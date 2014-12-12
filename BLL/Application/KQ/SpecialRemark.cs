using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Application.KQ
{
    public class SpecialRemark
    {
        public static List<v_KQ_SpecialRemark> databind()
        {
            using(DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.v_KQ_SpecialRemark.ToList();
            }
        }

        public static void deleteRecord(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                KQ_SpecialRemark s = dc.KQ_SpecialRemark.Where(i => i.Id == id).Single();
                dc.KQ_SpecialRemark.DeleteOnSubmit(s);
                dc.SubmitChanges();
            }
        }
        public static bool insertRecord(String username, String remark)
        {
             using(DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var users = dc.Users.Where(us => us.TrueName == username);
                 
                 if(users.Count()==1)
                 {
                     KQ_SpecialRemark s = new KQ_SpecialRemark();
                     s.userid = users.Single().Key;
                     s.remark = remark;

                     var has = dc.KQ_SpecialRemark.Where(h => h.userid == s.userid);
                     if (has.Count() > 0)
                         return false;
                     dc.KQ_SpecialRemark.InsertOnSubmit(s);
                     dc.SubmitChanges();
                 }
                
                 return true;
             }
        }
    }
}
