using ReceiptEntity;
using ReceiptLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ReceiptDataAcess
{
    public static class DAImportData
    {
        private static string[] numberformate = {"ZERO","FIRST","SECOND","THIRD","FOURTH","FIFTH","SIXTH","SEVENTH","EIGHTH",
            "NINTH","TENTH","ELEVENTH" };
        private static String[] units = { "Zero", "One", "Two", "Three",
    "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
    "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
    "Seventeen", "Eighteen", "Nineteen" };
        private static String[] tens = { "", "", "Twenty", "Thirty", "Forty",
    "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        private static string convertNumberToWord(int number)
        {
            return numberformate[number];
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
        public static async Task<List<string>> GetTableName()
        {
            SQLiteCommand command = new SQLiteCommand();
            try
            {
                command.CommandText = "SELECT NAME AS Table_Name from sqlite_master WHERE NAME NOT LIKE '%sqlite%' ORDER BY NAME;";
                command.Parameters.Clear();
                DataTable dtWingMaster = await DaDatabaseConnection.GetDataTable(command);
                var tableName = dtWingMaster.AsEnumerable().Select(x => x.Field<string>("Table_Name")).ToList<string>();
                return tableName;
            }
            catch (Exception ex)
            {
                ReceiptLog.clsLog.InstanceCreation().InsertLog(ex.Message, ReceiptLog.clsLog.logType.Error, "DaWingMaster.getWingMaster");
                throw ex;
            }
            finally
            {
                command.Dispose();
            }
        }
        public static async Task ImportWingDetails(DataTable dtForImport)
        {
            try
            {
                if (!dtForImport.Columns.Contains("Wing_Master_Id"))
                {
                    DataColumn dc = new DataColumn();
                    dc.DataType = typeof(int);
                    dc.DefaultValue = 0;
                    dc.ColumnName = "Wing_Master_Id";
                    dtForImport.Columns.Add(dc);
                }
                if (!dtForImport.Columns.Contains("Wing_DetailsId"))
                {
                    DataColumn dcWingDetailsId = new DataColumn();
                    dcWingDetailsId.DataType = typeof(int);
                    dcWingDetailsId.DefaultValue = 0;
                    dcWingDetailsId.ColumnName = "Wing_DetailsId";
                    dtForImport.Columns.Add(dcWingDetailsId);
                }
                if (!dtForImport.Columns.Contains("IsImport"))
                {
                    DataColumn dcIsImportRow = new DataColumn();
                    dcIsImportRow.DataType = typeof(bool);
                    dcIsImportRow.DefaultValue = false;
                    dcIsImportRow.ColumnName = "IsImport";
                    dtForImport.Columns.Add(dcIsImportRow);
                }
                dtForImport.AcceptChanges();
                foreach (DataRow drImport in dtForImport.Rows)
                {
                    try
                    {
                        var wingMaster = await DaWingMaster.GetWingMasterByName(Convert.ToString(drImport["WingName"]));
                        if (wingMaster != null && wingMaster.Wing_Master_Id > 0)
                        {
                            drImport["Wing_Master_Id"] = wingMaster.Wing_Master_Id;
                            var wingDetails = wingMaster.enWingDetails.Where<EnWingDetails>(x => x.FlatNo == Convert.ToString(drImport["HousNo"])).FirstOrDefault();
                            if (wingDetails != null)
                            {
                                drImport["Wing_DetailsId"] = wingDetails.Wing_DetailsId;
                                decimal totals = Convert.ToDecimal(drImport["Carpet"]) + Convert.ToDecimal(drImport["w_B"]);
                                wingDetails.Total = totals;
                                wingDetails.Carpet = Convert.ToDecimal(drImport["Carpet"]);
                                wingDetails.WB = Convert.ToDecimal(drImport["w_B"]);
                                wingDetails.Land = Convert.ToDecimal(drImport["Land"]);
                                wingDetails.Amount = Convert.ToDecimal(drImport["Amount"]);
                                wingDetails.WEST = Convert.ToString(drImport["WEST"]);
                                wingDetails.EAST = Convert.ToString(drImport["EAST"]);
                                wingDetails.NORTH = Convert.ToString(drImport["NORTH"]);
                                wingDetails.SOUTH = Convert.ToString(drImport["SOUTH"]);
                                int wingDetailId = await DaWingMaster.InsertUpdateWingDetails(wingDetails, wingMaster.Wing_Master_Id);
                                drImport["Wing_DetailsId"] = wingDetails.Wing_DetailsId;

                            }
                            else
                            {
                                var FlatNoumbr = Convert.ToString(drImport["HousNo"]);
                                int numberConvert = 0;
                                decimal totals = Convert.ToDecimal(drImport["Carpet"]) + Convert.ToDecimal(drImport["w_B"]);
                                if (FlatNoumbr.ToCharArray().Length == 3)
                                {
                                    numberConvert = Convert.ToInt32(FlatNoumbr.ToCharArray()[0].ToString());
                                }
                                if (FlatNoumbr.ToCharArray().Length > 3)
                                {
                                    numberConvert = Convert.ToInt32(FlatNoumbr.ToCharArray()[0].ToString() + FlatNoumbr.ToCharArray()[1].ToString());
                                }
                                var enWingDetails = new EnWingDetails(0, wingMaster.Wing_Master_Id, Convert.ToString(drImport["HousNo"]),
                                                                       Convert.ToString(drImport["Wing"]), Convert.ToDecimal(drImport["Land"]),
                                                                       Convert.ToDecimal(drImport["Carpet"]), Convert.ToDecimal(drImport["w_B"]),
                                                                       Convert.ToDecimal(drImport["Amount"]), totals, Convert.ToString(drImport["EAST"]),
                                                                       Convert.ToString(drImport["WEST"]), Convert.ToString(drImport["NORTH"]),
                                                                       Convert.ToString(drImport["SOUTH"]), convertNumberToWord(numberConvert));
                                int wingDetailId = await DaWingMaster.InsertUpdateWingDetails(enWingDetails, wingMaster.Wing_Master_Id);
                                drImport["Wing_DetailsId"] = enWingDetails.Wing_DetailsId;
                            }
                        }
                        else
                        {
                            var FlatNoumbr = Convert.ToString(drImport["HousNo"]);
                            int numberConvert = 0;
                            decimal totals = Convert.ToDecimal(drImport["Carpet"]) + Convert.ToDecimal(drImport["w_B"]);
                            if (FlatNoumbr.ToCharArray().Length == 3)
                            {
                                numberConvert = Convert.ToInt32(FlatNoumbr.ToCharArray()[0].ToString());
                            }
                            if (FlatNoumbr.ToCharArray().Length > 3)
                            {
                                numberConvert = Convert.ToInt32(FlatNoumbr.ToCharArray()[0].ToString() + FlatNoumbr.ToCharArray()[1].ToString());
                            }
                            EnWingMaster enWingMaster = new EnWingMaster(0, Convert.ToString(drImport["WingName"]), 11, 4, 100, 1104);
                            var enWingDetails = new EnWingDetails(0, wingMaster.Wing_Master_Id, Convert.ToString(drImport["HousNo"]),
                                                                           Convert.ToString(drImport["Wing"]), Convert.ToDecimal(drImport["Land"]),
                                                                           Convert.ToDecimal(drImport["Carpet"]), Convert.ToDecimal(drImport["w_B"]),
                                                                           Convert.ToDecimal(drImport["Amount"]), totals, Convert.ToString(drImport["EAST"]),
                                                                           Convert.ToString(drImport["WEST"]), Convert.ToString(drImport["NORTH"]),
                                                                           Convert.ToString(drImport["SOUTH"]), convertNumberToWord(numberConvert));
                            List<EnWingDetails> enWingDetailsList = new List<EnWingDetails>();
                            enWingDetailsList.Add(enWingDetails);
                            var wingMasterID = await DaWingMaster.InsertWingMaster(enWingMaster, enWingDetailsList, 1);
                            drImport["Wing_Master_Id"] = enWingMaster.Wing_Master_Id;
                            drImport["Wing_DetailsId"] = enWingDetailsList.FirstOrDefault().Wing_DetailsId;
                        }
                        drImport["IsImport"] = true;
                    }
                    catch (Exception ex)
                    {
                        drImport["IsImport"] = false;
                        ReceiptLog.clsLog.InstanceCreation().InsertLog(ex.Message, ReceiptLog.clsLog.logType.Error, "DAImport.ImportWingDetails");
                    }
                }
            }
            catch (Exception ex)
            {
                ReceiptLog.clsLog.InstanceCreation().InsertLog(ex.Message, ReceiptLog.clsLog.logType.Error, "DAImport.ImportWingDetails");
                throw ex;
            }
        }
        public static async Task<DataTable> ImportReceiptData(DataTable dtForImport)
        {
            DataTable dtReturn = new DataTable();
            try
            {
                if (!dtForImport.Columns.Contains("Wing_Master_Id"))
                {
                    DataColumn dc = new DataColumn();
                    dc.DataType = typeof(int);
                    dc.DefaultValue = 0;
                    dc.ColumnName = "Wing_Master_Id";
                    dtForImport.Columns.Add(dc);
                }
                if (!dtForImport.Columns.Contains("Wing_DetailsId"))
                {
                    DataColumn dcWingDetailsId = new DataColumn();
                    dcWingDetailsId.DataType = typeof(int);
                    dcWingDetailsId.DefaultValue = 0;
                    dcWingDetailsId.ColumnName = "Wing_DetailsId";
                    dtForImport.Columns.Add(dcWingDetailsId);
                }
                if (!dtForImport.Columns.Contains("Customer_Id"))
                {
                    DataColumn dcCustomer = new DataColumn();
                    dcCustomer.DataType = typeof(int);
                    dcCustomer.DefaultValue = 0;
                    dcCustomer.ColumnName = "Customer_Id";
                    dtForImport.Columns.Add(dcCustomer);
                }
                if (!dtForImport.Columns.Contains("Receipt_Id"))
                {
                    DataColumn dcReceipt_Id = new DataColumn();
                    dcReceipt_Id.DataType = typeof(int);
                    dcReceipt_Id.DefaultValue = 0;
                    dcReceipt_Id.ColumnName = "Receipt_Id";
                    dtForImport.Columns.Add(dcReceipt_Id);
                }
                if(!dtForImport.Columns.Contains("UpdateCustomerName"))
                {
                    DataColumn dcUpdateCustomerName = new DataColumn();
                    dcUpdateCustomerName.DataType = typeof(string);
                    dcUpdateCustomerName.DefaultValue = string.Empty;
                    dcUpdateCustomerName.ColumnName = "UpdateCustomerName";
                    dtForImport.Columns.Add(dcUpdateCustomerName);
                }
                if (!dtForImport.Columns.Contains("IsImport"))
                {
                    DataColumn dcIsImportRow = new DataColumn();
                    dcIsImportRow.DataType = typeof(bool);
                    dcIsImportRow.DefaultValue = false;
                    dcIsImportRow.ColumnName = "IsImport";
                    dtForImport.Columns.Add(dcIsImportRow);
                }

                dtForImport.AcceptChanges();
                foreach (DataRow drImport in dtForImport.Rows)
                {
                    try
                    {
                        string receiptDate = Convert.ToString(drImport["RECEIPT_DATE"]);
                        receiptDate = receiptDate.Split('/')[0] + "/" + receiptDate.Split('/')[1] + "/20" + receiptDate.Split('/')[2];
                        drImport["RECEIPT_DATE"] = DateTime.ParseExact(receiptDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                        string receiptDateNo = DateTime.ParseExact(receiptDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyyMMdd");
                        var wingMaster = await DaWingMaster.GetWingMasterByName(Convert.ToString(drImport["Wing"]));
                        if (wingMaster != null && wingMaster.Wing_Master_Id>0)
                        {
                            drImport["Wing_Master_Id"] = wingMaster.Wing_Master_Id;
                            var wingDetails = wingMaster.enWingDetails.Where<EnWingDetails>(x => x.FlatNo == Convert.ToString(drImport["Flat_No"])).FirstOrDefault();
                            if (wingDetails != null)
                            {
                                drImport["Wing_DetailsId"] = wingDetails.Wing_DetailsId;
                            }
                            else
                            {
                                var FlatNoumbr = Convert.ToString(drImport["Flat_No"]);
                                int numberConvert = 0;
                                decimal totals = Convert.ToDecimal(drImport["Carpet"]) + Convert.ToDecimal(drImport["w_B"]);
                                if(FlatNoumbr.ToCharArray().Length==3)
                                {
                                    numberConvert = Convert.ToInt32(FlatNoumbr.ToCharArray()[0].ToString());
                                }
                                if (FlatNoumbr.ToCharArray().Length>3)
                                {
                                    numberConvert = Convert.ToInt32(FlatNoumbr.ToCharArray()[0].ToString()+ FlatNoumbr.ToCharArray()[1].ToString());
                                }
                                var enWingDetails = new EnWingDetails(0, wingMaster.Wing_Master_Id, Convert.ToString(drImport["Flat_No"]),
                                                                       Convert.ToString(drImport["Wing"]), Convert.ToDecimal(drImport["Land"]),
                                                                       Convert.ToDecimal(drImport["Carpet"]), Convert.ToDecimal(drImport["w_B"]),
                                                                       Convert.ToDecimal(drImport["Amount"]), totals, Convert.ToString(drImport["EAST"]),
                                                                       Convert.ToString(drImport["WEST"]), Convert.ToString(drImport["NORTH"]),
                                                                       Convert.ToString(drImport["SOUTH"]),convertNumberToWord(numberConvert));
                                int wingDetailId = await DaWingMaster.InsertUpdateWingDetails(enWingDetails, wingMaster.Wing_Master_Id);
                                drImport["Wing_DetailsId"] = enWingDetails.Wing_DetailsId;
                            }
                        }
                        else
                        {
                            var FlatNoumbr = Convert.ToString(drImport["Flat_No"]);
                            int numberConvert = 0;
                            decimal totals = Convert.ToDecimal(drImport["Carpet"]) + Convert.ToDecimal(drImport["w_B"]);
                            if (FlatNoumbr.ToCharArray().Length == 3)
                            {
                                numberConvert = Convert.ToInt32(FlatNoumbr.ToCharArray()[0].ToString());
                            }
                            if (FlatNoumbr.ToCharArray().Length > 3)
                            {
                                numberConvert = Convert.ToInt32(FlatNoumbr.ToCharArray()[0].ToString() + FlatNoumbr.ToCharArray()[1].ToString());
                            }
                            EnWingMaster enWingMaster = new EnWingMaster(0, Convert.ToString(drImport["Wing"]), 11, 4, 100, 1104);
                            var enWingDetails = new EnWingDetails(0, wingMaster.Wing_Master_Id, Convert.ToString(drImport["Flat_No"]),
                                                                           Convert.ToString(drImport["Wing"]), Convert.ToDecimal(drImport["Land"]),
                                                                           Convert.ToDecimal(drImport["Carpet"]), Convert.ToDecimal(drImport["w_B"]),
                                                                           Convert.ToDecimal(drImport["Amount"]), totals, Convert.ToString(drImport["EAST"]),
                                                                           Convert.ToString(drImport["WEST"]), Convert.ToString(drImport["NORTH"]),
                                                                           Convert.ToString(drImport["SOUTH"]), convertNumberToWord(numberConvert));
                            List<EnWingDetails> enWingDetailsList = new List<EnWingDetails>();
                            enWingDetailsList.Add(enWingDetails);
                            var wingMasterID = await DaWingMaster.InsertWingMaster(enWingMaster, enWingDetailsList, 1);
                            drImport["Wing_Master_Id"] = enWingMaster.Wing_Master_Id;
                            drImport["Wing_DetailsId"] = enWingDetailsList.FirstOrDefault().Wing_DetailsId;
                        }
                        string banakhatNo = "";
                        string banakhatDate = "";
                        int IsBanakhat = 0;
                        if (drImport.Table.Columns.Contains("BANAKHATNO"))
                        {
                            banakhatNo = Convert.ToString(drImport["BANAKHATNO"]);
                        }
                        if (drImport.Table.Columns.Contains("BANAKHATDATE"))
                        {
                            banakhatDate = Convert.ToString(drImport["BANAKHATDATE"]);
                            if(!string.IsNullOrWhiteSpace(banakhatDate))
                            {
                                banakhatDate = banakhatDate.Split('.')[0]+"/"+ banakhatDate.Split('.')[1]+"/20"+ banakhatDate.Split('.')[2];
                            }
                        }
                        if(drImport.Table.Columns.Contains("IsBanakhat"))
                        {
                            if (!string.IsNullOrWhiteSpace(Convert.ToString(drImport["IsBanakhat"])))
                            {
                                IsBanakhat = Convert.ToInt32(Convert.ToString(drImport["IsBanakhat"]));
                            }
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(drImport["Wing_Master_Id"])) &&
                            !string.IsNullOrWhiteSpace(Convert.ToString(drImport["Wing_DetailsId"])))
                        {
                            string[] cutomerNames = Convert.ToString(drImport["Customer_Name"]).Split('&');
                            drImport["UpdateCustomerName"] = cutomerNames[0];
                            //var customer = await DACustomerMaster.GetCustomeriByName(Convert.ToString(drImport["Customer_Name"]));
                            var customer = await DACustomerMaster.GetCustomeriByName(cutomerNames[0]);
                            if (customer != null)
                            {
                                
                                var selectedCusteomer = customer.AsEnumerable().Where(x => x.Wing_Master_Id == Convert.ToInt32(drImport["Wing_Master_Id"]) &&
                                x.Wing_Details_Id == Convert.ToInt32(drImport["Wing_DetailsId"])).FirstOrDefault();
                                if (selectedCusteomer != null)
                                {
                                    drImport["Customer_Id"] = selectedCusteomer.Customer_Id;
                                }
                                else
                                {
                                    EnCustomer enCustomer = new EnCustomer(Convert.ToInt32(0),
                                                            Convert.ToInt32(drImport["Wing_Master_Id"]),
                                                            Convert.ToInt32(drImport["Wing_DetailsId"]),
                                                            Convert.ToString(drImport["Wing"]),
                                                            Convert.ToString(drImport["Flat_No"]),
                                                            cutomerNames[0],

                                                            drImport.Table.Columns.Contains("Address") == true ? Convert.ToString(drImport["Address"]) : "",
                                                            drImport.Table.Columns.Contains("Con_Details") == true ? Convert.ToString(drImport["Con_Details"]) : "",
                                                            drImport.Table.Columns.Contains("Email_Id") == true ? Convert.ToString(drImport["Email_Id"]) : "",
                                                            drImport.Table.Columns.Contains("Customer_Wing_Name") == true ? Convert.ToString(drImport["Customer_Wing_Name"]) : "",

                                                            drImport.Table.Columns.Contains("Pan") == true ? Convert.ToString(drImport["Pan"]) : "",
                                                            drImport.Table.Columns.Contains("Aadhar") == true ? Convert.ToString(drImport["Aadhar"]) : "",
                                                            
                                                            cutomerNames.Length > 0 ? cutomerNames[0]:"",
                                                            //drImport.Table.Columns.Contains("Customer1") == true ? Convert.ToString(drImport["Customer1"]) : "",
                                                            drImport.Table.Columns.Contains("Pan1") == true ? Convert.ToString(drImport["Pan1"]) : "",
                                                            drImport.Table.Columns.Contains("Aadhar1") == true ? Convert.ToString(drImport["Aadhar1"]) : "",
                                                            cutomerNames.Length > 1 ? cutomerNames[1] : "",
                                                            //drImport.Table.Columns.Contains("Customer2") == true ? Convert.ToString(drImport["Customer2"]) : "",
                                                            drImport.Table.Columns.Contains("Pan2") == true ? Convert.ToString(drImport["Pan2"]) : "",
                                                            drImport.Table.Columns.Contains("Aadhar2") == true ? Convert.ToString(drImport["Aadhar2"]) : "",
                                                            cutomerNames.Length > 2 ? cutomerNames[2] : "",
                                                            drImport.Table.Columns.Contains("Pan3") == true ? Convert.ToString(drImport["Pan3"]) : "",
                                                            drImport.Table.Columns.Contains("Aadhar3") == true ? Convert.ToString(drImport["Aadhar3"]) : "",
                                                            banakhatNo, banakhatDate,"","","","",
                                                            drImport.Table.Columns.Contains("Financial_Name") == true ? Convert.ToString(drImport["Financial_Name"]) : "",
                                                            "",""
                                                            );
                                    var newCustomer = await DACustomerMaster.InsertUpdateCustomer(enCustomer, IsBanakhat);
                                    drImport["Customer_Id"] = newCustomer;
                                }
                            }
                            else
                            {
                                EnCustomer enCustomer = new EnCustomer(Convert.ToInt32(0),
                                                        Convert.ToInt32(drImport["Wing_Master_Id"]),
                                                        Convert.ToInt32(drImport["Wing_DetailsId"]),
                                                        Convert.ToString(drImport["Wing"]),
                                                        Convert.ToString(drImport["Flat_No"]),
                                                        cutomerNames.Length > 0 ? cutomerNames[0] : "",

                                                        drImport.Table.Columns.Contains("Address") == true ? Convert.ToString(drImport["Address"]) : "",
                                                        drImport.Table.Columns.Contains("Con_Details") == true ? Convert.ToString(drImport["Con_Details"]) : "",
                                                        drImport.Table.Columns.Contains("Email_Id") == true ? Convert.ToString(drImport["Email_Id"]) : "",
                                                        drImport.Table.Columns.Contains("Customer_Wing_Name") == true ? Convert.ToString(drImport["Customer_Wing_Name"]) : "",

                                                        drImport.Table.Columns.Contains("Pan") == true ? Convert.ToString(drImport["Pan"]) : "",
                                                        drImport.Table.Columns.Contains("Aadhar") == true ? Convert.ToString(drImport["Aadhar"]) : "",
                                                        cutomerNames.Length > 0 ? cutomerNames[0] : "",
                                                        drImport.Table.Columns.Contains("Pan1") == true ? Convert.ToString(drImport["Pan1"]) : "",
                                                        drImport.Table.Columns.Contains("Aadhar1") == true ? Convert.ToString(drImport["Aadhar1"]) : "",
                                                        cutomerNames.Length > 1 ? cutomerNames[1] : "",
                                                        //drImport.Table.Columns.Contains("Customer2") == true ? Convert.ToString(drImport["Customer2"]) : "",
                                                        drImport.Table.Columns.Contains("Pan2") == true ? Convert.ToString(drImport["Pan2"]) : "",
                                                        drImport.Table.Columns.Contains("Aadhar2") == true ? Convert.ToString(drImport["Aadhar2"]) : "",
                                                        cutomerNames.Length > 2 ? cutomerNames[2] : "",
                                                        //drImport.Table.Columns.Contains("Customer3") == true ? Convert.ToString(drImport["Customer3"]) : "",
                                                        drImport.Table.Columns.Contains("Pan3") == true ? Convert.ToString(drImport["Pan3"]) : "",
                                                        drImport.Table.Columns.Contains("Aadhar3") == true ? Convert.ToString(drImport["Aadhar3"]) : "",
                                                        banakhatNo,banakhatDate,"","","","",
                                                        drImport.Table.Columns.Contains("Financial_Name") == true ? Convert.ToString(drImport["Financial_Name"]) : "",
                                                        "",""
                                                        );
                                var newCustomer = await DACustomerMaster.InsertUpdateCustomer(enCustomer, IsBanakhat);
                                drImport["Customer_Id"] = newCustomer;
                            }
                        }


                        if (!string.IsNullOrEmpty(Convert.ToString(drImport["Wing_Master_Id"])) &&
                            !string.IsNullOrWhiteSpace(Convert.ToString(drImport["Wing_DetailsId"])) &&
                            !string.IsNullOrEmpty(Convert.ToString(drImport["Customer_Id"])))
                        {
                            int IsCancel = 0;
                            if (drImport.Table.Columns.Contains("ISCANCALRECEIPT"))
                            {
                                IsCancel = Convert.ToInt32(drImport["ISCANCALRECEIPT"]);
                            }
                            var receiptDetails = await DAReciptDetails.GetReceiptDetailsByReceiptNo(Convert.ToString(drImport["RECEIPT_NO"]));
                            if (receiptDetails != null)
                            {
                                if (receiptDetails.Any(x => x.Customer_Id == Convert.ToInt32(drImport["Customer_Id"])))
                                {
                                    drImport["Receipt_Id"] = receiptDetails.FirstOrDefault().Receipt_Id;
                                }
                                else
                                {   
                                    EnReceiptDetails enReceiptDetails = new EnReceiptDetails(Convert.ToInt32(0),
                                                            Convert.ToString(drImport["RECEIPT_NO"]),
                                                            Convert.ToString(drImport["RECEIPT_DATE"]),
                                                            Convert.ToInt32(drImport["Customer_Id"]),
                                                            Convert.ToString(drImport["FLAT_WING"]),
                                                            Convert.ToString(drImport["RTG_NEFT_NO"]),
                                                            Convert.ToInt32(1),
                                                            Convert.ToString(drImport["BANK_NAME"]),
                                                            Convert.ToString(drImport["BRANCH_NAME"]),
                                                            Convert.ToString("Without Interest"),
                                                            Convert.ToDecimal(drImport["AMOUNT_Receipt"]),
                                                            ConvertAmount(Convert.ToDouble(drImport["AMOUNT_Receipt"])),
                                                            Convert.ToString(drImport["UpdateCustomerName"]),
                                                            Convert.ToString(drImport["RECEIPT_DATE"]),
                                                            Convert.ToInt32(receiptDateNo), IsCancel,0);
                                    var newReceipt = await DAReciptDetails.InsertUpdateReceiptDetails(enReceiptDetails);
                                    drImport["Receipt_Id"] = enReceiptDetails.Receipt_Id;
                                }
                            }
                            else
                            {
                                EnReceiptDetails enReceiptDetails = new EnReceiptDetails(Convert.ToInt32(0),
                                                        Convert.ToString(drImport["RECEIPT_NO"]),
                                                        Convert.ToString(drImport["RECEIPT_DATE"]),
                                                        Convert.ToInt32(drImport["Customer_Id"]),
                                                        Convert.ToString(drImport["FLAT_WING"]),
                                                        Convert.ToString(drImport["RTG_NEFT_NO"]),
                                                        Convert.ToInt32(1),
                                                        Convert.ToString(drImport["BANK_NAME"]),
                                                        Convert.ToString(drImport["BRANCH_NAME"]),
                                                        Convert.ToString("Without Interest"),
                                                        Convert.ToDecimal(drImport["AMOUNT_Receipt"]),
                                                        ConvertAmount(Convert.ToDouble(drImport["AMOUNT_Receipt"])),
                                                        Convert.ToString(drImport["UpdateCustomerName"]),
                                                        Convert.ToString(drImport["RECEIPT_DATE"]),
                                                        Convert.ToInt32(receiptDateNo),IsCancel,0);
                                var newReceipt = await DAReciptDetails.InsertUpdateReceiptDetails(enReceiptDetails);
                                drImport["Receipt_Id"] = enReceiptDetails.Receipt_Id;
                            }
                        }
                        drImport["IsImport"] = true;
                    }
                    catch (Exception ex)
                    {
                        clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, "ReceiptDataAcess.DAImportData.ImportData");
                        drImport["IsImport"] = false;
                    }
                }
                dtForImport.AcceptChanges();
                dtReturn = dtForImport;

                return dtReturn;
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, "ReceiptDataAcess.DAImportData.ImportData");
                throw ex;
            }
            finally
            {
                dtReturn.Dispose();
                dtForImport.Dispose();
            }
        }
    }

}
