using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.KQ.Attendance
{
    public partial class MyApproval : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AspNetPager1.PageSize = BLL.pub.PubClass.PAGE_SIZE;
                databind();
            }
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            databind();
        }

        protected void databind()
        {
            int recordNum = 0;
            gvAttendance.DataSource = BLL.Application.KQ.Attendance.MyApproval.getMyApprovalRecord(Convert.ToInt32(Session["userid"]), AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize, ref recordNum);
            gvAttendance.DataBind();
            gvAttendance.Columns[0].Visible = false;
            AspNetPager1.RecordCount = recordNum;
        }
        protected void lbStatus_DataBinding(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            v_KQ_Attendance item = GetDataItem() as v_KQ_Attendance;
            lb.Text = item.status;
            if (item.status.Trim() == "审批中")
                lb.ForeColor = System.Drawing.Color.Blue;
            else if (item.status.Trim() == "审批通过")
                lb.ForeColor = System.Drawing.Color.Green;
            else if (item.status.Trim() == "审批拒绝")
                lb.ForeColor = System.Drawing.Color.Red;

        }

        protected void lbView_DataBinding(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            v_KQ_Attendance item = GetDataItem() as v_KQ_Attendance;

            String url = "/Application/KQ/Attendance/AttendanceDetailView.aspx?id=" + item.Id;
            String click = "window.open('" + url + "','Sample','toolbar=no,location=no,directories=no,status=no,menubar=yes,scrollbars=yes,resizable=yes,copyhistory=yes,width=900,height=500,left=100,top=100');return false;";

            lb.Attributes.Add("onclick", click);
        }

        protected void gvAttendance_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent)); //此得出的值是表示那行被选中的索引值 
            int id = Convert.ToInt32(gvAttendance.DataKeys[drv.RowIndex].Value); //此获取的值为GridView中绑定数据库中的主键值 


            if (e.CommandName == "yes")
            {
                BLL.Application.KQ.Attendance.MyApproval.setAttendanceApplyStatus(id,1);
                databind();
            }
            if (e.CommandName == "no")
            {
                BLL.Application.KQ.Attendance.MyApproval.setAttendanceApplyStatus(id, 0);
                databind();
            }
        }

        protected void lbSpanDate_DataBinding(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            v_KQ_Attendance item = GetDataItem() as v_KQ_Attendance;

            lb.Text = item.starttime.ToString() + " 到 " + item.endtime.ToString();
        }

        protected void lbSpanDiscription_DataBinding(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            v_KQ_Attendance item = GetDataItem() as v_KQ_Attendance;

            lb.Text = "共: " + item.daySpan.ToString() + " 天 " + item.hourSpan.ToString()+" 小时";
        }


        protected void lbHistory_DataBinding(object sender, EventArgs e)
        {

            LinkButton lb = (LinkButton)sender;
            v_KQ_Attendance item = GetDataItem() as v_KQ_Attendance;

            String url = "/Application/KQ/Attendance/ApprovalHistory.aspx?id=" + item.Id;
            String click = "window.open('" + url + "','Sample','toolbar=no,location=no,directories=no,status=no,menubar=yes,scrollbars=yes,resizable=yes,copyhistory=yes,width=1024,height=500,left=100,top=100')";
            lb.Attributes.Add("onclick", "return false;");
            lb.OnClientClick = click;
        }
    }
}