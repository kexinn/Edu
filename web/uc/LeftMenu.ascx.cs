using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using BLL;

namespace web.uc
{

    //public enum Sys
    //{

    //    First = 1,

    //    Second = 2

    //}
    public partial class LeftMenu : System.Web.UI.UserControl
    {
        private int _sys = 1;
        public int sysid
        {

            get { return this._sys; }

            set { _sys = value; }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                databind();
            }
        }

        protected void databind()
        {
            StringBuilder sb = new StringBuilder();
            List<t_Menu> menus = BLL.admin.menu.MenuManagement.getMenuBySysid(_sys, Convert.ToInt32( Session["userid"]));
            List<t_Menu> menuParent = menus.Where(u=>u.parentId == 0).ToList();
            foreach (t_Menu m in menuParent)
            {
                sb.Append(@"<dd>
    <div class=""title"">
    <span><img src=""/media/images/leftico01.png"" /></span>");
                sb.Append(m.name);
                sb.Append(@" </div>
    	<ul class=""menuson"">");
                List<t_Menu> menuChild = menus.Where(u=>u.parentId == m.Id).ToList();
                foreach(t_Menu t in menuChild)
                {
                    sb.Append(@" <li><cite></cite><a href=""" + t.url + @""" target=""rightFrame"">" + t.name + @"</a><i></i></li>");
                }

                sb.Append(@"</ul>    
    </dd>");
            }
            dl.InnerHtml = sb.ToString();
        }
    }
}