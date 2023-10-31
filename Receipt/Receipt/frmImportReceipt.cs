using ReceiptBAccess;
using ReceiptLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Receipt
{
    public partial class frmImportReceipt : Form
    {
        private string _FileName = string.Empty;
        private System.Data.DataTable dtExcelData;
        public frmImportReceipt()
        {
            InitializeComponent();
        }
        public frmImportReceipt(string FileName)
        {
            InitializeComponent();
            _FileName = FileName;
            lblFileName.Text = "Selected File :"+Path.GetFileName(_FileName);
            dtExcelData= new DataTable();
        }
        private void GetDataFromExcel(string fileName, string sheetName)
        {
            clsWaitForm.ShowWaitForm();
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
                dgvImportReceipt.BeginInvoke(new MethodInvoker(()=>dgvImportReceipt.DataSource = dtExcelData));
                clsWaitForm.CloseWaitForm();
            }
            catch (Exception ex) 
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
                clsWaitForm.CloseWaitForm();
            }
        }

        private void frmImportReceipt_Load(object sender, EventArgs e)
        {
            new System.Threading.Thread(x=>GetDataFromExcel(_FileName,"Sheet1")).Start();
        }

        private async void btnImport_Click(object sender, EventArgs e)
        {
            clsWaitForm.ShowWaitForm();
            try
            {
                await BAReceiptDetails.ImportReceiptFromExcel(dtExcelData);
                clsWaitForm.CloseWaitForm();
                this.Close();
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
                clsWaitForm.CloseWaitForm();
            }
        }

        private void dgvImportReceipt_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            new System.Threading.Thread(() =>
            {
                try
                {
                    DataGridViewRow drRow = dgvImportReceipt.Rows[e.RowIndex];
                    if (dgvImportReceipt.Columns.Contains("IsImport"))
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
