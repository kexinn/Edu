using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Application.KQ.Attendance
{
    public partial class ApprovalHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initdata();
            }
        }

        protected void initdata()
        {
            int attendid = Convert.ToInt32( Request["id"]);
            gvHistory.DataSource = BLL.Application.KQ.Attendance.ApplyApprove.getAttendHistory(attendid);
            gvHistory.DataBind();
        }
    }
}