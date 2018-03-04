using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace model {
	public class company {
		#region 数据
		[DisplayName("公司名称")]
		public string sg_company_name { get; set; }

		[DisplayName("许可证")]
		public string liscence { get; set; }

		[DisplayName("法定代表人")]
		public string legal_representative { get; set; }

		[DisplayName("审批年份")]
		public string Approval_of_the_year { get; set; }

		[DisplayName("服务范围")]
		public string service_area { get; set; }

		[DisplayName("是否跨区域")]
		public bool is_across_zone { get; set; }

		[DisplayName("注册地")]
		public string Registered_Address { get; set; }

		[DisplayName("办公场所")]
		public string business_address { get; set; }

		[DisplayName("注册资金")]
		public string registered_capital { get; set; }

		[DisplayName("分公司")]
		public string branch_office { get; set; }

		[DisplayName("管理层人员")]
		public string management_layer { get; set; }

		[DisplayName("联系方式")]
		public string phone { get; set; }

		[DisplayName("公司员工总数")]
		public int allstaff_num { get; set; }

		[DisplayName("管理人员数")]
		public int administrator_num { get; set; }

		[DisplayName("保安员数量")]
		public int Security_Officer_num { get; set; }

		[DisplayName("服务单位名称")]
		public string Security_Officer_name { get; set; }

		[DisplayName("奖惩情况")]
		public string r_and_p { get; set; }
		#endregion

		DBhelper.MySQLconnection conn = new DBhelper.MySQLconnection();

		public void Insert() {
			string insertSql = string.Format(sql.companyInsert, sg_company_name, liscence, legal_representative, Approval_of_the_year, service_area,
				is_across_zone == true ? 1 : 0, Registered_Address, business_address, registered_capital, branch_office, management_layer, phone, allstaff_num,
				administrator_num, Security_Officer_num, Security_Officer_name, r_and_p);

			conn.OpenConnection();
			conn.ExecuteNonQuery(insertSql);
			conn.CloseConnection();
		}

		public List<company> QueryList() {
			List<company> returnlist = new List<company>();
			conn.OpenConnection();
			MySql.Data.MySqlClient.MySqlDataReader reader = conn.GetReader(sql.companyQueryList);
			while (reader.Read()) {
				returnlist.Add(new company() {
					sg_company_name = reader["sg_company_name"].ToString(),
					liscence = reader["liscence"].ToString(),
					legal_representative = reader["legal_representative"].ToString(),
					Approval_of_the_year = reader["Approval_of_the_year"].ToString(),
					service_area = reader["service_area"].ToString(),
					is_across_zone = reader["is_across_zone"].ToString() == "1" ? true : false,
					Registered_Address = reader["Registered_Address"].ToString(),
					business_address = reader["business_address"].ToString(),
					registered_capital = reader["registered_capital"].ToString(),
					branch_office = reader["branch_office"].ToString(),
					management_layer = reader["management_layer"].ToString(),
					phone = reader["phone"].ToString(),
					allstaff_num = int.Parse(reader["allstaff_num"].ToString()),
					administrator_num = int.Parse(reader["administrator_num"].ToString()),
					Security_Officer_num = int.Parse(reader["Security_Officer_num"].ToString()),
					Security_Officer_name = reader["Security_Officer_name"].ToString(),
					r_and_p = reader["r_and_p"].ToString()
				});
			}
			conn.CloseConnection();
			return returnlist;
		}
	}
}
