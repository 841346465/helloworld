using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace UI {
	public partial class GuardRegister : Form {
		public GuardRegister() {
			InitializeComponent();
			bindingSource1.DataSource = Guard;
		}
		private List<MODEL.guard> listGuard = new List<MODEL.guard>();
		private MODEL.guard Guard = new MODEL.guard();
		//录入
		private void btnRegister_Click(object sender, EventArgs e) {
			bindingSource1.EndEdit();
			new MODEL.ORM.orm().Insert(Guard);
		}
		//查询
		private void btnQuery_Click(object sender, EventArgs e) {
			listGuard = new MODEL.ORM.orm().Fetch<MODEL.guard>(new MODEL.ORM.sql());
			guardReport r = new guardReport();
			r.SetData(listGuard);
			r.Show();
		}

		private void button1_Click(object sender, EventArgs e) {
			var openfile = new OpenFileDialog();//打开文件对话框
			openfile.Filter = "image files(*.jpg;*.bmp,*.jpeg,*png);|*.jpg;*.bmp;*.jpeg;*.png";
			if (openfile.ShowDialog() == DialogResult.OK) {
				FileStream fsread = new FileStream(openfile.FileName, FileMode.Open);//数据流
				byte[] buffer = new byte[fsread.Length];
				fsread.Read(buffer, 0, (int)fsread.Length);
				string a = Convert.ToBase64String(buffer);
				Image image = Image.FromStream(fsread);
				Graphics graf = Graphics.FromImage(image);
				graf.DrawImage(image, 0, 0, pictureBox1.Width, pictureBox1.Height);
				pictureBox1.Image = image;
				pictureBox1.Show();
			}
		}
	}
}


