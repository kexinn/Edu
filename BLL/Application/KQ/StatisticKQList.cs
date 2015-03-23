using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using System.Reflection;

namespace BLL.Application.KQ
{
    public class KQStaticResult
    {
        public int 序号 { get; set; }
        public string 工号 { get; set; }
        public int id { get; set; }
        public string 姓名 { get; set; }
        public int 打卡次数 { get; set; }
        public int 上班次数 { get; set; }
        public int 下班次数 { get; set; }
        public int 迟到次数 { get; set; }
        public int 早退次数 { get; set; }
        public string 请假次数 { get; set; }
        public string 合计时长 { get; set; }
        public string 备注说明 { get; set; }


    }
    
    public static class  StatisticKQList
    {
        //转换var变量到datatable类型
        public static DataTable CopyToDataTable<T>(this IEnumerable<T> array)
        {
            var ret = new DataTable();
            foreach (PropertyDescriptor dp in TypeDescriptor.GetProperties(typeof(T)))
                ret.Columns.Add(dp.Name, dp.PropertyType);
            foreach (T item in array)
            {
                var Row = ret.NewRow();
                foreach (PropertyDescriptor dp in TypeDescriptor.GetProperties(typeof(T)))
                    Row[dp.Name] = dp.GetValue(item);
                ret.Rows.Add(Row);
            }
            return ret;
        }
        public static DataTable getStatisticResult(DateTime starttime,DateTime endtime,TimeSpan tsShangban,TimeSpan tsXiaban)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                //所有在编用户导入临时表
                var users = from u in dc.Users
                            where u.UserType == '1' && u.disabled == false && u.JobNumber !=null
                            select new KQStaticResult
                            {
                                序号 = (int)u.orderNo,
                                工号 = (String)u.JobNumber,
                                id = (int)u.Key,
                                姓名 = (String)u.TrueName
                            };
                DataTable resultTable = users.CopyToDataTable(); 
               
                //统计打卡结果
                TimeSpan timeShangban = tsShangban;  // new TimeSpan(8,0,0);//上班时间
                TimeSpan timeXiaban = tsXiaban;  //new TimeSpan(16, 25, 0);//下班时间
                var punchCardStatistic = from  kq in dc.KQ_PunchCardRecords 
                                         where kq.Time > starttime && kq.Time < endtime
                                         group kq by kq.PunchCardUserId into group_kq
                                         select new KQStaticResult
                                         {
                                             id = (int)group_kq.Key,
                                             打卡次数 = group_kq.Count(),
                                             上班次数 = group_kq.Count(kq => kq.PunchCardType == '1'),
                                             下班次数 = group_kq.Count(kq => kq.PunchCardType == '2'),
                                             迟到次数 = group_kq.Count(kq => kq.PunchCardType == '1' && (Convert.ToDateTime(kq.Time).TimeOfDay - timeShangban).TotalSeconds>0),
                                             早退次数 = group_kq.Count(kq => kq.PunchCardType == '2' && (Convert.ToDateTime(kq.Time).TimeOfDay - timeXiaban).TotalSeconds <= 0 && Convert.ToDateTime(kq.Time).DayOfWeek != System.DayOfWeek.Friday)
                                         };
                DataTable punchCardStatisticDatatable = punchCardStatistic.CopyToDataTable();
               
                //与用户表做左连接
                var result = from u in resultTable.AsEnumerable()
                             join p in punchCardStatisticDatatable.AsEnumerable() on u.Field<int>("id") equals p.Field<int>("id") 
                             into g
                             from p in g.DefaultIfEmpty()
                             orderby u.Field<int>("序号") 
                             select new KQStaticResult
                             {
                                 id = u.Field<int>("id"),
                                 序号 = u.Field<int>("序号"),
                                 工号 = (String)u.Field<string>("工号"),
                                 姓名 = (String)u.Field<string>("姓名"),
                                 打卡次数 = p == null ? 0 :p.Field<int>("打卡次数"),
                                 上班次数 = p == null ? 0 : p.Field<int>("上班次数"),
                                 下班次数 = p == null ? 0 : p.Field<int>("下班次数"),
                                 迟到次数 = p == null ? 0 : p.Field<int>("迟到次数"),
                                 早退次数 = p == null ? 0 : p.Field<int>("早退次数"),
                             };
                DataTable result1 = result.CopyToDataTable();//统计出打卡结果

                //统计请假结果
                BLL.Application.KQ.Attendance.statistic.Attendance_Statistic statistic = new BLL.Application.KQ.Attendance.statistic.Attendance_Statistic();
                statistic.dept = "";//部门
                statistic.status = "";//请假状态
                statistic.type = "";//请假类型

                DataTable dtAttend = BLL.Application.KQ.Attendance.statistic.calculateResult(statistic, starttime, endtime.AddHours(-23), "", "", -2);
                var remarks = from r in dc.KQ_SpecialRemark.Where(k=>(k.starttime<=starttime && k.endtime>=starttime) || (k.starttime>=starttime && k.starttime<=endtime) )
                              select new KQStaticResult
                              { 
                               id = (int)r.userid,
                               备注说明 = (String)r.remark
                              };
                DataTable dtRemark = remarks.CopyToDataTable();
                
                var result2 = from u in result1.AsEnumerable()
                              join a in dtAttend.AsEnumerable() on u.Field<int>("id").ToString() equals a["用户ID"].ToString()
                              into g
                              from n in g.DefaultIfEmpty()
                              join r in dtRemark.AsEnumerable() on u.Field<int>("id").ToString() equals r["id"].ToString()
                              into r1
                              from n1 in r1.DefaultIfEmpty()
                              orderby u.Field<int>("序号")
                              select new KQStaticResult
                              {
                                  id = u.Field<int>("id"),
                                  //序号 = u.Field<int>("序号"),
                                  工号 = (String)u.Field<string>("工号"),
                                  姓名 = (String)u.Field<string>("姓名"),
                                  打卡次数 =  u.Field<int>("打卡次数"),
                                  上班次数 = u.Field<int>("上班次数"),
                                  下班次数 =  u.Field<int>("下班次数"),
                                  迟到次数 =  n1==null? u.Field<int>("迟到次数"):0,
                                  早退次数 =  n1==null? u.Field<int>("早退次数"):0,
                                  请假次数 = n == null ? "0": n["请假次数"].ToString(),
                                  合计时长 = n == null ? "0": n["合计天数"].ToString() +"天"+n["剩余小时"].ToString() + "小时",
                                  备注说明 = n1==null?"":n1["备注说明"].ToString()
                              };
                DataTable re = result2.CopyToDataTable();

                return re;
            }
        }
    }
}
