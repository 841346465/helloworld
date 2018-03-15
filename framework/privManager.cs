using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace framework {
	public partial class privManager : Form {
		public privManager() {
			InitializeComponent();
		}

		public MODEL.menu menu { get; set; }
		private bool isNewOrModify;
		public void SetMode(bool isNewOrModify) {
			this.isNewOrModify = isNewOrModify;
		}

		private void browse_Click(object sender, EventArgs e) {
			var openFile = new OpenFileDialog() {
				Filter = "dll files|*.dll|All files|*.*",
				InitialDirectory = Application.StartupPath
			};
			if (openFile.ShowDialog() == DialogResult.OK) {
				menu.dllName = openFile.SafeFileName;

				Assembly assembly = Assembly.LoadFile(openFile.FileName);
				List<string> listClassName = new List<string>();
				foreach (var type in assembly.GetTypes()) {
					if (type.IsSubclassOf(typeof(Form))) {
						//(assembly.CreateInstance(type.FullName) as Form).Show();
						listClassName.Add(type.FullName);
					}
				}
				if (listClassName.Count == 0) {
					MessageBox.Show(menu.dllName + "中不包含窗口组件，无法创建菜单");
					menu.fieldName = string.Empty;
					lblHint.Text = "未选择组件";
					return;
				}
				privManagerPopup popup = new privManagerPopup();
				popup.SetList(listClassName);
				if (popup.ShowDialog() == DialogResult.OK) {
					lblHint.Text = popup.GetSelected;
					menu.fieldName = popup.GetSelected;
				}
			}
		}

		private void btnSave_Click(object sender, EventArgs e) {
			if (canOpen.Checked) {
				if (string.IsNullOrEmpty(menu.fieldName)) {
					MessageBox.Show("请选择组件");
					return;
				}
				if (string.IsNullOrEmpty(tbxMenuName.Text)) {
					MessageBox.Show("请输入菜单名");
					return;
				}
			}
			menu.name = tbxMenuName.Text;
			menu.canOpen = canOpen.Checked;
			MODEL.ORM.orm ormInstance = new MODEL.ORM.orm();
			if (isNewOrModify) {
				ormInstance.Insert<MODEL.menu>(menu);
			} else {
				ormInstance.Update<MODEL.menu>(menu);
			}

			this.DialogResult = DialogResult.OK;
		}

		private void canOpen_CheckedChanged(object sender, EventArgs e) {
			browse.Enabled = canOpen.Checked;
			if (!string.IsNullOrEmpty(menu.fieldName)) {
				if (DialogResult.OK == MessageBox.Show("如果选中“添加目录”，您之前选择了dll组件将不起作用，是否继续？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)) {
					menu.dllName = string.Empty;
					menu.fieldName = string.Empty;
					lblHint.Text = "为选择组件";
				} else {
					canOpen.Checked = !canOpen.Checked;
				}
			}
		}

		private void privManager_Shown(object sender, EventArgs e) {
			if (!isNewOrModify) {
				tbxMenuName.Text = menu.name;
				lblHint.Text = menu.fieldName;
				canOpen.Checked = menu.canOpen;
				cannotOpen.Checked = !menu.canOpen;
			}
		}
	}
}
