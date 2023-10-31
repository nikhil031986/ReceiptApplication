using Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel;
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
    public partial class frmReceiptNotDisplay : Form
    {
        private DataTable dtReceiptDetails;
        public frmReceiptNotDisplay()
        {
            InitializeComponent();
            try
            {
                Task.Run(async () =>
                    {
                        var strReturn = await CreateDataTable();
                        var isImport = await FillDataIntoDataTable();
                    });
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, "frmReceiptNotDisplay");
            }
        }
        private async Task<int> FillDataIntoDataTable()
        {
            try
            {
                var dtFromDB = await BAReceiptDetails.getMissingCustomerDetails();
                foreach(DataRow row in dtFromDB.Rows) 
                {
                   DataRow drNew = dtReceiptDetails.NewRow();
                    drNew["Receipt_Id"] = row["Receipt_Id"];
                    drNew["Receipt_No"] = row["Receipt_No"];
                    drNew["Receipt_Date"] = row["Receipt_Date"];
                    drNew["Customer_Id"] = row["Customer_Id"];
                    drNew["Customer_Name"] = row["Customer_Name"];
                    drNew["Flate_ShopNo"] = row["Flate_ShopNo"];
                    drNew["Bank_Name"] = row["Bank_Name"];
                    drNew["Branch_Name"] = row["Branch_Name"];
                    drNew["Amount"] = row["Amount"];
                    drNew["ReceiptCustomer"] = row["ReceiptCustomer"];
                    drNew["IsUpdate"] = row["IsUpdate"];
                    dtReceiptDetails.Rows.Add(drNew);
                    dtReceiptDetails.AcceptChanges();
                }
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private async Task<string> CreateDataTable()
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
                clsColumns.Add(new clsColumn("Bank_Name", ClsUtil.ColumnType.dbString, ""));
                clsColumns.Add(new clsColumn("Branch_Name", ClsUtil.ColumnType.dbString, ""));
                clsColumns.Add(new clsColumn("Amount", ClsUtil.ColumnType.dbDecimal, "0.0"));
                clsColumns.Add(new clsColumn("ReceiptCustomer", ClsUtil.ColumnType.dbString, ""));
                clsColumns.Add(new clsColumn("IsUpdate", ClsUtil.ColumnType.dbInt, "0"));
                await ClsUtil.AddColumn(dtReceiptDetails, clsColumns);
                dgvReceiptNotDisplay.DataSource = dtReceiptDetails;
                dtReceiptDetails.TableName = "ReceipList";
                return "1";
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void btnUpdateAll_Click(object sender, EventArgs e)
        {
            try
            {
                foreach(DataRow dr in dtReceiptDetails.Rows)
                {
                    var update = await BAReceiptDetails.UpdateReceiptCustomerId(Convert.ToInt32(dr["Receipt_Id"]), Convert.ToInt32(dr["Customer_Id"]));
                }
                this.Close();
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, "UpdateAll");
            }
        }

        private async void btnUpdateSelected_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow[] selectedRow = dtReceiptDetails.Select("IsUpdate=1");
                foreach(DataRow dr in selectedRow)
                {
                    var update = await BAReceiptDetails.UpdateReceiptCustomerId(Convert.ToInt32(dr["Receipt_Id"]), Convert.ToInt32(dr["Customer_Id"]));
                }
                this.Close();
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, "UpdateAll");
            }
        }
    }
}
