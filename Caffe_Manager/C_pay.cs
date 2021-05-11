using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caffe_Manager
{
    public partial class C_pay : Form
    {
        public int totalprice;
        public int totalwait;
        public int ordernumber;
        public string method;
        public bool is_card;
        string db = Program.db; 
        ListView lv3;

        public C_pay(string str, int price, ListView lv2)
        {
            InitializeComponent();

            method = str;
            if (str == "카드")
            {
                lb.Text = "카드를 넣어주세요.";
                is_card = true;
            }
            else if(str == "현금")
            {
                lb.Text = "현금을 넣어주세요.";
                is_card = false;
            }
         
            lbPrice.Text = price.ToString();
            totalprice = price;
            lv3 = lv2;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string menu;
            string size;
            int quantity;
            int delay;

            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            conn.ConnectionString = db;
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "insert into orderID values (getdate())";
            cmd.ExecuteNonQuery();

            for (int i = 0; i < lv3.Items.Count; i++)
            {
                dataGrid.Rows.Clear();
                dataGrid.Columns.Clear();
                menu = lv3.Items[i].SubItems[0].ToString().Split('{')[1].Split('}')[0];
                size = lv3.Items[i].SubItems[1].ToString().Split('{')[1].Split('}')[0];
                quantity = Int32.Parse(lv3.Items[i].SubItems[2].ToString().Split('{')[1].Trim('}'));
                cmd = new SqlCommand($"select * from menu where mName = N'{menu}'", conn);
                SqlDataReader sr = cmd.ExecuteReader();

                for (int j = 0; j < sr.FieldCount; j++)
                {
                    dataGrid.Columns.Add(sr.GetName(j), sr.GetName(j));
                }
                for (int k = 0; sr.Read(); k++)
                {
                    object[] oArr = new object[sr.FieldCount];
                    sr.GetValues(oArr);
                    dataGrid.Rows.Add(oArr);
                }
                sr.Close();
                delay = Int32.Parse(dataGrid[5,0].Value.ToString()) * quantity;


                dataGrid.Rows.Clear();
                dataGrid.Columns.Clear();
                cmd = new SqlCommand($"select max(id) from orderID", conn);
                sr = cmd.ExecuteReader();

                for (int j = 0; j < sr.FieldCount; j++)
                {
                    dataGrid.Columns.Add(sr.GetName(j), sr.GetName(j));
                }
                for (int k = 0; sr.Read(); k++)
                {
                    object[] oArr = new object[sr.FieldCount];
                    sr.GetValues(oArr);
                    dataGrid.Rows.Add(oArr);
                }
                sr.Close();

                int id = Int32.Parse(dataGrid[0, 0].Value.ToString());
                ordernumber = id;
                cmd.CommandText = $"Insert into COrderStatus values ({id}, N'{menu}', N'{size}', {quantity}, {delay}, {totalprice})";
                cmd.ExecuteNonQuery();
                
            }
            conn.Close();
            Close();

            if (is_card)
            {
                C_pay_sign cps = new C_pay_sign();
                cps.ShowDialog();
            }
             C_membership cm = new C_membership(totalprice);
             cm.ShowDialog();
        }
    }
}
