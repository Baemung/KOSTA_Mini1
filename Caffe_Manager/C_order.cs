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
    public partial class C_order : Form
    {
        public C_order()
        {
            InitializeComponent();
        }

        private void btn_Payment_Click(object sender, EventArgs e)
        {
            int len = sender.ToString().Split(' ').Length;
            string method = sender.ToString().Split(' ')[len - 1];

            C_orderlist col = new C_orderlist(method);

            if(col.ShowDialog() == DialogResult.Cancel)
            {
                C_finish cf = new C_finish("주문이 취소되었습니다.");
                cf.ShowDialog();
            }
            else
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            C_finish cf = new C_finish("주문이 취소되었습니다.");
            if (cf.ShowDialog() != DialogResult.Cancel) return;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            C_menu_detail md = new C_menu_detail();
            if(md.ShowDialog() == DialogResult.OK)
            {
                ListViewItem lv = new ListViewItem(americano.AccessibleName);
                list_order.Items.Add(lv);
            }
        }
    }
}
