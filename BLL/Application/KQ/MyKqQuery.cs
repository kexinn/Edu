using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Application.KQ
{
    public class MyKqQuery
    {
        public static List<KQ_Report> getMyKqQuery(int userid, ref int tot, int index = 0, int num = 0, string date = "")
        {
            using(DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var report = dc.KQ_Report.Where(l => l.userid == userid);
                if (!string.IsNullOrEmpty(date))
                    report.Where(l => l.date == Convert.ToDateTime(date));

                tot = report.Count();
                report = report.OrderByDescending(o => o.date).Skip(index);
                if (num != 0)
                    report = report.Take(num);
                return report.ToList();

            }
        }
    }
}
