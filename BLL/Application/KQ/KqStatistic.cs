using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL.Application.KQ
{
    public class kq_statistic
    {
        public int 序号 { get; set; }
        public string 工号 { get; set; }
        public string 姓名 { get; set; }
        public string  考勤周期 { get; set; }
        public int 上班应打卡 { get; set; }
        public int 上班实打卡 { get; set; }
        public int 迟到次数 { get; set; }
        public int 下班应打卡 { get; set; }
        public int 下班实打卡 { get; set; }
        public int 早退次数 { get; set; }
        public int 旷工次数 { get; set; }
        public int 事假次数 { get; set; }
        public string 事假时长 { get; set; }
        public int 病假次数 { get; set; }
        public string 病假时长 { get; set; }
       // public string 病事假时长 { get; set; }

        public string 产假时长 { get; set; }

        public string 备注 { get; set; }
    }

    public class KqStatistic
    {
        public static List<kq_statistic> getKqStatistic(DateTime start,DateTime end,string username = "")
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {

                DataTable attTable = KQ.Attendance.statistic.calculateResultGuding(start, end);//统计请假情况
                var result = from u in dc.Users    
                             where u.UserType == '1' && u.disabled == false
                             orderby u.orderNo
                             join r in from rp in  dc.KQ_Report
                                where rp.date >= start && rp.date <= end
                                group rp by rp.userid
                                into g
                                select new  {
                                    userid = g.Key,
                                    上班应打卡次数 = g.Count(s => s.isClockOn == true),
                                    上班实打卡次数 = g.Count(r => r.shangbanTime !=""),
                                    迟到次数 = g.Count(r => r.isChidao == true),
                                    下班应打卡次数 = g.Count(r => r.isClockOff == true),
                                    下班实打卡次数 = g.Count(r => r.xiabanTime!=""),
                                    早退次数 = g.Count(r => r.isZaotui == true),
                                    旷工次数 = g.Count(r=>r.isKuanggong == true)
                                }
                                
                             on u.Key equals r.userid
                             into t1
                             from r1 in t1.DefaultIfEmpty()
                             
                             select new kq_statistic
                             {
                                 序号 = (int)u.orderNo,
                                 工号 = u.bianhao,
                                 姓名 = u.TrueName,
                                 考勤周期 = start.ToShortDateString() + "到" + end.ToShortDateString(),
                                 上班应打卡 = (r1 == null) ? 0 : r1.上班应打卡次数,
                                 上班实打卡 = (r1 == null) ? 0 : r1.上班实打卡次数,
                                 迟到次数 = (r1 == null) ? 0 : r1.迟到次数,
                                 下班应打卡 = (r1 == null) ? 0 : r1.下班应打卡次数,
                                 下班实打卡 = (r1 == null) ? 0 : r1.下班实打卡次数,
                                 早退次数 = (r1 == null) ? 0 : r1.早退次数,
                                 旷工次数 = (r1==null)?0:r1.旷工次数

                             };
                List<kq_statistic> list = result.ToList();

                var re = from a in attTable.AsEnumerable()
                         join r in list
                         on a["姓名"].ToString() equals r.姓名
                         select new kq_statistic
                         {
                             序号 = r.序号,
                             工号 = r.工号,
                             姓名 = r.姓名,
                             考勤周期 = r.考勤周期,
                             上班应打卡 = r.上班应打卡,
                             上班实打卡 = r.上班实打卡,
                             迟到次数 = r.迟到次数,
                             下班应打卡 = r.下班应打卡,
                             下班实打卡 = r.下班实打卡,
                             早退次数 = r.早退次数,
                             旷工次数 = r.旷工次数,
                             事假次数 = Convert.ToInt32(a["事假次数"]),
                             事假时长 = (a["事假时长"].ToString() == "0") ? "0" : a["事假时长"].ToString() + "天",
                             病假次数 = Convert.ToInt32(a["病假次数"]),
                             病假时长 = (a["病假时长"].ToString() == "0") ? "0" : a["病假时长"].ToString() + "天",
                             产假时长 = (a["产假天数"].ToString()=="0")?"0":a["产假天数"].ToString()+"天"

                         };
               
                return re.ToList();

            }
        }
    }
}
