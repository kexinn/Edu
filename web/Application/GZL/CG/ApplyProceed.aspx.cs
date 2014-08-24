using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.GZL.CG
{
    public partial class ApplyProceed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                lbMessage.Text = "";
                PanelFirst.Visible = true;
                PanelNext.Visible = false;
                initdata();
            }
        }

        protected void initdata()
        {
            Guid itemid = new Guid(Request["itemguid"]);

            ViewState["itemid"] = Request["itemguid"];
            t_GZL_Actor actor = BLL.Application.GZL.CG.ApplyProceed.getActorByItemGuid(itemid);
            t_GZL_Actor actor_next = BLL.Application.GZL.Setting.ActorManagement.getActorForNextSortByRoutId((int)actor.routId, (int)actor.sortNo);
            lbActorName.Text = actor.actorName;
            ViewState["actorname"] = actor.actorName;

            if(actor_next!=null)
            {
                lbNextActor.Text = actor_next.actorName;
                ViewState["state"] = "未完成";
                switch(actor_next.actorName)
                {
                    case "仓库核算":
                       List<v_Role_Users> cangku = BLL.admin.role.RoleManagement.getUsersInRole(4);//4是采购负责用户，仓库核算
                       foreach (v_Role_Users li in cangku)
                         {
                             ListItem list = new ListItem();
                             list.Value = li.UserKey.ToString();
                             list.Text = li.username;
                             listBoxUser.Items.Add(list);
                         }
                        break;
                    case "主管校长审批":
                         List< v_Deparment_Leader> leaders = BLL.admin.department.DepartmentManagement.getDepartmentLeadersByDepartmentId(16);//16为校长室
                         foreach (v_Deparment_Leader li in leaders)
                         {
                             ListItem list = new ListItem();
                             list.Value = li.userid.ToString();
                             list.Text = li.LeaderName;
                             listBoxUser.Items.Add(list);
                         }
                        break;
                    case "财务校长审批":
                         List<v_Role_Users> users = BLL.admin.role.RoleManagement.getUsersInRole(3);//3是财务校长角色
                         foreach (v_Role_Users li in users)
                         {
                             ListItem list = new ListItem();
                             list.Value = li.UserKey.ToString();
                             list.Text = li.username;
;
                             listBoxUser.Items.Add(list);
                         }
                        break;
                    case "后勤校长审批":
                        List<v_Role_Users> houqin = BLL.admin.role.RoleManagement.getUsersInRole(5);//3是财务校长角色
                        foreach (v_Role_Users li in houqin)
                        {
                            ListItem list = new ListItem();
                            list.Value = li.UserKey.ToString();
                            list.Text = li.username;
                            ;
                            listBoxUser.Items.Add(list);
                        }
                        break;
                    case "进行采购":
                        List<v_Role_Users> users1 = BLL.admin.role.RoleManagement.getUsersInRole(4);//4是采购负责用户
                         foreach (v_Role_Users li in users1)
                         {
                             ListItem list = new ListItem();
                             list.Value = li.UserKey.ToString();
                             list.Text = li.username;
                             listBoxUser.Items.Add(list);
                         }
                        
                        break;
                }
            }else
            {
                ViewState["state"] = "完成";
            }

        }

        //同意，如果有下一步则选择下一步执行用户，否则终止项目
        protected void lbAgree_Click(object sender, EventArgs e)
        {
            Guid itemguid = new Guid(ViewState["itemid"].ToString());
            String opinion = tbOpinion.Text;

            if (ViewState["state"].ToString() == "完成")
            {
                BLL.Application.GZL.CG.ApplyProceed.setCompleteState(itemguid, opinion, Session["username"].ToString(), Convert.ToInt32(Session["userid"]));

                lbMessage.Text = "办理完成，请关闭窗口。";
                Response.Write("<script LANGUAGE='javascript'>alert('办理完成！');window.close();</script>");
                Response.End();
            }
            else
            {
                PanelFirst.Visible = false;
                PanelNext.Visible = true;

            }
        }
        //拒绝操作
        protected void lbRefuse_Click(object sender, EventArgs e)
        {
            Guid itemguid = new Guid(ViewState["itemid"].ToString());
            String opinion = tbOpinion.Text;

            BLL.Application.GZL.CG.ApplyProceed.setRefuseState(itemguid, opinion, Session["username"].ToString(), Convert.ToInt32(Session["userid"]));
            lbMessage.Text = "拒绝成功！，采购单已返回用户，请关闭窗口。";
            Response.Write("<script LANGUAGE='javascript'>alert('拒绝成功！');window.close();</script>"); 
            Response.End();
        }
        //送审下一步用户
        protected void lbApply_Click(object sender, EventArgs e)
        {
            Guid itemguid = new Guid(ViewState["itemid"].ToString());
            String opinion = tbOpinion.Text;

            if (listBoxUser.SelectedItem == null)
            {
                lbMessage.Text = "请选择用户";
                return;
            }

            try
            {
                BLL.Application.GZL.CG.ApplyProceed.applyItem(itemguid, opinion, Session["username"].ToString(), Convert.ToInt32(Session["userid"]), Convert.ToInt32(listBoxUser.SelectedValue), ViewState["actorname"].ToString());

                lbMessage.Text = "送审成功!请关闭窗口";
                Response.Write("<script LANGUAGE='javascript'>alert('送审成功！');window.close();</script>");
                Response.End();
            }
            catch (Exception ex)
            {
                lbMessage.Text = ex.Message;
            }
        }
    }
}