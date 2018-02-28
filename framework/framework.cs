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
			ToolStripMenuItem sysManager = new ToolStripMenuItem("系统管理");
			sysManager.Click += SysManager_Click;
			helper.DropDownItems.Add(sysManager);
			menuMain.Items.Add(helper);
		}

		private void SysManager_Click(object sender, EventArgs e) {
			var tabPage1 = new TabPage();
			tabControl1.TabPages.Add(tabPage1);

			var sysForm = new sysManager();
			sysForm.TopLevel = false;
			sysForm.FormBorderStyle = FormBorderStyle.None;
			sysForm.Size = tabPage1.Size;
			sysForm.Dock = DockStyle.Fill;

			tabPage1.Controls.Add(sysForm);
			tabPage1.Text = sysForm.Text;

			sysForm.Show();
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
