using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Application.KQ
{
    public class SchedulingManagement
    {
        public static List<KQ_Shift> getShift()
        {
            using(DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.KQ_Shift.ToList();
            }
        }

        public static List<KQ_Scheduling> getSchedulingList(int year,int month)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.KQ_Scheduling.Where(k => k.Year == year && k.Month == month).ToList();
            }
        }

        public static bool addShift(KQ_Shift sh)
        {
            using(DataClassesEduDataContext dc= new DataClassesEduDataContext())
            {
                dc.KQ_Shift.InsertOnSubmit(sh);
                dc.SubmitChanges();
                return true;
            }
        }

        public static bool deleteShift(string id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                KQ_Shift sh = dc.KQ_Shift.Where(k => k.Id == Convert.ToInt32(id)).Single();
                dc.KQ_Shift.DeleteOnSubmit(sh);
                dc.SubmitChanges();
                return true;
            }
        }

        public static void updateShift(KQ_Shift sh)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                KQ_Shift kq = dc.KQ_Shift.Where(k => k.Id == sh.Id).Single();
                kq.Name = sh.Name;
                kq.isClockOn = sh.isClockOn;
                kq.ClockOnTime = sh.ClockOnTime;
                kq.isClockOff = sh.isClockOff;
                kq.ClockOffTime = sh.ClockOffTime;
                kq.isDefault = sh.isDefault;
                kq.Remark = sh.Remark;
                dc.SubmitChanges();
            }
        }

        public static bool saveScheduling(List<KQ_Scheduling> list,int year,int month)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                try
                {
                    var sh = dc.KQ_Scheduling.Where(k => k.Year == year && k.Month == month);
                    if (sh.Count() > 0)
                        dc.KQ_Scheduling.DeleteAllOnSubmit(sh);
                    dc.KQ_Scheduling.InsertAllOnSubmit(list);
                    dc.SubmitChanges();
                    return true;
                }catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public class kq_para
        {
            public DateTime date { get; set; }
            public TimeSpan clockOnTime { get; set; }
            public TimeSpan clockOffTime { get; set; }
            public bool isClockOn { get; set; }
            public bool isClockOff { get; set; }

            public string weekday { get; set; }


        }
        //public class kq_report
        //{
        //    public int userid { get; set; }
        //    public DateTime date { get; set; }
        //    public DateTime shangbanTime { get; set; }

        //    public bool isChidao { get; set; }
        //    public DateTime xiabanTime { get; set; }
        //    public bool isZaotui { get; set; }
        //    public bool isQingjia { get; set; }
        //    public string qingjiaTime { get; set; }
        //    public bool isKuanggong { get; set; }
        //    public Int16 weekDay { get; set; }
        //}

    /*    public static void genReport(DateTime startdate,DateTime enddate)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var old = dc.KQ_Report.Where(k => k.date >= startdate && k.date <= enddate);
                dc.KQ_Report.DeleteAllOnSubmit(old);

                var users = dc.Users.Where(u => u.UserType == '1' && u.disabled == false).ToList();

                var result = from u in users
                             join dep in dc.Department on u.DepartmentId equals dep.ID
                             join p in dc.KQ_Scheduling.Where(u => u.Date >= startdate && u.Date <= enddate)
                             on dep.ParentId equals p.UserId

                             join c1 in dc.KQ_PunchCardRecords.Where(k => k.PunchCardType == '1')
                             on new { A= u.Key,B=p.Date.Value.ToShortDateString() } equals new {A= (int)(c1.PunchCardUserId),B=c1.Time.Value.ToShortDateString()}
                             into g1
                             from card1 in g1.DefaultIfEmpty()

                             join c2 in dc.KQ_PunchCardRecords.Where(k => k.PunchCardType == '2')
                             on new { A= u.Key,B=p.Date.Value.ToShortDateString() } equals new {A= (int)(c2.PunchCardUserId),B=c2.Time.Value.ToShortDateString()}
                             into g2
                             from card2 in g2.DefaultIfEmpty()
                             
                             join q in dc.KQ_Attendance.Where(a => (a.starttime <= p.date.AddHours(7).AddMinutes(50) && a.endtime >= p.date.AddHours(7).AddMinutes(50)) || (a.starttime >= p.date && a.starttime <= p.date.AddHours(16).AddMinutes(20))).GroupBy(g => g.userid)
                             on u.Key equals q.Key 
                             into g
                             from att in g.DefaultIfEmpty()

                             join q1 in dc.KQ_Attendance.Where(a => (a.starttime <= p.date.AddHours(7).AddMinutes(50) && a.endtime >= p.date.AddHours(7).AddMinutes(50)))
                             on u.Key equals q1.userid
                             into g3
                             from att1 in g3.DefaultIfEmpty()


                             join q2 in dc.KQ_Attendance.Where(a => (a.starttime <= p.date.AddHours(16).AddMinutes(20) && a.endtime >= p.date.AddHours(16).AddMinutes(20)))
                             on u.Key equals q2.userid
                             into g4
                             from att2 in g3.DefaultIfEmpty()
                             select new KQ_Report
                             {
                                 userid = u.Key,
                                 date = p.date,
                                 shangbanTime = (card1 != null) ? card1.Time.ToString() : "",
                                 isChidao = (card1 != null) ? (card1.Time - p.date) > p.clockOnTime : false,
                                 xiabanTime = (card2 != null) ? card2.Time.ToString() : "",
                                 isZaotui = (card2 != null) ? (card2.Time - p.date) < p.clockOffTime : false,
                                 isQingjia = (att != null),
                                 qingjiaTime = (att != null) ? att.Sum(a => a.daySpan) + "天" + att.Sum(a => a.hourSpan) + "小时" : "",
                                 isKuanggong = (p.isClockOn && card1 == null && att1 == null) || (p.isClockOff && card2 == null && att2 == null),
                                 isClockOn = p.isClockOn && (att1 != null),
                                 isClockOff = p.isClockOff && (att2 != null),
                                 weekDay = p.weekday

                             };
            }
        }*/

        public static void genReportByDate(DateTime startdate,DateTime enddate)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                try
                {
                    var old = dc.KQ_Report.Where(k => k.date >= startdate && k.date <= enddate);
                    dc.KQ_Report.DeleteAllOnSubmit(old);
                    var kq_paras = from k in dc.KQ_Scheduling
                                   where k.Date >= startdate && k.Date <= enddate
                                   join s in dc.KQ_Shift on k.ShiftId equals s.Id
                                   select new kq_para
                                   {
                                       date = (DateTime)k.Date,
                                       isClockOn = (bool)s.isClockOn,
                                       isClockOff = (bool)s.isClockOff,
                                       clockOnTime = TimeSpan.Parse(s.ClockOnTime),
                                       clockOffTime = TimeSpan.Parse(s.ClockOffTime),
                                       weekday = k.WeekDay.ToString()
                                   };

                    foreach (kq_para p in kq_paras)
                    {
                        var users = dc.Users.Where(u => u.UserType == '1' && u.disabled == false).ToList();

                        var list = from u in users
                                   join c1 in dc.KQ_PunchCardRecords.Where(k => k.Time >= p.date && k.Time <= p.date.AddDays(1) && k.PunchCardType == '1')
                                   on u.Key equals c1.PunchCardUserId
                                   into g1
                                   from card1 in g1.DefaultIfEmpty()

                                   join c2 in dc.KQ_PunchCardRecords.Where(k => k.Time >= p.date && k.Time <= p.date.AddDays(1) && k.PunchCardType == '2')
                                   on u.Key equals c2.PunchCardUserId
                                   into g2
                                   from card2 in g2.DefaultIfEmpty()


                                   join q in dc.KQ_Attendance.Where(a => (a.starttime <= p.date.AddHours(7).AddMinutes(50) && a.endtime >= p.date.AddHours(7).AddMinutes(50)) || (a.starttime >= p.date.AddHours(7).AddMinutes(50) && a.starttime <= p.date.AddHours(16).AddMinutes(20))).GroupBy(g=>g.userid)
                                   on u.Key equals q.Key
                                   into g
                                   from att in g.DefaultIfEmpty()

                                   join q1 in dc.KQ_Attendance.Where(a => (a.starttime <= p.date.AddHours(7).AddMinutes(50) && a.endtime >= p.date.AddHours(7).AddMinutes(50)))
                                   on u.Key equals q1.userid
                                   into g3
                                   from att1 in g3.DefaultIfEmpty()


                                   join q2 in dc.KQ_Attendance.Where(a => (a.starttime <= p.date.AddHours(16).AddMinutes(20) && a.endtime >= p.date.AddHours(16).AddMinutes(20)))
                                   on u.Key equals q2.userid
                                   into g4
                                   from att2 in g3.DefaultIfEmpty()
                                   select new KQ_Report
                                   {
                                       userid = u.Key,
                                       date = p.date,
                                       shangbanTime = (card1 != null) ? card1.Time.ToString() : "",
                                       isChidao = (card1 != null) ? (card1.Time - p.date) > p.clockOnTime : false,
                                       xiabanTime = (card2 != null) ? card2.Time.ToString() : "",
                                       isZaotui = (card2 != null) ? (card2.Time - p.date) < p.clockOffTime : false,
                                       isQingjia = (att != null),
                                       qingjiaTime = (att != null) ? att.Sum(a=>a.daySpan) + "天" + att.Sum(a=>a.hourSpan) + "小时" : "",
                                       isKuanggong = (p.isClockOn && card1 == null && att1 == null) || (p.isClockOff && card2 == null && att2 == null),
                                       isClockOn = p.isClockOn && (att1 == null),
                                       isClockOff = p.isClockOff && (att2 == null),
                                       weekDay = p.weekday

                                   };

                        dc.KQ_Report.InsertAllOnSubmit(list);
                        // return list.ToList();
                    }
                    // return null;
                    dc.SubmitChanges();
                }catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
