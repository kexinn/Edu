using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace web
{
    public partial class MainRight : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initData();
                getweateher2();
                getTask();
                databind(); 
            }
        }

        protected void databind()
        {

            DateTime date = DateTime.Now;

            RepeaterPlan.DataSource = BLL.Application.WorkPlan.LookByMonth.getWorkPlanByDate(date.Year, date.Month,18,'1');
            RepeaterPlan.DataBind();
        }
        protected void getTask()
        {
           RepeaterTask.DataSource =  BLL.Application.RoutTask.getRoutTask((int)Session["userid"]);
           RepeaterTask.DataBind();
        }

        protected String formatContentLen(String content)
        {
            if(content.Length>12)
            {
                return content.Substring(0, 12) + "...";
            }
            return content;
              
        }

        protected void getweateher2()
        {
            try
            {
                String strWeather = "";
                HttpWebRequest req;
                HttpWebResponse res;
                Stream s;
                StreamReader r;
                t_Weather w = new t_Weather();
                String url = "http://api.map.baidu.com/telematics/v3/weather?location=宁波&output=json&ak=tyoIv9jx0Bhiz5T1Vu0kMXI3";
                req = (HttpWebRequest)WebRequest.Create(url);
                res = (HttpWebResponse)req.GetResponse();
                s = res.GetResponseStream();
                r = new StreamReader(s);

                strWeather = r.ReadToEnd();
                r.Close();
                s.Close();
                res.Close();

                JObject jObj = JObject.Parse(strWeather);
                JToken date = jObj["date"];

                JToken weatherinfo = jObj["results"];

                var city = (from c in weatherinfo.Children() select c).Single();

                JObject jObj1 = JObject.Parse(city.ToString());

                var data = from n in jObj1["weather_data"].Children() select n;
                String html = "<ul class='tooli'>";

                foreach (JToken t in data)
                {
                    JObject day = JObject.Parse(t.ToString());
                    JToken date1 = day["date"];
                    JToken dayPictureUrl = day["dayPictureUrl"];
                    JToken nightPictureUrl = day["nightPictureUrl"];
                    JToken weather = day["weather"];
                    JToken wind = day["wind"];
                    JToken temperature = day["temperature"];

                    html += "<li><span class='inline'>";
                    html += "<b>日</b><img alt='weather' src='" + dayPictureUrl + "' />" + "</span><span class='inline'><b>夜</b><img alt='weather' src='" + nightPictureUrl + "' /></span><p><a href='#'>" + date1.ToString() + "</a></p><p><a href='#'>" + weather.ToString()
                        + "</a></p><p><a href='#'>" + wind.ToString() + "</a></p><p><a href='#'>" + temperature.ToString() + "</a></p></li>";

                }
                html += "</ul>";
                weatherDiv.InnerHtml = html;
            }catch(Exception e)
            {
                lbWeatherMessage.Text = "获得天气接口失败：" + e.Message;
            }
        }
     /*   protected void getWeather()
        {
            String strWeather = "";
            HttpWebRequest req;
            HttpWebResponse res;
            Stream s;
            StreamReader r;
            try
            {
                t_Weather weather = BLL.pub.PubClass.getTodayWeather();
                if (weather != null)
                {
                    lbWeatherMessage.Text = weather.city + " " + Convert.ToDateTime( weather.date).ToShortDateString() + " " + weather.week;
                    lbWeather1.Text = weather.temp1;
                    lbWeather2.Text = weather.temp2;
                    lbWeather3.Text = weather.temp3;
                    lbWeather4.Text = weather.temp4;
                    lbWeather5.Text = weather.temp5;
                    lbWeather6.Text = weather.temp6;
                    lbDes1.Text = weather.description1;
                    lbDes2.Text = weather.description2;
                    lbDes3.Text = weather.description3;
                    lbDes4.Text = weather.description4;
                    lbDes5.Text = weather.description5;
                    lbDes6.Text = weather.description6;
                    lbWind1.Text = weather.wind1;
                    lbWind2.Text = weather.wind2;
                    lbWind3.Text = weather.wind3;
                    lbWind4.Text = weather.wind4;
                    lbWind5.Text = weather.wind5;
                    lbWind6.Text = weather.wind6;
                    lbDate1.Text = Convert.ToDateTime(weather.date).ToShortDateString();
                    lbDate2.Text = Convert.ToDateTime(weather.date2).ToShortDateString();
                    lbDate3.Text = Convert.ToDateTime(weather.date3).ToShortDateString();
                    lbDate4.Text = Convert.ToDateTime(weather.date4).ToShortDateString();
                    lbDate5.Text = Convert.ToDateTime(weather.date5).ToShortDateString();
                    lbDate6.Text = Convert.ToDateTime(weather.date6).ToShortDateString();
                    img1.ImageUrl = "/media/images/weather/" + weather.img1.Trim() + ".png";
                    img2.ImageUrl = "/media/images/weather/" + weather.img2.Trim() + ".png";
                    img3.ImageUrl = "/media/images/weather/" + weather.img3.Trim() + ".png";
                    img4.ImageUrl = "/media/images/weather/" + weather.img4.Trim() + ".png";
                    img5.ImageUrl = "/media/images/weather/" + weather.img5.Trim() + ".png";
                    img6.ImageUrl = "/media/images/weather/" + weather.img6.Trim() + ".png";
                }
                else
                {
                    t_Weather w = new t_Weather();
                    //String sk = "GfeibTkbdyfQxviaoxcgwe3WSHviqc2c";
                    //String basicString = "/telematics/v3/weather?location=宁波&output=json&ak=tyoIv9jx0Bhiz5T1Vu0kMXI3";
                    //String uri = HttpUtility.HtmlEncode(basicString + sk);
                    //String sn = BLL.pub.PubClass.MD5(uri);
                    req = (HttpWebRequest)WebRequest.Create("http://m.weather.com.cn/data/101210401.html");
                    //String url = "http://api.map.baidu.com/telematics/v3/weather?location=宁波&output=json&ak=tyoIv9jx0Bhiz5T1Vu0kMXI3" + "&sn=" + sn;
                    //req = (HttpWebRequest)WebRequest.Create("http://api.map.baidu.com/telematics/v3/weather?location=宁波&output=json&ak=tyoIv9jx0Bhiz5T1Vu0kMXI3");
                    res = (HttpWebResponse)req.GetResponse();
                    s = res.GetResponseStream();
                    r = new StreamReader(s);

                    strWeather = r.ReadToEnd();
                    r.Close();
                    s.Close();
                    res.Close();

                    JObject jObj = JObject.Parse(strWeather);
                    JToken weatherToken = jObj["weatherinfo"];
                    JToken city = weatherToken["city"];
                    JToken date = weatherToken["date_y"];
                    JToken week = weatherToken["week"];
                    w.city = city.ToString();
                    w.week = week.ToString();
                    // var city = from c in jObj["weatherinfo"].Children()
                    //            select (string)c["city"];
                    DateTime today = DateTime.Now;
                    w.date = Convert.ToDateTime(today.ToShortDateString());
                    w.date2 = Convert.ToDateTime(today.AddDays(1).ToShortDateString());
                    w.date3 = Convert.ToDateTime(today.AddDays(2).ToShortDateString());
                    w.date4 = Convert.ToDateTime(today.AddDays(3).ToShortDateString());
                    w.date5 = Convert.ToDateTime(today.AddDays(4).ToShortDateString());
                    w.date6 = Convert.ToDateTime(today.AddDays(5).ToShortDateString());
                    lbDate1.Text = w.date.ToString();
                    lbDate2.Text = w.date2.ToString();
                    lbDate3.Text = w.date3.ToString();
                    lbDate4.Text = w.date4.ToString();
                    lbDate5.Text = w.date5.ToString();
                    lbDate6.Text = w.date6.ToString();
                    w.temp1 = weatherToken["temp1"].ToString();
                    w.temp2 = weatherToken["temp2"].ToString();
                    w.temp3 = weatherToken["temp3"].ToString();
                    w.temp4 = weatherToken["temp4"].ToString();
                    w.temp5 = weatherToken["temp5"].ToString();
                    w.temp6 = weatherToken["temp6"].ToString();
                    lbWeather1.Text = w.temp1;
                    lbWeather2.Text = w.temp2;
                    lbWeather3.Text = w.temp3;
                    lbWeather4.Text = w.temp4;
                    lbWeather5.Text = w.temp5;
                    lbWeather6.Text = w.temp6;
                    w.description1 = weatherToken["weather1"].ToString();
                    w.description2 = weatherToken["weather2"].ToString();
                    w.description3 = weatherToken["weather3"].ToString();
                    w.description4 = weatherToken["weather4"].ToString();
                    w.description5 = weatherToken["weather5"].ToString();
                    w.description6 = weatherToken["weather6"].ToString();
                    lbDes1.Text = w.description1;
                    lbDes2.Text = w.description2;
                    lbDes3.Text = w.description3;
                    lbDes4.Text = w.description4;
                    lbDes5.Text = w.description5;
                    lbDes6.Text = w.description6;
                    w.wind1 = weatherToken["wind1"].ToString();
                    w.wind2 = weatherToken["wind2"].ToString();
                    w.wind3 = weatherToken["wind3"].ToString();
                    w.wind4 = weatherToken["wind4"].ToString();
                    w.wind5 = weatherToken["wind5"].ToString();
                    w.wind6 = weatherToken["wind6"].ToString();
                    lbWind1.Text = w.wind1;
                    lbWind2.Text = w.wind2;
                    lbWind3.Text = w.wind3;
                    lbWind4.Text = w.wind4;
                    lbWind5.Text = w.wind5;
                    lbWind6.Text = w.wind6;
                   
                    w.img1 =  weatherToken["img1"].ToString();
                    w.img2 = weatherToken["img3"].ToString();
                    w.img3 = weatherToken["img5"].ToString();
                    w.img4 = weatherToken["img7"].ToString();
                    w.img5 = weatherToken["img9"].ToString();
                    w.img6 = weatherToken["img11"].ToString();
                    img1.ImageUrl = "/media/images/weather/" + w.img1 + ".png";
                    img2.ImageUrl = "/media/images/weather/" + w.img2 + ".png";
                    img3.ImageUrl = "/media/images/weather/" + w.img3 + ".png";
                    img4.ImageUrl = "/media/images/weather/" + w.img4 + ".png";
                    img5.ImageUrl = "/media/images/weather/" + w.img5 + ".png";
                    img6.ImageUrl = "/media/images/weather/" + w.img6 + ".png";
                    lbWeatherMessage.Text = w.city + " " + w.date.ToString() + " " + w.week;
                    BLL.pub.PubClass.insertTodayWeather(w);
                }

            }catch(Exception e)
            {
                lbWeatherMessage.Text = "获得天气接口失败："+e.Message;
            }


        }*/
        protected void initData()
        {
            List<KQ_PunchCardRecords> recordList;
            int userid = (int)Session["userid"];
            recordList = BLL.Application.KQ.KQManagement.getTodayPunchCardRecord(userid, '1');
            if (recordList.Count() == 0)
            {

                lbClockOnState.Text = "还未打卡";
                imgClockOn.ImageUrl = "media/images/attention.png";
            }
            else
            {
                KQ_PunchCardRecords kq = recordList.First();
                lbClockOnTime.Text = kq.Time.ToString();
                lbClockOnState.Text = "已经打卡";
                imgClockOn.ImageUrl = "media/images/check-64.png";
            }
            recordList = BLL.Application.KQ.KQManagement.getTodayPunchCardRecord(userid, '2');
            if (recordList.Count() == 0)
            {
                lbClockOffState.Text = "还未打卡";
                
                imgClokOff.ImageUrl = "media/images/attention.png";
            }
            else
            {
                KQ_PunchCardRecords kq = recordList.First();
                lbClockOffTime.Text = kq.Time.ToString();
                lbClockOffState.Text = "已经打卡";
                imgClokOff.ImageUrl = "media/images/check-64.png";
            }

        }

        

        protected void lbClockOff_Click(object sender, EventArgs e)
        {
            lbPunchCardMessage.Text = "";
            String ip = Request.UserHostAddress;
            String[] ips = ip.Split('.');
            try
            {
                BLL.Application.KQ.KQManagement.insertPunchCardRecord(Convert.ToInt32(Session["userid"]), ip, '2');
                initData();
            }
            catch (Exception ex)
            {
                lbPunchCardMessage.Text = ex.Message;
            }
        }

        protected void lbClockOn_Click(object sender, EventArgs e)
        {
            lbPunchCardMessage.Text = "";
            String ip = Request.UserHostAddress;
            String[] ips = ip.Split('.');
            try
            {
                BLL.Application.KQ.KQManagement.insertPunchCardRecord(Convert.ToInt32(Session["userid"]), ip, '1');
                initData();
            }
            catch (Exception ex)
            {
                lbPunchCardMessage.Text = ex.Message;
            }
        }

        protected void Unnamed_Tick(object sender, EventArgs e)
        {
            getTask();
        }
    }
}