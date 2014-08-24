using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Application.WorkPlan
{
    public class PreWeekPlanEvalution
    {
        public static bool setWorkPlanCompleteById(int id)
        {
            using(DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                t_Work_Plan plan = dc.t_Work_Plan.Where(w => w.Id == id).Single();
                plan.isComplete = true;
                plan.evalutionContent = "";
                dc.SubmitChanges();
                return true;
            }
        }

        public static bool updateWorkPlanNotCompleteReason(int id, String reason)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                t_Work_Plan plan = dc.t_Work_Plan.Where(w => w.Id == id).Single();
                plan.isComplete = false;
                if(String.IsNullOrEmpty(reason))
                    plan.isEvaluation = false;
                else
                    plan.isEvaluation = true;
                plan.evalutionContent = reason;
                dc.SubmitChanges();
                return true;
            }
        }

        public static List<v_WorkPlan> getPreWeekPlanByDeptid(int deptid)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                DateTime dt = DateTime.Now;  //当前时间

                DateTime startWeek = dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d"))-7);  //上周周一
                DateTime endWeek = startWeek.AddDays(6);  //上周周日
                String period = startWeek.ToShortDateString() + "到" + endWeek.ToShortDateString();

                //var plans = dc.v_WorkPlan.Where(w => w.detpId == deptid && w.createTime >= Convert.ToDateTime(startWeek.ToShortDateString()) && w.createTime <= endWeek).OrderBy(u=>u.sortNo);
                var plans = dc.v_WorkPlan.Where(w => w.detpId == deptid && w.planPeriod == period).OrderBy(u => u.sortNo);

                if (plans.Count() != 0)
                    return plans.ToList();
                else
                    return null;

            }
        }
    }
}
