using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.pub;
using System.Linq.Expressions;

namespace BLL
{
    public partial class Users
    {

        public static RepositoryBase<Users, DataClassesEduDataContext> CreateRepository() { return new Users_Repository(); }
    }

    class Users_Repository : RepositoryBase<Users, DataClassesEduDataContext>
    {
        public Users_Repository()
        {
        }

        override protected Expression<Func<Users, bool>> GetIDSelector(int ID)
        {
            return (Item) => Item.Key == ID;
        }
    }
}
