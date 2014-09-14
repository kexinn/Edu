﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
            }

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
                BLL.Application.KQ.Attendance.MyAttendance.createApply(userid, Session["username"].ToString(), Convert.ToDateTime(tbStartTime.Text), Convert.ToDateTime(tbEndTime.Text), Convert.ToInt32(ddlType.SelectedValue), tbReason.InnerText, ddlDept.Text,ref tel);
                lbMessage.Text = "添加申请成功！等待审批";
                PanelApply.Visible = false;
            }catch(Exception ex)
            {
                lbMessage.Text = "申请错误：" + ex.Message;
            }
        }

        protected void lbStatus_DataBinding(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            v_KQ_Attendance item = GetDataItem() as v_KQ_Attendance;
            if (item.status == "审批中")
                lb.ForeColor = System.Drawing.Color.Blue;
            else if (item.status == "审批通过")
                lb.ForeColor = System.Drawing.Color.Green;
            else if (item.status == "审批拒绝")
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
    }
}