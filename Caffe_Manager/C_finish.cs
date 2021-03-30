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
    public partial class C_finish : Form
    {
        public C_finish(string str)
        {
            InitializeComponent();
            lb.Text = str;
            if(str == "주문이 취소되었습니다.")
            {
                lbD.Text = ""; lbDelay.Text = "";
                lbOn.Text = ""; lbOrdernumber.Text = "";
                lbP.Text = ""; lbPrice.Text = "";
            }
        }
    }
}
