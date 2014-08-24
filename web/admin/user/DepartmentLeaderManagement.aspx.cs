using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.admin.user
{
    public partial class DepartmentLeaderManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                PanelAddLeader.Visible = false;
                databind();
            }
        }
        protected void databind()
        {
            String departmentid = Request["id"];
            ViewState["id"] = departmentid;


            List<v_Deparment_Leader> users = BLL.admin.department.DepartmentManagement.getDepartmentLeadersByDepartmentId(Convert.ToInt32(departmentid));


            gvDepartmentLeader.DataSource = users;
            gvDepartmentLeader.DataBind();
        }
        protected void lbAdd_Click(object sender, EventArgs e)
        {

            PanelAddLeader.Visible = true;
        }

        protected void btLookfor_Click(object sender, EventArgs e)
        {
            gvSearchUser.DataSource = BLL.admin.user.UserManagement.getUsersByTruename(tbTrueName.Text);
            gvSearchUser.DataBind();
        }

        protected void gvSearchUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent)); //此得出的值是表示那行被选中的索引值 
            int userid = Convert.ToInt32(gvSearchUser.DataKeys[drv.RowIndex].Value); //此获取的值为GridView中绑定数据库中的主键值 

            String departmentid = (String)ViewState["id"];

            Department_leader dl = new Department_leader();
            dl.department_id = Convert.ToInt32(departmentid);
            dl.leader_id = userid;

            if (e.CommandName == "Add")
            {
                BLL.admin.department.DepartmentManagement.insertIntoDepartmentLeader(dl);
                databind();
                lbMessage.Text = "添加成员成功！";
            }
        }

        protected void gvDepartmentLeader_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String id = this.gvDepartmentLeader.DataKeys[e.RowIndex].Value.ToString();

            if (BLL.admin.department.DepartmentManagement.deleteDepartmentLeaderById(id))
            {
                lbMessage.Text = "删除用户成功！";
            }
            databind();
        }

        protected void gvDepartmentLeader_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvDepartmentLeader.PageIndex = e.NewPageIndex;
            databind();
        }
    }
}