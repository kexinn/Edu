using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.admin.role
{
    public class RoleManagement
    {
        public static List< Roles> getRoles()
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.Roles.ToList();
            }
        }

        public static Roles getRolesById(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.Roles.Where(u => u.Key == id).Single();
            }
        }

        public static bool insertRoleUser(User_Role ur)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                dc.User_Role.InsertOnSubmit(ur);
                dc.SubmitChanges();
                return true;

            }
        }
        public static void updateRole(Roles role)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                Roles r = dc.Roles.Where(u=>u.Key == role.Key).Single();
                r.Key = role.Key;
                r.Name = role.Name;
                r.Remark = role.Remark;
                dc.SubmitChanges();
            }
        }

        public static List<v_Role_Users> getUsersInRole(int roleid)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.v_Role_Users.Where(r => r.rolekey == roleid).ToList();
            }
        }

        public static bool ifUserInRole(int userid,int roleid)//管理员都返回true
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var rolemanage = dc.User_Role.Where(u => u.UserKey == userid && u.RoleKey == 1);
                if (rolemanage.Count() > 0)
                    return true;

                var role = dc.User_Role.Where(u => u.UserKey == userid && u.RoleKey == roleid );
                if (role.Count() > 0 )
                    return true;
                else
                    return false;
            }
        }
        public static List<v_User_Role> getRolesByUserId(int id)
        {
            
            using(DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
               return dc.v_User_Role.Where(u => u.Key == id).ToList();
            }
        }

        public static bool createRole(Roles role)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                dc.Roles.InsertOnSubmit(role);
                dc.SubmitChanges();
                return true;
            }
        }

        public static bool deleteRoleById(String id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                dc.DeleteRoles(Convert.ToInt32(id));
                return true;
            }
        }

        public static bool deleteRoleUserById(String id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                User_Role ur = dc.User_Role.Where(u => u.Key == Convert.ToInt32(id)).Single();
                dc.User_Role.DeleteOnSubmit(ur);
                dc.SubmitChanges();
                return true;
            }
        }
    }
}
