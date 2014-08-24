using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web
{
    public partial class LoginBackup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btLogin_Click(object sender, EventArgs e)
        {
            String usernetid = this.usernetid.Text;
            String pwd = this.pwd.Text;

            Users user = BLL.admin.user.UserManagement.getUserByNetid(usernetid, pwd);

            if (user != null)
            {
                Session.Timeout = 12 * 60;
                Session["userid"] = user.Key;
                Session["netid"] = user.XMPY;
                Session["username"] = user.TrueName;
                Response.Redirect("/Default.aspx");
            }
            else
            {
                lbMessage.Text = "用户名或密码错误，登陆失败！";
            }
        }
    }
}