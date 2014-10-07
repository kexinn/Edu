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
                ViewState["retu"] = Request.UrlReferrer.ToString();   
            }
        }

        protected void databind()
        {
            string roleid = Request.QueryString["roleid"];
            string parentid = Request.QueryString["parentid"];
            gvMenu.DataSource =  BLL.admin.menu.RoleMenus.getRoleMenuByRoleid(Convert.ToInt32(roleid), Convert.ToInt32(parentid));
            gvMenu.DataBind();

           lbJuese.Text = "当前角色：" + BLL.admin.role.RoleManagement.getRolesById(Convert.ToInt32(roleid)).Name;
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
          //  CheckBox ck = (CheckBox)sender;
         //  Label lbKey = ck.NamingContainer.FindControl("lbKey") as Label;
           // BLL.admin.menu.RoleMenus.roleMenuAuthorize(Convert.ToInt32(Request.QueryString["roleid"]), Convert.ToInt32(lbKey.Text), ck.Checked);
          //  databind();
        }

        protected void hlMenuName_DataBinding(object sender, EventArgs e)
        {
            HyperLink lb = (HyperLink)sender;
            BLL.admin.menu.RoleMenus.MenuRole menurole = GetDataItem() as BLL.admin.menu.RoleMenus.MenuRole;

            lb.NavigateUrl = "/admin/Menu/RoleMenus.aspx?parentid=" + menurole.menuId + "&roleid=" + Request.QueryString["roleid"];
            
        }

        protected void gvMenu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent)); //此得出的值是表示那行被选中的索引值 
            int menuid = Convert.ToInt32(gvMenu.DataKeys[drv.RowIndex].Value); //此获取的值为GridView中绑定数据库中的主键值 

            try
            {
                if (e.CommandName == "Auth")
                {
                    BLL.admin.menu.RoleMenus.roleMenuAuthorize(Convert.ToInt32(Request.QueryString["roleid"]), menuid, true);

                    databind();
                }
                else
                    if (e.CommandName == "Del")
                    {
                        BLL.admin.menu.RoleMenus.roleMenuAuthorize(Convert.ToInt32(Request.QueryString["roleid"]), menuid, false);
                        databind();
                    }
            }catch (Exception ex)
            {
                lbMessage.Text = "错误：" + ex.Message;
            }
        }

        protected void lbAuth_DataBinding(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            BLL.admin.menu.RoleMenus.MenuRole menurole = GetDataItem() as BLL.admin.menu.RoleMenus.MenuRole;

            CheckBox cb = lb.NamingContainer.FindControl("cbAuth") as CheckBox;
            if (cb.Checked)
                lb.Enabled = false;
            else
                lb.Enabled = true;
            
          
        }

        protected void lbDel_DataBinding(object sender, EventArgs e)
        {

            LinkButton lb = (LinkButton)sender;
            BLL.admin.menu.RoleMenus.MenuRole menurole = GetDataItem() as BLL.admin.menu.RoleMenus.MenuRole;

            CheckBox cb = lb.NamingContainer.FindControl("cbAuth") as CheckBox;
            if (cb.Checked)
                lb.Enabled = true;
            else
                lb.Enabled = false;
        }

        protected void LinkButtonPreview_Click(object sender, EventArgs e)
        {
            Response.Redirect(ViewState["retu"].ToString());   

        }

    }
}