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
        //typeid为-1，按请假类型分类统计，为-2，按全部统计，否则按请假类型统计
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

                if (typeid != -1 && typeid != -2)
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
                if(typeid == -1)//统计所有类型的,按类型分类
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
                if (typeid == -2)//统计所有类型的，不按类型分类,此函数用于考勤统计合计
                {
                    statistic = from attend in dtSelect.AsEnumerable()
                                group attend by new { id = attend["userid"], name = attend["username"] } into g
                                
                                select new Attendance_Statistic
                                {
                                    statisticStart = starttime,
                                    statisticEnd = endtime,
                                    status = st,
                                    dept = "",
                                    type = "",
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

                        day += (int)(hour / 5);
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
        //固定格式
        public class Attendance_Statistic_Guding
        {
            public string bianhao { get; set; }
            public int ordernum { get; set; }
            public int userid { get; set; }
            public string username { get; set; }
            public DateTime statisticStart { get; set; }
            public DateTime statisticEnd { get; set; }
            
            public int count { get; set; }
            public int shijia_count { get; set; }
            public int bingjia_count { get; set; }
            public Decimal chanjiaSpan { get; set; }
            public Decimal daySpan { get; set; }
            public int hourSpan { get; set; }
            public int chanjiaHourSpan { get; set; }


        }

        public static DataTable calculateResultGuding( DateTime starttime, DateTime endtime)
        {
            endtime = endtime.AddHours(23);
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
              

                //选出符合条件的所有记录，导入datatable中
                var kqSelect = dc.KQ_Attendance.Where(r => ((r.starttime < starttime && r.endtime > starttime) || (r.starttime > starttime && r.starttime < endtime)) && (r.typeid == 1 || r.typeid == 2 || r.typeid == 4));

                kqSelect = kqSelect.Where(r => !r.status.Contains("审批拒绝"));

                DataTable dtSelect = kqSelect.ToList().ConvertToDataTable();

                if (dtSelect.Rows.Count > 0)
                {
                    foreach (DataRow r in dtSelect.Rows)
                    {
                        Decimal daySpan = 0;
                        int hourSpan = 0;

                        DateTime applyStartTime = (DateTime)r["starttime"];
                        DateTime applyEndTime = (DateTime)r["endtime"];

                        if ((applyStartTime - starttime).TotalSeconds >= 0 && (applyEndTime - endtime).TotalSeconds <=0)
                        {
                            BLL.Application.KQ.Attendance.AttendanceStatistic.getSpanDateTime(applyStartTime, applyEndTime, ref daySpan, ref hourSpan);
                        }
                        else if ((applyStartTime - starttime).TotalSeconds<=0 && (applyEndTime - starttime).TotalSeconds>=0 && (applyEndTime - endtime).TotalSeconds<=0)
                        {
                            BLL.Application.KQ.Attendance.AttendanceStatistic.getSpanDateTime(starttime, applyEndTime, ref daySpan, ref hourSpan);

                        }
                        else if ((applyStartTime - starttime).TotalSeconds>=0 && (applyStartTime - endtime).TotalSeconds<=0 && (applyEndTime - endtime).TotalSeconds>=0)
                        {
                            BLL.Application.KQ.Attendance.AttendanceStatistic.getSpanDateTime(applyStartTime, endtime, ref daySpan, ref hourSpan);

                        }
                        else if ((applyStartTime - starttime).TotalSeconds<=0 && (applyEndTime - endtime).TotalSeconds>=0)
                        {
                            BLL.Application.KQ.Attendance.AttendanceStatistic.getSpanDateTime(starttime, endtime, ref daySpan, ref hourSpan);
                        }

                        r["daySpan"] = daySpan;
                        r["hourSpan"] = hourSpan;
                    }
                    dtSelect.AcceptChanges();
                }

                //统计临时表中每个人的请假次数和合计

                var statistic = from attend in dtSelect.AsEnumerable() //统计指定类型的请假
                                group attend by new { id = attend["userid"], name = attend["username"] } into g
                                select new Attendance_Statistic_Guding
                                {
                                    statisticStart = starttime,
                                    statisticEnd = endtime,
                                    userid = (int)g.Key.id,
                                    username = (string)g.Key.name,
                                    count = g.Count(),
                                    shijia_count = g.Count(t => Convert.ToInt32(t["typeid"]) == 1),
                                    bingjia_count = g.Count(b => Convert.ToInt32(b["typeid"]) == 2),
                                    daySpan = (Decimal)g.Where(s => Convert.ToInt32(s["typeid"]) != 4).Sum(x => Convert.ToDecimal(x["daySpan"])),
                                    chanjiaSpan = (Decimal)g.Where(s => Convert.ToInt32(s["typeid"]) == 4).Sum(x => Convert.ToDecimal(x["daySpan"])),
                                    hourSpan = (int)g.Where(s => Convert.ToInt32(s["typeid"]) != 4).Sum(x => Convert.ToDecimal(x["hourSpan"])),
                                    chanjiaHourSpan = (int)g.Where(s => Convert.ToInt32(s["typeid"]) == 4).Sum(x => Convert.ToDecimal(x["hourSpan"]))
                                };
                var users = from u in dc.Users
                            where u.UserType == '1'
                            orderby u.orderNo
                            select u;

                DataTable dtUsers = users.ToList().ConvertToDataTable();

                var sta = from u in dtUsers.AsEnumerable()
                          join t in statistic on u["Key"] equals t.userid
                          into g
                          from s in g.DefaultIfEmpty()
                          select new Attendance_Statistic_Guding
                          {
                              bianhao = u["bianhao"].ToString(),
                              ordernum = (u["orderNo"] == null) ? 999 : Convert.ToInt32( u["orderNo"]),
                              userid =  Convert.ToInt32( u["Key"]),
                              username = u["TrueName"].ToString(),
                              count = (s==null)?0: s.count,
                              shijia_count = (s == null) ? 0 : s.shijia_count,
                              bingjia_count = (s == null) ? 0 : s.bingjia_count,
                              daySpan = (s == null) ? 0 : s.daySpan,
                              hourSpan = (s == null) ? 0 : s.hourSpan,
                              chanjiaSpan = (s == null) ? 0 : s.chanjiaSpan,
                              chanjiaHourSpan = (s == null) ? 0 : s.chanjiaHourSpan

                          };


                if (sta != null && sta.Count() > 0)//将统计结果放入datatable中，最后返回统计table
                {
                    DataTable dt1 = new DataTable();
                    dt1.Columns.Add("序号");
                    dt1.Columns.Add("姓名");
                    dt1.Columns.Add("教工工号");
                    dt1.Columns.Add("共请假次数");
                    dt1.Columns.Add("事假次数");
                    dt1.Columns.Add("病假次数");
                    dt1.Columns.Add("合计天数");
                    dt1.Columns.Add("产假天数");
                    foreach (Attendance_Statistic_Guding t in sta)
                    {
                        Decimal day,chanjia_day;
                        int hour,chanjia_hour;
                        DataRow tj = dt1.NewRow();
                        tj["序号"] = t.ordernum;
                        tj["姓名"] = t.username;
                        tj["教工工号"] = t.bianhao;
                        tj["共请假次数"] = t.count;
                        tj["事假次数"] = t.shijia_count;
                        tj["病假次数"] = t.bingjia_count;
                        day = t.daySpan;
                        hour = t.hourSpan;

                        day += (int)(hour / 5);
                        day += ((hour % 5) / 3) == 1 ? 0.5M : 0;
                        hour = (hour % 5) % 3;
                        tj["合计天数"] = day;

                        chanjia_day = t.chanjiaSpan;
                        chanjia_hour = t.chanjiaHourSpan;

                        chanjia_day += (int)(chanjia_hour / 5);
                        chanjia_day += ((chanjia_hour % 5) / 3) == 1 ? 0.5M : 0;
                        chanjia_hour = (chanjia_hour % 5) % 3;
                        tj["产假天数"] = chanjia_day;

                        dt1.Rows.Add(tj);
                    }
                    return dt1;
                }
                else
                {
                    return null;
                }
            }
        }

    }
}
