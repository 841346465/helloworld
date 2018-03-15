using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.ComponentModel;

namespace MODEL {
	public class function {
		public static string GetMD5(string originString) {
			byte[] origin = Encoding.UTF8.GetBytes(originString);
			MD5 md5 = MD5.Create();
			byte[] encrypted = md5.ComputeHash(origin);
			StringBuilder encryptedStrBuilder = new StringBuilder(40);
			for (int i = 0; i < encrypted.Length; i++) {
				encryptedStrBuilder.Append(encrypted[i].ToString("x2"));

			}
			return encryptedStrBuilder.ToString();
		}

		public static List<string> getIpv4List() {
			List<string> iplist = new List<string>();
			foreach (IPAddress ip in Dns.GetHostAddresses(Dns.GetHostName())) {
				if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) {
					iplist.Add(ip.ToString());
				}
			}
			return iplist;
		}

		public static bool SaveCsvFile<T>(List<T> list) {
			using (SaveFileDialog sfd = new SaveFileDialog { Filter = "csv File|*.csv" }) {
				if (sfd.ShowDialog() == DialogResult.OK) {
					// 垃圾微软 StreamWriter 和 Reader 用的是 utf8 with BOM!!!  excel对utf8编码的csv支持也不好
					StreamWriter sw = new StreamWriter(sfd.FileName,false,Encoding.UTF8);
					//StreamWriter sw = new StreamWriter(sfd.FileName);

					// 生成列
					var type = typeof(T);
					PropertyInfo[] props = type.GetProperties();
					StringBuilder strColumn = new StringBuilder();
					foreach (PropertyInfo property in props) {
						DisplayNameAttribute attr = property.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute;
						if (attr == null) { continue; }
						strColumn.Append(attr.DisplayName);
						strColumn.Append(",");
					}
					sw.WriteLine(strColumn);

					// 写入数据
					StringBuilder strValue = new StringBuilder();
					foreach (var dr in list) {
						strValue.Clear();
						foreach (PropertyInfo property in props) {
							DisplayNameAttribute attr = property.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute;
							if (attr == null) { continue; }
							strValue.Append(property.GetValue(dr, null));
							strValue.Append(",");
						}
						sw.WriteLine(strValue);
					}

					sw.Close();
				}
			}
			return true;
		}

		public static List<T> ReadFromCsvFile<T>() {
			using (OpenFileDialog sfd = new OpenFileDialog { Filter = "csv File|*.csv" }) {
				if (sfd.ShowDialog() == DialogResult.OK) {
					StreamReader sr = new StreamReader(sfd.FileName);
					List<T> list = new List<T>();
					Dictionary<int, string> dic = new Dictionary<int, string>();
					var type = typeof(T);

					// 读列名
					var txt = sr.ReadLine();
					string[] columns = txt.Split(',');
					PropertyInfo[] props = type.GetProperties();

					for (int i = 0; i < columns.Length; i++) {
						if (!string.IsNullOrEmpty(columns[i])) {
							foreach (PropertyInfo property in props) {
								DisplayNameAttribute attr = property.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute;
								if (attr == null) { continue; }
								if (columns[i] == attr.DisplayName) {
									dic.Add(i, property.Name);
									break;
								}
							}
						}
					}

					txt = sr.ReadLine();
					while (!string.IsNullOrEmpty(txt)) {
						columns = txt.Split(',');
						T detail = (T)type.Assembly.CreateInstance(type.ToString());
						for (int i = 0; i < columns.Length; i++) {
							if (string.IsNullOrEmpty(columns[i])) { continue; }
							if (type.GetProperty(dic[i]).PropertyType.IsEnum) {
								type.GetProperty(dic[i]).SetValue(detail, Enum.ToObject(type.GetProperty(dic[i]).PropertyType, columns[i]), null);
							} else {
								type.GetProperty(dic[i]).SetValue(detail, Convert.ChangeType(columns[i], type.GetProperty(dic[i]).PropertyType), null);
							}
						}
						list.Add(detail);
						txt = sr.ReadLine();
					}
					sr.Close();
					return list;
				}
			}
			return null;
		}
	}
}
