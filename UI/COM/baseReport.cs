using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace UI.COM {
	public partial class baseReport : Form {
		public baseReport() {
			InitializeComponent();
		}

		private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
			switch (e.ClickedItem.Name) {
				case "btnQuery":
					Query();
					break;
				case "btnNew":
					New();
					break;
				case "btnModify":
					Modify();
					break;
				case "btnDelete":
					Delete();
					break;
				case "btnImport":
					Import();
					break;
				case "btnExport":
					Export();
					break;
				default: break;
			}
		}

		protected virtual void Query() {
			dic.Clear();
			if (dataGridView1.DataSource == null) { return; }
			Type type = dataGridView1.DataSource.GetType().GetGenericArguments()[0];
			PropertyInfo[] properties = type.GetProperties();
			foreach (PropertyInfo property in properties) {
				DisplayNameAttribute displayAttr = property.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute;
				MODEL.ORM.VisableAttribute visableAttr = property.GetCustomAttribute(typeof(MODEL.ORM.VisableAttribute)) as MODEL.ORM.VisableAttribute;
				if (visableAttr != null && visableAttr.visable == false) {
					dataGridView1.Columns[property.Name].Visible = false;
				}
				if (displayAttr != null) {
					string key = property.Name;
					string value = displayAttr.DisplayName;
					dic.Add(new KeyValuePair<string, string>(key, value));
				}
			}

			comboBox1.DataSource = dic.ToArray();
			comboBox1.DisplayMember = "value";
			comboBox1.ValueMember = "key";

			comboBox2.DataSource = dic.ToArray();
			comboBox2.DisplayMember = "value";
			comboBox2.ValueMember = "key";

			comboBox3.DataSource = dic.ToArray();
			comboBox3.DisplayMember = "value";
			comboBox3.ValueMember = "key";
		}

		protected virtual void New() { }

		protected virtual void Modify() { }

		protected virtual void Delete() { }

		protected virtual void Import() { }

		protected virtual void Export() { }

		protected virtual void Filter(List<KeyValuePair<string, string>> filter) {
		}

		private void textBox_TextChanged(object sender, EventArgs e) {
			Filter(new List<KeyValuePair<string, string>> {
				new KeyValuePair<string, string>(comboBox1.SelectedValue.ToString(), textBox1.Text),
				new KeyValuePair<string, string>(comboBox2.SelectedValue.ToString(), textBox2.Text),
				new KeyValuePair<string, string>(comboBox3.SelectedValue.ToString(), textBox3.Text)
			});
		}

		List<KeyValuePair<string, string>> dic = new List<KeyValuePair<string, string>>();
		private void comboBox_DropDown(object sender, EventArgs e) {

		}
	}
}
