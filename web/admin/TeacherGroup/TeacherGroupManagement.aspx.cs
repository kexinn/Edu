using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.admin.TeacherGroup
{
    public partial class TeacherGroupManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                PanelAddGroup.Visible = false;
                databind();
            }
        }

        protected void databind()
        {
            gvTeacherGroup.DataSource = BLL.admin.TeacherGroup.TeacherGroupManagement.getDepartments();
            gvTeacherGroup.DataBind();
        }

        protected void lbAdd_Click(object sender, EventArgs e)
        {
            PanelAddGroup.Visible = true;
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            t_Teacher_Group tGroup = new t_Teacher_Group();
            tGroup.Name = tbGroupName.Text;
            BLL.admin.TeacherGroup.TeacherGroupManagement.createTeacherGroup(tGroup);
            lbMessage.Text = "添加成功！";
            databind();
        }

        protected void gvTeacherGroup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvTeacherGroup.PageIndex = e.NewPageIndex;
            databind();
        }

        protected void gvTeacherGroup_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            gvTeacherGroup.EditIndex = -1;
            databind();
        }

        protected void gvTeacherGroup_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            String id = gvTeacherGroup.DataKeys[e.RowIndex].Value.ToString();

            if (BLL.admin.TeacherGroup.TeacherGroupManagement.deleteTeacherGroupById(id))
            {
                lbMessage.Text = "删除成功！";
            }
            databind();
        }

        protected void gvTeacherGroup_RowEditing(object sender, GridViewEditEventArgs e)
        {

            gvTeacherGroup.EditIndex = e.NewEditIndex;
            databind();
        }

        protected void gvTeacherGroup_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String id = gvTeacherGroup.DataKeys[e.RowIndex].Value.ToString();
            String strName = ((TextBox)gvTeacherGroup.Rows[e.RowIndex].Cells[2].FindControl("tbTeacherGroupName")).Text.ToString().Trim();

            String managerName = ((TextBox)gvTeacherGroup.Rows[e.RowIndex].Cells[3].FindControl("tbLeaderName")).Text.ToString().Trim();

            int managerId = -1;
            try
            {
                Users user =  BLL.admin.user.UserManagement.getUserByName(managerName);
                if (user != null)
                    managerId = user.Key;
            }
            catch (Exception ex) { };

            t_Teacher_Group tg = new t_Teacher_Group();
            tg.Id = Convert.ToInt32(id);
            tg.Name = strName;
            tg.LeaderId = managerId;
            BLL.admin.TeacherGroup.TeacherGroupManagement.updateTeacherGroup(tg);


            gvTeacherGroup.EditIndex = -1; //将GridView控件恢复为编辑前的状态。即更新完了就得回到非编辑状态
            databind(); //更新完了之后，就得重新绑定，即重新从数据库中读取刚才更新的数据。
        }

    }
}