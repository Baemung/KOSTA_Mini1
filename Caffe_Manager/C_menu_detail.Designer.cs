
namespace Caffe_Manager
{
    partial class C_menu_detail
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbIce = new System.Windows.Forms.RadioButton();
            this.rbHot = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cntupdown = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbSizeLarge = new System.Windows.Forms.RadioButton();
            this.rbSizeMedium = new System.Windows.Forms.RadioButton();
            this.rbSizeSmall = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.lbP = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cntupdown)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbIce);
            this.groupBox1.Controls.Add(this.rbHot);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.groupBox1.Location = new System.Drawing.Point(29, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 86);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "핫 / 아이스";
            // 
            // rbIce
            // 
            this.rbIce.AutoSize = true;
            this.rbIce.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.rbIce.Location = new System.Drawing.Point(178, 36);
            this.rbIce.Name = "rbIce";
            this.rbIce.Size = new System.Drawing.Size(104, 25);
            this.rbIce.TabIndex = 0;
            this.rbIce.Text = "ICE (+500)";
            this.rbIce.UseVisualStyleBackColor = true;
            this.rbIce.CheckedChanged += new System.EventHandler(this.rbIce_CheckedChanged);
            // 
            // rbHot
            // 
            this.rbHot.AutoSize = true;
            this.rbHot.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbHot.Location = new System.Drawing.Point(67, 37);
            this.rbHot.Name = "rbHot";
            this.rbHot.Size = new System.Drawing.Size(61, 25);
            this.rbHot.TabIndex = 0;
            this.rbHot.Text = "HOT";
            this.rbHot.UseVisualStyleBackColor = true;
            this.rbHot.CheckedChanged += new System.EventHandler(this.rbHot_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cntupdown);
            this.groupBox3.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.groupBox3.Location = new System.Drawing.Point(29, 242);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(328, 98);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "수량";
            // 
            // cntupdown
            // 
            this.cntupdown.Location = new System.Drawing.Point(55, 40);
            this.cntupdown.Name = "cntupdown";
            this.cntupdown.Size = new System.Drawing.Size(219, 29);
            this.cntupdown.TabIndex = 0;
            this.cntupdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cntupdown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cntupdown.ValueChanged += new System.EventHandler(this.cntupdown_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbSizeLarge);
            this.groupBox2.Controls.Add(this.rbSizeMedium);
            this.groupBox2.Controls.Add(this.rbSizeSmall);
            this.groupBox2.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.groupBox2.Location = new System.Drawing.Point(29, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 96);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "사이즈";
            // 
            // rbSizeLarge
            // 
            this.rbSizeLarge.AutoSize = true;
            this.rbSizeLarge.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbSizeLarge.Location = new System.Drawing.Point(215, 40);
            this.rbSizeLarge.Name = "rbSizeLarge";
            this.rbSizeLarge.Size = new System.Drawing.Size(99, 25);
            this.rbSizeLarge.TabIndex = 0;
            this.rbSizeLarge.Text = "L (+1000)";
            this.rbSizeLarge.UseVisualStyleBackColor = true;
            this.rbSizeLarge.CheckedChanged += new System.EventHandler(this.rbSizeLarge_CheckedChanged);
            // 
            // rbSizeMedium
            // 
            this.rbSizeMedium.AutoSize = true;
            this.rbSizeMedium.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbSizeMedium.Location = new System.Drawing.Point(103, 40);
            this.rbSizeMedium.Name = "rbSizeMedium";
            this.rbSizeMedium.Size = new System.Drawing.Size(97, 25);
            this.rbSizeMedium.TabIndex = 0;
            this.rbSizeMedium.Text = "M (+500)";
            this.rbSizeMedium.UseVisualStyleBackColor = true;
            this.rbSizeMedium.CheckedChanged += new System.EventHandler(this.rbSizeMedium_CheckedChanged);
            // 
            // rbSizeSmall
            // 
            this.rbSizeSmall.AutoSize = true;
            this.rbSizeSmall.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbSizeSmall.Location = new System.Drawing.Point(42, 40);
            this.rbSizeSmall.Name = "rbSizeSmall";
            this.rbSizeSmall.Size = new System.Drawing.Size(37, 25);
            this.rbSizeSmall.TabIndex = 0;
            this.rbSizeSmall.Text = "S";
            this.rbSizeSmall.UseVisualStyleBackColor = true;
            this.rbSizeSmall.CheckedChanged += new System.EventHandler(this.rbSizeSmall_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOK.Location = new System.Drawing.Point(141, 414);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 41);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "확인";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lbP
            // 
            this.lbP.AutoSize = true;
            this.lbP.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbP.Location = new System.Drawing.Point(98, 359);
            this.lbP.Name = "lbP";
            this.lbP.Size = new System.Drawing.Size(67, 30);
            this.lbP.TabIndex = 5;
            this.lbP.Text = "가격 :";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbPrice.Location = new System.Drawing.Point(193, 359);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(25, 30);
            this.lbPrice.TabIndex = 5;
            this.lbPrice.Text = "0";
            // 
            // C_menu_detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 487);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.lbP);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "C_menu_detail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "옵션 선택";
            this.Load += new System.EventHandler(this.C_menu_detail_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cntupdown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbIce;
        private System.Windows.Forms.RadioButton rbHot;
        private System.Windows.Forms.RadioButton rbSizeLarge;
        private System.Windows.Forms.RadioButton rbSizeMedium;
        private System.Windows.Forms.RadioButton rbSizeSmall;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.NumericUpDown cntupdown;
        private System.Windows.Forms.Label lbP;
        private System.Windows.Forms.Label lbPrice;
    }
}