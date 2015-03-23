using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.Assets.Test
{
    public partial class test_listview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
            }
        }

        protected   void databind()
        {
            using (DataClassesASDataContext dc=new DataClassesASDataContext())
            {
                lv.DataSource = dc.AS_Ck.ToList();
                lv.DataBind();
            }
        }
    }
}