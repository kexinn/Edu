using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.KQ
{
    public partial class DayStatisticKQ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dateinit();
            }
        }

        protected void dateinit()
        {
            tbStartTime.Text = System.DateTime.Now.ToShortDateString();
        }

        protected void lbStatisc_Click(object sender, EventArgs e)
        {
            if (DropDownListPunch.SelectedValue == "1")//已打卡统计
            {
                PanelDaka.Visible = true;
                PanelWeiDaka.Visible = false;
                if(DropDownListType.SelectedValue == "1")//上班
                    databind1('1');
                if (DropDownListType.SelectedValue == "2")//下班
                    databind1('2');

            }else//未打卡统计
            {
                PanelDaka.Visible = false;
                PanelWeiDaka.Visible = true;
                if (DropDownListType.SelectedValue == "1")//上班
                    databind2('1');
                if (DropDownListType.SelectedValue == "2")//下班
                    databind2('2');
            }
        }

        protected void databind1(char type)
        {
            DateTime startdate = Convert.ToDateTime(tbStartTime.Text + " 00:00:00");
            DateTime enddate = Convert.ToDateTime(tbStartTime.Text + " 23:59:59");
            gvKQList.DataSource = BLL.Application.KQ.DayStatisticKQ.getStatiscByBetweenTime(startdate, enddate,type, Convert.ToByte( DropDownListStatus.SelectedValue));
            gvKQList.DataBind();

            GridView1.DataSource = gvKQList.DataSource;

        }
        protected void databind2(char type)
        {
            DateTime startdate = Convert.ToDateTime(tbStartTime.Text + " 00:00:00");
            DateTime enddate = Convert.ToDateTime(tbStartTime.Text + " 23:59:59");

            gvRecordNull.DataSource = BLL.Application.KQ.DayStatisticKQ.getStatiscNullByBetweenTime(startdate, enddate, type, Convert.ToByte(DropDownListStatus.SelectedValue));
            gvRecordNull.DataBind();

            GridView2.DataSource = gvRecordNull.DataSource;
        }

        protected void lbOutExcel1_Click(object sender, EventArgs e)
        {
            if (DropDownListPunch.SelectedValue == "1")
            {
                PanelDaka.Visible = true;
                PanelWeiDaka.Visible = false;
                if (DropDownListType.SelectedValue == "1")
                    databind1('1');
                if (DropDownListType.SelectedValue == "2")
                    databind1('2');
                GridView1.DataBind();
                GridView1.AllowPaging = false;
                GridView1.AllowSorting = false;
                BLL.pub.PubClass.ToExcel(GridView1, "record1.xls", "UTF-8");
                //ToExcel(GridView1, "record1.xls");
                GridView1.AllowPaging = true;
                GridView1.AllowSorting = true;
            }
            else
            {
                PanelDaka.Visible = false;
                PanelWeiDaka.Visible = true;
                if (DropDownListType.SelectedValue == "1")
                    databind2('1');
                if (DropDownListType.SelectedValue == "2")
                    databind2('2');
                GridView2.DataBind();
                GridView2.AllowPaging = false;
                GridView2.AllowSorting = false;
                //ToExcel(GridView2, "record2.xls");
                BLL.pub.PubClass.ToExcel(GridView2, "record2.xls", "UTF-8");
                GridView2.AllowPaging = true;
                GridView2.AllowSorting = true;
            }
            
        }


        protected void gvKQList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvKQList.PageIndex = e.NewPageIndex;
            if (DropDownListType.SelectedValue == "1")
                databind1('1');
            if (DropDownListType.SelectedValue == "2")
                databind1('2');
        }

        protected void gvRecordNull_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvRecordNull.PageIndex = e.NewPageIndex;
            if (DropDownListType.SelectedValue == "1")
                databind2('1');
            if (DropDownListType.SelectedValue == "2")
                databind2('2');
        }

        #region 导出为Excel
        public override void VerifyRenderingInServerForm(Control control)
        {
            // Confirms that an HtmlForm control is rendered for
        }

      
        #endregion

        protected void lbStatus_DataBinding(object sender, EventArgs e)
        {
            Label lb = (Label)sender;

            BLL.Application.KQ.DayStatisticKQ.DayPunchCardStatiscs statis = GetDataItem() as BLL.Application.KQ.DayStatisticKQ.DayPunchCardStatiscs;

            if (statis.状态 == 0)
            {
                lb.Text = "正常";
                lb.ForeColor = System.Drawing.Color.Blue;
            }else if (statis.状态 == 1)
            {

                lb.Text = "迟到";
                lb.ForeColor = System.Drawing.Color.Red;
            }
            else if (statis.状态 == 2)
            {

                lb.Text = "早退";
                lb.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void lbCardType_DataBinding(object sender, EventArgs e)
        {
            Label lb = (Label)sender;

            BLL.Application.KQ.DayStatisticKQ.DayPunchCardStatiscs statis = GetDataItem() as BLL.Application.KQ.DayStatisticKQ.DayPunchCardStatiscs;
             if (statis.打卡类型 == '1')
            {
                lb.Text = "上班打卡";
                lb.ForeColor = System.Drawing.Color.Blue;
            }
             else if (statis.打卡类型 == '2')
             {

                 lb.Text = "下班打卡";
                 lb.ForeColor = System.Drawing.Color.Green;
             }
        }
    }
}