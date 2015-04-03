using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.pub;
using System.Linq.Expressions;

namespace BLL
{
    public partial class Region
    {
        public static RepositoryBase<Region, DataClassesEduDataContext> CreateRepository() { return new Region_Repository(); }
    }

    public class Region_Repository : RepositoryBase<Region, DataClassesEduDataContext>
    {
        public Region_Repository()
        {
        }

        override protected Expression<Func<Region, bool>> GetIDSelector(int ID)
        {
            return (Item) => Item.PARENT_ID == ID;
        }
    }
}
