﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["username"] == null)
                    Response.Redirect("http://sso.nbyzzj.cn:8888/route/index1.jsp");
                //Response.Redirect("Login.aspx");
            }
        }
    }
}