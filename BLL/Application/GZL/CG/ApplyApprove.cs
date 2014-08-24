using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace BLL.Application.GZL.CG
{
    public class ApplyApprove
    {
        public static List<v_GZL_MyTaskList> getTaskListByUserid(int userid)
        {
            using(DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {

                return dc.v_GZL_MyTaskList.Where(l => l.operateUserId == userid && l.ItemType == "采购单").ToList();
            }
        }
    }
}
