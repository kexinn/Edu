using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Application.KQ.Attendance
{
    public class  AttendanceManagement
    {
        public static KQ_Attendance getAttendanceById(int id)
        {
            using(DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.KQ_Attendance.Where(k => k.Id == id).Single();
            }
        }

        public static bool updateAttendance(KQ_Attendance kq)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                KQ_Attendance k = dc.KQ_Attendance.Where(i => i.Id == kq.Id).Single();
                k.typeid = kq.typeid;
                k.starttime = kq.starttime;
                k.endtime = kq.endtime;
                k.reason = kq.reason;
                k.daySpan = kq.daySpan;
                k.hourSpan = kq.hourSpan;
                dc.SubmitChanges();
                return true;
            }
        }
    }
}
