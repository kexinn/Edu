using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.admin.TeacherGroup
{
    public partial class member_right : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                PanelAddGroup.Visible = false;
                datainit();
                databind();
            }
        }

        protected void datainit()
        {
            String groupid = Request["id"];
            if(String.IsNullOrEmpty(groupid))
            {
                lbAdd.Enabled = false;
                lbMessage.Text = "请先选择教研组";
            }else
            {
                lbTeacherName.Text = BLL.admin.TeacherGroup.TeacherGroupManagement.getTeacherGroupById(Convert.ToInt32(groupid)).Name;
            }
        }
        protected void databind()
        {
            String groupid = Request["id"];
            ViewState["groupid"] = groupid;

            gvGroupUsers.DataSource = BLL.admin.TeacherGroup.TeacherGroupManagement.getTeacherGroupUsersByGroupId(Convert.ToInt32(groupid));
            gvGroupUsers.DataBind();

        }
        protected void lbAdd_Click(object sender, EventArgs e)
        {
            PanelAddGroup.Visible = true;
        }

        protected void btLookfor_Click(object sender, EventArgs e)
        {

            gvSearchUser.DataSource = BLL.admin.user.UserManagement.getUsersByTruename(tbTrueName.Text);
            gvSearchUser.DataBind();
        }

        protected void gvSearchUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent)); //此得出的值是表示那行被选中的索引值 
            int userid = Convert.ToInt32(gvSearchUser.DataKeys[drv.RowIndex].Value); //此获取的值为GridView中绑定数据库中的主键值 

            String groupid = (String)ViewState["groupid"];

            if (e.CommandName == "Add")
            {
                BLL.admin.TeacherGroup.TeacherGroupManagement.setUserToTeacherGroup(userid, Convert.ToInt32(groupid));
                databind();
                lbMessage.Text = "添加成员成功！";
            }
        }

        protected void gvGroupUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvGroupUsers.PageIndex = e.NewPageIndex;
            databind();
        }
    }
}