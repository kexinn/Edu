using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.admin.Menu
{
    public partial class RoleMenus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                databind();
            }
        }

        protected void databind()
        {
            string roleid = Request.QueryString["roleid"];
            string parentid = Request.QueryString["parentid"];
            gvMenu.DataSource =  BLL.admin.menu.RoleMenus.getRoleMenuByRoleid(Convert.ToInt32(roleid), Convert.ToInt32(parentid));
            gvMenu.DataBind();
        }


        protected void imgStatus_DataBinding(object sender, EventArgs e)
        {
            Image img = (Image)sender;
            BLL.admin.menu.RoleMenus.MenuRole menurole = GetDataItem() as BLL.admin.menu.RoleMenus.MenuRole;
            if (menurole.status)
                img.ImageUrl = "/media/images/check-64.png";
            else
                img.ImageUrl = "/media/images/t03.png";
        }

        protected void cbAuth_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ck = (CheckBox)sender;
           Label lbKey = ck.NamingContainer.FindControl("lbKey") as Label;
            BLL.admin.menu.RoleMenus.roleMenuAuthorize(Convert.ToInt32(Request.QueryString["roleid"]), Convert.ToInt32(lbKey.Text), ck.Checked);
            
        }

        protected void hlMenuName_DataBinding(object sender, EventArgs e)
        {
            HyperLink lb = (HyperLink)sender;
            BLL.admin.menu.RoleMenus.MenuRole menurole = GetDataItem() as BLL.admin.menu.RoleMenus.MenuRole;

            lb.NavigateUrl = "/admin/Menu/RoleMenus.aspx?parentid=" + menurole.menuId + "&roleid=" + Request.QueryString["roleid"];
            
        }

    }
}