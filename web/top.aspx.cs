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
            Session.Abandon();

            //HttpCookie aCookie;
            //string cookieName;
            //int limit = Request.Cookies.Count;
            //for (int i = 0; i < limit; i++)
            //{
            //    cookieName = Request.Cookies[i].Name;
            //    aCookie = new HttpCookie(cookieName);
            //    aCookie.Expires = DateTime.Now.AddDays(-1);
            //    Response.Cookies.Add(aCookie);
            //}
            Response.Redirect("https://sso.nbyzzj.cn:8443/cas/logout");
            //Response.Write("<script>window.top.close();</script>");
            Response.Redirect("/Default.aspx");
        }
    }
}