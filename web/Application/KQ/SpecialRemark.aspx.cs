using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.KQ
{
    public partial class SpecialRemark : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                databind();
            }
        }
        protected void databind()
        {
           gvKQList.DataSource =  BLL.Application.KQ.SpecialRemark.databind();
           gvKQList.DataBind();
        }

        protected void gvKQList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvKQList.PageIndex = e.NewPageIndex;
            databind();
        }

        protected void gvKQList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String id = gvKQList.DataKeys[e.RowIndex].Value.ToString();

            BLL.Application.KQ.SpecialRemark.deleteRecord(Convert.ToInt32(id));
            
            databind();
        }

        protected void lbAdd_Click(object sender, EventArgs e)
        {
            if(BLL.Application.KQ.SpecialRemark.insertRecord(tbUsername.Text, tbRemark.Text,Convert.ToDateTime(tbStartTime.Text),Convert.ToDateTime(tbEndTime.Text)))
                BLL.pub.PubClass.showAlertMessage(Page, ClientScript, "添加成功！");
            else
                BLL.pub.PubClass.showAlertMessage(Page, ClientScript, "该用户已存在，请先删除！");
            databind();
        }
    }
}