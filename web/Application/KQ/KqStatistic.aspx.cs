using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.KQ
{
    public partial class KqStatistic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbSearch_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(2000);//延时2秒以显示进度条控件
            DateTime start = Convert.ToDateTime(tbDate.Text);
            DateTime end = Convert.ToDateTime(tbEndDate.Text);
            gvResult.DataSource = BLL.Application.KQ.KqStatistic.getKqStatistic(start, end);
            gvResult.DataBind();
        }

        protected void lbOutExcel_Click(object sender, EventArgs e)
        {
            BLL.pub.PubClass.ToExcel(gvResult, "record1.xls", "UTF-8");
            
        }

        #region 导出为Excel
        public override void VerifyRenderingInServerForm(Control control)
        {
            // Confirms that an HtmlForm control is rendered for
        }

        #endregion
    }
}