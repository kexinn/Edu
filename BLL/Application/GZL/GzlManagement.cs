using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Application.GZL
{
    public class GzlManagement
    {

        public static t_GZL_Item getItemById(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.t_GZL_Item.Where(i => i.ItemId == id).Single();
            }
        }

        public static bool createItem(t_GZL_Item item)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                dc.t_GZL_Item.InsertOnSubmit(item);
                dc.SubmitChanges();
                return true;
            }
        }
        public static bool insertTask(t_GZL_TaskList task)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                dc.t_GZL_TaskList.InsertOnSubmit(task);
                dc.SubmitChanges();
                return true;
            }
        }

        public static bool insertActorUser(t_GZL_actorUser actorUser)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                dc.t_GZL_actorUser.InsertOnSubmit(actorUser);
                dc.SubmitChanges();
                return true;
            }
        }

        public static bool insertTaskHistory(t_GZL_TaskHistory history)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                dc.t_GZL_TaskHistory.InsertOnSubmit(history);
                dc.SubmitChanges();
                return true;
            }
        }
    }
}
