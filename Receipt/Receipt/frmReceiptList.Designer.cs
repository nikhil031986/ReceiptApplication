namespace Receipt
{
    partial class frmReceiptList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReceiptList));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbColumnName = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvReceiptList = new System.Windows.Forms.DataGridView();
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
            this.IsCancel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsPrint = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Receipt_Print = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ctMenuReceiptList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblReceiptDetails = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tolFirst = new System.Windows.Forms.ToolStripButton();
            this.tolPrv = new System.Windows.Forms.ToolStripButton();
            this.txttolDisplay = new System.Windows.Forms.ToolStripLabel();
            this.tolTotalPages = new System.Windows.Forms.ToolStripLabel();
            this.tolNext = new System.Windows.Forms.ToolStripButton();
            this.tolLast = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.txttolRowsCount = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblGotoPageNo = new System.Windows.Forms.ToolStripLabel();
            this.txtGotoPageNo = new System.Windows.Forms.ToolStripTextBox();
            this.btnGoTo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tltTotalAMOUNT = new System.Windows.Forms.ToolStripLabel();
            this.importFromExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptList)).BeginInit();
            this.ctMenuReceiptList.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvReceiptList, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblReceiptDetails, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1083, 564);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.btnAdd, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnEdit, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 20);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1083, 34);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(963, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 28);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(1029, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(51, 28);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "EDIT";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel3.Controls.Add(this.cmbColumnName, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtSearch, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(960, 34);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // cmbColumnName
            // 
            this.cmbColumnName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbColumnName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColumnName.FormattingEnabled = true;
            this.cmbColumnName.Location = new System.Drawing.Point(3, 6);
            this.cmbColumnName.Name = "cmbColumnName";
            this.cmbColumnName.Size = new System.Drawing.Size(186, 21);
            this.cmbColumnName.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(195, 7);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(762, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dgvReceiptList
            // 
            this.dgvReceiptList.AllowUserToAddRows = false;
            this.dgvReceiptList.AllowUserToDeleteRows = false;
            this.dgvReceiptList.BackgroundColor = System.Drawing.Color.White;
            this.dgvReceiptList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceiptList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.Payment_Date,
            this.IsCancel,
            this.IsPrint,
            this.Receipt_Print});
            this.dgvReceiptList.ContextMenuStrip = this.ctMenuReceiptList;
            this.dgvReceiptList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReceiptList.Location = new System.Drawing.Point(3, 89);
            this.dgvReceiptList.Name = "dgvReceiptList";
            this.dgvReceiptList.ReadOnly = true;
            this.dgvReceiptList.RowHeadersVisible = false;
            this.dgvReceiptList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReceiptList.Size = new System.Drawing.Size(1077, 472);
            this.dgvReceiptList.TabIndex = 0;
            this.dgvReceiptList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReceiptList_CellClick);
            // 
            // Receipt_Id
            // 
            this.Receipt_Id.DataPropertyName = "Receipt_Id";
            this.Receipt_Id.HeaderText = "Receipt_Id";
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
            this.Customer_Id.HeaderText = "Customer_Id";
            this.Customer_Id.Name = "Customer_Id";
            this.Customer_Id.ReadOnly = true;
            this.Customer_Id.Visible = false;
            // 
            // Customer_Name
            // 
            this.Customer_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Customer_Name.DataPropertyName = "Customer_Name";
            this.Customer_Name.HeaderText = "Customer Name";
            this.Customer_Name.Name = "Customer_Name";
            this.Customer_Name.ReadOnly = true;
            this.Customer_Name.Width = 98;
            // 
            // Flate_ShopNo
            // 
            this.Flate_ShopNo.DataPropertyName = "Flate_ShopNo";
            this.Flate_ShopNo.HeaderText = "Flate/ShopNo";
            this.Flate_ShopNo.Name = "Flate_ShopNo";
            this.Flate_ShopNo.ReadOnly = true;
            // 
            // Cheq_Rtgs_Neft_ImpsNo
            // 
            this.Cheq_Rtgs_Neft_ImpsNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Cheq_Rtgs_Neft_ImpsNo.DataPropertyName = "Cheq_Rtgs_Neft_ImpsNo";
            this.Cheq_Rtgs_Neft_ImpsNo.HeaderText = "Cheq/RTGS/NEFT/IMPS No";
            this.Cheq_Rtgs_Neft_ImpsNo.Name = "Cheq_Rtgs_Neft_ImpsNo";
            this.Cheq_Rtgs_Neft_ImpsNo.ReadOnly = true;
            this.Cheq_Rtgs_Neft_ImpsNo.Width = 158;
            // 
            // Year_Id
            // 
            this.Year_Id.DataPropertyName = "Year_Id";
            this.Year_Id.HeaderText = "Year_Id";
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
            this.Amount_Word.HeaderText = "Amount Word";
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
            // IsCancel
            // 
            this.IsCancel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IsCancel.DataPropertyName = "IsCancel";
            this.IsCancel.FalseValue = "0";
            this.IsCancel.HeaderText = "IsCancel";
            this.IsCancel.Name = "IsCancel";
            this.IsCancel.ReadOnly = true;
            this.IsCancel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsCancel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsCancel.TrueValue = "1";
            this.IsCancel.Width = 73;
            // 
            // IsPrint
            // 
            this.IsPrint.DataPropertyName = "IsPrint";
            this.IsPrint.FalseValue = "0";
            this.IsPrint.HeaderText = "Is Print";
            this.IsPrint.Name = "IsPrint";
            this.IsPrint.ReadOnly = true;
            this.IsPrint.TrueValue = "1";
            // 
            // Receipt_Print
            // 
            this.Receipt_Print.DataPropertyName = "Print_Receipt";
            this.Receipt_Print.HeaderText = "Receipt Print";
            this.Receipt_Print.Name = "Receipt_Print";
            this.Receipt_Print.ReadOnly = true;
            this.Receipt_Print.Text = "Print Receipt";
            this.Receipt_Print.ToolTipText = "Print ";
            // 
            // ctMenuReceiptList
            // 
            this.ctMenuReceiptList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToExcelToolStripMenuItem,
            this.importFromExcelToolStripMenuItem});
            this.ctMenuReceiptList.Name = "ctMenuReceiptList";
            this.ctMenuReceiptList.Size = new System.Drawing.Size(181, 70);
            // 
            // exportToExcelToolStripMenuItem
            // 
            this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
            this.exportToExcelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportToExcelToolStripMenuItem.Text = "Export To Excel";
            this.exportToExcelToolStripMenuItem.Click += new System.EventHandler(this.exportToExcelToolStripMenuItem_Click);
            // 
            // lblReceiptDetails
            // 
            this.lblReceiptDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReceiptDetails.AutoSize = true;
            this.lblReceiptDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiptDetails.Location = new System.Drawing.Point(3, 0);
            this.lblReceiptDetails.Name = "lblReceiptDetails";
            this.lblReceiptDetails.Size = new System.Drawing.Size(1077, 20);
            this.lblReceiptDetails.TabIndex = 2;
            this.lblReceiptDetails.Text = "Receipt List";
            this.lblReceiptDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.toolStrip1, 5);
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tolFirst,
            this.tolPrv,
            this.txttolDisplay,
            this.tolTotalPages,
            this.tolNext,
            this.tolLast,
            this.toolStripSeparator1,
            this.toolStripLabel3,
            this.txttolRowsCount,
            this.toolStripSeparator2,
            this.lblGotoPageNo,
            this.txtGotoPageNo,
            this.btnGoTo,
            this.toolStripSeparator3,
            this.tltTotalAMOUNT});
            this.toolStrip1.Location = new System.Drawing.Point(0, 54);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1083, 32);
            this.toolStrip1.TabIndex = 42;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tolFirst
            // 
            this.tolFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tolFirst.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tolFirst.Image = ((System.Drawing.Image)(resources.GetObject("tolFirst.Image")));
            this.tolFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tolFirst.Name = "tolFirst";
            this.tolFirst.Size = new System.Drawing.Size(35, 29);
            this.tolFirst.Text = "|<";
            this.tolFirst.Click += new System.EventHandler(this.tolFirst_Click);
            // 
            // tolPrv
            // 
            this.tolPrv.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tolPrv.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tolPrv.Image = ((System.Drawing.Image)(resources.GetObject("tolPrv.Image")));
            this.tolPrv.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tolPrv.Name = "tolPrv";
            this.tolPrv.Size = new System.Drawing.Size(42, 29);
            this.tolPrv.Text = "<<";
            this.tolPrv.Click += new System.EventHandler(this.tolPrv_Click);
            // 
            // txttolDisplay
            // 
            this.txttolDisplay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txttolDisplay.Name = "txttolDisplay";
            this.txttolDisplay.Size = new System.Drawing.Size(13, 29);
            this.txttolDisplay.Text = "1";
            // 
            // tolTotalPages
            // 
            this.tolTotalPages.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tolTotalPages.Name = "tolTotalPages";
            this.tolTotalPages.Size = new System.Drawing.Size(40, 29);
            this.tolTotalPages.Text = "OF ";
            // 
            // tolNext
            // 
            this.tolNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tolNext.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tolNext.Image = ((System.Drawing.Image)(resources.GetObject("tolNext.Image")));
            this.tolNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tolNext.Name = "tolNext";
            this.tolNext.Size = new System.Drawing.Size(42, 29);
            this.tolNext.Text = ">>";
            this.tolNext.Click += new System.EventHandler(this.tolNext_Click);
            // 
            // tolLast
            // 
            this.tolLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tolLast.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tolLast.Image = ((System.Drawing.Image)(resources.GetObject("tolLast.Image")));
            this.tolLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tolLast.Name = "tolLast";
            this.tolLast.Size = new System.Drawing.Size(35, 29);
            this.tolLast.Text = ">|";
            this.tolLast.Click += new System.EventHandler(this.tolLast_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(157, 29);
            this.toolStripLabel3.Text = "Page Rows Count";
            // 
            // txttolRowsCount
            // 
            this.txttolRowsCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txttolRowsCount.Name = "txttolRowsCount";
            this.txttolRowsCount.Size = new System.Drawing.Size(100, 32);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // lblGotoPageNo
            // 
            this.lblGotoPageNo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGotoPageNo.Name = "lblGotoPageNo";
            this.lblGotoPageNo.Size = new System.Drawing.Size(83, 29);
            this.lblGotoPageNo.Text = "Page No";
            // 
            // txtGotoPageNo
            // 
            this.txtGotoPageNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGotoPageNo.Name = "txtGotoPageNo";
            this.txtGotoPageNo.Size = new System.Drawing.Size(100, 32);
            // 
            // btnGoTo
            // 
            this.btnGoTo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnGoTo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoTo.Image = ((System.Drawing.Image)(resources.GetObject("btnGoTo.Image")));
            this.btnGoTo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGoTo.Name = "btnGoTo";
            this.btnGoTo.Size = new System.Drawing.Size(40, 29);
            this.btnGoTo.Text = "Go";
            this.btnGoTo.Click += new System.EventHandler(this.btnGoTo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            // 
            // tltTotalAMOUNT
            // 
            this.tltTotalAMOUNT.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tltTotalAMOUNT.Name = "tltTotalAMOUNT";
            this.tltTotalAMOUNT.Size = new System.Drawing.Size(128, 29);
            this.tltTotalAMOUNT.Text = "Total Amount:";
            // 
            // importFromExcelToolStripMenuItem
            // 
            this.importFromExcelToolStripMenuItem.Name = "importFromExcelToolStripMenuItem";
            this.importFromExcelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.importFromExcelToolStripMenuItem.Text = "Import From Excel";
            this.importFromExcelToolStripMenuItem.Click += new System.EventHandler(this.importFromExcelToolStripMenuItem_Click);
            // 
            // frmReceiptList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1083, 564);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmReceiptList";
            this.Text = "Receipt List";
            this.Load += new System.EventHandler(this.frmReceiptList_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptList)).EndInit();
            this.ctMenuReceiptList.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvReceiptList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label lblReceiptDetails;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox cmbColumnName;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ContextMenuStrip ctMenuReceiptList;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelToolStripMenuItem;
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
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsCancel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsPrint;
        private System.Windows.Forms.DataGridViewButtonColumn Receipt_Print;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tolFirst;
        private System.Windows.Forms.ToolStripButton tolPrv;
        private System.Windows.Forms.ToolStripLabel txttolDisplay;
        private System.Windows.Forms.ToolStripLabel tolTotalPages;
        private System.Windows.Forms.ToolStripButton tolNext;
        private System.Windows.Forms.ToolStripButton tolLast;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox txttolRowsCount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lblGotoPageNo;
        private System.Windows.Forms.ToolStripTextBox txtGotoPageNo;
        private System.Windows.Forms.ToolStripButton btnGoTo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel tltTotalAMOUNT;
        private System.Windows.Forms.ToolStripMenuItem importFromExcelToolStripMenuItem;
    }
}