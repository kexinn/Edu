using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using BLL;

namespace web.Application.KQ.Attendance
{
    public partial class MyAttendance : System.Web.UI.Page
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
            PanelApply.Visible = false;
            lbApplyTime.Text = System.DateTime.Now.ToString();
            lbUsername.Text = Session["username"].ToString();

            ddlType.Items.Clear();
            List<KQ_AttendanceType> t = BLL.Application.KQ.Attendance.MyAttendance.getAttendanceType();
            foreach(KQ_AttendanceType li in t)
            {
                ListItem l = new ListItem();
                l.Text = li.name;
                l.Value = li.Id.ToString();
                ddlType.Items.Add(l);
            }/*
            ddlDept.Items.Clear();
            List<Department> deps = BLL.admin.department.DepartmentManagement.getDepartments();
            foreach(Department dept in deps)
            {
                ListItem item = new ListItem();
                item.Text = dept.Name;
                item.Value = dept.Name;
                ddlDept.Items.Add(item);
            }
            */
            AspNetPager1.PageSize = BLL.pub.PubClass.PAGE_SIZE;
        }
        protected void lbAdd_Click(object sender, EventArgs e)
        {
            PanelApply.Visible = true;
        }


        protected void btApply_Click(object sender, EventArgs e)
        {
            
            try
            {
                int userid = Convert.ToInt32(Session["userid"].ToString());
                String tel = "";
                BLL.Application.KQ.Attendance.MyAttendance.createApply(userid, Session["username"].ToString(), Convert.ToDateTime(tbStartTime.Text), Convert.ToDateTime(tbEndTime.Text), Convert.ToInt32(ddlType.SelectedValue), tbReason.InnerText, ddlDept.Text,"",ref tel);
                lbMessage.Text = "添加申请成功！等待审批";
                PanelApply.Visible = false;
                databind();
                // lbMessage.Text = tel;
                KQ_Attendance att = BLL.Application.KQ.Attendance.MyAttendance.getTopAttendRecordByUserid(userid);
                string approvalyes = "http://wx.nbyzzj.cn/approval.php?attendId=" + att.Id + "%26result=1";
                string approvalno = "http://wx.nbyzzj.cn/approval.php?attendId=" + att.Id + "%26result=0";
                string message = "您有一条待审批的请假申请，申请人：" + Session["username"].ToString() + "类型：" + ddlType.SelectedItem.ToString() +"请假时间从：" +tbStartTime.Text+" 到"+tbEndTime.Text +" 事由:" + tbReason.InnerText + ",请您审批，同意点：" + approvalyes + "。不同意点：" + approvalno; ;
               // tel = "13486689106";
                BLL.pub.PubClass.sendSMS(tel, message);
            }catch(Exception ex)
            {
                lbMessage.Text = "申请错误：" + ex.Message;
            }
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

        protected void databind()
        {
            int recordNum = 0;
            gvAttendance.DataSource = BLL.Application.KQ.Attendance.MyAttendance.getMyAttendanceRecord(Convert.ToInt32(Session["userid"]), AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize,ref recordNum);
            gvAttendance.DataBind();
            gvAttendance.Columns[0].Visible = false;
            AspNetPager1.RecordCount = recordNum;
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            databind();
        }

        protected void lbDel_DataBinding(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            v_KQ_Attendance item = GetDataItem() as v_KQ_Attendance;

            if (item.status.Trim() == "审批通过")
                lb.Visible = false;
        }

        protected void gvAttendance_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String id = gvAttendance.DataKeys[e.RowIndex].Value.ToString();

            BLL.Application.KQ.Attendance.MyAttendance.deleteAttendanceRecord(Convert.ToInt32(id));
            databind();
        }

        protected void tbEndTime_TextChanged(object sender, EventArgs e)
        {
            /*
            DateTime datestart = Convert.ToDateTime(tbStartTime.Text);
            DateTime datestartStartTime = Convert.ToDateTime(datestart.ToShortDateString() + " 11:30:00");
            DateTime datestartEndTime = Convert.ToDateTime(datestart.ToShortDateString() + " 13:00:00");
            DateTime dateend = Convert.ToDateTime(tbEndTime.Text);
            DateTime dateendStartTime = Convert.ToDateTime(dateend.ToShortDateString() + " 11:30:00");
            DateTime dateendEndTime = Convert.ToDateTime(dateend.ToShortDateString() + " 13:00:00");

            TimeSpan datespan = dateend -datestart;

            if (datestart.DayOfYear == dateend.DayOfYear)
            {
                lbDaySpan.Text = "0";
                TimeSpan ts1 = datestartStartTime - datestart;
                TimeSpan ts2 = dateend - datestartEndTime;


                
            }
            else if ( dateend.DayOfYear - datestart.DayOfYear == 1)
            {
                lbDaySpan.Text = "1";
                lbTimeSpan.Text = datespan.Hours.ToString();
            } */
        }
           

    }
}