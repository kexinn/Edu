using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.pub;
using System.Linq.Expressions;

namespace BLL
{
    public partial class t_BX_FormItem
    {
        public static RepositoryBase<t_BX_FormItem, DataClassesEduDataContext> CreateRepository() { return new t_BX_FormItem_Repository(); }
    }


    public class t_BX_FormItem_Repository : RepositoryBase<t_BX_FormItem, DataClassesEduDataContext>
    {
        public t_BX_FormItem_Repository()
        {
        }

        override protected Expression<Func<t_BX_FormItem, bool>> GetIDSelector(int ID)
        {
            return (Item) => Item.Id == ID;
        }

    }
}
