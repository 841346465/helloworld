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
	public partial class CompanyRegister : Form {
		public CompanyRegister() {
			InitializeComponent();
			bindingSource1.DataSource = myCompany;
		}

		private List<MODEL.company> listCompany = new List<MODEL.company>();
		private MODEL.company myCompany = new MODEL.company();

		//录入
		private void btnRegister_Click(object sender, EventArgs e) {
			bindingSource1.EndEdit();
			try {
				new MODEL.ORM.orm().Insert(myCompany);
			} catch (ArgumentException err) {
				MessageBox.Show(err.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		//查询
		private void btnQuery_Click(object sender, EventArgs e) {
			listCompany = new MODEL.ORM.orm().Fetch<MODEL.company>(new MODEL.ORM.sql());

			guardReport r = new guardReport();
			r.SetData(listCompany);
			r.Show();
		}
	}
}
