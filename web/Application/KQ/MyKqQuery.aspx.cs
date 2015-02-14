using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.KQ
{
    public partial class MyKqQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
            }
        }

        protected void databind()
        {
            int recordNum = 0;
            AspNetPager1.PageSize = BLL.pub.PubClass.PAGE_SIZE;
            

            gvKQ.DataSource = BLL.Application.KQ.MyKqQuery.getMyKqQuery(Convert.ToInt32(Session["userid"]) ,ref recordNum, AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize,tbDate.Text);
            gvKQ.DataBind();
            // gvAttendance.Columns[0].Visible = false;
            AspNetPager1.RecordCount = recordNum;
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            databind();
        }

        protected void lbEarly_DataBinding(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            KQ_Report item = GetDataItem() as KQ_Report;
            if ((bool)item.isZaotui)
            {
                lb.Text = "早退";
                lb.ForeColor = System.Drawing.Color.Red;
            }
            else if (!string.IsNullOrEmpty(item.xiabanTime))
            {

                lb.Text = "正常";
                lb.ForeColor = System.Drawing.Color.Blue;
            }
            else
                lb.Text = "";
        }

        protected void lbLate_DataBinding(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            KQ_Report item = GetDataItem() as KQ_Report;
            if ((bool)item.isChidao)
            {
                lb.Text = "迟到";
                lb.ForeColor = System.Drawing.Color.Red;
            }
            else if (!string.IsNullOrEmpty(item.shangbanTime))
            {

                lb.Text = "正常";
                lb.ForeColor = System.Drawing.Color.Blue;
            }
            else
                lb.Text = "";
        }

        protected void lbKuanggong_DataBinding(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            KQ_Report item = GetDataItem() as KQ_Report;
            if ((bool)item.isKuanggong)
            {
                lb.Text = "矿工";
                lb.ForeColor = System.Drawing.Color.Red;
            }
            else
            {

                lb.Text = "";
                lb.ForeColor = System.Drawing.Color.Blue;
            }
        }

        protected void lbWeek_DataBinding(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            KQ_Report item = GetDataItem() as KQ_Report;
            lb.Text = "星期" + ((item.weekDay == "0") ? "天" : item.weekDay);
        }

        protected void lbQingjia_DataBinding(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            KQ_Report item = GetDataItem() as KQ_Report;
            if ((bool)item.isQingjia)
            {
                lb.Text = "是";
                lb.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {

                lb.Text = "";
                lb.ForeColor = System.Drawing.Color.Blue;
            }
        }

        protected void lbSearch_Click(object sender, EventArgs e)
        {
            databind();
        }

        protected void lbDate_DataBinding(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            KQ_Report item = GetDataItem() as KQ_Report;
            lb.Text = Convert.ToDateTime(item.date).ToShortDateString();
        }
    }
}