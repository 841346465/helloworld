using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class CompanyRegister : Form
    {
        public CompanyRegister()
        {
            InitializeComponent();
            bindingSource1.DataSource = myCompany;
        }

        private List<model.company> listCompany = new List<model.company>();
        private model.company myCompany = new model.company();

        //录入
        private void btnRegister_Click(object sender, EventArgs e)
        {
            bindingSource1.EndEdit();
            myCompany.Insert();
        }
        //查询
        private void btnQuery_Click(object sender, EventArgs e)
        {
            listCompany = myCompany.QueryList();
            Report r = new Report();
            r.SetData(listCompany);
            r.Show();
        }
    }
}
