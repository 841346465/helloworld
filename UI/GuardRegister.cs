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
	public partial class guardRegister : Form {
		public guardRegister() {
			InitializeComponent();
			bindingSource1.DataSource = new MODEL.guard();
		}

        public bool isNew = true;
        MODEL.ReadCard.readCard reader = new MODEL.ReadCard.readCard();

        public void SetData(MODEL.guard data) {
            bindingSource1.DataSource = data;
            if (!string.IsNullOrEmpty(data.base64FromImage)) {
                byte[] buffer = Convert.FromBase64String(data.base64FromImage);
                MemoryStream ms = new MemoryStream(buffer);
                Image img = Image.FromStream(ms);
                Graphics graf = Graphics.FromImage(img);
                graf.DrawImage(img, 0, 0, pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = img;
                pictureBox1.Show();
                ms.Close();
            }
        }
        //保存
        private void btnSave_Click(object sender, EventArgs e) {
			bindingSource1.EndEdit();
            try {
                if (isNew) {
                    new MODEL.ORM.orm().Insert(bindingSource1.DataSource as MODEL.guard);
                } else {
                    new MODEL.ORM.orm().Update(bindingSource1.DataSource as MODEL.guard);
                }
                DialogResult = DialogResult.OK;
            } catch (ArgumentException err) {
                MessageBox.Show(err.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
            }
        }
		//取消
		private void btnCancel_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.Cancel;
		}

		private void btnImageBrowser_Click(object sender, EventArgs e) {
            var Guard = bindingSource1.DataSource as MODEL.guard;
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


