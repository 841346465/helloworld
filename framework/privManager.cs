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

		public model.menu menu { get; set; }

		public void SetMode(string mode) {
			switch (mode) {
				case "addSibMenu":
					break;
				case "addSubMenu":
					break;
				case "manageMenu":
					break;
				default:break;
			}
		}

		private void browse_Click(object sender, EventArgs e) {
			var openFile = new OpenFileDialog() {
				Filter = "Dll files|*.dll|All files|*.*",
				InitialDirectory = Application.StartupPath
			};
			if (openFile.ShowDialog() == DialogResult.OK) {
				menu.dllName = openFile.SafeFileName;
				listBox1.Items.Clear();
				Assembly assembly = Assembly.LoadFile(openFile.FileName);
				foreach (var type in assembly.GetTypes()) {
					if (type.IsSubclassOf(typeof(Form))) {
						//(assembly.CreateInstance(type.FullName) as Form).Show();
						addTypeNameToListView(type.FullName);
					}
				}
			}
		}

		public void addTypeNameToListView(string typeName) {
			listBox1.Items.Add(typeName);
		}

		private void btnSave_Click(object sender, EventArgs e) {
			if (listBox1.SelectedItem == null) {
				MessageBox.Show("请选择一个模块");
				return;
			} else if(string.IsNullOrEmpty(tbxMenuName.Text)){
				MessageBox.Show("请输入菜单名");
				return;
			} else {
				menu.fieldName = listBox1.SelectedItem.ToString();
				menu.name = tbxMenuName.Text;
				model.orm ormInstance= new model.orm();
				ormInstance.BeginTransaction();
				ormInstance.Insert<model.menu>(menu);
				menu.id = 100;
				ormInstance.Insert<model.menu>(menu);
				ormInstance.Commit();
			}
		}
	}
}
