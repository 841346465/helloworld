using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MODEL;

namespace framework {
	public partial class menuManager : Form {
		public menuManager() {
			InitializeComponent();
			addNode();
			initNode();
		}

		List<menu> listMenu = new List<menu>();
		private void addNode() {
			MODEL.ORM.orm ormInstance = new MODEL.ORM.orm();
			MODEL.ORM.sql sqlInstance = new MODEL.ORM.sql();
			sqlInstance.Select("*").From("menu");
			if (!MODEL.user.GetCurrentUser().isAdmin) {
				sqlInstance.Where("id in (select roleId from user_privileges where loginId = @0)", MODEL.user.GetCurrentUser().loginId);
			}
			listMenu = ormInstance.Fetch<MODEL.menu>(sqlInstance);
		}

		public void initNode() {
			foreach (var menu in listMenu.OrderBy(x => x.showOrder).Where(x => x.parentId == 0)) {
				TreeNode treeNode = new TreeNode(menu.name);
				treeNode.Tag = menu;
				treeView1.Nodes.Add(treeNode);
				findSubNode(menu, treeNode);
			}
		}
		//寻找子node
		private void findSubNode(menu menu, TreeNode treeNode) {
			if (listMenu.Count(x => x.parentId == menu.id) == 0) {
				return;
			} else {
				foreach (var subMenu in listMenu.OrderBy(x => x.showOrder).Where(x => x.parentId == menu.id)) {
					TreeNode subTreeNode = new TreeNode(subMenu.name);
					subTreeNode.Tag = subMenu;
					treeNode.Nodes.Add(subTreeNode);
					findSubNode(subMenu, subTreeNode);
				}
			}
		}

		private void addSibAndSubMenu_Click(object sender, EventArgs e) {
			var privManager1 = new privManager();
			menu currentMenu;
			if (treeView1.SelectedNode != null) {
				currentMenu = treeView1.SelectedNode.Tag as menu;
			} else {
				currentMenu = new menu { parentId = 0 };
			}
			var newMenu = currentMenu.Clone() as menu;
			switch ((sender as ToolStripMenuItem).Name) {
				case "addSibMenu":
					newMenu.showOrder = currentMenu.showOrder + 1;
					break;
				case "addSubMenu":
					if (treeView1.Nodes.Count == 0) { newMenu.showOrder = 0; } else {
						newMenu.showOrder = (treeView1.SelectedNode.LastNode.Tag as menu).showOrder + 1;
					}
					break;
				case "manageMenu":
					break;
				default: break;
			}
			privManager1.menu = newMenu;
			privManager1.ShowDialog();
		}

		private void treeView1_MouseClick(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Right) {
				TreeNode tn = treeView1.GetNodeAt(e.Location);
				if (tn != null) {
					treeView1.SelectedNode = tn;
				}
			}
		}

		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) {
			if (treeView1.SelectedNode == null) {
				manageMenu.Enabled = false;
				addSibMenu.Enabled = false;
				if (treeView1.Nodes.Count != 0) { addSubMenu.Enabled = false; }
				moveUp.Enabled = false;
				moveDown.Enabled = false;
			} else {
				manageMenu.Enabled = true;
				addSibMenu.Enabled = true;
				addSubMenu.Enabled = true;
				moveUp.Enabled = true;
				moveDown.Enabled = true;
			}
		}
	}
}
