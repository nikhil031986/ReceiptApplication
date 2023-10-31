using Microsoft.Reporting.WinForms;
using ReceiptBAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Receipt
{
    public partial class frmMSReport : Form
    {
        public frmMSReport()
        {
            InitializeComponent();
        }

        private void frmMSReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            getData();
        }

        private async void getData()
        {
            DataTable dsCustomers = await BAReceiptDetails.GetReceiptDetails();
            var param1 = new ReportParameter("CustomerId", "0");
            ReportDataSource datasource = new ReportDataSource("ReceiptDetails", dsCustomers);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.SetParameters(new[] { param1 });
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            this.reportViewer1.RefreshReport();
        }
    }
}
