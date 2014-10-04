using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.admin.user
{
    public partial class RoleManagement : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PanelAddRole.Visible = false;
                databind();
            }
        }

        protected void databind( )
        {


            List<Roles> roles = null;


            roles = BLL.admin.role.RoleManagement.getRoles();


            gvRoles.DataSource = roles;
            gvRoles.DataBind();
        }

        protected void lbRoleName_DataBinding(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            Roles role = GetDataItem() as Roles;

            lb.PostBackUrl = "/admin/user/UserRoleManagement.aspx?roleid=" + role.Key;
        }

        protected void gvRoles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvRoles.PageIndex = e.NewPageIndex;
            databind();
        }

        protected void gvRoles_RowEditing(object sender, GridViewEditEventArgs e)
        {

            gvRoles.EditIndex = e.NewEditIndex;
            databind();
        }

        protected void gvRoles_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String id = gvRoles.DataKeys[e.RowIndex].Value.ToString();
            String strRoleName = ((TextBox)gvRoles.Rows[e.RowIndex].Cells[2].FindControl("tbRoleName")).Text.ToString().Trim();
            String strRemark = ((TextBox)gvRoles.Rows[e.RowIndex].Cells[3].FindControl("tbRemark")).Text.ToString().Trim();

            Roles role = BLL.admin.role.RoleManagement.getRolesById(Convert.ToInt32(id));
            role.Key = Convert.ToInt32(id);
            role.Name = strRoleName;
            role.Remark = strRemark;
            BLL.admin.role.RoleManagement.updateRole(role);


            gvRoles.EditIndex = -1; //将GridView控件恢复为编辑前的状态。即更新完了就得回到非编辑状态
            databind(); //更新完了之后，就得重新绑定，即重新从数据库中读取刚才更新的数据。

        }

        protected void gvRoles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String id = gvRoles.DataKeys[e.RowIndex].Value.ToString();

            if( BLL.admin.role.RoleManagement.ifRoleHasUsers(Convert.ToInt32(id)))
            {

                lbMessage.Text = "该角色还有关联用户，不能删除，请先删除该角色中的用户！";
                BLL.pub.PubClass.showAlertMessage(Page, ClientScript, "该角色还有关联用户，不能删除!");
                return;
            }

            if (BLL.admin.role.RoleManagement.deleteRoleById(id))
            {
                lbMessage.Text = "删除角色成功！";
                BLL.pub.PubClass.showAlertMessage(Page, ClientScript, "删除角色成功!");
            }
            databind();
        }

        protected void gvRoles_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            gvRoles.EditIndex = -1;
            databind();
        }

        protected void lbAdd_Click(object sender, EventArgs e)
        {
            PanelAddRole.Visible = true;
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            String id = tbRoleKey.Text;
            String strRoleName = tbRoleName.Text;
            String strRoleRemark = tbRoleRemark.Text;

            Roles role = new Roles();
            role.Key = Convert.ToInt32(id);
            role.Name = strRoleName;
            role.Remark = strRoleRemark;

            if (BLL.admin.role.RoleManagement.createRole(role))
            {
                lbMessage.Text = "创建角色成功!";
            }
            databind();
        }

        protected void lbAuth_DataBinding(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            Roles role = GetDataItem() as Roles;

            lb.PostBackUrl = "/admin/Menu/RoleMenus.aspx?parentid=0&roleid=" + role.Key;
        }
    }
}