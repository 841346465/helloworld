using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.ORM {
	[AttributeUsage(AttributeTargets.Class)]
	public class TableAttribute : Attribute {
		public TableAttribute(string tableName) {
			this.Value = tableName;
		}

		public string Value { get; protected set; }
	}

	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
	public class ColumnAttribute : Attribute {
		public ColumnAttribute(string columnName) {
			this.Value = columnName;
		}

		public string Value { get; protected set; }
	}

	[AttributeUsage(AttributeTargets.Class)]
	public class PrimaryKeyAttribute : Attribute {
		public PrimaryKeyAttribute(string primaryKey) {
			this.Value = primaryKey;
		}

		public string Value { get; protected set; }
		public bool autoIncrement = false;

	}

	public class attributesHelper {
		/// <summary>  
		/// 获取表名  
		/// </summary>  
		/// <param name="type"></param>  
		/// <returns></returns>  
		public static string GetTableName(Type type) {
			string tableName = string.Empty;
			object[] attributes = type.GetCustomAttributes(false);
			foreach (var attr in attributes) {
				if (attr is TableAttribute) {
					TableAttribute tableAttribute = attr as TableAttribute;
					tableName = tableAttribute.Value;
				}
			}
			if (string.IsNullOrEmpty(tableName)) {
				tableName = type.Name;
			}
			return tableName;
		}

		/// <summary>  
		/// 判断是否是数据表列，如果是列则获取列名
		/// </summary>  
		/// <param name="property"></param>  
		/// <returns></returns>  
		public static bool IsColumn(PropertyInfo property, out string columnName) {
			object[] attributes = property.GetCustomAttributes(false);
			foreach (var attr in attributes) {
				if (attr is ColumnAttribute) {
					ColumnAttribute columnAttr = attr as ColumnAttribute;
					columnName = columnAttr.Value;
					return true;
				}
			}
			columnName = null;
			return false;
		}

		/// <summary>  
		/// 获取字段名  
		/// </summary>  
		/// <param name="property"></param>  
		/// <returns></returns>  
		public static string GetColumnName(PropertyInfo property) {
			string columnName = string.Empty;
			object[] attributes = property.GetCustomAttributes(false);
			foreach (var attr in attributes) {
				if (attr is ColumnAttribute) {
					ColumnAttribute columnAttr = attr as ColumnAttribute;
					columnName = columnAttr.Value;
				}
			}
			if (string.IsNullOrEmpty(columnName)) {
				columnName = property.Name;
			}
			return columnName;
		}

		/// <summary>  
		/// 判断主键是否自增  
		/// </summary>  
		/// <param name="property"></param>  
		/// <returns></returns>  
		public static bool IsIncrement(Type type) {
			object[] attributes = type.GetCustomAttributes(false);
			foreach (var attr in attributes) {
				if (attr is PrimaryKeyAttribute) {
					PrimaryKeyAttribute primaryKeyAttr = attr as PrimaryKeyAttribute;
					return primaryKeyAttr.autoIncrement;
				}
			}
			return false;
		}

		/// <summary>  
		/// 获取主键名  
		/// </summary>  
		/// <param name="type"></param>  
		/// <returns></returns>  
		public static string GetPrimary(Type type) {
			object[] attributes = type.GetCustomAttributes(false);
			foreach (var attr in attributes) {
				if (attr is PrimaryKeyAttribute) {
					PrimaryKeyAttribute primaryKeyAttr = attr as PrimaryKeyAttribute;
					return primaryKeyAttr.Value;
				}
			}
			return null;
		}

		/// <summary>  
		/// 判断属性是否为主键  
		/// </summary>  
		/// <param name="type"></param>  
		/// <param name="property"></param>  
		/// <returns></returns>  
		public static bool IsPrimary(Type type, PropertyInfo property) {
			string primaryKeyName = GetPrimary(type);
			string columnName = GetColumnName(property);
			return (primaryKeyName == columnName);
		}
	}
}
