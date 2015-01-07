using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Application.Assets.Base
{
    public  class ZT
    {
        public static List<AS_ZT> GetAS_ZT()
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.AS_ZT.ToList();
            }
        }

        public static bool createAS_ZT(AS_ZT ZT)
        {
            try
            {
                using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
                {
                    dc.AS_ZT.InsertOnSubmit(ZT);
                    dc.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool deleteAS_ZTbyID(string ID)
        {
            try
            {
                using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
                {
                    AS_ZT ZT = dc.AS_ZT.Where(u => u.ZT_ID == Convert.ToInt32(ID)).Single();
                    dc.AS_ZT.DeleteOnSubmit(ZT);
                    dc.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static AS_ZT getAS_ZTbyID(Int32 id)
        {
            try
            {
                using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
                {
                    return dc.AS_ZT.Where(u => u.ZT_ID == id).Single();
                }
            }
            catch
            {
                return null;
            }
        }

        public static bool updateZT(AS_ZT ZT)
        {
            try
            {
                using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
                {
                    AS_ZT d = dc.AS_ZT.Where(u => u.ZT_ID == ZT.ZT_ID).Single();

                    d.ZT_Name = ZT.ZT_Name;
                    d.ZT_Remark = ZT.ZT_Remark;

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
