using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.Assets.Lkgl
{
    public partial class Zcdj : System.Web.UI.Page
    {
        static string mode;
        static Int32 ID_ZcDj;

        DataClassesASDataContext dc = new DataClassesASDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            AspNetPager1.PageSize = 10;

            if (!IsPostBack)
            {

                this.PanelAddZC.Visible = false;
                lbMessage.Text = "";

                ViewState["condition"] = "";
                ViewState["popup"] = Request.Params["popup"];

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
                databindGV(ViewState["condition"].ToString());
                mode = "Add";
            }
        }

        protected void databindDW()
        {
            ddl_DW.Items.Clear();

            var rs_dw = dc.AS_DW;

            foreach(AS_DW r in rs_dw ){
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

            foreach(AS_Class0 r in rs_class0 ){
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

        protected void databindGV(String strCondition = "")
        {
            //gvZC.DataSource=BLL.Application.Assets.lkgl.Zcdj.GetAS_Zc() ;


            var list = (System.Linq.IQueryable<AS_ZcDj>)dc.AS_ZcDj;
            if (!String.IsNullOrEmpty(strCondition))
                list = list.Where(l => l.ZcName.Contains(strCondition));
            gvZC.DataSource = list.OrderByDescending(u => u.ZcDjID).Skip(AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1)).Take(AspNetPager1.PageSize);

            AspNetPager1.RecordCount = list.Count();
            gvZC.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            databindGV(ViewState["condition"].ToString());
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
                _Class0BH = _st.Substring(n+1,_st.Length-(n+1));
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
            
            string _Name = txt_ZcName.Text.Trim();
            string _Type = txt_ZcType.Text.Trim();
            string _Remark = txt_ZcDjRemark.Text.Trim();


            Int32 _DWID;
            if (ddl_DW.SelectedIndex != -1)
            {
                _DWID = Convert.ToInt32(ddl_DW.SelectedValue);
            }
            else
            {
                _DWID = 0;
            }

            AS_ZcDj  _ZcDj = new AS_ZcDj();


            _ZcDj.ZcName = _Name;
            _ZcDj.ZcType = _Type;
            _ZcDj.Class0BH = _Class0BH;
            _ZcDj.Class1BH = _Class1BH;
            _ZcDj.Class2BH = _Class2BH;
            _ZcDj.Class3BH = _Class3BH;
            _ZcDj.DWID = _DWID;
            _ZcDj.ZcSl = Convert.ToInt32(txt_ZcSl.Text);
            _ZcDj.ZcJg = Convert.ToDecimal(txt_ZcJg.Text);
            _ZcDj.ZcDjDate = Convert.ToDateTime(txt_ZcDjDate.Text);
            _ZcDj.ZcDjRemark = _Remark;
            _ZcDj.ZcDjOperateDate =DateTime.Now ;

            if (mode == "Add")
            {
                if (BLL.Application.Assets.lkgl.Zcdj.createAS_ZcDj(_ZcDj))
                {
                    lbMessage.Text = "新增资产登记成功！";
                    BLL.pub.PubClass.showAlertMessage(Page, ClientScript, "新增资产登记成功！");
                    databindGV(ViewState["condition"].ToString());
                }
                else
                {
                    lbMessage.Text = "新增资产登记失败！";
                    BLL.pub.PubClass.showAlertMessage(Page, ClientScript, "新增资产登记失败！");
                }
            }

            if (mode == "Edit")
            {
                   var rs = from r in dc.AS_ZcDj
                             where r.ZcDjID == ID_ZcDj
                             select r;

                   if (rs.Count() == 1) { 
                    foreach (var r in rs)
                    {
                        r.ZcName = txt_ZcName.Text.Trim();
                        r.ZcType = txt_ZcType.Text.Trim();
                        r.Class0BH = _Class0BH;
                        r.Class1BH = _Class1BH;
                        r.Class2BH = _Class2BH;
                        r.Class3BH = _Class3BH;
                        r.DWID = _DWID;
                        r.ZcSl = Convert.ToInt32(txt_ZcSl.Text);
                        r.ZcJg = Convert.ToDecimal(txt_ZcJg.Text);
                        r.ZcDjDate = Convert.ToDateTime(txt_ZcDjDate.Text);
                        r.ZcDjOperateDate = DateTime.Now;
                        r.ZcDjRemark = _Remark;
                    };

                    dc.SubmitChanges();
                    databindGV(ViewState["condition"].ToString());
                   }
            }
        }

        protected void lbAdd_Click(object sender, EventArgs e)
        {
            this.PanelAddZC.Visible = true;
            txt_ZcDjDate.Text = DateTime.Now.ToString("yyyy-MM-dd") ;
            mode = "Add";
            lbMessage.Text = "";
        }

        protected void gvZC_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvZC.EditIndex = e.NewEditIndex;
            databindGV(ViewState["condition"].ToString());
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
                    databindGV(ViewState["condition"].ToString());
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

            if(BLL.Application.Assets.lkgl.Zcdj.deleteAS_ZCbyID(id))
            {
                lbMessage.Text = "删除成功！";
                databindGV(ViewState["condition"].ToString());
            }
            else
            {
                lbMessage.Text = "删除失败！";
            }
        }

        protected void gvZC_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvZC.EditIndex = -1;
            databindGV(ViewState["condition"].ToString());
        }

        protected void gvZC_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvZC.PageIndex = e.NewPageIndex;
            databindGV(ViewState["condition"].ToString());
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

        protected void DDL_Zt_DataBinding(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;

            BLL.Application.Assets.lkgl.Zcdj.DDL_Zt_Databind(ref ddl);
        }

        protected void ddl_ZT_DataBinding1(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;

            BLL.Application.Assets.Base.CK.dllClass0Databind(ref ddl);
        }

        protected void gvZC_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ID_ZcDj = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "del")
            {
                try
                {
                    var rs = from r in dc.AS_ZcDj
                             where r.ZcDjID == ID_ZcDj
                             select r;

                    foreach (var r in rs)
                    {
                        dc.AS_ZcDj.DeleteOnSubmit(r);
                        dc.SubmitChanges();
                    }
                    databindGV(ViewState["condition"].ToString());
                    lbMessage.Text = "";
                }
                catch { 
                    lbMessage.Text = "记录删除未成功!";
                }
            }
            if (e.CommandName == "ed")
            {
                    var rs = from r in dc.AS_ZcDj
                             where r.ZcDjID == ID_ZcDj
                             select r;

                    foreach (var r in rs)
                    {
                        lbl_ZcDjID.Text = r.ZcDjID.ToString();
                        txt_ZcName.Text = r.ZcName;
                        txt_ZcType.Text = r.ZcType;
                        txt_ZcSl.Text = r.ZcSl.ToString();
                        txt_ZcJg.Text = r.ZcJg.ToString();
                        txt_ZcDjDate.Text = r.ZcDjDate.ToString();
                        txt_ZcDjRemark.Text = r.ZcDjRemark.ToString();

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

                                ddl_Class0.SelectedValue=rs_class0.Class0ID.ToString() + "," + r.Class0BH ;
                                databindDDL_Class1();
                            }
                            catch{
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

                                var rs_Class1 = dc.AS_Class1.Where(u => u.Class0ID == _Class0ID && u.Class1BH == _Class1BH ).Single();
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

                mode = "Edit";
                PanelAddZC.Visible = true;
            }

        }

        protected void lbStatisc_Click(object sender, EventArgs e)
        {
            ViewState["condition"] = tb_search.Text;
            databindGV(ViewState["condition"].ToString());
           
        }

        protected void gvZC_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           // e.Row.Attributes.Add("onclick", "javascript:chuan(this)");


        }

        protected void lbSelectOK_DataBinding(object sender, EventArgs e)
        {
            string pop = (string)ViewState["popup"];
            if (pop == "Yes")
            {
                LinkButton bt = (LinkButton)sender;
                AS_ZcDj dj = GetDataItem() as AS_ZcDj;

                bt.Attributes.Add("onclick", "javascript:chuan(" + dj.ZcDjID + ")");
            }
        }
    }
}