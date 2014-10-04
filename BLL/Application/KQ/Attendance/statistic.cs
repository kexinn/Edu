using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using System.Reflection;

namespace BLL.Application.KQ.Attendance
{
    public static class statistic
    {

        /// <summary>
        /// Convert a List{T} to a DataTable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static DataTable ConvertToDataTable<T>(this List<T> items)
        {
            var tb = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                Type t = GetCoreType(prop.PropertyType);
                tb.Columns.Add(prop.Name, t);
            }

            foreach (T item in items)
            {
                var values = new object[props.Length];

                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }
                tb.Rows.Add(values);
            }
            return tb;
        }

        /// <summary>
        /// Determine of specified type is nullable
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        /// <summary>
        /// Return underlying type if type is Nullable otherwise return the type.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Type GetCoreType(Type t)
        {
            if (t != null && IsNullable(t))
            {
                if (!t.IsValueType)
                {
                    return t;
                }
                else
                {
                    return Nullable.GetUnderlyingType(t);
                }
            }
            else
            {
                return t;
            }
        }

        public static DataTable calculateResult(Attendance_Statistic sta,DateTime starttime, DateTime endtime, String dept, String status, int typeid)
        {
            endtime = endtime.AddHours(23);
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
               // if (String.IsNullOrEmpty(dept))
               //     dept = "";
               // if (String.IsNullOrEmpty(status))
               //     status = "";
               // dc.sp_KQ_select_into_temp(starttime, endtime,dept,status,typeid);//选出所有时间范围内的记录，插入临时表

                //选出符合条件的所有记录，导入datatable中
                var kqSelect = dc.KQ_Attendance.Where(r => (r.starttime < starttime && r.endtime > starttime) || (r.starttime > starttime && r.starttime < endtime));

                if (!String.IsNullOrEmpty(dept))
                    kqSelect = kqSelect.Where(r => r.dept.Contains(dept));

                if (!String.IsNullOrEmpty(status))
                    kqSelect = kqSelect.Where(r => r.status.Contains(status));

                if (typeid != -1)
                    kqSelect = kqSelect.Where(r => r.typeid == typeid);
                
                DataTable dtSelect = kqSelect.ToList().ConvertToDataTable();

                if (dtSelect.Rows.Count > 0)
                {
                    foreach (DataRow r in dtSelect.Rows)
                    {
                        Decimal daySpan = 0;
                        int hourSpan = 0;

                        DateTime applyStartTime = (DateTime)r["starttime"];
                        DateTime applyEndTime = (DateTime)r["endtime"];

                        if (applyStartTime >= starttime && applyEndTime <= endtime)
                        {
                            BLL.Application.KQ.Attendance.AttendanceStatistic.getSpanDateTime(applyStartTime, applyEndTime, ref daySpan, ref hourSpan);
                        }
                        else if (applyStartTime < starttime && applyEndTime > starttime && applyEndTime < endtime)
                        {
                            BLL.Application.KQ.Attendance.AttendanceStatistic.getSpanDateTime(starttime, applyEndTime, ref daySpan, ref hourSpan);

                        }
                        else if (applyStartTime > starttime && applyStartTime < endtime && applyEndTime > endtime)
                        {
                            BLL.Application.KQ.Attendance.AttendanceStatistic.getSpanDateTime(applyStartTime, endtime, ref daySpan, ref hourSpan);

                        }
                        else if (applyStartTime < starttime && applyEndTime > endtime)
                        {
                            BLL.Application.KQ.Attendance.AttendanceStatistic.getSpanDateTime(starttime, endtime, ref daySpan, ref hourSpan);
                        }

                        r["daySpan"] = daySpan;
                        r["hourSpan"] = hourSpan;
                    }
                    dtSelect.AcceptChanges();
                }
             
                //统计临时表中每个人的请假次数和合计
                string st = sta.status;
                string de = sta.dept;
                string ty = sta.type;

                var statistic = from attend in dtSelect.AsEnumerable() //统计指定类型的请假
                                group attend by new { id = attend["userid"], name = attend["username"],dept1 = attend["dept"] } into g
                                orderby g.Key.dept1
                                select new Attendance_Statistic
                                {
                                    statisticStart = starttime,
                                    statisticEnd = endtime,
                                    status = st,
                                    dept = (string)g.Key.dept1,
                                    type = ty,
                                    userid = (int)g.Key.id,
                                    username = (string)g.Key.name,
                                    count = g.Count(),
                                    daySpan = (Decimal)g.Sum(x => Convert.ToDecimal(x["daySpan"])),
                                    hourSpan = (int)g.Sum(x => Convert.ToDecimal(x["hourSpan"]))
                                };
                if(typeid == -1)//统计所有类型的
                {
                    statistic = from attend in dtSelect.AsEnumerable()
                                join t in dc.KQ_AttendanceType on attend["typeid"] equals t.Id
                                group attend by new { id = attend["userid"], name = attend["username"],type = t.name,dept1=attend["dept"] } into g
                                orderby g.Key.type
                                select new Attendance_Statistic
                                {
                                    statisticStart = starttime,
                                    statisticEnd = endtime,
                                    status = st,
                                    dept = (string)g.Key.dept1,
                                    type = g.Key.type,
                                    userid = (int)g.Key.id,
                                    username = (string)g.Key.name,
                                    count = g.Count(),
                                    daySpan = (Decimal)g.Sum(x => Convert.ToDecimal(x["daySpan"])),
                                    hourSpan = (int)g.Sum(x => Convert.ToDecimal(x["hourSpan"]))
                                };
                }
                if (statistic != null && statistic.Count() > 0)//将统计结果放入datatable中，最后返回统计table
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("开始时间");
                    dt.Columns.Add("结束时间");
                    dt.Columns.Add("用户ID");
                    dt.Columns.Add("姓名");
                    dt.Columns.Add("请假状态");
                    dt.Columns.Add("请假类型");
                    dt.Columns.Add("部门");
                    dt.Columns.Add("请假次数");
                    dt.Columns.Add("合计天数");
                    dt.Columns.Add("剩余小时");
                    foreach (Attendance_Statistic t in statistic)
                    {
                        Decimal day;
                        int hour;
                        DataRow tj = dt.NewRow();
                        tj["用户ID"] = t.userid;
                        tj["请假次数"] = t.count;
                        day = t.daySpan;
                        hour = t.hourSpan;

                        day += (int)(day / 5);
                        day += ((hour % 5) / 3) == 1 ? 0.5M : 0;
                        hour = (hour % 5) % 3;
                        tj["合计天数"] = day;
                        tj["剩余小时"] = hour;
                        tj["开始时间"] = t.statisticStart.ToShortDateString();
                        tj["结束时间"] = t.statisticEnd.ToShortDateString();
                        tj["姓名"] = t.username;
                        tj["请假状态"] = t.status;
                        tj["请假类型"] = t.type;
                        tj["部门"] = t.dept;
                        dt.Rows.Add(tj);
                    }
                    return dt;
                }else
                {
                    return null;
                }
            }
        }
        public class Attendance_Statistic
        {
            public int userid { get; set; }
            public string username { get; set; }
            public DateTime statisticStart { get; set; }
            public DateTime statisticEnd { get; set; }
            public string status { get; set; }
            public string type { get; set; }
            public string dept { get; set; }
            public int count { get; set; }
            public Decimal daySpan { get; set; }
            public int hourSpan { get; set; }


        }

    }
}
