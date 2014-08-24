using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Login
    {
        public static Users getUser(String xmpy)
        {
            using(DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var user = dc.Users.Where(u => u.XMPY == xmpy);
                if (user.Count() == 1)
                    return user.Single();
                else
                    return null; 
            }
        }
    }
}
