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
    public partial class M_RegistP : Form
    {
        public string mName = "";
        public int mPrice = 0;
        public string mClass = "";
        public int mDelay = 0;

        public M_RegistP()
        {
            InitializeComponent();
        }

        string db = Program.db; 
        private void btnimg_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;
            pb.Image = Bitmap.FromFile(openFileDialog.FileName);
            pb.Tag = openFileDialog.FileName;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (pb.Image != null && tbName.Text != "" && tbPrice.Text != "" && cbClass.Text != "" && tbDelay.Text != "")
            {
                mName = tbName.Text;
                mPrice = Int32.Parse(tbPrice.Text);
                mClass = cbClass.SelectedItem.ToString();
                mDelay = Int32.Parse(tbDelay.Text);

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = db;
                conn.Open();

                FileStream fs = new FileStream(pb.Tag.ToString(), FileMode.Open, FileAccess.Read);
                byte[] bImage = new byte[fs.Length];
                fs.Read(bImage, 0, (int)fs.Length);

                string strSQL = "INSERT INTO MENU VALUES (@mName, @mPrice, @mClass, @ImgName, @mDelay)";
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                cmd.Parameters.AddWithValue("@mName", mName);
                cmd.Parameters.AddWithValue("@mPrice", mPrice);
                cmd.Parameters.AddWithValue("@mClass", mClass);
                cmd.Parameters.AddWithValue("@ImgName", bImage);
                cmd.Parameters.AddWithValue("@mDelay", mDelay);
                cmd.ExecuteNonQuery();
                fs.Close();

                MessageBox.Show("제품 등록 완료", "제품 등록");
                Close();
            }
            else
            {
                MessageBox.Show("제품 등록 실패", "제품 등록");
            }
        }

        private void tbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }
    }
}
