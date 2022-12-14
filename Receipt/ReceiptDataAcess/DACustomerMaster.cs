using ReceiptEntity;
using ReceiptLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptDataAcess
{
    public static class DACustomerMaster
    {
        public static async Task<EnCommonRet> GetCustomerDT(int customerId, bool isNext)
        {
            EnCommonRet enCommonRet = new EnCommonRet();
            DataSet retDataTable = new DataSet();
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                cmd.CommandText = @"SELECT CM.Customer_Id,CM.Wing_Master_Id,CM.Wing_Details_Id,WM.Wing_Name,WD.FlatNo,CM.Customer_Name,CM.Address,
                                        CM.Con_Details,CM.Email_Id,CM.Customer_Wing_Name,CM.Pan,CM.Aadhar,CM.Customer1,CM.Pan1,CM.Aadhar1,CM.Customer2,CM.Pan2,CM.Aadhar2,CM.Customer3,CM.Pan3,CM.Aadhar3
                                    FROM Customer_Master CM
                                    INNER JOIN Wing_Master WM
                                        ON WM.Wing_Master_Id = CM.Wing_Master_Id
                                    INNER JOIN Wing_Details WD
                                        ON WM.Wing_Master_Id = WD.Wing_MasterId
                                    AND CM.Wing_Details_Id = WD.Wing_DetailsId " + (customerId == 0 ? "" : " WHERE Customer_Id"+(isNext==true?">":"<")+ "@Customer_Id")+ " ORDER BY Customer_Id;SELECT COUNT(*) FROM Customer_Master;";
                if (customerId > 0)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Cheq_Details_Id", customerId);
                }
                retDataTable = await DaDatabaseConnection.GetDataSet(cmd);
                enCommonRet.dtForReturn = retDataTable.Tables[0];
                enCommonRet.TotalNumber = Convert.ToString(retDataTable.Tables[1].Rows[0][0]);
                return enCommonRet;
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, "DACustomerMaster.GetCustomerDT");
                throw ex;
            }
            finally
            {
                retDataTable.Dispose();
            }
        }
        public static async Task<List<EnCustomer>> GetCustomer(int customerId=0)
        {
            List<EnCustomer> lstCustomers = new List<EnCustomer>();
            DataTable dtCustomer = new DataTable();
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                cmd.CommandText = @"SELECT CM.Customer_Id,CM.Wing_Master_Id,CM.Wing_Details_Id,WM.Wing_Name,WD.FlatNo,CM.Customer_Name,CM.Address,
                                        CM.Con_Details,CM.Email_Id,CM.Customer_Wing_Name,CM.Pan,CM.Aadhar,CM.Customer1,CM.Pan1,CM.Aadhar1,CM.Customer2,CM.Pan2,CM.Aadhar2,CM.Customer3,CM.Pan3,CM.Aadhar3
                                    FROM Customer_Master CM
                                    INNER JOIN Wing_Master WM
                                        ON WM.Wing_Master_Id = CM.Wing_Master_Id
                                    INNER JOIN Wing_Details WD
                                        ON WM.Wing_Master_Id = WD.Wing_MasterId
                                    AND CM.Wing_Details_Id = WD.Wing_DetailsId " + (customerId == 0 ? ";" : " WHERE Customer_Id=@Customer_Id;");
                if (customerId > 0)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Customer_Id", customerId);
                }
                dtCustomer = await DaDatabaseConnection.GetDataTable(cmd);
                if (dtCustomer != null && dtCustomer.AsEnumerable().Count() > 0)
                {
                    dtCustomer.AsEnumerable().ToList().ForEach(firstRow =>
                    {
                        lstCustomers.Add(new EnCustomer(
                            Convert.ToInt32(firstRow["Customer_Id"]),
                                                        Convert.ToInt32(firstRow["Wing_Master_Id"]),
                                                        Convert.ToInt32(firstRow["Wing_Details_Id"]),
                                                        Convert.ToString(firstRow["Wing_Name"]),
                                                        Convert.ToString(firstRow["FlatNo"]),
                                                        Convert.ToString(firstRow["Customer_Name"]),
                                                        Convert.ToString(firstRow["Address"]),
                                                        Convert.ToString(firstRow["Con_Details"]),
                                                        Convert.ToString(firstRow["Email_Id"]),
                                                        Convert.ToString(firstRow["Customer_Wing_Name"]),

                                                        Convert.ToString(firstRow["Pan"]),
                                                        Convert.ToString(firstRow["Aadhar"]),
                                                        Convert.ToString(firstRow["Customer1"]),
                                                        Convert.ToString(firstRow["Pan1"]),
                                                        Convert.ToString(firstRow["Aadhar1"]),
                                                        Convert.ToString(firstRow["Customer2"]),
                                                        Convert.ToString(firstRow["Pan2"]),
                                                         Convert.ToString(firstRow["Aadhar2"]),
                                                        Convert.ToString(firstRow["Customer3"]),
                                                        Convert.ToString(firstRow["Pan3"]),
                                                        Convert.ToString(firstRow["Aadhar3"])
                                                        ));
                    });
                }
                return lstCustomers;
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, "ReceiptDataAcess.DACustomerMaster.GetCustomer");
                throw ex;
            }
            finally
            {
                dtCustomer.Dispose();
                cmd.Dispose();
            }
        }
        public static async Task<List<EnCustomer>> GetCustomeriByName(string customerName)
        {
            List<EnCustomer> lstCustomers = new List<EnCustomer>();
            DataTable dtCustomer = new DataTable();
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                cmd.CommandText = @"SELECT CM.Customer_Id,CM.Wing_Master_Id,CM.Wing_Details_Id,WM.Wing_Name,WD.FlatNo,CM.Customer_Name,CM.Address,
                                        CM.Con_Details,CM.Email_Id,CM.Customer_Wing_Name,CM.Pan,CM.Aadhar,CM.Customer1,CM.Pan1,CM.Aadhar1,CM.Customer2,CM.Pan2,CM.Aadhar2,CM.Customer3,CM.Pan3,CM.Aadhar3
                                    FROM Customer_Master CM
                                    INNER JOIN Wing_Master WM
                                        ON WM.Wing_Master_Id = CM.Wing_Master_Id
                                    INNER JOIN Wing_Details WD
                                        ON WM.Wing_Master_Id = WD.Wing_MasterId
                                    AND CM.Wing_Details_Id = WD.Wing_DetailsId " + (customerName == "" ? ";" : " WHERE Customer_Name=@Customer_Name;");
                if (!string.IsNullOrEmpty(customerName ))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Customer_Name", customerName);
                }
                dtCustomer = await DaDatabaseConnection.GetDataTable(cmd);
                if (dtCustomer != null && dtCustomer.AsEnumerable().Count() > 0)
                {
                    dtCustomer.AsEnumerable().ToList().ForEach(firstRow =>
                    {
                        lstCustomers.Add(new EnCustomer(
                            Convert.ToInt32(firstRow["Customer_Id"]),
                                                        Convert.ToInt32(firstRow["Wing_Master_Id"]),
                                                        Convert.ToInt32(firstRow["Wing_Details_Id"]),
                                                        Convert.ToString(firstRow["Wing_Name"]),
                                                        Convert.ToString(firstRow["FlatNo"]),
                                                        Convert.ToString(firstRow["Customer_Name"]),
                                                        Convert.ToString(firstRow["Address"]),
                                                        Convert.ToString(firstRow["Con_Details"]),
                                                        Convert.ToString(firstRow["Email_Id"]),
                                                        Convert.ToString(firstRow["Customer_Wing_Name"]),

                                                        Convert.ToString(firstRow["Pan"]),
                                                        Convert.ToString(firstRow["Aadhar"]),
                                                        Convert.ToString(firstRow["Customer1"]),
                                                        Convert.ToString(firstRow["Pan1"]),
                                                        Convert.ToString(firstRow["Aadhar1"]),
                                                        Convert.ToString(firstRow["Customer2"]),
                                                        Convert.ToString(firstRow["Pan2"]),
                                                         Convert.ToString(firstRow["Aadhar2"]),
                                                        Convert.ToString(firstRow["Customer3"]),
                                                        Convert.ToString(firstRow["Pan3"]),
                                                        Convert.ToString(firstRow["Aadhar3"])
                                                        ));
                    });
                }
                return lstCustomers;
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, "ReceiptDataAcess.DACustomerMaster.GetCustomeriByName");
                throw ex;
            }
            finally
            {
                dtCustomer.Dispose();
                cmd.Dispose();
            }
        }
        public static async Task<int> InsertUpdateCustomer(EnCustomer enCustomer)
        {
            int intRetValeu = 0;
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                string strCommand = "";
                bool isEdit = false;
                if (string.IsNullOrEmpty(Convert.ToString(enCustomer.Customer_Id)) || enCustomer.Customer_Id == 0)
                {
                    strCommand = @"Insert into Customer_Master (Wing_Master_Id,Wing_Details_Id,Customer_Name,Address,Con_Details,Email_Id,Customer_Wing_Name,Entry_By,Entry_DateTime,Pan,Aadhar,Customer1,Pan1,Aadhar1,Customer2,Pan2,Aadhar2,Customer3,Pan3,Aadhar3) VALUES
                                    (@Wing_Master_Id,@Wing_Details_Id,@Customer_Name,@Address,@Con_Details,@Email_Id,@Customer_Wing_Name,@Entry_By,@Entry_DateTime,@Pan,@Aadhar,@Customer1,@Pan1,@Aadhar1,@Customer2,@Pan2,@Aadhar2,@Customer3,@Pan3,@Aadhar3); 
                                    SELECT last_insert_rowid() FROM Customer_Master;";
                }
                else
                {
                    isEdit = true;
                    strCommand = @"Update Customer_Master set Wing_Master_Id=@Wing_Master_Id,Wing_Details_Id=@Wing_Details_Id,
                                Customer_Name=@Customer_Name,Address=@Address,Con_Details=@Con_Details,Email_Id=@Email_Id,
                                Customer_Wing_Name=@Customer_Wing_Name, Update_By=@Update_By, Update_DateTime=@Update_DateTime, 
                                Pan=@Pan,Aadhar=@Aadhar,Customer1=@Customer1,Pan1=@Pan1,Aadhar1=@Aadhar1,
                                Customer2=@Customer2,Pan2=@Pan2,Aadhar2=@Aadhar2,Customer3=@Customer3,Pan3=@Pan3,Aadhar3=@Aadhar3
                                WHERE Customer_Id=@Customer_Id; SELECT @Customer_Id;";
                }
                cmd.CommandText = strCommand;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Wing_Master_Id", enCustomer.Wing_Master_Id);
                cmd.Parameters.AddWithValue("@Wing_Details_Id", enCustomer.Wing_Details_Id);
                cmd.Parameters.AddWithValue("@Customer_Name", enCustomer.Customer_Name);
                cmd.Parameters.AddWithValue("@Address", enCustomer.Address);
                cmd.Parameters.AddWithValue("@Con_Details", enCustomer.Con_Details);
                cmd.Parameters.AddWithValue("@Email_Id", enCustomer.Email_Id);
                cmd.Parameters.AddWithValue("@Customer_Wing_Name", enCustomer.Customer_Wing_Name);
                cmd.Parameters.AddWithValue("@Pan", enCustomer.Pan);
                cmd.Parameters.AddWithValue("@Aadhar", enCustomer.Aadhar);
                cmd.Parameters.AddWithValue("@Customer1", enCustomer.Customer1);
                cmd.Parameters.AddWithValue("@Pan1", enCustomer.Pan1);
                cmd.Parameters.AddWithValue("@Aadhar1", enCustomer.Aadhar1);
                cmd.Parameters.AddWithValue("@Customer2", enCustomer.Customer2);
                cmd.Parameters.AddWithValue("@Pan2", enCustomer.Pan2);
                cmd.Parameters.AddWithValue("@Aadhar2", enCustomer.Aadhar2);
                cmd.Parameters.AddWithValue("@Customer3", enCustomer.Customer3);
                cmd.Parameters.AddWithValue("@Pan3", enCustomer.Pan3);
                cmd.Parameters.AddWithValue("@Aadhar3", enCustomer.Aadhar3);

                if (!isEdit)
                {
                    cmd.Parameters.AddWithValue("@Entry_By", 1);
                    cmd.Parameters.AddWithValue("@Entry_DateTime", DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Update_By", 1);
                    cmd.Parameters.AddWithValue("@Update_DateTime", DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"));
                    cmd.Parameters.AddWithValue("@Customer_Id", enCustomer.Customer_Id);
                }
                var Valeu = await DaDatabaseConnection.ExecSacaler(cmd);
                intRetValeu = Convert.ToInt32(Valeu);
                return intRetValeu;
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, "ReceiptDataAcess.DACustomerMaster.InsertUpdateCustomer");
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }
        }
    }
}
