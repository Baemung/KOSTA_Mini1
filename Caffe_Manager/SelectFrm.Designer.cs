
namespace Caffe_Manager
{
    partial class SelectFrm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnC = new System.Windows.Forms.Button();
            this.btnM = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnC
            // 
            this.btnC.Font = new System.Drawing.Font("Consolas", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnC.Location = new System.Drawing.Point(39, 89);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(330, 264);
            this.btnC.TabIndex = 0;
            this.btnC.Text = "Customer";
            this.btnC.UseVisualStyleBackColor = true;
            this.btnC.Click += new System.EventHandler(this.btnC_Click);
            // 
            // btnM
            // 
            this.btnM.Font = new System.Drawing.Font("Consolas", 36F);
            this.btnM.Location = new System.Drawing.Point(425, 89);
            this.btnM.Name = "btnM";
            this.btnM.Size = new System.Drawing.Size(330, 264);
            this.btnM.TabIndex = 0;
            this.btnM.Text = "Manager";
            this.btnM.UseVisualStyleBackColor = true;
            this.btnM.Click += new System.EventHandler(this.btnM_Click);
            // 
            // SelectFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnM);
            this.Controls.Add(this.btnC);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Mode";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnC;
        private System.Windows.Forms.Button btnM;
    }
}

