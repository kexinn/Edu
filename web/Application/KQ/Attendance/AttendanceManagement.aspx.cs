using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.KQ.Attendance
{
    public partial class AttendanceManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                initdata();
                databind();
            }
        }
        protected void initdata()
        {
            PanelApply.Visible = true;

           
        }
        protected void databind()
        {
           string id  =  Request.QueryString["id"];
            if(!String.IsNullOrEmpty(id))
            {
               KQ_Attendance att =  BLL.Application.KQ.Attendance.AttendanceManagement.getAttendanceById(Convert.ToInt32(id));

               lbUsername.Text = att.username;
               lbDept.Text = att.dept;
               lbApplyTime.Text = att.applyTime.ToString();
               ddlType.Items.Clear();
               List<KQ_AttendanceType> t = BLL.Application.KQ.Attendance.MyAttendance.getAttendanceType();
               foreach (KQ_AttendanceType li in t)
               {
                   ListItem l = new ListItem();
                   l.Text = li.name;
                   l.Value = li.Id.ToString();
                   ddlType.Items.Add(l);
                   if (att.typeid == li.Id)
                       l.Selected = true;
               }
               tbStartTime.Text = att.starttime.ToString();
               tbEndTime.Text = att.endtime.ToString();
               tbReason.InnerText = att.reason;
               lbDaySpan.Text = att.daySpan.ToString();
               lbTimeSpan.Text = att.hourSpan.ToString();
            }
        }

        protected void btDelete_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            if (BLL.Application.KQ.Attendance.MyAttendance.deleteAttendanceRecord(Convert.ToInt32(id)))
                BLL.pub.PubClass.showAlertMessage(Page, ClientScript, "删除成功！");
            Response.Redirect("AttendanceStatistic.aspx");
        }

        protected void btApply_Click(object sender, EventArgs e)
        {
            DateTime starttime = Convert.ToDateTime(tbStartTime.Text);
            DateTime endtime = Convert.ToDateTime(tbEndTime.Text);
            if (endtime < starttime)
            {
                lbMessage.Text = "起始时间不能小于结束时间，请重新输入！";
                return;
            }

            try
            {
                Decimal daySpan = Convert.ToDecimal(lbDaySpan.Text);
                int hourSpan = Convert.ToInt32(lbTimeSpan.Text);

                KQ_Attendance kq = new KQ_Attendance();
                kq.Id = Convert.ToInt32( Request.QueryString["id"]);
                kq.starttime = starttime;
                kq.endtime = endtime;
                kq.daySpan = daySpan;
                kq.hourSpan = hourSpan;
                kq.reason = tbReason.InnerText;
                kq.typeid = Convert.ToInt32( ddlType.SelectedValue);
                BLL.Application.KQ.Attendance.AttendanceManagement.updateAttendance(kq);

                BLL.pub.PubClass.showAlertMessage(Page, ClientScript, "修改成功！");
                Response.Redirect("AttendanceStatistic.aspx");
            }
            catch (Exception ex)
            {
                lbMessage.Text = "申请错误：" + ex.Message;
            }
        }

        protected void computeTime()
        {
            DateTime datestart = Convert.ToDateTime(tbStartTime.Text);
            DateTime dateend = Convert.ToDateTime(tbEndTime.Text);
            Decimal daySpan = 0;
            int timeSpan = 0;
            BLL.Application.KQ.Attendance.AttendanceStatistic.getSpanDateTime(datestart, dateend, ref daySpan, ref timeSpan);
            lbDaySpan.Text = daySpan.ToString();
            lbTimeSpan.Text = timeSpan.ToString();
            if (dateend.ToShortDateString() == datestart.ToShortDateString())
            {
                if (datestart.Hour == dateend.Hour)
                {
                    lbMinute.Text = (dateend.Minute - datestart.Minute).ToString();
                    lbMtip.Visible = true;
                }
                else
                {
                    lbMinute.Text = "";
                    lbMtip.Visible = false;
                }
            }
            else
            {
                lbMinute.Text = "";
                lbMtip.Visible = false;
            }
        }

        protected void tbEndTime_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbStartTime.Text))
            {
                computeTime();
            }

        }

        protected void tbStartTime_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbEndTime.Text))
            {

                computeTime();
            }
        }
    }
}