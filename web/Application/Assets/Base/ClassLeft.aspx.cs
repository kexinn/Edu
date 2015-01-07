using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.Assets.Base
{
    public partial class ClassLeft : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BLL.Application.Assets.Base.Class.getClassTree(ref this.TreeView1);
            }
        }
        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {

        }
 
    }
}