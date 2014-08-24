using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BLL;

namespace web.Application.WorkPlan
{
    public partial class WorkPlanRight : System.Web.UI.Page
    {
        String period = "";
        int i = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initdate();
                databind();
                PanelDept.Visible = false;
            }
        }

        protected void initdate()
        {
            lbMonth.Text = DateTime.Now.Month.ToString() + "月";
            ddlDeptList.Items.Clear();
            ListItem li = new ListItem("本月学校工作");
            li.Value = "1";
            ddlDeptList.Items.Add(li);
            ListItem li1 = new ListItem("本周各部门工作");
            li1.Value = "2";
            ddlDeptList.Items.Add(li1);

        }

        protected void databind()
        {
            DateTime date = DateTime.Now;
            RepeaterWorkMonth.DataSource = BLL.Application.WorkPlan.LookByMonth.getWorkPlanByDate(date.Year, date.Month);
            RepeaterWorkMonth.DataBind();

        }

        protected void databindDept()
        {

            RepeaterDept.DataSource = BLL.Application.WorkPlan.WorkPlanRight.getWeekPlan();
            RepeaterDept.DataBind();
        }

        protected void imgState_DataBinding(object sender, EventArgs e)
        {
            Image img = (Image)sender;
            v_WorkPlan plan = GetDataItem() as v_WorkPlan;

            if ((bool)plan.isComplete)
                img.ImageUrl = "/media/images/check-64.png";
            else
            {
                img.ImageUrl = "/media/images/t03.png";
            }
        }

        protected void Unnamed_DataBinding(object sender, EventArgs e)
        {
            HtmlControl hc = (HtmlControl)sender;
            v_WorkPlan plan = GetDataItem() as v_WorkPlan;
            if(i==1)
            {
                period = plan.planPeriod;
                i++;
                return;
            }
            if (period == plan.planPeriod)
            {

            }else
            {
                i++;
                period = plan.planPeriod;

            }

            if (i % 2 == 1)
                hc.Attributes.Add("style", "background-color:#e3f0f5;");
            else
                hc.Attributes.Add("style", "background-color:white;");
        }

        protected void ddlDeptList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDeptList.SelectedValue == "1")
            {
                PanelSchool.Visible = true;
                PanelDept.Visible = false;
            }
            else if (ddlDeptList.SelectedValue == "2")
            {
                databindDept();

                DateTime dt = DateTime.Now;  //当前时间
                DateTime startWeek = dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d")));  //本周周一
                DateTime endWeek = startWeek.AddDays(6);  //本周周日
                String period = startWeek.ToShortDateString() + "到" + endWeek.ToShortDateString();
                lbDate.Text = period;
                PanelSchool.Visible = false;
                PanelDept.Visible = true;
            }
        }
    }
}