using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace DBhelper {
	public class MySQLconnection  {
		public MySQLconnection() {
			this.Initialize("192.168.1.235", "test", "root", "");
		}
		/// <summary>  
		/// MySqlConnection连接对象  
		/// </summary>  
		private static MySqlConnection conn;

		/// <summary>  
		/// 初始化mysql连接  
		/// </summary>  
		/// <param name="server">服务器地址</param>  
		/// <param name="database">数据库实例</param>  
		/// <param name="uid">用户名称</param>  
		/// <param name="password">密码</param>  
		public void Initialize(string server, string database, string uid, string password) {}

		/// <summary>  
		/// 根据SQL获取DataTable数据表  
		/// </summary>  
		/// <param name="SQL">查询语句</param>  
		/// <param name="Table_name">返回表的表名</param>  
		/// <returns></returns>  
		public DataTable GetDataTable(string SQL) {
			MySqlDataAdapter Da = new MySqlDataAdapter(SQL, conn);
			DataTable dt = new DataTable();
			Da.Fill(dt);
			return dt;
		}
		/// <summary>  
		/// 运行MySql语句,返回DataSet对象  
		/// </summary>  
		/// <param name="SQL">查询语句</param>  
		/// <param name="Ds">待填充的DataSet对象</param>  
		/// <param name="tablename">表名</param>  
		/// <returns></returns>  
		public DataSet Get_DataSet(string SQL, DataSet Ds, string tablename) {
			MySqlDataAdapter Da = new MySqlDataAdapter(SQL, conn);
			Da.Fill(Ds, tablename);
			return Ds;
		}
		/// <summary>  
		/// 运行MySql语句,返回DataSet对象，将数据进行了分页  
		/// </summary>  
		/// <param name="SQL">查询语句</param>  
		/// <param name="Ds">待填充的DataSet对象</param>  
		/// <param name="StartIndex">开始项</param>  
		/// <param name="PageSize">每页数据条数</param>  
		/// <param name="tablename">表名</param>  
		/// <returns></returns>  
		public DataSet GetDataSet(string SQL, DataSet Ds, int StartIndex, int PageSize, string tablename) {
			MySqlDataAdapter Da = new MySqlDataAdapter(SQL, conn);
			Da.Fill(Ds, StartIndex, PageSize, tablename);
			return Ds;
		}

		/// <summary>  
		/// 增删改数据，不建议此方法因为未能防止sql注入
		/// </summary>  
		/// <param name="mySqlCommand"></param>  
		public int ExecuteNonQuery(string sql) {
			MySqlCommand cmd = new MySqlCommand(sql, conn);
			return cmd.ExecuteNonQuery();
		}
	}
}
