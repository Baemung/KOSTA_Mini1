namespace Caffe_Manager
{
    partial class M_First
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.OrderStatus = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.M_Menu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.M_Inven = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.M_orderhistory = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.M_sales = new System.Windows.Forms.ToolStripButton();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.btn_ia = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnServ = new System.Windows.Forms.Button();
            this.cb_monthlyP = new System.Windows.Forms.ComboBox();
            this.lb_monthlyP = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OrderStatus,
            this.toolStripSeparator3,
            this.M_Menu,
            this.toolStripSeparator4,
            this.M_Inven,
            this.toolStripSeparator1,
            this.M_orderhistory,
            this.toolStripSeparator2,
            this.M_sales});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(575, 32);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // OrderStatus
            // 
            this.OrderStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.OrderStatus.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.OrderStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OrderStatus.Name = "OrderStatus";
            this.OrderStatus.Size = new System.Drawing.Size(99, 29);
            this.OrderStatus.Text = "주문 현황";
            this.OrderStatus.Click += new System.EventHandler(this.OrderStatus_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            // 
            // M_Menu
            // 
            this.M_Menu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.M_Menu.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.M_Menu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.M_Menu.Name = "M_Menu";
            this.M_Menu.Size = new System.Drawing.Size(99, 29);
            this.M_Menu.Text = "메뉴 관리";
            this.M_Menu.Click += new System.EventHandler(this.M_Menu_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 32);
            // 
            // M_Inven
            // 
            this.M_Inven.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.M_Inven.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.M_Inven.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.M_Inven.Name = "M_Inven";
            this.M_Inven.Size = new System.Drawing.Size(99, 29);
            this.M_Inven.Text = "재고 현황";
            this.M_Inven.Click += new System.EventHandler(this.M_Inven_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // M_orderhistory
            // 
            this.M_orderhistory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.M_orderhistory.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.M_orderhistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.M_orderhistory.Name = "M_orderhistory";
            this.M_orderhistory.Size = new System.Drawing.Size(99, 29);
            this.M_orderhistory.Text = "발주 내역";
            this.M_orderhistory.Click += new System.EventHandler(this.M_orderhistory_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // M_sales
            // 
            this.M_sales.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.M_sales.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.M_sales.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.M_sales.Name = "M_sales";
            this.M_sales.Size = new System.Drawing.Size(99, 29);
            this.M_sales.Text = "매출 관리";
            this.M_sales.Click += new System.EventHandler(this.M_sales_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(0, 34);
            this.dataGrid.Margin = new System.Windows.Forms.Padding(2);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersWidth = 62;
            this.dataGrid.RowTemplate.Height = 30;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(575, 598);
            this.dataGrid.TabIndex = 1;
            // 
            // btn_ia
            // 
            this.btn_ia.Location = new System.Drawing.Point(101, 644);
            this.btn_ia.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ia.Name = "btn_ia";
            this.btn_ia.Size = new System.Drawing.Size(73, 52);
            this.btn_ia.TabIndex = 3;
            this.btn_ia.Text = "발주하기";
            this.btn_ia.UseVisualStyleBackColor = true;
            this.btn_ia.Click += new System.EventHandler(this.btn_ia_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(16, 644);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(73, 52);
            this.btnRegister.TabIndex = 4;
            this.btnRegister.Text = "메뉴 등록";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnServ
            // 
            this.btnServ.Location = new System.Drawing.Point(184, 644);
            this.btnServ.Name = "btnServ";
            this.btnServ.Size = new System.Drawing.Size(81, 52);
            this.btnServ.TabIndex = 4;
            this.btnServ.Text = "완료";
            this.btnServ.UseVisualStyleBackColor = true;
            this.btnServ.Visible = false;
            this.btnServ.Click += new System.EventHandler(this.btnServ_Click);
            // 
            // cb_monthlyP
            // 
            this.cb_monthlyP.FormattingEnabled = true;
            this.cb_monthlyP.Location = new System.Drawing.Point(423, 674);
            this.cb_monthlyP.Name = "cb_monthlyP";
            this.cb_monthlyP.Size = new System.Drawing.Size(121, 20);
            this.cb_monthlyP.TabIndex = 5;
            this.cb_monthlyP.SelectedIndexChanged += new System.EventHandler(this.cb_monthlyP_SelectedIndexChanged);
            // 
            // lb_monthlyP
            // 
            this.lb_monthlyP.AutoSize = true;
            this.lb_monthlyP.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_monthlyP.Location = new System.Drawing.Point(445, 646);
            this.lb_monthlyP.Name = "lb_monthlyP";
            this.lb_monthlyP.Size = new System.Drawing.Size(80, 21);
            this.lb_monthlyP.TabIndex = 6;
            this.lb_monthlyP.Text = "월별 매출";
            // 
            // M_First
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 707);
            this.ControlBox = false;
            this.Controls.Add(this.lb_monthlyP);
            this.Controls.Add(this.cb_monthlyP);
            this.Controls.Add(this.btnServ);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btn_ia);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "M_First";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "M_First";
            this.Load += new System.EventHandler(this.M_First_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton M_Inven;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton M_sales;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton M_orderhistory;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton OrderStatus;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button btn_ia;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.ToolStripButton M_Menu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Button btnServ;
        private System.Windows.Forms.ComboBox cb_monthlyP;
        private System.Windows.Forms.Label lb_monthlyP;
    }
}