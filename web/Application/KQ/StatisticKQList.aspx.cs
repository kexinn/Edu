using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Application.KQ
{
    public partial class StatisticKQList : System.Web.UI.Page
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
            tbEndTime.Text = System.DateTime.Now.ToShortDateString();
        }
        
        protected void databind1()
        {
            DateTime startdate = Convert.ToDateTime(tbStartTime.Text + " 00:00:00");
            DateTime enddate = Convert.ToDateTime(tbEndTime.Text + " 23:59:59");
            gvKQList.DataSource = BLL.Application.KQ.KQManagement.getStatiscByBetweenTime(startdate, enddate);
            gvKQList.DataBind();

            GridView1.DataSource = gvKQList.DataSource;
            
        }

        protected void databind2()
        {
            DateTime startdate = Convert.ToDateTime(tbStartTime.Text + " 00:00:00");
            DateTime enddate = Convert.ToDateTime(tbEndTime.Text + " 23:59:59");
            
            gvRecordNull.DataSource = BLL.Application.KQ.KQManagement.getStatiscNullByBetweenTime(startdate, enddate);
            gvRecordNull.DataBind();

            GridView2.DataSource = gvRecordNull.DataSource;
        }
        protected void lbStatisc_Click(object sender, EventArgs e)
        {
            databind1();
            databind2();

        }

        protected void gvKQList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvKQList.PageIndex = e.NewPageIndex;
            databind1();
        }

        protected void gvRecordNull_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRecordNull.PageIndex = e.NewPageIndex;
            databind2();
        }

        protected void lbOutExcel2_Click(object sender, EventArgs e)
        {
            databind2();
            GridView2.DataBind();
            GridView2.AllowPaging = false;
            GridView2.AllowSorting = false;
            //ToExcel(GridView2, "record2.xls");
            BLL.pub.PubClass.ToExcel(GridView2, "record2.xls", "UTF-8");
            GridView2.AllowPaging = true;
            GridView2.AllowSorting = true;

        }

        protected void lbOutExcel1_Click(object sender, EventArgs e)
        {

            databind1();
            GridView1.DataBind();
            GridView1.AllowPaging = false;
            GridView1.AllowSorting = false;
            BLL.pub.PubClass.ToExcel(GridView1, "record1.xls","UTF-8");
            //ToExcel(GridView1, "record1.xls");
            GridView1.AllowPaging = true;
            GridView1.AllowSorting = true;
        }

        #region 导出为Excel
        public override void VerifyRenderingInServerForm(Control control)
        {
            // Confirms that an HtmlForm control is rendered for
        }

        private void ToExcel(Control ctl, string FileName)
        {

            GridView gv = (GridView)ctl;
            // for (int i = 0; i < gv.Columns.Count; i++) //设置每个单元格
            // {
            // gv.Columns[1].ItemStyle.HorizontalAlign = HorizontalAlign.Left;
            //将第一列准考证号设置为字符型，避免丢失0
           // for (int j = 0; j < gv.Rows.Count; j++)
            //{
              //  gv.Rows[j].Cells[0].Attributes.Add("style", "vnd.ms-excel.numberformat:@");
            //}
            // }

            HttpContext.Current.Response.Charset = "GB2312";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + "" + FileName);
            gv.Page.EnableViewState = false;
            System.IO.StringWriter tw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            gv.RenderControl(hw);
            HttpContext.Current.Response.Write(tw.ToString());
            HttpContext.Current.Response.End();
        }

        #endregion

    }
}