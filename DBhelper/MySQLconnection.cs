using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace DBhelper {
	public class MySQLconnection {
		public MySQLconnection() {
			this.Initialize("localhost", "test", "root", "");
		}
		/// <summary>  
		/// MySqlConnection连接对象  
		/// </summary>  
		private MySqlConnection connection;
		/// <summary>  
		/// 服务器地址  
		/// </summary>  
		private string server;
		/// <summary>  
		/// 数据库实例名称  
		/// </summary>  
		private string database;
		/// <summary>  
		/// 用户名  
		/// </summary>    
		private string uid;
		/// <summary>  
		/// 密码  
		/// </summary>  
		private string password;

		public MySqlConnection getInstance() {
			return connection;
		}

		/// <summary>  
		/// 初始化mysql连接  
		/// </summary>  
		/// <param name="server">服务器地址</param>  
		/// <param name="database">数据库实例</param>  
		/// <param name="uid">用户名称</param>  
		/// <param name="password">密码</param>  
		public void Initialize(string server, string database, string uid, string password) {
			this.server = server;
			this.uid = uid;
			this.password = password;
			this.database = database;
			//string connectionString = "Data Source=" + server + ";" + "port=" + port + ";" + "Database=" + database + ";" + "User Id=" + uid + ";" + "Password=" + password + ";" + "CharSet = utf8"; ;  
			string connectionString = "server=" + server + ";user id=" + uid + ";password=" + password + ";database=" + database + ";Charset = utf8";
			connection = new MySqlConnection(connectionString);
		}
		/// <summary>  
		/// 打开数据库连接  
		/// </summary>  
		/// <returns>是否成功</returns>  
		public bool OpenConnection() {
			if (connection.State != ConnectionState.Open) {
				connection.Open();
			}
			return true;
		}

		/// <summary>  
		/// 关闭数据库连接  
		/// </summary>  
		/// <returns></returns>  
		public bool CloseConnection() {
			if (connection.State != ConnectionState.Closed) {
				connection.Close();
			}
			return true;
		}

		/// <summary>  
		/// 构建SQL句柄  
		/// </summary>  
		/// <param name="SQL">SQL语句</param>  
		/// <returns></returns>  
		private MySqlCommand CreateCmd(string SQL) {
			MySqlCommand Cmd = new MySqlCommand(SQL, connection);
			return Cmd;
		}
		/// <summary>  
		/// 根据SQL获取DataTable数据表  
		/// </summary>  
		/// <param name="SQL">查询语句</param>  
		/// <param name="Table_name">返回表的表名</param>  
		/// <returns></returns>  
		public DataTable GetDataTable(string SQL) {
			MySqlDataAdapter Da = new MySqlDataAdapter(SQL, connection);
			DataTable dt = new DataTable();
			Da.Fill(dt);
			return dt;
		}

		/// <summary>  
		///  运行MySql语句返回 MySqlDataReader对象  
		/// </summary>  
		/// <param name="查询语句"></param>  
		/// <returns>MySqlDataReader对象</returns>  
		public MySqlDataReader GetReader(string SQL) {
			MySqlCommand Cmd = new MySqlCommand(SQL, connection);
			MySqlDataReader Dr;
			Dr = Cmd.ExecuteReader(CommandBehavior.Default);
			return Dr;
		}

		/// <summary>  
		/// 运行MySql语句,返回DataSet对象  
		/// </summary>  
		/// <param name="SQL">查询语句</param>  
		/// <param name="Ds">待填充的DataSet对象</param>  
		/// <param name="tablename">表名</param>  
		/// <returns></returns>  
		public DataSet Get_DataSet(string SQL, DataSet Ds, string tablename) {
			MySqlDataAdapter Da = new MySqlDataAdapter(SQL, connection);
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
			MySqlDataAdapter Da = new MySqlDataAdapter(SQL, connection);
			Da.Fill(Ds, StartIndex, PageSize, tablename);
			return Ds;
		}

		/// <summary>  
		/// 增删改数据  
		/// </summary>  
		/// <param name="mySqlCommand"></param>  
		public int ExecuteNonQuery(string sql) {
			MySqlCommand mySqlCommand = CreateCmd(sql);
			return mySqlCommand.ExecuteNonQuery();
		}
	}
}
