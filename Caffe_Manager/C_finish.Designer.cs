
namespace Caffe_Manager
{
    partial class C_finish
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
            this.lb = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.lbOn = new System.Windows.Forms.Label();
            this.lbD = new System.Windows.Forms.Label();
            this.lbOrdernumber = new System.Windows.Forms.Label();
            this.lbDelay = new System.Windows.Forms.Label();
            this.lbP = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.Font = new System.Drawing.Font("맑은 고딕", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb.Location = new System.Drawing.Point(87, 109);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(359, 45);
            this.lb.TabIndex = 0;
            this.lb.Text = "주문이 완료되었습니다.";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOK.Location = new System.Drawing.Point(202, 231);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(106, 43);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "확인";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // lbOn
            // 
            this.lbOn.AutoSize = true;
            this.lbOn.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbOn.Location = new System.Drawing.Point(167, 45);
            this.lbOn.Name = "lbOn";
            this.lbOn.Size = new System.Drawing.Size(111, 32);
            this.lbOn.TabIndex = 2;
            this.lbOn.Text = "주문번호";
            // 
            // lbD
            // 
            this.lbD.AutoSize = true;
            this.lbD.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbD.Location = new System.Drawing.Point(304, 182);
            this.lbD.Name = "lbD";
            this.lbD.Size = new System.Drawing.Size(74, 21);
            this.lbD.TabIndex = 3;
            this.lbD.Text = "대기시간";
            // 
            // lbOrdernumber
            // 
            this.lbOrdernumber.AutoSize = true;
            this.lbOrdernumber.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbOrdernumber.Location = new System.Drawing.Point(318, 45);
            this.lbOrdernumber.Name = "lbOrdernumber";
            this.lbOrdernumber.Size = new System.Drawing.Size(29, 32);
            this.lbOrdernumber.TabIndex = 4;
            this.lbOrdernumber.Text = "0";
            // 
            // lbDelay
            // 
            this.lbDelay.AutoSize = true;
            this.lbDelay.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbDelay.Location = new System.Drawing.Point(427, 182);
            this.lbDelay.Name = "lbDelay";
            this.lbDelay.Size = new System.Drawing.Size(19, 21);
            this.lbDelay.TabIndex = 4;
            this.lbDelay.Text = "0";
            // 
            // lbP
            // 
            this.lbP.AutoSize = true;
            this.lbP.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbP.Location = new System.Drawing.Point(75, 182);
            this.lbP.Name = "lbP";
            this.lbP.Size = new System.Drawing.Size(80, 21);
            this.lbP.TabIndex = 3;
            this.lbP.Text = "결제 금액";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbPrice.Location = new System.Drawing.Point(198, 182);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(19, 21);
            this.lbPrice.TabIndex = 4;
            this.lbPrice.Text = "0";
            // 
            // C_finish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 314);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.lbDelay);
            this.Controls.Add(this.lbOrdernumber);
            this.Controls.Add(this.lbP);
            this.Controls.Add(this.lbD);
            this.Controls.Add(this.lbOn);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "C_finish";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "cancelFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lbOn;
        private System.Windows.Forms.Label lbD;
        private System.Windows.Forms.Label lbOrdernumber;
        private System.Windows.Forms.Label lbDelay;
        private System.Windows.Forms.Label lbP;
        private System.Windows.Forms.Label lbPrice;
    }
}