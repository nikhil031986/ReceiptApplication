using IronPdf;
using ReceiptBAccess;
using ReceiptLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using ReceiptEntity;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Windows.Forms.VisualStyles;
using System.Windows.Controls;

namespace Receipt
{
    public partial class frmBanakhatList : Form
    {
        private System.Data.DataTable dtList;
        private System.Data.DataTable dtReciptDetails;
        private System.Data.DataSet dsCustomerDetails;
        private string htmlFilePath = "";
        public frmBanakhatList()
        {
            InitializeComponent();

        }
        private async Task  AddContrial()
        {
            try
            {
                dtList = new System.Data.DataTable();
                List<clsColumn> list = new List<clsColumn>();
                list.Add(new clsColumn("Wing_Name", ClsUtil.ColumnType.dbString, ""));
                list.Add(new clsColumn("FlatNo", ClsUtil.ColumnType.dbString, ""));
                list.Add(new clsColumn("Customer_Name", ClsUtil.ColumnType.dbString, ""));
                list.Add(new clsColumn("Amount", ClsUtil.ColumnType.dbDecimal, "0.0"));
                list.Add(new clsColumn("minPayAmount", ClsUtil.ColumnType.dbDecimal, "0.0"));
                list.Add(new clsColumn("ReceiptAmount", ClsUtil.ColumnType.dbDecimal, "0.0"));
                list.Add(new clsColumn("PrintBanakhat", ClsUtil.ColumnType.dbInt, "0"));
                list.Add(new clsColumn("Customer_Id", ClsUtil.ColumnType.dbInt, "0"));
                list.Add(new clsColumn("Wing_Master_Id", ClsUtil.ColumnType.dbInt, "0"));
                await ClsUtil.AddColumn(dtList, list);
                dtList.TableName = "CustomerMaster";
                dtReciptDetails = new System.Data.DataTable();
                list = new List<clsColumn>();
                list.Add(new clsColumn("Receipt_No", ClsUtil.ColumnType.dbString, ""));
                list.Add(new clsColumn("Receipt_Date", ClsUtil.ColumnType.dbString, ""));
                list.Add(new clsColumn("Flate_ShopNo", ClsUtil.ColumnType.dbString, ""));
                list.Add(new clsColumn("Cheq_Rtgs_Neft_ImpsNo", ClsUtil.ColumnType.dbString, ""));
                list.Add(new clsColumn("Bank_Name", ClsUtil.ColumnType.dbString, ""));
                list.Add(new clsColumn("Branch_Name", ClsUtil.ColumnType.dbString, ""));
                list.Add(new clsColumn("Amount", ClsUtil.ColumnType.dbDecimal, "0"));
                list.Add(new clsColumn("Amount_Word", ClsUtil.ColumnType.dbString, ""));
                list.Add(new clsColumn("Customer_Id", ClsUtil.ColumnType.dbInt, "0"));
                await ClsUtil.AddColumn(dtReciptDetails, list);
                dtReciptDetails.TableName = "ReceiptDetails";
                dsCustomerDetails = new System.Data.DataSet();
                dsCustomerDetails.Tables.Add(dtList);
                dsCustomerDetails.Tables.Add(dtReciptDetails);

                DataRelation Datatablerelation = new DataRelation("ReceiptCustomer", dsCustomerDetails.Tables[0].Columns["Customer_Id"], dsCustomerDetails.Tables[1].Columns["Customer_Id"], true);
                dsCustomerDetails.Relations.Add(Datatablerelation);
                dsCustomerDetails.DataSetName = "Customer_List";
                dgviewBanakhatDetails.DataSource = dsCustomerDetails.Tables[0];
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, "AddContrial");
                throw;
            }
        }
        private async Task GetBanakhatListData(bool Iscompleted=false)
        {
            var dtBanakhat = await BAReceiptDetails.GetBanakhatDetails(Iscompleted);
            var dtRecipt = await BAReceiptDetails.GetReceiptDetails();
            dtReciptDetails.Rows.Clear();
            dtList.Rows.Clear();
            dtBanakhat.AsEnumerable().ToList<DataRow>().ForEach(row =>
            {
                var newRows = dtList.NewRow();
                newRows["Customer_Id"] = Convert.ToInt32(row["Customer_Id"]);
                newRows["Customer_Name"] = row["Customer_Name"].ToString();
                newRows["Wing_Master_Id"] = Convert.ToInt32(row["Wing_Master_Id"].ToString());
                newRows["Wing_Name"] = Convert.ToString(row["Wing_Name"]);
                newRows["FlatNo"] = Convert.ToString(row["FlatNo"]);
                newRows["minPayAmount"] = Convert.ToDecimal(row["minPayAmount"]);
                newRows["ReceiptAmount"] = Convert.ToDecimal(row["ReceiptAmount"]);
                newRows["Amount"] = Convert.ToDecimal(row["Amount"]);
                newRows["PrintBanakhat"] = Convert.ToInt32(row["PrintBanakhat"]) == 0 ? false : true;
                dtList.Rows.Add(newRows);
                dtRecipt.Select("Customer_Id=" + Convert.ToString(newRows["Customer_Id"])).AsEnumerable().ToList().ForEach(
                dr =>
                {
                    var drNew = dtReciptDetails.NewRow();
                    drNew["Customer_Id"] = Convert.ToInt32(dr["Customer_Id"]);
                    drNew["Receipt_No"] = Convert.ToString(dr["Receipt_No"]);
                    drNew["Receipt_Date"] = Convert.ToString(dr["Receipt_Date"]);
                    drNew["Flate_ShopNo"] = Convert.ToString(dr["Flate_ShopNo"]);
                    drNew["Cheq_Rtgs_Neft_ImpsNo"] = Convert.ToString(dr["Cheq_Rtgs_Neft_ImpsNo"]);
                    drNew["Bank_Name"] = Convert.ToString(dr["Bank_Name"]);
                    drNew["Branch_Name"] = Convert.ToString(dr["Branch_Name"]);

                    drNew["Amount"] = Convert.ToDecimal(dr["Amount"]);
                    drNew["Amount_Word"] = Convert.ToString(dr["Amount_Word"]);
                    dtReciptDetails.Rows.Add(drNew);
                });
                
            });
            dtReciptDetails.AcceptChanges();
            //dtRecipt.AsEnumerable().Where<DataRow>(x => x.Field<int>("Customer_Id") == Convert.ToInt32(newRows["Customer_Id"])).ToList<DataRow>().ForEach(
            dtList.AcceptChanges();

          
        }
        private async Task CreateExcelBankhat(int CustomerId)
        {
            try
            {
                string dirName = ClsUtil.getCurrentPath() + DateTime.Now.ToString("dd_MM_yyyy");
                if (!System.IO.Directory.Exists(dirName))
                {
                    System.IO.Directory.CreateDirectory(dirName);
                }

                var selectedCustomer = await BACustomerMaster.GetCustomer(CustomerId);
                var wingDetails = await BaWingMaster.GetWingDetails(selectedCustomer.FirstOrDefault().Wing_Master_Id);
                var selectedWingDetails = wingDetails.AsEnumerable().Where(x => x.Wing_DetailsId == selectedCustomer.FirstOrDefault().Wing_Details_Id).FirstOrDefault();
                var selectReceiptDetails = await BAReceiptDetails.GetReceiptByCustomer(selectedCustomer.FirstOrDefault().Customer_Id);

                string CustomerFileName = dirName + @"\" + selectedWingDetails.Wing_Name + "-" + selectedWingDetails.FlatNo + " " + selectedCustomer.FirstOrDefault().Customer_Name + ".xlsx";

                int rowNumber = 1;
                Microsoft.Office.Interop.Excel.Application MyApp = new Microsoft.Office.Interop.Excel.Application();
                System.Threading.Thread.Sleep(1000);
                MyApp.Visible = false;
                MyApp.DisplayAlerts = false;
                var worKbooK = MyApp.Workbooks.Add(Type.Missing);
                var worKsheeT = (Microsoft.Office.Interop.Excel.Worksheet)worKbooK.ActiveSheet;
                worKsheeT.Name = "StudentRepoertCard";
                rowNumber = 4;
                worKsheeT.Cells[rowNumber, 1].Value = "KARNAVATI APARTMENT-6";
                worKsheeT.Range[worKsheeT.Cells[rowNumber, 1], worKsheeT.Cells[rowNumber, 8]].Merge();
                worKsheeT.Range[worKsheeT.Cells[rowNumber, 1], worKsheeT.Cells[rowNumber, 8]].Font.Size = 20;
                worKsheeT.Range[worKsheeT.Cells[rowNumber, 1], worKsheeT.Cells[rowNumber, 8]].Font.Name = "Times New Roman";
                
                rowNumber = 5;
                worKsheeT.Cells[rowNumber, 1].Value = "REG. BANAKHAT";
                worKsheeT.Range[worKsheeT.Cells[rowNumber, 1], worKsheeT.Cells[rowNumber, 8]].Merge();
                worKsheeT.Range[worKsheeT.Cells[rowNumber, 1], worKsheeT.Cells[rowNumber, 8]].Font.Size = 20;
                worKsheeT.Range[worKsheeT.Cells[rowNumber, 1], worKsheeT.Cells[rowNumber, 8]].Font.Name = "Times New Roman";


                rowNumber = 6;
                var cells = worKsheeT.Cells[rowNumber, 1];
                cells.Value = "FLAT NO.:-";
                cells.Interior.Color = Color.FromArgb(252, 213, 180);
                cells = worKsheeT.Cells[rowNumber, 2];
                worKsheeT.Range[worKsheeT.Cells[rowNumber, 2], worKsheeT.Cells[rowNumber, 3]].Merge();
                cells.Value = selectedWingDetails.FlatNo;
                cells = worKsheeT.Cells[rowNumber, 4];
                cells.Value = "BLOCK:-";
                cells.Interior.Color = Color.FromArgb(252, 213, 180);
                cells = worKsheeT.Cells[rowNumber, 5];
                cells.Value = selectedWingDetails.Wing_Name;
                worKsheeT.Range[worKsheeT.Cells[rowNumber, 5], worKsheeT.Cells[rowNumber, 6]].Merge();
                cells = worKsheeT.Cells[rowNumber, 7];
                cells.Value = "FLOOR:-";
                cells.Interior.Color = Color.FromArgb(252, 213, 180);
                cells = worKsheeT.Cells[rowNumber, 8];
                cells.Value = selectedWingDetails.FlorName;


                rowNumber = 7;
                cells = worKsheeT.Cells[rowNumber, 1];
                cells.Value = "LAND.:-";
                cells.Interior.Color = Color.FromArgb(252, 213, 180);
                cells = worKsheeT.Cells[rowNumber, 2];
                cells.Value = selectedWingDetails.Land;
                cells = worKsheeT.Cells[rowNumber, 3];
                cells.Value = "SQ.MTR";

                cells = worKsheeT.Cells[rowNumber, 4];
                cells.Value = "TOTAL.:-";
                cells.Interior.Color = Color.FromArgb(252, 213, 180);
                cells = worKsheeT.Cells[rowNumber, 5];
                cells.Value = selectedWingDetails.Total;
                cells = worKsheeT.Cells[rowNumber, 6];
                cells.Value = "SQ.MTR";

                cells = worKsheeT.Cells[rowNumber, 7];
                cells.Value = "AMT.:-";
                cells.Interior.Color = Color.FromArgb(252, 213, 180);
                cells = worKsheeT.Cells[rowNumber, 8];
                cells.Value = selectedWingDetails.Amount;

                rowNumber = 8;
                cells = worKsheeT.Cells[rowNumber, 1];
                cells.Value = "CARPET.:-";
                cells.Interior.Color = Color.FromArgb(252, 213, 180);
                cells = worKsheeT.Cells[rowNumber, 2];
                cells.Value = selectedWingDetails.Carpet;
                cells = worKsheeT.Cells[rowNumber, 3];
                cells.Value = "SQ.MTR";

                cells = worKsheeT.Cells[rowNumber, 4];
                cells.Value = "W/B.:-";
                cells.Interior.Color = Color.FromArgb(252, 213, 180);
                cells = worKsheeT.Cells[rowNumber, 5];
                cells.Value = selectedWingDetails.WB;
                cells = worKsheeT.Cells[rowNumber, 6];
                cells.Value = "SQ.MTR";

                cells = worKsheeT.Cells[rowNumber, 7];
                cells.Value = "RELIGION.:-";
                cells.Interior.Color = Color.FromArgb(252, 213, 180);
                cells = worKsheeT.Cells[rowNumber, 8];
                cells.Value = "N/A";

                rowNumber = 9;
                cells = worKsheeT.Cells[rowNumber, 1];
                cells.Value = "NAME.:-";
                worKsheeT.Range[worKsheeT.Cells[rowNumber, 1], worKsheeT.Cells[rowNumber+1, 1]].Merge();
                cells.Interior.Color = Color.FromArgb(252, 213, 180);
                cells = worKsheeT.Cells[rowNumber, 2];
                cells.Value = selectedCustomer.FirstOrDefault().Customer_Name;
                worKsheeT.Range[worKsheeT.Cells[rowNumber, 2], worKsheeT.Cells[rowNumber + 1, 5]].Merge();
                cells = worKsheeT.Cells[rowNumber, 6];
                cells.Value = "OCCUPATION.:-";
                worKsheeT.Range[worKsheeT.Cells[rowNumber, 6], worKsheeT.Cells[rowNumber , 7]].Merge();

                rowNumber = 10;
                cells = worKsheeT.Cells[rowNumber, 6];
                cells.Value = "BANKHAT No.:-";
                worKsheeT.Range[worKsheeT.Cells[rowNumber, 6], worKsheeT.Cells[rowNumber , 7]].Merge();
                cells = worKsheeT.Cells[rowNumber, 8];
                cells.Value = selectedCustomer.FirstOrDefault().BanakhatNo;

                rowNumber = 11;
                cells = worKsheeT.Cells[rowNumber, 1];
                cells.Value = "PAN.NO.:-";
                cells.Interior.Color = Color.FromArgb(252, 213, 180);
                cells = worKsheeT.Cells[rowNumber, 2];
                cells.Value = selectedCustomer?.FirstOrDefault().Pan;
                worKsheeT.Range[worKsheeT.Cells[rowNumber, 2], worKsheeT.Cells[rowNumber, 5]].Merge();
                cells = worKsheeT.Cells[rowNumber, 7];
                cells.Value = "DATE.:-";
                cells = worKsheeT.Cells[rowNumber, 8];
                cells.Value = selectedCustomer.FirstOrDefault().BanakhatDate;

                rowNumber = 12;
                cells = worKsheeT.Cells[rowNumber, 1];
                cells.Value = "ADHAR NO.:-";
                cells.Interior.Color = Color.FromArgb(252, 213, 180);
                cells = worKsheeT.Cells[rowNumber, 2];
                cells.Value = selectedCustomer?.FirstOrDefault().Aadhar;
                worKsheeT.Range[worKsheeT.Cells[rowNumber, 2], worKsheeT.Cells[rowNumber, 5]].Merge();

                if (!string.IsNullOrEmpty(selectedCustomer.FirstOrDefault().Customer1))
                {
                    rowNumber += 1;
                    cells = worKsheeT.Cells[rowNumber, 1];
                    cells.Value = "NAME.:-";
                    cells.Interior.Color = Color.FromArgb(252, 213, 180);
                    cells = worKsheeT.Cells[rowNumber, 2];
                    cells.Value = selectedCustomer.FirstOrDefault().Customer1;
                    worKsheeT.Range[worKsheeT.Cells[rowNumber, 2], worKsheeT.Cells[rowNumber, 5]].Merge();
                    cells = worKsheeT.Cells[rowNumber, 6];
                    cells.Value = "OCCUPATION.:-";
                    worKsheeT.Range[worKsheeT.Cells[rowNumber, 6], worKsheeT.Cells[rowNumber , 7]].Merge();

                    rowNumber += 1;
                    cells = worKsheeT.Cells[rowNumber, 1];
                    cells.Value = "PAN.NO.:-";
                    cells.Interior.Color = Color.FromArgb(252, 213, 180);
                    cells = worKsheeT.Cells[rowNumber, 2];
                    cells.Value = selectedCustomer?.FirstOrDefault().Pan1;
                    worKsheeT.Range[worKsheeT.Cells[rowNumber, 2], worKsheeT.Cells[rowNumber, 5]].Merge();
                    cells = worKsheeT.Cells[rowNumber, 6];

                    rowNumber += 1;
                    cells = worKsheeT.Cells[rowNumber, 1];
                    cells.Value = "ADHAR NO.:-";
                    cells.Interior.Color = Color.FromArgb(252, 213, 180);
                    cells = worKsheeT.Cells[rowNumber, 2];
                    cells.Value = selectedCustomer?.FirstOrDefault().Aadhar1;
                    worKsheeT.Range[worKsheeT.Cells[rowNumber, 2], worKsheeT.Cells[rowNumber, 5]].Merge();
                }
                if (!string.IsNullOrEmpty(selectedCustomer.FirstOrDefault().Customer2))
                {
                    rowNumber += 1;
                    cells = worKsheeT.Cells[rowNumber, 1];
                    cells.Value = "NAME.:-";
                    cells.Interior.Color = Color.FromArgb(252, 213, 180);
                    cells = worKsheeT.Cells[rowNumber, 2];
                    cells.Value = selectedCustomer.FirstOrDefault().Customer2;
                    worKsheeT.Range[worKsheeT.Cells[rowNumber, 2], worKsheeT.Cells[rowNumber, 5]].Merge();
                    cells = worKsheeT.Cells[rowNumber, 6];
                    cells.Value = "OCCUPATION.:-";
                    worKsheeT.Range[worKsheeT.Cells[rowNumber, 6], worKsheeT.Cells[rowNumber, 7]].Merge();

                    rowNumber += 1;
                    cells = worKsheeT.Cells[rowNumber, 1];
                    cells.Value = "PAN.NO.:-";
                    cells.Interior.Color = Color.FromArgb(252, 213, 180);
                    cells = worKsheeT.Cells[rowNumber, 2];
                    cells.Value = selectedCustomer?.FirstOrDefault().Pan2;
                    worKsheeT.Range[worKsheeT.Cells[rowNumber, 2], worKsheeT.Cells[rowNumber, 5]].Merge();
                    cells = worKsheeT.Cells[rowNumber, 6];

                    rowNumber += 1;
                    cells = worKsheeT.Cells[rowNumber, 1];
                    cells.Value = "ADHAR NO.:-";
                    cells.Interior.Color = Color.FromArgb(252, 213, 180);
                    cells = worKsheeT.Cells[rowNumber, 2];
                    cells.Value = selectedCustomer?.FirstOrDefault().Aadhar2;
                    worKsheeT.Range[worKsheeT.Cells[rowNumber, 2], worKsheeT.Cells[rowNumber, 5]].Merge();
                }
                if (!string.IsNullOrEmpty(selectedCustomer.FirstOrDefault().Customer3))
                {
                    rowNumber += 1;
                    cells = worKsheeT.Cells[rowNumber, 1];
                    cells.Value = "NAME.:-";
                    cells.Interior.Color = Color.FromArgb(252, 213, 180);
                    cells = worKsheeT.Cells[rowNumber, 2];
                    cells.Value = selectedCustomer.FirstOrDefault().Customer3;
                    worKsheeT.Range[worKsheeT.Cells[rowNumber, 2], worKsheeT.Cells[rowNumber, 5]].Merge();
                    cells = worKsheeT.Cells[rowNumber, 6];
                    cells.Value = "OCCUPATION.:-";
                    worKsheeT.Range[worKsheeT.Cells[rowNumber, 6], worKsheeT.Cells[rowNumber, 7]].Merge();

                    rowNumber += 1;
                    cells = worKsheeT.Cells[rowNumber, 1];
                    cells.Value = "PAN.NO.:-";
                    cells.Interior.Color = Color.FromArgb(252, 213, 180);
                    cells = worKsheeT.Cells[rowNumber, 2];
                    cells.Value = selectedCustomer?.FirstOrDefault().Pan3;
                    cells = worKsheeT.Cells[rowNumber, 6];
                    worKsheeT.Range[worKsheeT.Cells[rowNumber, 2], worKsheeT.Cells[rowNumber, 5]].Merge();

                    rowNumber += 1;
                    cells = worKsheeT.Cells[rowNumber, 1];
                    cells.Value = "ADHAR NO.:-";
                    cells.Interior.Color = Color.FromArgb(252, 213, 180);
                    cells = worKsheeT.Cells[rowNumber, 2];
                    cells.Value = selectedCustomer?.FirstOrDefault().Aadhar3;
                    worKsheeT.Range[worKsheeT.Cells[rowNumber, 2], worKsheeT.Cells[rowNumber, 5]].Merge();
                }
                rowNumber += 1;
                cells = worKsheeT.Cells[rowNumber, 1];
                cells.Value = "ADDRESS.:-";
                cells.Interior.Color = Color.FromArgb(252, 213, 180);
                cells = worKsheeT.Cells[rowNumber, 2];
                cells.Value = selectedCustomer?.FirstOrDefault().Address;
                worKsheeT.Range[worKsheeT.Cells[rowNumber, 2], worKsheeT.Cells[rowNumber+3, 6]].Merge();

                rowNumber += 4;
                cells = worKsheeT.Cells[rowNumber, 1];
                cells.Value = "AMT";
                cells.Interior.Color = Color.FromArgb(252, 213, 180);
                cells = worKsheeT.Cells[rowNumber, 2];
                cells.Value = "BANK";
                cells.Interior.Color = Color.FromArgb(252, 213, 180);
                worKsheeT.Range[worKsheeT.Cells[rowNumber, 2], worKsheeT.Cells[rowNumber, 5]].Merge();
                cells = worKsheeT.Cells[rowNumber, 6];
                cells.Value = "BRANCH";
                cells.Interior.Color = Color.FromArgb(252, 213, 180);
                cells = worKsheeT.Cells[rowNumber, 7];
                cells.Value = "CH./RTGS.NO";
                cells.Interior.Color = Color.FromArgb(252, 213, 180);
                cells = worKsheeT.Cells[rowNumber, 8];
                cells.Value = "DATE";
                cells.Interior.Color = Color.FromArgb(252, 213, 180);
                decimal totalReceiptAmount = 0;
                foreach (var receipt in selectReceiptDetails)
                {
                    rowNumber += 1;
                    cells = worKsheeT.Cells[rowNumber, 1];
                    cells.Value = receipt.Amount.ToString();
                    cells = worKsheeT.Cells[rowNumber, 2];
                    cells.Value = receipt.Bank_Name;
                    worKsheeT.Range[worKsheeT.Cells[rowNumber, 2], worKsheeT.Cells[rowNumber, 5]].Merge();
                    cells = worKsheeT.Cells[rowNumber, 6];
                    cells.Value = receipt.Branch_Name;
                    cells = worKsheeT.Cells[rowNumber, 7];
                    cells.Value = receipt.Cheq_Rtgs_Neft_ImpsNo;
                    cells = worKsheeT.Cells[rowNumber, 8];
                    cells.Value = receipt.PaymentDate.ToString().Replace("/", ".");
                    totalReceiptAmount = totalReceiptAmount + receipt.Amount;
                }

                rowNumber += 1;
                cells = worKsheeT.Cells[rowNumber, 1];
                cells.Value = totalReceiptAmount;
                cells = worKsheeT.Cells[rowNumber, 2];
                cells.Value = (totalReceiptAmount - selectedWingDetails.Amount);

                rowNumber += 1;
                cells = worKsheeT.Cells[rowNumber, 1];
                cells.Value = "ALL BOUNDRIES  DETAIL :-";
                cells.Interior.Color = Color.FromArgb(252, 213, 180);
                worKsheeT.Range[worKsheeT.Cells[rowNumber, 1], worKsheeT.Cells[rowNumber, 8]].Merge();

                rowNumber += 1;
                cells = worKsheeT.Cells[rowNumber, 1];
                cells.Value = "EAST";
                cells.Interior.Color = Color.FromArgb(252, 213, 180);
                cells = worKsheeT.Cells[rowNumber, 2];
                cells.Value = selectedWingDetails.EAST;
                worKsheeT.Range[worKsheeT.Cells[rowNumber, 2], worKsheeT.Cells[rowNumber, 5]].Merge();

                rowNumber += 1;
                cells = worKsheeT.Cells[rowNumber, 1];
                cells.Value = "WEST";
                cells.Interior.Color = Color.FromArgb(252, 213, 180);
                cells = worKsheeT.Cells[rowNumber, 2];
                cells.Value = selectedWingDetails.WEST;
                worKsheeT.Range[worKsheeT.Cells[rowNumber, 2], worKsheeT.Cells[rowNumber, 5]].Merge();

                rowNumber += 1;
                cells = worKsheeT.Cells[rowNumber, 1];
                cells.Value = "NORTH";
                cells.Interior.Color = Color.FromArgb(252, 213, 180);
                cells = worKsheeT.Cells[rowNumber, 2];
                cells.Value = selectedWingDetails.NORTH;
                worKsheeT.Range[worKsheeT.Cells[rowNumber, 2], worKsheeT.Cells[rowNumber, 5]].Merge();

                rowNumber += 1;
                cells = worKsheeT.Cells[rowNumber, 1];
                cells.Value = "SOUTH";
                cells.Interior.Color = Color.FromArgb(252, 213, 180);
                cells = worKsheeT.Cells[rowNumber, 2];
                cells.Value = selectedWingDetails.SOUTH;
                worKsheeT.Range[worKsheeT.Cells[rowNumber, 2], worKsheeT.Cells[rowNumber, 5]].Merge();

                #region Set Border 
                int borderRowNumber = 4;
                var range=worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 1], worKsheeT.Cells[borderRowNumber, 8]];
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                range.Borders.Color = Color.Black;

