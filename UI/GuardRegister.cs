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
        private List<model.guard> listGuard = new List<model.guard>();
        private model.guard Guard = new model.guard();
        //录入
        private void btnRegister_Click(object sender, EventArgs e) {
            bindingSource1.EndEdit();
            Guard.Insert();
        }
        //查询
        private void btnQuery_Click(object sender, EventArgs e) {
            listGuard = Guard.Querylist();
            Report r = new Report();
            r.SetData(listGuard);
            r.Show();
        }

        private void button1_Click(object sender, EventArgs e) {
            var openfile = new OpenFileDialog();//打开文件对话框
            openfile.Filter = "image files(*.jpg;*.bmp,*.jpeg,*png);|*.jpg;*.bmp;*.jpeg;*.png";
            openfile.ShowDialog();
            FileStream fsread = new FileStream(openfile.FileName, FileMode.Open);//数据流
            byte[] buffer = new byte[fsread.Length];
            fsread.Read(buffer, 0, (int)fsread.Length);
            string a = Convert.ToBase64String(buffer);
           // buffer-->string
                //insert itn v
            //fsread.Read(buffer, 0, 2048 * 1024);
          
        }

            //path 路径
            //定义 一个 filestream 方法open 得到byte[]
            /*byte[]
             * 做base64编码 得到string
             * 把string 传到数据库
             */
           
        }
    }


