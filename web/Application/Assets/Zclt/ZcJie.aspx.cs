using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.Assets.Zclt
{
    public partial class ZcJie : System.Web.UI.Page
    {
        DataClassesASDataContext dc = new DataClassesASDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            AspNetPager1.PageSize = 5;

            if (!IsPostBack)
            {

                PanelAddZC.Visible = true;
                PanelJie.Visible = true ;
                lbMessage.Text = "";
                txt_JieDate.Text = DateTime.Now.ToString();
                ViewState["JieUserID"] = null;
                ViewState["JieID"] = null;
                ViewState["ZcID"] = null;
                ViewState["mode"] = "Add";
                ViewState["ZcTXM"] = null;
                ViewState["oldTXM"] = null;


                databindDDL_Position1();
                if (ddl_Position1.Items.Count > 0)
                {
                    ddl_Position1.SelectedIndex = 0;
                    databindDDL_Position2();
                }

                if (ddl_Position2.Items.Count > 0)
                {
                    ddl_Position2.SelectedIndex = 0;
                    databindDDL_Position3();
                }

                chk_bt_Save();
            }
        }

        protected void lbAdd_Click(object sender, EventArgs e)
        {
            bt_Save.Enabled = false;
            ViewState["mode"] = "Add";
            lbMessage.Text = "";
        }

        protected void chk_bt_Save()
        {
            if ((ViewState["JieUserID"] != null) && (ViewState["ZcID"] != null))
            {
                bt_Save.Enabled = true;
            }
            else
            {
                bt_Save.Enabled = false;
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

        protected void databindDDL_Position1()
        {
            var rs_Position1 = dc.AS_Position1 ;

            ddl_Position1.Items.Clear();
            ddl_Position2.Items.Clear();
            ddl_Position3.Items.Clear();

            foreach (AS_Position1  r in rs_Position1)
            {
                ListItem li = new ListItem();
                li.Text = r.Position1Name ;
                li.Value = r.Position1ID.ToString();
                ddl_Position1.Items.Add(li);
            }
        }

        protected void databindDDL_Position2()
        {
            Int32 _Position1ID = Convert.ToInt32(ddl_Position1.SelectedValue );

            var rs_Position2 = dc.AS_Position2.Where(u => u.Position1ID  == _Position1ID );

            ddl_Position2.Items.Clear();
            ddl_Position3.Items.Clear();

            foreach (AS_Position2 r in rs_Position2)
            {
                ListItem li = new ListItem();

                li.Text = r.Position2Name ;
                li.Value = r.Position2ID.ToString();
                ddl_Position2.Items.Add(li);
            }
        }

        protected void databindDDL_Position3()
        {
            Int32 _Position2ID = Convert.ToInt32(ddl_Position2.SelectedValue);

            var rs_Position3 = dc.AS_Position3.Where(u => u.Position2ID == _Position2ID);

            ddl_Position3.Items.Clear();

            foreach (AS_Position3 r in rs_Position3)
            {
                ListItem li = new ListItem();

                li.Text = r.Position3Name;
                li.Value = r.Position3ID.ToString();
                ddl_Position3.Items.Add(li);
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
            //gvJie.DataSource=BLL.Application.Assets.lkgl.Zcdj.GetAS_Zc() ;

            AspNetPager1.RecordCount = dc.v_AS_Jie.Where(u => u.JieYongUserKey == Convert.ToInt32(ViewState["JieUserID"] ) ).Count() ;

            //gvJie.DataSource = dc.v_AS_ZC.OrderByDescending(u => u.ZcID).Skip(AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1)).Take(AspNetPager1.PageSize);
            gvJie.DataSource = dc.v_AS_Jie.Where(u => u.JieYongUserKey == Convert.ToInt32(ViewState["JieUserID"])).OrderByDescending(u => u.JieID).Skip(AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1)).Take(AspNetPager1.PageSize);

            gvJie.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            databindGV();
        }

        protected void bt_Save_Click(object sender, EventArgs e)
        {

            Int32 _Position1ID, _Position2ID, _Position3ID;

            //使用地点处理-开始
            if (ddl_Position1.SelectedIndex != -1)    //使用地点1-楼
            {
                _Position1ID = Convert.ToInt32(ddl_Position1.SelectedValue );
            }
            else
            {
                _Position1ID = 0;
            }

            if (ddl_Position2.SelectedIndex != -1)    //使用地点2-层
            {
                _Position2ID = Convert.ToInt32(ddl_Position2.SelectedValue);
            }
            else
            {
                _Position2ID = 0;
            }

            if (ddl_Position3.SelectedIndex != -1)    //使用地点3-室
            {
                _Position3ID = Convert.ToInt32(ddl_Position3.SelectedValue);
            }
            else
            {
                _Position3ID = 0;
            }
            //使用地点处理-结束

            if ( ViewState["mode"].ToString() == "Add")
            {

                if (ViewState["ZcID"] == null )
                {
                    lbMessage.Text = "请确认有效资产！";
                    return;
                }

                if (ViewState["JieUserID"] == null)
                {
                    lbMessage.Text = "请确认正确的借用人！";
                    return;
                }

                Int32 _ZcZTID = BLL.Application.Assets.Zclt.ZcJie.GetZcZTIDbyZcID(Convert.ToInt32(ViewState["ZcID"]));
                if (_ZcZTID == 1)
                {
                    PanelJie.Visible = true;
                }
                else
                {
                    lbMessage.Text = "此资产非【在库】，无法出借！";
                    return;
                }

                try
                {
                    AS_Jie _Jie = new AS_Jie();

                    _Jie.ZcID = Convert.ToInt32(ViewState["ZcID"]);
                    _Jie.Position1ID = _Position1ID;
                    _Jie.Position2ID = _Position2ID;
                    _Jie.Position3ID = _Position3ID;
                    _Jie.JieDate = Convert.ToDateTime(txt_JieDate.Text);
                    _Jie.YingHuanDate = Convert.ToDateTime(txt_YingHuanDate.Text);
                    _Jie.JieYongtu = txt_JieYongtu.Text.Trim();
                    _Jie.JieYongUserKey = Convert.ToInt32(ViewState["JieUserID"]);
                    _Jie.JieJBRUserKey = 654;    //韩丹工号
                    _Jie.JieRemark = txt_JieRemark.Text.Trim();
                    _Jie.JieOperateDate = DateTime.Now;

                    //新增出借记录
                    if (BLL.Application.Assets.Zclt.ZcJie.createAS_Jie(_Jie))
                    {
                        lbMessage.Text = "出借成功！";
                        BLL.pub.PubClass.showAlertMessage(Page, ClientScript, "出借成功！");
                        databindGV();
                    }
                    else
                    {
                        lbMessage.Text = "出借失败！";
                        BLL.pub.PubClass.showAlertMessage(Page, ClientScript, "出借失败！");
                    }

                    //修改资产状态为“出借”
                    var rs = from r in dc.AS_Zc
                             where r.ZcID == Convert.ToInt32(ViewState["ZcID"])
                             select r;

                    foreach (var r in rs)
                    {
                        r.ZTID = 2;    //2表示“出借”状态
                    };

                    dc.SubmitChanges();
                    databindGV();
                    lbMessage.Text = "资产出借成功！";
                    txt_ZcTXM.Text = "";   //查询的资产编码文本框清空
                }
                catch
                {
                    lbMessage.Text = "资产出借失败！";
                }
                ViewState["mode"] = "Add";
                bt_Save.Enabled = false;
            }

            if (ViewState["mode"].ToString() == "Edit")
            {
                if (ViewState["JieID"] != null)
                {
                    try
                    {
                        var rs = from r in dc.AS_Jie
                                 where r.JieID == Convert.ToInt32(ViewState["JieID"])
                                 select r;

                        foreach (var r in rs)
                        {
                            r.Position1ID = _Position1ID;
                            r.Position2ID = _Position2ID;
                            r.Position3ID = _Position3ID;
                            r.JieDate = Convert.ToDateTime(txt_JieDate.Text);
                            r.YingHuanDate = Convert.ToDateTime(txt_YingHuanDate.Text);
                            r.JieYongtu = txt_JieYongtu.Text.Trim();
                            r.JieJBRUserKey = 654;    //韩丹工号
                            r.JieRemark = txt_JieRemark.Text.Trim();
                            r.JieOperateDate = DateTime.Now;
                        };

                        dc.SubmitChanges();
                        databindGV();
                    }
                    catch
                    {
                        lbMessage.Text = "编辑保存失败！";
                    }
                }
                else
                {
                    lbMessage.Text = "非正常借用ID！";
                    BLL.pub.PubClass.showAlertMessage(Page, ClientScript, "非正常借用ID！");
                    return;
                }
                bt_Save.Enabled = false;
                ViewState["mode"] = "Add";
            }
        }

        protected void gvJie_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvJie.EditIndex = e.NewEditIndex;
            databindGV();
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
        //            databindGV();
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
        //        databindGV();
        //    }
        //    else
        //    {
        //        lbMessage.Text = "删除失败！";
        //    }
        //}

        protected void gvJie_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvJie.EditIndex = -1;
            databindGV();
        }

        protected void gvJie_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvJie.PageIndex = e.NewPageIndex;
            databindGV();
        }

        protected void ddl_Position1_SelectedIndexChanged(object sender, EventArgs e)
        {
            databindDDL_Position2();
        }

        protected void ddl_Position2_SelectedIndexChanged(object sender, EventArgs e)
        {
            databindDDL_Position3();
        }


        //protected void DDL_Zt_DataBinding(object sender, EventArgs e)
        //{
        //    DropDownList ddl = (DropDownList)sender;

        //    BLL.Application.Assets.lkgl.Zcdj.DDL_Zt_Databind(ref ddl);
        //}

        //protected void ddl_ZT_DataBinding1(object sender, EventArgs e)
        //{
        //    DropDownList ddl = (DropDownList)sender;

        //    BLL.Application.Assets.Base.CK.dllClass0Databind(ref ddl);
        //}

        protected void gvJie_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "del")
            {
                Int32 _JieID = Convert.ToInt32(e.CommandArgument);

                Int32 _ZcID = BLL.Application.Assets.Zclt.ZcJie.GetZcIDbyJieID(_JieID);
                if(_ZcID != -1)
                {
                    //修改资产状态为“在库”
                    var rs = from r in dc.AS_Zc
                             where r.ZcID == _ZcID
                             select r;
                    foreach(var r in rs){
                        r.ZTID = 1;      //1表示“在库”状态
                    }

                    dc.SubmitChanges();
                }
                else
                {
                    lbMessage.Text = "资产信息获取失败，无法改为“在库”状态！";
                    return;
                }

                try 
                {
                    var rs1 = from r in dc.AS_Jie
                              where r.JieID == _JieID
                              select r;

                    foreach (var r in rs1)
                    {
                        dc.AS_Jie.DeleteOnSubmit(r);
                        dc.SubmitChanges();
                    }
                    databindGV();
                    lbMessage.Text = "删除成功！";
                }
                catch
                {
                    lbMessage.Text = "删除失败！";

                }
                ViewState["mode"] = "Add";
                bt_Save.Enabled = false;
            }

            if (e.CommandName == "details")
            {
                 //GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent)); //此得出的值是表示那行被选中的索引值 
                 //此获取的值为GridView中绑定数据库中的主键值,取值方法是选中的行中的第一列的值,drv.RowIndex取得是选中行的索引 
                 //string _txm = ((Label)gvJie.Rows[drv.RowIndex].Cells[3].FindControl("lbl_ZcTXM")).Text.ToString();

                Int32 _JieID = Convert.ToInt32(e.CommandArgument);
 
                //string  _txm = e.CommandArgument.ToString();

                //Int32 _id = BLL.Application.Assets.Zclt.ZcJie.GetZcIDbyZcTXM(_txm );

                ShowJieDetails(_JieID);

                bt_Save.Enabled = false;

                ////mode = "Edit";
                //PanelAddZC.Visible = true;
            }

            //"ed"----开始
            if (e.CommandName == "ed")
            {
                Int32  _JieID = Convert.ToInt32(e.CommandArgument);

                ShowJieDetails(_JieID);

                txt_ZcTXM.Text = "";   //查询的资产编码文本框清空
                ViewState["mode"] = "Edit";
                bt_Save.Enabled = true;
            }
            //"ed"----结束

        }

        protected void lbn_SearchUser_Click(object sender, EventArgs e)
        {
            string _UserName = txt_UserName.Text.Trim();

            ViewState["JieUserID"] = BLL.Application.Assets.Zclt.ZcJie.GetUserIDbyUserName(_UserName );
            if (Convert.ToInt32(ViewState["JieUserID"]) > 0)
            {
                lbl_UserID.Text = "工号：" + ViewState["JieUserID"].ToString();
                databindGV();

            }
            else
            {
                ViewState["JieUserID"] = null;
                lbl_UserID.Text = "查无此人！";
            }

            chk_bt_Save();
        }

        protected void lbn_SearchZc_Click(object sender, EventArgs e)
        {
            Search_Zc();
        }

        protected void Search_Zc()
        {
            ViewState["ZcTXM"] = txt_ZcTXM.Text.Trim();

            Int32 _ZcID = BLL.Application.Assets.Zclt.ZcJie.GetZcIDbyZcTXM(ViewState["ZcTXM"].ToString());
            if (_ZcID > 0)
            {
                lbl_ZcID.Text = "资产ID号：" + _ZcID.ToString();

                ShowZcDetails(_ZcID);

                ViewState["ZcID"] = _ZcID;
                PanelAddZC.Visible = true;
            }
            else
            {
                lbl_ZcID.Text = "查无此物！";
                ViewState["ZcID"] = null;
                ViewState["ZcTXM"] = null;
            }

            chk_bt_Save();
        }

        //显示资产详细信息
        protected void ShowZcDetails(Int32 _ZcID)
        {
            var rs = from r in dc.v_AS_ZC 
                     where r.ZcID  == _ZcID
                     select r;

            foreach (var r in rs)
            {
                //资产信息---开始
                lbl_ID.Text = r.ZcID.ToString();
                txt_Name.Text = r.ZcName;
                txt_Type.Text = r.ZcType;
                txt_TXM.Text = r.ZcTXM;
                txt_LkDate.Text = r.ZcRkDate.ToString();
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

                ViewState["oldTXM"] = r.ZcTXM;

                databindCK();    //初始化仓库下拉列表框
                ddl_CK.SelectedIndex = -1;
                ddl_CK.SelectedValue = r.CKID.ToString();

                databindZT();    //初始化资产状态
                ddl_ZT.SelectedIndex = -1;
                ddl_ZT.SelectedValue = r.ZTID.ToString();
                //资产信息---结束
            }
        }



        protected void ShowJieDetails(Int32 _JieID)
        {

            var rs = from r in dc.v_AS_Jie
                     where r.JieID == _JieID
                     select r;

            if (rs.Count() == 1)
            {
                ViewState["JieID"] = _JieID;
            }
            else
            {
                ViewState["JieID"] = null;
                lbMessage.Text = "无法编辑！";
                return;
            }

            foreach (var r in rs)
            {
                //显示资产信息
                ShowZcDetails(Convert.ToInt32( r.ZcID));

                //出借信息---开始
                txt_TXM.Text = r.ZcTXM;
                txt_JieYongtu.Text = r.JieYongtu;
                txt_JieRemark.Text = r.JieRemark;
                txt_JieDate.Text = r.JieDate.ToString();
                txt_YingHuanDate.Text = r.YingHuanDate.ToString();
                lbl_JieOperateDate.Text = r.JieOperateDate.ToString();
                lbl_JieJBRUserKey.Text = r.JieJBRUserKey.ToString();
                
                ddl_Position1.Items.Clear();
                ddl_Position2.Items.Clear();
                ddl_Position3.Items.Clear();

                    //下拉列表框处理--开始
                    databindDDL_Position1();

                    if (ddl_Position1.Items.Count > 0)
                    {
                        ddl_Position1.SelectedValue = r.Position1ID.ToString();
                        databindDDL_Position2();
                    }

                    if (ddl_Position2.Items.Count > 0)
                    {
                        ddl_Position2.SelectedValue = r.Position2ID.ToString();
                        databindDDL_Position3();
                    }


                    if (ddl_Position3.Items.Count > 0)
                    {
                        ddl_Position3.SelectedValue = r.Position3ID.ToString();
                    }
                    //下拉列表框处理--结束

                //出借信息---结束
            }
        }


        protected void txt_ZcTXM_TextChanged(object sender, EventArgs e)
        {
            if(txt_ZcTXM.Text.Length==12)
            {
                Search_Zc();
            }
        }

    }
}