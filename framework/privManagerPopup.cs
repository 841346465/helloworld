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
	public partial class privManagerPopup : Form {
		public privManagerPopup() {
			InitializeComponent();
		}

		public void SetList(List<string> list) {
			list.Sort();
			foreach (string item in list) {
				listBox1.Items.Add(item);
			}
		}

		public string GetSelected {
			get {
				return listBox1.SelectedItem.ToString();
			}
		}
		private void btnSave_Click(object sender, EventArgs e) {
			if (listBox1.SelectedItem == null) {
				MessageBox.Show("请选择一个模块");
				return;
			}
			this.DialogResult = DialogResult.OK;
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
		}
	}
}
