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

        public static void saveScheduling()
        {

        }
    }
}
