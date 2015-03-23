using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application
{
    public partial class Infomation : System.Web.UI.Page
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
            lbName.Text = Session["username"].ToString()+" 老师：";

            Users u = BLL.admin.user.UserManagement.getUserByName(Session["username"].ToString());

            if(u!=null && !String.IsNullOrEmpty(u.bianhao))
            {
                lbNianyue.Text = u.bianhao;
            }

        }

        protected void lbSave_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            user.bianhao = tbBianhao.Text;
            user.Key = Convert.ToInt32( Session["userid"]);
            BLL.admin.user.UserManagement.updateUserBianhao(user);
            databind();
        }

    }
}