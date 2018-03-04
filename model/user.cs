using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model {
	public class user {
		[DisplayName("登录名")]
		public string loginId { get; set; }

		[DisplayName("密码")]
		public string password { get; set; }

		[DisplayName("名字")]
		public string name { get; set; }

		[DisplayName("管理员")]
		public bool isAdmin { get; set; }

		[DisplayName("权限集合")]
		List<uint> privileges { get; set; }

		private static user currentUser;

		public static user GetCurrentUser() {
			return currentUser;
		}

		public static void SetUser(user user) {
			currentUser = user;
		}

		public static bool isSuperManager(user user) {
			if (user.loginId == "supermanager" && user.password == function.GetMD5("supermanager")) {
				user.name = "超级管理员";user.isAdmin = true;
				return true;
			} else { return false; }
		}

	}
}
