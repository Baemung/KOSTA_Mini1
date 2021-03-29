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
    public partial class CustomerOrder : Form
    {
        public CustomerOrder()
        {
            InitializeComponent();
        }

        private void btn_Payment_Click(object sender, EventArgs e)
        {
            CustomerOrderList col = new CustomerOrderList();

            if(col.ShowDialog() == DialogResult.Cancel)
            {
                finishFrm cf = new finishFrm("주문이 취소되었습니다.");
                cf.ShowDialog();
            }
            else
            {
                finishFrm cf = new finishFrm("주문이 완료되었습니다.");
                cf.ShowDialog();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            finishFrm cf = new finishFrm("주문이 취소되었습니다.");
            if (cf.ShowDialog() != DialogResult.Cancel) return;
        }
    }
}
