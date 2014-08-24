using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.admin.user
{
    public partial class UserRoleManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PanelAddRole.Visible = false;
                databind();
            }
        }

        protected void databind()
        {
            String roleid = Request["roleid"];
            ViewState["roleid"] = roleid;

            List<v_Role_Users> users = BLL.admin.role.RoleManagement.getUsersInRole(Convert.ToInt32(roleid));

            gvRoleUsers.DataSource = users;
            gvRoleUsers.DataBind();
        }

        protected void lbAdd_Click(object sender, EventArgs e)
        {
            PanelAddRole.Visible = true;
        }


        protected void gvRoleUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String key = this.gvRoleUsers.DataKeys[e.RowIndex].Value.ToString();

            if (BLL.admin.role.RoleManagement.deleteRoleUserById(key))
            {
                lbMessage.Text = "删除用户成功！";
            }
            databind();
        }

        protected void gvRoles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvRoleUsers.PageIndex = e.NewPageIndex;
            databind();
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
 
            String roleid = (String)ViewState["roleid"];

            User_Role ur = new User_Role();
            ur.UserKey = userid;
            ur.RoleKey = Convert.ToInt32(roleid);
            if (e.CommandName == "Add")
            {
                BLL.admin.role.RoleManagement.insertRoleUser(ur);
                databind();
                lbMessage.Text = "添加成员成功！";
            }
        }
    }
}