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
    public partial class C_orderlist : Form
    {
        string method;
        public C_orderlist(string str)
        {
            InitializeComponent();
            method = str;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            C_pay cp = new C_pay(method);
            cp.ShowDialog();
        }
    }
}
