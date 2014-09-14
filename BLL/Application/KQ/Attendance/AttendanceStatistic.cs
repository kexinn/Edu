using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Application.KQ.Attendance
{
    public class AttendanceStatistic
    {
        public static List<v_KQ_Attendance> getAttendanceRecords(String time,String username,String dept,String status,ref int tot, int index=0, int num=0)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                IQueryable<v_KQ_Attendance> attend = dc.v_KQ_Attendance;
                if(!String.IsNullOrEmpty(time))
                {
                    DateTime searchTime = Convert.ToDateTime(time).Date;
                    attend = attend.Where(i => Convert.ToDateTime(i.starttime).Date <= searchTime && searchTime <= Convert.ToDateTime(i.endtime).Date);
                }

                if (!String.IsNullOrEmpty(username))
                {
                    attend = attend.Where(u => u.username.Contains(username));
                }

                if (!String.IsNullOrEmpty(dept))
                {
                    attend = attend.Where(u => u.dept.Contains(dept));
                }

                if (!String.IsNullOrEmpty(status))
                {
                    attend = attend.Where(u => u.status.Contains(status));
                }

                tot = attend.Count();
                attend = attend.OrderByDescending(o => o.Id).Skip(index);
                if (num != 0)
                    attend = attend.Take(num);
                return attend.ToList();
            }
        }
    }
}
