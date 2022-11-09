using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Receipt
{
    public partial class frmImportData : Form
    {
        public event EventHandler CloseUserDetails;
        public frmImportData()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
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
        private void FillXlSheetName(string sFile)
        {
            var xlApp = new Microsoft.Office.Interop.Excel.Application();
            var xlWorkBook = xlApp.Workbooks.Open(sFile);           // WORKBOOK TO OPEN THE EXCEL FILE.
            foreach (Worksheet xlsheet in xlWorkBook.Worksheets)
            {
                cmbSelectSheet.Items.Add(xlsheet.Name);
            }
            xlWorkBook.Close();
            xlApp.Quit();
        }
        private void GetDataFromExcel(string fileName,string sheetName)
        {
            string connectionString = @"Provider = Microsoft.ACE.OLEDB.12.0;" +
            "Data Source='" + fileName + "';Extended Properties=Excel 12.0;";

            // Select using a Named Range

            // Select using a Worksheet name
            string selectString = "SELECT * FROM ["+sheetName+"$]";

            OleDbConnection con = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand(selectString, con);
            DataSet dsExcel = new DataSet();
            try
            {
                con.Open();
                using(OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
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
            dgvImportData.DataSource = dsExcel.Tables[0];
        }
        private void btnShowData_Click(object sender, EventArgs e)
        {
            GetDataFromExcel(txtSelectedFile.Text, cmbSelectSheet.Text);
        }
    }
}
