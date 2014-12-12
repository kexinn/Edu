using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.KQ
{
    public partial class QueryKQList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbSearch_Click(object sender, EventArgs e)
        {
            databind();
        }

        protected void databind()
        {

            String username = tbUsername.Text;
            DateTime startDate = Convert.ToDateTime(tbStartTime.Text + " 00:00:00");
            DateTime endDate = Convert.ToDateTime(tbEndTime.Text + " 23:59:59");
            gvKQList.DataSource = BLL.Application.KQ.KQManagement.getAppointRecordsByUsername(username, startDate, endDate);
            gvKQList.DataBind();

        }
        protected void gvKQList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvKQList.PageIndex = e.NewPageIndex;
            databind();
        }


        protected void lbStatus_DataBinding(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            v_KQ_punchcard_record kq = this.GetDataItem() as v_KQ_punchcard_record;
            switch (kq.status)
            {
                case 0:
                    lb.Text =  "正常";
                    lb.ForeColor = System.Drawing.Color.Green;
                    break;
                case 1:
                    lb.Text = "迟到";
                    lb.ForeColor = System.Drawing.Color.Red;
                    break;
                case 2:
                    lb.Text = "早退";

                    lb.ForeColor = System.Drawing.Color.Red;
                    break;
                default:
                    lb.Text = "";
                    break;
            }
        }

        protected void gvKQList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String id = gvKQList.DataKeys[e.RowIndex].Value.ToString();

            if (BLL.Application.KQ.KQManagement.deletePunchCardRecord(Convert.ToInt32(id)))
            {
                lbMessage.Text = "删除成功！";
                BLL.pub.PubClass.showAlertMessage(Page, ClientScript, "删除成功!");
            }
            databind();
        }
    }
}