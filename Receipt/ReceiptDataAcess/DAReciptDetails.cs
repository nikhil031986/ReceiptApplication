using ReceiptEntity;
using ReceiptLog;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptDataAcess
{
    public static class DAReciptDetails
    {
        public static async Task<List<EnReceiptDetails>> GetReceiptDetailsFromDateToDate(int fromDate, int Todate)
        {
            List<EnReceiptDetails> lstCustomers = new List<EnReceiptDetails>();
            DataTable dtCustomer = new DataTable();
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                cmd.CommandText = @"SELECT RD.Receipt_Id,RD.Receipt_No,
                                    RD.Receipt_Date,RD.Customer_Id,CM.Customer_Name,RD.Flate_ShopNo,RD.Cheq_Rtgs_Neft_ImpsNo,
                                    RD.Year_Id,RD.Bank_Name,RD.Branch_Name,RD.ReceivedAs,RD.Amount,RD.Amount_Word, RD.Payment_Date, RD.ReceiptDateNo,RD.IsCancel,RD.IsPrint FROM 
                                    ReceiptDetail RD
                                    INNER JOIN Customer_Master CM
                                    ON RD.Customer_Id = CM.Customer_Id  WHERE ReceiptDateNo BETWEEN @fromDate AND @ToDate;";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@fromDate", fromDate);
                cmd.Parameters.AddWithValue("@ToDate", Todate);
                dtCustomer = await DaDatabaseConnection.GetDataTable(cmd);
                if (dtCustomer != null && dtCustomer.AsEnumerable().Count() > 0)
                {
                    dtCustomer.AsEnumerable().ToList().ForEach(firstRow =>
                    {
                        lstCustomers.Add(new EnReceiptDetails(Convert.ToInt32(firstRow["Receipt_Id"]),
                                                        Convert.ToString(firstRow["Receipt_No"]),
                                                        Convert.ToString(firstRow["Receipt_Date"]),
                                                        Convert.ToInt32(firstRow["Customer_Id"]),
                                                        Convert.ToString(firstRow["Flate_ShopNo"]),
                                                        Convert.ToString(firstRow["Cheq_Rtgs_Neft_ImpsNo"]),
                                                        Convert.ToInt32(firstRow["Year_Id"]),
                                                        Convert.ToString(firstRow["Bank_Name"]),
                                                        Convert.ToString(firstRow["Branch_Name"]),
                                                        Convert.ToString(firstRow["ReceivedAs"]),
                                                        Convert.ToDecimal(firstRow["Amount"]),
                                                        Convert.ToString(firstRow["Amount_Word"]),
                                                        Convert.ToString(firstRow["Customer_Name"]),
                                                        Convert.ToString(firstRow["Payment_Date"]),
                                                        Convert.ToInt32(firstRow["ReceiptDateNo"]), Convert.ToInt32(firstRow["IsCancel"]),
                                                        Convert.ToInt32(firstRow["IsPrint"])));
                    });
                }
                return lstCustomers;
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
            finally
            {
                dtCustomer.Dispose();
                cmd.Dispose();
            }
        }
        public static async Task<List<string>> GetBranchName()
        {
            List<string> lstBankName = new List<string>();
            DataTable dtCustomer = new DataTable();
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                cmd.CommandText = @"SELECT DISTINCT RD.Branch_Name
                                    FROM 
                                    ReceiptDetail RD;";
                dtCustomer = await DaDatabaseConnection.GetDataTable(cmd);
                if (dtCustomer != null && dtCustomer.AsEnumerable().Count() > 0)
                {
                    lstBankName = dtCustomer.AsEnumerable().Select(x => x.Field<string>("Branch_Name")).ToList<string>();
                }
                return lstBankName;
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
            finally
            {
                dtCustomer.Dispose();
                cmd.Dispose();
            }
        }

        public static async Task<List<string>> GetBankName()
        {
            List<string> lstBankName = new List<string>();
            DataTable dtCustomer = new DataTable();
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                cmd.CommandText = @"SELECT DISTINCT RD.Bank_Name
                                    FROM 
                                    ReceiptDetail RD;";
                dtCustomer = await DaDatabaseConnection.GetDataTable(cmd);
                if (dtCustomer != null && dtCustomer.AsEnumerable().Count() > 0)
                {
                    lstBankName = dtCustomer.AsEnumerable().Select(x=> x.Field<string>("Bank_Name")).ToList<string>();
                }
                return lstBankName;
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
            finally
            {
                dtCustomer.Dispose();
                cmd.Dispose();
            }
        }
        public static async Task<List<EnReceiptDetails>> GetReceiptByCustomer(int CustomerID)
        {
            List<EnReceiptDetails> lstCustomers = new List<EnReceiptDetails>();
            DataTable dtCustomer = new DataTable();
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                cmd.CommandText = @"SELECT RD.Receipt_Id,RD.Receipt_No,
                                    RD.Receipt_Date,RD.Customer_Id,CM.Customer_Name,RD.Flate_ShopNo,RD.Cheq_Rtgs_Neft_ImpsNo,
                                    RD.Year_Id,RD.Bank_Name,RD.Branch_Name,RD.ReceivedAs,RD.Amount,RD.Amount_Word, RD.Payment_Date, RD.ReceiptDateNo,RD.IsCancel,RD.IsPrint FROM 
                                    ReceiptDetail RD
                                    INNER JOIN Customer_Master CM
                                    ON RD.Customer_Id = CM.Customer_Id AND RD.IsCancel = 0 " + (CustomerID == 0 ? ";" : " WHERE CM.Customer_Id=@Customer_Id;");
                if (CustomerID > 0)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Customer_Id", CustomerID);
                }
                dtCustomer = await DaDatabaseConnection.GetDataTable(cmd);
                if (dtCustomer != null && dtCustomer.AsEnumerable().Count() > 0)
                {
                    dtCustomer.AsEnumerable().ToList().ForEach(firstRow =>
                    {
                        lstCustomers.Add(new EnReceiptDetails(Convert.ToInt32(firstRow["Receipt_Id"]),
                                                        Convert.ToString(firstRow["Receipt_No"]),
                                                        Convert.ToString(firstRow["Receipt_Date"]),
                                                        Convert.ToInt32(firstRow["Customer_Id"]),
                                                        Convert.ToString(firstRow["Flate_ShopNo"]),
                                                        Convert.ToString(firstRow["Cheq_Rtgs_Neft_ImpsNo"]),
                                                        Convert.ToInt32(firstRow["Year_Id"]),
                                                        Convert.ToString(firstRow["Bank_Name"]),
                                                        Convert.ToString(firstRow["Branch_Name"]),
                                                        Convert.ToString(firstRow["ReceivedAs"]),
                                                        Convert.ToDecimal(firstRow["Amount"]),
                                                        Convert.ToString(firstRow["Amount_Word"]),
                                                        Convert.ToString(firstRow["Customer_Name"]),
                                                        Convert.ToString(firstRow["Payment_Date"]),
                                                        Convert.ToInt32(firstRow["ReceiptDateNo"]), Convert.ToInt32(firstRow["IsCancel"])
                                                        , Convert.ToInt32(firstRow["IsPrint"])));
                    });
                }
                return lstCustomers;
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
            finally
            {
                dtCustomer.Dispose();
                cmd.Dispose();
            }
        }
        public static async Task<List<EnReceiptDetails>> GetReceiptDetails(int ReceiptId)
        {
            List<EnReceiptDetails> lstCustomers = new List<EnReceiptDetails>();
            DataTable dtCustomer = new DataTable();
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                cmd.CommandText = @"SELECT RD.Receipt_Id AS Receipt_Id,RD.Receipt_No,
                                    RD.Receipt_Date,RD.Customer_Id,CM.Customer_Name,RD.Flate_ShopNo,RD.Cheq_Rtgs_Neft_ImpsNo,
                                    RD.Year_Id,RD.Bank_Name,RD.Branch_Name,RD.ReceivedAs,RD.Amount,RD.Amount_Word, RD.Payment_Date, RD.ReceiptDateNo,RD.IsCancel,IFNULL(RD.IsPrint,0) AS IsPrint FROM 
                                    ReceiptDetail RD
                                    INNER JOIN Customer_Master CM
                                    ON RD.Customer_Id = CM.Customer_Id " + (ReceiptId == 0 ? ";" : " WHERE Receipt_Id=@Receipt_Id;");
                if (ReceiptId > 0)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Receipt_Id", ReceiptId);
                }
                dtCustomer = await DaDatabaseConnection.GetDataTable(cmd);
                if (dtCustomer != null && dtCustomer.AsEnumerable().Count() > 0)
                {
                    dtCustomer.AsEnumerable().ToList().ForEach(firstRow =>
                    {
                        lstCustomers.Add(new EnReceiptDetails(Convert.ToInt32(firstRow["Receipt_Id"]),
                                                        Convert.ToString(firstRow["Receipt_No"]),
                                                        Convert.ToString(firstRow["Receipt_Date"]),
                                                        Convert.ToInt32(firstRow["Customer_Id"]),
                                                        Convert.ToString(firstRow["Flate_ShopNo"]),
                                                        Convert.ToString(firstRow["Cheq_Rtgs_Neft_ImpsNo"]),
                                                        Convert.ToInt32(firstRow["Year_Id"]),
                                                        Convert.ToString(firstRow["Bank_Name"]),
                                                        Convert.ToString(firstRow["Branch_Name"]),
                                                        Convert.ToString(firstRow["ReceivedAs"]),
                                                        Convert.ToDecimal(firstRow["Amount"]),
                                                        Convert.ToString(firstRow["Amount_Word"]),
                                                        Convert.ToString(firstRow["Customer_Name"]),
                                                        Convert.ToString(firstRow["Payment_Date"]),
                                                        Convert.ToInt32(firstRow["ReceiptDateNo"]),
                                                        Convert.ToInt32(firstRow["IsCancel"]), Convert.ToInt32(firstRow["IsPrint"])));
                    });
                }
                return lstCustomers;
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
            finally
            {
                dtCustomer.Dispose();
                cmd.Dispose();
            }
        }
        public static async Task<string> GetPageCount(int rowCount)
        {
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                cmd.CommandText = @"SELECT ROUND(CAST(COUNT(1) AS real)/" + rowCount.ToString() + ",2) AS PageCount FROM ReceiptDetail;";
                var Valeu = await DaDatabaseConnection.ExecSacaler(cmd);
                decimal pagesCount = Convert.ToDecimal(Valeu);
                int manValue = (int)pagesCount;
                //manValue= ((pagesCount-manValue)>0? manValue+1: manValue);
                return Convert.ToString(manValue);
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
            finally { cmd.Dispose(); }
        }
        public static async Task<List<EnReceiptDetails>> GetReceiptByCond(string whereCond)
        {
            List<EnReceiptDetails> lstCustomers = new List<EnReceiptDetails>();
            DataTable dtCustomer = new DataTable();
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                cmd.CommandText = @"SELECT RD.Receipt_Id AS Receipt_Id,RD.Receipt_No,
                                    RD.Receipt_Date,RD.Customer_Id,CM.Customer_Name,RD.Flate_ShopNo,RD.Cheq_Rtgs_Neft_ImpsNo,
                                    RD.Year_Id,RD.Bank_Name,RD.Branch_Name,RD.ReceivedAs,RD.Amount,RD.Amount_Word, RD.Payment_Date, RD.ReceiptDateNo,RD.IsCancel,RD.IsPrint FROM 
                                    ReceiptDetail RD
                                    INNER JOIN Customer_Master CM
                                    ON RD.Customer_Id = CM.Customer_Id "+ (string.IsNullOrWhiteSpace(whereCond)==true?"":"WHERE "+whereCond) +" ;";

                dtCustomer = await DaDatabaseConnection.GetDataTable(cmd);
                if (dtCustomer != null && dtCustomer.AsEnumerable().Count() > 0)
                {
                    dtCustomer.AsEnumerable().ToList().ForEach(firstRow =>
                    {
                        lstCustomers.Add(new EnReceiptDetails(Convert.ToInt32(firstRow["Receipt_Id"]),
                                                        Convert.ToString(firstRow["Receipt_No"]),
                                                        Convert.ToString(firstRow["Receipt_Date"]),
                                                        Convert.ToInt32(firstRow["Customer_Id"]),
                                                        Convert.ToString(firstRow["Flate_ShopNo"]),
                                                        Convert.ToString(firstRow["Cheq_Rtgs_Neft_ImpsNo"]),
                                                        Convert.ToInt32(firstRow["Year_Id"]),
                                                        Convert.ToString(firstRow["Bank_Name"]),
                                                        Convert.ToString(firstRow["Branch_Name"]),
                                                        Convert.ToString(firstRow["ReceivedAs"]),
                                                        Convert.ToDecimal(firstRow["Amount"]),
                                                        Convert.ToString(firstRow["Amount_Word"]),
                                                        Convert.ToString(firstRow["Customer_Name"]),
                                                        Convert.ToString(firstRow["Payment_Date"]),
                                                        Convert.ToInt32(firstRow["ReceiptDateNo"]),
                                                        Convert.ToInt32(firstRow["IsCancel"]), Convert.ToInt32(firstRow["IsPrint"])));
                    });
                }
                return lstCustomers;
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
            finally
            {
                dtCustomer.Dispose();
                cmd.Dispose();
            }
        }
        public static async Task<List<EnReceiptDetails>> GetReciptPageing(int incrimentSize,int rtRows)
        {
            List<EnReceiptDetails> lstCustomers = new List<EnReceiptDetails>();
            DataTable dtCustomer = new DataTable();
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                cmd.CommandText = @"SELECT RD.Receipt_Id AS Receipt_Id,RD.Receipt_No,
                                    RD.Receipt_Date,RD.Customer_Id,CM.Customer_Name,RD.Flate_ShopNo,RD.Cheq_Rtgs_Neft_ImpsNo,
                                    RD.Year_Id,RD.Bank_Name,RD.Branch_Name,RD.ReceivedAs,RD.Amount,RD.Amount_Word, RD.Payment_Date, RD.ReceiptDateNo,RD.IsCancel,IFNULL(RD.IsPrint,0) AS IsPrint FROM 
                                    ReceiptDetail RD
                                    INNER JOIN Customer_Master CM
                                    ON RD.Customer_Id = CM.Customer_Id ORDER BY RD.Receipt_Id  LIMIT " + rtRows.ToString() + (incrimentSize == 0 ? "" : " OFFSET " + incrimentSize.ToString())+";";

                clsLog.InstanceCreation().InsertLog(cmd.CommandText,clsLog.logType.Info, MethodBase.GetCurrentMethod().Name);

                dtCustomer = await DaDatabaseConnection.GetDataTable(cmd);
                if (dtCustomer != null && dtCustomer.AsEnumerable().Count() > 0)
                {
                    dtCustomer.AsEnumerable().ToList().ForEach(firstRow =>
                    {
                        lstCustomers.Add(new EnReceiptDetails(Convert.ToInt32(firstRow["Receipt_Id"]),
                                                        Convert.ToString(firstRow["Receipt_No"]),
                                                        Convert.ToString(firstRow["Receipt_Date"]),
                                                        Convert.ToInt32(firstRow["Customer_Id"]),
                                                        Convert.ToString(firstRow["Flate_ShopNo"]),
                                                        Convert.ToString(firstRow["Cheq_Rtgs_Neft_ImpsNo"]),
                                                        Convert.ToInt32(firstRow["Year_Id"]),
                                                        Convert.ToString(firstRow["Bank_Name"]),
                                                        Convert.ToString(firstRow["Branch_Name"]),
                                                        Convert.ToString(firstRow["ReceivedAs"]),
                                                        Convert.ToDecimal(firstRow["Amount"]),
                                                        Convert.ToString(firstRow["Amount_Word"]),
                                                        Convert.ToString(firstRow["Customer_Name"]),
                                                        Convert.ToString(firstRow["Payment_Date"]),
                                                        Convert.ToInt32(firstRow["ReceiptDateNo"]),
                                                        Convert.ToInt32(firstRow["IsCancel"]), Convert.ToInt32(firstRow["IsPrint"])));
                    });
                }
                return lstCustomers;
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
            finally
            {
                dtCustomer.Dispose();
                cmd.Dispose();
            }
        }
        public static async Task<List<EnReceiptDetails>> GetReceiptDetailsByReceiptNo(string ReceiptNo = "")
        {
            List<EnReceiptDetails> lstCustomers = new List<EnReceiptDetails>();
            DataTable dtCustomer = new DataTable();
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                cmd.CommandText = @"SELECT RD.Receipt_Id,RD.Receipt_No,
                                    RD.Receipt_Date,RD.Customer_Id,CM.Customer_Name,RD.Flate_ShopNo,RD.Cheq_Rtgs_Neft_ImpsNo,
                                    RD.Year_Id,RD.Bank_Name,RD.Branch_Name,RD.ReceivedAs,RD.Amount,RD.Amount_Word, RD.Payment_Date, RD.ReceiptDateNo,RD.IsCancel,RD.IsPrint FROM 
                                    ReceiptDetail RD
                                    INNER JOIN Customer_Master CM
                                    ON RD.Customer_Id = CM.Customer_Id " + (ReceiptNo == "" ? ";" : " WHERE Receipt_No=@Receipt_No;");
                if (ReceiptNo != "")
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Receipt_No", ReceiptNo);
                }
                dtCustomer = await DaDatabaseConnection.GetDataTable(cmd);
                if (dtCustomer != null && dtCustomer.AsEnumerable().Count() > 0)
                {
                    dtCustomer.AsEnumerable().ToList().ForEach(firstRow =>
                    {
                        lstCustomers.Add(new EnReceiptDetails(Convert.ToInt32(firstRow["Receipt_Id"]),
                                                        Convert.ToString(firstRow["Receipt_No"]),
                                                        Convert.ToString(firstRow["Receipt_Date"]),
                                                        Convert.ToInt32(firstRow["Customer_Id"]),
                                                        Convert.ToString(firstRow["Flate_ShopNo"]),
                                                        Convert.ToString(firstRow["Cheq_Rtgs_Neft_ImpsNo"]),
                                                        Convert.ToInt32(firstRow["Year_Id"]),
                                                        Convert.ToString(firstRow["Bank_Name"]),
                                                        Convert.ToString(firstRow["Branch_Name"]),
                                                        Convert.ToString(firstRow["ReceivedAs"]),
                                                        Convert.ToDecimal(firstRow["Amount"]),
                                                        Convert.ToString(firstRow["Amount_Word"]),
                                                        Convert.ToString(firstRow["Customer_Name"]),
                                                        Convert.ToString(firstRow["Payment_Date"]),
                                                        Convert.ToInt32(firstRow["ReceiptDateNo"]), Convert.ToInt32(firstRow["IsCancel"]), Convert.ToInt32(firstRow["IsPrint"])));
                    });
                }
                return lstCustomers;
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
            finally
            {
                dtCustomer.Dispose();
                cmd.Dispose();
            }
        }

        public static async Task<int> UpdateReceiptPrint(int receiptId)
        {
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                if (string.IsNullOrWhiteSpace(Convert.ToString(receiptId)) == true)
                {
                    return 1;
                }
                string sqlCommand = "UPDATE ReceiptDetail SET IsPrint=1 WHERE Receipt_Id =" + receiptId + "; SELECT 1 AS UPDATEDVALUE;";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sqlCommand;
                var Valeu = await DaDatabaseConnection.ExecSacaler(cmd);
                var intRetValeu = Convert.ToInt32(Valeu);
                return intRetValeu;
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
        }
        public static async Task<string> getReceiptNo()
        {
            string strRetValeu = "00-00-000";
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                string strCommand = "";
                strCommand = @" SELECT  CASE
		                            WHEN  CAST(strftime('%m',DATE()) AS INT) <=3 
			                            THEN CAST(substr( strftime('%Y',DATE()),3,2)-1 AS INT) 
			                            ELSE substr( strftime('%Y',DATE()),3,2) END
		                            ||'-'||
		                            CASE
		                            WHEN  
			                            CAST(strftime('%m',DATE()) AS INT) <=3 
		                            THEN CAST(substr( strftime('%Y',DATE()),3,2) AS INT) 
		                            ELSE CAST( substr(strftime('%Y',DATE()),3,2)+1 AS INT) END
		                            ||'-'||
	                            (	CASE  
			                            length(CAST( CAST(substr(ifnull(Receipt_No,'00-00-000'),7,3) AS INT)+1 AS TEXT))
		                            WHEN 1 THEN  '00'||CAST( CAST(substr(ifnull(Receipt_No,'00-00-000'),7,3) AS INT)+1 AS TEXT) 
		                            WHEN 2 THEN  '0'||CAST( CAST(substr(ifnull(Receipt_No,'00-00-000'),7,3) AS INT)+1 AS TEXT) 
		                            ELSE CAST( CAST(substr(ifnull(Receipt_No,'00-00-000'),7,3) AS INT)+1 AS TEXT) 
	                            END )
                            FROM ReceiptDetail ORDER BY Receipt_Id DESC LIMIT 1;";
                cmd.CommandText = strCommand;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.Clear();
                var Valeu = await DaDatabaseConnection.ExecSacaler(cmd);
                strRetValeu = Convert.ToString(Valeu);
                return strRetValeu;
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }
        }
        public async static Task<int> UpdatePrintedBanakhat(string customerIds)
        {
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                if (string.IsNullOrWhiteSpace(customerIds) == true)
                {
                    return 1;
                }
                string sqlCommand = "UPDATE Customer_Master SET IsBanakhat=1 WHERE Customer_Id IN(" + customerIds + "); SELECT 1 AS UPDATEDVALUE;";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sqlCommand;
                var Valeu = await DaDatabaseConnection.ExecSacaler(cmd);
                var intRetValeu = Convert.ToInt32(Valeu);
                return intRetValeu;
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }
        }
        public async static Task<DataTable> GetBanakhatDetails()
        {
            DataTable dtRetunr = new DataTable();
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                string strCommand = "";
                strCommand = @" SELECT CM.Customer_Id ,CM.Customer_Name,WM.Wing_Master_Id,WM.Wing_Name
                                    ,WD.FlatNo,WD.Amount,(WD.Amount*10)/100 As minPayAmount,
                                    SUM(RD.AMOUNT) AS ReceiptAmount,0 AS PrintBanakhat 
                                    FROM Customer_Master CM
                                    INNER JOIN Wing_Master WM ON CM.Wing_Master_Id=WM.Wing_Master_Id
                                    INNER JOIN Wing_Details WD ON WD.Wing_MasterId=WM.Wing_Master_Id
                                    AND WD.Wing_DetailsId=CM.Wing_Details_Id
                                    INNER JOIN ReceiptDetail RD ON RD.Customer_Id=CM.Customer_Id
                                    WHERE CM.IsBanakhat=0 AND RD.IsCancel=0
                                    GROUP BY CM.Customer_Id
                                    HAVING ((minPayAmount-ReceiptAmount)<0);";
                cmd.CommandText = strCommand;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.Clear();
                dtRetunr = await DaDatabaseConnection.GetDataTable(cmd);
                return dtRetunr;
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, "GetBanakhatDetails");
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                dtRetunr.Dispose();
            }
        }
        public static async Task ImportReceiptFromExcel(DataTable dtImport)
        {
            try
            {
                foreach(DataRow drImport in dtImport.Rows)
                {
                    EnReceiptDetails enReceiptDetails = new EnReceiptDetails();
                     var getReceipt = await GetReceiptDetailsByReceiptNo(Convert.ToString(drImport[0]));
                    if(getReceipt != null && getReceipt.Count>0)
                    {
                        enReceiptDetails = getReceipt.FirstOrDefault();
                        var wingAndWingDetails = drImport[3].ToString().Split('-');
                        var wingMaster = await DaWingMaster.GetWingMasterByName(wingAndWingDetails[0].ToString());
                        var wingDetails = wingMaster.enWingDetails.Where(x=> x.FlatNo==wingAndWingDetails[1].ToString());
                        var customerWingName=drImport[2].ToString();
                        var CustomerDetails = await DACustomerMaster.GetCustomeriByName(customerWingName,wingMaster.Wing_Master_Id,wingDetails.FirstOrDefault().Wing_DetailsId);
                        enReceiptDetails.Customer_Id = CustomerDetails.FirstOrDefault().Customer_Id;
                        enReceiptDetails.Customer_Name = CustomerDetails.FirstOrDefault().Customer_Name;
                        enReceiptDetails.Bank_Name = drImport[5].ToString();
                        enReceiptDetails.Amount = Convert.ToDecimal(drImport[8]);
                        enReceiptDetails.Amount_Word = Convert.ToString(drImport[9]);
                        enReceiptDetails.PaymentDate = Convert.ToString(drImport[10]);
                        enReceiptDetails.Branch_Name = Convert.ToString(drImport[6]);
                        enReceiptDetails.Cheq_Rtgs_Neft_ImpsNo = Convert.ToString(drImport[4]);
                        enReceiptDetails.Flate_ShopNo = Convert.ToString(drImport[3]);
                        enReceiptDetails.Customer_Name = CustomerDetails.FirstOrDefault().Customer_Name;
                        enReceiptDetails.Receipt_No = drImport[0].ToString();
                        enReceiptDetails.Receipt_Date = drImport[1].ToString();
                        var reDate = drImport[1].ToString().Split('/');
                        var recDateNo = reDate[2] + (reDate[1].Length<1?"0":"")+ reDate[1] +(reDate[0].Length<1?"0":"") + reDate[0];
                        enReceiptDetails.ReceiptDateNo=Convert.ToInt32(recDateNo);
                        enReceiptDetails.IsCancel = Convert.ToInt32(drImport[11]);
                        enReceiptDetails.IsPrint= Convert.ToInt32(drImport[12]);
                        await DAReciptDetails.InsertUpdateReceiptDetails(enReceiptDetails);
                    }
                    else
                    {
                        enReceiptDetails = new EnReceiptDetails();
                        var wingAndWingDetails = drImport[3].ToString().Split('-');
                        var wingMaster = await DaWingMaster.GetWingMasterByName(wingAndWingDetails[0].ToString());
                        var wingDetails = wingMaster.enWingDetails.Where(x => x.FlatNo == wingAndWingDetails[1].ToString());
                        var customerWingName = drImport[2].ToString();
                        var CustomerDetails = await DACustomerMaster.GetCustomeriByName(customerWingName, wingMaster.Wing_Master_Id, wingDetails.FirstOrDefault().Wing_DetailsId);
                        enReceiptDetails.Customer_Id = CustomerDetails.FirstOrDefault().Customer_Id;
                        enReceiptDetails.Customer_Name = CustomerDetails.FirstOrDefault().Customer_Name;
                        enReceiptDetails.Bank_Name = drImport[5].ToString();
                        enReceiptDetails.Amount = Convert.ToDecimal(drImport[8]);
                        enReceiptDetails.Amount_Word = Convert.ToString(drImport[9]);
                        enReceiptDetails.PaymentDate = Convert.ToString(drImport[10]);
                        enReceiptDetails.Branch_Name = Convert.ToString(drImport[6]);
                        enReceiptDetails.Cheq_Rtgs_Neft_ImpsNo = Convert.ToString(drImport[4]);
                        enReceiptDetails.Flate_ShopNo = Convert.ToString(drImport[3]);
                        enReceiptDetails.Customer_Name = CustomerDetails.FirstOrDefault().Customer_Name;
                        enReceiptDetails.Receipt_No = drImport[0].ToString();
                        enReceiptDetails.Receipt_Date = drImport[1].ToString();
                        var reDate = drImport[1].ToString().Split('/');
                        var recDateNo = reDate[2] + (reDate[1].Length < 1 ? "0" : "") + reDate[1] + (reDate[0].Length < 1 ? "0" : "") + reDate[0];
                        enReceiptDetails.ReceiptDateNo = Convert.ToInt32(recDateNo);
                        enReceiptDetails.IsCancel = Convert.ToInt32(drImport[11]);
                        enReceiptDetails.IsPrint = Convert.ToInt32(drImport[12]);
                        await DAReciptDetails.InsertUpdateReceiptDetails(enReceiptDetails);
                    }
                }
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
        }
        public static async Task<int> InsertUpdateReceiptDetails(EnReceiptDetails enReceiptDetails)
        {
            int intRetValeu = 0;
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                string strCommand = "";
                bool isEdit = false;
                if (string.IsNullOrEmpty(Convert.ToString(enReceiptDetails.Receipt_Id)) || enReceiptDetails.Receipt_Id == 0)
                {
                    strCommand = @"Insert into ReceiptDetail (Receipt_No,Receipt_Date,Customer_Id,Flate_ShopNo,Cheq_Rtgs_Neft_ImpsNo,Year_Id,Bank_Name,Branch_Name,ReceivedAs,Amount,Amount_Word,Ent_By,Ent_Date,Payment_Date,ReceiptDateNo,IsCancel,IsPrint) VALUES
                                    (@Receipt_No,@Receipt_Date,@Customer_Id,@Flate_ShopNo,@Cheq_Rtgs_Neft_ImpsNo,@Year_Id,@Bank_Name,@Branch_Name,@ReceivedAs,@Amount,@Amount_Word,@Ent_By,@Ent_Date,@PaymentDate,@ReceiptDateNo,@IsCancel,@IsPrint); 
                                    SELECT last_insert_rowid() FROM ReceiptDetail;";
                }
                else
                {
                    isEdit = true;
                    strCommand = @"UPDATE ReceiptDetail
                                SET Receipt_No=@Receipt_No,
                                Receipt_Date=@Receipt_Date,
                                Customer_Id=@Customer_Id,
                                Flate_ShopNo=@Flate_ShopNo,
                                Cheq_Rtgs_Neft_ImpsNo=@Cheq_Rtgs_Neft_ImpsNo,
                                Year_Id=@Year_Id,
                                Bank_Name=@Bank_Name,
                                Branch_Name=@Branch_Name,
                                ReceivedAs=@ReceivedAs,
                                Amount=@Amount,
                                Amount_Word=@Amount_Word,
                                Up_By=@Up_By,
                                Up_Date=@Up_Date,
                                Payment_Date=@PaymentDate,
                                ReceiptDateNo=@ReceiptDateNo,
                                IsCancel=@IsCancel,
                                IsPrint=@IsPrint
                                WHERE Receipt_Id=@Receipt_Id; SELECT @Receipt_Id;";
                }
                cmd.CommandText = strCommand;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Receipt_No", enReceiptDetails.Receipt_No);
                cmd.Parameters.AddWithValue("@Receipt_Date", enReceiptDetails.Receipt_Date);
                cmd.Parameters.AddWithValue("@Customer_Id", enReceiptDetails.Customer_Id);
                cmd.Parameters.AddWithValue("@Flate_ShopNo", enReceiptDetails.Flate_ShopNo);
                cmd.Parameters.AddWithValue("@Cheq_Rtgs_Neft_ImpsNo", enReceiptDetails.Cheq_Rtgs_Neft_ImpsNo);
                cmd.Parameters.AddWithValue("@Year_Id", enReceiptDetails.Year_Id);
                cmd.Parameters.AddWithValue("@Bank_Name", enReceiptDetails.Bank_Name);
                cmd.Parameters.AddWithValue("@Branch_Name", enReceiptDetails.Branch_Name);
                cmd.Parameters.AddWithValue("@ReceivedAs", enReceiptDetails.ReceivedAs);
                cmd.Parameters.AddWithValue("@Amount", enReceiptDetails.Amount);
                cmd.Parameters.AddWithValue("@Amount_Word", enReceiptDetails.Amount_Word);

                if (!isEdit)
                {
                    cmd.Parameters.AddWithValue("@Ent_By", 1);
                    cmd.Parameters.AddWithValue("@Ent_Date", DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Up_By", 1);
                    cmd.Parameters.AddWithValue("@Up_Date", DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"));
                    cmd.Parameters.AddWithValue("@Receipt_Id", enReceiptDetails.Receipt_Id);
                }

                cmd.Parameters.AddWithValue("@PaymentDate", enReceiptDetails.PaymentDate);
                cmd.Parameters.AddWithValue("@ReceiptDateNo", enReceiptDetails.ReceiptDateNo);
                cmd.Parameters.AddWithValue("@IsCancel", enReceiptDetails.IsCancel);
                cmd.Parameters.AddWithValue("@IsPrint",enReceiptDetails.IsPrint);
                var Valeu = await DaDatabaseConnection.ExecSacaler(cmd);
                intRetValeu = Convert.ToInt32(Valeu);
                return intRetValeu;
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }
        }
    }
}
