using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.IO;

namespace WindowsFormsApp1
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var handler = new HttpClientHandler() { UseCookies = true };
			var client = new HttpClient(handler);
			client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:57.0) Gecko/20100101 Firefox/57.0");
			client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
			client.DefaultRequestHeaders.Add("Keep-Alive", "timeout=600");

			string objectid = "36224.23797.57244.46285";
			string timestamp = getStrCurrentTimestamp();

			var content = new FormUrlEncodedContent(new[]
						{
				new KeyValuePair<string, string>("login_name", "shb01"),
				new KeyValuePair<string, string>("login_password", "1")
			});
			var result = client.PostAsync("http://192.168.200.177:8080/enovia/servlet/login", content);
			//如果不读取，得不到内容相应，读取了又耗时
			var resultContent = result.Result.Content.ReadAsStringAsync().Result;

			content = new FormUrlEncodedContent(new[]
						{
				new KeyValuePair<string, string>("CreateMode", "EBOM"),
				new KeyValuePair<string, string>("multiPartCreation", "true"),
				new KeyValuePair<string, string>("suiteKey", "EngineeringCentral"),
				new KeyValuePair<string, string>("StringResourceFileId", "emxEngineeringCentralStringResource"),
				new KeyValuePair<string, string>("SuiteDirectory", "engineeringcentral"),
				new KeyValuePair<string, string>("objectId", objectid),
				new KeyValuePair<string, string>("ENCBillOfMaterialsViewCustomFilter", "xxxx"),
				new KeyValuePair<string, string>("password", "Engineering"),
				new KeyValuePair<string, string>("timeStamp", timestamp),
				new KeyValuePair<string, string>("password", "xxxx")
			});

			var postresult = client.PostAsync("http://192.168.200.177:8080/enovia/same/sameExportBom.jsp", content);
			//如果不读取，得不到内容相应，读取了又耗时
			resultContent = postresult.Result.Content.ReadAsStringAsync().Result;
			var downloaduri = Regex.Match(resultContent, "(?<=action=\"sameDownloadFile.jsp\\?docName=)\\S+(?=\")");

			var finalresult = client.GetStreamAsync("http://192.168.200.177:8080/enovia/same/sameDownloadFile.jsp?docName=" + downloaduri);

			//新建文件流，写入磁盘
			string path = getSavePath(downloaduri.Value);
			FileStream fs = new FileStream(path, FileMode.Create);

			byte[] buffer = new byte[1024];
			int i = 0;//不定义i会使文件大小为1024的整数，即文件末尾填0补齐，会破坏文件格式
			while ((i = finalresult.Result.Read(buffer, 0, 1024)) > 0)
			{
				fs.Write(buffer, 0, i);
				buffer = new byte[1024];
			}
			//关闭文件流 网络流
			fs.Close();
			finalresult.Result.Close();
		}

		public static string getStrCurrentTimestamp()
		{
			System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
			TimeSpan ts = DateTime.Now - startTime;
			//Unix时间戳是秒数，Java时间戳取毫秒数
			return ts.TotalMilliseconds.ToString("f0");
		}

		public string getSavePath(string filname)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.FileName = filname;
			sfd.Filter = @"Excel文件|*.xls";
			sfd.ShowDialog();
			return sfd.FileName;
		}
	}
}
