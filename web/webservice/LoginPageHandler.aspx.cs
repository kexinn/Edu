using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.webservice
{
    public partial class LoginPageHandler1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String userid = Request.QueryString["userid"];
            String pwd = Request.QueryString["password"];
            Users user = BLL.admin.user.UserManagement.getUserByNetid(userid, "000000");
            if (user != null)
            {

                Session.Timeout = 12 * 60;
                Session["userid"] = user.Key;
                Session["netid"] = user.XMPY;
                Session["username"] = user.TrueName;
                Response.Redirect("/Default.aspx");
            }
        }
    }
}