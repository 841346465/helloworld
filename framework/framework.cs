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

namespace framework {
	public partial class framework : Form {
		public framework() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {
			InitMemuMain();
			addSysMenu();
			//ipContainer.Text = string.Join(",", ipv4List());
			ipContainer.Text = getIpv4List().First();
			
		}

		private void InitMemuMain() {
			ToolStripMenuItem tsmi;
			ToolStripMenuItem tsmiSub;

			//添加菜单
			tsmi = new ToolStripMenuItem("a");
			tsmiSub = new ToolStripMenuItem("a1", null, tsmiSub_Click, "tsmiName");
			tsmi.DropDownItems.Add(tsmiSub);
			tsmiSub = new ToolStripMenuItem("a2", null, null, "tsmiName");
			tsmi.DropDownItems.Add(tsmiSub);
			menuMain.Items.Add(tsmi);

			//添加菜单
			tsmi = new ToolStripMenuItem("b");
			tsmiSub = new ToolStripMenuItem("b1", null, tsmiSub_Click, "tsmiName");
			tsmi.DropDownItems.Add(tsmiSub);
			tsmiSub = new ToolStripMenuItem("b2", null, null, "tsmiName");
			tsmi.DropDownItems.Add(tsmiSub);
			menuMain.Items.Add(tsmi);
		}

		private void tsmiSub_Click(object sender, EventArgs e) {
			MessageBox.Show(sender.ToString());
		}

		private void addSysMenu() {
			ToolStripMenuItem helper = new ToolStripMenuItem("帮助");
			ToolStripMenuItem menuManager = new ToolStripMenuItem("菜单管理");
			menuManager.Click += menuManager_Click;
			/*ToolStripMenuItem privManager = new ToolStripMenuItem("权限管理");
			privManager.Click += privManager_Click;*/

			helper.DropDownItems.Add(menuManager);
			//helper.DropDownItems.Add(privManager);
			menuMain.Items.Add(helper);
		}

		/*private void privManager_Click(object sender, EventArgs e) {
			var tabPage = new TabPage();
			tabControl1.TabPages.Add(tabPage);

			var privForm = new privManager();
			privForm.TopLevel = false;
			privForm.FormBorderStyle = FormBorderStyle.None;
			privForm.Size = tabPage.Size;
			privForm.Dock = DockStyle.Fill;

			tabPage.Controls.Add(privForm);
			tabPage.Text = privForm.Text;

			privForm.Show();
		}*/

		private void menuManager_Click(object sender, EventArgs e) {
			var tabPage = new TabPage();
			tabControl1.TabPages.Add(tabPage);

			var menuForm = new menuManager();
			menuForm.TopLevel = false;
			menuForm.FormBorderStyle = FormBorderStyle.None;
			menuForm.Size = tabPage.Size;
			menuForm.Dock = DockStyle.Fill;

			tabPage.Controls.Add(menuForm);
			tabPage.Text = menuForm.Text;

			menuForm.Show();
		}

		private List<string> getIpv4List() {
			List<string> list = new List<string>();
			foreach (IPAddress ip in Dns.GetHostAddresses(Dns.GetHostName())) {
				if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) {
					list.Add(ip.ToString());
				}
			}
			return list;
		}

		private void tabControl1_MouseDoubleClick(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				tabControl1.TabPages.Remove(tabControl1.SelectedTab);
			}
		}

	}
}
