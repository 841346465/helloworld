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
			initMemu();
			initStatusStrip();
		}

		public override void Refresh() {
			listMenu.Clear();
			menuMain.Items.Clear();
			addMenu();
			initMemu();
		}
		readonly List<MODEL.menu> sysMenuList = new List<MODEL.menu> {
			new MODEL.menu {  name = "菜单管理", dllName = "framework.exe", fieldName = "framework.menuManager" },
			new MODEL.menu {  name = "新用户注册", dllName = "framework.exe", fieldName = "framework.register" }
		};
		List<MODEL.menu> listMenu = new List<MODEL.menu>();

		private void addMenu() {
			MODEL.ORM.orm ormInstance = new MODEL.ORM.orm();
			MODEL.ORM.sql sqlInstance = new MODEL.ORM.sql();
			sqlInstance.Select("*").From("menu");
			if (!MODEL.user.GetCurrentUser().isAdmin) {
				sqlInstance.Where("id in (select roleId from user_privileges where loginId = @0)", MODEL.user.GetCurrentUser().loginId);
			}
			listMenu = ormInstance.Fetch<MODEL.menu>(sqlInstance);
		}

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
			if (MODEL.user.GetCurrentUser().isAdmin) {
				addSysMenu();
			}
			#endregion
		}

		//寻找子菜单
		private void findSubNode(MODEL.menu menu, ToolStripMenuItem menuItem) {
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
		private void bindClickResponse(ToolStripMenuItem menuItem, MODEL.menu menu) {
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
					tabPage.Text = menu.name; 
					tabControl1.TabPages.Add(tabPage);
					tabControl1.SelectedTab = tabPage;
					currentForm.Show();
				}
			};
		}

		private void initStatusStrip() {
			ipContainer.Text += MODEL.function.getIpv4List().First();
			userNameStatus.Text += MODEL.user.GetCurrentUser().name;
		}

		private void addSysMenu() {
			ToolStripMenuItem menuItem = new ToolStripMenuItem("系统管理");
			foreach (var sysMenu in sysMenuList) {
				ToolStripMenuItem subMenuItem = new ToolStripMenuItem(sysMenu.name);
				bindClickResponse(subMenuItem, sysMenu);
				menuItem.DropDownItems.Add(subMenuItem);
			}
			{
				ToolStripMenuItem subMenuItem = new ToolStripMenuItem("刷新");
				subMenuItem.Click += (object sender, EventArgs e) => { Refresh(); };
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
