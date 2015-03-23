using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace web.Application.Assets.Test
{
    public partial class test_DDL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArrayList arrList = new ArrayList();
                arrList.Add("星期日");
                arrList.Add("星期一");
                arrList.Add("星期二");
                arrList.Add("星期三");
                arrList.Add("星期四");
                arrList.Add("星期五");
                arrList.Add("星期六");
                DropDownList1.DataSource = arrList;
                DropDownList1.DataBind();
            }
        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_1.Text = "SelectedIndex-" + DropDownList2.SelectedIndex + "";
            txt_1.Text += "  SelectedValue-" + DropDownList2.SelectedValue;
            txt_1.Text += "  SelectedItem.Text-" + DropDownList2.SelectedItem.Text;
            txt_1.Text += "  SelectedItem.Value-" + DropDownList2.SelectedItem.Value;
            txt_1.Text += "  .Items[DropDownList2.SelectedIndex].Text-" + DropDownList2.Items[DropDownList2.SelectedIndex].Text;
            txt_1.Text += "  .Items[DropDownList2.SelectedIndex ].Value-" + DropDownList2.Items[DropDownList2.SelectedIndex].Value;
            txt_1.Text += "  .Items[DropDownList2.SelectedIndex ].Selected-" + DropDownList2.Items[DropDownList2.SelectedIndex].Selected;
        }
        protected void btn_Del_Click(object sender, EventArgs e)
        {
            ListItem Item = DropDownList2.SelectedItem;
            DropDownList2.Items.Remove(Item );
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_1.Text = "SelectedIndex-" + DropDownList1.SelectedIndex + "";
            txt_1.Text += "  SelectedValue-" + DropDownList1.SelectedValue;
            txt_1.Text += "  SelectedItem.Text-" + DropDownList1.SelectedItem.Text;

        }

        protected void btn_Clear_Click(object sender, EventArgs e)
        {
            DropDownList2.ClearSelection();
        }

        protected void btn_OK_Click(object sender, EventArgs e)
        {
            txt_1.Text = DropDownList2.SelectedIndex.ToString();
        }

        protected void btn_Clear_All_Click(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
        }

        protected void btn_Count_Click(object sender, EventArgs e)
        {
            txt_1.Text = DropDownList2.Items.Count.ToString();
        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            DropDownList2.Items.Add(new ListItem("444","4"));
            ListItem lim = new ListItem("555", "5");
            DropDownList2.Items.Add(lim);
        }
    }
}