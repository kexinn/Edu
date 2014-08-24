using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace BLL.Application
{
     public class RoutTask
    {
         public static List<t_User_Task> getRoutTask(int userid)
         {
             using(DataClassesEduDataContext dc = new DataClassesEduDataContext())
             {
                 return dc.t_User_Task.Where(u => u.userid == userid && u.isClick == false).Take(6).ToList();
             }
         }

         public static t_User_Task rout(int id)
         {
             using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
             {
                 t_User_Task task = dc.t_User_Task.Where(u => u.Id == id).Single();
                 task.isClick = true;
                 dc.SubmitChanges();
                 return task;
             }
         }

         public static int getTaskNumByUserId(int userid)
         {
             using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
             {
                 return dc.t_User_Task.Where(u => u.userid == userid && u.isClick == false).Count();
             }
         }
    }
}
