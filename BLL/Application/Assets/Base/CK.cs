using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BLL.Application.Assets.Base
{
    public class CK
    {
        public static void databind(ref GridView gv,ref DropDownList ddl)
        {
            using(DataClassesASDataContext dc = new DataClassesASDataContext())
            {
                gv.DataSource = dc.v_AS_CK.OrderBy(o => o.Class0ID).ToList();
                gv.DataBind();

                var class0 = dc.AS_Class0;

                ddl.Items.Clear();

                foreach(AS_Class0 c in class0)
                {
                    ListItem li = new ListItem();
                    li.Text = c.Class0Name;
                    li.Value = c.Class0ID.ToString();
                    ddl.Items.Add(li);
                }
            }
        }
        public static bool createCK(AS_Ck ck)
        {
            using (DataClassesASDataContext dc = new DataClassesASDataContext())
            {
                dc.AS_Ck.InsertOnSubmit(ck);
                dc.SubmitChanges();
                return true;
            }
        }
        public static bool deleteCKById(String id)
        {
            using (DataClassesASDataContext dc = new DataClassesASDataContext())
            {
                AS_Ck  dl = dc.AS_Ck.Where(u =>u.CkID  == Convert.ToInt32(id)).Single();
                dc.AS_Ck.DeleteOnSubmit(dl);
                dc.SubmitChanges();
                return true;
            }
        }

        public static AS_Ck  getCKById(int id)
        {
            using (DataClassesASDataContext dc = new DataClassesASDataContext())
            {
                return dc.AS_Ck.Where(u => u.CkID  == id).Single();
            }
        }

        public static void updateCK(AS_Ck  ck)
        {
            using (DataClassesASDataContext dc = new DataClassesASDataContext())
            {
                AS_Ck  d = dc.AS_Ck.Where(u => u.CkID  == ck.CkID ).Single();

                d.CkName  = ck.CkName ;
                d.Class0ID  = ck.Class0ID ;
                d.CkRemark  = ck.CkRemark ;

                dc.SubmitChanges();
            }
        }

        public static void dllClass0Databind(ref DropDownList ddl)
        {
            using (DataClassesASDataContext dc = new DataClassesASDataContext())
            {
                var class0 = dc.AS_Class0;

                ddl.Items.Clear();

                foreach (AS_Class0 c in class0)
                {
                    ListItem li = new ListItem();
                    li.Text = c.Class0Name;
                    li.Value = c.Class0ID.ToString();
                    ddl.Items.Add(li);
                }
            }
        }
    }
}
