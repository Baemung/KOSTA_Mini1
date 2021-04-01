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
    public partial class Select : Form
    {
        public Select()
        {
            InitializeComponent();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            C_takeout cf = new C_takeout();
            cf.ShowDialog();
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            M_First mf = new M_First();
            mf.ShowDialog();
        }
    }
}
