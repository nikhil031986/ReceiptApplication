using Microsoft.Office.Interop.Excel;
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
            foreach(Worksheet xlsheet in xlWorkBook.Worksheets)
            {
                cmbSelectSheet.Items.Add(xlsheet.Name);
            }
            xlWorkBook.Close();
            xlApp.Quit();
        }
        private void GetDataFromExcel(string fileName,string sheetName)
        {
            var xlApp = new Microsoft.Office.Interop.Excel.Application();
            var xlWorkBook = xlApp.Workbooks.Open(fileName);           // WORKBOOK TO OPEN THE EXCEL FILE.
            var xlSheet = xlWorkBook.Worksheets[sheetName];
            Microsoft.Office.Interop.Excel.Range excelRange = xlSheet.UsedRange;
            System.Data.DataTable dt = new System.Data.DataTable();
            int rows = excelRange.Rows.Count;
            int cols = excelRange.Columns.Count;
            for (int i = 1; i <= rows-1; i++)
            {
                DataRow myNewRow =null;
                if (i>1)
                {

                    myNewRow = dt.NewRow();
                }
                for (int j = 1; j <= cols-1; j++)
                {
                    if (i == 1)
                    {
                        DataColumn dcNewColumn = new DataColumn();
                        dcNewColumn.DataType = typeof(string);
                        string columnName = "";
                        if(string.IsNullOrEmpty(excelRange.Cells[i, j].Value2))
                        {
                            columnName = "_New"+j.ToString();
                        }
                        else
                        {
                            columnName= excelRange.Cells[i, j].Value2.ToString();
                        }
                        dcNewColumn.ColumnName = columnName;
                        dcNewColumn.DefaultValue = string.Empty;
                        if(dt.Columns.Contains(dcNewColumn.ColumnName))
                        {
                            dcNewColumn.ColumnName = dcNewColumn.ColumnName + "_New";
                        }
                        dt.Columns.Add(dcNewColumn);
                    }
                    else
                    {
                        string excelCellValue = string.Empty;
                        if (!string.IsNullOrEmpty(Convert.ToString(excelRange.Cells[i, j].Value2)))
                        {
                            excelCellValue = excelRange.Cells[i, j].Value2.ToString();
                        }
                        myNewRow[j-1] = excelCellValue; //string
                    }
                }
                if (i != 1)
                {
                    dt.Rows.Add(myNewRow);
                }
            }
            dgvImportData.DataSource = dt;
            //foreach (var xlsheet in xlWorkBook.Worksheets)
            //{
            //    cmbSelectSheet.Items.Add(xlsheet);
            //}
            xlWorkBook.Close();
            xlApp.Quit();
        }
        private void btnShowData_Click(object sender, EventArgs e)
        {
            GetDataFromExcel(txtSelectedFile.Text, cmbSelectSheet.Text);
        }
    }
}
