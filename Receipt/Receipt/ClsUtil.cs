using ReceiptEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Receipt.ClsUtil;

namespace Receipt
{
    public class clsColumn
    {
        public string columnName { get; set; }
        public ClsUtil.ColumnType cType { get; set; }
        public string defultValue { get; set; }
        public clsColumn()
        { }
        public clsColumn(string columnName, ColumnType cType, string defultValue)
        {
            this.columnName = columnName;
            this.cType = cType;
            this.defultValue = defultValue;
        }
    }
    public static class ClsUtil
    {
        public static EnUserDetails currentUserInfo = new EnUserDetails();
        public static string SiteDBName { get; set; }

        private static String[] units = { "Zero", "One", "Two", "Three",
    "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
    "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
    "Seventeen", "Eighteen", "Nineteen" };
        private static String[] tens = { "", "", "Twenty", "Thirty", "Forty",
    "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        public enum ColumnType
        {
            dbString = 1,
            dbDateTime = 2,
            dbboolean = 3,
            dbLong = 4,
            dbInt = 5,
            dbDecimal = 6
        }

        public static void ExportDataToExcel(DataTable dtExport)
        {
            if (dtExport != null && dtExport.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
                XcelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dtExport.Columns.Count + 1; i++)
                {
                    XcelApp.Cells[1, i] = dtExport.Columns[i - 1].ColumnName;
                }
                for (int i = 0; i < dtExport.Rows.Count; i++)
                {
                    for (int j = 0; j < dtExport.Columns.Count; j++)
                    {
                        XcelApp.Cells[i + 2, j + 1] = dtExport.Rows[i][j].ToString();
                    }
                }
                XcelApp.Columns.AutoFit();
                XcelApp.Visible = true;
            }
        }

        public static void ExportDataToExcel(DataGridView dtExport)
        {
            if (dtExport != null && dtExport.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
                XcelApp.Application.Workbooks.Add(Type.Missing);
                int columnNo = 1;
                for (int i = 1; i < dtExport.Columns.Count + 1; i++)
                {
                    if (dtExport.Columns[i - 1].Visible)
                    {
                        XcelApp.Cells[1, columnNo] = dtExport.Columns[i - 1].HeaderText;
                        columnNo = columnNo + 1;
                    }
                }
                for (int i = 0; i < dtExport.Rows.Count; i++)
                {
                    columnNo = 1;
                    for (int j = 0; j < dtExport.Columns.Count; j++)
                    {
                        if (dtExport.Columns[j].Visible)
                        {
                            XcelApp.Cells[i + 2, columnNo] = dtExport.Rows[i].Cells[j].Value.ToString();
                            columnNo = columnNo + 1;
                        }
                    }
                }
                XcelApp.Columns.AutoFit();
                XcelApp.Visible = true;
            }
        }

