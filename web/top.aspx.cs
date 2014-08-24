using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web
{
    public partial class top : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                initMessageNum();
                initMenu();
            }
        }

        protected void initMenu()
        {
            if (BLL.admin.role.RoleManagement.ifUserInRole(Convert.ToInt32(Session["userid"]), 1))
                PanelConfigure.Visible = true;
            else
                PanelConfigure.Visible = false;
        }
        protected void initMessageNum()
        {
           int num =  BLL.Application.RoutTask.getTaskNumByUserId(Convert.ToInt32(Session["userid"]));
           this.bnum.InnerHtml = num.ToString();
        }
        protected void lbLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
           // Response.Redirect("/Login.aspx");
        }
    }
}