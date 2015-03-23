using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.Assets.Zclt
{
    public partial class ZcHuan : System.Web.UI.Page
    {
        DataClassesASDataContext dc = new DataClassesASDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            AspNetPager1.PageSize = 5;

            if (!IsPostBack)
            {
                txt_ShiHuanDate.Text = DateTime.Now.ToString();

                ViewState["JieUserID"] = null;
                ViewState["JieID"] = null;
                ViewState["ZcID"] = null;
                ViewState["mode"] = "Add";

                bt_Save.Enabled = false;
                databindUseQK();    //初始化使用情况下拉列表框
            }
        }

        protected void databindUseQK()
        {
            ddl_UseQK.Items.Clear();
            var rs_useQk = dc.AS_UseQk;
            foreach (AS_UseQk r in rs_useQk)
            {
                ListItem li = new ListItem();

                li.Text = r.UseQk_Name;
                li.Value = r.UseQk_ID.ToString();
                ddl_UseQK.Items.Add(li);
            }
        }

        protected void databindGV( Int32 _JieUserID)
        {
            if (_JieUserID > 0)
            {
                AspNetPager1.RecordCount = dc.v_AS_Jie.Where(u => u.JieYongUserKey == _JieUserID).Count();

                gvJie.DataSource = dc.v_AS_Jie.Where(u => u.JieYongUserKey == _JieUserID).OrderByDescending(u => u.JieID).Skip(AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1)).Take(AspNetPager1.PageSize);
            }
            else
            {
                gvJie.DataSource = null;
            }
            gvJie.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            databindGV(Convert.ToInt32(ViewState["JieUserID"]));
        }

        protected void bt_Save_Click(object sender, EventArgs e)
        {
            if (ViewState["mode"].ToString() == "Add")
            {
                //修改保存资产状态-开始
                Int32 _ZcID = Convert.ToInt32(ViewState["ZcID"]);
                Int32 _JieUserID = Convert.ToInt32(ViewState["JieUserID"]);
                string _TXM="";

                if (_ZcID <= 0 || _JieUserID <=0)
                {
                    System.Web.UI.ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "", "alert('归还失败！')", true);
                    return;
                }

                //修改资产状态
                try
                {
                    var rs = from r in dc.AS_Zc
                             where r.ZcID == _ZcID
                             select r;

                    foreach (var r in rs)
                    {
                        if (ddl_UseQK.SelectedIndex == 0 || ddl_UseQK.SelectedIndex == 1)    //使用情况,正常或部分损坏但能使用
                        {
                            r.ZTID = 1;     //在库
                        }
                        else
                        {
                            r.ZTID = 3;    //损坏
                        }
                        _TXM = r.ZcTXM;
                    }
                    dc.SubmitChanges();
                }
                catch
                {
                    System.Web.UI.ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "", "alert('修改资产状态失败！')", true);
                    return;
                }

                //新增资产归还记录-开始
                v_AS_Jie _Jie = BLL.Application.Assets.Zclt.ZcHuan.GetVJiebyZcTXM(_TXM);
                AS_Huan _Huan = new AS_Huan();

                _Huan.ZcID = _ZcID;
                _Huan.Position1ID = _Jie.Position1ID;
                _Huan.Position2ID = _Jie.Position2ID;
                _Huan.Position3ID = _Jie.Position3ID;
                _Huan.JieDate = _Jie.JieDate;
                _Huan.YingHuanDate = _Jie.YingHuanDate;
                _Huan.JieYongtu = _Jie.JieYongtu;
                _Huan.JieOperateDate = _Jie.JieOperateDate;
                _Huan.JieYongUserKey = _Jie.JieYongUserKey;
                _Huan.JieJBRUserKey = _Jie.JieJBRUserKey;
                _Huan.ShiHuanDate=Convert.ToDateTime(txt_ShiHuanDate.Text ) ;
                _Huan.HuanUserKey = _Jie.JieYongUserKey;
                _Huan.JieJBRUserKey = 654;    //韩丹工号
                if (ddl_UseQK.SelectedIndex != -1)    //使用状态
                {
                    _Huan.UseQkID  = Convert.ToInt32(ddl_UseQK.SelectedValue);
                }
                else
                {
                    _Huan.UseQkID  = 0;
                }
                _Huan.HuanRemark = txt_HuanRemark.Text.Trim();
                _Huan.HuanOperateDate = DateTime.Now;

                if(! BLL.Application.Assets.Zclt.ZcHuan.createAS_Huan(_Huan ))
                {
                    System.Web.UI.ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "", "alert('新增归还记录失败！')", true);
                    return;
                }
                //新增资产归还记录-结束

                //删除相应出借表记录-开始
                if(BLL.Application.Assets.Zclt.ZcHuan.deleteAS_JiebyID(_Jie.JieID ))
                {
                    databindGV(Convert.ToInt32(ViewState["JieUserID"]));
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "", "alert('删除出借记录失败！')", true);
                }
                //删除相应出借表记录-结束
            }

        }

        protected void lbAdd_Click(object sender, EventArgs e)
        {
            bt_Save.Enabled = false;
            ViewState["mode"] = "Add";
        }

        protected void gvJie_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvJie.EditIndex = e.NewEditIndex;
            databindGV(Convert.ToInt32(ViewState["JieUserID"]));
        }

        //protected void gvJie_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    try
        //    {
        //        string id = gvJie.DataKeys[e.RowIndex].Value.ToString();
        //        string name = ((TextBox)gvJie.Rows[e.RowIndex].Cells[2].FindControl("tbName")).Text.ToString().Trim();
        //        string remark = ((TextBox)gvJie.Rows[e.RowIndex].Cells[3].FindControl("tbRemark")).Text.ToString().Trim();

        //        AS_DW dw = BLL.Application.Assets.Base.DW.getAS_DWbyID(Convert.ToInt32(id));

        //        dw.DW_Name = name;
        //        dw.DW_Remark = remark;

        //        if (BLL.Application.Assets.Base.DW.updateDW(dw))
        //        {
        //            lbMessage.Text = "更新成功！";
        //            Response.Write("<script language=javascript>alert('更新成功！');</script>");
        //            gvJie.EditIndex = -1;
        //            databindGV(Convert.ToInt32(ViewState["JieUserID"]));
        //        }
        //        else
        //        {
        //            lbMessage.Text = "更新失败！";
        //            gvJie.EditIndex = -1;
        //        }
        //    }
        //    catch
        //    {
        //        lbMessage.Text = "更新失败！";
        //        gvJie.EditIndex = -1;
        //    }
        //}

        //protected void gvJie_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    string id = gvJie.DataKeys[e.RowIndex].Value.ToString();

        //    if (BLL.Application.Assets.lkgl.Zcdj.deleteAS_ZCbyID(id))
        //    {
        //        lbMessage.Text = "删除成功！";
        //        databindGV(Convert.ToInt32(ViewState["JieUserID"]));
        //    }
        //    else
        //    {
        //        lbMessage.Text = "删除失败！";
        //    }
        //}

        //protected void gvJie_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    gvJie.EditIndex = -1;
        //    databindGV(Convert.ToInt32(ViewState["JieUserID"]));
        //}

        //protected void gvJie_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvJie.PageIndex = e.NewPageIndex;
        //    databindGV(Convert.ToInt32(ViewState["JieUserID"]));
        //}


        protected void gvJie_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sel")
            {
                string _ZcTXM = e.CommandArgument.ToString();

                search_Jie(_ZcTXM);
            }
        }

        protected void lbn_SearchUser_Click(object sender, EventArgs e)
        {
            string _UserName = txt_UserName.Text.Trim();

            Int32  _JieUserID = BLL.Application.Assets.Zclt.ZcJie.GetUserIDbyUserName(_UserName);
            if (_JieUserID > 0)
            {
                ViewState["JieUserID"] = _JieUserID;
                databindGV(_JieUserID);
            }
            else
            {
                ViewState["JieUserID"] = null;
                System.Web.UI.ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "", "alert('查无此人！')", true);
            }
        }

        protected void lbn_SearchZc_Click(object sender, EventArgs e)
        {
            string _ZcTXM = txt_ZcTXM.Text.Trim();

            search_Jie(_ZcTXM);
        }

        protected void search_Jie( string _ZcTXM)
        {
            v_AS_Jie _VJie = BLL.Application.Assets.Zclt.ZcHuan.GetVJiebyZcTXM(_ZcTXM);

            show_Jie(_VJie);

            if (_VJie  != null)
            {
                ViewState["JieUserID"] = _VJie.JieYongUserKey.ToString();
            }
            else
            {
                ViewState["JieUserID"] = null;
                System.Web.UI.ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "" , "alert('此资产 [" + _ZcTXM + " ]无出借！')", true); 
            }

            databindGV(Convert.ToInt32(ViewState["JieUserID"]));
        }
        protected void show_Jie(v_AS_Jie _VJie)
        {
            if (_VJie != null)
            {
                txt_ZcTXM.Text = _VJie.ZcTXM.ToString();
                txt_Name.Text = _VJie.ZcName.ToString();
                txt_Type.Text = _VJie.ZcType.ToString();
                txt_UserName.Text = _VJie.TrueName.ToString();
                txt_JieDate.Text = _VJie.JieDate.ToString();
                txt_YingHuanDate.Text = _VJie.YingHuanDate.ToString();

                ViewState["ZcID"] = _VJie.ZcID.ToString();
                ViewState["JieID"] = _VJie.JieID.ToString();

                bt_Save.Enabled = true;
            }
            else
            {
                //txt_ZcTXM.Text = "";
                txt_Name.Text = "";
                txt_Type.Text = "";
                txt_UserName.Text = "";
                txt_JieDate.Text = "";
                txt_YingHuanDate.Text ="";

                ViewState["ZcID"] = null;
                ViewState["JieID"] = null;

                bt_Save.Enabled = false;
            }
        }

        protected void txt_ZcTXM_TextChanged(object sender, EventArgs e)
        {
            string _ZcTXM = txt_ZcTXM.Text.Trim();

            if (_ZcTXM.Length == 12)
            {
                search_Jie(_ZcTXM);
            }
        }
    }
}