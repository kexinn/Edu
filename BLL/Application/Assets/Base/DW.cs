using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Application.Assets.Base
{
    public class DW
    {
        public static List<AS_DW>  GetAS_DW()
        {
            using (DataClassesASDataContext dc = new DataClassesASDataContext())
            {
                return dc.AS_DW.ToList();
            }
        }

        public static bool createAS_DW(AS_DW dw)
        {
            try
            {
                using (DataClassesASDataContext dc = new DataClassesASDataContext())
                {
                    dc.AS_DW.InsertOnSubmit(dw);
                    dc.SubmitChanges();
                    return true;
                }
             }
             catch {
                  return false;
             }
        }

        public static bool deleteAS_DWbyID(string ID)
        {
            try
            {
                using(DataClassesASDataContext dc=new DataClassesASDataContext())
                {
                    AS_DW dw=dc.AS_DW.Where(u => u.DW_ID == Convert.ToInt32(ID )).Single();
                    dc.AS_DW.DeleteOnSubmit(dw);
                    dc.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static AS_DW getAS_DWbyID(Int32 id)
        {
            try
            {
                using (DataClassesASDataContext dc = new DataClassesASDataContext())
                {
                    return dc.AS_DW.Where(u => u.DW_ID == id).Single();
                }
            }
            catch
            {
                return null;
            }
        }

        public static bool  updateDW(AS_DW dw)
        {
            try
            {
                using (DataClassesASDataContext dc = new DataClassesASDataContext())
                {
                    AS_DW d = dc.AS_DW.Where(u => u.DW_ID == dw.DW_ID).Single();

                    d.DW_Name = dw.DW_Name;
                    d.DW_Remark = dw.DW_Remark;

                    dc.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
