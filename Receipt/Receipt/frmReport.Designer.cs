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
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.contGridMenu.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.dgvReport, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblToDate
            // 
            this.lblToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(366, 33);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(46, 13);
            this.lblToDate.TabIndex = 2;
            this.lblToDate.Text = "To Date";
            // 
            // lblFromDate
            // 
            this.lblFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(3, 33);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(53, 13);
            this.lblFromDate.TabIndex = 1;
            this.lblFromDate.Text = "FromDate";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(62, 29);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(298, 20);
            this.dtpFromDate.TabIndex = 3;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(418, 29);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(298, 20);
            this.dtpToDate.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(722, 28);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblReport
            // 
            this.lblReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReport.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblReport, 5);
            this.lblReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReport.Location = new System.Drawing.Point(3, 5);
            this.lblReport.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(794, 20);
            this.lblReport.TabIndex = 6;
            this.lblReport.Text = "Report";
            this.lblReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.tableLayoutPanel1.SetColumnSpan(this.dgvReport, 5);
            this.dgvReport.ContextMenuStrip = this.contGridMenu;
            this.dgvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReport.Location = new System.Drawing.Point(3, 57);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowHeadersVisible = false;
            this.dgvReport.Size = new System.Drawing.Size(794, 390);
            this.dgvReport.TabIndex = 7;
            // 
            // Receipt_Id
            // 
            this.Receipt_Id.DataPropertyName = "Receipt_Id";
            this.Receipt_Id.HeaderText = "Receipt Id";
            this.Receipt_Id.Name = "Receipt_Id";
            this.Receipt_Id.ReadOnly = true;
            this.Receipt_Id.Visible = false;
            // 
            // Receipt_No
            // 
            this.Receipt_No.DataPropertyName = "Receipt_No";
            this.Receipt_No.HeaderText = "Receipt No";
            this.Receipt_No.Name = "Receipt_No";
            this.Receipt_No.ReadOnly = true;
            // 
            // Receipt_Date
            // 
            this.Receipt_Date.DataPropertyName = "Receipt_Date";
            this.Receipt_Date.HeaderText = "Receipt Date";
            this.Receipt_Date.Name = "Receipt_Date";
            this.Receipt_Date.ReadOnly = true;
            // 
            // Customer_Id
            // 
            this.Customer_Id.DataPropertyName = "Customer_Id";
            this.Customer_Id.HeaderText = "Customer Id";
            this.Customer_Id.Name = "Customer_Id";
            this.Customer_Id.ReadOnly = true;
            this.Customer_Id.Visible = false;
            // 
            // Customer_Name
            // 
            this.Customer_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Customer_Name.DataPropertyName = "Customer_Name";
            this.Customer_Name.HeaderText = "Customer Name";
            this.Customer_Name.Name = "Customer_Name";
            this.Customer_Name.ReadOnly = true;
            // 
            // Flate_ShopNo
            // 
            this.Flate_ShopNo.DataPropertyName = "Flate_ShopNo";
            this.Flate_ShopNo.HeaderText = "Flate / ShopNo";
            this.Flate_ShopNo.Name = "Flate_ShopNo";
            this.Flate_ShopNo.ReadOnly = true;
            // 
            // Cheq_Rtgs_Neft_ImpsNo
            // 
            this.Cheq_Rtgs_Neft_ImpsNo.DataPropertyName = "Cheq_Rtgs_Neft_ImpsNo";
            this.Cheq_Rtgs_Neft_ImpsNo.HeaderText = "CHEQ RTGS NEFT IMPS No";
            this.Cheq_Rtgs_Neft_ImpsNo.Name = "Cheq_Rtgs_Neft_ImpsNo";
            this.Cheq_Rtgs_Neft_ImpsNo.ReadOnly = true;
            // 
            // Year_Id
            // 
            this.Year_Id.DataPropertyName = "Year_Id";
            this.Year_Id.HeaderText = "Year Id";
            this.Year_Id.Name = "Year_Id";
            this.Year_Id.ReadOnly = true;
            this.Year_Id.Visible = false;
            // 
            // Bank_Name
            // 
            this.Bank_Name.DataPropertyName = "Bank_Name";
            this.Bank_Name.HeaderText = "Bank Name";
            this.Bank_Name.Name = "Bank_Name";
            this.Bank_Name.ReadOnly = true;
            // 
            // Branch_Name
            // 
            this.Branch_Name.DataPropertyName = "Branch_Name";
            this.Branch_Name.HeaderText = "Branch Name";
            this.Branch_Name.Name = "Branch_Name";
            this.Branch_Name.ReadOnly = true;
            // 
            // ReceivedAs
            // 
            this.ReceivedAs.DataPropertyName = "ReceivedAs";
            this.ReceivedAs.HeaderText = "Received As";
            this.ReceivedAs.Name = "ReceivedAs";
            this.ReceivedAs.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // Amount_Word
            // 
            this.Amount_Word.DataPropertyName = "Amount_Word";
            this.Amount_Word.HeaderText = "Amount In Word";
            this.Amount_Word.Name = "Amount_Word";
            this.Amount_Word.ReadOnly = true;
            // 
            // Payment_Date
            // 
            this.Payment_Date.DataPropertyName = "Payment_Date";
            this.Payment_Date.HeaderText = "Payment Date";
            this.Payment_Date.Name = "Payment_Date";
            this.Payment_Date.ReadOnly = true;
            // 
            // contGridMenu
            // 
            this.contGridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportDataToExcelToolStripMenuItem});
            this.contGridMenu.Name = "contGridMenu";
            this.contGridMenu.Size = new System.Drawing.Size(181, 26);
            // 
            // exportDataToExcelToolStripMenuItem
            // 
            this.exportDataToExcelToolStripMenuItem.Name = "exportDataToExcelToolStripMenuItem";
            this.exportDataToExcelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportDataToExcelToolStripMenuItem.Text = "Export Data To Excel";
            this.exportDataToExcelToolStripMenuItem.Click += new System.EventHandler(this.exportDataToExcelToolStripMenuItem_Click);
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReport";
            this.Text = "frmReport";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.contGridMenu.ResumeLayout(false);
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
    }
}