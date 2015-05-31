using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Application.KQ.Attendance
{
    public class MyAttendance
    {
        public static List<KQ_AttendanceType> getAttendanceType()
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var t = dc.KQ_AttendanceType.OrderBy(o=>o.orderNum);
                return t.ToList();
            }
        }

        public static int createApply(int userid,String username,DateTime starttime,DateTime endtime,int typeid,String reason,String dept,String fileurl,Decimal daySpan,int hourSpan,ref String tel)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
               int state =  dc.CreateAttendanceRecord(userid, username, starttime, endtime, typeid, reason, dept,fileurl,daySpan,hourSpan,ref tel);
                return state;
            }
        }

        public static KQ_Attendance getTopAttendRecordByUserid(int userid)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
               return dc.KQ_Attendance.Where(k => k.userid == userid).OrderByDescending(o=>o.Id).Take(1).Single();
            }
        }

        public static List<v_KQ_Attendance> getMyAttendanceRecord(int userid,int index,int num,ref int tot)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                tot = dc.v_KQ_Attendance.Where(u => u.userid == userid).Count();
                var r = dc.v_KQ_Attendance.Where(u => u.userid == userid).OrderByDescending(o => o.Id).Skip(index).Take(num);
                return r.ToList();
            }
        }

        public static bool deleteAttendanceRecord(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                KQ_Attendance att = dc.KQ_Attendance.Where(i => i.Id == id).Single();
                dc.KQ_Attendance.DeleteOnSubmit(att);
                dc.SubmitChanges();
                return true;
            }
        }

    }
}
