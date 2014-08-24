using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.GZL.CG
{
    public partial class PurchaseStatisc : System.Web.UI.Page
    {
        BLL.pub.PagerTClass pageT = new BLL.pub.PagerTClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["index_page"] = 1;
                ViewState["searchDept"] = "";
                ViewState["searchItemName"] = "";
                ViewState["searchStartTime"] = "";
                ViewState["searchEndTime"] = "";
                initDept();
                databind();
            }
        }

        protected void initDept()
        {
            ddlDept.Items.Clear();
            List<Department> detp = BLL.admin.department.DepartmentManagement.getDepartments();
            ddlDept.Items.Add(new ListItem(""));
            foreach (Department t in detp)
            {
                ListItem item = new ListItem();
                item.Value = t.ID.ToString();
                item.Text = t.Name;
                ddlDept.Items.Add(item);
            }
        }
        protected void databind(int pageIndex = 1)
        {
            List<v_GZL_MyApplyItem> items = null;
           // if(ddlDept.SelectedValue !=null)
                ViewState["searchDept"] = ddlDept.SelectedValue;
          //  if (!String.IsNullOrEmpty(tbItemName.Text))
                ViewState["searchItemName"] = tbItemName.Text;
          //  if (!String.IsNullOrEmpty(tbStartTime.Text))
                ViewState["searchStartTime"] = tbStartTime.Text;
          //  if (!String.IsNullOrEmpty(tbEndTime.Text))
                ViewState["searchEndTime"] = tbEndTime.Text;

            items = BLL.Application.GZL.CG.PurchaseManagement.getApplyItemsByCondition(pageIndex, BLL.pub.PubClass.PAGE_SIZE, ref pageT, (String)ViewState["searchDept"], (String)ViewState["searchItemName"], (String)ViewState["searchStartTime"], (String)ViewState["searchEndTime"]);
            setPaginationStatus();
            ViewState["tot_page"] = pageT.PageCount;


            gvApply.DataSource = items;
            gvApply.DataBind();
        }

        protected void setPaginationStatus()
        {

            lbTotPage.Text = pageT.PageCount.ToString();
            lbIndexPage.Text = pageT.IndexPage.ToString();
            lbTotPage1.Text = pageT.PageCount.ToString();

            lbPrePage.Enabled = pageT.PrevShow;
            lbNexPage.Enabled = pageT.NextShow;
        }
        protected void lbDaoChu_Click(object sender, EventArgs e)
        {

        }

        protected void lbSearch_Click(object sender, EventArgs e)
        {
            databind();
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

        protected void lbHistory_DataBinding(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            v_GZL_MyApplyItem item = GetDataItem() as v_GZL_MyApplyItem;

            String url = "/Application/GZL/CG/PurchaseHistory.aspx?itemguid=" + item.itemGuid;
            String click = "window.open('" + url + "','Sample','toolbar=no,location=no,directories=no,status=no,menubar=yes,scrollbars=yes,resizable=yes,copyhistory=yes,width=1024,height=500,left=100,top=100')";
            lb.Attributes.Add("onclick", "return false;");
            lb.OnClientClick = click;
        }

        protected void lbFirstPage_Click(object sender, EventArgs e)
        {
            ViewState["index_page"] = 1;
            databind( 1);
        }

        protected void lbPrePage_Click(object sender, EventArgs e)
        {
            ViewState["index_page"] = Convert.ToInt32(lbIndexPage.Text) - 1;
            databind( (int)ViewState["index_page"]);
        }

        protected void lbNexPage_Click(object sender, EventArgs e)
        {
            ViewState["index_page"] = Convert.ToInt32(lbIndexPage.Text) + 1;
            databind((int)ViewState["index_page"]);
        }

        protected void lbLastPage_Click(object sender, EventArgs e)
        {

            ViewState["index_page"] = ((int)ViewState["tot_page"]);
            databind( (int)ViewState["tot_page"]);
        }

        protected void lbGo_Click(object sender, EventArgs e)
        {
            ViewState["index_page"] = Convert.ToInt32(tbGoNo.Text);
            databind((int)ViewState["index_page"]);
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
    }
}