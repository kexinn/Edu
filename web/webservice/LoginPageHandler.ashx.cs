using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;

namespace web.webservice
{
    /// <summary>
    /// LoginPageHandler 的摘要说明
    /// </summary>
    public class LoginPageHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");

            String userid = HttpContext.Current.Request.QueryString["userid"];
            String pwd = HttpContext.Current.Request.QueryString["password"];
            Users user = BLL.admin.user.UserManagement.getUserByNetid(userid, "000000");
            if (user != null)
            {

                context.Session.Timeout = 12 * 60;
                context.Session["userid"] = user.Key;
                context.Session["netid"] = user.XMPY;
                context.Session["username"] = user.TrueName;
                context.Response.Redirect("/Default.aspx");
            }


        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}