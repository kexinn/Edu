using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Application.GZL.CG
{
    public partial class PurchaseHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                initdata();
            }
        }
        protected void initdata()
        {
            Guid itemid = new Guid(Request["itemguid"]);
            gvHistory.DataSource = BLL.Application.GZL.CG.PurchaseManagement.getPurchaseHistoryByItemGuid(itemid);
            gvHistory.DataBind();
        }

        protected void gvApply_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvHistory.PageIndex = e.NewPageIndex;
            initdata();
        }
    }
}