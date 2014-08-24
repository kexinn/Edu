using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.WorkPlan
{
    public partial class WeekPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PanelAddPlan.Visible = false;
                databind();
            }
        }

        protected void databind()
        {
            Department_leader dept = BLL.admin.department.DepartmentManagement.getDepartmentByUserid(Convert.ToInt32( Session["userid"]));
            if(dept!=null)
            {
                gvWeekPlan.DataSource = BLL.Application.WorkPlan.WeekPlan.getWeekPlanByDeptid((int)dept.department_id);
                gvWeekPlan.DataBind();
            }
        }
        protected void btAdd_Click(object sender, EventArgs e)
        {
            Department_leader dept = BLL.admin.department.DepartmentManagement.getDepartmentByUserid(Convert.ToInt32( Session["userid"]));

            if (dept != null)
            {
                DateTime dt = DateTime.Now;  //当前时间

                DateTime startWeek = dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d")));  //本周周一
                DateTime endWeek = startWeek.AddDays(6);  //本周周日


                t_Work_Plan plan = new t_Work_Plan();
                plan.createTime = DateTime.Now;
                plan.isRelease = false;
                plan.isComplete = false;
                plan.isEvaluation = false;
                plan.detpId = dept.department_id;
                plan.username = Session["username"].ToString();
                plan.content = tbContent.Text;
                plan.sortNo = Convert.ToInt16(tbSortNo.Text);
                plan.isEvaluation = false;
                plan.planPeriod = startWeek.ToShortDateString() + "到" + endWeek.ToShortDateString();
                plan.type = '2';
                plan.year = DateTime.Now.Year;
                plan.month = DateTime.Now.Month;
                BLL.Application.WorkPlan.WeekPlan.insertWorkPlan(plan);
                databind();
            }
            else
                lbMessage.Text = "您没有权限操作！";
        }

        protected void lbAdd_Click(object sender, EventArgs e)
        {
            PanelAddPlan.Visible = true;
        }

        protected void gvWeekPlan_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvWeekPlan.PageIndex = e.NewPageIndex;
            databind();
        }

        protected void gvWeekPlan_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            gvWeekPlan.EditIndex = -1;
            databind();
        }

        protected void gvWeekPlan_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String id = gvWeekPlan.DataKeys[e.RowIndex].Value.ToString();

            if (BLL.Application.WorkPlan.WeekPlan.deleteWorkPlanById(Convert.ToInt32(id)))
            {
                lbMessage.Text = "删除计划成功！";
            }
            databind();
        }

        protected void gvWeekPlan_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvWeekPlan.EditIndex = e.NewEditIndex;
            databind();
        }

        protected void gvWeekPlan_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String id = gvWeekPlan.DataKeys[e.RowIndex].Value.ToString();
            String sortNo = ((TextBox)gvWeekPlan.Rows[e.RowIndex].Cells[1].FindControl("tbSortNo")).Text.ToString().Trim();
            String content = ((TextBox)gvWeekPlan.Rows[e.RowIndex].Cells[4].FindControl("tbContent")).Text.ToString().Trim();

            if (String.IsNullOrEmpty(sortNo))
                sortNo = "0";
            BLL.Application.WorkPlan.WeekPlan.updateWorkPlan(Convert.ToInt32(id), content, Convert.ToInt16(sortNo));


            gvWeekPlan.EditIndex = -1; //将GridView控件恢复为编辑前的状态。即更新完了就得回到非编辑状态
            databind(); //更新完了之后，就得重新绑定，即重新从数据库中读取刚才更新的数据。

        }

        protected void lbDel_DataBinding(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            v_WorkPlan plan = GetDataItem() as v_WorkPlan;

            if (plan.username != Session["username"].ToString())
                lb.Visible = false;
           
        }
    }
}