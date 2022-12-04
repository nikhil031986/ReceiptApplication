using ReceiptEntity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using ReceiptLog;
using System.Reflection;

namespace ReceiptDataAcess
{
    internal  static class DaDatabaseConnection
    {
        private static readonly string strMainDataBase = @"Data Source = MasterDb.db";
        public static string SelectedSiteDataBase { get; set; }
        public static async Task<List<EnUserDetails>> GetData(SQLiteCommand cmd)
        {
            if(string.IsNullOrWhiteSpace(SelectedSiteDataBase))
            {
                SelectedSiteDataBase = strMainDataBase;
            }
            List<EnUserDetails> retUserDetails = new List<EnUserDetails>();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(SelectedSiteDataBase))
                {
                    conn.Open();
                    using (SQLiteCommand sqlcmd = cmd)
                    {
                        sqlcmd.Connection = conn;
                        cmd.Prepare();
                        using (SQLiteDataReader reader = sqlcmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                retUserDetails.Add(new EnUserDetails(Convert.ToInt32(reader["Use_DetailId"]),
                                                    Convert.ToString(reader["User_Name"]),
                                                    Convert.ToString(reader["Password"]),
                                                    Convert.ToInt16(reader["IsAdmin"]),
                                                    Convert.ToInt16(reader["ISEdit"]),
                                                    Convert.ToInt16(reader["IsDelete"])
                                    ));
                            }
                        }
                    }
                    conn.Close();
                }
                return retUserDetails;
            }
            catch(Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
        }
        internal async static Task<DataSet> GetDataSet(SQLiteCommand cmd)
        {
            if (string.IsNullOrWhiteSpace(SelectedSiteDataBase))
            {
                SelectedSiteDataBase = strMainDataBase;
            }
            DataSet dtreturn = new DataSet();
            try
            {
                await Task.Run(() =>
                {
                    using (SQLiteConnection conn = new SQLiteConnection(SelectedSiteDataBase))
                    {
                        using (SQLiteCommand sqlcmd = cmd)
                        {
                            sqlcmd.Connection = conn;
                            using (SQLiteDataAdapter adp = new SQLiteDataAdapter(sqlcmd))
                            {
                                adp.Fill(dtreturn);
                            }
                        }
                    }
                });
                return dtreturn;
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
            finally
            {
                dtreturn.Dispose();
            }
        }
        internal async static Task<DataTable> GetDataTable(SQLiteCommand cmd)
        {
            if (string.IsNullOrWhiteSpace(SelectedSiteDataBase))
            {
                SelectedSiteDataBase = strMainDataBase;
            }
            DataTable dtreturn = new DataTable();
            try
            {
               await Task.Run(()=>
                {
                    using (SQLiteConnection conn = new SQLiteConnection(SelectedSiteDataBase))
                    {
                        using (SQLiteCommand sqlcmd = cmd)
                        {
                            sqlcmd.Connection = conn;
                            using (SQLiteDataAdapter adp = new SQLiteDataAdapter(sqlcmd))
                            {
                                adp.Fill(dtreturn);
                            }
                        }
                    }
                });
                return dtreturn;
            }
            catch(Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error,MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
            finally
            {
                dtreturn.Dispose();
            }
        }
        internal async static Task<object> ExecSacaler(SQLiteCommand cmd)
        {
            if (string.IsNullOrWhiteSpace(SelectedSiteDataBase))
            {
                SelectedSiteDataBase = strMainDataBase;
            }
            object retObject = null;
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(SelectedSiteDataBase))
                {
                    conn.Open();
                    using (SQLiteCommand sqlcmd = cmd)
                    {
                        cmd.Connection = conn;
                        cmd.Prepare();
                        retObject = await sqlcmd.ExecuteScalarAsync();
                    }
                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
            return retObject;
        }
    }
}
