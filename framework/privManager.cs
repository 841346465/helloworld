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

		public void SetMode(string mode) {
			switch (mode) {
				case "addSibMenu":
					break;
				case "addSubMenu":
					break;
				case "manageMenu":
					break;
				default: break;
			}
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
					MessageBox.Show(menu.dllName+"中不包含窗口组件，无法创建菜单");
					menu.fieldName = string.Empty;
					lblHint.Text = "未选择组件";
					return;
				}
				privManagerPopup popup = new privManagerPopup();
				popup.SetList(listClassName);
				popup.ShowDialog();
				lblHint.Text = popup.GetSelected;
				menu.fieldName = popup.GetSelected;
			}
		}

		private void btnSave_Click(object sender, EventArgs e) {
			if (string.IsNullOrEmpty(menu.fieldName)) {
				MessageBox.Show("请选择组件");
				return;
			}
			if (string.IsNullOrEmpty(tbxMenuName.Text)) {
				MessageBox.Show("请输入菜单名");
				return;
			} else {
				menu.name = tbxMenuName.Text;
				MODEL.ORM.orm ormInstance = new MODEL.ORM.orm();
				//ormInstance.BeginTransaction();
				ormInstance.Insert<MODEL.menu>(menu);
				//ormInstance.Commit();
				this.DialogResult = DialogResult.OK;
			}
		}
	}
}
