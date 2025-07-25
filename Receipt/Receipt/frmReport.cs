using ReceiptBAccess;
using ReceiptLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Receipt
{
    public partial class frmReport : Form
    {
        private DataTable dtReceiptDetails;
        public event EventHandler CloseUserDetails;
        public frmReport()
        {
            try
            {

                InitializeComponent();
                FillTableRecords();
                ReportWiseDisplayControll();
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
        private async Task FillTableRecords()
        {
            try
            {
                dtReceiptDetails = new DataTable();
                List<clsColumn> clsColumns = new List<clsColumn>();
                clsColumns.Add(new clsColumn("Receipt_Id", ClsUtil.ColumnType.dbLong, "0"));
                clsColumns.Add(new clsColumn("Receipt_No", ClsUtil.ColumnType.dbString, ""));
                clsColumns.Add(new clsColumn("Receipt_Date", ClsUtil.ColumnType.dbString, ""));
                clsColumns.Add(new clsColumn("Customer_Id", ClsUtil.ColumnType.dbInt, "0"));
                clsColumns.Add(new clsColumn("Customer_Name", ClsUtil.ColumnType.dbString, ""));
                clsColumns.Add(new clsColumn("Flate_ShopNo", ClsUtil.ColumnType.dbString, ""));
                clsColumns.Add(new clsColumn("Cheq_Rtgs_Neft_ImpsNo", ClsUtil.ColumnType.dbString, ""));
                clsColumns.Add(new clsColumn("Year_Id", ClsUtil.ColumnType.dbInt, "0"));
                clsColumns.Add(new clsColumn("Bank_Name", ClsUtil.ColumnType.dbString, ""));
                clsColumns.Add(new clsColumn("Branch_Name", ClsUtil.ColumnType.dbString, ""));
                clsColumns.Add(new clsColumn("ReceivedAs", ClsUtil.ColumnType.dbString, ""));
                clsColumns.Add(new clsColumn("Amount", ClsUtil.ColumnType.dbDecimal, "0.0"));
                clsColumns.Add(new clsColumn("Amount_Word", ClsUtil.ColumnType.dbString, ""));
                clsColumns.Add(new clsColumn("Payment_Date", ClsUtil.ColumnType.dbString, ""));
                clsColumns.Add(new clsColumn("IsCancel", ClsUtil.ColumnType.dbInt, "0"));
                await ClsUtil.AddColumn(dtReceiptDetails, clsColumns);
                dgvReport.DataSource = dtReceiptDetails;
                dtReceiptDetails.TableName = "ReceipList";
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkReportForAll.Checked == false)
                {
                    dtReceiptDetails.Rows.Clear();
                    int fromDate = Convert.ToInt32(dtpFromDate.Value.ToString("yyyyMMdd"));
                    int ToDate = Convert.ToInt32(dtpToDate.Value.ToString("yyyyMMdd"));
                    dtReceiptDetails.AcceptChanges();
                    var receiptDetails = await BAReceiptDetails.GetReceiptDetailsFromDateToDate(fromDate, ToDate);
                    receiptDetails.ForEach(receipt =>
                    {
                        DataRow drNew = dtReceiptDetails.NewRow();
                        drNew["Receipt_Id"] = receipt.Receipt_Id;
                        drNew["Receipt_No"] = receipt.Receipt_No;
                        drNew["Receipt_Date"] = ClsUtil.getDateFormate(receipt.Receipt_Date);
                        drNew["Customer_Id"] = receipt.Customer_Id;
                        drNew["Customer_Name"] = receipt.Customer_Name;
                        drNew["Flate_ShopNo"] = receipt.Flate_ShopNo;
                        drNew["Cheq_Rtgs_Neft_ImpsNo"] = receipt.Cheq_Rtgs_Neft_ImpsNo;
                        drNew["Year_Id"] = receipt.Year_Id;
                        drNew["Bank_Name"] = receipt.Bank_Name;
                        drNew["Branch_Name"] = receipt.Branch_Name;
                        drNew["ReceivedAs"] = receipt.ReceivedAs;
                        drNew["Amount"] = receipt.Amount;
                        drNew["Amount_Word"] = receipt.Amount_Word;
                        drNew["Payment_Date"] = ClsUtil.getDateFormate(receipt.PaymentDate);
                        drNew["IsCancel"] = receipt.IsCancel;
                        dtReceiptDetails.Rows.Add(drNew);
                    });
                }
                else
                {
                    DataTable dtForReportAll = await BaWingMaster.GetAllWingWithCustomer();
                    dgvAllWingReports.DataSource = dtForReportAll;
                }
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private void exportDataToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkReportForAll.Checked)
                {
                    ClsUtil.ExportDataToExcel(dgvAllWingReports);
                }
                else
                {
                    ClsUtil.ExportDataToExcel(dgvReport);
                }
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private void ReportWiseDisplayControll()
        {
            try
            {
                dtpFromDate.Enabled = !chkReportForAll.Checked;
                dtpToDate.Enabled = !chkReportForAll.Checked;
                plnReportOne.Visible = !chkReportForAll.Checked;
                plnReportTwo.Visible = chkReportForAll.Checked;
                if (chkReportForAll.Checked)
                {
                    tableLayoutPanel1.RowStyles[2].SizeType = SizeType.Absolute;
                    tableLayoutPanel1.RowStyles[2].Height = 0;
                    tableLayoutPanel1.RowStyles[3].SizeType = SizeType.Percent;
                    tableLayoutPanel1.RowStyles[3].Height = 100;
                }
                else
                {
                    tableLayoutPanel1.RowStyles[3].SizeType = SizeType.Absolute;
                    tableLayoutPanel1.RowStyles[3].Height = 0;
                    tableLayoutPanel1.RowStyles[2].SizeType = SizeType.Percent;
                    tableLayoutPanel1.RowStyles[2].Height = 100;
                }
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.Message, clsLog.logType.Error, "frmReport.ReportWiseDisplayControll");
            }
        }

        private void chkReportForAll_CheckedChanged(object sender, EventArgs e)
        {
            ReportWiseDisplayControll();
        }
    }
}