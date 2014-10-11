using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Application.KQ.Attendance
{
    public class ApplyApprove
    {
        public static List<sp_Attend_getHistoryResult> getAttendHistory(int attendId)
        {
            using(DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.sp_Attend_getHistory(attendId).ToList();
            }
        }
    }
}
