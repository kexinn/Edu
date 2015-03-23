using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.KQ.Attendance
{
    public partial class AttendanceStatistic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initdata();
                databind();
            }
        }

        protected void initdata()
        {
/*
            DropDownListDept.Items.Clear();
            List<Department> deps = BLL.admin.department.DepartmentManagement.getDepartments();
            foreach (Department dept in deps)
            {
                ListItem item = new ListItem();
                item.Text = dept.Name;
                item.Value = dept.Name;
                DropDownListDept.Items.Add(item);
            }
            */
            DropDownListType.Items.Clear();
            ListItem lin = new ListItem("");
            DropDownListType.Items.Add(lin);

            List<KQ_AttendanceType> t = BLL.Application.KQ.Attendance.MyAttendance.getAttendanceType();
            foreach (KQ_AttendanceType li in t)
            {
                ListItem l = new ListItem();
                l.Text = li.name;
                l.Value = li.Id.ToString();
                DropDownListType.Items.Add(l);
            }
            AspNetPager1.PageSize = BLL.pub.PubClass.PAGE_SIZE;
        }
        protected void databind()
        {
            int recordNum = 0;
            gvAttendance.DataSource = BLL.Application.KQ.Attendance.AttendanceStatistic.getAttendanceRecords(tbStartTime.Text, tbApplyUser.Text, DropDownListDept.SelectedValue, DropDownListStatus.SelectedValue,DropDownListType.SelectedValue, ref recordNum, AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize);
            gvAttendance.DataBind();
           // gvAttendance.Columns[0].Visible = false;
            AspNetPager1.RecordCount = recordNum;
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            databind();
        }
        protected void lbView_DataBinding(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            v_KQ_Attendance item = GetDataItem() as v_KQ_Attendance;

            String url = "/Application/KQ/Attendance/AttendanceDetailView.aspx?id=" + item.Id;
            String click = "window.open('" + url + "','Sample','toolbar=no,location=no,directories=no,status=no,menubar=yes,scrollbars=yes,resizable=yes,copyhistory=yes,width=1024,height=500,left=100,top=100');return false;";

            lb.Attributes.Add("onclick", click);
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
        protected void lbStatisc_Click(object sender, EventArgs e)
        {
            databind();
        }

        protected void databindExcel()
        {
            int recordNum = 0;
            GridView1.DataSource = BLL.Application.KQ.Attendance.AttendanceStatistic.getAttendanceRecords(tbStartTime.Text, tbApplyUser.Text, DropDownListDept.SelectedValue, DropDownListStatus.SelectedValue, DropDownListType.SelectedValue, ref recordNum, AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize); 
            
        }
        protected void lbOutExcel_Click(object sender, EventArgs e)
        {

            databindExcel();
            GridView1.DataBind();
            GridView1.AllowPaging = false;
            GridView1.AllowSorting = false;
            BLL.pub.PubClass.ToExcel(GridView1, "record1.xls", "UTF-8");
            //ToExcel(GridView1, "record1.xls");
            GridView1.AllowPaging = true;
            GridView1.AllowSorting = true;
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

            lb.Text = "共: " + item.daySpan.ToString() + " 天 " + item.hourSpan.ToString() + " 小时";
        }
        #region 导出为Excel
        public override void VerifyRenderingInServerForm(Control control)
        {
            // Confirms that an HtmlForm control is rendered for
        }

        #endregion

        protected void lbHistory_DataBinding(object sender, EventArgs e)
        {

            LinkButton lb = (LinkButton)sender;
            v_KQ_Attendance item = GetDataItem() as v_KQ_Attendance;

            String url = "/Application/KQ/Attendance/ApprovalHistory.aspx?id=" + item.Id;
            String click = "window.open('" + url + "','Sample','toolbar=no,location=no,directories=no,status=no,menubar=yes,scrollbars=yes,resizable=yes,copyhistory=yes,width=1024,height=500,left=100,top=100')";
            lb.Attributes.Add("onclick", "return false;");
            lb.OnClientClick = click;
        }

        protected void lbDel_DataBinding(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            v_KQ_Attendance item = GetDataItem() as v_KQ_Attendance;

            //if (BLL.admin.role.RoleManagement.ifUserInRole(Convert.ToInt32(Session["userid"]), 1))
            //    lb.Visible = true;
            //else
            //    lb.Visible = false;
        }

        protected void gvAttendance_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String id = gvAttendance.DataKeys[e.RowIndex].Value.ToString();

            Response.Redirect("AttendanceManagement.aspx?id=" + id);
        }
    }
}