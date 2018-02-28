using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace framework {
	class user {
		[DisplayName("登录名")]
		public string loginId { get; set; }

		[DisplayName("密码")]
		public string password { get; set; }

		[DisplayName("名字")]
		public string name { get; set; }

		[DisplayName("权限集合")]
		List<uint> privileges { get; set; }
	}
}
