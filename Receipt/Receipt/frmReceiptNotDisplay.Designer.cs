namespace Receipt
{
    partial class frmReceiptNotDisplay
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
            this.dgvReceiptNotDisplay = new System.Windows.Forms.DataGridView();
            this.btnUpdateSelected = new System.Windows.Forms.Button();
            this.btnUpdateAll = new System.Windows.Forms.Button();
            this.Receipt_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Receipt_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Receipt_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bank_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Branch_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Flate_ShopNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsUpdate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptNotDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.dgvReceiptNotDisplay, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnUpdateSelected, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnUpdateAll, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(951, 506);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvReceiptNotDisplay
            // 
            this.dgvReceiptNotDisplay.AllowUserToAddRows = false;
            this.dgvReceiptNotDisplay.AllowUserToDeleteRows = false;
            this.dgvReceiptNotDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceiptNotDisplay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Receipt_Id,
            this.Receipt_No,
            this.Receipt_Date,
            this.Bank_Name,
            this.Branch_Name,
            this.Amount,
            this.ReceiptCustomer,
            this.Customer_Id,
            this.Customer_Name,
            this.Flate_ShopNo,
            this.IsUpdate});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvReceiptNotDisplay, 2);
            this.dgvReceiptNotDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReceiptNotDisplay.Location = new System.Drawing.Point(3, 3);
            this.dgvReceiptNotDisplay.Name = "dgvReceiptNotDisplay";
            this.dgvReceiptNotDisplay.Size = new System.Drawing.Size(945, 471);
            this.dgvReceiptNotDisplay.TabIndex = 0;
            // 
            // btnUpdateSelected
            // 
            this.btnUpdateSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateSelected.Location = new System.Drawing.Point(757, 480);
            this.btnUpdateSelected.Name = "btnUpdateSelected";
            this.btnUpdateSelected.Size = new System.Drawing.Size(110, 23);
            this.btnUpdateSelected.TabIndex = 1;
            this.btnUpdateSelected.Text = "Update Selected ";
            this.btnUpdateSelected.UseVisualStyleBackColor = true;
            this.btnUpdateSelected.Click += new System.EventHandler(this.btnUpdateSelected_Click);
            // 
            // btnUpdateAll
            // 
            this.btnUpdateAll.Location = new System.Drawing.Point(873, 480);
            this.btnUpdateAll.Name = "btnUpdateAll";
            this.btnUpdateAll.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateAll.TabIndex = 2;
            this.btnUpdateAll.Text = "Update All";
            this.btnUpdateAll.UseVisualStyleBackColor = true;
            this.btnUpdateAll.Click += new System.EventHandler(this.btnUpdateAll_Click);
            // 
            // Receipt_Id
            // 
            this.Receipt_Id.DataPropertyName = "Receipt_Id";
            this.Receipt_Id.HeaderText = "Receipt_Id";
            this.Receipt_Id.Name = "Receipt_Id";
            this.Receipt_Id.Visible = false;
            // 
            // Receipt_No
            // 
            this.Receipt_No.DataPropertyName = "Receipt_No";
            this.Receipt_No.HeaderText = "Receipt_No";
            this.Receipt_No.Name = "Receipt_No";
            // 
            // Receipt_Date
            // 
            this.Receipt_Date.DataPropertyName = "Receipt_Date";
            this.Receipt_Date.HeaderText = "Receipt_Date";
            this.Receipt_Date.Name = "Receipt_Date";
            // 
            // Bank_Name
            // 
            this.Bank_Name.DataPropertyName = "Bank_Name";
            this.Bank_Name.HeaderText = "Bank_Name";
            this.Bank_Name.Name = "Bank_Name";
            // 
            // Branch_Name
            // 
            this.Branch_Name.DataPropertyName = "Branch_Name";
            this.Branch_Name.HeaderText = "Branch_Name";
            this.Branch_Name.Name = "Branch_Name";
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            // 
            // ReceiptCustomer
            // 
            this.ReceiptCustomer.DataPropertyName = "ReceiptCustomer";
            this.ReceiptCustomer.HeaderText = "ReceiptCustomer";
            this.ReceiptCustomer.Name = "ReceiptCustomer";
            // 
            // Customer_Id
            // 
            this.Customer_Id.DataPropertyName = "Customer_Id";
            this.Customer_Id.HeaderText = "Customer_Id";
            this.Customer_Id.Name = "Customer_Id";
            this.Customer_Id.Visible = false;
            // 
            // Customer_Name
            // 
            this.Customer_Name.DataPropertyName = "Customer_Name";
            this.Customer_Name.HeaderText = "Customer_Name";
            this.Customer_Name.Name = "Customer_Name";
            // 
            // Flate_ShopNo
            // 
            this.Flate_ShopNo.DataPropertyName = "Flate_ShopNo";
            this.Flate_ShopNo.HeaderText = "Flate_ShopNo";
            this.Flate_ShopNo.Name = "Flate_ShopNo";
            // 
            // IsUpdate
            // 
            this.IsUpdate.DataPropertyName = "IsUpdate";
            this.IsUpdate.FalseValue = "0";
            this.IsUpdate.HeaderText = "IsUpdate";
            this.IsUpdate.Name = "IsUpdate";
            this.IsUpdate.TrueValue = "1";
            // 
            // frmReceiptNotDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 506);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmReceiptNotDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receipt Not Display";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptNotDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvReceiptNotDisplay;
        private System.Windows.Forms.Button btnUpdateSelected;
        private System.Windows.Forms.Button btnUpdateAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receipt_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receipt_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receipt_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bank_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Branch_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Flate_ShopNo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsUpdate;
    }
}