using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.Assets.Base
{
    public partial class PositionLeft : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BLL.Application.Assets.Base.Position.getPositionTree(ref this.TreeView1);
            }
        }
        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            //Response.Redirect("../PositionManagement.aspx");
            TreeNode  _Node = new TreeNode();
            _Node = TreeView1.SelectedNode;
            Response.Write("aaaqqqqqq11111"  );
        }
        protected void databind()
        {
            int i = 0;
            int ParentNode;
            int NodeId;
            //定义节点数组，数组下标对应于分类信息的ID，编码最多不能大于1000，否则会报错 
            //TreeNode[] menuNodes = new TreeNode[100001];
            //for (i = 0; i <= menuNodes.Length - 1; i++)
            //{
            //    //初始化各节点 
            //    menuNodes[i] = new TreeNode();
            //}

            List<AS_Position1> p1 = BLL.Application.Assets.Base.Position.getPosition1();
            foreach (AS_Position1 p in p1)
            {
                TreeNode node = new TreeNode();
                node.Text = p.Position1Name;
                TreeView1.Nodes.Add(node);

            }
            /* foreach (t_Menu m in menus)
             {
                 ParentNode = (int)m.parentId;
                 //获取上级分类ID 
                 NodeId = m.Id;
                 //获取当前分类ID 
                 //设置节点的显示文本，即分类名称 
                 menuNodes[NodeId].Text ="("+m.Id+")"+ m.name+((bool)m.status?"":"(禁用)");
                 //设置节点的链接地址 
                 menuNodes[NodeId].NavigateUrl = "menu_right.aspx?id=" + NodeId;
                 menuNodes[NodeId].Target = "rframe";
                 if (ParentNode != 0)
                 {
                     //如果存在上级分类，则将本节点作为上级分类对应的节点的子节点 
                     menuNodes[ParentNode].ChildNodes.Add(menuNodes[NodeId]);
                 }
                 else
                 {
                     //如果不存在上级分类，则将本节点作为根节点，直接加载 
                     TreeView1.Nodes.Add(menuNodes[NodeId]);
                 }
             }*/
        }
    }
}