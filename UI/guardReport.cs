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
	public partial class guardReport : COM.baseReport {
		public guardReport() {
			InitializeComponent();
		}

		List<MODEL.guard> guardList = new List<MODEL.guard>();
		protected override void Query() {
			var ormInstance = new orm();
			sql sqlInstance = new sql();
			sqlInstance.Select(@"		
        id,		
		name,
		phone,
		certificate_num,
		service_area,
		ID_card,
		army,
		r_and_p,
		address,
		Hukou,
		contact_way,
		political_status,
		part_of_company,
		serviceunit,
		h_and_w,
		sex,
		soldier,
		approve_time,
		date_of_birth,
		major_skill,
		training_record,
		base64FromImage").From("guard");
			guardList = ormInstance.Fetch<MODEL.guard>(sqlInstance);
			dataGridView1.DataSource = guardList;
			base.Query();
		}

		protected override void New() {
			new guardRegister { isNew = true }.ShowDialog();
			Query();
		}

		protected override void Modify() {
			if (dataGridView1.SelectedRows.Count == 0) {
				MessageBox.Show("未选择修改数据");
			} else {
				var guardRegisterForm = new guardRegister { isNew = false };
				guardRegisterForm.SetData((dataGridView1.DataSource as List<MODEL.guard>)[dataGridView1.SelectedRows[0].Index]);
				guardRegisterForm.ShowDialog();
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
					dataGridView1.DataSource = ormInstance.Delete((dataGridView1.DataSource as List<MODEL.guard>)[dataGridView1.SelectedRows[0].Index]);
					Query();
				} else {
					MessageBox.Show("取消删除了");
				}
			}
		}

		protected override void Filter(List<KeyValuePair<string, string>> filter) {
			dataGridView1.DataSource = guardList.Where(x => {
				bool ret = true;
				Type type = x.GetType();
				PropertyInfo[] properties = type.GetProperties();
				foreach (KeyValuePair<string, string> kv in filter) {
					foreach (PropertyInfo property in properties) {
						if (property.Name == kv.Key) {
							ret = ret && property.GetValue(x).ToString().IndexOf(kv.Value) >= 0;
							break;
						}
					}			
				}
				return ret;
			}).ToList();
		}

		protected override void Export() {
			List<MODEL.guard> exportingList = dataGridView1.DataSource as List<MODEL.guard>;
			if (exportingList == null || exportingList.Count == 0) {
				MessageBox.Show("没有要导出的数据！");
			} else {
				MODEL.function.SaveCsvFile(dataGridView1.DataSource as List<MODEL.guard>);
				MessageBox.Show("导出成功！");
			}
		}

		protected override void Import() {
			List<MODEL.guard> insertingList = MODEL.function.ReadFromCsvFile<MODEL.guard>();
			if (insertingList == null || insertingList.Count == 0) {
				MessageBox.Show("解析文件失败，请确认文件格式正确，并以UTF-8编码保存");
			}
			orm ormInstance = new orm();
			int result = 0;
			foreach (MODEL.guard g in insertingList) {
				if (ormInstance.Insert(g) > 0) {
					result++;
				}
			}
			MessageBox.Show(string.Format("成功插入{0}行", result));
		}
	}
}
