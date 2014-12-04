using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.admin.user
{
    public partial class UserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                databind();
            }
        }

        protected void databind()
        {
            if(Request["id"]!=null)
            {
                Users user = BLL.admin.user.UserManagement.getUserById( Convert.ToInt32( Request["id"]));
                tbUsername.Text = user.TrueName;
                tbJobNumber.Text = user.JobNumber;
                tbNetId.Text = user.XMPY;
                tbEmail.Text = user.EMail;
                openid.Text = user.openUserId;
                tbDuanhao.Text = user.duanhao;
                tbChanghao.Text = user.changhao;
                tbOrder.Text = user.orderNo.ToString();
                var depts = BLL.admin.department.DepartmentManagement.getDepartments();
                ddlDept.Items.Clear();
                ddlDept.Items.Add(new ListItem(""));
                foreach(Department dept in depts)
                {
                    ListItem li = new ListItem();
                    li.Text = dept.Name;
                    li.Value = dept.ID.ToString();
                    if (dept.ID == user.DepartmentId)
                        li.Selected = true;
                    ddlDept.Items.Add(li);
                }
                foreach(ListItem l in ddlType.Items)
                {
                    if (l.Value == user.UserType.ToString())
                        l.Selected = true;
                }
                ddlJyz.Items.Clear();
                ddlJyz.Items.Add(new ListItem(""));
                var jyz = BLL.admin.TeacherGroup.TeacherGroupManagement.getGroups();
                foreach (v_TeacherGroup t in jyz)
                {
                    ListItem li = new ListItem();
                    li.Text = t.TeacherGroupName;
                    li.Value = t.Id.ToString();
                    if (t.Id == user.TeacherGroupId)
                        li.Selected = true;
                    ddlJyz.Items.Add(li);
                }
                if (user.disabled == true)
                    rbNo.Checked = true;
                else
                    rbYes.Checked = true;

            }
        }

        protected void lbSave_Click(object sender, EventArgs e)
        {
            try
            {
                Users user;
                user = BLL.admin.user.UserManagement.getUserById(Convert.ToInt32(Request["id"]));
                user.TrueName = tbUsername.Text;
                user.JobNumber = tbJobNumber.Text;
                user.XMPY = tbNetId.Text;
                user.EMail = tbEmail.Text;
                user.openUserId = (openid.Text == "") ? null : openid.Text;
                user.duanhao = tbDuanhao.Text;
                user.changhao = tbChanghao.Text;
                if (!String.IsNullOrEmpty(tbOrder.Text))
                    user.orderNo = Convert.ToInt32(tbOrder.Text);
                else
                    user.orderNo = 999;
                if (!String.IsNullOrEmpty(ddlDept.Text))
                    user.DepartmentId = Convert.ToInt32(ddlDept.SelectedValue);
                else
                    user.DepartmentId = null;
                user.UserType = Convert.ToChar(ddlType.SelectedValue);
                if (!String.IsNullOrEmpty(ddlJyz.Text))
                    user.TeacherGroupId = Convert.ToInt32(ddlJyz.SelectedValue);
                else
                    user.TeacherGroupId = null;
                if (rbNo.Checked)
                    user.disabled = true;
                if (rbYes.Checked)
                    user.disabled = false;
                BLL.admin.user.UserManagement.UpdateUser( user);
                BLL.pub.PubClass.showAlertMessage(Page, ClientScript, "保存成功！");

            }catch(Exception ex)
            {
                lbMessage.Text = "保存出错：" + ex.Message;
            }
        }
    }
}