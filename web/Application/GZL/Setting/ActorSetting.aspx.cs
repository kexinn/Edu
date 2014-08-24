using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.GZL.Setting
{
    public partial class ActorSetting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                PanelAddActor.Visible = false;
                databind();
            }
        }
        protected void databind()
        {
            int routid = Convert.ToInt32( Request["routid"]);
            gvActor.DataSource = BLL.Application.GZL.Setting.ActorManagement.getActorsByRoutId(routid);
            gvActor.DataBind();
        }
        protected void lbAdd_Click(object sender, EventArgs e)
        {
            PanelAddActor.Visible = true;
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            
            int routid = Convert.ToInt32( Request["routid"]);
            String actorname = tbActorName.Text;
            String sortno = tbSortNo.Text;

            t_GZL_Actor actor = new t_GZL_Actor();
            actor.actorName = actorname;
            actor.sortNo = Convert.ToInt32(sortno);
            actor.routId = routid;
            if (BLL.Application.GZL.Setting.ActorManagement.creatActor(actor))
                lbMessage.Text = "添加步骤成功";
            databind();
            
        }

        protected void gvActor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvActor.PageIndex = e.NewPageIndex;
            databind();
        }

        protected void gvActor_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            gvActor.EditIndex = -1;
            databind();
        }

        protected void gvActor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String id = gvActor.DataKeys[e.RowIndex].Value.ToString();

            if (BLL.Application.GZL.Setting.ActorManagement.deleteActorById(id))
            {
                lbMessage.Text = "删除步骤成功！";
            }
            databind();
        }

        protected void gvActor_RowEditing(object sender, GridViewEditEventArgs e)
        {

            gvActor.EditIndex = e.NewEditIndex;
            databind();
        }

        protected void gvActor_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String id = gvActor.DataKeys[e.RowIndex].Value.ToString();
            String actorName = ((TextBox)gvActor.Rows[e.RowIndex].Cells[2].FindControl("tbActorName")).Text.ToString().Trim();
            String sortNo = ((TextBox)gvActor.Rows[e.RowIndex].Cells[3].FindControl("tbSortNo")).Text.ToString().Trim();

            t_GZL_Actor actor = BLL.Application.GZL.Setting.ActorManagement.getActorById(Convert.ToInt32(id));

            actor.actorName = actorName;
            actor.sortNo = Convert.ToInt32(sortNo);
            
            BLL.Application.GZL.Setting.ActorManagement.updateActor(actor);


            gvActor.EditIndex = -1; //将GridView控件恢复为编辑前的状态。即更新完了就得回到非编辑状态
            databind(); //更新完了之后，就得重新绑定，即重新从数据库中读取刚才更新的数据。
        }
    }
}