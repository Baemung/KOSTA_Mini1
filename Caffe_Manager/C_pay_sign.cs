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
    public partial class C_pay_sign : Form
    {
        Graphics GDC;
        
        bool MStatus = false;  // false: 그리기 상태 아님, true: 그리기 상태
        int DrawMode = 0;     // -1:none / 0:pen / 1:circle / 2:Arc / 3:Line
        Point p1;
        Color Col = Color.Black;

        int cirX = 10;
        int cirY = 10;
        int Thickness = 5;

        public C_pay_sign()
        {
            InitializeComponent();
            GDC = CanvasDraw.CreateGraphics();
        }

        private void CanvasDraw_Click(object sender, EventArgs e)
        {
  
        }

        private void CanvasDraw_MouseDown(object sender, MouseEventArgs e)
        {
            if (DrawMode == 0)
            {
                p1 = new Point(e.X, e.Y);
                MStatus = true; //판별변수로 사용
            }
            else if (DrawMode == 1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Pen pp = new Pen(Col, Thickness);
                    GDC.DrawEllipse(pp, e.X - cirX / 2, e.Y - cirY / 2, cirX, cirY);
                }
            }
        }

        private void CanvasDraw_MouseMove(object sender, MouseEventArgs e)
        {

            if (DrawMode == 0)
            {
                if (MStatus)
                {
                    Pen pp = new Pen(Col, Thickness);
                    Point p2 = new Point(e.X, e.Y);
                    GDC.DrawLine(pp, p1, p2);
                    p1 = p2;
                }
            }
        }

        private void CanvasDraw_MouseUp(object sender, MouseEventArgs e)
        {
            if (DrawMode == 0)
            {
                MStatus = false;
            }
        }

        private void CanvasDraw_Resize(object sender, EventArgs e)
        {
            GDC = CanvasDraw.CreateGraphics();
        }
    }
}
