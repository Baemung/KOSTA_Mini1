using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caffe_Manager
{
    public partial class SelectFrm : Form
    {
        public SelectFrm()
        {
            InitializeComponent();
            
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            CustomerTH cf = new CustomerTH();
            cf.ShowDialog();
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ManagerFrm1 mf = new ManagerFrm1();
            mf.ShowDialog();
        }
    }
}
