namespace Receipt
{
    partial class frmRecipt
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
            this.plnMenuItem = new System.Windows.Forms.Panel();
            this.tblMenuItem = new System.Windows.Forms.TableLayoutPanel();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnUserDetails = new System.Windows.Forms.Button();
            this.btnWingDetails = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnReceiptDetails = new System.Windows.Forms.Button();
            this.btnChqDetails = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.PlnMainForm = new System.Windows.Forms.Panel();
            this.btnBanakhat = new System.Windows.Forms.Button();
            this.plnMenuItem.SuspendLayout();
            this.tblMenuItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // plnMenuItem
            // 
            this.plnMenuItem.Controls.Add(this.tblMenuItem);
            this.plnMenuItem.Dock = System.Windows.Forms.DockStyle.Left;
            this.plnMenuItem.Location = new System.Drawing.Point(0, 0);
            this.plnMenuItem.Name = "plnMenuItem";
            this.plnMenuItem.Size = new System.Drawing.Size(192, 521);
            this.plnMenuItem.TabIndex = 0;
            // 
            // tblMenuItem
            // 
            this.tblMenuItem.AutoSize = true;
            this.tblMenuItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblMenuItem.ColumnCount = 1;
            this.tblMenuItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMenuItem.Controls.Add(this.btnBanakhat, 0, 8);
            this.tblMenuItem.Controls.Add(this.btnImport, 0, 6);
            this.tblMenuItem.Controls.Add(this.btnUserDetails, 0, 0);
            this.tblMenuItem.Controls.Add(this.btnWingDetails, 0, 1);
            this.tblMenuItem.Controls.Add(this.btnCustomer, 0, 3);
            this.tblMenuItem.Controls.Add(this.btnReceiptDetails, 0, 4);
            this.tblMenuItem.Controls.Add(this.btnChqDetails, 0, 5);
            this.tblMenuItem.Controls.Add(this.btnReport, 0, 6);
            this.tblMenuItem.Controls.Add(this.btnLogout, 0, 9);
            this.tblMenuItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMenuItem.Location = new System.Drawing.Point(0, 0);
            this.tblMenuItem.Name = "tblMenuItem";
            this.tblMenuItem.RowCount = 10;
            this.tblMenuItem.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMenuItem.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMenuItem.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMenuItem.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMenuItem.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMenuItem.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMenuItem.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMenuItem.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMenuItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tblMenuItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tblMenuItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMenuItem.Size = new System.Drawing.Size(192, 521);
            this.tblMenuItem.TabIndex = 0;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Location = new System.Drawing.Point(3, 283);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(186, 50);
            this.btnImport.TabIndex = 7;
            this.btnImport.Text = "Import Data <";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnUserDetails
            // 
            this.btnUserDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUserDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserDetails.Location = new System.Drawing.Point(3, 3);
            this.btnUserDetails.Name = "btnUserDetails";
            this.btnUserDetails.Size = new System.Drawing.Size(186, 50);
            this.btnUserDetails.TabIndex = 0;
            this.btnUserDetails.Text = "User Details < ";
            this.btnUserDetails.UseVisualStyleBackColor = true;
            this.btnUserDetails.Click += new System.EventHandler(this.btnUserDetails_Click);
            // 
            // btnWingDetails
            // 
            this.btnWingDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWingDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWingDetails.Location = new System.Drawing.Point(3, 59);
            this.btnWingDetails.Name = "btnWingDetails";
            this.btnWingDetails.Size = new System.Drawing.Size(186, 50);
            this.btnWingDetails.TabIndex = 1;
            this.btnWingDetails.Text = "wing Details <";
            this.btnWingDetails.UseVisualStyleBackColor = true;
            this.btnWingDetails.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.Location = new System.Drawing.Point(3, 115);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(186, 50);
            this.btnCustomer.TabIndex = 2;
            this.btnCustomer.Text = "Customer Details <";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnReceiptDetails
            // 
            this.btnReceiptDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReceiptDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceiptDetails.Location = new System.Drawing.Point(3, 171);
            this.btnReceiptDetails.Name = "btnReceiptDetails";
            this.btnReceiptDetails.Size = new System.Drawing.Size(186, 50);
            this.btnReceiptDetails.TabIndex = 3;
            this.btnReceiptDetails.Text = "Receipt Details <";
            this.btnReceiptDetails.UseVisualStyleBackColor = true;
            this.btnReceiptDetails.Click += new System.EventHandler(this.btnReceiptDetails_Click);
            // 
            // btnChqDetails
            // 
            this.btnChqDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChqDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChqDetails.Location = new System.Drawing.Point(3, 227);
            this.btnChqDetails.Name = "btnChqDetails";
            this.btnChqDetails.Size = new System.Drawing.Size(186, 50);
            this.btnChqDetails.TabIndex = 4;
            this.btnChqDetails.Text = "Cheq Details <";
            this.btnChqDetails.UseVisualStyleBackColor = true;
            this.btnChqDetails.Click += new System.EventHandler(this.btnChqDetails_Click);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Location = new System.Drawing.Point(3, 339);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(186, 50);
            this.btnReport.TabIndex = 5;
            this.btnReport.Text = "Report <";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Location = new System.Drawing.Point(3, 473);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(186, 45);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // PlnMainForm
            // 
            this.PlnMainForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlnMainForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlnMainForm.Location = new System.Drawing.Point(192, 0);
            this.PlnMainForm.Name = "PlnMainForm";
            this.PlnMainForm.Size = new System.Drawing.Size(608, 521);
            this.PlnMainForm.TabIndex = 1;
            // 
            // btnBanakhat
            // 
            this.btnBanakhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBanakhat.Location = new System.Drawing.Point(3, 395);
            this.btnBanakhat.Name = "btnBanakhat";
            this.btnBanakhat.Size = new System.Drawing.Size(186, 50);
            this.btnBanakhat.TabIndex = 0;
            this.btnBanakhat.Text = "BANAKHAT >";
            this.btnBanakhat.UseVisualStyleBackColor = true;
            this.btnBanakhat.Click += new System.EventHandler(this.btnBanakhat_Click);
            // 
            // frmRecipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 521);
            this.Controls.Add(this.PlnMainForm);
            this.Controls.Add(this.plnMenuItem);
            this.Name = "frmRecipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recipt Application";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.plnMenuItem.ResumeLayout(false);
            this.plnMenuItem.PerformLayout();
            this.tblMenuItem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plnMenuItem;
        private System.Windows.Forms.TableLayoutPanel tblMenuItem;
        private System.Windows.Forms.Button btnUserDetails;
        private System.Windows.Forms.Panel PlnMainForm;
        private System.Windows.Forms.Button btnWingDetails;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnReceiptDetails;
        private System.Windows.Forms.Button btnChqDetails;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnBanakhat;
    }
}