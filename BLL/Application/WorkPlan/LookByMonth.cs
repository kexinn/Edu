using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Application.WorkPlan
{
    public class LookByMonth
    {

        public static List<v_WorkPlan> getWorkPlanByDate(int year,int month,int num=0,char sort='0')
        {
            using(DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var item = dc.v_WorkPlan.Where(w => w.type == '1' && w.year == year && w.month == month).OrderBy(o => o.detpId);
                if (sort == '0')
                    item = item.OrderBy(u => u.planPeriod);
                else if (sort == '1')
                    item = item.OrderByDescending(u => u.planPeriod);

                
                if (num != 0)
                    return item.Take(num).ToList();
                return item.ToList();
            }
           
        }
    }
}
