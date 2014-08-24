using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application
{
    public partial class RoutTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                rout();
            }
        }
        protected void rout()
        {
            String id = Request["taskid"];
            t_User_Task task =  BLL.Application.RoutTask.rout(Convert.ToInt32(id));
            Response.Redirect(task.url);
        }
    }
}