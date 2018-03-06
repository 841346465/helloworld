using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MODEL.ORM {
	public class sql {
		public sql() {
			sqlStatement = string.Empty;
			hasWhere = false;
			hasOrder = false;
		}
		private string sqlStatement;

		private bool hasWhere;

		private bool hasOrder;

		// 用正则表达式过滤sql注入风险，如果用户有输入下面关键词则过滤掉
		public static bool InjectionDefend(string value) {
			string SqlStr = @"\/\*|\*\/|;|'";

			if ((value != null) && (value != String.Empty)) {
				Regex Regex = new Regex(SqlStr, RegexOptions.IgnoreCase);
				if (true == Regex.IsMatch(value)) {
					throw new ArgumentException("输入不允许包含下列字符之一：\n注释/*、反注释*/、单引号' 和分号;");
				}
			}
			return true;
		}

		public sql Select(string column) {
			sqlStatement += ("SELECT " + column + " ");
			return this;
		}

		public sql From(string Table) {
			sqlStatement += ("FROM " + Table + " ");
			return this;
		}

		/// <summary>
		/// 用正则表达式将query中的@i 换成values[i]
		/// </summary>
		/// <param name="query">Id=@0 and name=@1 and...</param>
		/// <param name="values">[2,true,"something",...]</param>
		/// <returns></returns>
		public sql Where(string query, params object[] values) {
			if (!hasWhere) {
				sqlStatement += "WHERE ";
				hasWhere = true;
			} else {
				sqlStatement += " AND";
			}
			bindValues(ref query, values);
			sqlStatement += query;
			return this;
		}

		/// <summary>
		/// 在sql尾部插入任意sql语句
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		public sql Append(string sql, params object[] values) {
			bindValues(ref sql, values);
			this.sqlStatement += (" " + sql + " ");
			return this;
		}

		public sql OrderBy(string column) {
			if (!sqlStatement.EndsWith(" ")) {
				sqlStatement += " ";
			}
			if (hasOrder) {
				sqlStatement += (", " + column);
			} else {
				sqlStatement += ("ORDER BY " + column);
			}
			return this;
		}

		public string GetSql() {
			return sqlStatement;
		}

		private void bindValues(ref string query, params object[] values) {
			for (int i = 0; i < values.Length; i++) {
				Regex r = new Regex(@"@\d+");
				if (values[i] is bool) {
					bool value = bool.Parse(values[i].ToString());
					query = r.Replace(query, (value ? "1" : "0"), 1);
					continue; //加continue与不加效果相同，但加conitnue不用判断下面的if，效率更高
				} else if (values[i].GetType().IsPrimitive) {
					query = r.Replace(query, values[i].ToString(), 1);
					continue;
				} else if (values[i].GetType().IsEnum) {
					int intValue = (int)values[i];
					query = r.Replace(query, intValue.ToString(), 1);
					continue;
				} else {
					if (InjectionDefend(values[i].ToString())) {
						query = r.Replace(query, "\'" + values[i].ToString() + "\'", 1);
					}
				}
			}
		}
	}
}
