using ReceiptEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptDataAcess
{
    public static class DACheqDetails
    {
        public static async Task<List<EnCheqDetails>> GetCheqDetails(int CheqDetailsId)
        {
            List<EnCheqDetails> lstCustomers = new List<EnCheqDetails>();
            DataTable dtCustomer = new DataTable();
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                cmd.CommandText = @"SELECT Cheq_Details_Id,Customer_Name,Cheq_Date,Amount,Amount_InWord,Bank_Name,Cheq_No FROM Cheq_Details " + (CheqDetailsId == 0 ? ";" : " WHERE Cheq_Details_Id=@Cheq_Details_Id;");
                if (CheqDetailsId > 0)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Cheq_Details_Id", CheqDetailsId);
                }
                dtCustomer = await DaDatabaseConnection.GetDataTable(cmd);
                if (dtCustomer != null && dtCustomer.AsEnumerable().Count() > 0)
                {
                    dtCustomer.AsEnumerable().ToList().ForEach(firstRow =>
                    {
                        lstCustomers.Add(new EnCheqDetails(Convert.ToInt32(firstRow["Cheq_Details_Id"]),
                                                            Convert.ToString(firstRow["Customer_Name"]),
                                                            Convert.ToString(firstRow["Cheq_Date"]),
                                                            Convert.ToDecimal(firstRow["Amount"]),
                                                            Convert.ToString(firstRow["Amount_InWord"]),
                                                            Convert.ToString(firstRow["Bank_Name"]),
                                                            Convert.ToString(firstRow["Cheq_No"])));
                    });
                }
                return lstCustomers;
            }
            catch (Exception ex)
            {
                ReceiptLog.clsLog.InstanceCreation().InsertLog(ex.Message, ReceiptLog.clsLog.logType.Error, "DACheqDetails.GetCheqDetails");
                throw ex;
            }
            finally
            {
                dtCustomer.Dispose();
                cmd.Dispose();
            }
        }
        public static async Task<List<string>> GetCustomerName()
        {
            List<string> lstCustomers = new List<string>();
            DataTable dtCustomer = new DataTable();
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                cmd.CommandText = @"SELECT Distinct Customer_Name FROM Cheq_Details;";
                
                dtCustomer = await DaDatabaseConnection.GetDataTable(cmd);
                if (dtCustomer != null && dtCustomer.AsEnumerable().Count() > 0)
                {
                    dtCustomer.AsEnumerable().ToList().ForEach(firstRow =>
                    {
                        lstCustomers.Add(Convert.ToString(firstRow["Customer_Name"]));
                    });
                }
                return lstCustomers;
            }
            catch (Exception ex)
            {
                ReceiptLog.clsLog.InstanceCreation().InsertLog(ex.Message, ReceiptLog.clsLog.logType.Error, "DACheqDetails.GetCustomerName");
                throw ex;
            }
            finally
            {
                dtCustomer.Dispose();
                cmd.Dispose();
            }
        }
        public static async Task<int> InsertUpdateCheqDetqails(EnCheqDetails enCheqDetails)
        {
            int intRetValeu = 0;
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                string strCommand = "";
                bool isEdit = false;
                if (string.IsNullOrEmpty(Convert.ToString(enCheqDetails.Cheq_Details_Id)) || enCheqDetails.Cheq_Details_Id== 0)
                {
                    strCommand = @"Insert into Cheq_Details (Customer_Name,Cheq_Date,Amount,Amount_InWord,Ent_By,Ent_Date,Bank_Name,Cheq_No) VALUES
                                    (@Customer_Name,@Cheq_Date,@Amount,@Amount_InWord,@Ent_By,@Ent_Date,@Bank_Name,@Cheq_No); 
                                    SELECT last_insert_rowid() FROM Cheq_Details;";
                }
                else
                {
                    isEdit = true;
                    strCommand = @"UPDATE Cheq_Details
                                SET Customer_Name=@Customer_Name,
                                Cheq_Date=@Cheq_Date,
                                Amount=@Amount,
                                Amount_InWord=@Amount_InWord,
                                Update_By=@Update_By,
                                Update_Date=@Update_Date,
                                Bank_Name=@Bank_Name,
                                Cheq_No=@Cheq_No
                                WHERE Cheq_Details_Id=@Cheq_Details_Id; SELECT @Cheq_Details_Id;";
                }
                cmd.CommandText = strCommand;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Customer_Name", enCheqDetails.Customer_Name);
                cmd.Parameters.AddWithValue("@Cheq_Date", enCheqDetails.Cheq_Date);
                cmd.Parameters.AddWithValue("@Amount", enCheqDetails.Amount);
                cmd.Parameters.AddWithValue("@Amount_InWord", enCheqDetails.Amount_InWord);
               

                if (!isEdit)
                {
                    cmd.Parameters.AddWithValue("@Ent_By", 1);
                    cmd.Parameters.AddWithValue("@Ent_Date", DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Update_By", 1);
                    cmd.Parameters.AddWithValue("@Update_Date", DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"));
                    cmd.Parameters.AddWithValue("@Cheq_Details_Id", enCheqDetails.Cheq_Details_Id);
                }

                cmd.Parameters.AddWithValue("@Bank_Name", enCheqDetails.Bank_Name);
                cmd.Parameters.AddWithValue("Cheq_No", enCheqDetails.Cheq_No);

                var Valeu = await DaDatabaseConnection.ExecSacaler(cmd);
                intRetValeu = Convert.ToInt32(Valeu);
                return intRetValeu;
            }
            catch (Exception ex)
            {
                ReceiptLog.clsLog.InstanceCreation().InsertLog(ex.Message, ReceiptLog.clsLog.logType.Error, "DACheqDetails.InsertUpdateCheqDetqails");
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }
        }
    }
}
