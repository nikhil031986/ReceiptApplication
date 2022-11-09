namespace Receipt
{
    partial class frmBanakhat
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
            this.lblBANAKHATPRINT = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.btnprintprivew = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.wbHtmlView = new System.Windows.Forms.WebBrowser();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.lblBANAKHATPRINT, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbCustomer, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnPrint, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnprintprivew, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.wbHtmlView, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(924, 629);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblBANAKHATPRINT
            // 
            this.lblBANAKHATPRINT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBANAKHATPRINT.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblBANAKHATPRINT, 3);
            this.lblBANAKHATPRINT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBANAKHATPRINT.Location = new System.Drawing.Point(3, 0);
            this.lblBANAKHATPRINT.Name = "lblBANAKHATPRINT";
            this.lblBANAKHATPRINT.Size = new System.Drawing.Size(918, 18);
            this.lblBANAKHATPRINT.TabIndex = 0;
            this.lblBANAKHATPRINT.Text = "BANAKHAT PRINT";
            this.lblBANAKHATPRINT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(121, 22);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(683, 21);
            this.cmbCustomer.TabIndex = 1;
            // 
            // btnprintprivew
            // 
            this.btnprintprivew.Location = new System.Drawing.Point(810, 21);
            this.btnprintprivew.Name = "btnprintprivew";
            this.btnprintprivew.Size = new System.Drawing.Size(111, 23);
            this.btnprintprivew.TabIndex = 2;
            this.btnprintprivew.Text = "PRINT PRIVEW";
            this.btnprintprivew.UseVisualStyleBackColor = true;
            this.btnprintprivew.Click += new System.EventHandler(this.btnprintprivew_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(839, 603);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "SELECT CUSTOMER";
            // 
            // wbHtmlView
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.wbHtmlView, 3);
            this.wbHtmlView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbHtmlView.Location = new System.Drawing.Point(3, 50);
            this.wbHtmlView.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbHtmlView.Name = "wbHtmlView";
            this.wbHtmlView.Size = new System.Drawing.Size(918, 547);
            this.wbHtmlView.TabIndex = 5;
            // 
            // frmBanakhat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 629);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBanakhat";
            this.Text = "frmBanakhat";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblBANAKHATPRINT;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnprintprivew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.WebBrowser wbHtmlView;
    }
}