using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.GZL.CG
{
    public partial class PurchaseDetailList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                routEdit();
                initdata();
            }
        }

        protected void routEdit()
        {
            String itemid = Request["itemid"].ToString();

            t_GZL_Actor actor = BLL.Application.GZL.CG.ApplyProceed.getActorByItemId(Convert.ToInt32(itemid));


            if (actor !=null && actor.actorName == "仓库核算")
            {
                Response.Redirect("PurchaseFormEdit.aspx?itemid=" + itemid);
            }
        }
        protected void initdata()
        {
            String itemid = Request["itemid"].ToString();

            t_GZL_Item item = BLL.Application.GZL.GzlManagement.getItemById(Convert.ToInt32(itemid));
            t_Form_Purchase form = BLL.Application.GZL.CG.PurchaseManagement.getPurchaseFormByItemGuid((Guid)item.itemGuid);
            /*
            lbDept.Text = BLL.admin.department.DepartmentManagement.getDepartmentById((int)item.deptId).Name;
            lbUserName.Text = Session["username"].ToString();
            lbYear.Text = item.ApplyDate.Value.Year.ToString();
            lbMonth.Text = item.ApplyDate.Value.Month.ToString();
            lbDay.Text = item.ApplyDate.Value.Day.ToString();*/


            lbDept.Text = BLL.admin.department.DepartmentManagement.getDepartmentById((int)item.deptId).Name;
            lbUserName.Text = BLL.admin.user.UserManagement.getUserById( (int)form.applyUserId).TrueName;
            lbYear.Text = item.ApplyDate.Value.Year.ToString();
            lbMonth.Text = item.ApplyDate.Value.Month.ToString();
            lbDay.Text = item.ApplyDate.Value.Day.ToString();
            lbFenguanYijian.Text = form.FenGuanYiJian;
            lbXiaozhangYijian.Text = form.XiaoZhangYiJian;

            if( Convert.ToInt32( Session["userid"]) != BLL.Application.GZL.CG.PurchaseManagement.getTaskActorUserId(itemid))
                PanelBanli.Visible = false;

            String url = "/Application/GZL/CG/ApplyProceed.aspx?itemguid=" + item.itemGuid;
            String click = "window.open('" + url + "','Sample','toolbar=no,location=no,directories=no,status=no,menubar=yes,scrollbars=yes,resizable=yes,copyhistory=yes,width=500,height=500,left=100,top=100');return false;";
            
            linkBanli.Attributes.Add("onclick", click);
            databind();

        }
        protected void databind()
        {
            String itemid = Request["itemid"].ToString();
            t_GZL_Item item = BLL.Application.GZL.GzlManagement.getItemById(Convert.ToInt32(itemid));
            if (BLL.Application.GZL.CG.PurchaseManagement.getPurchaseFormCountByItemGuid((Guid)item.itemGuid) > 0)
            {
                t_Form_Purchase form = BLL.Application.GZL.CG.PurchaseManagement.getPurchaseFormByItemGuid((Guid)item.itemGuid);
                RepeaterItem.DataSource = BLL.Application.GZL.CG.PurchaseManagement.getFormPurchaseItemsByFormId((int)form.formId);
                RepeaterItem.DataBind();
                lbReason.Text = form.applyReason;
            }
        }



    }
}