﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Web;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

namespace BLL.pub
{
    public class PubClass
    {
        public const int PAGE_SIZE = 15;

        public static String getConnectionString()
        {
            return System.Configuration.ConfigurationManager.AppSettings["EduConnectionString"];
        }

        public static void showAlertMessage(Page p, ClientScriptManager ClientScript, string message)
        {
           ClientScript.RegisterStartupScript(p.GetType(),"", "<script>alert('"+message+"');<" + "/script>");
        }
        public static string MD5(string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] data = md5.ComputeHash(UTF8Encoding.Default.GetBytes(str));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("X2"));
            }
            return sBuilder.ToString();
        }

        public static void sendAll(string message)
        {
            using(DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                var users = dc.Users.Where(u => u.disabled == false && u.UserType == '1');
                foreach(Users u in users)
                {
                    if( !String.IsNullOrEmpty( u.changhao))
                    {
                        sendSMS(u.changhao, message);
                    }
                }
            }
        }

        public static void sendSMS(string tel,string message)
        {
            HttpWebRequest req;
            HttpWebResponse res;
            Stream s;
            StreamReader r;
            string smsUrl = System.Configuration.ConfigurationManager.AppSettings["SMSConnectionString"];
            String url = smsUrl +"?to="+tel+"&content="+message;
            req = (HttpWebRequest)WebRequest.Create(url);
            res = (HttpWebResponse)req.GetResponse();
            s = res.GetResponseStream();
            r = new StreamReader(s);

            String result = r.ReadToEnd();
            r.Close();
            s.Close();
            res.Close();
        }

        public static bool isOnline()
        {

            if (HttpContext.Current.Session["netid"] != null)
                return true;
            else
                return false;
        }

        public static int getUserid()
        {
            if (isOnline())
            {
                return Convert.ToInt32( HttpContext.Current.Session["userid"]);
            }
            return -1;
        }
        public static String getUsernameInSession()
        {
            if (HttpContext.Current.Session["username"] != null)
                return (String)HttpContext.Current.Session["username"];
            else
                return "";
        }


        public static String getUserNetidInSession()
        {
            if (HttpContext.Current.Session["netid"] != null)
                return (String)HttpContext.Current.Session["netid"];
            else
                return "";
        }

        /// <summary>
        /// 上传Excel文件
        /// </summary>
        /// <param name="inputfile">上传的控件名</param>
        /// <returns></returns>
        public static string UpLoadXls(System.Web.UI.HtmlControls.HtmlInputFile inputfile)
        {
            string orifilename = string.Empty;
            string uploadfilepath = string.Empty;
            string modifyfilename = string.Empty;
            string fileExtend = "";//文件扩展名
            int fileSize = 0;//文件大小
            try
            {
                if (inputfile.Value != string.Empty)
                {
                    //得到文件的大小
                    fileSize = inputfile.PostedFile.ContentLength;
                    if (fileSize == 0)
                    {
                        throw new Exception("导入的Excel文件大小为0，请检查是否正确！");
                    }
                    //得到扩展名
                    fileExtend = inputfile.Value.Substring(inputfile.Value.LastIndexOf(".") + 1);
                    if (fileExtend.ToLower() != "xls")
                    {
                        throw new Exception("你选择的文件格式不正确，只能导入EXCEL文件！");
                    }
                    //路径
                    uploadfilepath = System.Web.HttpContext.Current.Server.MapPath("~/file/upload/tmp");
                    //新文件名
                    modifyfilename = System.Guid.NewGuid().ToString();
                    modifyfilename += "." + inputfile.Value.Substring(inputfile.Value.LastIndexOf(".") + 1);
                    //判断是否有该目录
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(uploadfilepath);
                    if (!dir.Exists)
                    {
                        dir.Create();
                    }
                    orifilename = uploadfilepath + "//" + modifyfilename;
                    //如果存在,删除文件
                    if (File.Exists(orifilename))
                    {
                        File.Delete(orifilename);
                    }
                    // 上传文件
                    inputfile.PostedFile.SaveAs(orifilename);
                }
                else
                {
                    throw new Exception("请选择要导入的Excel文件!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return orifilename;
        }

        /// <summary>
        /// 导入excel文件到dataset数据集
        /// </summary>
        /// <param name="fileName"></param>
        public static DataSet ImportXlsToData(string fileName)
        {
            try
            {
                if (fileName == string.Empty)
                {
                    throw new ArgumentNullException("Excel文件上传失败！");
                }

                string oleDBConnString = String.Empty;
                oleDBConnString = "Provider=Microsoft.Jet.OLEDB.4.0;";
                oleDBConnString += "Data Source=";
                oleDBConnString += fileName;
                oleDBConnString += ";Extended Properties=Excel 8.0;";
                OleDbConnection oleDBConn = null;
                OleDbDataAdapter oleAdMaster = null;
                DataTable m_tableName = new DataTable();
                DataSet ds = new DataSet();

                oleDBConn = new OleDbConnection(oleDBConnString);
                oleDBConn.Open();
                m_tableName = oleDBConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                if (m_tableName != null && m_tableName.Rows.Count > 0)
                {

                    m_tableName.TableName = m_tableName.Rows[0]["TABLE_NAME"].ToString();

                }
                string sqlMaster;
                sqlMaster = " SELECT *  FROM [" + m_tableName.TableName + "]";
                oleAdMaster = new OleDbDataAdapter(sqlMaster, oleDBConn);
                oleAdMaster.Fill(ds, "m_tableName");
                oleAdMaster.Dispose();
                oleDBConn.Close();
                oleDBConn.Dispose();

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ToExcel(Control ctl, string FileName,string charType = "UTF-8")
        {
            System.Web.UI.WebControls.GridView gv = (System.Web.UI.WebControls.GridView)ctl;
          //  GridView gv = (GridView)ctl;
            // for (int i = 0; i < gv.Columns.Count; i++) //设置每个单元格
            // {
            // gv.Columns[1].ItemStyle.HorizontalAlign = HorizontalAlign.Left;
            //将第一列准考证号设置为字符型，避免丢失0
            // for (int j = 0; j < gv.Rows.Count; j++)
            //{
            //  gv.Rows[j].Cells[0].Attributes.Add("style", "vnd.ms-excel.numberformat:@");
            //}
            // }

            HttpContext.Current.Response.Charset = charType;
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding(charType);
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + "" + FileName);
            gv.Page.EnableViewState = false;
            System.IO.StringWriter tw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            gv.RenderControl(hw);
            HttpContext.Current.Response.Write(tw.ToString());
            HttpContext.Current.Response.End();
        }
        /*
        public static t_Weather getTodayWeather()
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
               var weather = dc.t_Weather.OrderByDescending(w=>w.Id).Take(1);
               if (weather!=null &&　weather.Count() >0 )
               {
                   t_Weather w = weather.Single();
                   String s1 = Convert.ToDateTime( w.date).ToShortDateString();
                   String s2 = DateTime.Now.ToShortDateString();
                   if (s1 == s2)
                       return w;
                   else
                       return null;
               }
               else
                   return null;
            }
        }

        public static bool  insertTodayWeather(t_Weather w)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                dc.t_Weather.InsertOnSubmit(w);
                dc.SubmitChanges();
                return true;
            }
        }
        */
        public static string getFileDir()
        {
            string dir = System.Web.HttpContext.Current.Server.MapPath("/");
            string date = System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString();
            dir += "file\\upload\\" + date;
            if (!System.IO.Directory.Exists(dir))
                System.IO.Directory.CreateDirectory(dir);
            return dir;
        }
        //SaveFileName网站存放绝对路径，fileurl输出网站文件相对路径
        public static bool UpFileFun(FileUpload Controlfile, string[] FileType, int FileSize, string SaveFileName, ref string fileurl)
        {
            string FileDir = Controlfile.PostedFile.FileName;
            string FileName = FileDir.Substring(FileDir.LastIndexOf("\\") + 1);                  //获取上传文件名称
            string FileNameType = FileDir.Substring(FileDir.LastIndexOf(".") + 1).ToString();    //获取上传文件类型
            int FileNameSize = Controlfile.PostedFile.ContentLength;                             //获取上传文件大小
            string saveFileDir = "";
            //  定义上传文件类型，并初始化
            string Types = "";

            //string strDate = DateTime.Now.ToString();//取当前时间用来修改上传文件名   
            //string str = strDate.Replace("/", "").Replace(":", "").Replace("   ", "");   //过滤当前时间里的特殊字符，如: - / : ,
            //HttpContext.Current.Response.Write("<hr><br>" + str + "<br><br><br><hr");
            string EditFileName = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff").Replace(" ", "_").Replace(":", "-") + Guid.NewGuid().ToString();
            //string strNewFileName = Guid.NewGuid().ToString();   

            //HttpContext.Current.Response.Write("<hr><br>" + strNewFileName + "<br><br><br><hr");
            string date = System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString();
            fileurl = "\\file\\upload\\" + date;
            try
            {
                if (FileNameSize < FileSize)
                {
                    for (int i = 0; i < FileType.Length; i++)
                    {
                        if (FileNameType == FileType[i])
                        {
                            Types = FileNameType;
                        }
                    }
                    if (FileNameType == Types)
                    {
                        saveFileDir = SaveFileName + "\\" + EditFileName + FileName;
                        fileurl += "\\" + EditFileName + FileName;
                        Controlfile.PostedFile.SaveAs(saveFileDir);
                        return true;
                    }
                    else
                    {
                        return false;//上传失败！上传文件类型不符合
                    }
                }
                else
                {
                    return false;//上传失败！上传文件尺寸超出限制
                }

            }
            catch
            {
                return false;
            }
        }

    }
}
