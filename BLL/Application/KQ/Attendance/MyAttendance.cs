using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Application.KQ.Attendance
{
    public class MyAttendance
    {
        public static List<String> getAttendanceType()
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var t = dc.KQ_AttendanceType.Select(r => r.name);
                return t.ToList();
            }
        }

        public static bool createApply(int userid,String username,DateTime starttime,DateTime endtime,int typeid,String reason,String dept)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                dc.CreateAttendanceRecord(userid, username, starttime, endtime, typeid, reason, dept);
                return true;
            }
        }
    }
}
