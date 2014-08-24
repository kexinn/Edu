using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.WorkPlan
{
    public partial class WorkPlanHistory : System.Web.UI.Page
    {
        BLL.pub.PagerTClass pageT = new BLL.pub.PagerTClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["index_page"] = 1;
                databind();

            }
        }

        protected void databind(int pageIndex = 1)
        {
            List<v_WorkPlan> plans = null;
            ViewState["searchContent"] = tbContent.Text;
            ViewState["searchStartTime"] = tbStartTime.Text;
            ViewState["searchEndTime"] = tbEndTime.Text;

            Department_leader dept = BLL.admin.department.DepartmentManagement.getDepartmentByUserid(Convert.ToInt32(Session["userid"]));
            plans = BLL.Application.WorkPlan.WorkPlanHistory.getWeekPlanByCondition(pageIndex, BLL.pub.PubClass.PAGE_SIZE, ref pageT,(int)dept.department_id,(String)ViewState["searchContent"], (String)ViewState["searchStartTime"], (String)ViewState["searchEndTime"] );
            setPaginationStatus();
            ViewState["tot_page"] = pageT.PageCount;


            gvWeekPlan.DataSource = plans;
            gvWeekPlan.DataBind();
        }

        protected void setPaginationStatus()
        {
            
            lbTotPage.Text = pageT.PageCount.ToString();
            lbIndexPage.Text = pageT.IndexPage.ToString();
            lbTotPage1.Text = pageT.PageCount.ToString();

            lbPrePage.Enabled = pageT.PrevShow;
            lbNexPage.Enabled = pageT.NextShow;
        }
        protected void lbSearch_Click(object sender, EventArgs e)
        {
            databind();
        }

        protected void gvWeekPlan_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            gvWeekPlan.EditIndex = -1;
            databind((int)ViewState["index_page"]);
        }

        
        protected void gvWeekPlan_RowEditing(object sender, GridViewEditEventArgs e)
        {

            gvWeekPlan.EditIndex = e.NewEditIndex;
            databind((int)ViewState["index_page"]);
        }

        protected void gvWeekPlan_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String id = gvWeekPlan.DataKeys[e.RowIndex].Value.ToString();
            String EvaContent = ((TextBox)gvWeekPlan.Rows[e.RowIndex].Cells[7].FindControl("tbEvaContent")).Text;

            BLL.Application.WorkPlan.PreWeekPlanEvalution.updateWorkPlanNotCompleteReason(Convert.ToInt32(id), EvaContent);


            gvWeekPlan.EditIndex = -1; //将GridView控件恢复为编辑前的状态。即更新完了就得回到非编辑状态
            databind((int)ViewState["index_page"]);
        }

        protected void lbFirstPage_Click(object sender, EventArgs e)
        {

            ViewState["index_page"] = 1;
            databind(1);
        }

        protected void lbPrePage_Click(object sender, EventArgs e)
        {

            ViewState["index_page"] = Convert.ToInt32(lbIndexPage.Text) - 1;
            databind((int)ViewState["index_page"]);
        }

        protected void lbNexPage_Click(object sender, EventArgs e)
        {

            ViewState["index_page"] = Convert.ToInt32(lbIndexPage.Text) + 1;
            databind((int)ViewState["index_page"]);
        }

        protected void lbLastPage_Click(object sender, EventArgs e)
        {

            ViewState["index_page"] = ((int)ViewState["tot_page"]);
            databind((int)ViewState["tot_page"]);
        }

        protected void lbGo_Click(object sender, EventArgs e)
        {

            ViewState["index_page"] = Convert.ToInt32(tbGoNo.Text);
            databind((int)ViewState["index_page"]);
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

        protected void gvWeekPlan_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "complete")
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                BLL.Application.WorkPlan.PreWeekPlanEvalution.setWorkPlanCompleteById(Convert.ToInt32(id));
                databind((int)ViewState["index_page"]);
            }
            if(e.CommandName == "week")
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                BLL.Application.WorkPlan.WorkPlanHistory.updateWorkPlanToThisWeek(id);
            }
        }
    }
}