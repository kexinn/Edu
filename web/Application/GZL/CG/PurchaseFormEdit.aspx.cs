using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.GZL.CG
{
    public partial class PurchaseFormEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                initdata();
            }
        }

        protected void initdata()
        {
            String itemid = Request["itemid"].ToString();

            t_GZL_Item item = BLL.Application.GZL.GzlManagement.getItemById(Convert.ToInt32(itemid));
            t_Form_Purchase form = BLL.Application.GZL.CG.PurchaseManagement.getPurchaseFormByItemGuid((Guid)item.itemGuid);
            

            lbDept.Text = BLL.admin.department.DepartmentManagement.getDepartmentById((int)item.deptId).Name;
            lbUserName.Text = BLL.admin.user.UserManagement.getUserById((int)form.applyUserId).TrueName;
            lbYear.Text = item.ApplyDate.Value.Year.ToString();
            lbMonth.Text = item.ApplyDate.Value.Month.ToString();
            lbDay.Text = item.ApplyDate.Value.Day.ToString();

            if (Convert.ToInt32(Session["userid"]) != BLL.Application.GZL.CG.PurchaseManagement.getTaskActorUserId(itemid))
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

                ListView1.DataSource = BLL.Application.GZL.CG.PurchaseManagement.getFormPurchaseItemsByFormId((int)form.formId);
                ListView1.DataBind();
            }
        }

        protected void ListView1_ItemEditing(object sender, ListViewEditEventArgs e)
        {

            ListView1.EditIndex = e.NewEditIndex;
            databind();
        }

        protected void ListView1_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {

            ListView1.EditIndex = -1;
            this.ListView1.InsertItemPosition = InsertItemPosition.None;
            databind();
        }

        protected void ListView1_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            string id = ListView1.DataKeys[e.ItemIndex].Value.ToString();

            TextBox tbType = ListView1.EditItem.FindControl("tbType") as TextBox;
            TextBox tbPrice = ListView1.EditItem.FindControl("tbPrice") as TextBox;
            TextBox tbNumber = ListView1.EditItem.FindControl("tbNumber") as TextBox;

            try
            {
                BLL.Application.GZL.CG.PurchaseFormEdit.updatePurchaseFormItems(Convert.ToInt32(id), tbType.Text, float.Parse(tbPrice.Text), Convert.ToInt32(tbNumber.Text));
            }
            catch (Exception ex)
            {
                lbMessage.Text = "更新错误：" + ex.Message;
            }
            ListView1.EditIndex = -1;
            databind();
        }
    }
}