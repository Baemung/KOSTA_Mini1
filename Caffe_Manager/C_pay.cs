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
    public partial class C_pay : Form
    {
        public C_pay(string str)
        {
            InitializeComponent();
            if(str == "카드결제")
            {
                lb.Text = "카드를 넣어주세요.";
            }
            else if(str == "현금결제")
            {
                lb.Text = "현금을 넣어주세요.";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            C_membership cm = new C_membership();
            cm.ShowDialog();
        }
    }
}
