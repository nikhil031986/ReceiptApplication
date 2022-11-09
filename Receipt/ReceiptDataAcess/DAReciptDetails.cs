using ReceiptEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
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
                                    RD.Year_Id,RD.Bank_Name,RD.Branch_Name,RD.ReceivedAs,RD.Amount,RD.Amount_Word, RD.Payment_Date, RD.ReceiptDateNo FROM 
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
                                                        Convert.ToInt32(firstRow["ReceiptDateNo"])));
                    });
                }
                return lstCustomers;
            }
            catch (Exception ex)
            {
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
                                    RD.Year_Id,RD.Bank_Name,RD.Branch_Name,RD.ReceivedAs,RD.Amount,RD.Amount_Word, RD.Payment_Date, RD.ReceiptDateNo FROM 
                                    ReceiptDetail RD
                                    INNER JOIN Customer_Master CM
                                    ON RD.Customer_Id = CM.Customer_Id " + (CustomerID == 0 ? ";" : " WHERE CM.Customer_Id=@Customer_Id;");
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
                                                        Convert.ToInt32(firstRow["ReceiptDateNo"])));
                    });
                }
                return lstCustomers;
            }
            catch (Exception ex)
            {
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
                cmd.CommandText = @"SELECT RD.Receipt_Id,RD.Receipt_No,
                                    RD.Receipt_Date,RD.Customer_Id,CM.Customer_Name,RD.Flate_ShopNo,RD.Cheq_Rtgs_Neft_ImpsNo,
                                    RD.Year_Id,RD.Bank_Name,RD.Branch_Name,RD.ReceivedAs,RD.Amount,RD.Amount_Word, RD.Payment_Date, RD.ReceiptDateNo FROM 
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
                                                        Convert.ToInt32(firstRow["ReceiptDateNo"])));
                    });
                }
                return lstCustomers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dtCustomer.Dispose();
                cmd.Dispose();
            }
        }
        public static async Task<string> getReceiptNo()
        {
            string strRetValeu = "00-00-000";
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                string strCommand = "";
                strCommand = @" SELECT substr( strftime('%Y',DATE()),3,2)||'-'||
                                CAST(CAST(substr( strftime('%Y',DATE()),3,2) AS INT)+1 AS TEXT)||'-'||
                                (CASE  length(CAST( CAST(substr(ifnull(Receipt_No,'00-00-000'),7,3) AS INT)+1 AS TEXT))
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
                throw ex;
            }
            finally
            {
                cmd.Dispose();
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
                    strCommand = @"Insert into ReceiptDetail (Receipt_No,Receipt_Date,Customer_Id,Flate_ShopNo,Cheq_Rtgs_Neft_ImpsNo,Year_Id,Bank_Name,Branch_Name,ReceivedAs,Amount,Amount_Word,Ent_By,Ent_Date,Payment_Date,ReceiptDateNo) VALUES
                                    (@Receipt_No,@Receipt_Date,@Customer_Id,@Flate_ShopNo,@Cheq_Rtgs_Neft_ImpsNo,@Year_Id,@Bank_Name,@Branch_Name,@ReceivedAs,@Amount,@Amount_Word,@Ent_By,@Ent_Date,@PaymentDate,@ReceiptDateNo); 
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
                                ReceiptDateNo=@ReceiptDateNo
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
                var Valeu = await DaDatabaseConnection.ExecSacaler(cmd);
                intRetValeu = Convert.ToInt32(Valeu);
                return intRetValeu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }
        }
    }
}
