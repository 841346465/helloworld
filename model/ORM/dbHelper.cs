using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace MODEL.ORM {
	public class dbHelper {

		public dbHelper() { }

		private DbTransaction trans;
		private DbConnection conn;

		public void SetConnection(dbType type, string connectionName) {
			switch (type) {
				case dbType.Mysql: {
						conn = new MySqlConnection(ConfigurationManager.ConnectionStrings[connectionName].ConnectionString);
						break;
					}
				default: break;
			}
		}

		public void BeginTransaction() {
			if (conn.State != System.Data.ConnectionState.Open) { conn.Open(); }
			trans = conn.BeginTransaction();
		}

		public void Commit() {
			trans.Commit();
			trans = null;
		}

		public void Open() {
			if (conn.State != System.Data.ConnectionState.Open) { conn.Open(); }
			conn.Open();
		}
		public void Close() {
			conn.Close();
		}
		public void Rollback() {
			trans.Rollback();
		}

		public DbDataReader GetReader(string sql) {
			if (conn.State != System.Data.ConnectionState.Open) { conn.Open(); }
			DbCommand cmd = conn.CreateCommand();
			cmd.CommandText = sql;
			return cmd.ExecuteReader();
		}

		public int ExecuteNonQuery(string sql) {
			if (conn.State != System.Data.ConnectionState.Open) { conn.Open(); }
			DbCommand cmd = conn.CreateCommand();
			cmd.CommandText = sql;
			if (trans != null) {
				cmd.Transaction = trans;
			}
			return cmd.ExecuteNonQuery();
		}
	}
}
