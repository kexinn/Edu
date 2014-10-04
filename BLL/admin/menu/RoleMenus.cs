using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.admin.menu
{
    public class RoleMenus
    {
        public static List<MenuRole> getRoleMenuByRoleid(int roleid,int parentid)
        {
            using(DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var menus = from m in dc.t_Menu
                            where m.parentId == parentid
                            orderby m.Id
                            join ro in dc.t_Menu_Role.Where(e=>e.RoleKey == roleid) 
                            on m.Id equals ro.MenuKey
                            into tmp1
                            from n in tmp1.DefaultIfEmpty()
                            select new MenuRole
                            {
                                menuId = m.Id,
                                name = m.name,
                                url = m.url,
                                status = (bool)m.status,
                                auth =(n.RoleKey == null)?false:true,
                            };
                return menus.ToList();
            }
        }
        public class MenuRole
        {
            public int menuId { get; set; }
            public string name { get; set; }
            public string url { get; set; }
            public bool status { get; set; }
            public bool auth { get; set; }
        }

        public static void roleMenuAuthorize(int roleid,int menuid,bool auth)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                if (auth)
                {
                    t_Menu_Role mr = new t_Menu_Role();
                    mr.MenuKey = menuid;
                    mr.RoleKey = roleid;
                    dc.t_Menu_Role.InsertOnSubmit(mr);
                    dc.SubmitChanges();
                }else
                {
                    t_Menu_Role mr = dc.t_Menu_Role.Where(m => m.RoleKey == roleid && m.MenuKey == menuid).Single();
                    dc.t_Menu_Role.DeleteOnSubmit(mr);
                    dc.SubmitChanges();
                }
            }
        }

    }
}
