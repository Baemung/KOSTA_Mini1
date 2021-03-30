
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.shotCount = new System.Windows.Forms.DomainUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbSizeLarge = new System.Windows.Forms.RadioButton();
            this.rbSizeMedium = new System.Windows.Forms.RadioButton();
            this.rbSizeSmall = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.rbIce.Location = new System.Drawing.Point(121, 32);
            this.rbIce.Name = "rbIce";
            this.rbIce.Size = new System.Drawing.Size(173, 25);
            this.rbIce.TabIndex = 0;
            this.rbIce.TabStop = true;
            this.rbIce.Text = "아이스 (500원 추가)";
            this.rbIce.UseVisualStyleBackColor = true;
            // 
            // rbHot
            // 
            this.rbHot.AutoSize = true;
            this.rbHot.Checked = true;
            this.rbHot.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbHot.Location = new System.Drawing.Point(29, 32);
            this.rbHot.Name = "rbHot";
            this.rbHot.Size = new System.Drawing.Size(44, 25);
            this.rbHot.TabIndex = 0;
            this.rbHot.TabStop = true;
            this.rbHot.Text = "핫";
            this.rbHot.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.shotCount);
            this.groupBox2.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.groupBox2.Location = new System.Drawing.Point(29, 284);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 98);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "샷 추가";
            // 
            // shotCount
            // 
            this.shotCount.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.shotCount.Items.Add("3");
            this.shotCount.Items.Add("2");
            this.shotCount.Items.Add("1");
            this.shotCount.Items.Add("0");
            this.shotCount.Location = new System.Drawing.Point(78, 38);
            this.shotCount.Name = "shotCount";
            this.shotCount.Size = new System.Drawing.Size(172, 33);
            this.shotCount.TabIndex = 0;
            this.shotCount.Text = "0";
            this.shotCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbSizeLarge);
            this.groupBox3.Controls.Add(this.rbSizeMedium);
            this.groupBox3.Controls.Add(this.rbSizeSmall);
            this.groupBox3.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.groupBox3.Location = new System.Drawing.Point(29, 152);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(328, 96);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "사이즈";
            // 
            // rbSizeLarge
            // 
            this.rbSizeLarge.AutoSize = true;
            this.rbSizeLarge.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbSizeLarge.Location = new System.Drawing.Point(229, 40);
            this.rbSizeLarge.Name = "rbSizeLarge";
            this.rbSizeLarge.Size = new System.Drawing.Size(69, 25);
            this.rbSizeLarge.TabIndex = 0;
            this.rbSizeLarge.TabStop = true;
            this.rbSizeLarge.Text = "Large";
            this.rbSizeLarge.UseVisualStyleBackColor = true;
            // 
            // rbSizeMedium
            // 
            this.rbSizeMedium.AutoSize = true;
            this.rbSizeMedium.Checked = true;
            this.rbSizeMedium.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbSizeMedium.Location = new System.Drawing.Point(123, 40);
            this.rbSizeMedium.Name = "rbSizeMedium";
            this.rbSizeMedium.Size = new System.Drawing.Size(89, 25);
            this.rbSizeMedium.TabIndex = 0;
            this.rbSizeMedium.TabStop = true;
            this.rbSizeMedium.Text = "Medium";
            this.rbSizeMedium.UseVisualStyleBackColor = true;
            // 
            // rbSizeSmall
            // 
            this.rbSizeSmall.AutoSize = true;
            this.rbSizeSmall.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbSizeSmall.Location = new System.Drawing.Point(31, 40);
            this.rbSizeSmall.Name = "rbSizeSmall";
            this.rbSizeSmall.Size = new System.Drawing.Size(67, 25);
            this.rbSizeSmall.TabIndex = 0;
            this.rbSizeSmall.TabStop = true;
            this.rbSizeSmall.Text = "Small";
            this.rbSizeSmall.UseVisualStyleBackColor = true;
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
            // 
            // C_menu_detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 487);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "C_menu_detail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "옵션 선택";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DomainUpDown shotCount;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbIce;
        private System.Windows.Forms.RadioButton rbHot;
        private System.Windows.Forms.RadioButton rbSizeLarge;
        private System.Windows.Forms.RadioButton rbSizeMedium;
        private System.Windows.Forms.RadioButton rbSizeSmall;
        private System.Windows.Forms.Button btnOK;
    }
}