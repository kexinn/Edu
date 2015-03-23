using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.Assets.Lkgl
{
    public partial class Zcrk : System.Web.UI.Page
    {
        static string mode;
        //static Int32 ID;
        static string _oldTXM;
        

        DataClassesASDataContext dc = new DataClassesASDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            AspNetPager1.PageSize = 10;

            if (!IsPostBack)
            {

                this.PanelAddZC.Visible = false;
                lbMessage.Text = "";


                databindDDL_Class0();
                if (ddl_Class0.Items.Count > 0)
                {
                    ddl_Class0.SelectedIndex = 0;
                    databindDDL_Class1();
                }

                if (ddl_Class1.Items.Count > 0)
                {
                    ddl_Class1.SelectedIndex = 0;
                    databindDDL_Class2();
                }

                if (ddl_Class2.Items.Count > 0)
                {
                    ddl_Class2.SelectedIndex = 0;
                    databindDDL_Class3();
                }

                if (ddl_Class3.Items.Count > 0)
                {
                    ddl_Class3.SelectedIndex = 0;
                }

                databindDW();    //初始化单位下拉列表框
                databindCK();    //初始化仓库下拉列表框
                databindZT();    //初始化资产状态
                databindGV();
                mode = "Add";
                bt_Save.Enabled = false;

                String url = "/Application/Assets/LKgl/Zcdj.aspx?popup=Yes";
                String click = "window.open('" + url + "','Sample','toolbar=no,location=no,directories=no,status=no,menubar=yes,scrollbars=yes,resizable=yes,copyhistory=yes,width=950,height=500,left=100,top=100');return false;";
                ibt_Search.Attributes.Add("onclick", click);
            }
        }

        protected void databindZT()   //初始化资产状态
        {
            //ddl_ZT.Items.Clear();
            //ddl_ZT.Items.Add(new ListItem("未入库", "0"));
            //ddl_ZT.Items.Add(new ListItem("在库", "1"));
            //ddl_ZT.Items.Add(new ListItem("出借", "2"));
            //ddl_ZT.Items.Add(new ListItem("损坏", "3"));
            //ddl_ZT.Items.Add(new ListItem("在修", "4"));
            //ddl_ZT.Items.Add(new ListItem("报废", "5"));

            ddl_ZT.Items.Clear();

            var rs_zt = dc.AS_ZT;

            foreach (AS_ZT r in rs_zt)
            {
                ListItem li = new ListItem();
                li.Text = r.ZT_Name;
                li.Value = r.ZT_ID.ToString();
                ddl_ZT.Items.Add(li);
            }

        }
        protected void databindCK()
        {
            ddl_CK.Items.Clear();

            var rs_ck = dc.AS_Ck;

            foreach (AS_Ck r in rs_ck)
            {
                ListItem li = new ListItem();

                li.Text = r.CkName;
                li.Value = r.CkID.ToString();
                ddl_CK.Items.Add(li);
            }
        }
        protected void databindDW()
        {
            ddl_DW.Items.Clear();

            var rs_dw = dc.AS_DW;

            foreach (AS_DW r in rs_dw)
            {
                ListItem li = new ListItem();
                li.Text = r.DW_Name;
                li.Value = r.DW_ID.ToString();
                ddl_DW.Items.Add(li);
            }
        }
        protected void databindDDL_Class0()
        {
            var rs_class0 = dc.AS_Class0;

            ddl_Class0.Items.Clear();
            ddl_Class1.Items.Clear();
            ddl_Class2.Items.Clear();
            ddl_Class3.Items.Clear();

            foreach (AS_Class0 r in rs_class0)
            {
                ListItem li = new ListItem();
                li.Text = r.Class0Name;
                li.Value = r.Class0ID.ToString() + "," + r.Class0BH;
                ddl_Class0.Items.Add(li);
            }
        }

        protected void databindDDL_Class1()
        {
            string _st = ddl_Class0.SelectedValue;

            Int32 n = _st.IndexOf(",");
            Int32 _Class0ID = Convert.ToInt32(_st.Substring(0, n));
            string _Class0BH = _st.Substring(n + 1, _st.Length - (n + 1));

            var rs_Class1 = dc.AS_Class1.Where(u => u.Class0ID == _Class0ID);

            ddl_Class1.Items.Clear();
            ddl_Class2.Items.Clear();
            ddl_Class3.Items.Clear();

            foreach (AS_Class1 r in rs_Class1)
            {
                ListItem li = new ListItem();

                li.Text = r.Class1Name;
                li.Value = r.Class1ID.ToString() + "," + r.Class1BH;
                ddl_Class1.Items.Add(li);
            }
        }

        protected void databindDDL_Class2()
        {
            string _st = ddl_Class1.SelectedValue;

            ddl_Class2.Items.Clear();
            ddl_Class3.Items.Clear();

            Int32 n = _st.IndexOf(",");
            Int32 _Class1ID = Convert.ToInt32(_st.Substring(0, n));
            string _Class1BH = _st.Substring(n + 1, _st.Length - (n + 1));

            var rs_Class2 = dc.AS_Class2.Where(u => u.Class1ID == _Class1ID);

            foreach (AS_Class2 r in rs_Class2)
            {
                ListItem li = new ListItem();

                li.Text = r.Class2Name;
                li.Value = r.Class2ID.ToString() + "," + r.Class2BH;
                ddl_Class2.Items.Add(li);
            }
        }

        protected void databindDDL_Class3()
        {
            string _st = ddl_Class2.SelectedValue;

            Int32 n = _st.IndexOf(",");
            Int32 _Class2ID = Convert.ToInt32(_st.Substring(0, n));
            string _Class2BH = _st.Substring(n + 1, _st.Length - (n + 1));

            ddl_Class3.Items.Clear();

            var rs_Class3 = dc.AS_Class3.Where(u => u.Class2ID == _Class2ID);

            foreach (AS_Class3 r in rs_Class3)
            {
                ListItem li = new ListItem();

                li.Text = r.Class3Name;
                li.Value = r.Class3ID.ToString() + "," + r.Class3BH;
                ddl_Class3.Items.Add(li);
            }
        }

        protected void databindGV()
        {
            //gvZC.DataSource=BLL.Application.Assets.lkgl.Zcdj.GetAS_Zc() ;

            AspNetPager1.RecordCount = dc.v_AS_ZC.Count();

            gvZC.DataSource = dc.v_AS_ZC.OrderByDescending(u => u.ZcID).Skip(AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1)).Take(AspNetPager1.PageSize);

            gvZC.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            databindGV();
        }

        protected void bt_Save_Click(object sender, EventArgs e)
        {
            string _st;
            string _Class0BH, _Class1BH, _Class2BH, _Class3BH;
            Int32 n;


            //分类编号处理-开始
            if (ddl_Class0.SelectedIndex >= 0)    //分类Class0BH
            {
                _st = ddl_Class0.SelectedValue;
                n = _st.IndexOf(",");
                _Class0BH = _st.Substring(n + 1, _st.Length - (n + 1));
            }
            else
            {
                _Class0BH = "00";
            }


            if (ddl_Class1.SelectedIndex >= 0)    //分类Class1BH
            {
                _st = ddl_Class1.SelectedValue;
                n = _st.IndexOf(",");
                _Class1BH = _st.Substring(n + 1, _st.Length - (n + 1));
            }
            else
            {
                _Class1BH = "00";
            }


            if (ddl_Class2.SelectedIndex >= 0)    //分类Class2BH
            {
                _st = ddl_Class2.SelectedValue;
                n = _st.IndexOf(",");
                _Class2BH = _st.Substring(n + 1, _st.Length - (n + 1));
            }
            else
            {
                _Class2BH = "00";
            }


            if (ddl_Class3.SelectedIndex >= 0)    //分类Class3BH
            {
                _st = ddl_Class3.SelectedValue;
                n = _st.IndexOf(",");
                _Class3BH = _st.Substring(n + 1, _st.Length - (n + 1));
            }
            else
            {
                _Class3BH = "00";
            }
            //分类编号处理-结束

            //条形码编号处理-开始
            string _TXM;
            if (txt_TXM.Text.Trim().Length == 0)
            {
                _TXM = _Class0BH + _Class1BH + _Class2BH + _Class3BH;

                var aa = dc.AS_Zc.Where(u => u.ZcTXM.Substring(0, 8) == _TXM).OrderByDescending(o => o.ZcTXM);
                if (aa.Count() > 0)
                {
                    string num = aa.Take(1).Single().ZcTXM.Substring(8);
                    _TXM += (Convert.ToInt32(num) + 1).ToString("0000");
                }
                else
                {
                    _TXM += "0001";
                }
            }
            else
            {
                _TXM = txt_TXM.Text.Trim();
            }
            //条形码编号处理-结束

            //条形码唯一性判断
            Int32 _oldNum = dc.AS_Zc.Where(u => u.ZcTXM == _TXM).Count();

            string _Name = txt_Name.Text.Trim();
            string _Type = txt_Type.Text.Trim();
            string _Remark = txt_Remark.Text.Trim();

            Int32 _CKID;
            if (ddl_CK.SelectedIndex != -1)
            {
                _CKID = Convert.ToInt32(ddl_CK.SelectedValue);
            }
            else
            {
                _CKID = 0;
            }

            Int32 _ZTID;
            if (ddl_ZT.SelectedIndex != -1)
            {
                _ZTID = Convert.ToInt32(ddl_ZT.SelectedValue);
            }
            else
            {
                _ZTID = 0;
            }

            if ((mode == "Add") && ( ViewState["ZcDjID"] != null ))
            {
                AS_Zc _Zc = new AS_Zc();

                _Zc.ZcDjID = Convert.ToInt32(ViewState["ZcDjID"]);
                _Zc.ZcTXM = _TXM;
                _Zc.CKID = _CKID;
                _Zc.ZTID = _ZTID;
                _Zc.ZcRkDate = Convert.ToDateTime(txt_RkDate.Text);
                _Zc.ZcRkUserKey = 654;    //韩丹工号
                _Zc.ZcRemark = _Remark;
                _Zc.ZcOperateDate = DateTime.Now;

                if (_oldNum > 0)
                {
                    BLL.pub.PubClass.showAlertMessage(Page, ClientScript, "条码编号有重复！");
                    return;
                }

                if (BLL.Application.Assets.lkgl.Zcrk.createAS_Zc(_Zc))
                {
                    BLL.pub.PubClass.showAlertMessage(Page, ClientScript, "新增资产成功！");
                    databindGV();
                }
                else
                {
                    BLL.pub.PubClass.showAlertMessage(Page, ClientScript, "新增资产失败！");
                }
            }

            if (mode == "Edit")
            {
                if ((txt_TXM.Text.Trim() == _oldTXM && _oldNum == 1) || (txt_TXM.Text.Trim() != _oldTXM && _oldNum == 0))
                {
                    var rs = from r in dc.AS_Zc
                             where r.ZcID == Convert.ToInt32(ViewState["ZcID"])
                             select r;

                    foreach (var r in rs)
                    {
                        r.ZcDjID = Convert.ToInt32(ViewState["ZcDjID"]);
                        r.ZcTXM = txt_TXM.Text.Trim();
                        r.CKID = _CKID;
                        r.ZTID = _ZTID;
                        r.ZcRkDate = Convert.ToDateTime(txt_RkDate.Text);
                        r.ZcRkUserKey = 654;    //韩丹工号
                        r.ZcRemark = _Remark;
                        r.ZcOperateDate = DateTime.Now;
                    };

                    dc.SubmitChanges();
                    databindGV();
                }
                else
                {
                    BLL.pub.PubClass.showAlertMessage(Page, ClientScript, "条码编号有重复！");
                    return;
                }
            }
        }

        protected void lbAdd_Click(object sender, EventArgs e)
        {
            this.PanelAddZC.Visible = true;
            txt_TXM.Text = "";
            txt_RkDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            ddl_ZT.SelectedIndex = 1;
            bt_Save.Enabled = false;
            mode = "Add";
            lbMessage.Text = "";
        }

        protected void gvZC_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvZC.EditIndex = e.NewEditIndex;
            databindGV();
        }

        protected void gvZC_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string id = gvZC.DataKeys[e.RowIndex].Value.ToString();
                string name = ((TextBox)gvZC.Rows[e.RowIndex].Cells[2].FindControl("tbName")).Text.ToString().Trim();
                string remark = ((TextBox)gvZC.Rows[e.RowIndex].Cells[3].FindControl("tbRemark")).Text.ToString().Trim();

                AS_DW dw = BLL.Application.Assets.Base.DW.getAS_DWbyID(Convert.ToInt32(id));

                dw.DW_Name = name;
                dw.DW_Remark = remark;

                if (BLL.Application.Assets.Base.DW.updateDW(dw))
                {
                    lbMessage.Text = "更新成功！";
                    Response.Write("<script language=javascript>alert('更新成功！');</script>");
                    gvZC.EditIndex = -1;
                    databindGV();
                }
                else
                {
                    lbMessage.Text = "更新失败！";
                    gvZC.EditIndex = -1;
                }
            }
            catch
            {
                lbMessage.Text = "更新失败！";
                gvZC.EditIndex = -1;
            }
        }

        protected void gvZC_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = gvZC.DataKeys[e.RowIndex].Value.ToString();

            if (BLL.Application.Assets.lkgl.Zcdj.deleteAS_ZCbyID(id))
            {
                lbMessage.Text = "删除成功！";
                databindGV();
            }
            else
            {
                lbMessage.Text = "删除失败！";
            }
        }

        protected void gvZC_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvZC.EditIndex = -1;
            databindGV();
        }

        protected void gvZC_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvZC.PageIndex = e.NewPageIndex;
            databindGV();
        }

        protected void ddl_Class0_SelectedIndexChanged(object sender, EventArgs e)
        {
            databindDDL_Class1();
        }

        protected void ddl_Class1_SelectedIndexChanged(object sender, EventArgs e)
        {
            databindDDL_Class2();
        }

        protected void ddl_Class2_SelectedIndexChanged(object sender, EventArgs e)
        {
            databindDDL_Class3();
        }

        protected void ddl_ZT_DataBinding(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;

            BLL.Application.Assets.Base.CK.dllClass0Databind(ref ddl);
        }

        protected void gvZC_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Int32 ZcID;
            ViewState["ZcID"] = e.CommandArgument;

            ZcID = Convert.ToInt32(ViewState["ZcID"]);

            if (e.CommandName == "del")
            {
                try
                {
                    var rs = from r in dc.AS_Zc
                             where r.ZcID == ZcID
                             select r;

                    foreach (var r in rs)
                    {
                        dc.AS_Zc.DeleteOnSubmit(r);
                        dc.SubmitChanges();
                    }
                    databindGV();
                    lbMessage.Text = "删除成功！";
                }
                catch
                {
                    lbMessage.Text = "删除未成功！";
                }
                bt_Save.Enabled = false;

            }

            //"ed"---开始
            if (e.CommandName == "ed")
            {
                var rs = from r in dc.v_AS_ZC
                         where r.ZcID == ZcID
                         select r;

                if (rs.Count() == 1)
                {
                    ViewState["ZcDjID"] = rs.Single().ZcDjID  ;
                    bt_Save.Enabled = true;
                }
                else
                {
                    ViewState["ZcDjID"] = null;
                    lbMessage.Text = "编辑有误！";
                    bt_Save.Enabled = false;
                    return;
                }

                foreach (var r in rs)
                {
                    lbl_ID.Text = r.ZcID.ToString();
                    txt_Name.Text = r.ZcName;
                    txt_Type.Text = r.ZcType;
                    txt_TXM.Text = r.ZcTXM;
                    txt_Sl.Text = r.ZcSl.ToString();
                    txt_Jg.Text = r.ZcJg.ToString();
                    txt_RkDate.Text = r.ZcRkDate.ToString();
                    txt_Remark.Text = r.ZcRemark.ToString();

                    ddl_Class0.Items.Clear();
                    ddl_Class1.Items.Clear();
                    ddl_Class2.Items.Clear();
                    ddl_Class3.Items.Clear();

                    //下拉列表框处理--开始
                    databindDDL_Class0();

                    if (ddl_Class0.Items.Count > 0)
                    {
                        try
                        {
                            var rs_class0 = dc.AS_Class0.Where(u => u.Class0BH == r.Class0BH.ToString()).Single();

                            ddl_Class0.SelectedValue = rs_class0.Class0ID.ToString() + "," + r.Class0BH;
                            databindDDL_Class1();
                        }
                        catch
                        {
                        }
                    }

                    if (ddl_Class1.Items.Count > 0)
                    {
                        try
                        {
                            string _st = ddl_Class0.SelectedValue;

                            Int32 n = _st.IndexOf(",");
                            Int32 _Class0ID = Convert.ToInt32(_st.Substring(0, n));
                            //string _Class0BH = _st.Substring(n + 1, _st.Length - (n + 1));
                            string _Class1BH = r.Class1BH;

                            var rs_Class1 = dc.AS_Class1.Where(u => u.Class0ID == _Class0ID && u.Class1BH == _Class1BH).Single();
                            ddl_Class1.SelectedValue = rs_Class1.Class1ID.ToString() + "," + r.Class1BH;

                            databindDDL_Class2();
                        }
                        catch
                        {

                        }
                    }

                    if (ddl_Class2.Items.Count > 0)
                    {
                        try
                        {
                            string _st = ddl_Class1.SelectedValue;

                            Int32 n = _st.IndexOf(",");
                            Int32 _Class1ID = Convert.ToInt32(_st.Substring(0, n));
                            //string _Class0BH = _st.Substring(n + 1, _st.Length - (n + 1));
                            string _Class2BH = r.Class2BH;

                            var rs_Class2 = dc.AS_Class2.Where(u => u.Class1ID == _Class1ID && u.Class2BH == _Class2BH).Single();
                            ddl_Class2.SelectedValue = rs_Class2.Class2ID.ToString() + "," + r.Class2BH;

                            databindDDL_Class3();
                        }
                        catch
                        {

                        }
                    }

                    if (ddl_Class3.Items.Count > 0)
                    {
                        try
                        {
                            string _st = ddl_Class2.SelectedValue;

                            Int32 n = _st.IndexOf(",");
                            Int32 _Class2ID = Convert.ToInt32(_st.Substring(0, n));
                            //string _Class0BH = _st.Substring(n + 1, _st.Length - (n + 1));
                            string _Class3BH = r.Class3BH;

                            var rs_Class3 = dc.AS_Class3.Where(u => u.Class2ID == _Class2ID && u.Class3BH == _Class3BH).Single();
                            ddl_Class3.SelectedValue = rs_Class3.Class3ID.ToString() + "," + r.Class3BH;
                        }
                        catch
                        {

                        }
                    }
                    //下拉列表框处理--结束

                    _oldTXM = r.ZcTXM;

                    databindDW();    //初始化单位下拉列表框
                    ddl_DW.SelectedValue = r.DWID.ToString();

                    databindCK();    //初始化仓库下拉列表框
                    ddl_CK.SelectedValue = r.CKID.ToString();

                    databindZT();    //初始化资产状态
                    ddl_ZT.SelectedValue = r.ZTID.ToString();

                }

                mode = "Edit";
                PanelAddZC.Visible = true;
            }
            //"ed"---结束


        }

        protected void ibt_Refresh_Click(object sender, ImageClickEventArgs e)
        {
            ViewState["ZcDjID"] = txt_ZcDjID.Text.Trim();
        
            var rs = from r in dc.AS_ZcDj
                             where r.ZcDjID == Convert.ToInt32(ViewState["ZcDjID"])
                             select r;
            if (rs.Count() == 1)
            {
                foreach (var r in rs)
                {
                    txt_Name.Text = r.ZcName;
                    txt_Type.Text = r.ZcType;
                    txt_Sl.Text = r.ZcSl.ToString();
                    txt_Jg.Text = r.ZcJg.ToString();

                    ddl_Class0.Items.Clear();
                    ddl_Class1.Items.Clear();
                    ddl_Class2.Items.Clear();
                    ddl_Class3.Items.Clear();

                    //下拉列表框处理--开始
                    databindDDL_Class0();

                    if (ddl_Class0.Items.Count > 0)
                    {
                        try
                        {
                            var rs_class0 = dc.AS_Class0.Where(u => u.Class0BH == r.Class0BH.ToString()).Single();

                            ddl_Class0.SelectedValue = rs_class0.Class0ID.ToString() + "," + r.Class0BH;
                            databindDDL_Class1();
                        }
                        catch
                        {
                        }
                    }

                    if (ddl_Class1.Items.Count > 0)
                    {
                        try
                        {
                            string _st = ddl_Class0.SelectedValue;

                            Int32 n = _st.IndexOf(",");
                            Int32 _Class0ID = Convert.ToInt32(_st.Substring(0, n));
                            //string _Class0BH = _st.Substring(n + 1, _st.Length - (n + 1));
                            string _Class1BH = r.Class1BH;

                            var rs_Class1 = dc.AS_Class1.Where(u => u.Class0ID == _Class0ID && u.Class1BH == _Class1BH).Single();
                            ddl_Class1.SelectedValue = rs_Class1.Class1ID.ToString() + "," + r.Class1BH;

                            databindDDL_Class2();
                        }
                        catch
                        {

                        }
                    }

                    if (ddl_Class2.Items.Count > 0)
                    {
                        try
                        {
                            string _st = ddl_Class1.SelectedValue;

                            Int32 n = _st.IndexOf(",");
                            Int32 _Class1ID = Convert.ToInt32(_st.Substring(0, n));
                            //string _Class0BH = _st.Substring(n + 1, _st.Length - (n + 1));
                            string _Class2BH = r.Class2BH;

                            var rs_Class2 = dc.AS_Class2.Where(u => u.Class1ID == _Class1ID && u.Class2BH == _Class2BH).Single();
                            ddl_Class2.SelectedValue = rs_Class2.Class2ID.ToString() + "," + r.Class2BH;

                            databindDDL_Class3();
                        }
                        catch
                        {

                        }
                    }

                    if (ddl_Class3.Items.Count > 0)
                    {
                        try
                        {
                            string _st = ddl_Class2.SelectedValue;

                            Int32 n = _st.IndexOf(",");
                            Int32 _Class2ID = Convert.ToInt32(_st.Substring(0, n));
                            //string _Class0BH = _st.Substring(n + 1, _st.Length - (n + 1));
                            string _Class3BH = r.Class3BH;

                            var rs_Class3 = dc.AS_Class3.Where(u => u.Class2ID == _Class2ID && u.Class3BH == _Class3BH).Single();
                            ddl_Class3.SelectedValue = rs_Class3.Class3ID.ToString() + "," + r.Class3BH;
                        }
                        catch
                        {

                        }
                    }
                    //下拉列表框处理--结束

                    databindDW();    //初始化单位下拉列表框
                    ddl_DW.SelectedValue = r.DWID.ToString();
                }
                bt_Save.Enabled = true;
            }
            else
            {
                lbMessage.Text = "资产登记ID有误！";
                ViewState["ZcDjID"] = null;
                bt_Save.Enabled = false;
            }
        }


    }
}