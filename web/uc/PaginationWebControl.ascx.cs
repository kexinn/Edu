using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.uc
{
    public partial class PaginationWebControl : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        public void setStatus(BLL.pub.PagerTClass pageT)
        {
            lbTotPage.Text = pageT.PageCount.ToString();
            lbIndexPage.Text = pageT.IndexPage.ToString();
            lbTotPage1.Text = pageT.PageCount.ToString();

            lbPrePage.Enabled = pageT.PrevShow;
            lbNexPage.Enabled = pageT.NextShow;

        }

        protected void lbPrePage_Click(object sender, EventArgs e)
        {
          
        }

        protected void lbNexPage_Click(object sender, EventArgs e)
        {

        }

        protected void lbGo_Click(object sender, EventArgs e)
        {

        }
    }
}