using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.admin.Menu
{
    public partial class menu_right : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                databind();
            }
        }

        protected void databind()
        {
            string id = Request.QueryString["id"];
            if (!String.IsNullOrEmpty(id))
            {
                ViewState["mode"] = "update";
                ViewState["id"] = id;
                lbMode.Text = "修改模式";
                tbMenuId.Enabled = false;
                t_Menu menu = BLL.admin.menu.MenuManagement.getMenuById(Convert.ToInt32(id));
                tbMenuId.Text = menu.Id.ToString();
                tbName.Text = menu.name;
                tbUrl.Text = menu.url;
                CheckBoxStatus.Checked = (bool)menu.status;
            }
            else
            {
                ViewState["mode"] = "add";
                lbMode.Text = "添加模式";
                tbMenuId.Enabled = true;
            }
            bindDropdownListNode(DropDownListParentNode);
        }

        protected void clearData()
        {
            tbMenuId.Text = "";
            tbName.Text = "";
            tbUrl.Text = "";
            DropDownListParentNode.Items.Clear();
            bindDropdownListNode(DropDownListParentNode);

            ViewState["mode"] = "add";
            lbMode.Text = "添加模式";
            tbMenuId.Enabled = true;
        }

        protected void bindDropdownListNode( DropDownList ddl)
        {
            ListItem li = new ListItem("");
            ddl.Items.Add(li);
            BLL.admin.menu.MenuManagement.bindDropdownListNode(ref ddl);

        }

        protected void lbAdd_Click(object sender, EventArgs e)
        {
            clearData();
        }

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(tbMenuId.Text))
                {
                    if(BLL.admin.menu.MenuManagement.hasChildMenu(Convert.ToInt32(tbMenuId.Text)))
                    {
                        lbMessage.Text = "该菜单还有下级菜单，不能删除，请先删除子菜单！";
                        return;
                    }
                    if(BLL.admin.menu.MenuManagement.hasMenuRole(Convert.ToInt32(tbMenuId.Text)))
                    {
                        lbMessage.Text = "该菜单还有绑定的角色，不能删除，请先删除绑定角色！";
                        return;
                    }
                    BLL.admin.menu.MenuManagement.deleteMenu(Convert.ToInt32(tbMenuId.Text));

                    Response.Write("<script language=javascript>");
                    Response.Write("window.parent.lframe.location='menu_left.aspx';<");
                    Response.Write("/script>");
                    BLL.pub.PubClass.showAlertMessage(Page, ClientScript, "删除成功！");
                    clearData();
                }
            }catch(Exception ex)
            {
                lbMessage.Text = "删除错误：" + ex.Message;
            }
        }

        protected void lbSave_Click(object sender, EventArgs e)
        {
            if((string)ViewState["mode"] == "add")
            {
                try
                {
                    t_Menu menu = new t_Menu();
                    menu.Id = Convert.ToInt32( tbMenuId.Text);
                    menu.name = tbName.Text;
                    menu.url = tbUrl.Text;
                    menu.status = CheckBoxStatus.Checked;
                    if (!String.IsNullOrEmpty(DropDownListParentNode.SelectedValue))
                        menu.parentId = Convert.ToInt32(DropDownListParentNode.SelectedValue);
                    else
                        menu.parentId = 0;
                    BLL.admin.menu.MenuManagement.createMenu(menu);
                    Response.Write("<script language=javascript>");
                    Response.Write("window.parent.lframe.location='menu_left.aspx';<");
                    Response.Write("/script>");
                    BLL.pub.PubClass.showAlertMessage(Page, ClientScript, "添加成功！");
                    lbMode.Text = "修改模式";
                    ViewState["mode"] = "update";
                    tbMenuId.Enabled = false;
                }catch(Exception ex)
                {
                    lbMessage.Text = "添加错误：" + ex.Message;
                }
               
            }else
            if ((string)ViewState["mode"] == "update")
            {
                try
                {
                    t_Menu menu = new t_Menu();
                    menu.Id = Convert.ToInt32(tbMenuId.Text);
                    menu.name = tbName.Text;
                    menu.url = tbUrl.Text;
                    menu.status = CheckBoxStatus.Checked;
                    menu.parentId = Convert.ToInt32(DropDownListParentNode.SelectedValue);
                    BLL.admin.menu.MenuManagement.updateMenu(menu);

                    Response.Write("<script language=javascript>");
                    Response.Write("window.parent.lframe.location='menu_left.aspx';<");
                    Response.Write("/script>");
                    BLL.pub.PubClass.showAlertMessage(Page, ClientScript, "修改成功！");
                    lbMode.Text = "修改模式";
                    ViewState["mode"] = "update";
                    tbMenuId.Enabled = false;
                }
                catch (Exception ex)
                {
                    lbMessage.Text = "修改错误：" + ex.Message;
                }
            }
        }
    }
}