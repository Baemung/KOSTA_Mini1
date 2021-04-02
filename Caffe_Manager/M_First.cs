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
using System.IO;

namespace Caffe_Manager
{
    public partial class M_First : Form
    {
        public M_First()
        {
            InitializeComponent();
            lb_monthlyP.Visible = false;
            cb_monthlyP.Visible = false;
            sqlConn.ConnectionString = db;
            sqlConn.Open();
            sqlCom.Connection = sqlConn;
        }
        
        SqlConnection sqlConn = new SqlConnection();
        SqlCommand sqlCom = new SqlCommand();
        string db = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anvo9\KOSTA_Project\Caffe_Manager\Caffe_Manager.mdf;Integrated Security = True; Connect Timeout = 30";
        
        private void ClearGrid()
        {
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();
        }

        public string GetToKen(int i, string src, char del)
        {
            string[] sArr = src.Split(del);
            return sArr[i];
        }

        public void RunSql(string Sql)
        {   // Select id, fCode from Facility
            try
            {
                string ss = GetToKen(0, Sql.Trim().ToLower(), ' ');
                sqlCom.CommandText = Sql;
                if (ss == "select")
                {
                    ClearGrid();
                    SqlDataReader sr = sqlCom.ExecuteReader();
                    for (int i = 0; i < sr.FieldCount; i++)
                    {
                        dataGrid.Columns.Add(sr.GetName(i), sr.GetName(i));
                    }
                    for (int k = 0; sr.Read(); k++)
                    {
                        object[] oArr = new object[sr.FieldCount];
                        sr.GetValues(oArr);
                        dataGrid.Rows.Add(oArr);
                    }
                    sr.Close();
                }
                else
                {
                    sqlCom.ExecuteNonQuery();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void OrderStatus_Click(object sender, EventArgs e)
        {
            lbMember.Visible = true;
            tbMember.Visible = true;
            lb_monthlyP.Visible = false;
            cb_monthlyP.Visible = false;
            btnServ.Visible = true;
            RunSql($"select * from COrderStatus");
        }

        private void M_Menu_Click(object sender, EventArgs e)
        {
            lbMember.Visible = true;
            tbMember.Visible = true;
            lb_monthlyP.Visible = false;
            cb_monthlyP.Visible = false;
            btnServ.Visible = false;
            RunSql($"select * from Menu");
        }

        private void M_orderhistory_Click(object sender, EventArgs e)
        {
            lbMember.Visible = true;
            tbMember.Visible = true;
            lb_monthlyP.Visible = false;
            cb_monthlyP.Visible = false;
            btnServ.Visible = false;
            RunSql($"select * from MOrderHistory");
        }

        private void M_Inven_Click(object sender, EventArgs e)
        {
            lbMember.Visible = true;
            tbMember.Visible = true;
            lb_monthlyP.Visible = false;
            cb_monthlyP.Visible = false;
            btnServ.Visible = false;
            RunSql($"select * from MInvenControl");
        }
        private void M_sales_Click(object sender, EventArgs e)
        {
            lb_monthlyP.Visible = true;
            cb_monthlyP.Visible = true;
            lbMember.Visible = false;
            tbMember.Visible = false;
            btnServ.Visible = false;
            RunSql($"select * from Profits");
        }

        private void btn_ia_Click(object sender, EventArgs e)
        {
            M_InvenAdd ia = new M_InvenAdd();
            if (ia.ShowDialog() == DialogResult.Cancel) return;
            RunSql($"insert into MOrderHistory values (GETDATE(), N'{ia.client}', N'{ia.item}', N'{ia.cnt}')");
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            M_RegistP isrt = new M_RegistP();
            isrt.ShowDialog();
        }

        private void btnServ_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgvr = dataGrid.SelectedRows[0];
            if (dgvr.Cells[0].Value != null)
            {
                RunSql($"delete from COrderStatus where id = {dgvr.Cells[0].Value} and menu = N'{dgvr.Cells[1].Value}'");
                MessageBox.Show("서비스 완료", "완료");
                RunSql($"select * from COrderStatus");
            }
            else
            {
                MessageBox.Show("주문이 없습니다.", "주문없음");
            }
        }

        private void M_First_Load(object sender, EventArgs e)
        {
            string sql =  $"SELECT distinct CONVERT(CHAR(7), date, 120) from Profits";
            RunSql(sql);
            for(int i = 0; i < dataGrid.Rows.Count-1; i++)
            {
                cb_monthlyP.Items.Add(dataGrid[0, i].Value.ToString());
            }
            ClearGrid();
        }

        private void cb_monthlyP_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearGrid();
            string Mdate = cb_monthlyP.SelectedItem.ToString();
            string sql = $"SELECT * from Profits where date like N'{Mdate}%'";
            RunSql(sql);
        }

        private void tbMember_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                ClearGrid();
                string sql = $"SELECT phone, point from memberinfo where phone=N'{tbMember.Text}'";
                RunSql(sql);
            }
        }

        private void M_Membership_Click(object sender, EventArgs e)
        {
            lb_monthlyP.Visible = false;
            cb_monthlyP.Visible = false;
            lbMember.Visible = true;
            tbMember.Visible = true;
            ClearGrid();
            string sql = $"SELECT phone, point from memberinfo";
            RunSql(sql);
        }
    }
}
