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
	public partial class register : Form {
		public register() {
			InitializeComponent();
			addNode();
			initNode();
		}

		List<menu> listmenu = new List<menu>();
		private void addNode() {
			listmenu.Add(new menu { id = 1, name = "节点1", parentId = 0, showOrder = 2 });
			listmenu.Add(new menu { id = 2, name = "节点2", parentId = 0, showOrder = 1 });
			listmenu.Add(new menu { id = 3, name = "节点3", parentId = 0, showOrder = 0 });
			listmenu.Add(new menu { id = 4, name = "节点4", parentId = 1, showOrder = 0 });
			listmenu.Add(new menu { id = 5, name = "节点5", parentId = 2, showOrder = 1 });
			listmenu.Add(new menu { id = 6, name = "节点6", parentId = 2, showOrder = 0 });
		}

		public void initNode() {
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

		private void chkSelectAll_CheckedChanged(object sender, EventArgs e) {
			recursion(treeView1.Nodes);
		}

		private void recursion(TreeNodeCollection nodes) {
			foreach (TreeNode node in nodes) {
				node.Checked = chkSelectAll.Checked;
				if (node.Nodes.Count > 0) {
					recursion(node.Nodes);
				}
			}
		}

		private void btnSave_Click(object sender, EventArgs e) {
			if (string.IsNullOrEmpty(txtLoginName.Text)) {
				MessageBox.Show("请录入用户登录名");
				return;
			} else if (string.IsNullOrEmpty(txtName.Text)) {
				MessageBox.Show("请录入真实姓名");
				return;
			} else if ((txtPassword.Text).Length < 6) {
				MessageBox.Show("密码至少需要六位字符");
				return;
			} else if (!txtPassword.Text.Equals(txtEnsurePassword.Text)) {
				MessageBox.Show("两次密码输入不一致");
				return;
			}
		}
	}
}
