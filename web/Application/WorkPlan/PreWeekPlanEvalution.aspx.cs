using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.WorkPlan
{
    public partial class PreWeekPlanEvalution : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
            }
        }
        protected void databind()
        {
            Department_leader dept = BLL.admin.department.DepartmentManagement.getDepartmentByUserid(Convert.ToInt32(Session["userid"]));
            if (dept != null)
            {
                gvWeekPlan.DataSource = BLL.Application.WorkPlan.PreWeekPlanEvalution.getPreWeekPlanByDeptid((int)dept.department_id);
                gvWeekPlan.DataBind();
            }
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

        protected void gvWeekPlan_RowDeleting(object sender, GridViewDeleteEventArgs e)//完成按钮
        {
            String id = gvWeekPlan.DataKeys[e.RowIndex].Value.ToString();

            BLL.Application.WorkPlan.PreWeekPlanEvalution.setWorkPlanCompleteById(Convert.ToInt32(id));
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
            String EvaContent = ((TextBox)gvWeekPlan.Rows[e.RowIndex].Cells[7].FindControl("tbEvaContent")).Text;

            BLL.Application.WorkPlan.PreWeekPlanEvalution.updateWorkPlanNotCompleteReason(Convert.ToInt32(id), EvaContent);


            gvWeekPlan.EditIndex = -1; //将GridView控件恢复为编辑前的状态。即更新完了就得回到非编辑状态
            databind(); //更新完了之后，就得重新绑定，即重新从数据库中读取刚才更新的数据。
        }
    }
}