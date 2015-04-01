using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.pub;
using System.Linq.Expressions;

namespace BLL
{
    public partial class t_BX_PositionType
    {
        public static RepositoryBase<t_BX_PositionType, DataClassesEduDataContext> CreateRepository() { return new t_BX_PositionType_Repository(); }
   
    }

    public class t_BX_PositionType_Repository : RepositoryBase<t_BX_PositionType, DataClassesEduDataContext>
    {
        public t_BX_PositionType_Repository()
        {
        }

        override protected Expression<Func<t_BX_PositionType, bool>> GetIDSelector(int ID)
        {
            return (Item) => Item.Id == ID;
        }
    }
}
