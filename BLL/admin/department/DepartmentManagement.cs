using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.admin.department
{
    public class DepartmentManagement
    {
        public static List<Department> getDepartments()
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.Department.ToList();
            }
        }

        public static bool userInDepartment(int deptId,int userid)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var dept = dc.Department_leader.Where(d => d.department_id == deptId && d.leader_id == userid);
                if (dept.Count() > 0)
                    return true;
                else
                    return false;
            }
        }
        public static List<v_Deparment_Headmaster> get_vDepartments()
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.v_Deparment_Headmaster.ToList();
            }
        }

        public static Department getDepartmentById(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.Department.Where(u => u.ID == id).Single();
            }
        }

        public static Department_leader getDepartmentByUserid(int userid)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var dp = dc.Department_leader.Where(d => d.leader_id == userid);
                if (dp.Count() > 0)
                    return dp.Single();
                else
                    return null;

            }
        }
        public static List<v_Deparment_Leader> getDepartmentLeadersByDepartmentId(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                return dc.v_Deparment_Leader.Where(d=>d.DepartmentId == id).ToList();
            }
        }

        public static bool insertIntoDepartmentLeader(Department_leader dl)
        {

            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                dc.Department_leader.InsertOnSubmit(dl);
                dc.SubmitChanges();
                return true;

            }
        }

        public static bool deleteDepartmentLeaderById(String id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                Department_leader dl = dc.Department_leader.Where(u => u.ID == Convert.ToInt32(id)).Single();
                dc.Department_leader.DeleteOnSubmit(dl);
                dc.SubmitChanges();
                return true;
            }
        }

        public static void updateDepartment(Department dep)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                Department d = dc.Department.Where(u => u.ID == dep.ID).Single();
                
                d.Name = dep.Name;
                d.Description = dep.Description;
                d.HeadmasterId = dep.HeadmasterId;
                dc.SubmitChanges();
            }
        }

        public static bool createDepartment(Department dep)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                dc.Department.InsertOnSubmit(dep);
                dc.SubmitChanges();
                return true;
            }
        }


        public static bool deleteDepartmentById(String id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                Department dep = dc.Department.Where(d => d.ID == Convert.ToInt32(id)).Single();
                dc.Department.DeleteOnSubmit(dep);
                dc.SubmitChanges();
                return true;
            }
        }
    }
}
