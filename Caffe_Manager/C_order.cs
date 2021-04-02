using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caffe_Manager
{
    public partial class C_order : Form
    {
        PictureBox[] ApictureBoxes = new PictureBox[12];
        PictureBox[] BpictureBoxes = new PictureBox[12];
        PictureBox[] CpictureBoxes = new PictureBox[12];
        PictureBox[] DpictureBoxes = new PictureBox[12];
        PictureBox[] EpictureBoxes = new PictureBox[12];
        PictureBox[] FpictureBoxes = new PictureBox[12];
        Label[] Alabels = new Label[12];
        Label[] Blabels = new Label[12];
        Label[] Clabels = new Label[12];
        Label[] Dlabels = new Label[12];
        Label[] Elabels = new Label[12];
        Label[] Flabels = new Label[12];

        int totalcnt = 0;
        int totalprice = 0;
        string tabName = "커피";

        public C_order()
        {
            InitializeComponent();

            ApictureBoxes[0] = ApictureBox1;
            ApictureBoxes[1] = ApictureBox2;
            ApictureBoxes[2] = ApictureBox3;
            ApictureBoxes[3] = ApictureBox4;
            ApictureBoxes[4] = ApictureBox5;
            ApictureBoxes[5] = ApictureBox6;
            ApictureBoxes[6] = ApictureBox7;
            ApictureBoxes[7] = ApictureBox8;
            ApictureBoxes[8] = ApictureBox9;
            ApictureBoxes[9] = ApictureBox10;
            ApictureBoxes[10] = ApictureBox11;
            ApictureBoxes[11] = ApictureBox12;

            BpictureBoxes[0] = BpictureBox1;
            BpictureBoxes[1] = BpictureBox2;
            BpictureBoxes[2] = BpictureBox3;
            BpictureBoxes[3] = BpictureBox4;
            BpictureBoxes[4] = BpictureBox5;
            BpictureBoxes[5] = BpictureBox6;
            BpictureBoxes[6] = BpictureBox7;
            BpictureBoxes[7] = BpictureBox8;
            BpictureBoxes[8] = BpictureBox9;
            BpictureBoxes[9] = BpictureBox10;
            BpictureBoxes[10] = BpictureBox11;
            BpictureBoxes[11] = BpictureBox12;

            CpictureBoxes[0] = CpictureBox1;
            CpictureBoxes[1] = CpictureBox2;
            CpictureBoxes[2] = CpictureBox3;
            CpictureBoxes[3] = CpictureBox4;
            CpictureBoxes[4] = CpictureBox5;
            CpictureBoxes[5] = CpictureBox6;
            CpictureBoxes[6] = CpictureBox7;
            CpictureBoxes[7] = CpictureBox8;
            CpictureBoxes[8] = CpictureBox9;
            CpictureBoxes[9] = CpictureBox10;
            CpictureBoxes[10] = CpictureBox11;
            CpictureBoxes[11] = CpictureBox12;

            DpictureBoxes[0] = DpictureBox1;
            DpictureBoxes[1] = DpictureBox2;
            DpictureBoxes[2] = DpictureBox3;
            DpictureBoxes[3] = DpictureBox4;
            DpictureBoxes[4] = DpictureBox5;
            DpictureBoxes[5] = DpictureBox6;
            DpictureBoxes[6] = DpictureBox7;
            DpictureBoxes[7] = DpictureBox8;
            DpictureBoxes[8] = DpictureBox9;
            DpictureBoxes[9] = DpictureBox10;
            DpictureBoxes[10] = DpictureBox11;
            DpictureBoxes[11] = DpictureBox12;

            EpictureBoxes[0] = EpictureBox1;
            EpictureBoxes[1] = EpictureBox2;
            EpictureBoxes[2] = EpictureBox3;
            EpictureBoxes[3] = EpictureBox4;
            EpictureBoxes[4] = EpictureBox5;
            EpictureBoxes[5] = EpictureBox6;
            EpictureBoxes[6] = EpictureBox7;
            EpictureBoxes[7] = EpictureBox8;
            EpictureBoxes[8] = EpictureBox9;
            EpictureBoxes[9] = EpictureBox10;
            EpictureBoxes[10] = EpictureBox11;
            EpictureBoxes[11] = EpictureBox12;

            FpictureBoxes[0] = FpictureBox1;
            FpictureBoxes[1] = FpictureBox2;
            FpictureBoxes[2] = FpictureBox3;
            FpictureBoxes[3] = FpictureBox4;
            FpictureBoxes[4] = FpictureBox5;
            FpictureBoxes[5] = FpictureBox6;
            FpictureBoxes[6] = FpictureBox7;
            FpictureBoxes[7] = FpictureBox8;
            FpictureBoxes[8] = FpictureBox9;
            FpictureBoxes[9] = FpictureBox10;
            FpictureBoxes[10] = FpictureBox11;
            FpictureBoxes[11] = FpictureBox12;

            Alabels[0] = Alabel1;
            Alabels[1] = Alabel2;
            Alabels[2] = Alabel3;
            Alabels[3] = Alabel4;
            Alabels[4] = Alabel5;
            Alabels[5] = Alabel6;
            Alabels[6] = Alabel7;
            Alabels[7] = Alabel8;
            Alabels[8] = Alabel9;
            Alabels[9] = Alabel10;
            Alabels[10] = Alabel11;
            Alabels[11] = Alabel12;

            Blabels[0] = Blabel1;
            Blabels[1] = Blabel2;
            Blabels[2] = Blabel3;
            Blabels[3] = Blabel4;
            Blabels[4] = Blabel5;
            Blabels[5] = Blabel6;
            Blabels[6] = Blabel7;
            Blabels[7] = Blabel8;
            Blabels[8] = Blabel9;
            Blabels[9] = Blabel10;
            Blabels[10] = Blabel11;
            Blabels[11] = Blabel12;

            Clabels[0] = Clabel1;
            Clabels[1] = Clabel2;
            Clabels[2] = Clabel3;
            Clabels[3] = Clabel4;
            Clabels[4] = Clabel5;
            Clabels[5] = Clabel6;
            Clabels[6] = Clabel7;
            Clabels[7] = Clabel8;
            Clabels[8] = Clabel9;
            Clabels[9] = Clabel10;
            Clabels[10] = Clabel11;
            Clabels[11] = Clabel12;

            Dlabels[0] = Dlabel1;
            Dlabels[1] = Dlabel2;
            Dlabels[2] = Dlabel3;
            Dlabels[3] = Dlabel4;
            Dlabels[4] = Dlabel5;
            Dlabels[5] = Dlabel6;
            Dlabels[6] = Dlabel7;
            Dlabels[7] = Dlabel8;
            Dlabels[8] = Dlabel9;
            Dlabels[9] = Dlabel10;
            Dlabels[10] = Dlabel11;
            Dlabels[11] = Dlabel12;

            Elabels[0] = Elabel1;
            Elabels[1] = Elabel2;
            Elabels[2] = Elabel3;
            Elabels[3] = Elabel4;
            Elabels[4] = Elabel5;
            Elabels[5] = Elabel6;
            Elabels[6] = Elabel7;
            Elabels[7] = Elabel8;
            Elabels[8] = Elabel9;
            Elabels[9] = Elabel10;
            Elabels[10] = Elabel11;
            Elabels[11] = Elabel12;

            Flabels[0] = Flabel1;
            Flabels[1] = Flabel2;
            Flabels[2] = Flabel3;
            Flabels[3] = Flabel4;
            Flabels[4] = Flabel5;
            Flabels[5] = Flabel6;
            Flabels[6] = Flabel7;
            Flabels[7] = Flabel8;
            Flabels[8] = Flabel9;
            Flabels[9] = Flabel10;
            Flabels[10] = Flabel11;
            Flabels[11] = Flabel12;

            SqlConnection conn = new SqlConnection(db);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM MENU WHERE MCLASS = 'COFFEE'", conn);
            SqlDataReader sr = cmd.ExecuteReader();

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

            for (int i = 0; i < dataGrid.Rows.Count - 1; i++)
            {
                Alabels[i].Visible = true;
                Alabels[i].Text = dataGrid[1, i].Value.ToString();
                ApictureBoxes[i].Visible = true;
                ApictureBoxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                ApictureBoxes[i].Tag = Alabels[i].Text;

                var data = (Byte[])dataGrid[4, i].Value;
                var stream = new MemoryStream(data);
                ApictureBoxes[i].Image = Image.FromStream(stream);
            }
            conn.Close();

        }

        string db = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\anvo9\KOSTA_Project\Caffe_Manager\Caffe_Manager.mdf;Integrated Security = True; Connect Timeout = 30";
        
        private void btn_Payment_Click(object sender, EventArgs e)
        {
            if(totalcnt > 0 && totalprice > 0)
            {
                int len = sender.ToString().Split(' ').Length;
                string method = sender.ToString().Split(' ')[len - 1];

                C_orderlist col = new C_orderlist(method, totalcnt, totalprice, list_order);

                if (col.ShowDialog() == DialogResult.Cancel)
                {
                    C_finish cf = new C_finish("주문이 취소되었습니다.");
                    cf.ShowDialog();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            C_finish cf = new C_finish("주문이 취소되었습니다.");
            if (cf.ShowDialog() != DialogResult.Cancel) return;
        }

        private void C_order_Load(object sender, EventArgs e)
        {
            list_order.View = View.Details;
        }

        private void tc_Selected(object sender, TabControlEventArgs e)
        {

            SqlConnection conn = new SqlConnection(db);
            conn.Open();
            tabName = tc.SelectedTab.Text.Trim();
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();

            switch (tabName)
            {
                case "커피":
                    SqlCommand Ccmd = new SqlCommand("SELECT * FROM MENU WHERE MCLASS = 'COFFEE'", conn);
                    SqlDataReader Csr = Ccmd.ExecuteReader();
                    for (int i = 0; i < Csr.FieldCount; i++)
                    {
                        dataGrid.Columns.Add(Csr.GetName(i), Csr.GetName(i));
                    }
                    for (int k = 0; Csr.Read(); k++)
                    {
                        object[] oArr = new object[Csr.FieldCount];
                        Csr.GetValues(oArr);
                        dataGrid.Rows.Add(oArr);
                    }
                    Csr.Close();

                    for (int i = 0; i < dataGrid.Rows.Count-1; i++)
                    {
                        Alabels[i].Visible = true;
                        Alabels[i].Text = dataGrid[1, i].Value.ToString();
                        ApictureBoxes[i].Visible = true;
                        ApictureBoxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                        ApictureBoxes[i].Tag = Alabels[i].Text;

                        var data = (Byte[])dataGrid[4,i].Value;
                        var stream = new MemoryStream(data);
                        ApictureBoxes[i].Image = Image.FromStream(stream);
                    }
                    conn.Close();
                    break;

                case "기타 음료":
                    SqlCommand NCcmd = new SqlCommand("SELECT * FROM MENU WHERE MCLASS = 'NONCOFFEE'", conn);
                    SqlDataReader NCsr = NCcmd.ExecuteReader();
                    for (int i = 0; i < NCsr.FieldCount; i++)
                    {
                        dataGrid.Columns.Add(NCsr.GetName(i), NCsr.GetName(i));
                    }
                    for (int k = 0; NCsr.Read(); k++)
                    {
                        object[] oArr = new object[NCsr.FieldCount];
                        NCsr.GetValues(oArr);
                        dataGrid.Rows.Add(oArr);
                    }
                    NCsr.Close();

                    for (int i = 0; i < dataGrid.Rows.Count - 1; i++)
                    {
                        Blabels[i].Visible = true;
                        Blabels[i].Text = dataGrid[1, i].Value.ToString();
                        BpictureBoxes[i].Visible = true;
                        BpictureBoxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                        BpictureBoxes[i].Tag = Blabels[i].Text;

                        var data = (Byte[])dataGrid[4, i].Value;
                        var stream = new MemoryStream(data);
                        BpictureBoxes[i].Image = Image.FromStream(stream);
                    }
                    conn.Close();
                    break;

                case "병음료":
                    SqlCommand Bcmd = new SqlCommand("SELECT * FROM MENU WHERE MCLASS = 'BOTTLE'", conn);
                    SqlDataReader Bsr = Bcmd.ExecuteReader();
                    for (int i = 0; i < Bsr.FieldCount; i++)
                    {
                        dataGrid.Columns.Add(Bsr.GetName(i), Bsr.GetName(i));
                    }
                    for (int k = 0; Bsr.Read(); k++)
                    {
                        object[] oArr = new object[Bsr.FieldCount];
                        Bsr.GetValues(oArr);
                        dataGrid.Rows.Add(oArr);
                    }
                    Bsr.Close();

                    for (int i = 0; i < dataGrid.Rows.Count - 1; i++)
                    {
                        Clabels[i].Visible = true;
                        Clabels[i].Text = dataGrid[1, i].Value.ToString();
                        CpictureBoxes[i].Visible = true;
                        CpictureBoxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                        CpictureBoxes[i].Tag = Clabels[i].Text;

                        var data = (Byte[])dataGrid[4, i].Value;
                        var stream = new MemoryStream(data);
                        CpictureBoxes[i].Image = Image.FromStream(stream);
                    }
                    conn.Close();
                    break;

                case "디저트":
                    SqlCommand Dcmd = new SqlCommand("SELECT * FROM MENU WHERE MCLASS = 'DESSERT'", conn);
                    SqlDataReader Dsr = Dcmd.ExecuteReader();
                    for (int i = 0; i < Dsr.FieldCount; i++)
                    {
                        dataGrid.Columns.Add(Dsr.GetName(i), Dsr.GetName(i));
                    }
                    for (int k = 0; Dsr.Read(); k++)
                    {
                        object[] oArr = new object[Dsr.FieldCount];
                        Dsr.GetValues(oArr);
                        dataGrid.Rows.Add(oArr);
                    }
                    Dsr.Close();

                    for (int i = 0; i < dataGrid.Rows.Count - 1; i++)
                    {
                        Dlabels[i].Visible = true;
                        Dlabels[i].Text = dataGrid[1, i].Value.ToString();
                        DpictureBoxes[i].Visible = true;
                        DpictureBoxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                        DpictureBoxes[i].Tag = Dlabels[i].Text;

                        var data = (Byte[])dataGrid[4, i].Value;
                        var stream = new MemoryStream(data);
                        DpictureBoxes[i].Image = Image.FromStream(stream);
                    }
                    conn.Close();
                    break;

                case "원두":
                    SqlCommand CBcmd = new SqlCommand("SELECT * FROM MENU WHERE MCLASS = 'COFFEEBEAN'", conn);
                    SqlDataReader CBsr = CBcmd.ExecuteReader();
                    for (int i = 0; i < CBsr.FieldCount; i++)
                    {
                        dataGrid.Columns.Add(CBsr.GetName(i), CBsr.GetName(i));
                    }
                    for (int k = 0; CBsr.Read(); k++)
                    {
                        object[] oArr = new object[CBsr.FieldCount];
                        CBsr.GetValues(oArr);
                        dataGrid.Rows.Add(oArr);
                    }
                    CBsr.Close();

                    for (int i = 0; i < dataGrid.Rows.Count - 1; i++)
                    {
                        Elabels[i].Visible = true;
                        Elabels[i].Text = dataGrid[1, i].Value.ToString();
                        EpictureBoxes[i].Visible = true;
                        EpictureBoxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                        EpictureBoxes[i].Tag = Elabels[i].Text;

                        var data = (Byte[])dataGrid[4, i].Value;
                        var stream = new MemoryStream(data);
                        EpictureBoxes[i].Image = Image.FromStream(stream);
                    }
                    conn.Close();
                    break;

                case "MD":
                    SqlCommand Mcmd = new SqlCommand("SELECT * FROM MENU WHERE MCLASS = 'MD'", conn);
                    SqlDataReader Msr = Mcmd.ExecuteReader();
                    for (int i = 0; i < Msr.FieldCount; i++)
                    {
                        dataGrid.Columns.Add(Msr.GetName(i), Msr.GetName(i));
                    }
                    for (int k = 0; Msr.Read(); k++)
                    {
                        object[] oArr = new object[Msr.FieldCount];
                        Msr.GetValues(oArr);
                        dataGrid.Rows.Add(oArr);
                    }
                    Msr.Close();

                    for (int i = 0; i < dataGrid.Rows.Count - 1; i++)
                    {
                        Flabels[i].Visible = true;
                        Flabels[i].Text = dataGrid[1, i].Value.ToString();
                        FpictureBoxes[i].Visible = true;
                        FpictureBoxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                        FpictureBoxes[i].Tag = Flabels[i].Text;

                        var data = (Byte[])dataGrid[4, i].Value;
                        var stream = new MemoryStream(data);
                        FpictureBoxes[i].Image = Image.FromStream(stream);
                    }
                    conn.Close();
                    break;
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            string item = ((Control)sender).Tag.ToString();


            int price = 0;

            for (int i = 0; i < dataGrid.Rows.Count - 1; i++)
            {
                if (dataGrid[1, i].Value.ToString() == item)
                {
                    price = Int32.Parse(dataGrid[2, i].Value.ToString());
                }
            }

            C_menu_detail md = new C_menu_detail(item, tabName, price);
            if (md.ShowDialog() == DialogResult.Cancel) return;

            string size = md.size;
            string is_hot = md.is_hot;
            int cnt = md.cnt;
            price = md.result_price;

            ListViewItem newitem = new ListViewItem(new string[] {$"{item}{is_hot}", size, cnt.ToString(), price.ToString()});
            list_order.Items.Add(newitem);

            int cntnum = Int32.Parse(lbCntNum.Text);
            int pricenum = Int32.Parse(lbPriceNum.Text);
            cntnum += cnt;
            pricenum += price;
            lbCntNum.Text = cntnum.ToString();
            lbPriceNum.Text = pricenum.ToString();
            totalcnt = cntnum;
            totalprice = pricenum;
        }

        private void btnSCancel_Click(object sender, EventArgs e)
        {
            int cntnum = Int32.Parse(lbCntNum.Text);
            int pricenum = Int32.Parse(lbPriceNum.Text);
            if(list_order.FocusedItem != null)
            {
                cntnum -= Int32.Parse(list_order.FocusedItem.SubItems[2].ToString().Split('{')[1].Trim('}'));
                pricenum -= Int32.Parse(list_order.FocusedItem.SubItems[3].ToString().Split('{')[1].Trim('}'));
                lbCntNum.Text = cntnum.ToString();
                lbPriceNum.Text = pricenum.ToString();
                totalcnt = cntnum;
                totalprice = pricenum;

                list_order.Items.Remove(list_order.FocusedItem);
            }
        }
    }
}
