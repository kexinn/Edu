using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Application.WorkPlan
{
    public class WorkPlanHistory
    {
        public static List<v_WorkPlan> getWeekPlanByCondition(int indexPg, int pgSize, ref pub.PagerTClass pageT,int deptid, String content = "", String startTime = "", String endTime = "")
        {

            IEnumerable<v_WorkPlan> items;
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                items = dc.v_WorkPlan;
                items = items.Where(i => i.detpId == deptid);
                if (!String.IsNullOrEmpty(content))
                    items = items.Where(i => i.content.Contains(content));
                if (!String.IsNullOrEmpty(startTime) && !String.IsNullOrEmpty(endTime))
                    items = items.Where(i => i.createTime >= Convert.ToDateTime(startTime) && i.createTime <= Convert.ToDateTime(endTime));
                else if (!String.IsNullOrEmpty(startTime))
                    items = items.Where(i => i.createTime >= Convert.ToDateTime(startTime));
                items = pageT.ShowPage(items, indexPg, pgSize);
                return items.ToList();

            }
        }

        public static bool updateWorkPlanToThisWeek(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                DateTime dt = DateTime.Now;  //当前时间

                DateTime startWeek = dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d")));  //本周周一
                DateTime endWeek = startWeek.AddDays(6);  //本周周日


                t_Work_Plan plan = dc.t_Work_Plan.Where(u => u.Id == id).Single();
                plan.createTime = DateTime.Now;
                plan.isRelease = false;
                plan.isComplete = false;
                plan.isEvaluation = false;
                plan.planPeriod = startWeek.ToShortDateString() + "到" + endWeek.ToShortDateString();
                plan.type = '2';
                plan.year = DateTime.Now.Year;
                plan.month = DateTime.Now.Month;
                dc.SubmitChanges();
                return true;
            }
        }

    }
}
