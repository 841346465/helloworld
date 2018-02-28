using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using model;

namespace framework {
	public partial class menuManager : Form {
		public menuManager() {
			InitializeComponent();
			initNode();
			dosth();
		}

		List<menu> listmenu = new List<menu>();
		private void initNode() {
			listmenu.Add(new menu { id = 1, name = "节点1", parentId = 0, showOrder = 2 });
			listmenu.Add(new menu { id = 2, name = "节点2", parentId = 0, showOrder = 1 });
			listmenu.Add(new menu { id = 3, name = "节点3", parentId = 0, showOrder = 0 });
			listmenu.Add(new menu { id = 4, name = "节点4", parentId = 1, showOrder = 0 });
			listmenu.Add(new menu { id = 5, name = "节点5", parentId = 2, showOrder = 1 });
			listmenu.Add(new menu { id = 6, name = "节点6", parentId = 2, showOrder = 0 });
		}

		public void dosth() {
			foreach (var menu in listmenu.OrderBy(x => x.showOrder).Where(x => x.parentId == 0)) {
				TreeNode treeNode = new TreeNode(menu.name);
				treeNode.Tag = menu;
				treeView1.Nodes.Add(treeNode);
				findSubNode(menu, treeNode);
			}
		}
		//寻找子node
		private void findSubNode(menu menu, TreeNode treeNode) {
			if (listmenu.Count(x => x.parentId == menu.id) == 0) {
				return;
			} else {
				foreach (var subMenu in listmenu.OrderBy(x => x.showOrder).Where(x => x.parentId == menu.id)) {
					TreeNode subTreeNode = new TreeNode(subMenu.name);
					subTreeNode.Tag = subMenu;
					treeNode.Nodes.Add(subTreeNode);
					findSubNode(subMenu, subTreeNode);
				}
			}
		}

		private void addSibAndSubMenu_Click(object sender, EventArgs e) {
			var privManager1 = new privManager();
			var currentMenu = treeView1.SelectedNode.Tag as menu;
			var newMenu = currentMenu.Clone() as menu;
			switch ((sender as ToolStripMenuItem).Name){
				case "addSibMenu":
					newMenu.showOrder = currentMenu.showOrder + 1;
					break;
				case "addSubMenu":
					newMenu.showOrder = (treeView1.SelectedNode.LastNode.Tag as menu).showOrder + 1;
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
	}
}
