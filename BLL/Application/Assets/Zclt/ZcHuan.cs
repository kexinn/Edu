using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using BLL;

namespace BLL.Application.Assets.Zclt
{
    public  class ZcHuan
    {
        public static Int32 GetUserIDbyUserName(string _UserName)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var _rs = dc.Users.Where(u => u.TrueName == _UserName);
                if (_rs.Count() == 1)
                {
                    return _rs.Single().Key;
                }
                else
                {
                    return -1;
                }
            }
        }

        public static v_AS_Jie  GetVJiebyZcTXM(string _ZcTXM)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var _rs = dc.v_AS_Jie.Where(u => u.ZcTXM == _ZcTXM);
                
                if (_rs.Count() == 1)
                {
                    return _rs.Single() ;
                }
                else
                {
                    return null ;
                }
            }
        }


        public static Int32 GetJieIDbyZcTXMfromVJie(string _ZcTXM)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var _rs = dc.v_AS_Jie.Where(u => u.ZcTXM == _ZcTXM);

                if (_rs.Count() == 1)
                {
                    return Convert.ToInt32(_rs.Single().JieID );
                }
                else
                {
                    return -1;
                }
            }
        }

        public static Int32 GetZcZTIDbyZcID(Int32 _ZcID)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var _rs = dc.v_AS_ZC.Where(u => u.ZcID == _ZcID);
                if (_rs.Count() == 1)
                {
                    return Convert.ToInt32(_rs.Single().ZTID);
                }
                else
                {
                    return -1;
                }
            }
        }

        public static Int32 GetZcIDbyJieID(Int32 _JieID)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var _rs = dc.AS_Jie.Where(u => u.JieID == _JieID);
                if (_rs.Count() == 1)
                {
                    return Convert.ToInt32(_rs.Single().ZcID);
                }
                else
                {
                    return -1;
                }
            }
        }

        public static bool createAS_Huan(AS_Huan _Huan)
        {
            try
            {
                using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
                {
                    dc.AS_Huan.InsertOnSubmit(_Huan);
                    dc.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static List<AS_Zc> GetAS_Zc()
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

        public static bool deleteAS_JiebyID(Int32  ID)
        {
            try
            {
                using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
                {
                    AS_Jie _jie = dc.AS_Jie.Where(u => u.JieID == ID).Single();
                    dc.AS_Jie.DeleteOnSubmit(_jie );
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

                foreach (AS_ZT r in _zt)
                {
                    ListItem li = new ListItem();
                    li.Text = r.ZT_Name;
                    li.Value = r.ZT_ID.ToString();
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

                foreach (AS_ZT zt in _ZT)
                {
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
