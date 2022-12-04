using ReceiptBAccess;
using ReceiptEntity;
using ReceiptLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Receipt
{
    public partial class frmReceiptList : Form
    {
        private DataTable dtReceiptDetails;
        public event EventHandler CloseUserDetails;
        public frmReceiptList()
        {
            try
            {
                InitializeComponent();
                FillTableRecords();
                new System.Threading.Thread(() => FillGridReceiptList(0)).Start();
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
        private async Task FillGridReceiptList(int ReceiptId = 0)
        {
            try
            {
                var receiptDetails = await BAReceiptDetails.GetReceiptDetails(ReceiptId);
                receiptDetails.ForEach(receipt =>
                {
                    if (dtReceiptDetails.AsEnumerable().Any(x => x.Field<int>("Receipt_Id") == receipt.Receipt_Id))
                    {
                        dtReceiptDetails.AsEnumerable().Where<DataRow>(x => x.Field<int>("Receipt_Id") == receipt.Receipt_Id).ToList().ForEach(dr =>
                        {
                            dr["Receipt_Id"] = receipt.Receipt_Id;
                            dr["Receipt_No"] = receipt.Receipt_No;
                            dr["Receipt_Date"] = receipt.Receipt_Date;
                            dr["Customer_Id"] = receipt.Customer_Id;
                            dr["Customer_Name"] = receipt.Customer_Name;
                            dr["Flate_ShopNo"] = receipt.Flate_ShopNo;
                            dr["Cheq_Rtgs_Neft_ImpsNo"] = receipt.Cheq_Rtgs_Neft_ImpsNo;
                            dr["Year_Id"] = receipt.Year_Id;
                            dr["Bank_Name"] = receipt.Bank_Name;
                            dr["Branch_Name"] = receipt.Branch_Name;
                            dr["ReceivedAs"] = receipt.ReceivedAs;
                            dr["Amount"] = receipt.Amount;
                            dr["Amount_Word"] = receipt.Amount_Word;
                            dr["Payment_Date"] = receipt.PaymentDate;
                        });
                        dtReceiptDetails.AcceptChanges();
                    }
                    else
                    {
                        DataRow drNew = dtReceiptDetails.NewRow();
                        drNew["Receipt_Id"] = receipt.Receipt_Id;
                        drNew["Receipt_No"] = receipt.Receipt_No;
                        drNew["Receipt_Date"] = receipt.Receipt_Date;
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
                        drNew["Payment_Date"] = receipt.PaymentDate;
                        dtReceiptDetails.Rows.Add(drNew);
                    }
                });

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
                await ClsUtil.AddColumn(dtReceiptDetails, clsColumns);
                dgvReceiptList.DataSource = dtReceiptDetails;
                dtReceiptDetails.TableName = "ReceipList";
                cmbColumnName.Items.Clear();
                foreach (DataColumn column in dtReceiptDetails.Columns)
                {
                    if (!column.ColumnName.ToLower().Contains("id"))
                        cmbColumnName.Items.Add(column.ColumnName);
                }
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
        private async Task OpenReceiptEntryForm(int receipt_Id = 0)
        {
            try
            {
                frmReceiptEntry _frmReceiptEntry;
                if (receipt_Id == 0)
                {
                    _frmReceiptEntry = new frmReceiptEntry();
                }
                else
                {
                    _frmReceiptEntry = new frmReceiptEntry(receipt_Id);
                }
                _frmReceiptEntry.ShowDialog();
                if (_frmReceiptEntry.Receipt_ID > 0)
                    await FillGridReceiptList(_frmReceiptEntry.Receipt_ID);
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                await OpenReceiptEntryForm(0);
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

                var receiptId = dgvReceiptList.SelectedRows[0].Cells[0].Value;
                await OpenReceiptEntryForm(Convert.ToInt32(receiptId));
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    dtReceiptDetails.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", cmbColumnName.Text, txtSearch.Text);
                }
                else
                {
                    dtReceiptDetails.DefaultView.RowFilter = String.Empty;
                }
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ClsUtil.ExportDataToExcel(dgvReceiptList);
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
    }
}