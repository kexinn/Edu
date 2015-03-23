using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.admin.sys
{
    public class SysManage
    {
        public static void intsert(string name,string remark)
        {
            using(DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                t_Sys sys = new t_Sys();
                sys.name = name;
                sys.remark = remark;
                dc.t_Sys.InsertOnSubmit(sys);
                dc.SubmitChanges();
            }
        }

        

        public static List<t_Sys> databind()
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.t_Sys.ToList();
            }
        }

        public static void delete(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                t_Sys sys = dc.t_Sys.Where(i => i.Id == id).Single();
                dc.t_Sys.DeleteOnSubmit(sys);
                dc.SubmitChanges();
            }
        }
        public static void update(t_Sys sys)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {

                t_Sys s = dc.t_Sys.Where(i => i.Id == sys.Id).Single();
                s.name = sys.name;
                s.remark = sys.remark;
                dc.SubmitChanges();
            }
        }
    }
}
