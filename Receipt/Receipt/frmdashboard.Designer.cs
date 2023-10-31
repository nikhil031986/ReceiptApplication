namespace Receipt
{
    partial class frmdashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chtCurrentSales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chTotalPending = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chAmountmonthwise = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lbldashboard = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chtCurrentSales)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chTotalPending)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chAmountmonthwise)).BeginInit();
            this.SuspendLayout();
            // 
            // chtCurrentSales
            // 
            this.chtCurrentSales.BorderlineColor = System.Drawing.Color.Black;
            this.chtCurrentSales.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chtCurrentSales.BorderlineWidth = 2;
            chartArea4.Name = "ChartArea1";
            this.chtCurrentSales.ChartAreas.Add(chartArea4);
            this.chtCurrentSales.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Name = "Legend1";
            this.chtCurrentSales.Legends.Add(legend4);
            this.chtCurrentSales.Location = new System.Drawing.Point(3, 38);
            this.chtCurrentSales.Name = "chtCurrentSales";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series4.Legend = "Legend1";
            series4.Name = "Wing_Name";
            this.chtCurrentSales.Series.Add(series4);
            this.chtCurrentSales.Size = new System.Drawing.Size(496, 180);
            this.chtCurrentSales.TabIndex = 0;
            this.chtCurrentSales.Text = "chart1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.chtCurrentSales, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chTotalPending, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.chAmountmonthwise, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbldashboard, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnReport, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // chTotalPending
            // 
            this.chTotalPending.BorderlineColor = System.Drawing.Color.Black;
            this.chTotalPending.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chTotalPending.BorderlineWidth = 2;
            chartArea5.Name = "ChartArea1";
            this.chTotalPending.ChartAreas.Add(chartArea5);
            this.tableLayoutPanel1.SetColumnSpan(this.chTotalPending, 2);
            this.chTotalPending.Dock = System.Windows.Forms.DockStyle.Fill;
            legend5.Name = "Legend1";
            this.chTotalPending.Legends.Add(legend5);
            this.chTotalPending.Location = new System.Drawing.Point(505, 38);
            this.chTotalPending.Name = "chTotalPending";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series5.Legend = "Legend1";
            series5.Name = "Wing_Name";
            this.chTotalPending.Series.Add(series5);
            this.chTotalPending.Size = new System.Drawing.Size(292, 180);
            this.chTotalPending.TabIndex = 1;
            this.chTotalPending.Text = "chart1";
            // 
            // chAmountmonthwise
            // 
            this.chAmountmonthwise.BorderlineColor = System.Drawing.Color.Black;
            this.chAmountmonthwise.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chAmountmonthwise.BorderlineWidth = 2;
            chartArea6.Name = "ChartArea1";
            this.chAmountmonthwise.ChartAreas.Add(chartArea6);
            this.tableLayoutPanel1.SetColumnSpan(this.chAmountmonthwise, 3);
            this.chAmountmonthwise.Dock = System.Windows.Forms.DockStyle.Fill;
            legend6.Name = "Legend1";
            this.chAmountmonthwise.Legends.Add(legend6);
            this.chAmountmonthwise.Location = new System.Drawing.Point(3, 224);
            this.chAmountmonthwise.Name = "chAmountmonthwise";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series6.Legend = "Legend1";
            series6.Name = "year";
            series6.YValuesPerPoint = 4;
            this.chAmountmonthwise.Series.Add(series6);
            this.chAmountmonthwise.Size = new System.Drawing.Size(794, 223);
            this.chAmountmonthwise.TabIndex = 2;
            this.chAmountmonthwise.Text = "chart1";
            // 
            // lbldashboard
            // 
            this.lbldashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbldashboard.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lbldashboard, 2);
            this.lbldashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldashboard.Location = new System.Drawing.Point(3, 7);
            this.lbldashboard.Name = "lbldashboard";
            this.lbldashboard.Size = new System.Drawing.Size(711, 20);
            this.lbldashboard.TabIndex = 3;
            this.lbldashboard.Text = "Dashboard";
            this.lbldashboard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(720, 3);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(76, 23);
            this.btnReport.TabIndex = 4;
            this.btnReport.Text = "ReportShow";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // frmdashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmdashboard";
            this.Text = "frmdashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.chtCurrentSales)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chTotalPending)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chAmountmonthwise)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chtCurrentSales;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chTotalPending;
        private System.Windows.Forms.DataVisualization.Charting.Chart chAmountmonthwise;
        private System.Windows.Forms.Label lbldashboard;
        private System.Windows.Forms.Button btnReport;
    }
}