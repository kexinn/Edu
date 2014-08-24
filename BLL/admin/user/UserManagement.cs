using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data.Linq;
using System.Data;


namespace BLL.admin.user
{
    public class  UserManagement
    {

        public static List<Users> getUsers(int indexPg, int pgSize,ref pub.PagerTClass pageT,String XMPY = "")
        {
            
            IEnumerable<Users> u;
          
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                if (!String.IsNullOrEmpty(XMPY))
                {
                    u = dc.Users.Where(us => us.XMPY.Contains(XMPY));
                }
                else
                {
                    u = dc.Users;
                }

                u = pageT.ShowPage(u, indexPg, pgSize);
                return u.ToList();
            }
        }

        public static List<Users> getUsersByTruename(String name)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
               return dc.Users.Where(u => u.TrueName.Contains(name)).ToList();
            }
        }

        public static String[] getUsersName(string name,int count)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                List<String> listUsers = new List<String>();
                var users = dc.Users.Where(u => u.TrueName.Contains(name)).Take(count);
                foreach (Users u in users)
                {
                    listUsers.Add(u.TrueName);
                }
                return listUsers.ToArray();
                //return dc.Users.Where(u => u.TrueName.Contains(name)).Select<.ToList();
            }
        }
        public static Users getUserById(int id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var us = dc.Users.Where(u => u.Key == id);

                if (us != null && us.Count() == 1)
                    return us.Single();
                else
                    return null;
            }
        }

        public static Users getUserByNetid(String netid,String pwd)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var us = dc.Users.Where(u => u.XMPY == netid && u.Password == pub.PubClass.MD5(pwd));

                if (us!=null && us.Count()==1)
                    return us.Single();
                else
                    return null;
            }
        }

        public static bool DeleteUserById(String id)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                dc.DeleteUser(Convert.ToInt32(id));
                dc.SubmitChanges();
                return true;
            }
        }

        public static bool CreatUser(String TrueName,String XMPY)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                string passwd = "000000";

               dc.CreateUser(XMPY, TrueName, BLL.pub.PubClass.MD5(passwd), XMPY + "@sina.com", Guid.NewGuid().ToString().ToUpper().Replace("-", ""));

                dc.SubmitChanges();

            }
            return true;
        }

        public static bool UpdateUser(int userid,String XMPY,String TrueName,String Pwd,String JobNumber,int DepartmentId)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                Users user = dc.Users.Where(u => u.Key == userid).Single();


                user.XMPY = XMPY;
                user.TrueName = TrueName;
                user.JobNumber = JobNumber;
                user.DepartmentId = DepartmentId;


                if (!String.IsNullOrEmpty(Pwd))
                {

                    user.Password = pub.PubClass.MD5(Pwd);
                }
                dc.SubmitChanges();
                return true;
            }
        }

        /// <summary>
        /// 将Dataset的数据导入数据库
        /// </summary>
        /// <param name="pds">数据集</param>
        /// <returns></returns>
        public static bool AddDatasetToUsers(DataSet pds)
        {
            int ic, ir;
            ic = pds.Tables[0].Columns.Count;

            ir = pds.Tables[0].Rows.Count;
            if (pds != null && pds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < pds.Tables[0].Rows.Count; i++)
                {
                    Users user = new Users();
                    String xmpy = "";
                    String truename = "";
                    if (pds.Tables[0].Rows[i][0] != null)

                        xmpy = pds.Tables[0].Rows[i][0].ToString().Trim();
                    if (pds.Tables[0].Rows[i][1] != null)
                        truename = pds.Tables[0].Rows[i][1].ToString().Trim();
                    CreatUser(truename, xmpy);

                }
            }
            else
            {
                throw new Exception("导入数据为空！");
            }
            return true;
        }
    }
}
