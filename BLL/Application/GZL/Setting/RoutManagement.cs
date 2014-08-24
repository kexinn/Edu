using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Application.GZL.Setting
{
    public class RoutManagement
    {
        public static List<t_GZL_Rout> getRoutList()
        {
            using(DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {

                return dc.t_GZL_Rout.ToList();
            }
        }

        public static t_GZL_Rout getRoutById(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.t_GZL_Rout.Where(r => r.routId == id).Single();
            }
        }

        public static bool updateRout(t_GZL_Rout rout)
        {
            using(DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                t_GZL_Rout d = dc.t_GZL_Rout.Where(u => u.routId == rout.routId).Single();
                
                d.routName = rout.routName;
                d.version = rout.version;
                dc.SubmitChanges();
                return true;
            }
        }

        public static bool updateRoutState(int id,String state)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                t_GZL_Rout rout = dc.t_GZL_Rout.Where(r => r.routId == id).Single();
                rout.State = state;
                dc.SubmitChanges();
                return true;
            }

        }
        public static bool createRout(t_GZL_Rout rout)
        {
            using(DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                dc.t_GZL_Rout.InsertOnSubmit(rout);
                dc.SubmitChanges();
                return true;
            }
        }

        public static bool deleteRoutById(String id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                t_GZL_Rout rout = dc.t_GZL_Rout.Where(d => d.routId == Convert.ToInt32(id)).Single();
                dc.t_GZL_Rout.DeleteOnSubmit(rout);
                dc.SubmitChanges();
                return true;
            }
        }
    }
}