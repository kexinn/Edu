using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Application.Assets.Lkgl
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String url = "/Application/Assets/LKgl/Zcdj.aspx";
            String click = "window.open('" + url + "','Sample','toolbar=no,location=no,directories=no,status=no,menubar=yes,scrollbars=yes,resizable=yes,copyhistory=yes,width=900,height=500,left=100,top=100');return false;";
            Button1.Attributes.Add("onclick", click);
        }
    }
}