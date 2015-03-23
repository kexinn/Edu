using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Printing;

namespace web
{
    public partial class test : System.Web.UI.Page
    {
        Bitmap b;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bttm_Click(object sender, EventArgs e)
        {
            string tsm = tm.Text;

            // b = BLL.pub.BarCode.BuildBarCode(tsm);

            //PrintDocument printDocument = new PrintDocument();
            //printDocument.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
            //printDocument.Print();
            Label1.Text = Guid.NewGuid().ToString();
        }
        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            string strLine;//用于存放当前行打印的信息            
            float leftMargin = (e.MarginBounds.Left) * 3 / 4;   //左边距
            float topMargin = e.MarginBounds.Top * 2 / 3;       //顶边距
            float verticalPosition = topMargin;                 //初始化垂直位置，设为顶边距

            Font mainFont = new Font("Courier New", 10);//打印的字体
            //每页的行数，当打印行数超过这个时，要换页(1.05这个值是根据实际情况中设定的，可以不要)
            int linesPerPage = (int)(e.MarginBounds.Height * 1.05 / mainFont.GetHeight(e.Graphics));
            e.Graphics.DrawImage(b, new Point());
        }
    }
}