using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Application.WorkPlan
{
    public class WeekPlan
    {
        public static List<v_WorkPlan> getWeekPlanByDeptid(int deptid)
        {
            using(DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                DateTime dt = DateTime.Now;  //当前时间

                DateTime startWeek = dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d")));  //本周周一
                DateTime endWeek = startWeek.AddDays(6);  //本周周日
                String period = startWeek.ToShortDateString()+"到" + endWeek.ToShortDateString();

                //var plans = dc.v_WorkPlan.Where(w => w.detpId == deptid && w.createTime >= Convert.ToDateTime(startWeek.ToShortDateString()) && w.createTime <= endWeek).OrderBy(u=>u.sortNo);
                var plans = dc.v_WorkPlan.Where(w => w.detpId == deptid && w.planPeriod == period).OrderBy(u => u.sortNo);
                
                if (plans.Count() != 0)
                    return plans.ToList();
                else
                    return null;

            }
        }

        public static bool insertWorkPlan(t_Work_Plan plan)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                dc.t_Work_Plan.InsertOnSubmit(plan);
                dc.SubmitChanges();
                return true;
            }
        }

        public static bool deleteWorkPlanById(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
               t_Work_Plan plan = dc.t_Work_Plan.Where(w => w.Id == id).Single();
               dc.t_Work_Plan.DeleteOnSubmit(plan);
               dc.SubmitChanges();
               return true;
            }
        }

        public static bool updateWorkPlan(int id, String content, Int16 sortNO = 0)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                t_Work_Plan plan = dc.t_Work_Plan.Where(w => w.Id == id).Single();
                plan.sortNo = sortNO;
                plan.content = content;
                dc.SubmitChanges();
                return true;
            }
        }
    }
}
