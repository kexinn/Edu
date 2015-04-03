using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;

namespace web.Application.BX
{
    public partial class MyBXForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                AspNetPager1.PageSize = BLL.pub.PubClass.PAGE_SIZE;
                initgrid();
                initForm();
            }
        }

        protected void initForm()//判断是否有请求，如果有则初始化
        {

            if (Request["id"] != null)
            {
                t_BX_Form form = new t_BX_Form_Repository().Load(Convert.ToInt32(Request["id"]));
                PanelApply.Visible = true;
                PanelItems.Visible = true;
                lbUsername.Text = Session["username"].ToString();
                tbStartDate.Text = Convert.ToDateTime(form.StartDate).ToShortDateString();
                tbEndDate.Text = Convert.ToDateTime(form.EndDate).ToShortDateString();
                lbFormId.Text = form.Id.ToString();
                tbReason.Text = form.Reason;
                initPositionType(form.PositionTypeId);
                tbPosition.Text = form.Position;
                if(form.PositionTypeId!=5)
                {
                    initPositon(form.Position.Trim());
                    tbPosition.Text = form.Position;
                }else
                {
                    tbPosition.Enabled = true;
                }
                foreach(ListItem li in ddlBXType.Items)
                {
                    if (li.Value == form.Type.ToString())
                        li.Selected = true;
                }
                if (form.PeopleNumber > 1)
                {
                    PanelPeople.Visible = true;
                    tbPeoples.Text = form.PeoplesName;
                    tbPeopleNum.Text = form.PeopleNumber.ToString();
                }
                RepeaterItem.DataSource = form.t_BX_FormItem;
                RepeaterItem.DataBind();
            }
        }

        protected void initPositionType(int selecet = 0)
        {

            List<t_BX_PositionType> lists = new BLL.Application.BX.MyBXForm().getDDLPositionType();
            ddlPositionType.Items.Clear();
            ListItem li = new ListItem();
            li.Text = "";
            li.Value = "";
            ddlPositionType.Items.Add(li);
            foreach (t_BX_PositionType l in lists)
            {
                ListItem ll = new ListItem();
                ll.Text = l.name;
                ll.Value = l.Id.ToString();
                if (l.Id == selecet)
                    ll.Selected = true;
                ddlPositionType.Items.Add(ll);

            }
        }

        protected void initPositon(string select = "")
        {
            tbPosition.Enabled = false;
            tbPosition.Text = "";
            ddlPosition.Visible = true;
            ddlPosition.Items.Clear();
            List<t_BX_Position> lists = new BLL.Application.BX.MyBXForm().getDDLPosition(Convert.ToInt32(ddlPositionType.SelectedValue));
            ListItem li = new ListItem();
            li.Text = "";
            li.Value = "";
            ddlPosition.Items.Add(li);
            foreach (t_BX_Position p in lists)
            {
                ListItem l = new ListItem();
                l.Text = p.Name;
                l.Value = p.Id.ToString();
                if (p.Name.Trim() == select)
                    l.Selected = true;
                ddlPosition.Items.Add(l);
            }
        }

        protected void initdata()
        {
            lbMessage.Text = "";
            lbFormId.Text = "";
            lbUsername.Text = Session["username"].ToString();
            initPositionType();
        }
        
        protected void initgrid()
        {
            int recordNum = 0;

            gvBXForm.DataSource = new BLL.Application.BX.MyBXForm().getForms(Convert.ToInt32(Session["userid"]), AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize, ref recordNum);

            gvBXForm.Columns[0].Visible = false;
            AspNetPager1.RecordCount = recordNum;
            gvBXForm.DataBind();
        }

        protected void clearinput()
        {
            tbItemsStart.Text = "";
            tbDays.Text = "";
            tbItemsPeopleNum.Text = "";
            tbShineiFee.Text = "";
            tbChengjianFee.Text = "";
            tbAccomdanceFee.Text = "";
        }

        protected void initFormItems()
        {
            if (!string.IsNullOrEmpty(lbFormId.Text))
            {
                RepeaterItem.DataSource = new BLL.Application.BX.MyBXForm().getFormItems(Convert.ToInt32(lbFormId.Text));
                RepeaterItem.DataBind();
            }
        }
        protected void lbAdd_Click(object sender, EventArgs e)
        {
            initdata();
            PanelApply.Visible = true;
        }

        protected void btApply_Click(object sender, EventArgs e)
        {
            try
            {
                t_BX_Form form = new t_BX_Form();

                if(!string.IsNullOrEmpty(lbFormId.Text))
                    form.Id = Convert.ToInt32( lbFormId.Text);
                form.userid = Convert.ToInt32(Session["userid"].ToString());
                form.username = Session["username"].ToString();
                form.StartDate = Convert.ToDateTime(tbStartDate.Text);
                form.EndDate = Convert.ToDateTime(tbEndDate.Text);
                form.Reason = tbReason.Text;
                form.PositionTypeId = Convert.ToInt32(ddlPositionType.SelectedValue);
                form.Position = tbPosition.Text;
                form.Type = Convert.ToInt16(ddlBXType.SelectedValue);
                form.PeopleNumber = string.IsNullOrEmpty(tbPeopleNum.Text) ? 1 : Convert.ToInt32(tbPeopleNum.Text);
                form.PeoplesName = string.IsNullOrEmpty(tbPeoples.Text) ? "" : tbPeoples.Text;

                if(new BLL.Application.BX.MyBXForm().saveForm(form))
                {
                    PanelItems.Visible = true;
                    Debug.Assert(form.Id != 0);
                    lbFormId.Text = form.Id.ToString();
                    initgrid();
                }else
                {
                    lbMessage.Text = "保存错误，请重试。";
                }

            }
            catch (Exception ex)
            {
                lbMessage.Text = "错误：" + ex.Message;
            }
            lbAdd.Enabled = false;
        }

        protected void RepeaterItem_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
             if(e.CommandName == "del")
            {

                if(new BLL.Application.BX.MyBXForm().DeleteFormItem(Convert.ToInt32(e.CommandArgument.ToString())))
                {
                    initFormItems();
                }
            }
        }

        protected void lbAddItem_Click(object sender, EventArgs e)
        {
            lbMessage.Text = "";
            if (!string.IsNullOrEmpty(lbFormId.Text))
            {
                try
                {
                    BLL.Application.BX.MyBXForm myform = new BLL.Application.BX.MyBXForm();
                    t_BX_FormItem items = new t_BX_FormItem();
                    items.Date = Convert.ToDateTime(tbItemsStart.Text);
                    items.Days = Convert.ToInt32( tbDays.Text);
                    items.PeoplesNum = Convert.ToInt32(tbItemsPeopleNum.Text);
                    items.TrafficFee = string.IsNullOrEmpty(tbShineiFee.Text) ? 0 : Convert.ToDecimal(tbShineiFee.Text);
                    items.CityTrafficFee = string.IsNullOrEmpty(tbChengjianFee.Text) ? 0 : Convert.ToDecimal(tbChengjianFee.Text);
                    items.AccommodationFee = string.IsNullOrEmpty(tbAccomdanceFee.Text) ? 0 : Convert.ToDecimal(tbAccomdanceFee.Text);
                    items.IsReception = Convert.ToBoolean( Convert.ToInt32( ddlIsReception.SelectedValue));
                    items.FormId = Convert.ToInt32(lbFormId.Text);
                    if (myform.saveFormItem(Convert.ToInt32(lbFormId.Text), items))
                    {
                        //更新列表
                        RepeaterItem.DataSource = myform.getFormItems(Convert.ToInt32(lbFormId.Text));
                      RepeaterItem.DataBind();
                      clearinput();
                    }


                }
                catch (Exception ex)
                {
                    lbMessage.Text = "错误：" + ex.Message;
                }
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            initgrid();
        }

        protected void ddlPositionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ddlPositionType.SelectedValue))
            {
                if (ddlPositionType.SelectedItem.Text.Trim() == "大市外")
                {
                    tbPosition.Text = "";
                    ddlPosition.Items.Clear();
                    ddlPosition.Visible = false;
                    PanelRagion.Visible = true;
                    initDDlSheng();

                }else
                {
                    PanelRagion.Visible = false;
                    initPositon();
                }

            }
            else
            {
                tbPosition.Text = "";
                tbPosition.Visible = false;
                ddlPosition.Items.Clear();
            }
        }

        protected void initDDlSheng(int select=0)
        {
            List<Region> lists = new BLL.Application.BX.MyBXForm().getDDLRegion(1);
            ddlSheng.Items.Clear();
            ListItem li = new ListItem();
            li.Text = "";
            li.Value = "";
            ddlSheng.Items.Add(li);
            foreach (Region l in lists)
            {
                ListItem ll = new ListItem();
                ll.Text = l.REGION_NAME;
                ll.Value = l.REGION_ID.ToString();
                if (l.REGION_ID == select)
                    ll.Selected = true;
                ddlSheng.Items.Add(ll);

            }
        }

        protected void initDDlShi(int select = 0)
        {
            List<Region> lists = new BLL.Application.BX.MyBXForm().getDDLRegion(Convert.ToInt32(ddlSheng.SelectedValue));
            ddlShi.Items.Clear();
            ListItem li = new ListItem();
            li.Text = "";
            li.Value = "";
            ddlShi.Items.Add(li);
            foreach (Region l in lists)
            {
                ListItem ll = new ListItem();
                ll.Text = l.REGION_NAME;
                ll.Value = l.REGION_ID.ToString();
                if (l.REGION_ID == select)
                    ll.Selected = true;
                ddlShi.Items.Add(ll);

            }
        }

        protected void initDDlXian(int select = 0)
        {
            List<Region> lists = new BLL.Application.BX.MyBXForm().getDDLRegion(Convert.ToInt32(ddlShi.SelectedValue));
            ddlXian.Items.Clear();
            ListItem li = new ListItem();
            li.Text = "";
            li.Value = "";
            ddlXian.Items.Add(li);
            foreach (Region l in lists)
            {
                ListItem ll = new ListItem();
                ll.Text = l.REGION_NAME;
                ll.Value = l.REGION_ID.ToString();
                if (l.REGION_ID == select)
                    ll.Selected = true;
                ddlXian.Items.Add(ll);
            }
        }

        protected void ddlPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbPosition.Text = ddlPosition.SelectedItem.Text;
        }

        protected void ddlBXType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ddlBXType.SelectedValue))
            {
                if (ddlBXType.SelectedValue == "1")//凭票
                {
                    PanelPeople.Visible = false;
                }else if (ddlBXType.SelectedValue == "2")//包干
                {
                    PanelPeople.Visible = true;

                }

            }
        }


        protected void hlEdit_DataBinding(object sender, EventArgs e)
        {
            HyperLink li = sender as HyperLink;
            t_BX_Form form = GetDataItem() as t_BX_Form;
            li.NavigateUrl = "/Application/BX/MyBXForm.aspx?id=" + form.Id;
        }


        protected void hlView_DataBinding(object sender, EventArgs e)
        {

            HyperLink li = sender as HyperLink;
            t_BX_Form form = GetDataItem() as t_BX_Form;
            li.NavigateUrl = "/Application/BX/FormDetailView.aspx?id=" + form.Id;
        }

        protected void ddlSheng_SelectedIndexChanged(object sender, EventArgs e)
        {
            initDDlShi();
            ddlXian.Items.Clear();
            tbPosition.Text = ddlSheng.SelectedItem.Text;
        }

        protected void ddlShi_SelectedIndexChanged(object sender, EventArgs e)
        {
            initDDlXian();
            tbPosition.Text = ddlSheng.SelectedItem.Text + " " + ddlShi.SelectedItem.Text;
        }

        protected void ddlXian_SelectedIndexChanged(object sender, EventArgs e)
        {

            tbPosition.Text = ddlSheng.SelectedItem.Text + " " + ddlShi.SelectedItem.Text + " " + ddlXian.SelectedItem.Text;
        }
    }
}