using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.KQ
{
    public partial class MyKQList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
            }
        }

        protected void databind()
        {
            gvKQList.DataSource = BLL.Application.KQ.KQManagement.getTodayPunchCardRecord((int)Session["userid"]);
            gvKQList.DataBind();
        }
        protected void lbSearch_Click(object sender, EventArgs e)
        {
            databind_appoint_time();
        }

        protected void databind_appoint_time()
        {
            if (!String.IsNullOrEmpty(tbStartTime.Text) && !String.IsNullOrEmpty(tbEndTime.Text))
            {
                DateTime start = Convert.ToDateTime(tbStartTime.Text + " 00:00:00");
                DateTime end = Convert.ToDateTime(tbEndTime.Text + " 23:59:59");
                List<KQ_PunchCardRecords> list = BLL.Application.KQ.KQManagement.getAppointTimePunchCardRecords(BLL.pub.PubClass.getUserid(), start, end);
                gvKQList.DataSource = list;
                gvKQList.DataBind();
            }
        }
        protected void gvKQList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvKQList.PageIndex = e.NewPageIndex;
            databind_appoint_time();
        }
    }
}