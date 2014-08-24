using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Application.GZL
{
    public partial class GZLApplyLeft : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            initMenu();
        }

        protected void initMenu()
        {
            if (BLL.admin.role.RoleManagement.ifUserInRole(Convert.ToInt32(Session["userid"]), 1))

                PanelGZLSetting.Visible = true;
            else
                PanelGZLSetting.Visible = false;
        }
    }
}