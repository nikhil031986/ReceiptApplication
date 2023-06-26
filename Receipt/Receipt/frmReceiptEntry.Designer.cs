namespace Receipt
{
    partial class frmReceiptEntry
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
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.prntprvControl = new System.Windows.Forms.PrintPreviewControl();
            this.btnPrint = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbReceivedAs = new System.Windows.Forms.ComboBox();
            this.ChkIsCancel = new System.Windows.Forms.CheckBox();
            this.lblReceiptDate = new System.Windows.Forms.Label();
            this.lblReceiptNo = new System.Windows.Forms.Label();
            this.lblCheqRtgNeftIMps = new System.Windows.Forms.Label();
            this.lblBankName = new System.Windows.Forms.Label();
            this.lblBranchName = new System.Windows.Forms.Label();
            this.dtpReceiptDate = new System.Windows.Forms.DateTimePicker();
            this.txtReceiptNo = new System.Windows.Forms.TextBox();
            this.txtImpsCheqDetails = new System.Windows.Forms.TextBox();
            this.lblAmountInword = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmountInWord = new System.Windows.Forms.TextBox();
            this.lblReceivedAs = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.txtFlatShopNo = new System.Windows.Forms.TextBox();
            this.cmbCustomerName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPrintPreviw = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cboBankName = new System.Windows.Forms.ComboBox();
            this.cboBranchName = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(938, 556);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.prntprvControl, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnPrint, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(284, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(651, 550);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // prntprvControl
            // 
            this.prntprvControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prntprvControl.Location = new System.Drawing.Point(3, 3);
            this.prntprvControl.Name = "prntprvControl";
            this.prntprvControl.Size = new System.Drawing.Size(645, 515);
            this.prntprvControl.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(573, 524);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(275, 550);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.cmbReceivedAs, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.ChkIsCancel, 0, 11);
            this.tableLayoutPanel2.Controls.Add(this.lblReceiptDate, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblReceiptNo, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblCheqRtgNeftIMps, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblBankName, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.lblBranchName, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.dtpReceiptDate, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtReceiptNo, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtImpsCheqDetails, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblAmountInword, 0, 10);
            this.tableLayoutPanel2.Controls.Add(this.lblAmount, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.txtAmountInWord, 1, 10);
            this.tableLayoutPanel2.Controls.Add(this.lblReceivedAs, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.txtAmount, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.dtpPaymentDate, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.txtFlatShopNo, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.cmbCustomerName, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblCustomerName, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 12);
            this.tableLayoutPanel2.Controls.Add(this.cboBankName, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.cboBranchName, 1, 6);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 103);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 13;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(269, 344);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // cmbReceivedAs
            // 
            this.cmbReceivedAs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbReceivedAs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReceivedAs.FormattingEnabled = true;
            this.cmbReceivedAs.Items.AddRange(new object[] {
            "Without Interest"});
            this.cmbReceivedAs.Location = new System.Drawing.Point(108, 214);
            this.cmbReceivedAs.Name = "cmbReceivedAs";
            this.cmbReceivedAs.Size = new System.Drawing.Size(138, 21);
            this.cmbReceivedAs.TabIndex = 17;
            // 
            // ChkIsCancel
            // 
            this.ChkIsCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChkIsCancel.AutoSize = true;
            this.ChkIsCancel.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ChkIsCancel.Location = new System.Drawing.Point(3, 293);
            this.ChkIsCancel.Name = "ChkIsCancel";
            this.ChkIsCancel.Size = new System.Drawing.Size(99, 17);
            this.ChkIsCancel.TabIndex = 22;
            this.ChkIsCancel.Text = "IsCancel";
            this.ChkIsCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ChkIsCancel.UseVisualStyleBackColor = true;
            // 
            // lblReceiptDate
            // 
            this.lblReceiptDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReceiptDate.AutoSize = true;
            this.lblReceiptDate.Location = new System.Drawing.Point(3, 32);
            this.lblReceiptDate.Name = "lblReceiptDate";
            this.lblReceiptDate.Size = new System.Drawing.Size(99, 13);
            this.lblReceiptDate.TabIndex = 2;
            this.lblReceiptDate.Text = "Receipt Date";
            this.lblReceiptDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblReceiptNo
            // 
            this.lblReceiptNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReceiptNo.AutoSize = true;
            this.lblReceiptNo.Location = new System.Drawing.Point(3, 6);
            this.lblReceiptNo.Name = "lblReceiptNo";
            this.lblReceiptNo.Size = new System.Drawing.Size(99, 13);
            this.lblReceiptNo.TabIndex = 0;
            this.lblReceiptNo.Text = "Receipt No";
            this.lblReceiptNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCheqRtgNeftIMps
            // 
            this.lblCheqRtgNeftIMps.AutoSize = true;
            this.lblCheqRtgNeftIMps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCheqRtgNeftIMps.Location = new System.Drawing.Point(3, 105);
            this.lblCheqRtgNeftIMps.Name = "lblCheqRtgNeftIMps";
            this.lblCheqRtgNeftIMps.Size = new System.Drawing.Size(99, 26);
            this.lblCheqRtgNeftIMps.TabIndex = 8;
            this.lblCheqRtgNeftIMps.Text = "Cheq/RTGS/NEFT/IMPS No";
            this.lblCheqRtgNeftIMps.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBankName
            // 
            this.lblBankName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBankName.AutoSize = true;
            this.lblBankName.Location = new System.Drawing.Point(3, 138);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(99, 13);
            this.lblBankName.TabIndex = 10;
            this.lblBankName.Text = "Bank Name";
            this.lblBankName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBranchName
            // 
            this.lblBranchName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBranchName.AutoSize = true;
            this.lblBranchName.Location = new System.Drawing.Point(3, 165);
            this.lblBranchName.Name = "lblBranchName";
            this.lblBranchName.Size = new System.Drawing.Size(99, 13);
            this.lblBranchName.TabIndex = 12;
            this.lblBranchName.Text = "Branch Name";
            this.lblBranchName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpReceiptDate
            // 
            this.dtpReceiptDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpReceiptDate.CustomFormat = "dd/MM/yyyy";
            this.dtpReceiptDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReceiptDate.Location = new System.Drawing.Point(108, 29);
            this.dtpReceiptDate.Name = "dtpReceiptDate";
            this.dtpReceiptDate.Size = new System.Drawing.Size(138, 20);
            this.dtpReceiptDate.TabIndex = 3;
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReceiptNo.Location = new System.Drawing.Point(108, 3);
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.ReadOnly = true;
            this.txtReceiptNo.Size = new System.Drawing.Size(138, 20);
            this.txtReceiptNo.TabIndex = 1;
            // 
            // txtImpsCheqDetails
            // 
            this.txtImpsCheqDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImpsCheqDetails.Location = new System.Drawing.Point(108, 108);
            this.txtImpsCheqDetails.Name = "txtImpsCheqDetails";
            this.txtImpsCheqDetails.Size = new System.Drawing.Size(138, 20);
            this.txtImpsCheqDetails.TabIndex = 9;
            // 
            // lblAmountInword
            // 
            this.lblAmountInword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAmountInword.AutoSize = true;
            this.lblAmountInword.Location = new System.Drawing.Point(3, 270);
            this.lblAmountInword.Name = "lblAmountInword";
            this.lblAmountInword.Size = new System.Drawing.Size(99, 13);
            this.lblAmountInword.TabIndex = 20;
            this.lblAmountInword.Text = "Amount in word";
            this.lblAmountInword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAmount
            // 
            this.lblAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(3, 244);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(99, 13);
            this.lblAmount.TabIndex = 18;
            this.lblAmount.Text = "Amount";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAmountInWord
            // 
            this.txtAmountInWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAmountInWord.Location = new System.Drawing.Point(108, 267);
            this.txtAmountInWord.Name = "txtAmountInWord";
            this.txtAmountInWord.Size = new System.Drawing.Size(138, 20);
            this.txtAmountInWord.TabIndex = 21;
            // 
            // lblReceivedAs
            // 
            this.lblReceivedAs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReceivedAs.AutoSize = true;
            this.lblReceivedAs.Location = new System.Drawing.Point(3, 218);
            this.lblReceivedAs.Name = "lblReceivedAs";
            this.lblReceivedAs.Size = new System.Drawing.Size(99, 13);
            this.lblReceivedAs.TabIndex = 16;
            this.lblReceivedAs.Text = "Received As";
            this.lblReceivedAs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAmount
            // 
            this.txtAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAmount.Location = new System.Drawing.Point(108, 241);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(138, 20);
            this.txtAmount.TabIndex = 19;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Payment Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpPaymentDate.CustomFormat = "dd/MM/yyyy";
            this.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPaymentDate.Location = new System.Drawing.Point(108, 188);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.Size = new System.Drawing.Size(138, 20);
            this.dtpPaymentDate.TabIndex = 15;
            // 
            // txtFlatShopNo
            // 
            this.txtFlatShopNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFlatShopNo.Location = new System.Drawing.Point(108, 55);
            this.txtFlatShopNo.Name = "txtFlatShopNo";
            this.txtFlatShopNo.Size = new System.Drawing.Size(138, 20);
            this.txtFlatShopNo.TabIndex = 5;
            this.txtFlatShopNo.Validated += new System.EventHandler(this.txtFlatShopNo_Validated);
            // 
            // cmbCustomerName
            // 
            this.cmbCustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCustomerName.FormattingEnabled = true;
            this.cmbCustomerName.Location = new System.Drawing.Point(108, 81);
            this.cmbCustomerName.Name = "cmbCustomerName";
            this.cmbCustomerName.Size = new System.Drawing.Size(138, 21);
            this.cmbCustomerName.TabIndex = 7;
            this.cmbCustomerName.SelectedIndexChanged += new System.EventHandler(this.cmbCustomerName_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Flat/Shop No";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(3, 85);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(99, 13);
            this.lblCustomerName.TabIndex = 6;
            this.lblCustomerName.Text = "Customer Name";
            this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.SetColumnSpan(this.flowLayoutPanel1, 3);
            this.flowLayoutPanel1.Controls.Add(this.btnPrintPreviw);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(23, 316);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(243, 29);
            this.flowLayoutPanel1.TabIndex = 23;
            // 
            // btnPrintPreviw
            // 
            this.btnPrintPreviw.Location = new System.Drawing.Point(3, 3);
            this.btnPrintPreviw.Name = "btnPrintPreviw";
            this.btnPrintPreviw.Size = new System.Drawing.Size(75, 23);
            this.btnPrintPreviw.TabIndex = 0;
            this.btnPrintPreviw.Text = "Print Prive";
            this.btnPrintPreviw.UseVisualStyleBackColor = true;
            this.btnPrintPreviw.Click += new System.EventHandler(this.btnPrintPreviw_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(84, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(165, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cboBankName
            // 
            this.cboBankName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBankName.FormattingEnabled = true;
            this.cboBankName.Location = new System.Drawing.Point(108, 134);
            this.cboBankName.Name = "cboBankName";
            this.cboBankName.Size = new System.Drawing.Size(138, 21);
            this.cboBankName.TabIndex = 11;
            // 
            // cboBranchName
            // 
            this.cboBranchName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBranchName.FormattingEnabled = true;
            this.cboBranchName.Location = new System.Drawing.Point(108, 161);
            this.cboBranchName.Name = "cboBranchName";
            this.cboBranchName.Size = new System.Drawing.Size(138, 21);
            this.cboBranchName.TabIndex = 13;
            // 
            // frmReceiptEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(938, 556);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmReceiptEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receipt Details";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblAmountInword;
        private System.Windows.Forms.Label lblReceiptDate;
        private System.Windows.Forms.Label lblReceiptNo;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCheqRtgNeftIMps;
        private System.Windows.Forms.Label lblBankName;
        private System.Windows.Forms.Label lblBranchName;
        private System.Windows.Forms.Label lblReceivedAs;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.PrintPreviewControl prntprvControl;
        private System.Windows.Forms.DateTimePicker dtpReceiptDate;
        private System.Windows.Forms.ComboBox cmbCustomerName;
        private System.Windows.Forms.TextBox txtReceiptNo;
        private System.Windows.Forms.TextBox txtFlatShopNo;
        private System.Windows.Forms.TextBox txtImpsCheqDetails;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtAmountInWord;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.ComboBox cmbReceivedAs;
        private System.Windows.Forms.Button btnPrintPreviw;
        private System.Windows.Forms.CheckBox ChkIsCancel;
        private System.Windows.Forms.ComboBox cboBankName;
        private System.Windows.Forms.ComboBox cboBranchName;
    }
}