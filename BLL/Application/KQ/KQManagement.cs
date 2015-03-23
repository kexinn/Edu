using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BLL.Application.KQ
{
    public class KQManagement
    {
        public static List<KQ_PunchCardRecords> getTodayPunchCardRecord(int userid, char type = '3')//3为全部，1为上班，2为下班
        {
            String today = DateTime.Now.ToShortDateString();
            DateTime starttime = Convert.ToDateTime(today + " 00:00:00");
            DateTime endtime = Convert.ToDateTime(today + " 23:59:59");
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                if(type == '3')
                    return dc.KQ_PunchCardRecords.Where(k=>k.PunchCardUserId == userid && k.Time > starttime && k.Time < endtime).ToList();
                else
                    return dc.KQ_PunchCardRecords.Where(k=>k.PunchCardUserId == userid && k.Time > starttime && k.Time < endtime && k.PunchCardType == type).ToList();
            }
        }
        
        public static List<v_KQ_punchcard_record> getAppointRecordsByUsername(String username, DateTime start, DateTime end,int type)//1正常打卡的，2补卡的
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var result = dc.v_KQ_punchcard_record.Where(k=>k.Time >= start && k.Time <= end);
                if (!String.IsNullOrEmpty(username))
                    result = result.Where(k => k.username.Contains( username) );
                else if (String.IsNullOrEmpty(username) && type ==1)
                    result = result.Where(k => k.username == null);

                if (type == 2)
                    result = result.Where(k => k.fillCard != null);
                return result.ToList();
            }
        }
        public static List<KQ_PunchCardRecords> getAppointTimePunchCardRecords(int userid,DateTime start,DateTime end)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.KQ_PunchCardRecords.Where(k=>k.PunchCardUserId == userid && k.Time >= start && k.Time<= end).ToList();
            }
        }

        public class PunchCardStatiscs
        {
            public String jobnumber{get;set;}
            public String username{get;set;}
            public int order { get; set; }
            public int clockTotle{get;set;}
            public int clockOnNum{get;set;}
            public int clockOffNum{get;set;}
            public int lateTimes{get;set;}
            public int earlyTimes{get;set;}
        }
        public static List<PunchCardStatiscs> getStatiscByBetweenTime(DateTime start,DateTime end)
        {
            using(DataClassesEduDataContext dc = new DataClassesEduDataContext() )
            {
               

                var aa = from kq in dc.KQ_PunchCardRecords where kq.Time > start && kq.Time < end
                           group kq by kq.PunchCardUserId into group_kq
                           join user in dc.Users on group_kq.Key equals user.Key
                           where user.UserType == '1'
                           select new PunchCardStatiscs
                           {
                               jobnumber = user.JobNumber,
                               username = user.TrueName,
                               order= (user.orderNo == null)?0:(int)user.orderNo ,
                              clockTotle = group_kq.Count(),
                              clockOnNum = group_kq.Count(kq=>kq.PunchCardType == '1'),
                              clockOffNum = group_kq.Count(kq=>kq.PunchCardType == '2'),
                              lateTimes = group_kq.Count(kq=>kq.status == 1),
                              earlyTimes = group_kq.Count(kq=>kq.status == 2)
                           } ;
                return aa.OrderBy(a=>a.order).ToList<PunchCardStatiscs>();

            }
        }

        public class PunchCardUser
        {
            public String jobnumber { get; set; }
            public String username { get; set; }

            public String tel1 { get;set;}
            public String tel2 { get; set; }

            public int order { get; set; }
        }
        public static List<PunchCardUser> getStatiscNullByBetweenTime(DateTime start, DateTime end)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {

                var bb = from user in dc.Users
                         where user.UserType == '1' &&
                         !(from kq in dc.KQ_PunchCardRecords where kq.Time > start && kq.Time < end select kq.PunchCardUserId).Contains(user.Key)
                         select new PunchCardUser { jobnumber = user.JobNumber,username = user.TrueName,tel1=user.changhao,tel2=user.duanhao,order = (user.orderNo == null)?0:(int)user.orderNo};
                return bb.OrderBy(a=>a.order).ToList<PunchCardUser>();

            }
        }

        public static bool insertPunchCardRecordByType(String username,String date ,char type,String fillcard="",String fillcarduser="" )
        {
            try
            {
                using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
                {
                    DateTime starttime = Convert.ToDateTime(date + " 00:00:00");
                    DateTime endtime = Convert.ToDateTime(date + " 23:59:59");

                    Users user = dc.Users.Where(u => u.TrueName == username).Single();
                    var record = dc.KQ_PunchCardRecords.Where(k => k.PunchCardUserId == user.Key && k.Time > starttime && k.Time < endtime && k.PunchCardType == type);

                    if (record != null && record.Count() > 0)
                    {
                        return false;
                    }
                    KQ_PunchCardRecords kq = new KQ_PunchCardRecords();
                    kq.PunchCardUserId = user.Key;
                    kq.PunchCardType = type;
                    if (type == '1')
                        kq.Time = Convert.ToDateTime(date + " 07:20:00");
                    if (type == '2')
                        kq.Time = Convert.ToDateTime(date + " 16:50:00");
                    kq.IpAddress = "9.9.9.9";
                    kq.status = 0;
                    if (!String.IsNullOrEmpty(fillcard) && fillcarduser!="赵琦琼")
                    {
                        kq.fillCard = fillcard;
                        kq.fillcardUser = fillcarduser;
                        kq.fillCardTime = DateTime.Now;
                    }
                    dc.KQ_PunchCardRecords.InsertOnSubmit(kq);
                    dc.SubmitChanges();

                    return true;
                }
            } 
             catch(Exception ex)
            {
                throw ex;
            }
        }
        public static bool deletePunchCardRecord(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                KQ_PunchCardRecords k = dc.KQ_PunchCardRecords.Where(u => u.ID == id).Single();
                dc.KQ_PunchCardRecords.DeleteOnSubmit(k);
                dc.SubmitChanges();
                return true;
            }
        }
        public static bool insertPunchCardRecord(int userid,String ip,char type)
        {

            try
            {
                using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
                {
                    String today = DateTime.Now.ToShortDateString();
                    DateTime starttime = Convert.ToDateTime(today + " 00:00:00");
                    DateTime endtime = Convert.ToDateTime(today + " 23:59:59");

                    var record = dc.KQ_PunchCardRecords.Where(k => k.PunchCardUserId == userid && k.Time > starttime && k.Time < endtime && k.PunchCardType == type);

                    if (record != null && record.Count() > 0)
                    {
                        Exception e = new Exception("您已经打过卡");
                        throw e;
                    }

                    var recordip = dc.KQ_PunchCardRecords.Where(k =>k.IpAddress.Trim() == ip &&  k.Time > starttime && k.Time < endtime && k.PunchCardType == type);

                    if (recordip != null && recordip.Count() > 0)
                    {
                        Exception e = new Exception("该电脑已经打过卡");
                        throw e;
                    }
                    KQ_PunchCardRecords kq = new KQ_PunchCardRecords();
                    kq.PunchCardUserId = userid;
                    kq.PunchCardType = type;
                    kq.Time = DateTime.Now;
                    kq.IpAddress = ip;
                  /*  KQ_Set_time settime = dc.KQ_Set_time.First();
                    DateTime time = (DateTime)settime.CheckOnTime;
                    DateTime time_checkoff = (DateTime)settime.CheckOffTime;
                    int hour = time.Hour;
                    int minute = time.Minute;
                    int second = time.Second;

                    int houroff = time_checkoff.Hour;
                    int minuteoff = time_checkoff.Minute;
                    int secondoff = time_checkoff.Second;
                    switch (type)
                    {
                        case '1'://上班
                            if (DateTime.Now.Hour > hour)
                                kq.status = 1;//迟到
                            else if (DateTime.Now.Hour == hour && DateTime.Now.Minute > minute)
                                kq.status = 1;
                            else
                                kq.status = 0;
                            break;
                        case '2'://下班
                            if (DateTime.Now.Hour < houroff)
                                kq.status = 2;//早退
                            else if (DateTime.Now.Hour == houroff && DateTime.Now.Minute < minuteoff)
                                kq.status = 2;
                            else
                                kq.status = 0;
                            break;
                    }
                   // kq.ip1 = ips[0];
                    //kq.ip2 = ips[1];
                    //kq.ip3 = ips[2];
                    //kq.ip4 = ips[3];*/
                    dc.KQ_PunchCardRecords.InsertOnSubmit(kq);
                    dc.SubmitChanges();

                    return true;
                }
            }
             catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
