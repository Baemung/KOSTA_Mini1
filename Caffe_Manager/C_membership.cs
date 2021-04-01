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
    public partial class C_membership : Form
    {
        string db = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anvo9\KOSTA_Project\Caffe_Manager\Caffe_Manager.mdf;Integrated Security = True; Connect Timeout = 30";
        string member_number = "010";
        int point;
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        public C_membership(int price)
        {
            InitializeComponent();
            
            conn.ConnectionString = db;
            conn.Open();
            cmd.Connection = conn;
            point = (int)Math.Round(price * 0.05,0);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            int len = sender.ToString().Split(' ').Length;
            int sublen;
            string cmd = sender.ToString().Split(' ')[len - 1];

            if (member_number.Length < 11)
            {
                switch (cmd)
                {
                    case "1":
                        member_number += $"{cmd}";
                        break;
                    case "2":
                        member_number += $"{cmd}";
                        break;
                    case "3":
                        member_number += $"{cmd}";
                        break;
                    case "4":
                        member_number += $"{cmd}";
                        break;
                    case "5":
                        member_number += $"{cmd}";
                        break;
                    case "6":
                        member_number += $"{cmd}";
                        break;
                    case "7":
                        member_number += $"{cmd}";
                        break;
                    case "8":
                        member_number += $"{cmd}";
                        break;
                    case "9":
                        member_number += $"{cmd}";
                        break;
                    case "0":
                        member_number += $"{cmd}";
                        break;
                    case "취소":
                        member_number = "010";
                        break;
                    case "←":
                        if(member_number.Length > 3)
                        {
                            sublen = member_number.Length;
                            member_number = member_number.Substring(0, sublen - 1);
                        }
                        break;
                }
            }
            else if (member_number.Length == 11)
            {
                switch (cmd)
                {
                    case "취소":
                        member_number = "010";
                        break;
                    case "←":
                        sublen = member_number.Length;
                        member_number = member_number.Substring(0, sublen - 1);
                        break;
                }
            }
            tbNumber.Text = member_number;
		}

        private void btnOK_Click(object sender, EventArgs e)
        {
            int len = sender.ToString().Split(' ').Length;
            string mem = sender.ToString().Split(' ')[len - 1];

            if (mem == "확인")
            {
                C_finish cf = new C_finish("주문이 완료되었습니다.");
                try
                {
                    string sql = $"insert into memberinfo values (N'{member_number}',{point})";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    string sql = $"update memberinfo set point = point + {point} where phone = N'{member_number}'";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                cf.ShowDialog();
            }
            else if (mem == "취소")
            {
                C_finish cf = new C_finish("주문이 완료되었습니다.");
                cf.ShowDialog();
            }
        }

        private void tbNumber_TextChanged(object sender, EventArgs e)
        {
            if(member_number.Length == 11)
            {
                btnOK.Enabled = true;
            }
            else
            {
                btnOK.Enabled = false;
            }
        }
    }
}
