using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Application.KQ.Attendance
{
    public partial class MyAttendance : System.Web.UI.Page
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
            PanelApply.Visible = false;
            lbApplyTime.Text = System.DateTime.Now.ToString();
            lbUsername.Text = Session["username"].ToString();
            ddlType.DataSource = BLL.Application.KQ.Attendance.MyAttendance.getAttendanceType();
            ddlType.DataBind();
        }
        protected void lbAdd_Click(object sender, EventArgs e)
        {
            PanelApply.Visible = true;
        }


        protected void btApply_Click(object sender, EventArgs e)
        {

        }
    }
}