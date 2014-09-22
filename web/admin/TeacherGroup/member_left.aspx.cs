using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.admin.TeacherGroup
{
    public partial class member_left : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
            }
        }

        protected void databind()
        {
          List< v_TeacherGroup> groups =  BLL.admin.TeacherGroup.TeacherGroupManagement.getDepartments();
            foreach(v_TeacherGroup g in groups)
            {
                TreeNode node = new TreeNode();

                int Id =g.Id;
                node.Text = g.TeacherGroupName;
                node.NavigateUrl = "member_right.aspx?id=" + Id;
                node.Target = "rframe";
                TreeView1.Nodes.Add(node);
            }
        }
        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {

        }
    }
}