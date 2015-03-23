using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.Assets.Base
{
    public partial class UseQk : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PanelAddUseQk.Visible = false;
                lbMessage.Text = "";
                databind();
            }

        }

        protected void databind()
        {
            gvUseQk.DataSource = BLL.Application.Assets.Base.UseQk.GetAS_UseQk();
            gvUseQk.DataBind();
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            Int32 ID = Convert.ToInt32(this.tbID.Text);
            string Name = this.tbName.Text;
            string Remark = this.tbRemark.Text;

            AS_UseQk UseQk = new AS_UseQk();

            UseQk.UseQk_ID = ID;
            UseQk.UseQk_Name = Name;
            UseQk.UseQk_Remark = Remark;

            if (BLL.Application.Assets.Base.UseQk.createAS_UseQk(UseQk))
            {
                BLL.pub.PubClass.showAlertMessage(Page, ClientScript, "新增资产状态成功！");
                databind();
            }
            else
            {
                BLL.pub.PubClass.showAlertMessage(Page, ClientScript, "新增资产状态失败！");
            }
        }



        protected void lbAdd_Click(object sender, EventArgs e)
        {
            this.PanelAddUseQk.Visible = true;
            lbMessage.Text = "";
        }

        protected void gvUseQk_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUseQk.EditIndex = e.NewEditIndex;
            databind();
        }

        protected void gvUseQk_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string id = gvUseQk.DataKeys[e.RowIndex].Value.ToString();
                string name = ((TextBox)gvUseQk.Rows[e.RowIndex].Cells[2].FindControl("tbName")).Text.ToString().Trim();
                string remark = ((TextBox)gvUseQk.Rows[e.RowIndex].Cells[3].FindControl("tbRemark")).Text.ToString().Trim();

                AS_UseQk UseQk = BLL.Application.Assets.Base.UseQk.getAS_UseQkbyID(Convert.ToInt32(id));

                UseQk.UseQk_Name = name;
                UseQk.UseQk_Remark = remark;

                if (BLL.Application.Assets.Base.UseQk.updateUseQk(UseQk))
                {
                    lbMessage.Text = "更新成功！";
                    Response.Write("<script language=javascript>alert('更新成功！');</script>");
                    gvUseQk.EditIndex = -1;
                    databind();
                }
                else
                {
                    lbMessage.Text = "更新失败！";
                    gvUseQk.EditIndex = -1;
                }
            }
            catch
            {
                lbMessage.Text = "更新失败！";
                gvUseQk.EditIndex = -1;
            }
        }

        protected void gvUseQk_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = gvUseQk.DataKeys[e.RowIndex].Value.ToString();

            if (BLL.Application.Assets.Base.UseQk.deleteAS_UseQkbyID(id))
            {
                lbMessage.Text = "删除成功！";
                databind();
            }
            else
            {
                lbMessage.Text = "删除失败！";
            }
        }

        protected void gvUseQk_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUseQk.EditIndex = -1;
            databind();
        }

        protected void gvUseQk_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUseQk.PageIndex = e.NewPageIndex;
            databind();
        }


    }
}