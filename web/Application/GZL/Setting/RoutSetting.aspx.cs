using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.GZL.Setting
{
    public partial class RoutSetting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PanelAddRout.Visible = false;
                databind();
            }
        }

        protected void databind()
        {
            gvRout.DataSource = BLL.Application.GZL.Setting.RoutManagement.getRoutList();
            gvRout.DataBind();
        }
        protected void btAdd_Click(object sender, EventArgs e)
        {
            t_GZL_Rout rout = new t_GZL_Rout();
            rout.routName = tbRoutName.Text;
            rout.version = Convert.ToInt16(tbVerson.Text);
            rout.State = "草稿";
            BLL.Application.GZL.Setting.RoutManagement.createRout(rout);
            databind();
        }

        protected void lbState_DataBinding(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            t_GZL_Rout rout = GetDataItem() as t_GZL_Rout;
            if (rout.State == "停止")
                lb.ForeColor = System.Drawing.Color.Red;
            if (rout.State == "发布")
                lb.ForeColor = System.Drawing.Color.Green;


        }

        protected void lbEdit_DataBinding(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            t_GZL_Rout rout = GetDataItem() as t_GZL_Rout;
            if (rout.State == "停止")
                lb.Enabled = false;
            if (rout.State == "发布")
                lb.Enabled = false;

        }

        protected void lbDel_DataBinding(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            t_GZL_Rout rout = GetDataItem() as t_GZL_Rout;
            if (rout.State == "停止")
                lb.Enabled = false;
            if (rout.State == "发布")
                lb.Enabled = false;
        }

        protected void lbAdd_Click(object sender, EventArgs e)
        {
            PanelAddRout.Visible = true;
            
        }

        protected void gvRout_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvRout.PageIndex = e.NewPageIndex;
            databind();
        }

        protected void gvRout_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvRout.EditIndex = -1;
            databind();
        }

        protected void gvRout_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String id = gvRout.DataKeys[e.RowIndex].Value.ToString();

            if (BLL.Application.GZL.Setting.RoutManagement.deleteRoutById(id))
            {
                lbMessage.Text = "删除流程成功！";
            }
            databind();
        }

        protected void gvRout_RowEditing(object sender, GridViewEditEventArgs e)
        {

            gvRout.EditIndex = e.NewEditIndex;
            databind();
        }

        protected void gvRout_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String id = gvRout.DataKeys[e.RowIndex].Value.ToString();
            String routName = ((TextBox)gvRout.Rows[e.RowIndex].Cells[2].FindControl("tbRoutName")).Text.ToString().Trim();
            String version = ((TextBox)gvRout.Rows[e.RowIndex].Cells[3].FindControl("tbVersion")).Text.ToString().Trim();

            t_GZL_Rout rout = BLL.Application.GZL.Setting.RoutManagement.getRoutById(Convert.ToInt32(id));

            rout.routName = routName;
            rout.version = Convert.ToInt32( version);
            
            BLL.Application.GZL.Setting.RoutManagement.updateRout(rout);


            gvRout.EditIndex = -1; //将GridView控件恢复为编辑前的状态。即更新完了就得回到非编辑状态
            databind(); //更新完了之后，就得重新绑定，即重新从数据库中读取刚才更新的数据。
        }

        protected void gvRout_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           

            if (e.CommandName == "release")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                BLL.Application.GZL.Setting.RoutManagement.updateRoutState(id, "发布");
            }
            else if (e.CommandName == "stop")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                BLL.Application.GZL.Setting.RoutManagement.updateRoutState(id, "停止");

            }
        }

        protected void lbRoutName_DataBinding(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            t_GZL_Rout rout = GetDataItem() as t_GZL_Rout;

            lb.PostBackUrl = "/Application/GZL/Setting/ActorSetting.aspx?routid=" + rout.routId;
        }

        protected void lbRelease_DataBinding(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            t_GZL_Rout rout = GetDataItem() as t_GZL_Rout;
            if (rout.State == "发布")
                lb.Enabled = false;
        }

        protected void lbStop_DataBinding(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            t_GZL_Rout rout = GetDataItem() as t_GZL_Rout;
            if (rout.State == "停止")
                lb.Enabled = false;
        }

    }
}