using Microsoft.Office.Interop.Excel;
using ReceiptBAccess;
using ReceiptLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Receipt
{
    public partial class frmImportData : Form
    {
        public event EventHandler CloseUserDetails;
        private System.Data.DataTable dtExcelData = new System.Data.DataTable();
        public frmImportData()
        {
            InitializeComponent();
            FillTableName();
        }
        private async void FillTableName()
        {
            cboTableName.Items.Clear();
            var lstTableName = await BAImpoerData.GetTableName();
            lstTableName.ForEach(x =>
            {
                cboTableName.Items.Add(x);
            });
        }
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            try
            {
                dtExcelData = new System.Data.DataTable();
                OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
                OpenFileDialog1.Title = "Excel File to Edit";
                OpenFileDialog1.FileName = "";
                OpenFileDialog1.Filter = "Excel File|*.xlsx;*.xls";

                if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtSelectedFile.Text = OpenFileDialog1.FileName;

                    if (txtSelectedFile.Text.Trim() != "")
                    {
                        FillXlSheetName(txtSelectedFile.Text);
                    }
                }
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
        private void FillXlSheetName(string sFile)
        {
            try
            {
                cmbSelectSheet.Items.Clear();
                string connectionString = @"Provider = Microsoft.ACE.OLEDB.12.0;" +
                "Data Source='" + sFile + "';Extended Properties=Excel 12.0;";
                
                OleDbConnection con = new OleDbConnection(connectionString);

                System.Data.DataTable dtForExcel = new System.Data.DataTable();
                try
                {
                    con.Open();
                    dtForExcel = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Dispose();
                }
                foreach (System.Data.DataRow sheets in dtForExcel.Rows)
                {
                    cmbSelectSheet.Items.Add(Convert.ToString(sheets["TABLE_NAME"]).Replace("$",""));
                }
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
        private void GetDataFromExcel(string fileName, string sheetName)
        {
            try
            {

                string connectionString = @"Provider = Microsoft.ACE.OLEDB.12.0;" +
                "Data Source='" + fileName + "';Extended Properties=Excel 12.0;";

                // Select using a Named Range

                // Select using a Worksheet name
                string selectString = "SELECT * FROM [" + sheetName + "$]";

                OleDbConnection con = new OleDbConnection(connectionString);
                OleDbCommand cmd = new OleDbCommand(selectString, con);
                DataSet dsExcel = new DataSet();
                try
                {
                    con.Open();
                    using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
                    {
                        adp.Fill(dsExcel);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Dispose();
                }
                dtExcelData = dsExcel.Tables[0];
                dgvImportData.DataSource = dtExcelData;
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
        private void btnShowData_Click(object sender, EventArgs e)
        {
            try
            {
                GetDataFromExcel(txtSelectedFile.Text, cmbSelectSheet.Text);
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private async void btnImportData_Click(object sender, EventArgs e)
        {
            try
            {
                if(!string.IsNullOrWhiteSpace(cboTableName.Text))
                {
                    if(!string.IsNullOrWhiteSpace(cboTableName.Text))
                    {
                        string selectedTableName = cboTableName.Text.Trim().ToLower();
                        switch (selectedTableName)
                        {
                            case "receiptdetail":
                                System.Data.DataTable dtImportData = await BAImpoerData.ImportReceiptData(dtExcelData);
                                break;
                            case "wing_details":
                                await BAImpoerData.ImportWingDetails(dtExcelData);
                                break;
                            default:
                                break;
                        }
                    }
                    MessageBox.Show("Data Import in the system.\n if any error for import data see the isimport column value and contact to administrator.", "Receipt Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //if(!string.IsNullOrWhiteSpace(cboTableName.Text) && cboTableName.Text.Trim().ToLower()== "receiptdetail")
                    //{
                    //    System.Data.DataTable dtImportData = await BAImpoerData.ImportReceiptData(dtExcelData);
                    //}
                }

            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private void dgvImportData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //new System.Threading.Thread(() =>
            //{
            //    try
            //    {
            //        foreach (DataGridViewRow Myrow in dgvImportData.Rows)
            //        {            //Here 2 cell is target value and 1 cell is Volume
            //            if (dgvImportData.Columns.Contains("IsImport"))
            //            {
            //                if (Convert.ToBoolean(Myrow.Cells["IsImport"].Value))// Or your condition 
            //                {
            //                    Myrow.DefaultCellStyle.BackColor = Color.Green;
            //                    Myrow.DefaultCellStyle.ForeColor = Color.White;
            //                }
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
            //    }
            //}).Start();
        }

        private void dgvImportData_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            new System.Threading.Thread(() =>
            {
                try
                {
                    DataGridViewRow drRow = dgvImportData.Rows[e.RowIndex];
                    if (dgvImportData.Columns.Contains("IsImport"))
                    {
                        if (Convert.ToBoolean(drRow.Cells["IsImport"].Value))// Or your condition 
                        {
                            drRow.DefaultCellStyle.BackColor = Color.Green;
                            drRow.DefaultCellStyle.ForeColor = Color.White;
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
                }
            }).Start();
        }
    }
}