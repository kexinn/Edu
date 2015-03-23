using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.Assets.Base
{
    public partial class DW : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PanelAddDW.Visible = false;
                lbMessage.Text = "";
                databind();
            }
        }

        protected void databind()
        {
            gvDW.DataSource = BLL.Application.Assets.Base.DW.GetAS_DW();
            gvDW.DataBind();
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            Int32  ID = Convert.ToInt32(this.tbID.Text);
            string Name = this.tbName.Text;
            string Remark = this.tbRemark.Text;

            AS_DW dw = new AS_DW();

            dw.DW_ID = ID;
            dw.DW_Name = Name;
            dw.DW_Remark = Remark;

            if (BLL.Application.Assets.Base.DW.createAS_DW(dw))
            {
                BLL.pub.PubClass.showAlertMessage(Page, ClientScript, "新增度量单位成功！");
                databind();
            }
            else
            {
                BLL.pub.PubClass.showAlertMessage(Page, ClientScript, "新增度量单位失败！");
            }
        }



        protected void lbAdd_Click(object sender, EventArgs e)
        {
            this.PanelAddDW.Visible = true;
            lbMessage.Text = "";
        }

        protected void gvDW_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvDW.EditIndex=e.NewEditIndex  ;
            databind();
        }

        protected void gvDW_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string id = gvDW.DataKeys[e.RowIndex].Value.ToString();
                string name = ((TextBox)gvDW.Rows[e.RowIndex].Cells[2].FindControl("tbName")).Text.ToString().Trim();
                string remark = ((TextBox)gvDW.Rows[e.RowIndex].Cells[3].FindControl("tbRemark")).Text.ToString().Trim();

                AS_DW dw = BLL.Application.Assets.Base.DW.getAS_DWbyID(Convert.ToInt32(id));

                dw.DW_Name = name;
                dw.DW_Remark = remark;

                if (BLL.Application.Assets.Base.DW.updateDW(dw))
                {
                    lbMessage.Text = "更新成功！";
                    Response.Write("<script language=javascript>alert('更新成功！');</script>");
                    gvDW.EditIndex = -1;
                    databind();
                }
                else
                {
                    lbMessage.Text = "更新失败！";
                    gvDW.EditIndex = -1;
                }
            }
            catch
            {
                lbMessage.Text = "更新失败！";
                gvDW.EditIndex = -1;
            }
        }

        protected void gvDW_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = gvDW.DataKeys[e.RowIndex].Value.ToString();

            if(BLL.Application.Assets.Base.DW.deleteAS_DWbyID(id)){
                lbMessage.Text = "删除成功！";
                databind();
            }
            else{
                lbMessage.Text = "删除失败！";
            }
        }

        protected void gvDW_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvDW.EditIndex = -1;
            databind();
        }

        protected void gvDW_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDW.PageIndex = e.NewPageIndex;
            databind();
        }
    }
}