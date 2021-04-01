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
    public partial class M_InvenAdd : Form
    {
        public M_InvenAdd()
        {
            InitializeComponent();
        }

        public string client;
        public string item;
        public string cnt;

        private void btn_OK_Click(object sender, EventArgs e)
        {
            client = tbClient.Text;
            item = tbItem.Text;
            cnt = tbCnt.Text;
        }

        private void tbCnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }
    }
}
