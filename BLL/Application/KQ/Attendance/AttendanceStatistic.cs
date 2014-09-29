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
        //计算两日期间隔天数和小时数
        public static void getSpanDateTime(DateTime datestart, DateTime dateend, ref Decimal daySpan, ref int timeSpan)
        {
            TimeSpan dayMorStartTime = new TimeSpan(7, 40, 0);
            TimeSpan dayMorEndTime = new TimeSpan(11, 30, 0);
            TimeSpan dayNoonStartTime = new TimeSpan(13, 0, 0);
            TimeSpan dayNoonEndTime = new TimeSpan(16, 30, 0);

            TimeSpan datespan = dateend - datestart;

            if (datestart.DayOfYear == dateend.DayOfYear) //只请假一天以内的
            {
                daySpan = 0;

                if (datestart.TimeOfDay < dayMorStartTime)
                {
                    if (dateend.TimeOfDay <= dayMorEndTime)
                        timeSpan = (dateend.TimeOfDay - dayMorStartTime).Hours;
                    else if (dateend.TimeOfDay <= dayNoonStartTime)
                        timeSpan = (dayMorEndTime - dayMorStartTime ).Hours;
                    else if (dateend.TimeOfDay <= dayNoonEndTime)
                        timeSpan = (dateend.TimeOfDay - dayMorStartTime - (dayNoonStartTime - dayMorEndTime)).Hours;
                    else
                        timeSpan = (dateend.TimeOfDay - dayMorStartTime - (dayNoonStartTime - dayMorEndTime) - (dateend.TimeOfDay - dayNoonEndTime)).Hours;


                }
                else if (datestart.TimeOfDay >= dayMorStartTime && datestart.TimeOfDay < dayMorEndTime)
                {
                    if (dateend.TimeOfDay <= dayMorEndTime)
                        timeSpan = (dateend.TimeOfDay - datestart.TimeOfDay).Hours;
                    else if (dateend.TimeOfDay <= dayNoonStartTime)
                        timeSpan = (dayMorEndTime - datestart.TimeOfDay ).Hours;
                    else if (dateend.TimeOfDay <= dayNoonEndTime)
                        timeSpan = (dateend.TimeOfDay - datestart.TimeOfDay - (dayNoonStartTime - dayMorEndTime)).Hours;
                    else
                        timeSpan = (dateend.TimeOfDay - datestart.TimeOfDay - (dayNoonStartTime - dayMorEndTime) - (dateend.TimeOfDay - dayNoonEndTime)).Hours;

                }
                else if (datestart.TimeOfDay >= dayMorEndTime && datestart.TimeOfDay < dayNoonStartTime)
                {

                    if (dateend.TimeOfDay <= dayNoonStartTime)
                        timeSpan = 0;
                    else if (dateend.TimeOfDay <= dayNoonEndTime)
                        timeSpan = (dateend.TimeOfDay - datestart.TimeOfDay - (dayNoonStartTime - datestart.TimeOfDay)).Hours;
                    else
                        timeSpan = (dateend.TimeOfDay - datestart.TimeOfDay - (dayNoonStartTime - datestart.TimeOfDay) - (dateend.TimeOfDay - dayNoonEndTime)).Hours;

                }
                else if (datestart.TimeOfDay >= dayNoonStartTime && datestart.TimeOfDay < dayNoonEndTime)
                {
                    if (dateend.TimeOfDay <= dayNoonEndTime)
                        timeSpan = (dateend.TimeOfDay - datestart.TimeOfDay).Hours;
                    else
                        timeSpan = (dateend.TimeOfDay - datestart.TimeOfDay - (dateend.TimeOfDay - dayNoonEndTime)).Hours;

                }
                else
                    timeSpan = 0;

                if (timeSpan / 5 == 1)
                {
                    daySpan = 1; timeSpan = 0;
                }else if(timeSpan /3 ==1)
                {
                    daySpan = 0.5M; timeSpan = 0;
                }


            }
            else if (dateend.DayOfYear - datestart.DayOfYear > 1) //请假一天以上的
            {
                daySpan = (dateend.DayOfYear - datestart.DayOfYear - 1); //中间天数
                TimeSpan ts1;
                TimeSpan ts2;
                if (datestart.TimeOfDay < dayMorStartTime) //第一天计算小时数
                {
                    ts1 = dayMorEndTime - dayMorStartTime + (dayNoonEndTime - dayNoonStartTime);

                }
                else if (datestart.TimeOfDay >= dayMorStartTime && datestart.TimeOfDay < dayMorEndTime)
                {
                    ts1 = dayNoonEndTime - datestart.TimeOfDay - (dayNoonStartTime - dayMorEndTime);
                }
                else if (datestart.TimeOfDay >= dayMorEndTime && datestart.TimeOfDay < dayNoonStartTime)
                {

                    ts1 = dayNoonEndTime - dayNoonStartTime;
                }
                else if (datestart.TimeOfDay >= dayNoonStartTime && datestart.TimeOfDay < dayNoonEndTime)
                {
                    ts1 = dayNoonEndTime - datestart.TimeOfDay;
                }
                else
                    ts1 = new TimeSpan(0);

                if (ts1.Hours / 5 == 1)
                {
                    daySpan += 1; timeSpan = 0;
                }
                else if (ts1.Hours / 3 == 1)
                {
                    daySpan += 0.5M; timeSpan = 0;
                }


                if (dateend.TimeOfDay < dayMorStartTime)//最后一天计算小时数
                {
                    ts2 = new TimeSpan(0);

                }
                else if (dateend.TimeOfDay >= dayMorStartTime && dateend.TimeOfDay < dayMorEndTime)
                {
                    ts2 = dateend.TimeOfDay - dayMorStartTime;
                }
                else if (dateend.TimeOfDay >= dayMorEndTime && dateend.TimeOfDay < dayNoonStartTime)
                {

                    ts2 = dayMorEndTime - dayMorStartTime;
                }
                else if (dateend.TimeOfDay >= dayNoonStartTime && dateend.TimeOfDay < dayNoonEndTime)
                {
                    ts2 = dayMorEndTime - dayMorStartTime + dateend.TimeOfDay - dayNoonStartTime;
                }
                else
                    ts2 = dayMorEndTime - dayMorStartTime + dayNoonEndTime - dayNoonStartTime;


                if (ts2.Hours / 5 == 1)
                {
                    daySpan += 1; timeSpan = 0;
                }
                else if (ts2.Hours / 3 == 1)
                {
                    daySpan += 0.5M; timeSpan = 0;
                }

            }
        }
    }
}
