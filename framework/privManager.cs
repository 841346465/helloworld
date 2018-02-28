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
	public partial class privManager : Form {
		public privManager() {
			InitializeComponent();
		}

		private void browse_Click(object sender, EventArgs e) {
			var openFile = new OpenFileDialog();
			openFile.Filter = "(*.dll)|*.dll|All files(*.*)|*.*";
			openFile.ShowDialog();
		}
	}
}
