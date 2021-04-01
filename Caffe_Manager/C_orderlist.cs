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
        int totalcnt;
        int totalprice;
        ListView lv2;

        public C_orderlist(string str, int cnt, int price, ListView lv)
        {
            InitializeComponent();
            method = str;
            totalcnt = cnt;
            totalprice = price;
            lbCount.Text = totalcnt.ToString();
            lbPrice.Text = totalprice.ToString();
            lv2 = lv;
            ListViewItem[] lvis = new ListViewItem[lv.Items.Count];
            for(int i = 0; i < lv.Items.Count; i++)
            {
                lvis[i] = (ListViewItem)lv.Items[i].Clone();
            }
            listView.Items.AddRange(lvis);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            C_pay cp = new C_pay(method, totalprice, lv2);
            if(cp.ShowDialog() == DialogResult.Cancel) 
                MessageBox.Show("주문이 취소되었습니다. 다시 주문해주세요.","주문 실패");
        }

        private void C_orderlist_Load(object sender, EventArgs e)
        {
            listView.View = View.Details;
        }
    }
}
