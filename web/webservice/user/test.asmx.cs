using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using BLL;
namespace web.webservice.user
{
    /// <summary>
    /// test 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [ScriptService]
    public class test : System.Web.Services.WebService
    {
        /// <summary>
        /// 无任何参数
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// 传入参数
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [WebMethod]

        public string Hello(string name)
        {
            return string.Format("Hello {0}", name);
        }

        /// <summary>
        /// 返回泛型列表
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        [WebMethod]
        public List<int> CreateArray(int i)
        {
            List<int> list = new List<int>();

            while (i >= 0)
            {
                list.Add(i--);
            }

            return list;
        }

        /// <summary>
        /// 返回复杂类型
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        [WebMethod]
        public Users GetPerson(string name, int age)
        {
            return new Users()
            {
                TrueName = name,
                orderNo = age
            };
        }
    }
}
