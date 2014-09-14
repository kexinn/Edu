using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.KQ.Attendance
{
    public partial class AttendanceDetailView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                initdata();
            }
        }

        protected void initdata()
        {
            int id = Convert.ToInt32( Request["id"].ToString());
            v_KQ_Attendance attendance = BLL.Application.KQ.Attendance.AttendanceDetailView.getAttendanceDetail(id);
            lbUsername.Text = attendance.username;
            lbDept.Text = attendance.dept;
            lbApplyTime.Text = attendance.applyTime.ToString();
            lbType.Text = attendance.applytype;
            lbStartTime.Text = attendance.starttime.ToString();
            lbEndtime.Text = attendance.endtime.ToString();
            lbReason.Text = attendance.reason;
            
        }
    }
}