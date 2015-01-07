using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Application.Assets.Base
{
    public  class UseQk
    {
        public static List<AS_UseQk> GetAS_UseQk()
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.AS_UseQk.ToList();
            }
        }

        public static bool createAS_UseQk(AS_UseQk UseQk)
        {
            try
            {
                using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
                {
                    dc.AS_UseQk.InsertOnSubmit(UseQk);
                    dc.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool deleteAS_UseQkbyID(string ID)
        {
            try
            {
                using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
                {
                    AS_UseQk UseQk = dc.AS_UseQk.Where(u => u.UseQk_ID == Convert.ToInt32(ID)).Single();
                    dc.AS_UseQk.DeleteOnSubmit(UseQk);
                    dc.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static AS_UseQk getAS_UseQkbyID(Int32 id)
        {
            try
            {
                using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
                {
                    return dc.AS_UseQk.Where(u => u.UseQk_ID == id).Single();
                }
            }
            catch
            {
                return null;
            }
        }

        public static bool updateUseQk(AS_UseQk UseQk)
        {
            try
            {
                using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
                {
                    AS_UseQk d = dc.AS_UseQk.Where(u => u.UseQk_ID == UseQk.UseQk_ID).Single();

                    d.UseQk_Name = UseQk.UseQk_Name;
                    d.UseQk_Remark = UseQk.UseQk_Remark;

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
