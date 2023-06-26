namespace Receipt
{
    partial class frmCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomer));
            this.tblMainCustomerDetails = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.cboSearch = new System.Windows.Forms.ComboBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tolFirst = new System.Windows.Forms.ToolStripButton();
            this.tolPrv = new System.Windows.Forms.ToolStripButton();
            this.txttolDisplay = new System.Windows.Forms.ToolStripLabel();
            this.tolTotalPages = new System.Windows.Forms.ToolStripLabel();
            this.tolNext = new System.Windows.Forms.ToolStripButton();
            this.tolLast = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tolRowsCounts = new System.Windows.Forms.ToolStripLabel();
            this.txttolRowsCount = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblGotoPageNo = new System.Windows.Forms.ToolStripLabel();
            this.txtGotoPageNo = new System.Windows.Forms.ToolStripTextBox();
            this.btnGoTo = new System.Windows.Forms.ToolStripButton();
            this.dgCustomer = new System.Windows.Forms.DataGridView();
            this.Customer_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wing_Master_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wing_Details_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wing_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Flate_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Con_Details = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer_Wing_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BanakhatNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BanakhatDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txttolDisplay1 = new System.Windows.Forms.ToolStripTextBox();
            this.ctxCustomerSendToExcel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sendToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tblMainCustomerDetails.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomer)).BeginInit();
            this.ctxCustomerSendToExcel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblMainCustomerDetails
            // 
            this.tblMainCustomerDetails.AutoSize = true;
            this.tblMainCustomerDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblMainCustomerDetails.ColumnCount = 1;
            this.tblMainCustomerDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMainCustomerDetails.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tblMainCustomerDetails.Controls.Add(this.dgCustomer, 0, 1);
            this.tblMainCustomerDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMainCustomerDetails.Location = new System.Drawing.Point(0, 0);
            this.tblMainCustomerDetails.Name = "tblMainCustomerDetails";
            this.tblMainCustomerDetails.RowCount = 2;
            this.tblMainCustomerDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMainCustomerDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMainCustomerDetails.Size = new System.Drawing.Size(1050, 624);
            this.tblMainCustomerDetails.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.toolStrip1, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1044, 109);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel1, 5);
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Controls.Add(this.btnClose, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCustomer, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1038, 38);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(1001, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(34, 32);
            this.btnClose.TabIndex = 1;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblCustomer
            // 
            this.lblCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(42, 9);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(953, 20);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "Customer Details";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Receipt.Properties.Resources.CustomerDetails;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel4, 5);
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.cboSearch, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblSearch, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtSearch, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel2, 3, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 44);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1044, 33);
            this.tableLayoutPanel4.TabIndex = 39;
            // 
            // cboSearch
            // 
            this.cboSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSearch.FormattingEnabled = true;
            this.cboSearch.Location = new System.Drawing.Point(87, 6);
            this.cboSearch.Name = "cboSearch";
            this.cboSearch.Size = new System.Drawing.Size(247, 21);
            this.cboSearch.TabIndex = 0;
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(3, 10);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(3, 0, 40, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(41, 13);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(340, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(534, 20);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.Controls.Add(this.btnSave);
            this.flowLayoutPanel2.Controls.Add(this.button1);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(877, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(167, 33);
            this.flowLayoutPanel2.TabIndex = 38;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "ADD";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(84, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 40;
            this.button1.Text = "EDIT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.toolStrip1, 5);
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tolFirst,
            this.tolPrv,
            this.txttolDisplay,
            this.tolTotalPages,
            this.tolNext,
            this.tolLast,
            this.toolStripSeparator1,
            this.tolRowsCounts,
            this.txttolRowsCount,
            this.toolStripSeparator2,
            this.lblGotoPageNo,
            this.txtGotoPageNo,
            this.btnGoTo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 77);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1044, 32);
            this.toolStrip1.TabIndex = 41;
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
            this.txttolDisplay.TextChanged += new System.EventHandler(this.txttolDisplay_TextChanged);
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
            // tolRowsCounts
            // 
            this.tolRowsCounts.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tolRowsCounts.Name = "tolRowsCounts";
            this.tolRowsCounts.Size = new System.Drawing.Size(157, 29);
            this.tolRowsCounts.Text = "Page Rows Count";
            // 
            // txttolRowsCount
            // 
            this.txttolRowsCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txttolRowsCount.Name = "txttolRowsCount";
            this.txttolRowsCount.Size = new System.Drawing.Size(100, 32);
            this.txttolRowsCount.TextChanged += new System.EventHandler(this.txttolRowsCount_TextChanged);
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
            // dgCustomer
            // 
            this.dgCustomer.AllowUserToAddRows = false;
            this.dgCustomer.AllowUserToDeleteRows = false;
            this.dgCustomer.BackgroundColor = System.Drawing.Color.White;
            this.dgCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Customer_Id,
            this.Wing_Master_Id,
            this.Wing_Details_Id,
            this.Customer_Name,
            this.Wing_Name,
            this.Flate_No,
            this.Address,
            this.Con_Details,
            this.Email_Id,
            this.Customer_Wing_Name,
            this.BanakhatNo,
            this.BanakhatDate});
            this.dgCustomer.ContextMenuStrip = this.ctxCustomerSendToExcel;
            this.dgCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCustomer.Location = new System.Drawing.Point(3, 118);
            this.dgCustomer.Name = "dgCustomer";
            this.dgCustomer.ReadOnly = true;
            this.dgCustomer.RowHeadersVisible = false;
            this.dgCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCustomer.Size = new System.Drawing.Size(1044, 503);
            this.dgCustomer.TabIndex = 1;
            this.dgCustomer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCustomer_CellClick);
            // 
            // Customer_Id
            // 
            this.Customer_Id.DataPropertyName = "Customer_Id";
            this.Customer_Id.HeaderText = "Customer_Id";
            this.Customer_Id.Name = "Customer_Id";
            this.Customer_Id.ReadOnly = true;
            this.Customer_Id.Visible = false;
            this.Customer_Id.Width = 180;
            // 
            // Wing_Master_Id
            // 
            this.Wing_Master_Id.DataPropertyName = "Wing_Master_Id";
            this.Wing_Master_Id.HeaderText = "Wing_Master_Id";
            this.Wing_Master_Id.Name = "Wing_Master_Id";
            this.Wing_Master_Id.ReadOnly = true;
            this.Wing_Master_Id.Visible = false;
            // 
            // Wing_Details_Id
            // 
            this.Wing_Details_Id.DataPropertyName = "Wing_Details_Id";
            this.Wing_Details_Id.HeaderText = "Wing_Details_Id";
            this.Wing_Details_Id.Name = "Wing_Details_Id";
            this.Wing_Details_Id.ReadOnly = true;
            this.Wing_Details_Id.Visible = false;
            // 
            // Customer_Name
            // 
            this.Customer_Name.DataPropertyName = "Customer_Name";
            this.Customer_Name.HeaderText = "Customer Name";
            this.Customer_Name.Name = "Customer_Name";
            this.Customer_Name.ReadOnly = true;
            this.Customer_Name.Width = 180;
            // 
            // Wing_Name
            // 
            this.Wing_Name.DataPropertyName = "Wing_Name";
            this.Wing_Name.HeaderText = "Wing Name";
            this.Wing_Name.Name = "Wing_Name";
            this.Wing_Name.ReadOnly = true;
            // 
            // Flate_No
            // 
            this.Flate_No.DataPropertyName = "FlatNo";
            this.Flate_No.HeaderText = "Flate No";
            this.Flate_No.Name = "Flate_No";
            this.Flate_No.ReadOnly = true;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Width = 120;
            // 
            // Con_Details
            // 
            this.Con_Details.DataPropertyName = "Con_Details";
            this.Con_Details.HeaderText = "Con. Details";
            this.Con_Details.Name = "Con_Details";
            this.Con_Details.ReadOnly = true;
            // 
            // Email_Id
            // 
            this.Email_Id.DataPropertyName = "Email_Id";
            this.Email_Id.HeaderText = "Email Id";
            this.Email_Id.Name = "Email_Id";
            this.Email_Id.ReadOnly = true;
            // 
            // Customer_Wing_Name
            // 
            this.Customer_Wing_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Customer_Wing_Name.DataPropertyName = "Customer_Wing_Name";
            this.Customer_Wing_Name.HeaderText = "Customer Wing Name";
            this.Customer_Wing_Name.Name = "Customer_Wing_Name";
            this.Customer_Wing_Name.ReadOnly = true;
            this.Customer_Wing_Name.Width = 98;
            // 
            // BanakhatNo
            // 
            this.BanakhatNo.DataPropertyName = "BanakhatNo";
            this.BanakhatNo.HeaderText = "Banakhat No";
            this.BanakhatNo.Name = "BanakhatNo";
            this.BanakhatNo.ReadOnly = true;
            // 
            // BanakhatDate
            // 
            this.BanakhatDate.DataPropertyName = "BanakhatDate";
            this.BanakhatDate.HeaderText = "Banakhat Date";
            this.BanakhatDate.Name = "BanakhatDate";
            this.BanakhatDate.ReadOnly = true;
            // 
            // txttolDisplay1
            // 
            this.txttolDisplay1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txttolDisplay1.Name = "txttolDisplay1";
            this.txttolDisplay1.Size = new System.Drawing.Size(100, 23);
            // 
            // ctxCustomerSendToExcel
            // 
            this.ctxCustomerSendToExcel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendToExcelToolStripMenuItem});
            this.ctxCustomerSendToExcel.Name = "ctxCustomerSendToExcel";
            this.ctxCustomerSendToExcel.Size = new System.Drawing.Size(181, 48);
            // 
            // sendToExcelToolStripMenuItem
            // 
            this.sendToExcelToolStripMenuItem.Name = "sendToExcelToolStripMenuItem";
            this.sendToExcelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sendToExcelToolStripMenuItem.Text = "Send To Excel";
            this.sendToExcelToolStripMenuItem.Click += new System.EventHandler(this.sendToExcelToolStripMenuItem_Click);
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1050, 624);
            this.Controls.Add(this.tblMainCustomerDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomer";
            this.Text = "frmCustomer";
            this.Load += new System.EventHandler(this.frmCustomer_Load);
            this.tblMainCustomerDetails.ResumeLayout(false);
            this.tblMainCustomerDetails.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomer)).EndInit();
            this.ctxCustomerSendToExcel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblMainCustomerDetails;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgCustomer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wing_Master_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wing_Details_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wing_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Flate_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Con_Details;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_Wing_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn BanakhatNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BanakhatDate;
        private System.Windows.Forms.ContextMenuStrip ctxCustomerSendToExcel;
        private System.Windows.Forms.ToolStripMenuItem sendToExcelToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ComboBox cboSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tolFirst;
        private System.Windows.Forms.ToolStripButton tolPrv;
        private System.Windows.Forms.ToolStripTextBox txttolDisplay1;
        private System.Windows.Forms.ToolStripLabel tolTotalPages;
        private System.Windows.Forms.ToolStripButton tolNext;
        private System.Windows.Forms.ToolStripButton tolLast;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel tolRowsCounts;
        private System.Windows.Forms.ToolStripTextBox txttolRowsCount;
        private System.Windows.Forms.ToolStripLabel txttolDisplay;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lblGotoPageNo;
        private System.Windows.Forms.ToolStripButton btnGoTo;
        private System.Windows.Forms.ToolStripTextBox txtGotoPageNo;
    }
}