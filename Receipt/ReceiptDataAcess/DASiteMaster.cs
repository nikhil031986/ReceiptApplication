using ReceiptEntity;
using ReceiptLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptDataAcess
{
    public static class DASiteMaster
    {
        public static async Task<List<EnSiteMaster>> GetSiteMaster(int SiteMasterId)
        {
            List<EnSiteMaster> lstCustomers = new List<EnSiteMaster>();
            DataTable dtCustomer = new DataTable();
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                cmd.CommandText = @"SELECT Site_Master_Id,Site_Name,DB_Name,Site_Address,Created_Date FROM Site_Master " + (SiteMasterId == 0 ? ";" : " WHERE Site_Master_Id=@Site_Master_Id;");
                if (SiteMasterId > 0)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Site_Master_Id", SiteMasterId);
                }
                dtCustomer = await DaDatabaseConnection.GetDataTable(cmd);
                if (dtCustomer != null && dtCustomer.AsEnumerable().Count() > 0)
                {
                    dtCustomer.AsEnumerable().ToList().ForEach(firstRow =>
                    {
                        lstCustomers.Add(new EnSiteMaster(Convert.ToInt32(firstRow["Site_Master_Id"]),
                                                            Convert.ToString(firstRow["Site_Name"]),
                                                            Convert.ToString(firstRow["DB_Name"]),
                                                            Convert.ToString(firstRow["Site_Address"]),
                                                            Convert.ToString(firstRow["Created_Date"])));
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
        public static async Task<int> InsertUpdateSiteMaster(EnSiteMaster enSiteMaster)
        {
            int intRetValeu = 0;
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                string strCommand = "";
                bool isEdit = false;
                if (string.IsNullOrEmpty(Convert.ToString(enSiteMaster.Site_Master_Id)) || enSiteMaster.Site_Master_Id== 0)
                {
                    strCommand = @"Insert into Site_Master (Site_Name,DB_Name,Site_Address,Created_Date) VALUES
                                    (@Site_Name,@DB_Name,@Site_Address,@Created_Date); 
                                    SELECT last_insert_rowid() FROM Site_Master;";
                }
                else
                {
                    isEdit = true;
                    strCommand = @"UPDATE Site_Master
                                SET Site_Name=@Site_Name,
                                DB_Name=@DB_Name,
                                Site_Address=@Site_Address,
                                Created_Date=@Created_Date
                                WHERE Site_Master_Id=@Site_Master_Id; SELECT @Site_Master_Id;";
                }
                cmd.CommandText = strCommand;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Site_Name", enSiteMaster.Site_Name);
                cmd.Parameters.AddWithValue("@DB_Name", enSiteMaster.DB_Name);
                cmd.Parameters.AddWithValue("@Site_Address", enSiteMaster.Site_Address);
                cmd.Parameters.AddWithValue("@Created_Date", enSiteMaster.Created_Date);

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
