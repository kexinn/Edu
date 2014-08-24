using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.WorkPlan
{
    public partial class AssignTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PanelAddPlan.Visible = false;
                init();
            }
        }

        protected void init()
        {
            if (!BLL.admin.department.DepartmentManagement.userInDepartment(16, Convert.ToInt32(Session["userid"].ToString())) && !BLL.admin.department.DepartmentManagement.userInDepartment(13, Convert.ToInt32(Session["userid"].ToString())))//不在校长室或校办不能添加
            {
                lbAdd.Enabled = false;
                lbMessage.Text = "您无权操作";
            }
            else
            {
                tbDate.Text = DateTime.Now.ToShortDateString();
                initDept();
                databind();
            }
        }
        protected void initDept()
        {
            List<Department> list = BLL.admin.department.DepartmentManagement.getDepartments();
            ddlDept.Items.Clear();
            ddlDept.Items.Add(new ListItem(""));
            foreach (Department dl in list)
            {
                ListItem li = new ListItem();
                li.Value = dl.ID.ToString();
                li.Text = dl.Name;
                ddlDept.Items.Add(li);
            }
        }

        protected void databind()
        {

            gvWeekPlan.DataSource = BLL.Application.WorkPlan.AssignTask.getSchoolWorkPlan();
            gvWeekPlan.DataBind();
        }
        protected void lbAdd_Click(object sender, EventArgs e)
        {
            PanelAddPlan.Visible = true;
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            DateTime dt = Convert.ToDateTime(tbDate.Text);  //选择的时间

            DateTime startWeek = dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d")));  //当周周一
            DateTime endWeek = startWeek.AddDays(6);  //当周周日


            t_Work_Plan plan = new t_Work_Plan();
            plan.createTime = DateTime.Now;
            
            plan.isRelease = false;
            plan.isComplete = false;
            plan.isEvaluation = false;
            plan.type = '1';
            plan.year = dt.Year;
            plan.month = dt.Month;
            plan.sortNo = 0;
            plan.detpId = Convert.ToInt32( ddlDept.SelectedValue);
            plan.username = Session["username"].ToString();
            plan.content = tbContent.Text;
            plan.planPeriod = startWeek.ToShortDateString() + "到" + endWeek.ToShortDateString();
            plan.isEvaluation = false;
            BLL.Application.WorkPlan.WeekPlan.insertWorkPlan(plan);
            databind();
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
            String content = ((TextBox)gvWeekPlan.Rows[e.RowIndex].Cells[4].FindControl("tbContent")).Text.ToString().Trim();

            BLL.Application.WorkPlan.WeekPlan.updateWorkPlan(Convert.ToInt32(id),  content,0);


            gvWeekPlan.EditIndex = -1; //将GridView控件恢复为编辑前的状态。即更新完了就得回到非编辑状态
            databind(); //更新完了之后，就得重新绑定，即重新从数据库中读取刚才更新的数据。
        }

    }
}