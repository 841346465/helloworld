using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace model {
	public class orm {
		public orm() {
			type = this.GetType();
		}

		Type type;
		DBhelper.MySQLconnection conn = new DBhelper.MySQLconnection();

		public int Update(object obj, params string[] keys) {
			return 0;
		}

		public int Insert() {
			var fieldinfos = type.GetRuntimeFields();
			var propertiesInfo = type.GetProperties();
			var tableName = type.Name;
			Dictionary<string, string> dic = new Dictionary<string, string>();
			foreach (var propertyInfo in propertiesInfo) {
				var key = propertyInfo.Name;
				var value = propertyInfo.GetValue(this).ToString();
				dic.Add(key, value);
			}

			string sql = "insert into {0} ({1}) values ('{2}')";
			string fields = string.Join(",", dic.Keys);
			string values = string.Join("','", dic.Values);
			sql = string.Format(sql, tableName, fields, values);

			conn.OpenConnection();
			int i = conn.ExecuteNonQuery(sql);
			conn.CloseConnection();

			return i;
		}

		public int Delete(object obj, params string[] keys) {
			return 0;
		}

		public List<orm> QueryList(orm obj) {
			return null;
		}
	}
}
