using ReceiptBAccess;
using ReceiptLog;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Receipt
{
    public partial class frmCustomer : Form
    {
        public event EventHandler CloseUserDetails;
        private DataTable dtCustomer;
        private int PageSize;
        private int PageIndex;
        private int PageCount;
        private int rowsCount;
        private int crrrentPage;
        public int RowCount { get { return rowsCount; } set { value = rowsCount; } }
        public frmCustomer()
        {
            try
            {
                InitializeComponent();

                this.btnClose.Image = (Image)(new Bitmap(Receipt.Properties.Resources.Close, new Size(32, 25)));
                this.btnClose.ImageAlign = ContentAlignment.MiddleCenter;
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private async Task FilterDetails()
        {
            try
            {

                dtCustomer.Rows.Clear();
                dtCustomer.AcceptChanges();
                string appendTableName = "CM.";
                if (cboSearch.Text.ToUpper().Contains("WING"))
                {
                    appendTableName = "WM.";
                }
                if (cboSearch.Text.ToUpper().Contains("FLAT"))
                {
                    appendTableName = "WD.";
                }
                string whereCond = "CAST (" + appendTableName + cboSearch.Text + " AS TEXT) " + " LIKE '" + txtSearch.Text + "%'";
                var receiptDetails = await BACustomerMaster.GetCustomerByCond(whereCond);
                receiptDetails.ForEach(customer =>
                {
                    DataRow drNew = dtCustomer.NewRow();
                    drNew["Customer_Id"] = customer.Customer_Id;
                    drNew["Wing_Master_Id"] = customer.Wing_Master_Id;
                    drNew["Wing_Details_Id"] = customer.Wing_Details_Id;
                    drNew["Wing_Name"] = customer.Wing_Name;
                    drNew["FlatNo"] = customer.FlatNo;
                    drNew["Customer_Name"] = customer.Customer_Name;
                    drNew["Address"] = customer.Address;
                    drNew["Con_Details"] = customer.Con_Details;
                    drNew["Email_Id"] = customer.Email_Id;
                    drNew["Customer_Wing_Name"] = customer.Customer_Wing_Name;
                    drNew["Pan"] = customer.Pan;
                    drNew["Aadhar"] = customer.Aadhar;
                    drNew["Customer1"] = customer.Customer1;
                    drNew["Pan1"] = customer.Pan1;
                    drNew["Aadhar1"] = customer.Aadhar1;
                    drNew["Customer2"] = customer.Customer2;
                    drNew["Pan2"] = customer.Pan2;
                    drNew["Aadhar2"] = customer.Aadhar2;
                    drNew["Customer3"] = customer.Customer3;
                    drNew["Pan3"] = customer.Pan3;
                    drNew["Aadhar3"] = customer.Aadhar3;
                    drNew["BanakhatNo"] = customer.BanakhatNo;
                    drNew["BanakhatDate"] = ClsUtil.getDateFormate(customer.BanakhatDate);
                    drNew["Dastavej_No"] = customer.Dastavg_No;
                    drNew["Dastavej_Date"] = ClsUtil.getDateFormate(customer.Dastavg_Date);
                    drNew["Dastavej_Amount"] = customer.Dastavej_Amount;
                    dtCustomer.Rows.Add(drNew);
                });

            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
            }
        }
        private async void GetCustomerDetails()
        {
            try
            {
                dtCustomer.Rows.Clear();
                dtCustomer.AcceptChanges();
                var customerDetails = await BACustomerMaster.GetCustomerPageing(PageSize, this.rowsCount);
                customerDetails.ForEach(customer =>
                {
                    DataRow drNew = dtCustomer.NewRow();
                    drNew["Customer_Id"] = customer.Customer_Id;
                    drNew["Wing_Master_Id"] = customer.Wing_Master_Id;
                    drNew["Wing_Details_Id"] = customer.Wing_Details_Id;
                    drNew["Wing_Name"] = customer.Wing_Name;
                    drNew["FlatNo"] = customer.FlatNo;
                    drNew["Customer_Name"] = customer.Customer_Name;
                    drNew["Address"] = customer.Address;
                    drNew["Con_Details"] = customer.Con_Details;
                    drNew["Email_Id"] = customer.Email_Id;
                    drNew["Customer_Wing_Name"] = customer.Customer_Wing_Name;
                    drNew["Pan"] = customer.Pan;
                    drNew["Aadhar"] = customer.Aadhar;
                    drNew["Customer1"] = customer.Customer1;
                    drNew["Pan1"] = customer.Pan1;
                    drNew["Aadhar1"] = customer.Aadhar1;
                    drNew["Customer2"] = customer.Customer2;
                    drNew["Pan2"] = customer.Pan2;
                    drNew["Aadhar2"] = customer.Aadhar2;
                    drNew["Customer3"] = customer.Customer3;
                    drNew["Pan3"] = customer.Pan3;
                    drNew["Aadhar3"] = customer.Aadhar3;
                    drNew["BanakhatNo"] = customer.BanakhatNo;
                    drNew["BanakhatDate"] = customer.BanakhatDate;
                    drNew["Dastavej_No"] = customer.Dastavg_No;
                    drNew["Dastavej_Date"] = customer.Dastavg_Date;
                    drNew["Dastavej_Amount"] = customer.Dastavej_Amount;
                    dtCustomer.Rows.Add(drNew);
                });
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
        private async void GetCustomerDetails(int customerId)
        {
            try
            {
                var customerDetails = await BACustomerMaster.GetCustomer(customerId);
                customerDetails.ForEach(customer =>
                {
                    if (dtCustomer.AsEnumerable().Any(x => x.Field<int>("Customer_Id") == customer.Customer_Id))
                    {
                        dtCustomer.AsEnumerable().Where<DataRow>(x => x.Field<int>("Customer_Id") == customer.Customer_Id).ToList().ForEach(dr =>
                        {
                            dr["Customer_Id"] = customer.Customer_Id;
                            dr["Wing_Master_Id"] = customer.Wing_Master_Id;
                            dr["Wing_Details_Id"] = customer.Wing_Details_Id;
                            dr["Wing_Name"] = customer.Wing_Name;
                            dr["FlatNo"] = customer.FlatNo;
                            dr["Customer_Name"] = customer.Customer_Name;
                            dr["Address"] = customer.Address;
                            dr["Con_Details"] = customer.Con_Details;
                            dr["Email_Id"] = customer.Email_Id;
                            dr["Customer_Wing_Name"] = customer.Customer_Wing_Name;
                            dr["Pan"] = customer.Pan;
                            dr["Aadhar"] = customer.Aadhar;
                            dr["Customer1"] = customer.Customer1;
                            dr["Pan1"] = customer.Pan1;
                            dr["Aadhar1"] = customer.Aadhar1;
                            dr["Customer2"] = customer.Customer2;
                            dr["Pan2"] = customer.Pan2;
                            dr["Aadhar2"] = customer.Aadhar2;
                            dr["Customer3"] = customer.Customer3;
                            dr["Pan3"] = customer.Pan3;
                            dr["Aadhar3"] = customer.Aadhar3;
                            dr["BanakhatNo"] = customer.BanakhatNo;
                            dr["BanakhatDate"] = customer.BanakhatDate;
                            dr["Dastavej_No"] = customer.Dastavg_No;
                            dr["Dastavej_Date"] = customer.Dastavg_Date;
                            dr["Dastavej_Amount"] = customer.Dastavej_Amount;
                        });
                        dtCustomer.AcceptChanges();
                    }
                    else
                    {
                        DataRow drNew = dtCustomer.NewRow();
                        drNew["Customer_Id"] = customer.Customer_Id;
                        drNew["Wing_Master_Id"] = customer.Wing_Master_Id;
                        drNew["Wing_Details_Id"] = customer.Wing_Details_Id;
                        drNew["Wing_Name"] = customer.Wing_Name;
                        drNew["FlatNo"] = customer.FlatNo;
                        drNew["Customer_Name"] = customer.Customer_Name;
                        drNew["Address"] = customer.Address;
                        drNew["Con_Details"] = customer.Con_Details;
                        drNew["Email_Id"] = customer.Email_Id;
                        drNew["Customer_Wing_Name"] = customer.Customer_Wing_Name;
                        drNew["Pan"] = customer.Pan;
                        drNew["Aadhar"] = customer.Aadhar;
                        drNew["Customer1"] = customer.Customer1;
                        drNew["Pan1"] = customer.Pan1;
                        drNew["Aadhar1"] = customer.Aadhar1;
                        drNew["Customer2"] = customer.Customer2;
                        drNew["Pan2"] = customer.Pan2;
                        drNew["Aadhar2"] = customer.Aadhar2;
                        drNew["Customer3"] = customer.Customer3;
                        drNew["Pan3"] = customer.Pan3;
                        drNew["Aadhar3"] = customer.Aadhar3;
                        drNew["BanakhatNo"] = customer.BanakhatNo;
                        drNew["BanakhatDate"] = customer.BanakhatDate;
                        drNew["Dastavej_No"] = customer.Dastavg_No;
                        drNew["Dastavej_Date"] = customer.Dastavg_Date;
                        drNew["Dastavej_Amount"] = customer.Dastavej_Amount;
                        dtCustomer.Rows.Add(drNew);
                    }
                });
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
        private async void FillCustomerTable()
        {
            try
            {
                dtCustomer = new DataTable();
                await ClsUtil.AddColumn(dtCustomer, "Customer_Id", ClsUtil.ColumnType.dbLong, "0");
                await ClsUtil.AddColumn(dtCustomer, "Wing_Master_Id", ClsUtil.ColumnType.dbInt, "");
                await ClsUtil.AddColumn(dtCustomer, "Wing_Details_Id", ClsUtil.ColumnType.dbInt, "");
                await ClsUtil.AddColumn(dtCustomer, "Wing_Name", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtCustomer, "FlatNo", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtCustomer, "Customer_Name", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtCustomer, "Address", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtCustomer, "Con_Details", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtCustomer, "Email_Id", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtCustomer, "Customer_Wing_Name", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtCustomer, "Pan", ClsUtil.ColumnType.dbString, "0");
                await ClsUtil.AddColumn(dtCustomer, "Aadhar", ClsUtil.ColumnType.dbString, "0");
                await ClsUtil.AddColumn(dtCustomer, "Customer1", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtCustomer, "Pan1", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtCustomer, "Aadhar1", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtCustomer, "Customer2", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtCustomer, "Pan2", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtCustomer, "Aadhar2", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtCustomer, "Customer3", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtCustomer, "Pan3", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtCustomer, "Aadhar3", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtCustomer, "BanakhatNo", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtCustomer, "BanakhatDate", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtCustomer, "Dastavej_No", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtCustomer, "Dastavej_Date", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtCustomer, "Dastavej_Amount", ClsUtil.ColumnType.dbDecimal, "0");
                dgCustomer.DataSource = dtCustomer;

                cboSearch.Items.Clear();
                foreach (DataColumn dtColumn in dtCustomer.Columns)
                {
                    if (dtColumn.DataType == typeof(string))
                    {
                        cboSearch.Items.Add(dtColumn.ColumnName);
                    }
                }
                GetCustomerDetails();
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (CloseUserDetails != null)
                {
                    CloseUserDetails.Invoke(sender, e);
                }
                this.Close();
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                frmCustomerEntry frmCust = new frmCustomerEntry();
                frmCust.ShowDialog();
                if (frmCust.CustomerId > 0)
                {
                    GetCustomerDetails(frmCust.CustomerId);
                }
                frmCust.Dispose();
                GC.Collect();
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }


        private async void dgCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    int selectedCustomer = Convert.ToInt32(dgCustomer[0, e.RowIndex].Value);
                }
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private async void sendToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsWaitForm.ShowWaitForm();
            var dgExport = new DataGridView();
            var dtExport = dtCustomer.Clone();
            try
            {
                foreach (DataGridViewColumn dgColumn in dgCustomer.Columns)
                {
                    dgExport.Columns.Add(dgColumn.Clone() as DataGridViewColumn);
                }
                dgExport.Refresh();
                dtExport.Rows.Clear();
                var receiptDetails = await BACustomerMaster.GetCustomerByCond("");
                receiptDetails.ForEach(customer =>
                {
                    DataRow drNew = dtExport.NewRow();
                    drNew["Customer_Id"] = customer.Customer_Id;
                    drNew["Wing_Master_Id"] = customer.Wing_Master_Id;
                    drNew["Wing_Details_Id"] = customer.Wing_Details_Id;
                    drNew["Wing_Name"] = customer.Wing_Name;
                    drNew["FlatNo"] = customer.FlatNo;
                    drNew["Customer_Name"] = customer.Customer_Name;
                    drNew["Address"] = customer.Address;
                    drNew["Con_Details"] = customer.Con_Details;
                    drNew["Email_Id"] = customer.Email_Id;
                    drNew["Customer_Wing_Name"] = customer.Customer_Wing_Name;
                    drNew["Pan"] = customer.Pan;
                    drNew["Aadhar"] = customer.Aadhar;
                    drNew["Customer1"] = customer.Customer1;
                    drNew["Pan1"] = customer.Pan1;
                    drNew["Aadhar1"] = customer.Aadhar1;
                    drNew["Customer2"] = customer.Customer2;
                    drNew["Pan2"] = customer.Pan2;
                    drNew["Aadhar2"] = customer.Aadhar2;
                    drNew["Customer3"] = customer.Customer3;
                    drNew["Pan3"] = customer.Pan3;
                    drNew["Aadhar3"] = customer.Aadhar3;
                    drNew["BanakhatNo"] = customer.BanakhatNo;
                    drNew["BanakhatDate"] = ClsUtil.getDateFormate(customer.BanakhatDate);
                    drNew["Dastavej_No"] = customer.Dastavg_No;
                    drNew["Dastavej_Date"] = ClsUtil.getDateFormate(customer.Dastavg_Date);
                    drNew["Dastavej_Amount"] = customer.Dastavej_Amount;
                    dtExport.Rows.Add(drNew);
                    dgExport.Rows.Add(drNew.ItemArray);
                });
                ClsUtil.ExportDataToExcel(dgExport);
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
            finally
            {
                dgExport.Dispose();
                dtExport.Dispose();
                clsWaitForm.CloseWaitForm();
            }
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtSearch.Text) && !string.IsNullOrWhiteSpace(cboSearch.Text))
                {
                    await FilterDetails();
                }
                else
                {
                    if (dtCustomer.Rows.Count == rowsCount) { return; }
                    PageIndex = 1;
                    txttolDisplay.Text = PageIndex.ToString();
                    PageSize = 0;
                    GetCustomerDetails();
                }
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }

            //try
            //{
            //    if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            //    {
            //        dtCustomer.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", cboSearch.Text, txtSearch.Text);
            //    }
            //    else
            //    {
            //        dtCustomer.DefaultView.RowFilter = String.Empty;
            //    }
            //}
            //catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedCustomer = Convert.ToInt32(dgCustomer[0, dgCustomer.SelectedCells[0].RowIndex].Value);
                frmCustomerEntry frmCust = new frmCustomerEntry(selectedCustomer);
                frmCust.ShowDialog();
                GetCustomerDetails(selectedCustomer);
                frmCust.Dispose();
                GC.Collect();
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private void tolFirst_Click(object sender, EventArgs e)
        {
            try
            {
                clsWaitForm.ShowWaitForm();
                PageIndex = 1;
                txttolDisplay.Text = PageIndex.ToString();
                PageSize = 0;
                crrrentPage = 0;
                GetCustomerDetails();
                clsWaitForm.CloseWaitForm();
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private void tolPrv_Click(object sender, EventArgs e)
        {
            try
            {
                if (PageIndex <= 1 || PageSize == 0)
                {
                    return;
                }
                clsWaitForm.ShowWaitForm();
                PageIndex = PageIndex - 1;
                crrrentPage = crrrentPage - 1;
                txttolDisplay.Text = PageIndex.ToString();
                PageSize = PageSize - this.rowsCount;
                GetCustomerDetails();
                clsWaitForm.CloseWaitForm();
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
                clsWaitForm.ShowWaitForm();
                PageIndex = PageIndex + 1;
                crrrentPage = crrrentPage + 1;
                txttolDisplay.Text = PageIndex.ToString();
                PageSize = crrrentPage + this.rowsCount;
                GetCustomerDetails();
                clsWaitForm.CloseWaitForm();
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private void tolLast_Click(object sender, EventArgs e)
        {
            try
            {
                clsWaitForm.ShowWaitForm();
                PageSize = (this.rowsCount * PageCount);
                PageIndex = PageCount;
                txttolDisplay.Text = PageIndex.ToString();
                GetCustomerDetails();
                clsWaitForm.CloseWaitForm();
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }


        private void txttolDisplay_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    int pageNumber = 0;
            //    if (int.TryParse(txttolDisplay.Text, out pageNumber))
            //    {
            //        pageNumber = Convert.ToInt32(txttolDisplay.Text);
            //        PageSize = (rowsCount * pageNumber);
            //        PageIndex = PageCount;
            //        txttolDisplay.Text = pageNumber.ToString();
            //        GetCustomerDetails();
            //    }
            //    else
            //    {
            //        txttolDisplay.Text = "1";
            //        return;
            //    }

            //}
            //catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
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
        private void txttolRowsCount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rowsCount != Convert.ToInt32(txttolRowsCount.Text))
                {
                    this.rowsCount = Convert.ToInt32(txttolRowsCount.Text);
                    var pag = BACustomerMaster.GetPageCount(this.rowsCount);
                    PageCount = Convert.ToInt32(pag.Result.ToString());
                    PageIndex = 0;
                    tolTotalPages.Text = " OF " + PageCount.ToString();
                    PageSize = this.rowsCount;
                    txttolDisplay.Text = (PageIndex + 1).ToString();
                    GetCustomerDetails();
                }
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private void btnGoTo_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    int pageNumber = 0;
                    if (int.TryParse(txtGotoPageNo.Text, out pageNumber))
                    {
                        clsWaitForm.ShowWaitForm();
                        pageNumber = Convert.ToInt32(txtGotoPageNo.Text);
                        PageSize = (rowsCount * pageNumber);
                        PageIndex = PageCount;
                        txttolDisplay.Text = pageNumber.ToString();
                        GetCustomerDetails();
                        clsWaitForm.CloseWaitForm();
                    }
                    else
                    {
                        txttolDisplay.Text = "1";
                        return;
                    }

                }
                catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                clsWaitForm.ShowWaitForm();
                PageSize = 0;
                crrrentPage = 0;
                this.rowsCount = 30;
                var pag = BACustomerMaster.GetPageCount(this.rowsCount);
                PageCount = Convert.ToInt32(pag.Result.ToString());
                PageIndex = PageCount;
                PageSize = PageIndex * rowsCount;
                tolTotalPages.Text = " OF " + PageCount.ToString();
                txttolRowsCount.Text = this.rowsCount.ToString();
                txttolDisplay.Text = PageIndex.ToString();
                FillCustomerTable();
                clsWaitForm.CloseWaitForm();
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
    }
}
