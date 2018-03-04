using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace DBhelper {
	public class databaseManager {
		#region 单例模式
		private databaseManager() { }
		private static databaseManager UniqueDatabaseManager;
		private static DbConnection UniqueDbConnection;
		private static DbTransaction trans;
		private static readonly object locker = new object();
		public static databaseManager GetInstance() {
			if (UniqueDatabaseManager == null) {
				lock (locker) {
					if (UniqueDatabaseManager == null) {
						UniqueDatabaseManager = new databaseManager();
					}
				}
			}
			return UniqueDatabaseManager;
		}
		#endregion
		private static DbConnection conn {
			get {
				if (UniqueDbConnection == null) {
					lock (locker) {
						if (UniqueDbConnection == null) {
							UniqueDbConnection = new MySqlConnection(
							ConfigurationManager.ConnectionStrings["remoteServer"].ConnectionString
							); return UniqueDbConnection;
						}
					}
				}
				return UniqueDbConnection;
			}
		}

		public void BeginTransaction() {
			if (conn.State != System.Data.ConnectionState.Open) { conn.Open(); }
			trans = conn.BeginTransaction();
		}

		public void Commit() {
			trans.Commit();
			if (conn.State != System.Data.ConnectionState.Closed) { conn.Close(); }
		}

		public void Rollback() {
			trans.Rollback();
			if (conn.State != System.Data.ConnectionState.Closed) { conn.Close(); }
		}

		public int ExecuteNonQuery(string sql) {
			DbCommand cmd = new MySqlCommand(sql, conn as MySqlConnection);
			if (conn.State != System.Data.ConnectionState.Open) { conn.Open(); }
			try {
				if (trans != null) {
					cmd.Transaction = trans;
				}
				return cmd.ExecuteNonQuery();
			} catch { throw; } finally {
				if (conn == null) {
					conn.Close();
				}
			}
		}
	}
}
