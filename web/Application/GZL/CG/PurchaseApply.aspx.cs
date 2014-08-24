using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.GZL.CG
{
    public partial class PurchaseApply : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PanelAddItem.Visible = false;
                databind();
                initDDLDept();
            }
        }

        protected void initDDLDept()
        {
            ddlDept.Items.Clear();
            List<Department> detp = BLL.admin.department.DepartmentManagement.getDepartments();
            ddlDept.Items.Add(new ListItem(""));
            foreach(Department t in detp)
            {
                ListItem item = new ListItem();
                item.Value = t.ID.ToString();
                item.Text = t.Name;
                ddlDept.Items.Add(item);
            }
        }

        protected void databind()
        {
            int userid = (int)Session["userid"];
          
            gvApply.DataSource = BLL.Application.GZL.CG.PurchaseManagement.getMyApplyItems(userid, "采购单");
            gvApply.DataBind();
        }

        protected void lbState_DataBinding(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            v_GZL_MyApplyItem item = GetDataItem() as v_GZL_MyApplyItem;
            if (item.State == "审批通过")
                lb.ForeColor = System.Drawing.Color.Green;
            if (item.State == "审批拒绝")
                lb.ForeColor = System.Drawing.Color.Red;
        }

        protected void gvApply_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvApply.PageIndex = e.NewPageIndex;
            databind();
        }


        protected void lbAdd_Click(object sender, EventArgs e)
        {
            PanelAddItem.Visible = true;
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                
                t_GZL_Item item = new t_GZL_Item();
                item.ApplyDate = DateTime.Now;
                item.ApplyUserId = (int)Session["userid"];
                item.deptId = Convert.ToInt32(ddlDept.SelectedValue);
                item.ItemName = tbItemName.Text;
                item.ItemType = "采购单";
                item.RoutId = 1;
                item.State = "待发布";
                Guid guid = Guid.NewGuid();
                item.itemGuid = guid;
                BLL.Application.GZL.GzlManagement.createItem(item);

                t_GZL_TaskList task = new t_GZL_TaskList();
                t_GZL_Actor actor = BLL.Application.GZL.Setting.ActorManagement.getActorForNextSortByRoutId(1, 0);
                if (actor != null)
                    task.actorId = actor.actorId;
                task.itemGuid = guid;
                task.state = "待检出";
                task.version = 1;
                BLL.Application.GZL.GzlManagement.insertTask(task);

                t_GZL_actorUser au = new t_GZL_actorUser();
                
                au.actorId = actor.actorId;
                au.itemGuid = guid;
                au.operateUserId = (int)Session["userid"];
                BLL.Application.GZL.GzlManagement.insertActorUser(au);

                t_GZL_TaskHistory history = new t_GZL_TaskHistory();
                history.actorId = actor.actorId;
                history.createDate = System.DateTime.Now;
                history.itemGuid = guid;
                history.operatorName = Session["username"].ToString();
                history.action = "创建";
                BLL.Application.GZL.GzlManagement.insertTaskHistory(history);
                
                lbMessage.Text = "添加成功";
                databind();
            }
            catch (Exception ex)
            {
                lbMessage.Text = "添加失败：" + ex.Message;
            }
        }

        protected void lbDetail_DataBinding(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            v_GZL_MyApplyItem item = GetDataItem() as v_GZL_MyApplyItem;
            if (item.State == "待发布")
                lb.Visible = true;
            else
                lb.Visible = false;
            String url = "/Application/GZL/CG/PurchaseForm.aspx?itemid=" + item.ItemId;
            String click = "window.open('" + url + "','Sample','toolbar=no,location=no,directories=no,status=no,menubar=yes,scrollbars=yes,resizable=yes,copyhistory=yes,width=1024,height=500,left=100,top=100')";
            lb.Attributes.Add("onclick", "return false;");
            lb.OnClientClick = click;
        }

        protected void lbLookDetail_DataBinding(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            v_GZL_MyApplyItem item = GetDataItem() as v_GZL_MyApplyItem;
            if (item.State != "待发布")
                lb.Visible = true;
            else
                lb.Visible = false;
            String url = "/Application/GZL/CG/PurchaseDetailList.aspx?itemid=" + item.ItemId;
            String click = "window.open('" + url + "','Sample','toolbar=no,location=no,directories=no,status=no,menubar=yes,scrollbars=yes,resizable=yes,copyhistory=yes,width=1024,height=500,left=100,top=100')";
            lb.Attributes.Add("onclick", "return false;");
            lb.OnClientClick = click;
        }
        /*
        protected void lbApplyUser_DataBinding(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            lb.Text = Convert.ToDateTime(lb.Text).ToShortDateString();
        }
        */
        protected void lbHistory_DataBinding(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            v_GZL_MyApplyItem item = GetDataItem() as v_GZL_MyApplyItem;

            String url = "/Application/GZL/CG/PurchaseHistory.aspx?itemguid=" + item.itemGuid;
            String click = "window.open('" + url + "','Sample','toolbar=no,location=no,directories=no,status=no,menubar=yes,scrollbars=yes,resizable=yes,copyhistory=yes,width=1024,height=500,left=100,top=100')";

            lb.OnClientClick = click;
        }


    }
}