using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.admin.user
{
    public partial class DepartmentManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                PanelAddRole.Visible = false;
                databind();
            }
        }
/*

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlControl hc =
                Page.Master.Master.FindControl("ContentPlaceHolder1").FindControl("liDepartment") as System.Web.UI.HtmlControls.HtmlControl;

            hc.Attributes.Add("class", "active");
        }
        */
        protected void databind()
        {

           
            List<v_Deparment_Headmaster> depart = null;


            depart = BLL.admin.department.DepartmentManagement.get_vDepartments();


            this.gvDepartment.DataSource = depart;
            this.gvDepartment.DataBind();
        }

        protected void lbDepartmentName_DataBinding(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            v_Deparment_Headmaster dep = GetDataItem() as v_Deparment_Headmaster;

            lb.PostBackUrl = "/admin/user/DepartmentLeaderManagement.aspx?id=" + dep.ID;
        }

        protected void lbDepartmentHead_DataBinding(object sender, EventArgs e)
        {

            Label lb = (Label)sender;
            v_Deparment_Headmaster dep = GetDataItem() as v_Deparment_Headmaster;
            List<v_Deparment_Leader> list = BLL.admin.department.DepartmentManagement.getDepartmentLeadersByDepartmentId(dep.ID);

            foreach(v_Deparment_Leader li in list)
            {
                lb.Text += li.LeaderName +" ";
            }
        }



        protected void ddlHeadmaster_DataBinding(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            v_Deparment_Headmaster dep = GetDataItem() as v_Deparment_Headmaster;

            List<v_Deparment_Leader> list = BLL.admin.department.DepartmentManagement.getDepartmentLeadersByDepartmentId(16);//校长室

            foreach (v_Deparment_Leader dl in list)
            {
                ListItem li = new ListItem();
                li.Value = dl.userid.ToString();
                li.Text = dl.LeaderName;
                if (dl.userid == dep.headmasterID)
                    li.Selected = true;
                ddl.Items.Add(li);
            }
        }

        protected void lbAdd_Click(object sender, EventArgs e)
        {

            PanelAddRole.Visible = true;
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            String name = tbDepartmentName.Text;

            String strRemark = tbRemark.Text;

            Department dep = new Department();
            dep.Name = name;
            dep.Description = strRemark;

            if (BLL.admin.department.DepartmentManagement.createDepartment(dep))
            {
                lbMessage.Text = "创建机构成功!";
            }
            databind();
        }

        protected void gvDepartment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String id = gvDepartment.DataKeys[e.RowIndex].Value.ToString();

            if (BLL.admin.department.DepartmentManagement.deleteDepartmentById(id))
            {
                lbMessage.Text = "删除组织成功！";
            }
            databind();
        }

        protected void gvDepartment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvDepartment.PageIndex = e.NewPageIndex;
            databind();
        }

        protected void gvDepartment_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            gvDepartment.EditIndex = -1;
            databind();
        }

        protected void gvDepartment_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String id = gvDepartment.DataKeys[e.RowIndex].Value.ToString();
            String strName = ((TextBox)gvDepartment.Rows[e.RowIndex].Cells[2].FindControl("tbDepartmentName")).Text.ToString().Trim();
            String strRemark = ((TextBox)gvDepartment.Rows[e.RowIndex].Cells[3].FindControl("tbRemark")).Text.ToString().Trim();

            String headmasterId = ((DropDownList)gvDepartment.Rows[e.RowIndex].Cells[5].FindControl("DropDownListHeadmaster")).SelectedValue;

            Department dep = BLL.admin.department.DepartmentManagement.getDepartmentById(Convert.ToInt32(id));

            dep.Name = strName;
            dep.Description = strRemark;
            dep.HeadmasterId = Convert.ToInt32(headmasterId);
            BLL.admin.department.DepartmentManagement.updateDepartment(dep);


            gvDepartment.EditIndex = -1; //将GridView控件恢复为编辑前的状态。即更新完了就得回到非编辑状态
            databind(); //更新完了之后，就得重新绑定，即重新从数据库中读取刚才更新的数据。

        }

        protected void gvDepartment_RowEditing(object sender, GridViewEditEventArgs e)
        {

            gvDepartment.EditIndex = e.NewEditIndex;
            databind();
        }
    }
}