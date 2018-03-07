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

namespace UI {
    public partial class compayReport : COM.baseReport {
        public compayReport() {
            InitializeComponent();
        }

        List<MODEL.company> companyList = new List<MODEL.company>();
        protected override void Query() {
            var ormInstance = new orm();
            sql sqlInstance = new sql();
            sqlInstance.Select("*").From("company");
            companyList = ormInstance.Fetch<MODEL.company>(sqlInstance);
            dataGridView1.DataSource = companyList;
            base.Query();
        }

        protected override void New() {
            new companyRegister { isNew = true }.ShowDialog();
            Query();
        }

        protected override void Modify() {
            if (dataGridView1.SelectedRows.Count == 0) {
                MessageBox.Show("未选择修改数据");
            } else {
                var companyRegisterForm = new companyRegister { isNew = false };
                companyRegisterForm.SetData((dataGridView1.DataSource as List<MODEL.company>)[dataGridView1.SelectedRows[0].Index]);
                companyRegisterForm.ShowDialog();
                Query();
            }
        }

        protected override void Delete() {
            if (dataGridView1.SelectedRows.Count == 0) {
                MessageBox.Show("未选择删除数据");
            } else {
                if (MessageBox.Show("是否删除当前行", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                    == DialogResult.OK) {
                    var ormInstance = new orm();
                    dataGridView1.DataSource = ormInstance.Delete((dataGridView1.DataSource as List<MODEL.company>)[dataGridView1.SelectedRows[0].Index]);
                    Query();
                } else {
                    MessageBox.Show("取消删除了");
                }
            }
        }

        protected override void Filter(string filter, string key) {
            dataGridView1.DataSource = companyList.Where(x => {
                Type type = x.GetType();
                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo property in properties) {
                    if (property.Name == key) {
                        return property.GetValue(x).ToString().IndexOf(filter) >= 0;
                    }
                }
                return false;
            }).ToList();
        }
    }
}
