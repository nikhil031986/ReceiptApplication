namespace Receipt
{
    partial class frmReport
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblToDate = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblReport = new System.Windows.Forms.Label();
            this.plnReportOne = new System.Windows.Forms.Panel();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.Receipt_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Receipt_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Receipt_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Flate_ShopNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cheq_Rtgs_Neft_ImpsNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bank_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Branch_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceivedAs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount_Word = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payment_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contGridMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportDataToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkReportForAll = new System.Windows.Forms.CheckBox();
            this.plnReportTwo = new System.Windows.Forms.Panel();
            this.dgvAllWingReports = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.plnReportOne.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.contGridMenu.SuspendLayout();
            this.plnReportTwo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllWingReports)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblToDate, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFromDate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtpFromDate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtpToDate, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSearch, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblReport, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.plnReportOne, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkReportForAll, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.plnReportTwo, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1226, 654);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblToDate
            // 
            this.lblToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(536, 45);
            this.lblToDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(56, 16);
            this.lblToDate.TabIndex = 2;
            this.lblToDate.Text = "To Date";
            // 
            // lblFromDate
            // 
            this.lblFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(4, 45);
            this.lblFromDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(67, 16);
            this.lblFromDate.TabIndex = 1;
            this.lblFromDate.Text = "FromDate";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(79, 42);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(449, 22);
            this.dtpFromDate.TabIndex = 3;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(600, 42);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(449, 22);
            this.dtpToDate.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1057, 39);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 28);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblReport
            // 
            this.lblReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReport.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblReport, 4);
            this.lblReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReport.Location = new System.Drawing.Point(4, 8);
            this.lblReport.Margin = new System.Windows.Forms.Padding(4, 6, 4, 0);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(1045, 25);
            this.lblReport.TabIndex = 6;
            this.lblReport.Text = "Report";
            this.lblReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // plnReportOne
            // 
            this.plnReportOne.AutoSize = true;
            this.plnReportOne.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.plnReportOne, 5);
            this.plnReportOne.Controls.Add(this.dgvReport);
            this.plnReportOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plnReportOne.Location = new System.Drawing.Point(3, 74);
            this.plnReportOne.Name = "plnReportOne";
            this.plnReportOne.Size = new System.Drawing.Size(1220, 285);
            this.plnReportOne.TabIndex = 8;
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Receipt_Id,
            this.Receipt_No,
            this.Receipt_Date,
            this.Customer_Id,
            this.Customer_Name,
            this.Flate_ShopNo,
            this.Cheq_Rtgs_Neft_ImpsNo,
            this.Year_Id,
            this.Bank_Name,
            this.Branch_Name,
            this.ReceivedAs,
            this.Amount,
            this.Amount_Word,
            this.Payment_Date});
            this.dgvReport.ContextMenuStrip = this.contGridMenu;
            this.dgvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReport.Location = new System.Drawing.Point(0, 0);
            this.dgvReport.Margin = new System.Windows.Forms.Padding(4);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowHeadersVisible = false;
            this.dgvReport.RowHeadersWidth = 51;
            this.dgvReport.Size = new System.Drawing.Size(1220, 285);
            this.dgvReport.TabIndex = 7;
            // 
            // Receipt_Id
            // 
            this.Receipt_Id.DataPropertyName = "Receipt_Id";
            this.Receipt_Id.HeaderText = "Receipt Id";
            this.Receipt_Id.MinimumWidth = 6;
            this.Receipt_Id.Name = "Receipt_Id";
            this.Receipt_Id.ReadOnly = true;
            this.Receipt_Id.Visible = false;
            this.Receipt_Id.Width = 125;
            // 
            // Receipt_No
            // 
            this.Receipt_No.DataPropertyName = "Receipt_No";
            this.Receipt_No.HeaderText = "Receipt No";
            this.Receipt_No.MinimumWidth = 6;
            this.Receipt_No.Name = "Receipt_No";
            this.Receipt_No.ReadOnly = true;
            this.Receipt_No.Width = 125;
            // 
            // Receipt_Date
            // 
            this.Receipt_Date.DataPropertyName = "Receipt_Date";
            this.Receipt_Date.HeaderText = "Receipt Date";
            this.Receipt_Date.MinimumWidth = 6;
            this.Receipt_Date.Name = "Receipt_Date";
            this.Receipt_Date.ReadOnly = true;
            this.Receipt_Date.Width = 125;
            // 
            // Customer_Id
            // 
            this.Customer_Id.DataPropertyName = "Customer_Id";
            this.Customer_Id.HeaderText = "Customer Id";
            this.Customer_Id.MinimumWidth = 6;
            this.Customer_Id.Name = "Customer_Id";
            this.Customer_Id.ReadOnly = true;
            this.Customer_Id.Visible = false;
            this.Customer_Id.Width = 125;
            // 
            // Customer_Name
            // 
            this.Customer_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Customer_Name.DataPropertyName = "Customer_Name";
            this.Customer_Name.HeaderText = "Customer Name";
            this.Customer_Name.MinimumWidth = 6;
            this.Customer_Name.Name = "Customer_Name";
            this.Customer_Name.ReadOnly = true;
            // 
            // Flate_ShopNo
            // 
            this.Flate_ShopNo.DataPropertyName = "Flate_ShopNo";
            this.Flate_ShopNo.HeaderText = "Flate / ShopNo";
            this.Flate_ShopNo.MinimumWidth = 6;
            this.Flate_ShopNo.Name = "Flate_ShopNo";
            this.Flate_ShopNo.ReadOnly = true;
            this.Flate_ShopNo.Width = 125;
            // 
            // Cheq_Rtgs_Neft_ImpsNo
            // 
            this.Cheq_Rtgs_Neft_ImpsNo.DataPropertyName = "Cheq_Rtgs_Neft_ImpsNo";
            this.Cheq_Rtgs_Neft_ImpsNo.HeaderText = "CHEQ RTGS NEFT IMPS No";
            this.Cheq_Rtgs_Neft_ImpsNo.MinimumWidth = 6;
            this.Cheq_Rtgs_Neft_ImpsNo.Name = "Cheq_Rtgs_Neft_ImpsNo";
            this.Cheq_Rtgs_Neft_ImpsNo.ReadOnly = true;
            this.Cheq_Rtgs_Neft_ImpsNo.Width = 125;
            // 
            // Year_Id
            // 
            this.Year_Id.DataPropertyName = "Year_Id";
            this.Year_Id.HeaderText = "Year Id";
            this.Year_Id.MinimumWidth = 6;
            this.Year_Id.Name = "Year_Id";
            this.Year_Id.ReadOnly = true;
            this.Year_Id.Visible = false;
            this.Year_Id.Width = 125;
            // 
            // Bank_Name
            // 
            this.Bank_Name.DataPropertyName = "Bank_Name";
            this.Bank_Name.HeaderText = "Bank Name";
            this.Bank_Name.MinimumWidth = 6;
            this.Bank_Name.Name = "Bank_Name";
            this.Bank_Name.ReadOnly = true;
            this.Bank_Name.Width = 125;
            // 
            // Branch_Name
            // 
            this.Branch_Name.DataPropertyName = "Branch_Name";
            this.Branch_Name.HeaderText = "Branch Name";
            this.Branch_Name.MinimumWidth = 6;
            this.Branch_Name.Name = "Branch_Name";
            this.Branch_Name.ReadOnly = true;
            this.Branch_Name.Width = 125;
            // 
            // ReceivedAs
            // 
            this.ReceivedAs.DataPropertyName = "ReceivedAs";
            this.ReceivedAs.HeaderText = "Received As";
            this.ReceivedAs.MinimumWidth = 6;
            this.ReceivedAs.Name = "ReceivedAs";
            this.ReceivedAs.ReadOnly = true;
            this.ReceivedAs.Width = 125;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Amount";
            this.Amount.MinimumWidth = 6;
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 125;
            // 
            // Amount_Word
            // 
            this.Amount_Word.DataPropertyName = "Amount_Word";
            this.Amount_Word.HeaderText = "Amount In Word";
            this.Amount_Word.MinimumWidth = 6;
            this.Amount_Word.Name = "Amount_Word";
            this.Amount_Word.ReadOnly = true;
            this.Amount_Word.Width = 125;
            // 
            // Payment_Date
            // 
            this.Payment_Date.DataPropertyName = "Payment_Date";
            this.Payment_Date.HeaderText = "Payment Date";
            this.Payment_Date.MinimumWidth = 6;
            this.Payment_Date.Name = "Payment_Date";
            this.Payment_Date.ReadOnly = true;
            this.Payment_Date.Width = 125;
            // 
            // contGridMenu
            // 
            this.contGridMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contGridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportDataToExcelToolStripMenuItem});
            this.contGridMenu.Name = "contGridMenu";
            this.contGridMenu.Size = new System.Drawing.Size(216, 28);
            // 
            // exportDataToExcelToolStripMenuItem
            // 
            this.exportDataToExcelToolStripMenuItem.Name = "exportDataToExcelToolStripMenuItem";
            this.exportDataToExcelToolStripMenuItem.Size = new System.Drawing.Size(215, 24);
            this.exportDataToExcelToolStripMenuItem.Text = "Export Data To Excel";
            this.exportDataToExcelToolStripMenuItem.Click += new System.EventHandler(this.exportDataToExcelToolStripMenuItem_Click);
            // 
            // chkReportForAll
            // 
            this.chkReportForAll.AutoSize = true;
            this.chkReportForAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkReportForAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkReportForAll.Location = new System.Drawing.Point(1056, 3);
            this.chkReportForAll.Name = "chkReportForAll";
            this.chkReportForAll.Size = new System.Drawing.Size(167, 29);
            this.chkReportForAll.TabIndex = 9;
            this.chkReportForAll.Text = "Report For All";
            this.chkReportForAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkReportForAll.UseVisualStyleBackColor = true;
            this.chkReportForAll.CheckedChanged += new System.EventHandler(this.chkReportForAll_CheckedChanged);
            // 
            // plnReportTwo
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.plnReportTwo, 5);
            this.plnReportTwo.Controls.Add(this.dgvAllWingReports);
            this.plnReportTwo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plnReportTwo.Location = new System.Drawing.Point(3, 365);
            this.plnReportTwo.Name = "plnReportTwo";
            this.plnReportTwo.Size = new System.Drawing.Size(1220, 286);
            this.plnReportTwo.TabIndex = 10;
            // 
            // dgvAllWingReports
            // 
            this.dgvAllWingReports.AllowUserToAddRows = false;
            this.dgvAllWingReports.AllowUserToDeleteRows = false;
            this.dgvAllWingReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllWingReports.ContextMenuStrip = this.contGridMenu;
            this.dgvAllWingReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAllWingReports.Location = new System.Drawing.Point(0, 0);
            this.dgvAllWingReports.Name = "dgvAllWingReports";
            this.dgvAllWingReports.ReadOnly = true;
            this.dgvAllWingReports.RowHeadersWidth = 51;
            this.dgvAllWingReports.RowTemplate.Height = 24;
            this.dgvAllWingReports.Size = new System.Drawing.Size(1220, 286);
            this.dgvAllWingReports.TabIndex = 0;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1226, 654);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmReport";
            this.Text = "frmReport";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.plnReportOne.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.contGridMenu.ResumeLayout(false);
            this.plnReportTwo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllWingReports)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblReport;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.ContextMenuStrip contGridMenu;
        private System.Windows.Forms.ToolStripMenuItem exportDataToExcelToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receipt_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receipt_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receipt_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Flate_ShopNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cheq_Rtgs_Neft_ImpsNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bank_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Branch_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceivedAs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount_Word;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payment_Date;
        private System.Windows.Forms.Panel plnReportOne;
        private System.Windows.Forms.CheckBox chkReportForAll;
        private System.Windows.Forms.Panel plnReportTwo;
        private System.Windows.Forms.DataGridView dgvAllWingReports;
    }
}