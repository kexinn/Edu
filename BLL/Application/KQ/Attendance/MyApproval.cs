using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Application.KQ.Attendance
{
    public class MyApproval
    {
        public static List<v_KQ_Attendance> getMyApprovalRecord(int approvalId, int index, int num, ref int tot)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                tot = dc.v_KQ_Attendance.Where(u => u.ApprovalId == approvalId).Count();
                var r = dc.v_KQ_Attendance.Where(u => u.ApprovalId == approvalId).OrderByDescending(o => o.Id).Skip(index).Take(num);
                return r.ToList();
            }
        }

        public static bool setAttendanceApplyStatus(int id ,String status)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                KQ_Attendance kq = dc.KQ_Attendance.Where(o => o.Id == id).Single();
                kq.status = status;
                dc.SubmitChanges();
                return true;
            }
        }
    }
}