                borderRowNumber = borderRowNumber + 1;
                range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 1], worKsheeT.Cells[borderRowNumber, 8]];
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                range.Borders.Color = Color.Black;

                borderRowNumber = borderRowNumber + 1;
                range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 1], worKsheeT.Cells[borderRowNumber+13, 1]];
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                range.Borders.Color = Color.Black;

                range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 2], worKsheeT.Cells[borderRowNumber + 3, 8]];
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                range.Borders.Color = Color.Black;

                borderRowNumber = borderRowNumber + 1;
                range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 2], worKsheeT.Cells[borderRowNumber+1, 5]];
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                range.Borders.Color = Color.Black;

                range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 6], worKsheeT.Cells[borderRowNumber, 7]];
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                range.Borders.Color = Color.Black;
                range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 8], worKsheeT.Cells[borderRowNumber, 8]];
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                range.Borders.Color = Color.Black;
                borderRowNumber = borderRowNumber + 1;
                range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 6], worKsheeT.Cells[borderRowNumber, 7]];
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                range.Borders.Color = Color.Black;
                range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 8], worKsheeT.Cells[borderRowNumber, 8]];
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                range.Borders.Color = Color.Black;

                borderRowNumber = borderRowNumber + 1;
                range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 2], worKsheeT.Cells[borderRowNumber, 5]];
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                range.Borders.Color = Color.Black;
                range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 6], worKsheeT.Cells[borderRowNumber, 7]];
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                range.Borders.Color = Color.Black;
                range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 8], worKsheeT.Cells[borderRowNumber, 8]];
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                range.Borders.Color = Color.Black;

                borderRowNumber = borderRowNumber + 1;
                range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 2], worKsheeT.Cells[borderRowNumber, 5]];
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                range.Borders.Color = Color.Black;
                range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 6], worKsheeT.Cells[borderRowNumber, 8]];
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                range.Borders.Color = Color.Black;

                int intCust = 0;
                if(!string.IsNullOrWhiteSpace(selectedCustomer.FirstOrDefault().Customer1))
                {
                    AddCustomer:
                    borderRowNumber = borderRowNumber + 1;
                    range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 2], worKsheeT.Cells[borderRowNumber, 5]];
                    range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders.Color = Color.Black;
                    range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 6], worKsheeT.Cells[borderRowNumber, 7]];
                    range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders.Color = Color.Black;
                    range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 8], worKsheeT.Cells[borderRowNumber, 8]];
                    range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders.Color = Color.Black;

                    borderRowNumber = borderRowNumber + 1;
                    range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 2], worKsheeT.Cells[borderRowNumber, 5]];
                    range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders.Color = Color.Black;

                    borderRowNumber = borderRowNumber + 1;
                    range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 2], worKsheeT.Cells[borderRowNumber, 5]];
                    range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders.Color = Color.Black;
                    range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 6], worKsheeT.Cells[borderRowNumber, 8]];
                    range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders.Color = Color.Black;
                    if (!string.IsNullOrWhiteSpace(Convert.ToString(selectedCustomer.FirstOrDefault().Customer2)) && intCust == 0)
                    {
                        intCust = 2;
                        goto AddCustomer;
                    }
                    if(string.IsNullOrWhiteSpace(Convert.ToString(selectedCustomer.FirstOrDefault().Customer3)) && intCust<3)
                    {
                        intCust = 3;
                        goto AddCustomer;
                    }
                }


                borderRowNumber = borderRowNumber + 1;
                range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 2], worKsheeT.Cells[borderRowNumber, 5]];
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                range.Borders.Color = Color.Black;
                range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 6], worKsheeT.Cells[borderRowNumber, 7]];
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                range.Borders.Color = Color.Black;
                range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 8], worKsheeT.Cells[borderRowNumber, 8]];
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                range.Borders.Color = Color.Black;

                borderRowNumber = borderRowNumber + 1;
                range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 2], worKsheeT.Cells[borderRowNumber, 5]];
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                range.Borders.Color = Color.Black;
                borderRowNumber = borderRowNumber + 1;
                range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 2], worKsheeT.Cells[borderRowNumber, 5]];
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                range.Borders.Color = Color.Black;

                borderRowNumber = borderRowNumber + 1;
                range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 2], worKsheeT.Cells[borderRowNumber+3, 6]];
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                range.Borders.Color = Color.Black;

                borderRowNumber = borderRowNumber + 4;
                range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 1], worKsheeT.Cells[borderRowNumber ,1]];
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                range.Borders.Color = Color.Black;
                range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 2], worKsheeT.Cells[borderRowNumber, 5]];
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                range.Borders.Color = Color.Black;
                range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 6], worKsheeT.Cells[borderRowNumber, 6]];
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                range.Borders.Color = Color.Black;
                range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 7], worKsheeT.Cells[borderRowNumber, 7]];
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                range.Borders.Color = Color.Black;
                range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 8], worKsheeT.Cells[borderRowNumber, 8]];
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                range.Borders.Color = Color.Black;
                borderRowNumber = borderRowNumber + 1;
                foreach (var rec in selectReceiptDetails)
                {
                    range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 1], worKsheeT.Cells[borderRowNumber, 8]];
                    range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders.Color = Color.Black;
                    borderRowNumber = borderRowNumber + 1;
                }
                //int lastBorder = borderRowNumber;
                //borderRowNumber = borderRowNumber + selectReceiptDetails.Count();
                //borderRowNumber = borderRowNumber + 3;
                range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 1], worKsheeT.Cells[borderRowNumber, 8]];
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                range.Borders.Color = Color.Black;
                borderRowNumber = borderRowNumber + 1;
                range = worKsheeT.Range[worKsheeT.Cells[borderRowNumber, 1], worKsheeT.Cells[borderRowNumber+3, 5]];
                range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                range.Borders.Color = Color.Black;
                borderRowNumber = borderRowNumber + 1;
                #endregion

                worKbooK.SaveAs(CustomerFileName);
                worKbooK.Close();
                MyApp.Quit();
                MyApp = null;
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, "frmBanakhatList.CreateExcelBanakhat");
            }
        }

        private async Task CreateExcelFile(int CustomerId)
        {
            try
            {
                string MasterFilePath = ClsUtil.getCurrentPath() + @"MasterCopyBanakhat.xlsx";
                string dirName = ClsUtil.getdesktopPath()+@"BANAKHAT\" + DateTime.Now.ToString("dd_MM_yyyy");
                if(!System.IO.Directory.Exists(ClsUtil.getdesktopPath() + @"BANAKHAT\"))
                {
                    System.IO.Directory.CreateDirectory(ClsUtil.getdesktopPath() + @"BANAKHAT\");
                }
                if (!System.IO.Directory.Exists(dirName))
                {
                    System.IO.Directory.CreateDirectory(dirName);
                }

                var selectedCustomer = await BACustomerMaster.GetCustomer(CustomerId);
                var wingDetails = await BaWingMaster.GetWingDetails(selectedCustomer.FirstOrDefault().Wing_Master_Id);
                var selectedWingDetails = wingDetails.AsEnumerable().Where(x => x.Wing_DetailsId == selectedCustomer.FirstOrDefault().Wing_Details_Id).FirstOrDefault();
                var selectReceiptDetails = await BAReceiptDetails.GetReceiptByCustomer(selectedCustomer.FirstOrDefault().Customer_Id);


                string CustomerFileName = dirName + @"\" + selectedWingDetails.Wing_Name + "-" + selectedWingDetails.FlatNo + " " + selectedCustomer.FirstOrDefault().Customer_Name + ".xlsx";
                System.IO.File.Copy(MasterFilePath, CustomerFileName);

                Microsoft.Office.Interop.Excel.Application MyApp = new Microsoft.Office.Interop.Excel.Application();
                System.Threading.Thread.Sleep(1000);
                MyApp.Visible = false;
                var xlBook = MyApp.Workbooks.Open(CustomerFileName);
                var xlSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlBook.Worksheets.get_Item(1);

                xlSheet.Cells[6, 2].Value = selectedWingDetails.FlatNo;
                xlSheet.Cells[6, 6].Value = selectedWingDetails.Wing_Name;
                xlSheet.Cells[6, 8].Value = selectedWingDetails.FlorName;

                xlSheet.Cells[7, 2].Value = selectedWingDetails.Land;
                xlSheet.Cells[8, 2].Value = selectedWingDetails.Carpet;
                xlSheet.Cells[7, 5].Value = selectedWingDetails.Total;
                xlSheet.Cells[8, 5].Value = selectedWingDetails.WB;
                xlSheet.Cells[7, 8].Value = selectedWingDetails.Amount;

                xlSheet.Cells[9, 2].Value = selectedCustomer.FirstOrDefault().Customer_Name;
                xlSheet.Cells[9, 8].Value = selectedCustomer.FirstOrDefault().Ocupation;
                xlSheet.Cells[10, 8].Value = selectedCustomer.FirstOrDefault().BanakhatNo;
                xlSheet.Cells[11, 8].Value = selectedCustomer.FirstOrDefault().BanakhatDate;
                xlSheet.Cells[11, 2].Value = selectedCustomer.FirstOrDefault().Pan;
                xlSheet.Cells[12, 2].Value = selectedCustomer.FirstOrDefault().Aadhar;

                if (!string.IsNullOrEmpty(Convert.ToString(selectedCustomer.FirstOrDefault().Customer1)))
                {
                    xlSheet.Cells[13, 2].Value = selectedCustomer.FirstOrDefault().Customer1;
                    xlSheet.Cells[13, 8].Value = selectedCustomer.FirstOrDefault().Ocupation1;
                    xlSheet.Cells[15, 2].Value = selectedCustomer.FirstOrDefault().Pan1;
                    xlSheet.Cells[16, 2].Value = selectedCustomer.FirstOrDefault().Aadhar1;
                }
                if (!string.IsNullOrEmpty(Convert.ToString(selectedCustomer.FirstOrDefault().Customer2)))
                {
                    Range line = (Range)xlSheet.Rows[16];
                    line.Insert();
                    xlSheet.Cells[17, 1].Value = "NAME:-";
                    xlSheet.Cells[17, 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(252, 213, 180));
                    line = (Range)xlSheet.Rows[17];
                    line.Insert();
                    line = (Range)xlSheet.Rows[18];
                    line.Insert();
                    xlSheet.Cells[18, 1].Value = "PAN NO.:-";
                    xlSheet.Cells[18, 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(252, 213, 180));
                    line = (Range)xlSheet.Rows[19];
                    line.Insert();
                    xlSheet.Cells[19, 1].Value = "ADHAR NO.:-";
                    xlSheet.Cells[19, 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(252, 213, 180));

                    xlSheet.Cells[17, 2].Value = selectedCustomer.FirstOrDefault().Customer2;
                    xlSheet.Cells[17, 8].Value = selectedCustomer.FirstOrDefault().Ocupation2;
                    xlSheet.Cells[19, 2].Value = selectedCustomer.FirstOrDefault().Pan2;
                    xlSheet.Cells[20, 2].Value = selectedCustomer.FirstOrDefault().Aadhar2;
                }
                if (!string.IsNullOrEmpty(Convert.ToString(selectedCustomer.FirstOrDefault().Customer3)))
                {
                    Range line = (Range)xlSheet.Rows[16];
                    line.Insert();
                    xlSheet.Cells[17, 1].Value = "NAME:-";
                    xlSheet.Cells[17, 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(252, 213, 180));
                    line = (Range)xlSheet.Rows[17];
                    line.Insert();
                    line = (Range)xlSheet.Rows[18];
                    line.Insert();
                    xlSheet.Cells[18, 1].Value = "PAN NO.:-";
                    xlSheet.Cells[18, 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(252, 213, 180));
                    line = (Range)xlSheet.Rows[19];
                    line.Insert();
                    xlSheet.Cells[19, 1].Value = "ADHAR NO.:-";
                    xlSheet.Cells[19, 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(252, 213, 180));

                    xlSheet.Cells[17, 2].Value = selectedCustomer.FirstOrDefault().Customer3;
                    xlSheet.Cells[17, 8].Value = selectedCustomer.FirstOrDefault().Ocupation3;
                    xlSheet.Cells[19, 2].Value = selectedCustomer.FirstOrDefault().Pan3;
                    xlSheet.Cells[20, 2].Value = selectedCustomer.FirstOrDefault().Aadhar3;
                }
                decimal TotalAmount = 0;
                int rowNumber = 23;
                foreach (EnReceiptDetails rec in selectReceiptDetails)
                {
                    xlSheet.Cells[rowNumber, 1].Value = rec.Amount;
                    xlSheet.Cells[rowNumber, 2].Value = rec.Bank_Name;
                    xlSheet.Cells[rowNumber, 6].Value = rec.Branch_Name;
                    xlSheet.Cells[rowNumber, 7].Value = rec.Cheq_Rtgs_Neft_ImpsNo;
                    xlSheet.Cells[rowNumber, 8].Value = rec.Receipt_Date.Replace("/", ".");

                    TotalAmount = TotalAmount + rec.Amount;
                    rowNumber = rowNumber + 1;
                    if (rowNumber == 28)
                    {
                        Range line = (Range)xlSheet.Rows[28];
                        line.Insert();
                    }
                }
                decimal pendingAmount = selectedWingDetails.Amount - TotalAmount;
                
                xlSheet.Cells[rowNumber, 1].Value = TotalAmount.ToString();
                xlSheet.Cells[rowNumber, 2].Value = pendingAmount.ToString();
                rowNumber = 17;
                xlSheet.Cells[rowNumber, 2].Value = selectedCustomer.FirstOrDefault().Address;
                rowNumber = 31;
                xlSheet.Cells[rowNumber, 2].Value = selectedWingDetails.EAST;
                rowNumber = rowNumber + 1;
                xlSheet.Cells[rowNumber, 2].Value = selectedWingDetails.WEST;
                rowNumber = rowNumber + 1;
                xlSheet.Cells[rowNumber, 2].Value = selectedWingDetails.NORTH;
                rowNumber = rowNumber + 1;
                xlSheet.Cells[rowNumber, 2].Value = selectedWingDetails.SOUTH;
                rowNumber = rowNumber + 1;

                xlSheet.Cells[17, 2].Value = selectedCustomer.FirstOrDefault().Address;


                xlBook.Save();
                xlBook.Close();
                MyApp.Quit();
                MyApp = null;
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Module.Name);
            }
        }

        private async Task CreateHTMLFile(int CustomerId)
        {
            try
            {
                htmlFilePath = "";
                StringBuilder strNewHTMLFile = new StringBuilder();
                var selectedCustomer = await BACustomerMaster.GetCustomer(CustomerId);
                var wingDetails = await BaWingMaster.GetWingDetails(selectedCustomer.FirstOrDefault().Wing_Master_Id);
                var selectedWingDetails = wingDetails.AsEnumerable().Where(x => x.Wing_DetailsId == selectedCustomer.FirstOrDefault().Wing_Details_Id).FirstOrDefault();
                var selectReceiptDetails = await BAReceiptDetails.GetReceiptByCustomer(selectedCustomer.FirstOrDefault().Customer_Id);
                strNewHTMLFile.AppendLine(@"<html>");
                strNewHTMLFile.AppendLine(@"<body>");
                strNewHTMLFile.AppendLine(@"<table border='1' cellpadding = '1' cellspacing = '1' style = 'width:100%' > ");
                strNewHTMLFile.AppendLine(@"	<tbody>");
                strNewHTMLFile.AppendLine(@"		<tr>");
                strNewHTMLFile.AppendLine(@"			<td style='text-align:center'><strong>KARNAVATI APARTMENT - 6</strong></td>");
                strNewHTMLFile.AppendLine(@"		</tr>");
                strNewHTMLFile.AppendLine(@"		<tr>");
                strNewHTMLFile.AppendLine(@"			<td style='text-align:center'><strong>REG. BANAKHAT</strong></td>");
                strNewHTMLFile.AppendLine(@"		</tr>");
                strNewHTMLFile.AppendLine(@"		<tr>");
                strNewHTMLFile.AppendLine(@"			<td>");
                strNewHTMLFile.AppendLine(@"			<table border='1' cellpadding = '1' cellspacing='1' style='width: 100%'>");
                strNewHTMLFile.AppendLine(@"				<tbody>");
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td style='width:108px;background-color:#E8E8E8;'><strong>FLAT NO.:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td colspan='2' rowspan = '1' style = 'text-align:center; width:226px' >" + selectedCustomer.FirstOrDefault().Wing_Name + "-" + selectedCustomer.FirstOrDefault().FlatNo + "</td> ");
                strNewHTMLFile.AppendLine(@"						<td style='width:95px;background-color:#E8E8E8;'><strong>BLOCK.:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td colspan='2' rowspan = '1' style = 'text-align:center; width:340px' > " + selectedCustomer.FirstOrDefault().Wing_Name + " </ td > ");
                strNewHTMLFile.AppendLine(@"						<td style='width:225px;background-color:#E8E8E8;'><strong>FLOOR.:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:168px'>" + selectedWingDetails.FlorName.ToUpper() + "</td>");
                strNewHTMLFile.AppendLine(@"					</tr>");
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td style='width:108px;background-color:#E8E8E8;'><strong>LAND.:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:89px'>" + selectedWingDetails.Land.ToString() + "</td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:132px'>SQ.MTR</td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:95px;background-color:#E8E8E8;'><strong>TOTAL.:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:167px'>" + selectedWingDetails.Total.ToString() + "</td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:168px'>SQ.MTR</td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:225px;background-color:#E8E8E8;'><strong>AMT.:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:168px'>" + selectedWingDetails.Amount.ToString() + "</td>");
                strNewHTMLFile.AppendLine(@"					</tr>");
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td style='width:108px;background-color:#E8E8E8;'><strong>CARPET.:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:89px'>" + selectedWingDetails.Carpet.ToString() + "</td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:132px'>SQ.MTR</td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:95px;background-color:#E8E8E8;'><strong>W/B</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:167px'>" + selectedWingDetails.WB.ToString() + "</td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:168px'>SQ.MTR</td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:225px;background-color:#E8E8E8;'><strong>RELIGION.:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:168px'>HINDU</td>");
                strNewHTMLFile.AppendLine(@"					</tr>");
                strNewHTMLFile.AppendLine(@"				</tbody>");
                strNewHTMLFile.AppendLine(@"			</table>");
                strNewHTMLFile.AppendLine(@"");
                strNewHTMLFile.AppendLine(@"			<table border='1' cellpadding='1' cellspacing='1' style='width:100%'>");
                strNewHTMLFile.AppendLine(@"				<tbody>");
                if (!string.IsNullOrWhiteSpace(selectedCustomer.FirstOrDefault().Customer1))
                {
                    strNewHTMLFile.AppendLine(@"					<tr>");
                    strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8; width:185px;'><strong>NAME.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td colspan='1' rowspan='2'>" + selectedCustomer.FirstOrDefault().Customer1 + "</td>");
                    strNewHTMLFile.AppendLine(@"						<td ><strong>OCCUPATION.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td >N/A</td>");
                    strNewHTMLFile.AppendLine(@"					</tr>");
                    strNewHTMLFile.AppendLine(@"					<tr>");
                    strNewHTMLFile.AppendLine(@"						<td style='width:185px;'>&nbsp;</td>");
                    strNewHTMLFile.AppendLine(@"						<td><strong>BANAKHAT. NO.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td>N/A</td>");
                    strNewHTMLFile.AppendLine(@"					</tr>");
                    strNewHTMLFile.AppendLine(@"					<tr>");
                    strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8; width:185px;'><strong>PAN NO.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td>" + selectedCustomer.FirstOrDefault().Pan1 + "</td>");
                    strNewHTMLFile.AppendLine(@"						<td><strong>DATE:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td>&nbsp;</td>");
                    strNewHTMLFile.AppendLine(@"					</tr>");
                    strNewHTMLFile.AppendLine(@"					<tr>");
                    strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8; width:185px;'><strong>ADHAR NO.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td colspan='3' rowspan = '1' > " + selectedCustomer.FirstOrDefault().Aadhar1 + " </ td > ");
                    strNewHTMLFile.AppendLine(@"					</tr>");
                }
                if (!string.IsNullOrWhiteSpace(selectedCustomer.FirstOrDefault().Customer2))
                {
                    strNewHTMLFile.AppendLine(@"					<tr>");
                    strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8; width:185px;'><strong>NAME.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td colspan='1' rowspan='2'>" + selectedCustomer.FirstOrDefault().Customer2 + "</td>");
                    strNewHTMLFile.AppendLine(@"						<td><strong>OCCUPATION.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td>N/A</td>");
                    strNewHTMLFile.AppendLine(@"					</tr>");
                    strNewHTMLFile.AppendLine(@"					<tr>");
                    strNewHTMLFile.AppendLine(@"						<td style='width:185px;'>&nbsp;</td>");
                    strNewHTMLFile.AppendLine(@"						<td><strong>BANAKHAT. NO.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td>N/A</td>");
                    strNewHTMLFile.AppendLine(@"					</tr>");
                    strNewHTMLFile.AppendLine(@"					<tr>");
                    strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8; width:185px;'><strong>PAN NO.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td>" + selectedCustomer.FirstOrDefault().Pan2 + "</td>");
                    strNewHTMLFile.AppendLine(@"						<td><strong>DATE:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td>&nbsp;</td>");
                    strNewHTMLFile.AppendLine(@"					</tr>");
                    strNewHTMLFile.AppendLine(@"					<tr>");
                    strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8; width:185px;'><strong>ADHAR NO.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td colspan='3' rowspan = '1' > " + selectedCustomer.FirstOrDefault().Aadhar2 + "</td>");
                    strNewHTMLFile.AppendLine(@"					</tr>");
                }
                if (!string.IsNullOrWhiteSpace(selectedCustomer.FirstOrDefault().Customer3))
                {
                    strNewHTMLFile.AppendLine(@"					<tr>");
                    strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8; width:185px;'><strong>NAME.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td colspan='1' rowspan='2'>" + selectedCustomer.FirstOrDefault().Customer3 + "</td>");
                    strNewHTMLFile.AppendLine(@"						<td><strong>OCCUPATION.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td>N/A</td>");
                    strNewHTMLFile.AppendLine(@"					</tr>");
                    strNewHTMLFile.AppendLine(@"					<tr>");
                    strNewHTMLFile.AppendLine(@"						<td style='width:185px;'>&nbsp;</td>");
                    strNewHTMLFile.AppendLine(@"						<td><strong>BANAKHAT. NO.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td>N/A</td>");
                    strNewHTMLFile.AppendLine(@"					</tr>");
                    strNewHTMLFile.AppendLine(@"					<tr>");
                    strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8; width:185px;'><strong>PAN NO.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td>" + selectedCustomer.FirstOrDefault().Pan3 + "</td>");
                    strNewHTMLFile.AppendLine(@"						<td><strong>DATE:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td>&nbsp;</td>");
                    strNewHTMLFile.AppendLine(@"					</tr>");
                    strNewHTMLFile.AppendLine(@"					<tr>");
                    strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8; width:185px;'><strong>ADHAR NO.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td colspan='3' rowspan = '1' > " + selectedCustomer.FirstOrDefault().Aadhar3 + "</ td > ");
                    strNewHTMLFile.AppendLine(@"					</tr>");
                }
                if (!string.IsNullOrWhiteSpace(selectedCustomer.FirstOrDefault().Address))
                {
                    strNewHTMLFile.AppendLine(@"					<tr>");
                    strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8; width:185px;'><strong>ADDRESS.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td colspan='3' rowspan='2'>" + selectedCustomer.FirstOrDefault().Address.ToUpper() + "</td>");
                    strNewHTMLFile.AppendLine(@"					</tr>");
                }
                strNewHTMLFile.AppendLine(@"				</tbody>");
                strNewHTMLFile.AppendLine(@"			</table>");
                strNewHTMLFile.AppendLine(@"			</td>");
                strNewHTMLFile.AppendLine(@"		</tr>");
                strNewHTMLFile.AppendLine(@"		<tr>");
                strNewHTMLFile.AppendLine(@"			<td>");
                strNewHTMLFile.AppendLine(@"			<table border='1' cellpadding = '1' cellspacing = '1' style = 'width:100%' > ");
                strNewHTMLFile.AppendLine(@"				<tbody>");
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td style='text-align:center;background-color:#E8E8E8; width:128px;'><strong>AMT.</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='text-align:center; width:404px;background-color:#E8E8E8;'><strong>BANK</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='text-align:center; width:229px;background-color:#E8E8E8;'><strong>BRANCH</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='text-align:center; width:232px;background-color:#E8E8E8;'><strong>CH./RTGS. NO.</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='text-align:center; width:144px;background-color:#E8E8E8;'><strong>DATE</strong></td>");
                strNewHTMLFile.AppendLine(@"					</tr>");
                decimal TotalAmount = 0;
                foreach (var receipt in selectReceiptDetails)
                {
                    strNewHTMLFile.AppendLine(@"					<tr>");
                    strNewHTMLFile.AppendLine(@"						<td style='text-align:right; width:128px;'>" + receipt.Amount + "</td>");
                    strNewHTMLFile.AppendLine(@"						<td style='width:404px'>" + receipt.Bank_Name + "</td>");
                    strNewHTMLFile.AppendLine(@"						<td style='text-align:center; width:229px'>" + receipt.Branch_Name + "</td>");
                    strNewHTMLFile.AppendLine(@"						<td style='text-align:center; width:232px'>" + receipt.Cheq_Rtgs_Neft_ImpsNo + "</td>");
                    strNewHTMLFile.AppendLine(@"						<td style='text-align:center; width:144px'>" + receipt.PaymentDate.Replace("/", ".") + "</td>");
                    strNewHTMLFile.AppendLine(@"					</tr>");
                    TotalAmount = TotalAmount + receipt.Amount;
                }
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td style='text-align:right; width:128px;'><strong>" + TotalAmount.ToString() + "</strong></td>");
                decimal pendingAmount = selectedWingDetails.Amount - TotalAmount;
                strNewHTMLFile.AppendLine(@"						<td style='width:404px'>-<strong>" + pendingAmount + "</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='text-align:center; width:229px'>&nbsp;</td>");
                strNewHTMLFile.AppendLine(@"						<td style='text-align:center; width:232px'>&nbsp;</td>");
                strNewHTMLFile.AppendLine(@"						<td style='text-align:center; width:144px'>&nbsp;</td>");
                strNewHTMLFile.AppendLine(@"					</tr>");
                strNewHTMLFile.AppendLine(@"				</tbody>");
                strNewHTMLFile.AppendLine(@"			</table>");
                strNewHTMLFile.AppendLine(@"			</td>");
                strNewHTMLFile.AppendLine(@"		</tr>");

                strNewHTMLFile.AppendLine(@"		<tr>");
                strNewHTMLFile.AppendLine(@"			<td style='background-color:#E8E8E8;'><strong>ALL BOUNDRIES DETAIL</strong></td>");
                strNewHTMLFile.AppendLine(@"		</tr>");
                strNewHTMLFile.AppendLine(@"		<tr>");
                strNewHTMLFile.AppendLine(@"			<td>");
                strNewHTMLFile.AppendLine(@"			<table border='1' cellpadding='1' cellspacing='1' style='width:100%'>");
                strNewHTMLFile.AppendLine(@"				<tbody>");
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td style='text-align:center; width:128px;'><strong>EAST</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:1070px'>" + selectedWingDetails.EAST + "</td>");
                strNewHTMLFile.AppendLine(@"						<td rowspan='4' style='width:1070px'>&nbsp;</td>");
                strNewHTMLFile.AppendLine(@"					</tr>");
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td style='text-align:center; width:128px;'><strong>WEST</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:1070px'>" + selectedWingDetails.WEST + "</td>");
                strNewHTMLFile.AppendLine(@"					</tr>");
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td style='text-align:center; width:128px;'><strong>NORTH</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:1070px'>" + selectedWingDetails.NORTH + "</td>");
                strNewHTMLFile.AppendLine(@"					</tr>");
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td style='text-align:center; width:128px;'><strong>SOUTH</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:1070px'>" + selectedWingDetails.SOUTH + "</td>");
                strNewHTMLFile.AppendLine(@"					</tr>");
                strNewHTMLFile.AppendLine(@"				</tbody>");
                strNewHTMLFile.AppendLine(@"			</table>");
                strNewHTMLFile.AppendLine(@"			</td>");
                strNewHTMLFile.AppendLine(@"		</tr>");
                strNewHTMLFile.AppendLine(@"	</tbody>");
                strNewHTMLFile.AppendLine(@"</table>");
                strNewHTMLFile.AppendLine(@"");
                strNewHTMLFile.AppendLine(@"</body>");
                strNewHTMLFile.AppendLine(@"</html>");

                string FileName = ClsUtil.getCurrentPath() + "Banakhat_" + selectedCustomer.FirstOrDefault().Customer_Name.Replace(" ", "").Trim() + ".html";


                if (System.IO.File.Exists(FileName))
                {
                    System.IO.File.Delete(FileName);
                }

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(FileName))
                {
                    file.WriteLine(strNewHTMLFile.ToString()); // "sb" is the StringBuilder
                }

                htmlFilePath = FileName;

                //wbHtmlView.Url = new Uri("file:///" + FileName);

            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Module.Name);
            }
        }

        private async Task convertToPdf(string strNewHTMLFile)
        {
            try
            {
                //string fileData = System.IO.File.ReadAllText(strNewHTMLFile);
                var htmlData = new HtmlToPdf();
                string dateFolderName = DateTime.Now.ToString("dd_MM_yyyy");
                if (!System.IO.Directory.Exists(ClsUtil.getCurrentPath() + @"BanakhatPdf\" + dateFolderName))
                {
                    System.IO.Directory.CreateDirectory(ClsUtil.getCurrentPath() + @"BanakhatPdf\" + dateFolderName);
                }
                string svaeFilePath = ClsUtil.getCurrentPath() + @"BanakhatPdf\" + dateFolderName + @"\" + strNewHTMLFile.Replace(ClsUtil.getCurrentPath(), "").Replace(".html", "") + ".pdf";
                htmlData.RenderHtmlFileAsPdf(strNewHTMLFile).SaveAs(svaeFilePath);

            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, "ConvertToPdf");
            }
        }

        private async void btnprint_Click(object sender, EventArgs e)
        {

            List<DataRow> selectedRows = dtList.Select("PrintBanakhat=1").ToList<DataRow>();
            foreach (DataRow row in selectedRows)
            {
                await CreateExcelBankhat(Convert.ToInt32(row["Customer_Id"]));
                //await CreateExcelFile(Convert.ToInt32(row["Customer_Id"]));

                //await CreateHTMLFile(Convert.ToInt32(row["Customer_Id"]));
                //await convertToPdf(htmlFilePath);
                //var updatevalue = await BAReceiptDetails.UpdatePrintedBanakhat(row["Customer_Id"].ToString());
            }
            //var filePath = ClsUtil.getdesktopPath() + @"BANAKHAT\" + DateTime.Now.ToString("dd_MM_yyyy");
            //System.Diagnostics.Process.Start("explorer.exe", string.Format("/select,\"{0}\"", filePath));
        }

        private void sendToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView= new DataGridView();
            try
            {
                ClsUtil.ExpodtDatasetToExcel(dsCustomerDetails, "Customer_Id");
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
            finally
            {
                dataGridView.Dispose();
                GC.Collect();
            }
        }

        private async void frmBanakhatList_Load(object sender, EventArgs e)
        {
            try
            {
                clsWaitForm.ShowWaitForm();
                await AddContrial();
                await GetBanakhatListData();
                clsWaitForm.CloseWaitForm();
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private async void chlRePrintBANAKHAT_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if(chlRePrintBANAKHAT.Checked)
                {
                    await GetBanakhatListData(true);
                    dgviewBanakhatDetails.CaptionText = "Banakhat completed List";
                }
                else
                {
                    await GetBanakhatListData(false);
                    dgviewBanakhatDetails.CaptionText = "Banakhat Pending List";
                }
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
    }
}
