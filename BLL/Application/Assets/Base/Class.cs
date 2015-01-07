using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using BLL;

namespace BLL.Application.Assets.Base
{
    public class Class
    {
        public static AS_Class0 getClass0ById(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.AS_Class0.Where(p => p.Class0ID == id).Single();
            }
        }

        public static void deleteClass0ById(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                AS_Class0 p = dc.AS_Class0.Where(pp => pp.Class0ID == id).Single();
                dc.AS_Class0.DeleteOnSubmit(p);
                dc.SubmitChanges();
            }
        }
        public static void createClass0(AS_Class0 p0)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                dc.AS_Class0.InsertOnSubmit(p0);
                dc.SubmitChanges();
            }
        }

        public static void updateClass0(AS_Class0 p0)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                AS_Class0 p = dc.AS_Class0.Where(o => o.Class0ID == p0.Class0ID).Single();
                p.Class0Name = p0.Class0Name;
                p.Class0BH = p0.Class0BH;
                p.Class0Remark = p0.Class0Remark;
                dc.SubmitChanges();
            }
        }

        public static AS_Class1 getClass1ById(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.AS_Class1.Where(p => p.Class1ID == id).Single();
            }
        }

        public static void updateClass1(AS_Class1 p1)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                AS_Class1 p = dc.AS_Class1.Where(o => o.Class1ID == p1.Class1ID).Single();
                p.Class1Name = p1.Class1Name;
                p.Class1BH = p1.Class1BH;
                p.Class1Remark = p1.Class1Remark;
                dc.SubmitChanges();
            }
        }
        public static void createClass1(AS_Class1 p1)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                dc.AS_Class1.InsertOnSubmit(p1);
                dc.SubmitChanges();
            }
        }

        public static void deleteClass1ById(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                AS_Class1 p = dc.AS_Class1.Where(pp => pp.Class1ID == id).Single();
                dc.AS_Class1.DeleteOnSubmit(p);
                dc.SubmitChanges();
            }
        }
        public static AS_Class2 getClass2ById(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.AS_Class2.Where(p => p.Class2ID == id).Single();
            }
        }
        public static void createClass2(AS_Class2 p2)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                dc.AS_Class2.InsertOnSubmit(p2);
                dc.SubmitChanges();
            }
        }

        public static void updateClass2(AS_Class2 p2)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                AS_Class2 p = dc.AS_Class2.Where(o => o.Class2ID == p2.Class2ID).Single();
                p.Class2Name = p2.Class2Name;
                p.Class2BH = p2.Class2BH;
                p.Class2Remark = p2.Class2Remark;
                dc.SubmitChanges();
            }
        }

        public static void deleteClass2ById(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                AS_Class2 p = dc.AS_Class2.Where(pp => pp.Class2ID == id).Single();
                dc.AS_Class2.DeleteOnSubmit(p);
                dc.SubmitChanges();
            }
        }

        public static AS_Class3 getClass3ById(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.AS_Class3.Where(p => p.Class3ID == id).Single();
            }
        }
        public static void createClass3(AS_Class3 p3)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                dc.AS_Class3.InsertOnSubmit(p3);
                dc.SubmitChanges();
            }
        }
        public static void updateClass3(AS_Class3 p3)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                AS_Class3 p = dc.AS_Class3.Where(o => o.Class3ID == p3.Class3ID).Single();
                p.Class3Name = p3.Class3Name;
                p.Class3BH = p3.Class3BH;
                p.Class3Remark = p3.Class3Remark;
                dc.SubmitChanges();
            }
        }
        public static void deleteClass3ById(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                AS_Class3 p = dc.AS_Class3.Where(pp => pp.Class3ID == id).Single();
                dc.AS_Class3.DeleteOnSubmit(p);
                dc.SubmitChanges();
            }
        }
        
        public static void getClassTree(ref TreeView tree)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var ps0 = dc.AS_Class0.OrderBy(o => o.Class0BH  ).ToList();
                TreeNode node00 = new TreeNode();
                node00.Text = "资产分类";
                node00.Value = "/";
                node00.NavigateUrl = "/Application/Assets/Base/ClassRight.aspx?level=/";
                node00.Target = "rframe";
                tree.Nodes.Add(node00);
                foreach (AS_Class0  p0 in ps0)
                {
                    TreeNode node0 = new TreeNode();
                    node0.Text = p0.Class0Name ;
                    node0.Value = "R" + p0.Class0ID.ToString();     //"R"=="root",表示0层
                    node0.NavigateUrl = "/Application/Assets/Base/ClassRight.aspx?id=" + node0.Value + "&level=R";
                    node0.Target = "rframe";
                    node00.ChildNodes.Add(node0);
                    var p1s = dc.AS_Class1.Where(u => u.Class0ID == p0.Class0ID).OrderBy(o=>o.Class1BH );
                    if (p1s.Count() > 0)
                    {
                        foreach (AS_Class1 p1 in p1s)
                        {
                            TreeNode node1 = new TreeNode();
                            node1.Text = p1.Class1Name;
                            node1.Value = node0.Value + "A" + p1.Class1ID.ToString();
                            node1.NavigateUrl = "/Application/Assets/Base/ClassRight.aspx?id=" + node1.Value + "&level=A";
                            node1.Target = "rframe";
                            node0.ChildNodes.Add(node1);
                            var p2s = dc.AS_Class2.Where(u2 => u2.Class1ID == p1.Class1ID ).OrderBy(o=>o.Class2BH );
                            if (p2s.Count() > 0)
                            {
                                foreach (AS_Class2 p2 in p2s)
                                {
                                    TreeNode node2 = new TreeNode();
                                    node2.Text = p2.Class2Name;
                                    node2.Value = node1.Value + "B" + p2.Class2ID.ToString();
                                    node2.NavigateUrl = "/Application/Assets/Base/ClassRight.aspx?id=" + node2.Value + "&level=B";
                                    node2.Target = "rframe";
                                    node1.ChildNodes.Add(node2);
                                    var p3s = dc.AS_Class3.Where(u3 => u3.Class2ID == p2.Class2ID).OrderBy(o => o.Class3BH);
                                    if (p3s.Count() > 0)
                                    {
                                        foreach (AS_Class3 p3 in p3s)
                                        {
                                            TreeNode node3 = new TreeNode();
                                            node3.Text = p3.Class3Name;
                                            node3.Value = node2.Value + "C" + p3.Class3ID.ToString();
                                            node3.NavigateUrl = "/Application/Assets/Base/ClassRight.aspx?id=" + node3.Value + "&level=C";
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
    }
}
