using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Reflection;

namespace framework {
	public partial class framework : Form {
		public framework() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {
			addMenu();
			//这部分改为根据当前用户去数据库查询，获得List<model.menu> 

			initMemu();
			initStatusStrip();
		}
		readonly List<model.menu> sysMenuList = new List<model.menu> {
			new model.menu {  name = "菜单管理", dllName = "framework.exe", fieldName = "framework.menuManager" },
			new model.menu {  name = "新用户注册", dllName = "framework.exe", fieldName = "framework.register" }
		};
		List<model.menu> listMenu = new List<model.menu>();

		#region 测试时代码，正式会删掉
		private void addMenu() {
			listMenu.Add(new model.menu { id = 1, name = "节点1", dllName = "UI.dll", fieldName = "UI.CompanyRegister", canOpen = false, parentId = 0, showOrder = 1 });
			listMenu.Add(new model.menu { id = 2, name = "节点2", parentId = 0, showOrder = 1 });
			listMenu.Add(new model.menu { id = 3, name = "节点3", parentId = 0, showOrder = 2 });
			listMenu.Add(new model.menu {
				id = 4, name = "节点1的子菜单", dllName = "UI.dll", fieldName = "UI.login", canOpen = true, parentId = 1, showOrder = 0
			});
			listMenu.Add(new model.menu { id = 5, name = "节点2的第二个子菜单", parentId = 2, showOrder = 1 });
			listMenu.Add(new model.menu { id = 6, name = "节点2的第一个子菜单", parentId = 2, showOrder = 0 });
			listMenu.Add(new model.menu { id = 7, name = "节点2的第二个子菜单的第一个", dllName = "UI.dll", fieldName = "UI.GuardRegister", canOpen = true, parentId = 5, showOrder = 0 });
			//listmenu.OrderBy(x => x.showOrder);
		}
		#endregion

		private void initMemu() {
			foreach (var menu in listMenu.OrderBy(x => x.showOrder).Where(x => x.parentId == 0)) {
				ToolStripMenuItem menuItem = new ToolStripMenuItem(menu.name);
				if (menu.canOpen) {
					bindClickResponse(menuItem, menu);
				}
				menuMain.Items.Add(menuItem);
				findSubNode(menu, menuItem);
			}
			#region 管理员添加系统设置菜单
			if (model.user.GetCurrentUser().isAdmin) {
				addSysMenu();
			}
			#endregion
		}

		//寻找子菜单
		private void findSubNode(model.menu menu, ToolStripMenuItem menuItem) {
			foreach (var subMenu in listMenu.OrderBy(x => x.showOrder).Where(x => x.parentId == menu.id)) {
				ToolStripMenuItem subMenuItem = new ToolStripMenuItem(subMenu.name);
				if (subMenu.canOpen) {
					bindClickResponse(subMenuItem, subMenu);
				};
				subMenuItem.Tag = subMenu;
				menuItem.DropDownItems.Add(subMenuItem);
				findSubNode(subMenu, subMenuItem);
			}
		}

		//绑定点击事件
		private void bindClickResponse(ToolStripMenuItem menuItem, model.menu menu) {
			menuItem.Click += (object sender, EventArgs e) => {
				// 寻找打开的窗口，如果有已经打开的则不新增
				if (tabControl1.TabPages.ContainsKey(menu.fieldName)) {
					tabControl1.SelectedTab = tabControl1.TabPages[menu.fieldName];
				} else {
					Assembly assembly = Assembly.LoadFile(Application.StartupPath + "\\" + menu.dllName);
					var currentForm = (assembly.CreateInstance(menu.fieldName) as Form);
					currentForm.TopLevel = false;
					currentForm.FormBorderStyle = FormBorderStyle.None;
					currentForm.Dock = DockStyle.Fill;
					var tabPage = new TabPage();
					tabPage.Name = menu.fieldName;
					tabPage.Controls.Add(currentForm);
					tabPage.Text = currentForm.Text;
					tabControl1.TabPages.Add(tabPage);
					tabControl1.SelectedTab = tabPage;
					currentForm.Show();
				}
			};
		}

		private void initStatusStrip() {
			ipContainer.Text += model.function.getIpv4List().First();
			userNameStatus.Text += model.user.GetCurrentUser().name;
		}

		private void addSysMenu() {
			ToolStripMenuItem menuItem = new ToolStripMenuItem("系统管理");
			foreach (var sysMenu in sysMenuList) {
				ToolStripMenuItem subMenuItem = new ToolStripMenuItem(sysMenu.name);
				bindClickResponse(subMenuItem, sysMenu);
				menuItem.DropDownItems.Add(subMenuItem);
			}
			menuMain.Items.Add(menuItem);
		}

		private void tabControl1_MouseDoubleClick(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				tabControl1.TabPages.Remove(tabControl1.SelectedTab);
			}
		}
	}
}