        public static String ConvertAmount(double amount)
        {
            try
            {
                Int64 amount_int = (Int64)amount;
                Int64 amount_dec = (Int64)Math.Round((amount - (double)(amount_int)) * 100);
                if (amount_dec == 0)
                {
                    return ConvertWord(amount_int) + " Only.";
                }
                else
                {
                    return ConvertWord(amount_int) + " Point " + ConvertWord(amount_dec) + " Only.";
                }
            }
            catch (Exception e)
            {
                // TODO: handle exception  
            }
            return "";
        }
        public static String ConvertWord(Int64 i)
        {
            if (i < 20)
            {
                return units[i];
            }
            if (i < 100)
            {
                return tens[i / 10] + ((i % 10 > 0) ? " " + ConvertWord(i % 10) : "");
            }
            if (i < 1000)
            {
                return units[i / 100] + " Hundred"
                        + ((i % 100 > 0) ? " And " + ConvertWord(i % 100) : "");
            }
            if (i < 100000)
            {
                return ConvertWord(i / 1000) + " Thousand "
                        + ((i % 1000 > 0) ? " " + ConvertWord(i % 1000) : "");
            }
            if (i < 10000000)
            {
                return ConvertWord(i / 100000) + " Lakh "
                        + ((i % 100000 > 0) ? " " + ConvertWord(i % 100000) : "");
            }
            if (i < 1000000000)
            {
                return ConvertWord(i / 10000000) + " Crore "
                        + ((i % 10000000 > 0) ? " " + ConvertWord(i % 10000000) : "");
            }
            return ConvertWord(i / 1000000000) + " Arab "
                    + ((i % 1000000000 > 0) ? " " + ConvertWord(i % 1000000000) : "");
        }
        public static async Task AddColumn(DataTable dtAddColumn, List<clsColumn> columns)
        {
            try
            {
                foreach (var column in columns)
                {
                    DataColumn dcNewColumn = new DataColumn();
                    dcNewColumn.ColumnName = column.columnName;
                    switch (column.cType)
                    {
                        case ColumnType.dbString:
                            dcNewColumn.DataType = typeof(string);
                            if (string.IsNullOrEmpty(column.defultValue))
                            {
                                dcNewColumn.DefaultValue = string.Empty;
                            }
                            else
                            {
                                dcNewColumn.DefaultValue = column.defultValue;
                            }
                            break;
                        case ColumnType.dbboolean:
                            dcNewColumn.DataType = typeof(bool);
                            if (string.IsNullOrEmpty(column.defultValue))
                            {
                                dcNewColumn.DefaultValue = false;
                            }
                            else
                            {
                                dcNewColumn.DefaultValue = Convert.ToString(column.defultValue).ToUpper() == "TRUE" ? true : false;
                            }
                            break;
                        case ColumnType.dbLong:
                        case ColumnType.dbInt:
                            dcNewColumn.DataType = typeof(int);
                            if (string.IsNullOrEmpty(column.defultValue))
                            {
                                dcNewColumn.DefaultValue = 0;
                            }
                            else
                            {
                                dcNewColumn.DefaultValue = Convert.ToInt32(column.defultValue);
                            }
                            break;
                        case ColumnType.dbDateTime:
                            dcNewColumn.DataType = typeof(DateTime);
                            if (string.IsNullOrEmpty(column.defultValue))
                            {
                                dcNewColumn.DefaultValue = DateTime.Now;
                            }
                            else
                            {
                                dcNewColumn.DefaultValue = Convert.ToDateTime(column.defultValue);
                            }
                            break;
                        case ColumnType.dbDecimal:
                            dcNewColumn.DataType = typeof(decimal);
                            if (string.IsNullOrEmpty(column.defultValue))
                            {
                                dcNewColumn.DefaultValue = 0.0;
                            }
                            else
                            {
                                dcNewColumn.DefaultValue = Convert.ToDecimal(column.defultValue);
                            }
                            break;
                    }
                    dtAddColumn.Columns.Add(dcNewColumn);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string getCurrentPath()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("Receipt.exe", "");
        }
        public static async Task AddColumn(DataTable dtAddColumn, string columnName, ColumnType columnType, string DefaultValue)
        {
            try
            {
                DataColumn dcNewColumn = new DataColumn();
                dcNewColumn.ColumnName = columnName;
                switch (columnType)
                {
                    case ColumnType.dbString:
                        dcNewColumn.DataType = typeof(string);
                        if (string.IsNullOrEmpty(DefaultValue))
                        {
                            dcNewColumn.DefaultValue = string.Empty;
                        }
                        else
                        {
                            dcNewColumn.DefaultValue = DefaultValue;
                        }
                        break;
                    case ColumnType.dbboolean:
                        dcNewColumn.DataType = typeof(bool);
                        if (string.IsNullOrEmpty(DefaultValue))
                        {
                            dcNewColumn.DefaultValue = false;
                        }
                        else
                        {
                            dcNewColumn.DefaultValue = Convert.ToString(DefaultValue).ToUpper() == "TRUE" ? true : false;
                        }
                        break;
                    case ColumnType.dbLong:
                    case ColumnType.dbInt:
                        dcNewColumn.DataType = typeof(int);
                        if (string.IsNullOrEmpty(DefaultValue))
                        {
                            dcNewColumn.DefaultValue = 0;
                        }
                        else
                        {
                            dcNewColumn.DefaultValue = Convert.ToInt32(DefaultValue);
                        }
                        break;
                    case ColumnType.dbDateTime:
                        dcNewColumn.DataType = typeof(DateTime);
                        if (string.IsNullOrEmpty(DefaultValue))
                        {
                            dcNewColumn.DefaultValue = DateTime.Now;
                        }
                        else
                        {
                            dcNewColumn.DefaultValue = Convert.ToDateTime(DefaultValue);
                        }
                        break;
                    case ColumnType.dbDecimal:
                        dcNewColumn.DataType = typeof(decimal);
                        if (string.IsNullOrEmpty(DefaultValue))
                        {
                            dcNewColumn.DefaultValue = 0.0;
                        }
                        else
                        {
                            dcNewColumn.DefaultValue = Convert.ToDecimal(DefaultValue);
                        }
                        break;
                }
                dtAddColumn.Columns.Add(dcNewColumn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
