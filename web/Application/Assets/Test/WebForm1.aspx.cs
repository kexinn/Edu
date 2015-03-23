using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.Assets.Test
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataClassesEduDataContext dc = new DataClassesEduDataContext();

                var rs = from r in dc.KQ_PunchCardRecords
                         where r.PunchCardUserId == 671 && r.IpAddress == "9.9.9.9"
                         select r;
                //var rs = from r in dc.KQ_PunchCardRecords
                //         where r.PunchCardUserId == 569
                //         select r;

                GridView1.DataSource = rs;

                GridView1.DataBind();

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataClassesEduDataContext dc = new DataClassesEduDataContext();

            var rs = from r in dc.KQ_PunchCardRecords  
                     where r.PunchCardUserId   == 671 && r.IpAddress == "9.9.9.9"
                     select r;

            foreach (var r in rs)
            {
                //r.IpAddress = "172.17.9.14";
                r.IpAddress = "172.17.16.55";
             }

            dc.SubmitChanges();

        }
    }
}