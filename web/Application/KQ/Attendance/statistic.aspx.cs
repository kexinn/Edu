using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

namespace web.Application.KQ.Attendance
{
    public partial class statistic : System.Web.UI.Page
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
        }


        protected void lbCompute_Click(object sender, EventArgs e)
        {

            System.Threading.Thread.Sleep(2000);//延时2秒以显示进度条控件
            getdata();
        }

        protected void  getdata()
        {
            int typeid = -1;
            if (!String.IsNullOrEmpty(DropDownListType.SelectedValue))
                typeid = Convert.ToInt32(DropDownListType.SelectedValue);
            BLL.Application.KQ.Attendance.statistic.Attendance_Statistic statistic = new BLL.Application.KQ.Attendance.statistic.Attendance_Statistic();

            if (!String.IsNullOrEmpty(DropDownListDept.SelectedValue))
                statistic.dept = DropDownListDept.SelectedValue;
            else
                statistic.dept = "";
            if (!String.IsNullOrEmpty(DropDownListStatus.SelectedValue))
                statistic.status = DropDownListStatus.SelectedValue;
            else
                statistic.status = "";
            if (!String.IsNullOrEmpty(DropDownListType.SelectedValue))
                statistic.type = DropDownListType.SelectedItem.Text;

            DataTable dt = BLL.Application.KQ.Attendance.statistic.calculateResult(statistic, Convert.ToDateTime(tbStartTime.Text), Convert.ToDateTime(tbEndTime.Text), DropDownListDept.SelectedValue, DropDownListStatus.SelectedValue, typeid);

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void lbOutExcel_Click(object sender, EventArgs e)
        {
            GridView1.AllowPaging = false;
            GridView1.AllowSorting = false;
            BLL.pub.PubClass.ToExcel(GridView1, "record1.xls", "UTF-8");
            GridView1.AllowPaging = true;
            GridView1.AllowSorting = true;
        }

        #region 导出为Excel
        public override void VerifyRenderingInServerForm(Control control)
        {
            // Confirms that an HtmlForm control is rendered for
        }

        #endregion
    }
}