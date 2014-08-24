using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Application.WorkPlan
{
    public class WorkPlanRight 
    {

        public static List<v_WorkPlan> getWeekPlan()
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                DateTime dt = DateTime.Now;  //当前时间

                DateTime startWeek = dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d")));  //本周周一
                DateTime endWeek = startWeek.AddDays(6);  //本周周日
                String period = startWeek.ToShortDateString() + "到" + endWeek.ToShortDateString();

                //var plans = dc.v_WorkPlan.Where(w => w.detpId == deptid && w.createTime >= Convert.ToDateTime(startWeek.ToShortDateString()) && w.createTime <= endWeek).OrderBy(u=>u.sortNo);
                var plans = dc.v_WorkPlan.Where(w =>  w.planPeriod == period).OrderBy(u => u.sortNo).OrderBy(o=>o.detpId);

                if (plans.Count() != 0)
                    return plans.ToList();
                else
                    return null;

            }
        }
    }
}
