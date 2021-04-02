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
    public partial class C_menu_detail : Form
    {
        public string size = "";
        public string is_hot = "";
        public int cnt = 1;
        public int Origin_price = 0;
        public int Hot_price = 0;
        public int Size_price = 0;
        public int result_price = 0;
        public string menu;
        public string category;

        public C_menu_detail(string name, string tabname, int price)
        {
            InitializeComponent();
            cntupdown.Minimum = 1;
            menu = name;
            category = tabname.Trim();
            Origin_price = price;
        }

        private void C_menu_detail_Load(object sender, EventArgs e)
        {
            lbPrice.Text = Origin_price.ToString();
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;

            if (category == "커피")
            {
                if(menu == "Espresso")
                {
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = false;
                }
            }
            else if (category == "기타 음료")
            {
                if(menu == "GREEN TEA FRAPPUCCINO")
                {
                    groupBox1.Enabled = false;
                }
                else if(menu == "YOGURT SMOOTHIE")
                {
                    groupBox1.Enabled = false;
                }
                else if (menu == "STRAWBERRY YOGURT SMOOTHIE")
                {
                    groupBox1.Enabled = false;
                }
                else if (menu == "LEMON ADE")
                {
                    groupBox1.Enabled = false;
                }
                else if (menu == "GRAPEFRUIT ADE")
                {
                    groupBox1.Enabled = false;
                }
                else if (menu == "MILK TEA")
                {
                    groupBox1.Enabled = false;
                }
                else if (menu == "YOGURT SMOOTHIE")
                {
                    groupBox1.Enabled = false;
                }
            }
            else 
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
            }
        }

        private void C_menu_detail_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void rbHot_CheckedChanged(object sender, EventArgs e)
        {
            is_hot = "(HOT)";
            Hot_price = 0;
            lbPrice.Text = ((Origin_price + Hot_price + Size_price) * cnt).ToString();
        }
        private void rbIce_CheckedChanged(object sender, EventArgs e)
        {
            is_hot = "(ICE)";
            Hot_price = 500;
            lbPrice.Text = ((Origin_price + Hot_price + Size_price) * cnt).ToString();
        }

        private void rbSizeSmall_CheckedChanged(object sender, EventArgs e)
        {
            size = "Small";
            Size_price = 0;
            lbPrice.Text = ((Origin_price + Hot_price + Size_price) * cnt).ToString();
        }

        private void rbSizeMedium_CheckedChanged(object sender, EventArgs e)
        {
            size = "Medium";
            Size_price = 500;
            lbPrice.Text = ((Origin_price + Hot_price + Size_price) * cnt).ToString();
        }

        private void rbSizeLarge_CheckedChanged(object sender, EventArgs e)
        {
            size = "Large";
            Size_price = 1000;
            lbPrice.Text = ((Origin_price + Hot_price + Size_price) * cnt).ToString();
        }

        private void cntupdown_ValueChanged(object sender, EventArgs e)
        {
            cnt = Int32.Parse(cntupdown.Value.ToString());
            lbPrice.Text = ((Origin_price + Hot_price + Size_price) * cnt).ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            result_price = Int32.Parse(lbPrice.Text);
        }
    }
}
