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
    public partial class C_finish : Form
    {
        string db = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anvo9\KOSTA_Project\Caffe_Manager\Caffe_Manager.mdf;Integrated Security = True; Connect Timeout = 30";

        public C_finish(string str) 
        { 
            InitializeComponent();
            if (str == "주문이 취소되었습니다.")
            {
                lbD.Text = ""; lbDelay.Text = "";
                lb.Text = str;
                lbOn.Text = ""; lbOrdernumber.Text = "";
                lbP.Text = ""; lbPrice.Text = "";
            }

            else
            {
                SqlConnection conn = new SqlConnection();
                SqlCommand cmd = new SqlCommand();
                conn.ConnectionString = db;
                conn.Open();
                cmd.Connection = conn;

                string sql = $"select sum(delay) from COrderStatus union select max(id) from orderID";
                cmd.CommandText = sql;
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
                string totalwait = dataGrid[0, 0].Value.ToString();
                string id = dataGrid[0, 1].Value.ToString();


                dataGrid.Rows.Clear();
                dataGrid.Columns.Clear();
                sql = $"select distinct(totalprice) from COrderStatus where id = {id}";
                cmd.CommandText = sql;
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
                string totalprice = dataGrid[0, 0].Value.ToString();

                conn.Close();

                lb.Text = str;

                lbDelay.Text = totalwait + " min";
                lbOrdernumber.Text = id;
                lbPrice.Text = totalprice;
            }
        }
    }
}
