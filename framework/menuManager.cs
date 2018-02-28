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
	public partial class menuManager : Form {
		public menuManager() {
			InitializeComponent();
			initNode();
			dosth(0);
		}

		List<node> listNode = new List<node>();
		private void initNode() {
			listNode.Add(new node { id = 1, name = "节点1", parentId = 0, order = 2 });
			listNode.Add(new node { id = 2, name = "节点2", parentId = 0, order = 1 });
			listNode.Add(new node { id = 3, name = "节点3", parentId = 0, order = 0 });
			listNode.Add(new node { id = 4, name = "节点4", parentId = 1, order = 0 });
			listNode.Add(new node { id = 5, name = "节点5", parentId = 2, order = 1 });
			listNode.Add(new node { id = 6, name = "节点6", parentId = 2, order = 0 });
		}

		public void dosth(int i) {
			foreach (var node in listNode.OrderBy(x => x.order).Where(x => x.parentId == 0)) {
				TreeNode treeNode = new TreeNode(node.name);
				findSubNode(node, treeNode);
				treeView1.Nodes.Add(treeNode);
			}
		}
		//寻找子node
		private void findSubNode(node node, TreeNode treeNode) {
			if (listNode.Count(x => x.parentId == node.id) == 0) {
				return;
			} else {
				foreach (var subNode in listNode.OrderBy(x => x.order).Where(x => x.parentId == node.id)) {
					TreeNode subTreeNode = new TreeNode(subNode.name);
					treeNode.Nodes.Add(subTreeNode);
					findSubNode(subNode, subTreeNode);
				}
			}
		}
		//寻找同级node 最小order
		private void findSibNode(node node, TreeNode treeNode) {
			if (listNode.Count(x => x.parentId == node.id) == 0) {
				return;
			} else {
				foreach (var subNode in listNode.Where(x => x.parentId == node.id)) {
					TreeNode subTreeNode = new TreeNode(subNode.name);
					treeNode.Nodes.Add(subTreeNode);
					findSubNode(subNode, subTreeNode);
				}
			}
		}
	}
}
