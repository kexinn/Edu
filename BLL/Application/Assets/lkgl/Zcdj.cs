using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using BLL;

namespace BLL.Application.Assets.lkgl
{
    public  class Zcdj
    {
        public static List<AS_Zc > GetAS_Zc()
        {

            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.AS_Zc.ToList();
            }
        }

        public static bool createAS_Zc(AS_Zc _Zc)
        {
            try
            {
                using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
                {
                    dc.AS_Zc.InsertOnSubmit(_Zc);
                    dc.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool deleteAS_ZCbyID(string ID)
        {
            try
            {
                using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
                {
                    AS_Zc _zc = dc.AS_Zc.Where(u => u.ZcID == Convert.ToInt32(ID)).Single();

                    dc.AS_Zc.DeleteOnSubmit(_zc );
                    dc.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static string get_TXM(string _TXM)
        {


            return _TXM;
        }

        public static void DDL_Zt_Databind(ref DropDownList ddl)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var _zt = dc.AS_ZT;

                foreach (AS_ZT  r in _zt )
                {
                    ListItem li = new ListItem();
                    li.Text = r.ZT_Name  ;
                    li.Value = r.ZT_ID.ToString() ;
                    ddl.Items.Add(li);
                }
            }
        }

        public static void dll_ZT_Databind(ref DropDownList ddl)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var class0 = dc.AS_Class0;

                foreach (AS_Class0 c in class0)
                {
                    ListItem li = new ListItem();
                    li.Text = c.Class0Name;
                    li.Value = c.Class0ID.ToString();
                    ddl.Items.Add(li);
                }

                var _ZT = dc.AS_ZT;

                foreach(AS_ZT zt in _ZT ){
                    ListItem li = new ListItem();
                    li.Text = zt.ZT_Name;
                    li.Value = zt.ZT_ID.ToString();
                    ddl.Items.Add(li);
                }
            }
        }


        //public static AS_DW getAS_DWbyID(Int32 id)
        //{
        //    try
        //    {
        //        using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
        //        {
        //            return dc.AS_DW.Where(u => u.DW_ID == id).Single();
        //        }
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        //public static bool updateDW(AS_DW dw)
        //{
        //    try
        //    {
        //        using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
        //        {
        //            AS_DW d = dc.AS_DW.Where(u => u.DW_ID == dw.DW_ID).Single();

        //            d.DW_Name = dw.DW_Name;
        //            d.DW_Remark = dw.DW_Remark;

        //            dc.SubmitChanges();
        //            return true;
        //        }
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }
}
