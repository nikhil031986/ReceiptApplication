using ReceiptBAccess;
using ReceiptLog;
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
    public partial class frmdashboard : Form
    {
        public frmdashboard()
        {
            InitializeComponent();
            FillChartData();
        }
        private async void FillChartData()
        {
            try
            {
                var dtChart = await BACustomerMaster.GetCurrentSales();
                chtCurrentSales.DataSource = dtChart;
                chtCurrentSales.Series["Wing_Name"].XValueMember = "Wing_Name";
                chtCurrentSales.Series["Wing_Name"].YValueMembers = "TotalSales";
                chtCurrentSales.Titles.Add("Total sales Chart");

                var panding = await BACustomerMaster.GetCurrentPendingSales();
                chTotalPending.DataSource = panding;
                chTotalPending.Series["Wing_Name"].XValueMember = "Wing_Name";
                chTotalPending.Series["Wing_Name"].YValueMembers = "TotalPending";
                chTotalPending.Titles.Add("Total Panding sales Chart");


                var monthWise = await BACustomerMaster.GetMonthWiseSalesAmount();
                chAmountmonthwise.DataSource = monthWise;
                chAmountmonthwise.Series["year"].XValueMember = "year";
                chAmountmonthwise.Series["year"].YValueMembers = "TotalAmount";
                chAmountmonthwise.Titles.Add("Total year wise sales Chart");
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, "frmdashboard");
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                frmMSReport frm = new frmMSReport();
                frm.Show();

            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, "frmdashboard");
            }
        }
    }
}
