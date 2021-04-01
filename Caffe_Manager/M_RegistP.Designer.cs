
namespace Caffe_Manager
{
    partial class M_RegistP
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
            this.btnimg = new System.Windows.Forms.Button();
            this.pb = new System.Windows.Forms.PictureBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.lbPrice = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.tbDelay = new System.Windows.Forms.TextBox();
            this.lbDelay = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.SuspendLayout();
            // 
            // btnimg
            // 
            this.btnimg.Location = new System.Drawing.Point(71, 131);
            this.btnimg.Name = "btnimg";
            this.btnimg.Size = new System.Drawing.Size(126, 31);
            this.btnimg.TabIndex = 0;
            this.btnimg.Text = "메뉴 이미지 선택";
            this.btnimg.UseVisualStyleBackColor = true;
            this.btnimg.Click += new System.EventHandler(this.btnimg_Click);
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(71, 16);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(126, 107);
            this.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb.TabIndex = 1;
            this.pb.TabStop = false;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(77, 175);
            this.tbName.Name = "tbName";
            this.tbName.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbName.Size = new System.Drawing.Size(159, 21);
            this.tbName.TabIndex = 2;
            this.tbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(19, 180);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(41, 12);
            this.lbName.TabIndex = 3;
            this.lbName.Text = "메뉴명";
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(77, 205);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(159, 21);
            this.tbPrice.TabIndex = 2;
            this.tbPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPrice_KeyPress);
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Location = new System.Drawing.Point(24, 210);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(29, 12);
            this.lbPrice.TabIndex = 3;
            this.lbPrice.Text = "가격";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(98, 300);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "등록";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "종류";
            // 
            // cbClass
            // 
            this.cbClass.FormattingEnabled = true;
            this.cbClass.Items.AddRange(new object[] {
            "Coffee",
            "Non_Coffee",
            "Bottle",
            "Dessert",
            "Coffebean",
            "MD"});
            this.cbClass.Location = new System.Drawing.Point(77, 237);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(159, 20);
            this.cbClass.TabIndex = 6;
            // 
            // tbDelay
            // 
            this.tbDelay.Location = new System.Drawing.Point(77, 265);
            this.tbDelay.Name = "tbDelay";
            this.tbDelay.Size = new System.Drawing.Size(159, 21);
            this.tbDelay.TabIndex = 2;
            this.tbDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbDelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPrice_KeyPress);
            // 
            // lbDelay
            // 
            this.lbDelay.AutoSize = true;
            this.lbDelay.Location = new System.Drawing.Point(14, 270);
            this.lbDelay.Name = "lbDelay";
            this.lbDelay.Size = new System.Drawing.Size(53, 12);
            this.lbDelay.TabIndex = 3;
            this.lbDelay.Text = "준비시간";
            // 
            // M_RegistP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 339);
            this.Controls.Add(this.cbClass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbDelay);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.tbDelay);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.btnimg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "M_RegistP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "메뉴 등록";
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnimg;
        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.TextBox tbDelay;
        private System.Windows.Forms.Label lbDelay;
    }
}