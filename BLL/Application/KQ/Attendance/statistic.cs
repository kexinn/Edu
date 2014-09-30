using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Application.KQ.Attendance
{
    public class statistic
    {
        public static void calculateResult(DateTime starttime,DateTime endtime,String dept,String status,int typeid)
        {
            endtime = endtime.AddHours(23);
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                if (String.IsNullOrEmpty(dept))
                    dept = "";
                if (String.IsNullOrEmpty(status))
                    status = "";
                dc.sp_KQ_select_into_temp(starttime, endtime,dept,status,typeid);

                var records = dc.KQ_Attendance_Tmp;
                foreach(KQ_Attendance_Tmp r in records)
                {
                    Decimal daySpan =0;
                    int hourSpan =0;

                    DateTime applyStartTime = (DateTime)r.starttime;
                    DateTime applyEndTime = (DateTime)r.endtime;

                    if(applyStartTime >= starttime && applyEndTime <= endtime)
                    {
                        //if(r.daySpan !=null)
                        //    daySpan = (Decimal)r.daySpan;
                        //if(r.hourSpan !=null)
                        //    hourSpan = (int)r.hourSpan;
                        BLL.Application.KQ.Attendance.AttendanceStatistic.getSpanDateTime(applyStartTime, applyEndTime, ref daySpan, ref hourSpan);
                    }else  if(applyStartTime < starttime && applyEndTime > starttime && applyEndTime < endtime)
                    {
                        BLL.Application.KQ.Attendance.AttendanceStatistic.getSpanDateTime(starttime, applyEndTime, ref daySpan, ref hourSpan);
                        
                    }else if (applyStartTime > starttime && applyStartTime < endtime && applyEndTime > endtime)
                    {
                        BLL.Application.KQ.Attendance.AttendanceStatistic.getSpanDateTime(applyStartTime, endtime, ref daySpan, ref hourSpan);

                    }else if(applyStartTime < starttime && applyEndTime > endtime)
                    {
                        BLL.Application.KQ.Attendance.AttendanceStatistic.getSpanDateTime(starttime, endtime, ref daySpan, ref hourSpan);
                    }

                    r.realDaySpan = daySpan;
                    r.realHourSpan = hourSpan;

                }
                dc.SubmitChanges();

                dc.ExecuteCommand("TRUNCATE TABLE KQ_Attendance_Statistic");

                var statistic = from attend in dc.KQ_Attendance_Tmp
                                group attend by attend.userid into g

                                select new Attendance_Statistic
                                {
                                    userid = (int)g.Key,
                                    count = g.Count(),
                                    daySpan = (Decimal)g.Sum(x=>x.realDaySpan),
                                    hourSpan = (int)g.Sum(x=>x.realHourSpan)
                                };
                if (statistic != null && statistic.Count() > 0)
                {
                    foreach (Attendance_Statistic t in statistic)
                    {
                        KQ_Attendance_Statistic tj = new KQ_Attendance_Statistic();
                        tj.userid = t.userid;
                        tj.count = t.count;
                        tj.daySpan = t.daySpan;
                        tj.hourSpan = t.hourSpan;

                        tj.daySpan += tj.hourSpan / 5;
                        tj.daySpan += ((tj.hourSpan % 5) / 3) == 1 ? 0.5M : 0;
                        tj.hourSpan = (tj.hourSpan % 5) % 3;
                        dc.KQ_Attendance_Statistic.InsertOnSubmit(tj);
                    }
                    dc.SubmitChanges();
                }
            }
        }
        public class Attendance_Statistic
        {
            public int userid { get; set; }
            public int count { get; set; }
            public Decimal daySpan { get; set; }
            public int hourSpan { get; set; }
        }

    }
}
