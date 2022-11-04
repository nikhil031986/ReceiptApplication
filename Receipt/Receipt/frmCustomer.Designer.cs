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
            this.tblMainCustomerDetails = new System.Windows.Forms.TableLayoutPanel();
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtCustomerWingName = new System.Windows.Forms.TextBox();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.cmbFlatNo = new System.Windows.Forms.ComboBox();
            this.lblCustomerWingName = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblWingName = new System.Windows.Forms.Label();
            this.lblEmailID = new System.Windows.Forms.Label();
            this.lblContactNo = new System.Windows.Forms.Label();
            this.lblFlatNo = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.cmbWingName = new System.Windows.Forms.ComboBox();
            this.txtEmailId = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.tblMainCustomerDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomer)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblMainCustomerDetails
            // 
            this.tblMainCustomerDetails.AutoSize = true;
            this.tblMainCustomerDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblMainCustomerDetails.ColumnCount = 1;
            this.tblMainCustomerDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMainCustomerDetails.Controls.Add(this.dgCustomer, 0, 1);
            this.tblMainCustomerDetails.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tblMainCustomerDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMainCustomerDetails.Location = new System.Drawing.Point(0, 0);
            this.tblMainCustomerDetails.Name = "tblMainCustomerDetails";
            this.tblMainCustomerDetails.RowCount = 2;
            this.tblMainCustomerDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMainCustomerDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMainCustomerDetails.Size = new System.Drawing.Size(1050, 624);
            this.tblMainCustomerDetails.TabIndex = 0;
            // 
            // dgCustomer
            // 
            this.dgCustomer.AllowUserToAddRows = false;
            this.dgCustomer.AllowUserToDeleteRows = false;
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
            this.Customer_Wing_Name});
            this.dgCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCustomer.Location = new System.Drawing.Point(3, 186);
            this.dgCustomer.Name = "dgCustomer";
            this.dgCustomer.ReadOnly = true;
            this.dgCustomer.Size = new System.Drawing.Size(1044, 435);
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
            this.Customer_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Customer_Name.DataPropertyName = "Customer_Name";
            this.Customer_Name.HeaderText = "Customer Name";
            this.Customer_Name.Name = "Customer_Name";
            this.Customer_Name.ReadOnly = true;
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
            this.Address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
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
            this.tableLayoutPanel2.Controls.Add(this.txtCustomerWingName, 4, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtContactNo, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtAddress, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtCustomerName, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.cmbFlatNo, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblCustomerWingName, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblAddress, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblWingName, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblEmailID, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblContactNo, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblFlatNo, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblCustomerName, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.cmbWingName, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtEmailId, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 3, 5);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1044, 177);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // txtCustomerWingName
            // 
            this.txtCustomerWingName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomerWingName.Location = new System.Drawing.Point(637, 119);
            this.txtCustomerWingName.Name = "txtCustomerWingName";
            this.txtCustomerWingName.Size = new System.Drawing.Size(404, 20);
            this.txtCustomerWingName.TabIndex = 14;
            // 
            // txtContactNo
            // 
            this.txtContactNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContactNo.Location = new System.Drawing.Point(91, 93);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(404, 20);
            this.txtContactNo.TabIndex = 10;
            // 
            // txtAddress
            // 
            this.txtAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAddress.Location = new System.Drawing.Point(637, 66);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.tableLayoutPanel2.SetRowSpan(this.txtAddress, 2);
            this.txtAddress.Size = new System.Drawing.Size(404, 47);
            this.txtAddress.TabIndex = 8;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomerName.Location = new System.Drawing.Point(91, 39);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(404, 20);
            this.txtCustomerName.TabIndex = 2;
            this.txtCustomerName.TextChanged += new System.EventHandler(this.txtCustomerName_TextChanged);
            // 
            // cmbFlatNo
            // 
            this.cmbFlatNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFlatNo.FormattingEnabled = true;
            this.cmbFlatNo.Location = new System.Drawing.Point(91, 66);
            this.cmbFlatNo.Name = "cmbFlatNo";
            this.cmbFlatNo.Size = new System.Drawing.Size(404, 21);
            this.cmbFlatNo.TabIndex = 6;
            this.cmbFlatNo.SelectedIndexChanged += new System.EventHandler(this.cmbFlatNo_SelectedIndexChanged);
            // 
            // lblCustomerWingName
            // 
            this.lblCustomerWingName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCustomerWingName.AutoSize = true;
            this.lblCustomerWingName.Location = new System.Drawing.Point(521, 122);
            this.lblCustomerWingName.Name = "lblCustomerWingName";
            this.lblCustomerWingName.Size = new System.Drawing.Size(110, 13);
            this.lblCustomerWingName.TabIndex = 13;
            this.lblCustomerWingName.Text = "Customer Wing Name";
            // 
            // lblAddress
            // 
            this.lblAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(521, 70);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(110, 13);
            this.lblAddress.TabIndex = 7;
            this.lblAddress.Text = "Address";
            // 
            // lblWingName
            // 
            this.lblWingName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWingName.AutoSize = true;
            this.lblWingName.Location = new System.Drawing.Point(521, 43);
            this.lblWingName.Name = "lblWingName";
            this.lblWingName.Size = new System.Drawing.Size(110, 13);
            this.lblWingName.TabIndex = 3;
            this.lblWingName.Text = "Wing Name";
            // 
            // lblEmailID
            // 
            this.lblEmailID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmailID.AutoSize = true;
            this.lblEmailID.Location = new System.Drawing.Point(3, 122);
            this.lblEmailID.Name = "lblEmailID";
            this.lblEmailID.Size = new System.Drawing.Size(82, 13);
            this.lblEmailID.TabIndex = 11;
            this.lblEmailID.Text = "Email Id";
            // 
            // lblContactNo
            // 
            this.lblContactNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContactNo.AutoSize = true;
            this.lblContactNo.Location = new System.Drawing.Point(3, 96);
            this.lblContactNo.Name = "lblContactNo";
            this.lblContactNo.Size = new System.Drawing.Size(82, 13);
            this.lblContactNo.TabIndex = 9;
            this.lblContactNo.Text = "Contact No";
            // 
            // lblFlatNo
            // 
            this.lblFlatNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFlatNo.AutoSize = true;
            this.lblFlatNo.Location = new System.Drawing.Point(3, 70);
            this.lblFlatNo.Name = "lblFlatNo";
            this.lblFlatNo.Size = new System.Drawing.Size(82, 13);
            this.lblFlatNo.TabIndex = 5;
            this.lblFlatNo.Text = "Flat No";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(3, 43);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(82, 13);
            this.lblCustomerName.TabIndex = 1;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // cmbWingName
            // 
            this.cmbWingName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbWingName.FormattingEnabled = true;
            this.cmbWingName.Location = new System.Drawing.Point(637, 39);
            this.cmbWingName.Name = "cmbWingName";
            this.cmbWingName.Size = new System.Drawing.Size(404, 21);
            this.cmbWingName.TabIndex = 4;
            this.cmbWingName.SelectedIndexChanged += new System.EventHandler(this.cmbWingName_SelectedIndexChanged);
            // 
            // txtEmailId
            // 
            this.txtEmailId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmailId.Location = new System.Drawing.Point(91, 119);
            this.txtEmailId.Name = "txtEmailId";
            this.txtEmailId.Size = new System.Drawing.Size(404, 20);
            this.txtEmailId.TabIndex = 12;
            this.txtEmailId.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmailId_Validating);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(879, 145);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(162, 29);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(84, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel1, 5);
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnClose, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCustomer, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1038, 30);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Location = new System.Drawing.Point(1001, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(34, 24);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblCustomer
            // 
            this.lblCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(3, 5);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(992, 20);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "Customer Details";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 624);
            this.Controls.Add(this.tblMainCustomerDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomer";
            this.Text = "frmCustomer";
            this.tblMainCustomerDetails.ResumeLayout(false);
            this.tblMainCustomerDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomer)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblMainCustomerDetails;
        private System.Windows.Forms.DataGridView dgCustomer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtCustomerWingName;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.ComboBox cmbFlatNo;
        private System.Windows.Forms.Label lblCustomerWingName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblWingName;
        private System.Windows.Forms.Label lblEmailID;
        private System.Windows.Forms.Label lblContactNo;
        private System.Windows.Forms.Label lblFlatNo;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cmbWingName;
        private System.Windows.Forms.TextBox txtEmailId;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnClose;
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
    }
}