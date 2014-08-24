using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Application.WorkPlan
{
    public class AssignTask
    {
        public static List<v_WorkPlan> getWeekPlanByUsername(String username)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                DateTime dt = DateTime.Now;  //当前时间

                DateTime startWeek = dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d")));  //本周周一
                DateTime endWeek = startWeek.AddDays(6);  //本周周日

                var plans = dc.v_WorkPlan.Where(w => w.username == username && w.createTime >= Convert.ToDateTime(startWeek.ToShortDateString()) && w.createTime <= endWeek).OrderBy(u => u.sortNo);
                if (plans.Count() != 0)
                    return plans.ToList();
                else
                    return null;

            }
        }

        public static List<v_WorkPlan> getSchoolWorkPlan()
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                DateTime dt = DateTime.Now;  //当前时间
               return  dc.v_WorkPlan.Where(w => w.type == '1' && w.year == dt.Year && w.month == dt.Month).ToList();
            }
        }
    }
}
