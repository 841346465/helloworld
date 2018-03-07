using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using MODEL.ORM;
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
                default: break;
            }
        }

        protected virtual void Query() {
            dic.Clear();
            if (dataGridView1.DataSource == null) { return; }
            Type type = dataGridView1.DataSource.GetType().GetGenericArguments()[0];
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties) {
                string key = property.Name;
                string value = ((DisplayNameAttribute)(property.GetCustomAttribute(typeof(DisplayNameAttribute)))).DisplayName;
                dic.Add(new KeyValuePair<string, string>(key, value));
            }
            
            comboBox1.DataSource = dic;
            comboBox1.DisplayMember = "value";
            comboBox1.ValueMember = "key";
        }

        protected virtual void New() { }

        protected virtual void Modify() { }

        protected virtual void Delete() { }

        protected virtual void Filter(string filter,string key) {
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            Filter(textBox1.Text,comboBox1.SelectedValue.ToString());
        }

        List<KeyValuePair<string, string>> dic = new List<KeyValuePair<string, string>>();
        private void comboBox1_DropDown(object sender, EventArgs e) {

        }
    }
}
