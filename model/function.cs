using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace model {
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
	}
}
