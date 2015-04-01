using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Security.Cryptography;
using System.Web.Security;
using DotNetCasClient;

namespace web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        /*
            try
            {
                HttpCookie ticketCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                if (ticketCookie != null)
                {
                    if (!string.IsNullOrEmpty(ticketCookie.Value))
                    {
                        FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(ticketCookie.Value);
                        if (CasAuthentication.ServiceTicketManager != null)
                        {
                            CasAuthenticationTicket casTicket = CasAuthentication.ServiceTicketManager.GetTicket(ticket.UserData);
                            if (casTicket != null)
                            {

                                lbMessage.Text = casTicket.NetId;
                                checkLogin(casTicket.NetId);
                                //Label1.Text = casTicket.ServiceTicket;
                                // CasOriginatingServiceName.Text = casTicket.OriginatingServiceName;
                                // CasClientHostAddress.Text = casTicket.ClientHostAddress;
                                // CasValidFromDate.Text = casTicket.ValidFromDate.ToString();
                                // CasValidUntilDate.Text = casTicket.ValidUntilDate.ToString();
                                // ProxyGrantingTicket.Text = casTicket.ProxyGrantingTicket;
                                // ProxyGrantingTicketIou.Text = casTicket.ProxyGrantingTicketIou;


                            }else
                            {
                                Response.Redirect("https://sso.nbyzzj.cn:8443/cas/login");
                            }
                        }
                    }

                }
                else
                {

                    lbMessage.Text = "cookie is null";
                    Response.Redirect("https://sso.nbyzzj.cn:8443/cas/login");

                }
            }catch (Exception ex)
            {
                lbMessage.Text = "系统错误：" + ex.Message;
            }
         * */
        }

        protected void checkLogin(String name)
        {

            Users user = BLL.Login.getUser(name);

            if(user == null)
            {
                lbMessage.Text = "无此用户，请与管理员联系。";
            }else
            {

                Session.Timeout = 12 * 60;
                Session["userid"] = user.Key;
                Session["netid"] = user.XMPY;
                Session["username"] = user.TrueName;
                Response.Redirect("/Default.aspx");

            }
            
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