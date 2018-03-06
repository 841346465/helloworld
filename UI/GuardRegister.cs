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
            Guard.name = "fefe";
			bindingSource1.DataSource = Guard;
		}

		private MODEL.guard Guard = new MODEL.guard();
        MODEL.ReadCard.readCard reader = new MODEL.ReadCard.readCard();
        //保存
        private void btnSave_Click(object sender, EventArgs e) {
			bindingSource1.EndEdit();
			new MODEL.ORM.orm().Insert(Guard);
		}
		//取消
		private void btnCancel_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.Cancel;
		}

		private void btnImageBrowser_Click(object sender, EventArgs e) {
            /*var openfile = new OpenFileDialog();
			openfile.Filter = "image files(*.jpg;*.bmp,*.jpeg,*png);|*.jpg;*.bmp;*.jpeg;*.png";
			if (openfile.ShowDialog() == DialogResult.OK) {
				FileStream fstream = new FileStream(openfile.FileName, FileMode.Open);
				byte[] buffer = new byte[fstream.Length];
				fstream.Read(buffer, 0, (int)fstream.Length);
				Guard.base64FromImage = Convert.ToBase64String(buffer);
				Image image = Image.FromStream(fstream);
				Graphics graf = Graphics.FromImage(image);
				graf.DrawImage(image, 0, 0, pictureBox1.Width, pictureBox1.Height);
				pictureBox1.Image = image;
				pictureBox1.Show();
			}*/
            MODEL.ReadCard.IDCardData person=new MODEL.ReadCard.IDCardData();
            try {
                person = reader.Read();
                Guard.address = person.Address;
                Guard.date_of_birth = DateTime.ParseExact(person.Born, "yyyyMMdd", null);
                Guard.ID_card = person.IDCardNo;
                Guard.name = person.Name;
                if (!string.IsNullOrEmpty(person.PhotoFileName.Trim())) {
                    FileStream fstream = new FileStream(person.PhotoFileName.Trim(), FileMode.Open);
                    byte[] buffer = new byte[fstream.Length];
                    fstream.Read(buffer, 0, (int)fstream.Length);
                    Guard.base64FromImage = Convert.ToBase64String(buffer);
                    Image image = Image.FromStream(fstream);
                    Graphics graf = Graphics.FromImage(image);
                    graf.DrawImage(image, 0, 0, pictureBox1.Width, pictureBox1.Height);
                    pictureBox1.Image = image;
                    pictureBox1.Show();
                    fstream.Close();
                    FileInfo file = new FileInfo(person.PhotoFileName.Trim());
                    file.Delete();
                }
                Guard.sex = person.Sex;
                bindingSource1.ResetBindings(false);
            } catch (Exception err) {
                MessageBox.Show(err.Message);
            } finally {
            }
        }
    }
}


