using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.admin.Sys
{
    public partial class SysManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PanelAddSys.Visible = false;
                databind();
            }
        }

        protected void databind()
        {
            gvSys.DataSource =   BLL.admin.sys.SysManage.databind();
            gvSys.DataBind();
        }

        protected void lbAdd_Click(object sender, EventArgs e)
        {
            PanelAddSys.Visible = true;
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            BLL.admin.sys.SysManage.intsert(tbName.Text, tbRemark.Text);
            databind();
        }

        protected void gvSys_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String id = gvSys.DataKeys[e.RowIndex].Value.ToString();

            BLL.admin.sys.SysManage.delete(Convert.ToInt32(id));
            databind();
        }

        protected void gvSys_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvSys.EditIndex = e.NewEditIndex;
            databind();
        }

        protected void gvSys_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String id = gvSys.DataKeys[e.RowIndex].Value.ToString();
            String name = ((TextBox)gvSys.Rows[e.RowIndex].Cells[1].FindControl("tbName")).Text.ToString().Trim();
            String remark = ((TextBox)gvSys.Rows[e.RowIndex].Cells[2].FindControl("tbRemark")).Text.ToString().Trim();
            t_Sys sys = new t_Sys();
            sys.Id = Convert.ToInt32(id);
            sys.name = name;
            sys.remark = remark;
            BLL.admin.sys.SysManage.update(sys);
            gvSys.EditIndex = -1;
            databind();
            
        }

        protected void gvSys_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvSys.EditIndex = -1;
            databind();
        }
    }
}