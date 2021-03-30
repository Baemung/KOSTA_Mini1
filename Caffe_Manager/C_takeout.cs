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
    public partial class C_takeout : Form
    {
        public bool is_Takeout = false;

        public C_takeout()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            int len = sender.ToString().Split(' ').Length;
            if (sender.ToString().Split(' ')[len - 1] == "테이크아웃") is_Takeout = true;
            else is_Takeout = false;

            C_order co = new C_order();
            co.ShowDialog();
        }
    }
}
