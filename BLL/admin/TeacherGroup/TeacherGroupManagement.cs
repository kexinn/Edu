using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.admin.TeacherGroup
{
    public class TeacherGroupManagement
    {
        public static bool createTeacherGroup(t_Teacher_Group group)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                dc.t_Teacher_Group.InsertOnSubmit(group);
                dc.SubmitChanges();
                return true;
            }
        }

        public static t_Teacher_Group getTeacherGroupById(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.t_Teacher_Group.Where(u => u.Id == id).Single();
            }
        }
        public static List<v_TeacherGroup> getDepartments()
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.v_TeacherGroup.ToList();
            }
        }

        public static List<v_TeacherGroupUsers> getTeacherGroupUsersByGroupId(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.v_TeacherGroupUsers.Where(u => u.TeacherGroupId == id).ToList();
            }
        }

        public static void setUserToTeacherGroup(int userid,int teacherGroupId)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                Users user = dc.Users.Where(u => u.Key == userid).Single();
                user.TeacherGroupId = teacherGroupId;
                dc.SubmitChanges();
            }
        }

        public static bool deleteTeacherGroupById(String id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                t_Teacher_Group group = dc.t_Teacher_Group.Where(d => d.Id == Convert.ToInt32(id)).Single();
                dc.t_Teacher_Group.DeleteOnSubmit(group);
                dc.SubmitChanges();
                return true;
            }
        }

        public static bool updateTeacherGroup(t_Teacher_Group group)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                t_Teacher_Group tGroup = dc.t_Teacher_Group.Where(u => u.Id == group.Id).Single();
                tGroup.Name = group.Name;
                tGroup.LeaderId = group.LeaderId;
                dc.SubmitChanges();
                return true;

            }
        }


    }
}
