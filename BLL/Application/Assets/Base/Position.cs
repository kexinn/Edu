using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using BLL;

namespace BLL.Application.Assets.Base
{
    public class Position
    {
        public static List<AS_Position1> getPosition1()
        {
            using(DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.AS_Position1.OrderBy(o=>o.Position1ID).ToList();
            }
        }
        public static AS_Position1 getPosition1ById(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.AS_Position1.Where(p => p.Position1ID == id).Single();
            }
        }

        public static void deletePosition1ById(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
               AS_Position1 p =  dc.AS_Position1.Where(pp => pp.Position1ID == id).Single();
               dc.AS_Position1.DeleteOnSubmit(p);
               dc.SubmitChanges();
            }
        }
        public static void createPosition1(AS_Position1 p1)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                dc.AS_Position1.InsertOnSubmit(p1);
                dc.SubmitChanges();
            }
        }

        public static void updatePosition1(AS_Position1 p1)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                AS_Position1 p = dc.AS_Position1.Where(o => o.Position1ID == p1.Position1ID).Single();
                p.Position1Name = p1.Position1Name;
                p.Position1Remark = p1.Position1Remark;
                dc.SubmitChanges();
            }
        }

        public static AS_Position2 getPosition2ById(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.AS_Position2.Where(p => p.Position2ID == id).Single();
            }
        }

        public static void updatePosition2(AS_Position2 p2)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                AS_Position2 p = dc.AS_Position2.Where(o => o.Position2ID == p2.Position2ID).Single();
                //p.Position1ID = p2.Position1ID;
                p.Position2Name = p2.Position2Name;
                p.Position2Remark = p2.Position2Remark;
                dc.SubmitChanges();
            }
        }
        public static void createPosition2(AS_Position2 p2)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                dc.AS_Position2.InsertOnSubmit(p2);
                dc.SubmitChanges();
            }
        }

        public static void deletePosition2ById(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                AS_Position2 p = dc.AS_Position2.Where(pp => pp.Position2ID == id).Single();
                dc.AS_Position2.DeleteOnSubmit(p);
                dc.SubmitChanges();
            }
        }
        public static AS_Position3 getPosition3ById(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.AS_Position3.Where(p => p.Position3ID == id).Single();
            }
        }
        public static void createPosition3(AS_Position3 p3)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                dc.AS_Position3.InsertOnSubmit(p3);
                dc.SubmitChanges();
            }
        }

        public static void updatePosition3(AS_Position3 p3)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                AS_Position3 p = dc.AS_Position3.Where(o => o.Position3ID == p3.Position3ID).Single();
                p.Position3Name = p3.Position3Name;
                p.Position3Remark = p3.Position3Remark;
                dc.SubmitChanges();
            }
        }

        public static void deletePosition3ById(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                AS_Position3 p = dc.AS_Position3.Where(pp => pp.Position3ID == id).Single();
                dc.AS_Position3.DeleteOnSubmit(p);
                dc.SubmitChanges();
            }
        }
        public static void getPositionTree(ref TreeView  tree)
        {
            using(DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var ps = dc.AS_Position1.OrderBy(o => o.Position1ID).ToList();
                TreeNode node0 = new TreeNode();
                node0.Text = "职教中心";
                node0.Value = "/";
                node0.NavigateUrl = "/Application/Assets/Base/PositionRight.aspx?level=/";
                node0.Target = "rframe";
                tree.Nodes.Add(node0);
                foreach (AS_Position1 p in ps)
                {
                    TreeNode node = new TreeNode();
                    node.Text = p.Position1Name;
                    node.Value = "A" + p.Position1ID.ToString();
                    node.NavigateUrl = "/Application/Assets/Base/PositionRight.aspx?id=" + node.Value + "&level=A"   ;
                    node.Target = "rframe";
                    node0.ChildNodes.Add(node);
                    var p2s = dc.AS_Position2.Where(u => u.Position1ID == p.Position1ID);
                    if(p2s.Count()>0)
                    {
                        foreach(AS_Position2 p2 in p2s)
                        {
                            TreeNode node2 = new TreeNode();
                            node2.Text = p2.Position2Name;
                            node2.Value =node.Value + "B" + p2.Position2ID.ToString();
                            node2.NavigateUrl = "/Application/Assets/Base/PositionRight.aspx?id=" + node2.Value + "&level=B" ;
                            node2.Target = "rframe";
                            node.ChildNodes.Add(node2);
                            var p3s = dc.AS_Position3.Where(u3=> u3.Position2ID == p2.Position2ID );
                            if(p3s.Count()>0)
                            {
                                foreach(AS_Position3 p3 in p3s)
                                {
                                    TreeNode node3 = new TreeNode();
                                    node3.Text = p3.Position3Name;
                                    node3.Value =node2.Value + "C" + p3.Position3ID.ToString();
                                    node3.NavigateUrl = "/Application/Assets/Base/PositionRight.aspx?id=" + node3.Value + "&level=C" ;
                                    node3.Target = "rframe";
                                    node2.ChildNodes.Add(node3);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
