using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace web.admin.user
{
    public partial class UserManagement : System.Web.UI.Page
    {

        BLL.pub.PagerTClass pageT = new BLL.pub.PagerTClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["index_page"] = 1;
                PanelAddUser.Visible = false;
                PanelDaoru.Visible = false;
                ViewState["search_id"] = "";
                databind();
            }
        }

        protected void setPaginationStatus()
        {

            lbTotPage.Text = pageT.PageCount.ToString();
            lbIndexPage.Text = pageT.IndexPage.ToString();
            lbTotPage1.Text = pageT.PageCount.ToString();

            lbPrePage.Enabled = pageT.PrevShow;
            lbNexPage.Enabled = pageT.NextShow;
        }
        protected void databind(String name = "", int pageIndex = 1)
        {


            List<Users> users = null;


            users = BLL.admin.user.UserManagement.getUsers(pageIndex, BLL.pub.PubClass.PAGE_SIZE, ref pageT, name);


            setPaginationStatus();
            ViewState["tot_page"] = pageT.PageCount;


            gvUsers.DataSource = users;
            gvUsers.DataBind();
        }

        protected void gvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

         //   gvUsers.PageIndex = e.NewPageIndex;
        //    databind();
        }

        protected void gvUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            gvUsers.EditIndex = -1;
            databind((String)ViewState["search_id"], (int)ViewState["index_page"]);
        }

        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String id = gvUsers.DataKeys[e.RowIndex].Value.ToString();

            if (BLL.admin.user.UserManagement.DeleteUserById(id))
            {
                lbMessage.Text = "删除用户成功！";
                databind((String)ViewState["search_id"], (int)ViewState["index_page"]);
            }
        }

        protected void gvUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
           
            gvUsers.EditIndex = e.NewEditIndex;
            databind((String)ViewState["search_id"], (int)ViewState["index_page"]);
        }

        protected void gvUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String id = gvUsers.DataKeys[e.RowIndex].Value.ToString();
            String XMPY = ((TextBox)gvUsers.Rows[e.RowIndex].Cells[1].FindControl("tbNetid")).Text.ToString().Trim();
            String orderNo = ((TextBox)gvUsers.Rows[e.RowIndex].Cells[2].FindControl("tbOrderNo")).Text.ToString().Trim();
            String TrueName = ((TextBox)gvUsers.Rows[e.RowIndex].Cells[3].FindControl("tbUserName")).Text.ToString().Trim();
            TextBox tbPasswd = (TextBox)gvUsers.Rows[e.RowIndex].Cells[4].FindControl("tbPasswd");

            TextBox tbJobNumber = (TextBox)gvUsers.Rows[e.RowIndex].Cells[5].FindControl("tbJobNumber");
            DropDownList ddlDepartment = (DropDownList)gvUsers.Rows[e.RowIndex].Cells[6].FindControl("DropDownListDepartment");
            int departmentId = Convert.ToInt32(ddlDepartment.SelectedValue);

            if (String.IsNullOrEmpty(orderNo))
                orderNo = "0";
            BLL.admin.user.UserManagement.UpdateUser(Convert.ToInt32(id), XMPY, TrueName, tbPasswd.Text, tbJobNumber.Text, departmentId,Convert.ToInt32(orderNo));
            gvUsers.EditIndex = -1; //将GridView控件恢复为编辑前的状态。即更新完了就得回到非编辑状态
            databind((String)ViewState["search_id"], (int)ViewState["index_page"]); //更新完了之后，就得重新绑定，即重新从数据库中读取刚才更新的数据。

        }

        protected void lbAdd_Click(object sender, EventArgs e)
        {

            PanelAddUser.Visible = true;
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            String XMPY = tbNetId.Text;
            String TrueName = tbUsername.Text;

            try
            {
                BLL.admin.user.UserManagement.CreatUser(TrueName, XMPY);
                lbMessage.Text = "创建用户：  " + TrueName + " 成功！";
            }
            catch (Exception ex)
            {
                lbMessage.Text = "创建用户失败！" + ex.Message;

            }

        }

        protected void lbSearch_Click(object sender, EventArgs e)
        {
            
            ViewState["search_id"] = tbUserId.Text;
            databind((String)ViewState["search_id"]);

        }

        protected void lbPrePage_Click(object sender, EventArgs e)
        {
            ViewState["index_page"] = Convert.ToInt32(lbIndexPage.Text) - 1;
            databind((String)ViewState["search_id"], (int)ViewState["index_page"]);
        }

        protected void lbNexPage_Click(object sender, EventArgs e)
        {
            ViewState["index_page"] = Convert.ToInt32(lbIndexPage.Text) + 1;
            databind((String)ViewState["search_id"], (int)ViewState["index_page"]);
        }

        protected void lbGo_Click(object sender, EventArgs e)
        {
            ViewState["index_page"] = Convert.ToInt32(tbGoNo.Text);
            databind((String)ViewState["search_id"], (int)ViewState["index_page"]);
        }

        protected void lbFirstPage_Click(object sender, EventArgs e)
        {
            ViewState["index_page"] = 1;
            databind((String)ViewState["search_id"], 1);
        }

        protected void lbLastPage_Click(object sender, EventArgs e)
        {

            ViewState["index_page"] = ((int)ViewState["tot_page"]);
            databind((String)ViewState["search_id"], (int)ViewState["tot_page"]);
        }

        protected void lbDepartment_DataBinding(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            Users user = GetDataItem() as Users;

            if(user.DepartmentId != null )
                lb.Text = BLL.admin.department.DepartmentManagement.getDepartmentById((int)user.DepartmentId).Name;
        }

        protected void ddlDepartment_DataBinding(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            Users user = GetDataItem() as Users;

            List<Department> list = BLL.admin.department.DepartmentManagement.getDepartments();

            foreach (Department d in list)
            {
                ListItem li = new ListItem();
                li.Value = d.ID.ToString();
                li.Text = d.Name;
                if (d.ID == user.DepartmentId)
                    li.Selected = true;
                ddl.Items.Add(li);
            }
        }

        protected void juese_DataBinding(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            Users user = GetDataItem() as Users;
            List<v_User_Role> list = BLL.admin.role.RoleManagement.getRolesByUserId(user.Key);

            foreach (v_User_Role r in list)
            {
                lb.Text += r.rolename+" ";
            }
        }

        protected void BtnImport_Click(object sender, EventArgs e)
        {
            string filename = string.Empty;
            try
            {

                filename = BLL.pub.PubClass.UpLoadXls(FileExcel);//上传XLS文件
                DataSet ds = BLL.pub.PubClass.ImportXlsToData(filename);//将XLS文件的数据导入数据库   

                BLL.admin.user.UserManagement.AddDatasetToUsers(ds);
                if (filename != string.Empty && System.IO.File.Exists(filename))
                {
                    System.IO.File.Delete(filename);//删除上传的XLS文件
                }
                lbMessage.Text = "数据导入成功！";
                databind();

            }
            catch (Exception ex)
            {
                lbMessage.Text = ex.Message;
            }
        }

        protected void lbDaoru_Click(object sender, EventArgs e)
        {
            PanelDaoru.Visible = true;
        }

        protected void lbUserInfo_DataBinding(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            Users item = GetDataItem() as Users;

            String url = "/admin/user/UserInfo.aspx?id=" + item.Key;
            lb.PostBackUrl = url;
        }
    }
}