namespace Caffe_Manager
{
    partial class M_InvenAdd
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
            this.components = new System.ComponentModel.Container();
            this.tbItem = new System.Windows.Forms.TextBox();
            this.tbCnt = new System.Windows.Forms.TextBox();
            this.lb_client = new System.Windows.Forms.Label();
            this.lb_item = new System.Windows.Forms.Label();
            this.lb_cnt = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.mInvenAddBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbClient = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.mInvenAddBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tbItem
            // 
            this.tbItem.Location = new System.Drawing.Point(99, 67);
            this.tbItem.Margin = new System.Windows.Forms.Padding(2);
            this.tbItem.Name = "tbItem";
            this.tbItem.Size = new System.Drawing.Size(148, 21);
            this.tbItem.TabIndex = 1;
            // 
            // tbCnt
            // 
            this.tbCnt.Location = new System.Drawing.Point(99, 111);
            this.tbCnt.Margin = new System.Windows.Forms.Padding(2);
            this.tbCnt.Name = "tbCnt";
            this.tbCnt.Size = new System.Drawing.Size(148, 21);
            this.tbCnt.TabIndex = 3;
            this.tbCnt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCnt_KeyPress);
            // 
            // lb_client
            // 
            this.lb_client.AutoSize = true;
            this.lb_client.Location = new System.Drawing.Point(32, 27);
            this.lb_client.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_client.Name = "lb_client";
            this.lb_client.Size = new System.Drawing.Size(41, 12);
            this.lb_client.TabIndex = 5;
            this.lb_client.Text = "거래처";
            // 
            // lb_item
            // 
            this.lb_item.AutoSize = true;
            this.lb_item.Location = new System.Drawing.Point(34, 71);
            this.lb_item.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_item.Name = "lb_item";
            this.lb_item.Size = new System.Drawing.Size(29, 12);
            this.lb_item.TabIndex = 6;
            this.lb_item.Text = "물품";
            // 
            // lb_cnt
            // 
            this.lb_cnt.AutoSize = true;
            this.lb_cnt.Location = new System.Drawing.Point(34, 115);
            this.lb_cnt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_cnt.Name = "lb_cnt";
            this.lb_cnt.Size = new System.Drawing.Size(29, 12);
            this.lb_cnt.TabIndex = 7;
            this.lb_cnt.Text = "수량";
            // 
            // btn_OK
            // 
            this.btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_OK.Location = new System.Drawing.Point(79, 157);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(114, 34);
            this.btn_OK.TabIndex = 8;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // mInvenAddBindingSource
            // 
            this.mInvenAddBindingSource.DataSource = typeof(Caffe_Manager.M_InvenAdd);
            // 
            // tbClient
            // 
            this.tbClient.Location = new System.Drawing.Point(99, 22);
            this.tbClient.Name = "tbClient";
            this.tbClient.Size = new System.Drawing.Size(148, 21);
            this.tbClient.TabIndex = 9;
            // 
            // M_InvenAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 213);
            this.Controls.Add(this.tbClient);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.lb_cnt);
            this.Controls.Add(this.lb_item);
            this.Controls.Add(this.lb_client);
            this.Controls.Add(this.tbCnt);
            this.Controls.Add(this.tbItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "M_InvenAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "발주하기";
            ((System.ComponentModel.ISupportInitialize)(this.mInvenAddBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbItem;
        private System.Windows.Forms.TextBox tbCnt;
        private System.Windows.Forms.Label lb_client;
        private System.Windows.Forms.Label lb_item;
        private System.Windows.Forms.Label lb_cnt;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.BindingSource mInvenAddBindingSource;
        private System.Windows.Forms.TextBox tbClient;
    }
}