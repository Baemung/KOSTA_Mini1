namespace Caffe_Manager
{
    partial class C_pay_sign
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CanvasDraw = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CanvasDraw)).BeginInit();
            this.SuspendLayout();
            // 
            // CanvasDraw
            // 
            this.CanvasDraw.Location = new System.Drawing.Point(2, 0);
            this.CanvasDraw.Margin = new System.Windows.Forms.Padding(2);
            this.CanvasDraw.Name = "CanvasDraw";
            this.CanvasDraw.Size = new System.Drawing.Size(557, 243);
            this.CanvasDraw.TabIndex = 0;
            this.CanvasDraw.TabStop = false;
            this.CanvasDraw.Click += new System.EventHandler(this.CanvasDraw_Click);
            this.CanvasDraw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CanvasDraw_MouseDown);
            this.CanvasDraw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CanvasDraw_MouseMove);
            this.CanvasDraw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CanvasDraw_MouseUp);
            this.CanvasDraw.Resize += new System.EventHandler(this.CanvasDraw_Resize);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("굴림", 12F);
            this.btnOK.Location = new System.Drawing.Point(193, 255);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(167, 31);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "확인";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // C_pay_sign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(560, 300);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.CanvasDraw);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "C_pay_sign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "사인하기";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.CanvasDraw)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox CanvasDraw;
        private System.Windows.Forms.Button btnOK;
    }
}