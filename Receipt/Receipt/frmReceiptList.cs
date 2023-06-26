using Microsoft.Office.Interop.Excel;
using ReceiptBAccess;
using ReceiptEntity;
using ReceiptLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Receipt
{
    public partial class frmReceiptList : Form
    {
        private System.Data.DataTable dtReceiptDetails;
        private int PageSize;
        private int PageIndex;
        private int PageCount;
        private int rowsCount;
        private int currentPage;
        public event EventHandler CloseUserDetails;
        public frmReceiptList()
        {
            try
            {
                InitializeComponent();
                this.Dock = DockStyle.Fill;
                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Left))
            {
                tolPrv_Click(null, null);
                return base.ProcessCmdKey(ref msg, keyData);
            }
            if (keyData == (Keys.Right))
            {
                tolNext_Click(null, null);
                return base.ProcessCmdKey(ref msg, keyData);
            }
            if (keyData == (Keys.Control | Keys.Left))
            {
                tolFirst_Click(null, null);
                return base.ProcessCmdKey(ref msg, keyData);
            }
            if (keyData == (Keys.Control | Keys.Right))
            {
                tolLast_Click(null, null);
                return base.ProcessCmdKey(ref msg, keyData);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private async Task FilterDetails()
        {
            try
            {

                dtReceiptDetails.Rows.Clear();
                dtReceiptDetails.AcceptChanges();
                string whereCond = "CAST(" + (cmbColumnName.Text.Contains("Customer") ? "CM." : "RD.") + cmbColumnName.Text + " AS TEXT) LIKE '" + txtSearch.Text + "%'";
                var receiptDetails = await BAReceiptDetails.GetReceiptByCond(whereCond);
                receiptDetails.ForEach(receipt =>
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
                    drNew["IsCancel"] = receipt.IsCancel;
                    drNew["IsPrint"] = receipt.IsPrint;
                    dtReceiptDetails.Rows.Add(drNew);
                });

                var totalAmount = dtReceiptDetails.AsEnumerable().Where<DataRow>(x => x.Field<int>("IsCancel") == 0).Sum(x => x.Field<decimal>("Amount"));
                tltTotalAMOUNT.Text = "Total Amount: " + Convert.ToString(totalAmount);
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
            }
        }

        private async Task FillGridReceiptList(int ReceiptId = 0)
        {
            try
            {
                if (ReceiptId == 0)
                {
                    dtReceiptDetails.Rows.Clear();
                    dtReceiptDetails.AcceptChanges();
                    var receiptDetails = await BAReceiptDetails.GetReciptPageing(PageSize, rowsCount);
                    receiptDetails.ForEach(receipt =>
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
                        drNew["IsCancel"] = receipt.IsCancel;
                        drNew["IsPrint"] = receipt.IsPrint;
                        dtReceiptDetails.Rows.Add(drNew);
                    });
                }
                else
                {
                    var receiptDetails = await BAReceiptDetails.GetReceiptDetails(ReceiptId);
                    receiptDetails.ForEach(receipt =>
                    {
                        if (dtReceiptDetails.AsEnumerable().Where<DataRow>(x => x.Field<int>("Receipt_Id") == receipt.Receipt_Id).Count() > 0)
                        {
                            var dr = dtReceiptDetails.AsEnumerable().Where<DataRow>(x => x.Field<int>("Receipt_Id") == receipt.Receipt_Id).FirstOrDefault();
                            if (dr != null)
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
                                dr["IsCancel"] = receipt.IsCancel;
                                dr["IsPrint"] = receipt.IsPrint;
                            }
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
                            drNew["IsCancel"] = receipt.IsCancel;
                            drNew["IsPrint"] = receipt.IsPrint;
                            dtReceiptDetails.Rows.Add(drNew);
                        }
                    });
                }

                var totalAmount = dtReceiptDetails.AsEnumerable().Where<DataRow>(x => x.Field<int>("IsCancel") == 0).Sum(x => x.Field<decimal>("Amount"));
                tltTotalAMOUNT.Text = "Total Amount: " + Convert.ToString(totalAmount);
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }

        }
        private async Task FillTableRecords()
        {
            try
            {
                dtReceiptDetails = new System.Data.DataTable();
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
                clsColumns.Add(new clsColumn("IsPrint", ClsUtil.ColumnType.dbInt, "0"));
                clsColumns.Add(new clsColumn("Print_Receipt", ClsUtil.ColumnType.dbString, "Print"));
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
        private async Task OpenReceiptEntryForm(int receipt_Id = 0, bool IsPrint = false)
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
                    _frmReceiptEntry = new frmReceiptEntry(receipt_Id, IsPrint);
                }
                if (IsPrint)
                {
                    _frmReceiptEntry.Show();
                    await _frmReceiptEntry.PrintDocument();
                    if(_frmReceiptEntry.Receipt_ID > 0)
                    {
                        await FillGridReceiptList(_frmReceiptEntry.Receipt_ID);
                    }
                }
                else
                {
                    _frmReceiptEntry.ShowDialog();
                    if (_frmReceiptEntry.Receipt_ID > 0)
                        await FillGridReceiptList(_frmReceiptEntry.Receipt_ID);
                }
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

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtSearch.Text) && !string.IsNullOrWhiteSpace(cmbColumnName.Text))
                {
                    //clsWaitForm.ShowWaitForm();
                    await FilterDetails();
                    //clsWaitForm.CloseWaitForm();
                }
                else
                {
                    if (dtReceiptDetails.Rows.Count == rowsCount) { return; }
                    //clsWaitForm.ShowWaitForm();
                    PageIndex = 1;
                    txttolDisplay.Text = PageIndex.ToString();
                    PageSize = 0;
                    await FillGridReceiptList(0);
                    //clsWaitForm.CloseWaitForm();
                }
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                clsWaitForm.ShowWaitForm();
                ClsUtil.ExportDataToExcel(dgvReceiptList);
                clsWaitForm.CloseWaitForm();
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private async void tolFirst_Click(object sender, EventArgs e)
        {
            try
            {
               // clsWaitForm.ShowWaitForm();
                PageIndex = 1;
                txttolDisplay.Text = PageIndex.ToString();
                PageSize = 0;
                currentPage = 0;
                await FillGridReceiptList(0);
                //clsWaitForm.CloseWaitForm();
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private async void tolPrv_Click(object sender, EventArgs e)
        {
            try
            {
                if (PageIndex <= 1 || PageSize == 0)
                {
                    return;
                }
                //clsWaitForm.ShowWaitForm();
                PageIndex = PageIndex - 1;
                currentPage = currentPage - 1;
                txttolDisplay.Text = PageIndex.ToString();
                PageSize = PageSize - rowsCount;
                await FillGridReceiptList(0);
                //clsWaitForm.CloseWaitForm();
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private async void tolNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (PageIndex >= PageCount)
                {
                    return;
                }
                //clsWaitForm.ShowWaitForm();
                PageIndex = PageIndex + 1;
                currentPage = currentPage + 1;
                txttolDisplay.Text = PageIndex.ToString();
                PageSize = currentPage + rowsCount;
                await FillGridReceiptList(0);
                //clsWaitForm.CloseWaitForm();
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private async void tolLast_Click(object sender, EventArgs e)
        {
            try
            {
                //clsWaitForm.ShowWaitForm();
                PageSize = (rowsCount * PageCount);
                PageIndex = PageCount;
                currentPage = PageCount;
                txttolDisplay.Text = PageIndex.ToString();
                await FillGridReceiptList(0);
                //clsWaitForm.CloseWaitForm();
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private async void txttolDisplay_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                int pageNumber = Convert.ToInt32(txttolDisplay.Text);
                PageSize = (rowsCount * pageNumber);
                PageIndex = PageCount;
                txttolDisplay.Text = pageNumber.ToString();
                await FillGridReceiptList(0);
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private async void txttolRowsCount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            rowsCount = Convert.ToInt32(txttolRowsCount.Text);
            var pag = BAReceiptDetails.GetPageCount(rowsCount);
            PageCount = Convert.ToInt32(pag.Result.ToString());
            PageIndex = 1;
            tolTotalPages.Text = " OF " + PageCount.ToString();
            txttolDisplay.Text = PageIndex.ToString();
            int pageNumber = Convert.ToInt32(txttolDisplay.Text);
            PageSize = (rowsCount * pageNumber);
            PageIndex = 1;
            txttolDisplay.Text = pageNumber.ToString();
            await FillGridReceiptList(0);
        }

        private async void dgvReceiptList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 16)
            {
                try
                {

                    var receiptId = dgvReceiptList[0, e.RowIndex].Value;
                    await OpenReceiptEntryForm(Convert.ToInt32(receiptId), true);
                }
                catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
            }
        }

        private async void frmReceiptList_Load(object sender, EventArgs e)
        {
            try
            {
                clsWaitForm.ShowWaitForm();
                PageSize = 0;
                rowsCount = 30;
                currentPage = 0;
                txttolRowsCount.Text = rowsCount.ToString();
                await FillTableRecords();
                var pag = BAReceiptDetails.GetPageCount(rowsCount);
                PageCount = Convert.ToInt32(pag.Result.ToString());
                PageIndex = PageCount;
                PageSize = PageIndex * rowsCount;
                tolTotalPages.Text = " OF " + PageCount.ToString();
                txttolDisplay.Text = PageIndex.ToString();
                await FillGridReceiptList(0);
                clsWaitForm.CloseWaitForm();
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private async void btnGoTo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtGotoPageNo.Text))
                {
                    int pageNumber = Convert.ToInt32(txtGotoPageNo.Text);
                    PageSize = (rowsCount * pageNumber);
                    PageIndex = PageCount;
                    txttolDisplay.Text = pageNumber.ToString();
                    await FillGridReceiptList(0);
                }
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private async void importFromExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = @"Upload File",
                Filter =
                    @"Spreadsheet (.xls ,.xlsx)|  *.xls ;*.xlsx",
                FilterIndex = 1,
                RestoreDirectory = true,
                Multiselect= false
            };
            if(openFileDialog.ShowDialog()== DialogResult.OK)
            {
                frmImportReceipt frmImportRece = new frmImportReceipt(openFileDialog.FileName);
                frmImportRece.ShowDialog();
                tolLast_Click(null, null);
            }
        }
    }
}