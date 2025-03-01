namespace Receipt
{
    partial class frmBanakhat
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblBANAKHATPRINT = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.wbHtmlView = new System.Windows.Forms.WebBrowser();
            this.btnprintprivew = new System.Windows.Forms.Button();
            this.lblEnterFlaotNO = new System.Windows.Forms.Label();
            this.txtFlatNo = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSendToExcel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblBANAKHATPRINT, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbCustomer, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.wbHtmlView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnprintprivew, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblEnterFlaotNO, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtFlatNo, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSendToExcel, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnPrint, 5, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1050, 774);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblBANAKHATPRINT
            // 
            this.lblBANAKHATPRINT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBANAKHATPRINT.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblBANAKHATPRINT, 5);
            this.lblBANAKHATPRINT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBANAKHATPRINT.Location = new System.Drawing.Point(4, 0);
            this.lblBANAKHATPRINT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBANAKHATPRINT.Name = "lblBANAKHATPRINT";
            this.lblBANAKHATPRINT.Size = new System.Drawing.Size(888, 24);
            this.lblBANAKHATPRINT.TabIndex = 0;
            this.lblBANAKHATPRINT.Text = "BANAKHAT PRINT";
            this.lblBANAKHATPRINT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(151, 30);
            this.cmbCustomer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(232, 24);
            this.cmbCustomer.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "SELECT CUSTOMER";
            // 
            // wbHtmlView
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.wbHtmlView, 6);
            this.wbHtmlView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbHtmlView.Location = new System.Drawing.Point(4, 64);
            this.wbHtmlView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.wbHtmlView.MinimumSize = new System.Drawing.Size(27, 25);
            this.wbHtmlView.Name = "wbHtmlView";
            this.wbHtmlView.Size = new System.Drawing.Size(1042, 670);
            this.wbHtmlView.TabIndex = 6;
            // 
            // btnprintprivew
            // 
            this.btnprintprivew.Location = new System.Drawing.Point(744, 28);
            this.btnprintprivew.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnprintprivew.Name = "btnprintprivew";
            this.btnprintprivew.Size = new System.Drawing.Size(148, 28);
            this.btnprintprivew.TabIndex = 5;
            this.btnprintprivew.Text = "PRINT PRIVEW";
            this.btnprintprivew.UseVisualStyleBackColor = true;
            this.btnprintprivew.Click += new System.EventHandler(this.btnprintprivew_Click);
            // 
            // lblEnterFlaotNO
            // 
            this.lblEnterFlaotNO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEnterFlaotNO.AutoSize = true;
            this.lblEnterFlaotNO.Location = new System.Drawing.Point(391, 34);
            this.lblEnterFlaotNO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnterFlaotNO.Name = "lblEnterFlaotNO";
            this.lblEnterFlaotNO.Size = new System.Drawing.Size(105, 16);
            this.lblEnterFlaotNO.TabIndex = 3;
            this.lblEnterFlaotNO.Text = "FLAT/SHOP NO";
            // 
            // txtFlatNo
            // 
            this.txtFlatNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFlatNo.Location = new System.Drawing.Point(504, 31);
            this.txtFlatNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFlatNo.Name = "txtFlatNo";
            this.txtFlatNo.Size = new System.Drawing.Size(232, 22);
            this.txtFlatNo.TabIndex = 4;
            this.txtFlatNo.Validated += new System.EventHandler(this.txtFlatNo_Validated);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(937, 742);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 4, 13, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 28);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSendToExcel
            // 
            this.btnSendToExcel.Location = new System.Drawing.Point(899, 27);
            this.btnSendToExcel.Name = "btnSendToExcel";
            this.btnSendToExcel.Size = new System.Drawing.Size(148, 28);
            this.btnSendToExcel.TabIndex = 8;
            this.btnSendToExcel.Text = "Send To Excel";
            this.btnSendToExcel.UseVisualStyleBackColor = true;
            this.btnSendToExcel.Click += new System.EventHandler(this.btnSendToExcel_Click);
            // 
            // frmBanakhat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1050, 774);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmBanakhat";
            this.Text = "frmBanakhat";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblBANAKHATPRINT;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnprintprivew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.WebBrowser wbHtmlView;
        private System.Windows.Forms.Label lblEnterFlaotNO;
        private System.Windows.Forms.TextBox txtFlatNo;
        private System.Windows.Forms.Button btnSendToExcel;
    }
}