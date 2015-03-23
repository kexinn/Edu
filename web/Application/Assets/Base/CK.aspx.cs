using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.Assets.Base
{
    public partial class CK : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PanelAddCK.Visible = false;
                databind();
            }
        }

        protected void databind()
        {
            PanelAddCK.Visible = false;
            BLL.Application.Assets.Base.CK.databind(ref gvCK, ref DropDownListClass);
        }

        protected void DropDownListClass_DataBinding(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            
            BLL.Application.Assets.Base.CK.dllClass0Databind(ref ddl);
        }

        protected void lbAdd_Click(object sender, EventArgs e)
        {
            PanelAddCK.Visible = true;
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            String name = tbName.Text.Trim();
            Int32 Class0ID = Convert.ToInt32(DropDownListClass.SelectedValue);
            String strRemark = tbRemark.Text.Trim();

            AS_Ck ck = new AS_Ck();
            ck.CkName = name;
            ck.Class0ID = Class0ID;
            ck.CkRemark = strRemark;

            if(BLL.Application.Assets.Base.CK.createCK(ck))
            {
                Response.Write("<script>alert('创建仓库成功');</script>");
                tbName.Text = "";
                tbRemark.Text = "";
                databind();
            }
        }

        protected void gvCK_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCK.PageIndex = e.NewPageIndex;
            databind();
        }

        protected void gvCK_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCK.EditIndex = -1;
            databind();
        }

        protected void gvCK_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String id = gvCK.DataKeys[e.RowIndex].Value.ToString();

            if(BLL.Application.Assets.Base.CK.deleteCKById(id))
            {
                Response.Write("<script>alert('删除仓库成功');</script>");
                databind();
            }
        }

        protected void gvCK_RowEditing(object sender, GridViewEditEventArgs e)
        {

            gvCK.EditIndex = e.NewEditIndex;
            databind();
        }

        protected void gvCK_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String id = gvCK.DataKeys[e.RowIndex].Value.ToString();
            String strName = ((TextBox)gvCK.Rows[e.RowIndex].Cells[2].FindControl("tbName")).Text.ToString().Trim();
            String Class0ID = ((DropDownList)gvCK.Rows[e.RowIndex].Cells[3].FindControl("DropDownListClass")).SelectedValue;
            String strRemark = ((TextBox)gvCK.Rows[e.RowIndex].Cells[4].FindControl("tbRemark")).Text.ToString().Trim();

            AS_Ck ck = BLL.Application.Assets.Base.CK.getCKById(Convert.ToInt32(id));

            //int managerId = -1;
            //try
            //{
            //    managerId = BLL.admin.user.UserManagement.getUsersByTruename(managerName).Single().Key;
            //}
            //catch (Exception ex) { };

            ck.CkName  = strName;
            ck.Class0ID = Convert.ToInt32(Class0ID );
            ck.CkRemark  = strRemark;

            BLL.Application.Assets.Base.CK.updateCK(ck);

            gvCK.EditIndex = -1; //将GridView控件恢复为编辑前的状态。即更新完了就得回到非编辑状态
            databind(); //更新完了之后，就得重新绑定，即重新从数据库中读取刚才更新的数据。
        }
    }
}