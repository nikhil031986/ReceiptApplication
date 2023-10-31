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
            this.chlRePrintBANAKHAT = new System.Windows.Forms.CheckBox();
            this.btnprint = new System.Windows.Forms.Button();
            this.dgviewBanakhatDetails = new System.Windows.Forms.DataGrid();
            this.ctMnuGridSendToExcel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sendToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgviewBanakhatDetails)).BeginInit();
            this.ctMnuGridSendToExcel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblBanakhatList, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chlRePrintBANAKHAT, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnprint, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dgviewBanakhatDetails, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
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
            // chlRePrintBANAKHAT
            // 
            this.chlRePrintBANAKHAT.AutoSize = true;
            this.chlRePrintBANAKHAT.Location = new System.Drawing.Point(3, 21);
            this.chlRePrintBANAKHAT.Name = "chlRePrintBANAKHAT";
            this.chlRePrintBANAKHAT.Size = new System.Drawing.Size(148, 17);
            this.chlRePrintBANAKHAT.TabIndex = 3;
            this.chlRePrintBANAKHAT.Text = "Show Bankhat completed";
            this.chlRePrintBANAKHAT.UseVisualStyleBackColor = true;
            this.chlRePrintBANAKHAT.CheckedChanged += new System.EventHandler(this.chlRePrintBANAKHAT_CheckedChanged);
            // 
            // btnprint
            // 
            this.btnprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnprint.Location = new System.Drawing.Point(722, 477);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(75, 43);
            this.btnprint.TabIndex = 2;
            this.btnprint.Text = "print";
            this.btnprint.UseVisualStyleBackColor = true;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // dgviewBanakhatDetails
            // 
            this.dgviewBanakhatDetails.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;
            this.dgviewBanakhatDetails.BackColor = System.Drawing.Color.Gainsboro;
            this.dgviewBanakhatDetails.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgviewBanakhatDetails.CaptionBackColor = System.Drawing.Color.DarkKhaki;
            this.dgviewBanakhatDetails.CaptionFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgviewBanakhatDetails.CaptionForeColor = System.Drawing.Color.Black;
            this.dgviewBanakhatDetails.CaptionText = "Banakhat Pending List";
            this.dgviewBanakhatDetails.ContextMenuStrip = this.ctMnuGridSendToExcel;
            this.dgviewBanakhatDetails.DataMember = "";
            this.dgviewBanakhatDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgviewBanakhatDetails.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgviewBanakhatDetails.ForeColor = System.Drawing.Color.Black;
            this.dgviewBanakhatDetails.GridLineColor = System.Drawing.Color.Silver;
            this.dgviewBanakhatDetails.HeaderBackColor = System.Drawing.Color.Black;
            this.dgviewBanakhatDetails.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dgviewBanakhatDetails.HeaderForeColor = System.Drawing.Color.White;
            this.dgviewBanakhatDetails.LinkColor = System.Drawing.Color.DarkSlateBlue;
            this.dgviewBanakhatDetails.Location = new System.Drawing.Point(3, 44);
            this.dgviewBanakhatDetails.Name = "dgviewBanakhatDetails";
            this.dgviewBanakhatDetails.ParentRowsBackColor = System.Drawing.Color.LightGray;
            this.dgviewBanakhatDetails.ParentRowsForeColor = System.Drawing.Color.Black;
            this.dgviewBanakhatDetails.SelectionBackColor = System.Drawing.Color.Firebrick;
            this.dgviewBanakhatDetails.SelectionForeColor = System.Drawing.Color.White;
            this.dgviewBanakhatDetails.Size = new System.Drawing.Size(794, 427);
            this.dgviewBanakhatDetails.TabIndex = 4;
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
            ((System.ComponentModel.ISupportInitialize)(this.dgviewBanakhatDetails)).EndInit();
            this.ctMnuGridSendToExcel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblBanakhatList;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.ContextMenuStrip ctMnuGridSendToExcel;
        private System.Windows.Forms.ToolStripMenuItem sendToExcelToolStripMenuItem;
        private System.Windows.Forms.CheckBox chlRePrintBANAKHAT;
        private System.Windows.Forms.DataGrid dgviewBanakhatDetails;
    }
}