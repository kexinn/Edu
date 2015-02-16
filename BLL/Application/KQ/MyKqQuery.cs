using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Application.KQ
{
    public class MyKqQuery
    {
        public static List<KQ_Report> getMyKqQuery(int userid, ref int tot, int index = 0, int num = 0, string startdate = "",string enddate="")
        {
            using(DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var report = dc.KQ_Report.Where(l => l.userid == userid);
                if (!string.IsNullOrEmpty(startdate) && !string.IsNullOrEmpty(enddate))
                  report =  report.Where(l => l.date >= Convert.ToDateTime(startdate) && l.date <= Convert.ToDateTime(enddate));

                tot = report.Count();
                report = report.OrderByDescending(o => o.date).Skip(index);
                if (num != 0)
                    report = report.Take(num);
                return report.ToList();

            }
        }

        public class KQ_all_report :KQ_Report
        {
            public string username { get; set; }
            public int order { get; set; }
        }

        public static List<KQ_all_report> getAllKqQuery(ref int tot, int index = 0, int num = 0, string startdate = "", string enddate = "",string username ="")
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var report = from r in dc.KQ_Report
                             join u in dc.Users on r.userid equals u.Key
                             select new KQ_all_report
                             {
                                 username = u.TrueName,
                                 userid = r.userid,
                                 date = r.date,
                                 isChidao = r.isChidao,
                                 isClockOff = r.isClockOff,
                                 isClockOn = r.isClockOn,
                                 isKuanggong = r.isKuanggong,
                                 isQingjia = r.isQingjia,
                                 isZaotui = r.isZaotui,
                                 qingjiaTime = r.qingjiaTime,
                                 remark = r.remark,
                                 shangbanTime = r.shangbanTime,
                                 weekDay = r.weekDay,
                                 xiabanTime = r.xiabanTime,
                                 Id = r.Id,
                                 order = u.orderNo==null?999:(int)u.orderNo
                             };
                if (!string.IsNullOrEmpty(username))
                    report = report.Where(l => l.username.Contains(username));
                if (!string.IsNullOrEmpty(startdate) && !string.IsNullOrEmpty(enddate))
                    report = report.Where(l => l.date >= Convert.ToDateTime(startdate) && l.date <= Convert.ToDateTime(enddate));

                tot = report.Count();
                report = report.OrderBy(o => o.order).OrderByDescending(o=>o.date).Skip(index);
                if (num != 0)
                    report = report.Take(num);
                return report.ToList();

            }
        }
    }
}
