using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.GZL.CG
{
    public partial class ApplyApprove : System.Web.UI.Page
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
            gvApply.DataSource = BLL.Application.GZL.CG.ApplyApprove.getTaskListByUserid(Convert.ToInt32(Session["userid"]));
            gvApply.DataBind();
        }
        protected void gvApply_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvApply.PageIndex = e.NewPageIndex;
            databind();
        }

        protected void lbLookDetail_DataBinding(object sender, EventArgs e)
        {

            LinkButton lb = (LinkButton)sender;

            v_GZL_MyTaskList item = GetDataItem() as v_GZL_MyTaskList;
            
            String url = "/Application/GZL/CG/PurchaseDetailList.aspx?itemid=" + item.ItemId;
            String click = "window.open('" + url + "','Sample','toolbar=no,location=no,directories=no,status=no,menubar=yes,scrollbars=yes,resizable=yes,copyhistory=yes,width=1024,height=600,left=100,top=100')";
            lb.Attributes.Add("onclick", "return false;");
           
            lb.OnClientClick = click;
        }

        protected void lbHistory_DataBinding(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            v_GZL_MyTaskList item = GetDataItem() as v_GZL_MyTaskList;

            String url = "/Application/GZL/CG/PurchaseHistory.aspx?itemguid=" + item.itemGuid;
            String click = "window.open('" + url + "','Sample','toolbar=no,location=no,directories=no,status=no,menubar=yes,scrollbars=yes,resizable=yes,copyhistory=yes,width=1024,height=500,left=100,top=100')";
            lb.Attributes.Add("onclick", "return false;");
            lb.OnClientClick = click;
        }
    }
}