using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Printing;
using System.Drawing;

namespace web.Application.Assets.Test
{
    public partial class test_printer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //PrintDialog pDlg = new PrintDialog();
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            PrintDocument pd;
            pd = new PrintDocument();
            PaperSize ps = new PaperSize("Custom Size 1", 262, 197);
           // pd.DefaultPageSettings.PaperSize = ps;

           PageSettings pageSet = new PageSettings();
            pageSet.Landscape = false; //打印方向为纵向
            pageSet.Margins.Top = 0; //设置顶部页边距 
            pageSet.Margins.Left = 0; //设置左部页边距
            pageSet.PaperSize = ps;//设置为指定的纸张类型
            pd.DefaultPageSettings = pageSet;//当前打印页面为上面设置的打印页面

            //pd.OriginAtMargins = false ;
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
            pd.Print();
        }
        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
           // Graphics g = e.Graphics;
            SolidBrush myBrush = new SolidBrush(Color.Black);//刷子
            //float leftMargin = (e.MarginBounds.Left) * 3 / 4;
            //float topMargin = e.MarginBounds.Top * 2 / 3;       //顶边距
            //float verticalPosition = topMargin;
            //float leftMargin = 0;
            //float topMargin = 1;
            //float verticalPosition = 0;

           // g.DrawString(line, printFont, myBrush, leftMargin, yPosition, new StringFormat());
            //e.Graphics.DrawString("*123456789012*", new System.Drawing.Font("Code 128", 22), Brushes.Black, leftMargin, verticalPosition, new StringFormat());
            //e.Graphics.DrawString("*123456789012*", new System.Drawing.Font("3 of 9 Barcode", 22), Brushes.Black, leftMargin, verticalPosition, new StringFormat());
            //e.Graphics.DrawString("*123*", new System.Drawing.Font("3 of 9 Barcode", 34), Brushes.Black, new PointF(1,1));
            e.Graphics.DrawString("*123456*", new System.Drawing.Font("3 of 9 Barcode", 22), Brushes.Black, new RectangleF(1, 1, 270 , 150));
            e.Graphics.DrawString("*000001*", new System.Drawing.Font("3 of 9 Barcode", 22), Brushes.Black, new RectangleF(1, 70, 270, 150));
            //e.Graphics.DrawString((char)103 + "95270078" + (char)21 + (char)103, new System.Drawing.Font("Code 128", 22), Brushes.Black, new RectangleF(1, 1, 270, 150));
            e.Graphics.DrawString("要打印的东东123456789012", new Font("宋体", 12), Brushes.Black, new RectangleF(1, 30, 200, 220)); 
            Bitmap b = BLL.pub.BarCode.BuildBarCode("12345azAB1Z9");
            e.Graphics.DrawImage(b, new Point(1,100));
            //e.Graphics.DrawString("*123456789012*", new System.Drawing.Font("3 of 9 Barcode", 24), myBrush, leftMargin, new System.Drawing.PointF());
            //e.Graphics.DrawString("123456789012", new System.Drawing.Font("3 of 9 Barcode", 12), myBrush, new System.Drawing.PointF());
        }
    }
}