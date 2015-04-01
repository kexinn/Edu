using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.pub;
using System.Linq.Expressions;

namespace BLL
{
    public partial class KQ_Attendance
    {

        public static RepositoryBase<KQ_Attendance, DataClassesEduDataContext> CreateRepository() { return new KQ_Attendance_Repository(); }
    }

    public class KQ_Attendance_Repository : RepositoryBase<KQ_Attendance, DataClassesEduDataContext>
    {
        public KQ_Attendance_Repository()
        {
        }

        override protected Expression<Func<KQ_Attendance, bool>> GetIDSelector(int ID)
        {
            return (Item) => Item.Id == ID;
        }
    }
}
