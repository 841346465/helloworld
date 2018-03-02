using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace framework {
	public partial class login : Form {
		public login() {
			InitializeComponent();
		}

		private void btnLogin_Click(object sender, EventArgs e) {
			if (txtLoginName.Text.Equals("")) { MessageBox.Show("用户名不能为空"); return; }
			if (txtPassword.Text.Equals("")) { MessageBox.Show("密码不能为空"); return; }
			string password = model.function.GetMD5(txtPassword.Text);
			if (validateUser(txtLoginName.Text, password)) {
				this.DialogResult = DialogResult.OK;
			} else {
				{ MessageBox.Show("用户不存在或密码错误！"); return; }
			}
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
		}

		private bool validateUser(string loginName, string password) {
			model.user currentUser = new model.user {
				loginId = loginName,
				password = password
			};
			#region 超级管理员
			if (model.user.isSuperManager(currentUser)) {
				model.user.SetUser(currentUser);
				return true;
			}
			#endregion

			model.orm ormInstance = new model.orm();
			if ((currentUser = ormInstance.First(currentUser)) == null) {
				return false;
			} else {
				model.user.SetUser(currentUser);
				return true;
			}
		}

		private void txtPassword_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter) {
				btnLogin_Click(null, null);
			}
		}
	}
}
