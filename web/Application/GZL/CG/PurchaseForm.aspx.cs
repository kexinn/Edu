using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.GZL.CG
{
    public partial class PurchaseForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PanelSongShen.Visible = false;
                PanelForm.Visible = true;
                initdata();
            }
        }

        protected void initdata()
        {
            String itemid =  Request["itemid"].ToString();

            t_GZL_Item item = BLL.Application.GZL.GzlManagement.getItemById(Convert.ToInt32(itemid));

            lbDept.Text = BLL.admin.department.DepartmentManagement.getDepartmentById((int)item.deptId).Name;
            lbUserName.Text = Session["username"].ToString();
            lbYear.Text = item.ApplyDate.Value.Year.ToString();
            lbMonth.Text = item.ApplyDate.Value.Month.ToString();
            lbDay.Text = item.ApplyDate.Value.Day.ToString();

            List< v_Deparment_Leader> leaders = BLL.admin.department.DepartmentManagement.getDepartmentLeadersByDepartmentId((int)item.deptId);
            foreach(v_Deparment_Leader li in leaders)
            {
                ListItem list = new ListItem();
                list.Value = li.userid.ToString();
                list.Text = li.LeaderName;
                listBoxLeader.Items.Add(list);
            }

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
                tbReason.Text = form.applyReason;
            }
        }


        protected void RepeaterItem_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName == "del")
            {
                BLL.Application.GZL.CG.PurchaseManagement.deleteFormPurchaseItemById(Convert.ToInt32(e.CommandArgument.ToString()));
                databind();
            }
        }

       
        protected void lbSongShen_Click(object sender, EventArgs e)
        {
            PanelSongShen.Visible = true;
            PanelForm.Visible = false;
        }


        protected void lbSure_Click(object sender, EventArgs e)
        {
            if (listBoxLeader.SelectedItem == null)
            {
                lbModalMessage.Text = "请选择用户";
                return;
            }

            try
            {
                String itemid = Request["itemid"].ToString();
                BLL.Application.GZL.CG.PurchaseManagement.applyItem(itemid, Session["username"].ToString(), Convert.ToInt32(listBoxLeader.SelectedValue));
                lbModalMessage.Text = "送审成功!请关闭窗口";

                Response.Write("<script LANGUAGE='javascript'>alert('送审成功！');window.close();</script>");
                Response.End();
            }
            catch (Exception ex)
            {
                lbModalMessage.Text = ex.Message;
            }
        }

        protected void lbAdd_Click(object sender, EventArgs e)
        {
            String itemid = Request["itemid"].ToString();
            t_GZL_Item item = BLL.Application.GZL.GzlManagement.getItemById(Convert.ToInt32(itemid));
            if (BLL.Application.GZL.CG.PurchaseManagement.getPurchaseFormCountByItemGuid((Guid)item.itemGuid) == 0)
            {
                t_Form_Purchase form = new t_Form_Purchase();
                form.applyDept = item.deptId;
                form.applyUserId = (int)Session["userid"];
                form.applyDate = item.ApplyDate;
                form.itemGuid = item.itemGuid;
                form.totalPrice = 0;
                BLL.Application.GZL.CG.PurchaseManagement.createFormPurchase(form);
            }
            try
            {
                t_Form_Purchase form = BLL.Application.GZL.CG.PurchaseManagement.getPurchaseFormByItemGuid((Guid)item.itemGuid);
                t_Form_Purchase_Items items = new t_Form_Purchase_Items();
                items.formId = form.formId;
                items.itemName = tbZCName.Text;
                items.sortId = Convert.ToInt16(tbSortNo.Text);
                items.type = tbType.Text;
                items.price = Convert.ToDouble(tbPrice.Text);
                items.needNumber = Convert.ToInt16(tbNeedAmont.Text);
                items.number = Convert.ToInt16(tbNeedAmont.Text);
                items.totalPrice = items.price * items.number;
                items.memo = tbMemo.Text;
                BLL.Application.GZL.CG.PurchaseManagement.insertFormPurchaseItems(items,form);
                databind();
            }
            catch (Exception ex)
            {
                lbMessage.Text = "添加错误：" + ex.Message;
            }
        }

        protected void lbSave_Click(object sender, EventArgs e)
        {
            String itemid = Request["itemid"].ToString();
            BLL.Application.GZL.CG.PurchaseManagement.saveFormReason(itemid, Convert.ToInt32(Session["userid"]), tbReason.Text);
            lbResMessage.Text = "保存成功！";
        }

    }
}