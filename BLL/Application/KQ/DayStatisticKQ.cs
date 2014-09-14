using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Application.KQ
{
    public class DayStatisticKQ
    {

        public class DayPunchCardStatiscs
        {
            public String 工号 { get; set; }
            public String 姓名 { get; set; }
            public int 序号 { get; set; }
            public DateTime 打卡时间 { get; set; }
            public byte 状态 { get; set; }
            public char 打卡类型 { get; set; }
            public String 电话 { get; set; }
        }
        public static List<DayPunchCardStatiscs> getStatiscByBetweenTime(DateTime start, DateTime end,char type,byte status)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var aa = from kq in dc.KQ_PunchCardRecords
                         where kq.Time > start && kq.Time < end && kq.PunchCardType == type && kq.status == status
                         join user in dc.Users on kq.PunchCardUserId equals user.Key
                         where user.UserType == '1'
                         select new DayPunchCardStatiscs
                         {
                             工号 = user.JobNumber,
                             姓名 = user.TrueName,
                             电话 = user.duanhao,
                             序号 = (user.orderNo == null) ? 0 : (int)user.orderNo,
                             打卡时间 = (DateTime)kq.Time,
                             打卡类型 = (char)kq.PunchCardType,
                             状态 = (byte)kq.status
                         };
                return aa.OrderBy(a => a.序号).ToList<DayPunchCardStatiscs>();

            }
        }


        public class DayPunchCardUser
        {
            public String 工号 { get; set; }
            public String 姓名 { get; set; }

            public String 电话长号 { get; set; }
            public String 电话短号 { get; set; }

            public int 序号 { get; set; }
        }
        public static List<DayPunchCardUser> getStatiscNullByBetweenTime(DateTime start, DateTime end, char type, byte status)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {

                var bb = from user in dc.Users
                         where user.UserType == '1' &&
                         !(from kq in dc.KQ_PunchCardRecords where kq.PunchCardType == type && kq.status == status && kq.Time > start && kq.Time < end select kq.PunchCardUserId).Contains(user.Key)
                         select new DayPunchCardUser { 工号 = user.JobNumber,  姓名 = user.TrueName,  电话长号 = user.changhao,  电话短号 = user.duanhao, 序号  = (user.orderNo == null) ? 0 : (int)user.orderNo };
                return bb.OrderBy(a => a.序号).ToList<DayPunchCardUser>();

            }
        }
    }
}
