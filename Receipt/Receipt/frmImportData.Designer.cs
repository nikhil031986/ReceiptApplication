namespace Receipt
{
    partial class frmImportData
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
            this.lblImportModule = new System.Windows.Forms.Label();
            this.lblSelectFile = new System.Windows.Forms.Label();
            this.txtSelectedFile = new System.Windows.Forms.TextBox();
            this.lblSelectSheet = new System.Windows.Forms.Label();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.btnShowData = new System.Windows.Forms.Button();
            this.cmbSelectSheet = new System.Windows.Forms.ComboBox();
            this.btnImportData = new System.Windows.Forms.Button();
            this.dgvImportData = new System.Windows.Forms.DataGridView();
            this.lblTableName = new System.Windows.Forms.Label();
            this.cboTableName = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportData)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblImportModule, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblSelectFile, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSelectedFile, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblSelectSheet, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnSelectFile, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnShowData, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbSelectSheet, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dgvImportData, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnImportData, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblTableName, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cboTableName, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblImportModule
            // 
            this.lblImportModule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImportModule.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblImportModule, 3);
            this.lblImportModule.Location = new System.Drawing.Point(3, 0);
            this.lblImportModule.Name = "lblImportModule";
            this.lblImportModule.Size = new System.Drawing.Size(794, 13);
            this.lblImportModule.TabIndex = 0;
            this.lblImportModule.Text = "Import Module";
            this.lblImportModule.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSelectFile
            // 
            this.lblSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectFile.AutoSize = true;
            this.lblSelectFile.Location = new System.Drawing.Point(3, 21);
            this.lblSelectFile.Name = "lblSelectFile";
            this.lblSelectFile.Size = new System.Drawing.Size(68, 13);
            this.lblSelectFile.TabIndex = 1;
            this.lblSelectFile.Text = "SelectFile";
            // 
            // txtSelectedFile
            // 
            this.txtSelectedFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelectedFile.Location = new System.Drawing.Point(77, 17);
            this.txtSelectedFile.Name = "txtSelectedFile";
            this.txtSelectedFile.Size = new System.Drawing.Size(639, 20);
            this.txtSelectedFile.TabIndex = 2;
            // 
            // lblSelectSheet
            // 
            this.lblSelectSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectSheet.AutoSize = true;
            this.lblSelectSheet.Location = new System.Drawing.Point(3, 50);
            this.lblSelectSheet.Name = "lblSelectSheet";
            this.lblSelectSheet.Size = new System.Drawing.Size(68, 13);
            this.lblSelectSheet.TabIndex = 3;
            this.lblSelectSheet.Text = "Select Sheet";
            this.lblSelectSheet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(722, 16);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFile.TabIndex = 4;
            this.btnSelectFile.Text = "File Select";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // btnShowData
            // 
            this.btnShowData.Location = new System.Drawing.Point(722, 45);
            this.btnShowData.Name = "btnShowData";
            this.btnShowData.Size = new System.Drawing.Size(75, 23);
            this.btnShowData.TabIndex = 5;
            this.btnShowData.Text = "Show Data";
            this.btnShowData.UseVisualStyleBackColor = true;
            this.btnShowData.Click += new System.EventHandler(this.btnShowData_Click);
            // 
            // cmbSelectSheet
            // 
            this.cmbSelectSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSelectSheet.FormattingEnabled = true;
            this.cmbSelectSheet.Location = new System.Drawing.Point(77, 46);
            this.cmbSelectSheet.Name = "cmbSelectSheet";
            this.cmbSelectSheet.Size = new System.Drawing.Size(639, 21);
            this.cmbSelectSheet.TabIndex = 6;
            // 
            // btnImportData
            // 
            this.btnImportData.Location = new System.Drawing.Point(722, 424);
            this.btnImportData.Name = "btnImportData";
            this.btnImportData.Size = new System.Drawing.Size(75, 23);
            this.btnImportData.TabIndex = 7;
            this.btnImportData.Text = "Import";
            this.btnImportData.UseVisualStyleBackColor = true;
            this.btnImportData.Click += new System.EventHandler(this.btnImportData_Click);
            // 
            // dgvImportData
            // 
            this.dgvImportData.AllowUserToAddRows = false;
            this.dgvImportData.AllowUserToDeleteRows = false;
            this.dgvImportData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dgvImportData, 3);
            this.dgvImportData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvImportData.Location = new System.Drawing.Point(3, 101);
            this.dgvImportData.Name = "dgvImportData";
            this.dgvImportData.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.dgvImportData, 2);
            this.dgvImportData.Size = new System.Drawing.Size(794, 317);
            this.dgvImportData.TabIndex = 8;
            this.dgvImportData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvImportData_CellFormatting);
            this.dgvImportData.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvImportData_RowPrePaint);
            // 
            // lblTableName
            // 
            this.lblTableName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTableName.AutoSize = true;
            this.lblTableName.Location = new System.Drawing.Point(3, 78);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(68, 13);
            this.lblTableName.TabIndex = 9;
            this.lblTableName.Text = "Table Name";
            // 
            // cboTableName
            // 
            this.cboTableName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTableName.FormattingEnabled = true;
            this.cboTableName.Location = new System.Drawing.Point(77, 74);
            this.cboTableName.Name = "cboTableName";
            this.cboTableName.Size = new System.Drawing.Size(639, 21);
            this.cboTableName.TabIndex = 10;
            // 
            // frmImportData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmImportData";
            this.Text = "frmImportData";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblImportModule;
        private System.Windows.Forms.Label lblSelectFile;
        private System.Windows.Forms.TextBox txtSelectedFile;
        private System.Windows.Forms.Label lblSelectSheet;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Button btnShowData;
        private System.Windows.Forms.ComboBox cmbSelectSheet;
        private System.Windows.Forms.Button btnImportData;
        private System.Windows.Forms.DataGridView dgvImportData;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.ComboBox cboTableName;
    }
}