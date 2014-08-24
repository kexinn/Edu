using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Application.GZL.Setting
{
    public class ActorManagement
    {
        public static List<t_GZL_Actor> getActorsByRoutId(int routid)
        {
            using(DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.t_GZL_Actor.Where(a => a.routId == routid).OrderBy(u=>u.sortNo).ToList();
            }
        }

        public static t_GZL_Actor getActorForNextSortByRoutId(int routid,int sortNO)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                if (dc.t_GZL_Actor.Where(a => a.routId == routid).Count() > sortNO)
                    return dc.t_GZL_Actor.Where(a => a.routId == routid).OrderBy(u => u.sortNo).Skip(sortNO).Take(1).Single();
                else
                    return null;
            }
        }
        public static t_GZL_Actor getActorById(int id)
        {
            using(DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.t_GZL_Actor.Where(a => a.actorId == id).Single();
            }
        }
        public static bool creatActor(t_GZL_Actor actor)
        {
            using(DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                dc.t_GZL_Actor.InsertOnSubmit(actor);
                dc.SubmitChanges();
                return true;
            }
        }

        public static bool deleteActorById(String id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                t_GZL_Actor actor = dc.t_GZL_Actor.Where(d => d.actorId == Convert.ToInt32(id)).Single();
                dc.t_GZL_Actor.DeleteOnSubmit(actor);
                dc.SubmitChanges();
                return true;
            }
        }

        public static bool updateActor(t_GZL_Actor actor)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                t_GZL_Actor a = dc.t_GZL_Actor.Where(u => u.actorId == actor.actorId).Single();

                a.actorName = actor.actorName;
                a.sortNo = actor.sortNo;
                dc.SubmitChanges();
                return true;
            }
        }
    }
}
