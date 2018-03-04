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
    public partial class guardReport : Form {
        public guardReport() {
            InitializeComponent();
        }

        public void SetData(DataTable dt) {
            this.dataGridView1.DataSource = dt;
        }

        public void SetData(object list) {
            this.dataGridView1.DataSource = list;
        }

        private void btnAddNew_Click(object sender, EventArgs e) {
            new GuardRegister().Show();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            if (dataGridView1.SelectedRows.Count == 0) {
                MessageBox.Show("未选择删除数据");
            } else {
                if (MessageBox.Show("是否删除当前行", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                    == DialogResult.OK) {
                    MessageBox.Show("删除了");
                } else {
                    MessageBox.Show("取消删除了");
                }
            }
        }

        private void btnModify_Click(object sender, EventArgs e) {
            if (dataGridView1.SelectedRows.Count == 0) {
                MessageBox.Show("未选择删除数据");
            } else {
                var guardRegisterForm = new GuardRegister();
                guardRegisterForm.Show();
            }
        }
    }
}
