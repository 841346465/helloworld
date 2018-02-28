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
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        public void SetData(DataTable dt)
        {
            this.dataGridView1.DataSource = dt;
        }

        public void SetData(object list)
        {
            this.dataGridView1.DataSource = list;
        }
    }
}
