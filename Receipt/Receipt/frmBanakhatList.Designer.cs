namespace Receipt
{
    partial class frmBanakhatList
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
            this.lblBanakhatList = new System.Windows.Forms.Label();
            this.dgvListOfBanakhat = new System.Windows.Forms.DataGridView();
            this.Customer_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wing_Master_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wing_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlatNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minPayAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrintBanakhat = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ctMnuGridSendToExcel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sendToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnprint = new System.Windows.Forms.Button();
            this.chlRePrintBANAKHAT = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListOfBanakhat)).BeginInit();
            this.ctMnuGridSendToExcel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblBanakhatList, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvListOfBanakhat, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnprint, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.chlRePrintBANAKHAT, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 523);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblBanakhatList
            // 
            this.lblBanakhatList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBanakhatList.AutoSize = true;
            this.lblBanakhatList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanakhatList.Location = new System.Drawing.Point(3, 0);
            this.lblBanakhatList.Name = "lblBanakhatList";
            this.lblBanakhatList.Size = new System.Drawing.Size(794, 18);
            this.lblBanakhatList.TabIndex = 0;
            this.lblBanakhatList.Text = "BANAKHAT LIST";
            this.lblBanakhatList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvListOfBanakhat
            // 
            this.dgvListOfBanakhat.AllowUserToAddRows = false;
            this.dgvListOfBanakhat.AllowUserToDeleteRows = false;
            this.dgvListOfBanakhat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListOfBanakhat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Customer_Id,
            this.Customer_Name,
            this.Wing_Master_Id,
            this.Wing_Name,
            this.FlatNo,
            this.Amount,
            this.minPayAmount,
            this.ReceiptAmount,
            this.PrintBanakhat});
            this.dgvListOfBanakhat.ContextMenuStrip = this.ctMnuGridSendToExcel;
            this.dgvListOfBanakhat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListOfBanakhat.Location = new System.Drawing.Point(3, 103);
            this.dgvListOfBanakhat.Name = "dgvListOfBanakhat";
            this.dgvListOfBanakhat.RowHeadersVisible = false;
            this.dgvListOfBanakhat.Size = new System.Drawing.Size(794, 397);
            this.dgvListOfBanakhat.TabIndex = 1;
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
            this.Customer_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Customer_Name.DataPropertyName = "Customer_Name";
            this.Customer_Name.HeaderText = "Customer_Name";
            this.Customer_Name.Name = "Customer_Name";
            this.Customer_Name.ReadOnly = true;
            // 
            // Wing_Master_Id
            // 
            this.Wing_Master_Id.DataPropertyName = "Wing_Master_Id";
            this.Wing_Master_Id.HeaderText = "Wing_Master_Id";
            this.Wing_Master_Id.Name = "Wing_Master_Id";
            this.Wing_Master_Id.ReadOnly = true;
            this.Wing_Master_Id.Visible = false;
            // 
            // Wing_Name
            // 
            this.Wing_Name.DataPropertyName = "Wing_Name";
            this.Wing_Name.HeaderText = "Wing_Name";
            this.Wing_Name.Name = "Wing_Name";
            this.Wing_Name.ReadOnly = true;
            // 
            // FlatNo
            // 
            this.FlatNo.DataPropertyName = "FlatNo";
            this.FlatNo.HeaderText = "FlatNo";
            this.FlatNo.Name = "FlatNo";
            this.FlatNo.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // minPayAmount
            // 
            this.minPayAmount.DataPropertyName = "minPayAmount";
            this.minPayAmount.HeaderText = "minPayAmount";
            this.minPayAmount.Name = "minPayAmount";
            this.minPayAmount.ReadOnly = true;
            // 
            // ReceiptAmount
            // 
            this.ReceiptAmount.DataPropertyName = "ReceiptAmount";
            this.ReceiptAmount.HeaderText = "ReceiptAmount";
            this.ReceiptAmount.Name = "ReceiptAmount";
            this.ReceiptAmount.ReadOnly = true;
            // 
            // PrintBanakhat
            // 
            this.PrintBanakhat.DataPropertyName = "PrintBanakhat";
            this.PrintBanakhat.FalseValue = "0";
            this.PrintBanakhat.HeaderText = "PrintBanakhat";
            this.PrintBanakhat.Name = "PrintBanakhat";
            this.PrintBanakhat.TrueValue = "1";
            // 
            // ctMnuGridSendToExcel
            // 
            this.ctMnuGridSendToExcel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendToExcelToolStripMenuItem});
            this.ctMnuGridSendToExcel.Name = "ctMnuGridSendToExcel";
            this.ctMnuGridSendToExcel.Size = new System.Drawing.Size(140, 26);
            // 
            // sendToExcelToolStripMenuItem
            // 
            this.sendToExcelToolStripMenuItem.Name = "sendToExcelToolStripMenuItem";
            this.sendToExcelToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.sendToExcelToolStripMenuItem.Text = "SendToExcel";
            this.sendToExcelToolStripMenuItem.Click += new System.EventHandler(this.sendToExcelToolStripMenuItem_Click);
            // 
            // btnprint
            // 
            this.btnprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnprint.Location = new System.Drawing.Point(722, 506);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(75, 14);
            this.btnprint.TabIndex = 2;
            this.btnprint.Text = "print";
            this.btnprint.UseVisualStyleBackColor = true;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // chlRePrintBANAKHAT
            // 
            this.chlRePrintBANAKHAT.AutoSize = true;
            this.chlRePrintBANAKHAT.Location = new System.Drawing.Point(3, 21);
            this.chlRePrintBANAKHAT.Name = "chlRePrintBANAKHAT";
            this.chlRePrintBANAKHAT.Size = new System.Drawing.Size(138, 17);
            this.chlRePrintBANAKHAT.TabIndex = 3;
            this.chlRePrintBANAKHAT.Text = "Show Printed Banakhat";
            this.chlRePrintBANAKHAT.UseVisualStyleBackColor = true;
            this.chlRePrintBANAKHAT.CheckedChanged += new System.EventHandler(this.chlRePrintBANAKHAT_CheckedChanged);
            // 
            // frmBanakhatList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 523);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBanakhatList";
            this.Text = "BANAKHAT LIST";
            this.Load += new System.EventHandler(this.frmBanakhatList_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListOfBanakhat)).EndInit();
            this.ctMnuGridSendToExcel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblBanakhatList;
        private System.Windows.Forms.DataGridView dgvListOfBanakhat;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wing_Master_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wing_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlatNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn minPayAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptAmount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PrintBanakhat;
        private System.Windows.Forms.ContextMenuStrip ctMnuGridSendToExcel;
        private System.Windows.Forms.ToolStripMenuItem sendToExcelToolStripMenuItem;
        private System.Windows.Forms.CheckBox chlRePrintBANAKHAT;
    }
}