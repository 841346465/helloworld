using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI {
	public partial class companyRegister : Form {
		public companyRegister() {
			InitializeComponent();
            bindingSource1.DataSource = new MODEL.company();
        }

        public bool isNew = true;

        public void SetData(MODEL.company data) {
            bindingSource1.DataSource = data;
        }
        //录入
        private void btnRegister_Click(object sender, EventArgs e) {
			bindingSource1.EndEdit();
			try {
                if (isNew) {
                    new MODEL.ORM.orm().Insert(bindingSource1.DataSource as MODEL.company);
                } else {
                    new MODEL.ORM.orm().Update(bindingSource1.DataSource as MODEL.company);
                }
                DialogResult = DialogResult.OK;
            } catch (ArgumentException err) {
				MessageBox.Show(err.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
            }
            
		}

        private void btnCancel_Click(object sender, EventArgs e) {

        }
    }
}
