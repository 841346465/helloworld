using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MODEL.ORM {
	public class orm {
		public orm() {
			db = DBhelper.databaseManager.GetInstance();
		}
		DBhelper.databaseManager db;

		public void Open() { db.Open(); }
		public void Close() { db.Close(); }
		public void BeginTransaction() { db.BeginTransaction(); }
		public void Commit() { db.Commit(); }
		public void Rollback() { db.Rollback(); }
		public int ExecuteNonQuery(string sql) {
			return db.ExecuteNonQuery(sql);
		}
		//

		#region create
		public int Insert<T>(T data) {
			Type type = data.GetType();
			string table = attributesHelper.GetTableName(type);
			List<string> columns = new List<string>();
			List<string> values = new List<string>();
			foreach (PropertyInfo property in type.GetProperties()) {
				if (!(attributesHelper.IsPrimary(type, property) && attributesHelper.IsIncrement(type))) {
					if (property.GetValue(data) != null) {
						columns.Add(attributesHelper.GetColumnName(property));
						if (property.PropertyType == typeof(bool)) {
							bool value = bool.Parse(property.GetValue(data).ToString());
							values.Add(value ? "1" : "0");
						} else if (property.PropertyType.IsPrimitive) {
							values.Add(property.GetValue(data, null).ToString());
						} else if (property.PropertyType.IsEnum) {
							int intValue = (int)property.GetValue(data, null);
							values.Add(intValue.ToString());
						} else {
							if (ORM.sql.InjectionDefend(property.GetValue(data, null).ToString())) {
							values.Add("\'" + property.GetValue(data, null) + "\'");
							}
						}
					}
				}
			}
			string sql = "INSERT INTO " + table + "(" + string.Join(",", columns) + ")" + "VALUES" + "(" + string.Join(",", values) + ")";

			return db.ExecuteNonQuery(sql);
		}
		#endregion

		#region update
		public int Update<T>(T data, IEnumerable<string> columns) {
			if (columns == null || columns.Count() == 0) {
				return Update<T>(data);
			}
			return 0;
		}

		/// <summary>
		/// 查找类定义，根据主键更新
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="data"></param>
		/// <returns></returns>
		public int Update<T>(T data) {
			Type type = data.GetType();//typeof(T)
			string table = attributesHelper.GetTableName(type);
			string sql = "update " + table + " Set ";
			List<string> sets = new List<string>();
			string where = "where";
			PropertyInfo[] properties = type.GetProperties();
			foreach (PropertyInfo property in properties) {
				string column = attributesHelper.GetColumnName(property);
				if (!attributesHelper.IsPrimary(type, property)) {
					if (property.PropertyType == typeof(bool)) {
						bool value = bool.Parse(property.GetValue(data).ToString());
						sets.Add(column + "=" + (value ? "1" : "0"));
					} else if (property.PropertyType.IsPrimitive) {
						sets.Add(column + "=" + property.GetValue(data));
					} else if (property.PropertyType.IsEnum) {
						int intValue = (int)property.GetValue(data);
						sets.Add(column + "=" + intValue);
					} else {
						//if (sql.InjectionDefend(property.GetValue(data).ToString())) {
						sets.Add(column + "=\'" + property.GetValue(data) + "\'");
						//}
					}
				} else {
					if (property.PropertyType.IsPrimitive) {
						where += column + "=" + property.GetValue(data);
					} else {
						where += column + "\'" + property.GetValue(data) + "\'";
					}
				}
			}
			sql += (string.Join(",", sets) + where);
			return db.ExecuteNonQuery(sql);
		}
		#endregion

		#region retrieve

		/// <summary>
		/// 取第一条，如果没有符合返回null，不能把此方法写作Fetch().First()，因为这样datareader会无故读许多无用数据，影响查询
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="sql"></param>
		/// <returns></returns>
		public T First<T>(sql sql) {
			try {
				T result = default(T);
				System.Data.Common.DbDataReader reader = db.GetReader(sql.GetSql());
				if (reader.Read()) {
					Type type = typeof(T);
					if (type.IsPrimitive || type == typeof(string) || type == typeof(DateTime) || type.IsEnum) {
						if (type.IsEnum) {
							result = (T)Enum.ToObject(type, reader.GetValue(0));
						} else {
							result = (T)Convert.ChangeType(reader.GetValue(0), type);
						}
					} else {
						result = Activator.CreateInstance<T>();
						PropertyInfo[] properties = type.GetProperties();
						foreach (PropertyInfo property in properties) {
							string columName = attributesHelper.GetColumnName(property);
							if (property.PropertyType.IsEnum) {
								property.SetValue(result, Enum.ToObject(property.PropertyType, reader.GetValue(reader.GetOrdinal(columName))), null);
							} else {
								property.SetValue(result, Convert.ChangeType(reader.GetValue(reader.GetOrdinal(columName)), property.PropertyType), null);
							}
						}
					}
				}
				return result;
			} catch {
				throw ;
			} finally {
				Close();
			}
		}
		public List<T> Fetch<T>(sql sql) {
			try {
				System.Data.Common.DbDataReader reader = db.GetReader(sql.GetSql());
				List<T> list = new List<T>();
				Type type = typeof(T);
				if (type.IsPrimitive || type == typeof(string) || type == typeof(DateTime) || type.IsEnum) {
					while (reader.Read()) {
						if (type.IsEnum) {
							list.Add((T)Enum.ToObject(type, reader.GetValue(0)));
						} else {
							list.Add((T)Convert.ChangeType(reader.GetValue(0), type));
						}
					}
				} else {
					while (reader.Read()) {
						T result = Activator.CreateInstance<T>();
						PropertyInfo[] properties = type.GetProperties();
						foreach (PropertyInfo property in properties) {
							string columName = attributesHelper.GetColumnName(property);
							if (property.PropertyType.IsEnum) {
								property.SetValue(result, Enum.ToObject(property.PropertyType, reader.GetValue(reader.GetOrdinal(columName))), null);
							} else {
								property.SetValue(result, Convert.ChangeType(reader.GetValue(reader.GetOrdinal(columName)), property.PropertyType), null);
							}
						}
						list.Add(result);
					}
				}
				return list;
			} catch  {
				throw ;
			} finally {
				Close();
			}
		}
		#endregion

		#region delete
		public int Delete<T>(T data) {
			Type type = typeof(T);
			string table = attributesHelper.GetTableName(type);
			string sql = "DELETE FROM " + table + " WHERE ";
			PropertyInfo[] properties = type.GetProperties();
			foreach (PropertyInfo property in properties) {
				if (attributesHelper.IsPrimary(type, property)) {
					sql += (attributesHelper.GetColumnName(property) + "=");
					if (property.PropertyType.IsPrimitive) {
						sql += (data.ToString() + ";");
					} else {
						sql += ("\'" + data.ToString() + "\';");
					}
				}
			}
			return db.ExecuteNonQuery(sql);
		}
		#endregion

	}
}
