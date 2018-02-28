using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static HttpWebResponse GetHttpResponse(string url, CookieCollection cookies)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            
            request.Method = "GET";
            request.Accept = "ext/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
 
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(cookies);
            //request.CookieContainer.Add(new Cookie("JSESSIONID","8E71BB5496597B9C0934E4622D525739"));
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:58.0) Gecko/20100101 Firefox/58.0";
            request.KeepAlive = true;
            foreach (var cookie in cookies)
            {
                request.Headers.Add("Cookie", cookie.ToString());
            }

            return request.GetResponse() as HttpWebResponse;
        }

        public static HttpWebResponse CreatePostHttpResponse(string url, IDictionary<string, string> parameters, int timeout, string userAgent, CookieCollection cookies)
        {
            HttpWebRequest request = null;
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            //request.Headers.Add("set_cookie","")
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            //设置代理UserAgent和超时
            //request.UserAgent = userAgent;
            //request.Timeout = timeout; 

            #region 火狐捕获的头
            request.Accept = "ext/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(cookies);
            //request.CookieContainer.Add(new Cookie("JSESSIONID","8E71BB5496597B9C0934E4622D525739"));
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:58.0) Gecko/20100101 Firefox/58.0";
            request.KeepAlive = true;
            #endregion

            //发送POST数据  
            if (!(parameters == null || parameters.Count == 0))
            {
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                        i++;
                    }
                }
                byte[] data = Encoding.ASCII.GetBytes(buffer.ToString());
                Stream stream = request.GetRequestStream();

                stream.Write(data, 0, data.Length);
                stream.Close();
            }
            string[] values = request.Headers.GetValues("Content-Type");
            return request.GetResponse() as HttpWebResponse;
        }


        /// <summary>
        /// 获取请求的数据
        /// </summary>
        public static string GetResponseString(HttpWebResponse webresponse)
        {
            using (Stream s = webresponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(s, Encoding.UTF8);
                return reader.ReadToEnd();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> login = new Dictionary<string, string>();
            /*login.Add("login_name", "shb01");
            login.Add("login_password", "1");
            HttpWebResponse response = CreatePostHttpResponse("http://192.168.200.177:8080/enovia/emxLogin.jsp", login, 0, null, null);*/
            HttpWebResponse response = GetHttpResponse("http://192.168.200.177:8080/enovia/emxLogin.jsp?login_name=shb01&login_password=1", new CookieCollection());
            string objectid = "36224.23797.57244.46285";
            string timestamp = getStrCurrentTimestamp();
            /*
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("CreateMode", "EBOM");
            param.Add("multiPartCreation", "true");
            param.Add("suiteKey", "EngineeringCentral");
            param.Add("StringResourceFileId", "emxEngineeringCentralStringResource");
            param.Add("SuiteDirectory", "engineeringcentral");
            param.Add("objectId", objectid);
            param.Add("ENCBillOfMaterialsViewCustomFilter", "Engineering");
            param.Add("timeStamp", timestamp);

            HttpWebResponse response2 = CreatePostHttpResponse("http://192.168.200.177:8080/enovia/same/sameExportBom.jsp", param, 0, null, response.Cookies);*/
            string url = "http://192.168.200.177:8080/enovia/same/sameExportBom.jsp?CreateMode=EBOM&multiPartCreation=true&suiteKey=EngineeringCentral&StringResourceFileId=emxEngineeringCentralStringResource&SuiteDirectory=engineeringcentral&objectId={0}&ENCBillOfMaterialsViewCustomFilter=Engineering&timeStamp={1}";
            url = string.Format(url, objectid, timestamp);

            HttpWebResponse response2 = GetHttpResponse(url, response.Cookies);
            string a = GetResponseString(response2);
        }

        public static string getStrCurrentTimestamp()
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            TimeSpan ts = DateTime.Now - startTime;
            return ts.TotalSeconds.ToString();
        }
    }
}
