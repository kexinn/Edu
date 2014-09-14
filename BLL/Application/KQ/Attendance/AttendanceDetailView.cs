using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Application.KQ.Attendance
{
    public class AttendanceDetailView
    {
        public static v_KQ_Attendance getAttendanceDetail(int id)
        {
            using(DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.v_KQ_Attendance.Where(u => u.Id == id).Single();

            }

        }
    }
}
