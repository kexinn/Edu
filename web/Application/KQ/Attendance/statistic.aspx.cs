using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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

        protected void lbSearch_Click(object sender, EventArgs e)
        {

        }

        protected void lbCompute_Click(object sender, EventArgs e)
        {
            int typeid = -1;
            if(!String.IsNullOrEmpty( DropDownListType.SelectedValue))
                typeid = Convert.ToInt32(DropDownListType.SelectedValue);

            BLL.Application.KQ.Attendance.statistic.calculateResult(Convert.ToDateTime(tbStartTime.Text), Convert.ToDateTime(tbEndTime.Text),DropDownListDept.SelectedValue,DropDownListStatus.SelectedValue,typeid);
        }
    }
}