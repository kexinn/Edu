using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BLL.admin.menu
{
    public class MenuManagement
    {
        public static List<t_Menu> getMenus()
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.t_Menu.OrderBy(o=>o.Id).ToList();
            }
        }
        public static t_Menu getMenuById(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.t_Menu.Where(u=>u.Id==id).Single();
            }
        }

        public static void deleteMenu(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                t_Menu m =  dc.t_Menu.Where(u => u.Id == id).Single();
                dc.t_Menu.DeleteOnSubmit(m);
                dc.SubmitChanges();
            }
        }

        public static bool hasChildMenu(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var menus = dc.t_Menu.Where(m => m.parentId == id);
                if (menus.Count() > 0)
                    return true;
                else
                    return false;
            }
        }

        public static bool hasMenuRole(int menuid)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var menus = dc.t_Menu_Role.Where(m => m.MenuKey == menuid);
                if (menus.Count() > 0)
                    return true;
                else
                    return false;
            }
        }

        public static bool createMenu(t_Menu menu)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                dc.t_Menu.InsertOnSubmit(menu);
                dc.SubmitChanges();
                return true;
            }
        }
        public static bool updateMenu(t_Menu menu)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                t_Menu m = dc.t_Menu.Where(me=>me.Id == menu.Id).Single();
                m.name = menu.name;
                m.parentId = menu.parentId;
                m.url = menu.url;
                m.status = menu.status;
                dc.SubmitChanges();
               
                return true;
            }
        }

        public static void bindDropdownListNode(ref DropDownList ddl,int parentId)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var menuParent = dc.t_Menu.Where(m=>m.parentId ==0 && m.status == true).OrderBy(o=>o.Id);
                foreach(t_Menu m in menuParent)
                {
                    
                ListItem theItem = new ListItem();
                theItem.Text = m.name;
                theItem.Value = m.Id.ToString();
                if (m.Id == parentId)
                    theItem.Selected = true;
                ddl.Items.Add(theItem);
                AddItem(dc,ref ddl,m.Id, 1);
                }
            }
           
        }
        protected static void AddItem(DataClassesEduDataContext dc,ref DropDownList ddl, int id, int level)
        {
            string Str1 = "";
            int i = 0;
            var menus = dc.t_Menu.Where(m => m.status == true && m.parentId == id).OrderBy(o => o.Id);
            for (i = 1; i <= level; i++)
            {
                Str1 = Str1 + "|—";
            }
            foreach(t_Menu m in menus)
            {
                ListItem theItem = new ListItem();
                theItem.Text = Str1 + m.name;
                theItem.Value = m.Id.ToString();
                ddl.Items.Add(theItem);
                AddItem(dc,ref ddl, m.Id, level + 1);
            }
        }

    }
}
