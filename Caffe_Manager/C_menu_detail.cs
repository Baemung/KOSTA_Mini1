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
        public int price = 0;
        public string menu;
        public string category;

        public C_menu_detail(string name, string tabname)
        {
            InitializeComponent();
            cntupdown.Minimum = 1;
            menu = name;
            category = tabname.Trim();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!groupBox1.Enabled && !groupBox2.Enabled)
            {
                cnt = Int32.Parse(cntupdown.Value.ToString());
            }
            else if (rbHot.Checked)
            {
                is_hot = "Hot";
                cnt = Int32.Parse(cntupdown.Value.ToString());
                if (rbSizeSmall.Checked)
                {
                    size = "Small";
                }
                else if (rbSizeMedium.Checked)
                {
                    size = "Medium";
                    price += 500;
                }
                else if (rbSizeLarge.Checked)
                {
                    size = "Large";
                    price += 500;
                }
                else
                {
                    MessageBox.Show("기본옵션으로 선택됩니다. ", "옵션 선택");
                }
            }
            else if (rbIce.Checked)
            {

                is_hot = "Ice";
                price += 500;
                cnt = Int32.Parse(cntupdown.Value.ToString());
                if (rbSizeSmall.Checked)
                {
                    size = "Small";
                }
                else if (rbSizeMedium.Checked)
                {
                    size = "Medium";
                    price += 500;
                }
                else if (rbSizeLarge.Checked)
                {
                    size = "Large";
                    price += 500;
                }
                else
                {
                    MessageBox.Show("기본옵션으로 선택됩니다. ", "옵션 선택");
                }
            }
            else
            {
                if (groupBox1.Enabled)
                {
                    MessageBox.Show("기본옵션으로 선택됩니다. ", "옵션 선택");
                }
                else
                {
                    cnt = Int32.Parse(cntupdown.Value.ToString());
                    if (rbSizeSmall.Checked)
                    {
                        size = "Small";
                    }
                    else if (rbSizeMedium.Checked)
                    {
                        size = "Medium";
                        price += 500;
                    }
                    else if (rbSizeLarge.Checked)
                    {
                        size = "Large";
                        price += 500;
                    }
                    else
                    {
                        MessageBox.Show("기본옵션으로 선택됩니다. ", "옵션 선택");
                    }
                }

            }
        }

        private void C_menu_detail_Load(object sender, EventArgs e)
        {
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
    }
}
