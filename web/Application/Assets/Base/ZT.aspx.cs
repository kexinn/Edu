using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.Assets.Base
{
    public partial class ZT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PanelAddZT.Visible = false;
                lbMessage.Text = "";
                databind();
            }

        }

        protected void databind()
        {
            gvZT.DataSource = BLL.Application.Assets.Base.ZT.GetAS_ZT();
            gvZT.DataBind();
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            Int32 ID = Convert.ToInt32(this.tbID.Text);
            string Name = this.tbName.Text;
            string Remark = this.tbRemark.Text;

            AS_ZT ZT = new AS_ZT();

            ZT.ZT_ID = ID;
            ZT.ZT_Name = Name;
            ZT.ZT_Remark = Remark;

            if (BLL.Application.Assets.Base.ZT.createAS_ZT(ZT))
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
            this.PanelAddZT.Visible = true;
            lbMessage.Text = "";
        }

        protected void gvZT_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvZT.EditIndex = e.NewEditIndex;
            databind();
        }

        protected void gvZT_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string id = gvZT.DataKeys[e.RowIndex].Value.ToString();
                string name = ((TextBox)gvZT.Rows[e.RowIndex].Cells[2].FindControl("tbName")).Text.ToString().Trim();
                string remark = ((TextBox)gvZT.Rows[e.RowIndex].Cells[3].FindControl("tbRemark")).Text.ToString().Trim();

                AS_ZT ZT = BLL.Application.Assets.Base.ZT.getAS_ZTbyID(Convert.ToInt32(id));

                ZT.ZT_Name = name;
                ZT.ZT_Remark = remark;

                if (BLL.Application.Assets.Base.ZT.updateZT(ZT))
                {
                    lbMessage.Text = "更新成功！";
                    Response.Write("<script language=javascript>alert('更新成功！');</script>");
                    gvZT.EditIndex = -1;
                    databind();
                }
                else
                {
                    lbMessage.Text = "更新失败！";
                    gvZT.EditIndex = -1;
                }
            }
            catch
            {
                lbMessage.Text = "更新失败！";
                gvZT.EditIndex = -1;
            }
        }

        protected void gvZT_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = gvZT.DataKeys[e.RowIndex].Value.ToString();

            if (BLL.Application.Assets.Base.ZT.deleteAS_ZTbyID(id))
            {
                lbMessage.Text = "删除成功！";
                databind();
            }
            else
            {
                lbMessage.Text = "删除失败！";
            }
        }

        protected void gvZT_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvZT.EditIndex = -1;
            databind();
        }

        protected void gvZT_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvZT.PageIndex = e.NewPageIndex;
            databind();
        }

    
    
    }
}