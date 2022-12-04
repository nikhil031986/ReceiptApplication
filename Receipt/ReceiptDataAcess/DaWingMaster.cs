using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReceiptEntity;

namespace ReceiptDataAcess
{
    public static class DaWingMaster
    {
        public static async Task<List<EnWingMaster>> GetWingMaster(int WingMasterId = 0)
        {
            List<EnWingMaster> lstWingMaster = new List<EnWingMaster>();
            DataTable dtWingMaster = new DataTable();
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                cmd.CommandText = "SELECT Wing_Master_Id,Wing_Name,Floar_Count,Hous_Count,Start_Number,End_Number,Ent_UserId,Ent_DateTime,Update_UserID,Update_Date FROM Wing_Master" + (WingMasterId == 0 ? ";" : " WHERE Wing_Master_Id=@Wing_Master_Id;");
                if (WingMasterId > 0)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Wing_Master_Id", WingMasterId);
                }
                dtWingMaster = await DaDatabaseConnection.GetDataTable(cmd);
                if (dtWingMaster != null && dtWingMaster.AsEnumerable().Count() > 0)
                {
                    dtWingMaster.AsEnumerable().ToList().ForEach(firstRow =>
                    {
                        lstWingMaster.Add(new EnWingMaster(Convert.ToInt32(firstRow["Wing_Master_Id"]),
                        Convert.ToString(firstRow["Wing_Name"]),
                        Convert.ToInt32(firstRow["Floar_Count"]),
                        Convert.ToInt32(firstRow["Hous_Count"]),
                        Convert.ToInt32(firstRow["Start_Number"]),
                         Convert.ToInt32(firstRow["End_Number"])
                       ));
                    });
                }
                return lstWingMaster;
            }
            catch (Exception ex)
            {
                ReceiptLog.clsLog.InstanceCreation().InsertLog(ex.Message, ReceiptLog.clsLog.logType.Error, "DaWingMaster.GetWingMaster");
                throw ex;
            }
            finally
            {
                dtWingMaster.Dispose();
            }
        }
        public static async Task<EnWingMaster> GetWingMasterByName(string wingName)
        {
            EnWingMaster enWingMaster = new EnWingMaster();
            List<EnWingDetails> enWingDetails = new List<EnWingDetails>();
            SQLiteCommand command = new SQLiteCommand();
            try
            {
                command.CommandText = "SELECT Wing_Master_Id,Wing_Name,Floar_Count,Hous_Count,Start_Number,End_Number,Ent_UserId,Ent_DateTime,Update_UserID,Update_Date FROM Wing_Master WHERE Wing_Name=@Wing_Name;";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@Wing_Name", wingName);
                DataTable dtWingMaster = await DaDatabaseConnection.GetDataTable(command);
                if (dtWingMaster != null && dtWingMaster.AsEnumerable().Count() > 0)
                {
                    var firstRow = dtWingMaster.AsEnumerable().FirstOrDefault();
                    enWingMaster = new EnWingMaster(Convert.ToInt32(firstRow["Wing_Master_Id"]),
                        Convert.ToString(firstRow["Wing_Name"]),
                        Convert.ToInt32(firstRow["Floar_Count"]),
                        Convert.ToInt32(firstRow["Hous_Count"]),
                        Convert.ToInt32(firstRow["Start_Number"]),
                        Convert.ToInt32(firstRow["End_Number"]));
                    command = new SQLiteCommand();
                    command.CommandText = "SELECT Wing_DetailsId,Wing_MasterId,FlatNo,Wing_Name,IFNULL(Land, 0 ) as Land,IFNULL(Carpet, 0 ) as Carpet,IFNULL(WB, 0 ) as WB,IFNULL(Amount, 0 ) as Amount,IFNULL(Total, 0 ) as Total,EAST,WEST,NORTH,SOUTH,FlorName FROM Wing_Details WHERE Wing_MasterId=@Wing_MasterId";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@Wing_MasterId", enWingMaster.Wing_Master_Id);
                    dtWingMaster = await DaDatabaseConnection.GetDataTable(command);
                    if (dtWingMaster != null && dtWingMaster.AsEnumerable().Count() > 0)
                    {
                        dtWingMaster.AsEnumerable().ToList().ForEach(x =>
                        {
                            enWingDetails.Add(new EnWingDetails(Convert.ToInt32(x["Wing_DetailsId"]),
                                enWingMaster.Wing_Master_Id,
                                Convert.ToString(x["FlatNo"]),
                                enWingMaster.Wing_Name,
                                 Convert.ToDecimal(x["Land"]),
                                 Convert.ToDecimal(x["Carpet"]),
                                 Convert.ToDecimal(x["WB"]),
                                 Convert.ToDecimal(x["Amount"]),
                                 Convert.ToDecimal(x["Total"]),
                                  Convert.ToString(x["EAST"]),
                                 Convert.ToString(x["WEST"]),
                                 Convert.ToString(x["NORTH"]),
                                 Convert.ToString(x["SOUTH"]),
                                 Convert.ToString(x["FlorName"])
                                ));
                        });
                    }
                    enWingMaster.enWingDetails = enWingDetails;
                }
                return enWingMaster;
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
        public static async Task<EnWingMaster> getWingMaster(int wingMasterId)
        {
            EnWingMaster enWingMaster = new EnWingMaster();
            List<EnWingDetails> enWingDetails = new List<EnWingDetails>();
            SQLiteCommand command = new SQLiteCommand();
            try
            {
                command.CommandText = "SELECT Wing_Master_Id,Wing_Name,Floar_Count,Hous_Count,Start_Number,End_Number,Ent_UserId,Ent_DateTime,Update_UserID,Update_Date FROM Wing_Master WHERE Wing_Master_Id=@Wing_Master_Id;";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@Wing_Master_Id", wingMasterId);
                DataTable dtWingMaster = await DaDatabaseConnection.GetDataTable(command);
                if (dtWingMaster != null && dtWingMaster.AsEnumerable().Count() > 0)
                {
                    var firstRow = dtWingMaster.AsEnumerable().FirstOrDefault();
                    enWingMaster = new EnWingMaster(Convert.ToInt32(firstRow["Wing_Master_Id"]),
                        Convert.ToString(firstRow["Wing_Name"]),
                        Convert.ToInt32(firstRow["Floar_Count"]),
                        Convert.ToInt32(firstRow["Hous_Count"]),
                        Convert.ToInt32(firstRow["Start_Number"]),
                        Convert.ToInt32(firstRow["End_Number"]));
                    command = new SQLiteCommand();
                    command.CommandText = "SELECT Wing_DetailsId,Wing_MasterId,FlatNo,Wing_Name,IFNULL(Land, 0 ) as Land,IFNULL(Carpet, 0 ) as Carpet,IFNULL(WB, 0 ) as WB,IFNULL(Amount, 0 ) as Amount,IFNULL(Total, 0 ) as Total,EAST,WEST,NORTH,SOUTH,FlorName FROM Wing_Details WHERE Wing_MasterId=@Wing_MasterId";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@Wing_MasterId", wingMasterId);
                    dtWingMaster = await DaDatabaseConnection.GetDataTable(command);
                    if (dtWingMaster != null && dtWingMaster.AsEnumerable().Count() > 0)
                    {
                        dtWingMaster.AsEnumerable().ToList().ForEach(x =>
                        {
                            enWingDetails.Add(new EnWingDetails(Convert.ToInt32(x["Wing_DetailsId"]),
                                wingMasterId,
                                Convert.ToString(x["FlatNo"]),
                                enWingMaster.Wing_Name,
                                 Convert.ToDecimal(x["Land"]),
                                 Convert.ToDecimal(x["Carpet"]),
                                 Convert.ToDecimal(x["WB"]),
                                 Convert.ToDecimal(x["Amount"]),
                                 Convert.ToDecimal(x["Total"]),
                                  Convert.ToString(x["EAST"]),
                                 Convert.ToString(x["WEST"]),
                                 Convert.ToString(x["NORTH"]),
                                 Convert.ToString(x["SOUTH"]),
                                 Convert.ToString(x["FlorName"])
                                ));
                        });
                    }
                    enWingMaster.enWingDetails = enWingDetails;
                }
                return enWingMaster;
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
        public static async Task<List<EnWingDetails>> GetWingDetails(int wingMasterId = 0)
        {
            List<EnWingDetails> lstwingDetails = new List<EnWingDetails>();
            DataTable dtWingMaster = new DataTable();
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                cmd.CommandText = "SELECT Wing_DetailsId,Wing_MasterId,FlatNo,Wing_Name,IFNULL(Land, 0 ) as Land,IFNULL(Carpet, 0 ) as Carpet,IFNULL(WB, 0 ) as WB,IFNULL(Amount, 0 ) as Amount,IFNULL(Total, 0 ) as Total,EAST,WEST,NORTH,SOUTH,FlorName FROM Wing_Details" + (wingMasterId == 0 ? ";" : " WHERE Wing_MasterId=@Wing_MasterId;");
                if (wingMasterId > 0)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Wing_MasterId", wingMasterId);
                }
                dtWingMaster = await DaDatabaseConnection.GetDataTable(cmd);
                if (dtWingMaster != null && dtWingMaster.AsEnumerable().Count() > 0)
                {
                    dtWingMaster.AsEnumerable().ToList().ForEach(firstRow =>
                    {
                        lstwingDetails.Add(new EnWingDetails(Convert.ToInt32(firstRow["Wing_DetailsId"]),
                            Convert.ToInt32(firstRow["Wing_MasterId"]),
                        Convert.ToString(firstRow["FlatNo"]),
                        Convert.ToString(firstRow["Wing_Name"]),

                        Convert.ToDecimal(firstRow["Land"]),
                        Convert.ToDecimal(firstRow["Carpet"]),
                        Convert.ToDecimal(firstRow["WB"]),
                        Convert.ToDecimal(firstRow["Amount"]),
                        Convert.ToDecimal(firstRow["Total"]),
                         Convert.ToString(firstRow["EAST"]),
                        Convert.ToString(firstRow["WEST"]),
                        Convert.ToString(firstRow["NORTH"]),
                        Convert.ToString(firstRow["SOUTH"]),
                        Convert.ToString(firstRow["FlorName"])
                        ));
                    });
                }
                return lstwingDetails;
            }
            catch (Exception ex)
            {
                ReceiptLog.clsLog.InstanceCreation().InsertLog(ex.Message, ReceiptLog.clsLog.logType.Error, "DaWingMaster.GetWingDetails");
                throw ex;
            }
            finally
            {
                dtWingMaster.Dispose();
                cmd.Dispose();
            }
        }
        public static async Task<int> InsertWingMaster(EnWingMaster wingMaster, List<EnWingDetails> wingDetails, int UserId)
        {
            int intRetValeu = 0;
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                string strCommand = "";
                bool isEdit = false;
                if (string.IsNullOrEmpty(Convert.ToString(wingMaster.Wing_Master_Id)) || wingMaster.Wing_Master_Id == 0)
                {
                    strCommand = "Insert into Wing_Master (Wing_Name,Floar_Count,Hous_Count,Start_Number,End_Number,Ent_UserId,Ent_UserId,Ent_DateTime) VALUES(@Wing_Name,@Floar_Count,@Hous_Count,@Start_Number,@End_Number,@Ent_UserId,@Ent_UserId,@Ent_DateTime); SELECT last_insert_rowid() FROM Wing_Master;";
                }
                else
                {
                    isEdit = true;
                    strCommand = "Update Wing_Master set Wing_Name=@Wing_Name,Floar_Count=@Floar_Count,Hous_Count=@Hous_Count,Start_Number=@Start_Number,End_Number=@End_Number,Update_UserID=@Update_UserID,Update_Date=@Update_Date WHERE Wing_Master_Id=@Wing_Master_Id; SELECT @Wing_Master_Id;";
                }
                cmd.CommandText = strCommand;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Wing_Name", wingMaster.Wing_Name);
                cmd.Parameters.AddWithValue("@Floar_Count", wingMaster.Floar_Count);
                cmd.Parameters.AddWithValue("@Hous_Count", wingMaster.Hous_Count);
                cmd.Parameters.AddWithValue("@Start_Number", wingMaster.Start_Number);
                cmd.Parameters.AddWithValue("@End_Number", wingMaster.End_Number);

                if (!isEdit)
                {
                    cmd.Parameters.AddWithValue("@Ent_UserId", UserId);
                    cmd.Parameters.AddWithValue("@Ent_DateTime", DateTime.Now.ToString("dd/MM/yyyy"));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Update_UserID", UserId);
                    cmd.Parameters.AddWithValue("@Update_Date", DateTime.Now.ToString("dd/MM/yyyy"));
                    cmd.Parameters.AddWithValue("@Wing_Master_Id", wingMaster.Wing_Master_Id);
                }
                var Valeu = await DaDatabaseConnection.ExecSacaler(cmd);
                intRetValeu = Convert.ToInt32(Valeu);
                wingMaster.Wing_Master_Id = intRetValeu;
                var InsertWingDetails = await InsertUpdateWingDetails(wingDetails, wingMaster.Wing_Master_Id);
                if (wingDetails.Count() != InsertWingDetails.Count())
                {
                    intRetValeu = -1;
                }
                return intRetValeu;
            }
            catch (Exception ex)
            {
                ReceiptLog.clsLog.InstanceCreation().InsertLog(ex.Message, ReceiptLog.clsLog.logType.Error, "DaWingMaster.InsertWingMaster");
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }
        }
        public static async Task<int> InsertUpdateWingDetails(EnWingDetails wingDetail, int wingMasterId)
        {
            decimal Total = wingDetail.Land + wingDetail.Carpet + wingDetail.WB;
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                string strCommand = "";
                bool isEdit = false;
                if (string.IsNullOrEmpty(Convert.ToString(wingDetail.Wing_DetailsId)) || wingDetail.Wing_DetailsId == 0)
                {
                    strCommand = "Insert into Wing_Details (Wing_MasterId,FlatNo,Wing_Name,Land,Carpet,WB,Amount,Total,EAST,WEST,NORTH,SOUTH,FlorName) VALUES(@Wing_MasterId,@FlatNo,@Wing_Name,@Land,@Carpet,@WB,@Amount,@Total,@East,@West,@North,@South,@FlorName); SELECT last_insert_rowid() FROM Wing_Details;";
                }
                else
                {
                    isEdit = true;
                    strCommand = "Update Wing_Details set Wing_MasterId=@Wing_MasterId,FlatNo=@FlatNo,Wing_Name=@Wing_Name,Land=@Land,Carpet=@Carpet,WB=@WB,Amount=@Amount,Total=@Total,EAST=@East,WEST=@West,NORTH=@North,SOUTH=@South,FlorName=@FlorName WHERE Wing_DetailsId=@Wing_DetailsId; SELECT @Wing_DetailsId;";
                }
                cmd.CommandText = strCommand;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Wing_MasterId", wingMasterId);
                cmd.Parameters.AddWithValue("@FlatNo", wingDetail.FlatNo);
                cmd.Parameters.AddWithValue("@Wing_Name", wingDetail.Wing_Name);

                cmd.Parameters.AddWithValue("@Land", wingDetail.Land);
                cmd.Parameters.AddWithValue("@Carpet", wingDetail.Carpet);
                cmd.Parameters.AddWithValue("@WB", wingDetail.WB);
                cmd.Parameters.AddWithValue("@Amount", wingDetail.Amount);
                cmd.Parameters.AddWithValue("@Total", Total);
                cmd.Parameters.AddWithValue("@East", wingDetail.EAST);
                cmd.Parameters.AddWithValue("@West", wingDetail.WEST);
                cmd.Parameters.AddWithValue("@North", wingDetail.NORTH);
                cmd.Parameters.AddWithValue("@South", wingDetail.SOUTH);
                cmd.Parameters.AddWithValue("@FlorName", wingDetail.FlorName);

                if (isEdit)
                {
                    cmd.Parameters.AddWithValue("@Wing_DetailsId", wingDetail.Wing_DetailsId);
                }
                var Valeu = await DaDatabaseConnection.ExecSacaler(cmd);
                wingDetail.Wing_DetailsId = Convert.ToInt32(Valeu);
                return wingDetail.Wing_DetailsId;
            }
            catch (Exception ex)
            {
                ReceiptLog.clsLog.InstanceCreation().InsertLog(ex.Message, ReceiptLog.clsLog.logType.Error, "DaWingMaster.InsertUpdateWingDetails");
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }

        }
        private static async Task<List<int>> InsertUpdateWingDetails(List<EnWingDetails> wingDetails, int wingMasterId)
        {
            List<int> totalWingInsert = new List<int>();
            foreach (EnWingDetails wingDetail in wingDetails)
            {
                decimal Total = wingDetail.Land + wingDetail.Carpet + wingDetail.WB;
                SQLiteCommand cmd = new SQLiteCommand();
                try
                {
                    string strCommand = "";
                    bool isEdit = false;
                    if (string.IsNullOrEmpty(Convert.ToString(wingDetail.Wing_DetailsId)) || wingDetail.Wing_DetailsId == 0)
                    {
                        strCommand = "Insert into Wing_Details (Wing_MasterId,FlatNo,Wing_Name,Land,Carpet,WB,Amount,Total,EAST,WEST,NORTH,SOUTH,FlorName) VALUES(@Wing_MasterId,@FlatNo,@Wing_Name,@Land,@Carpet,@WB,@Amount,@Total,@East,@West,@North,@South,@FlorName); SELECT last_insert_rowid() FROM Wing_Details;";
                    }
                    else
                    {
                        isEdit = true;
                        strCommand = "Update Wing_Details set Wing_MasterId=@Wing_MasterId,FlatNo=@FlatNo,Wing_Name=@Wing_Name,Land=@Land,Carpet=@Carpet,WB=@WB,Amount=@Amount,Total=@Total,EAST=@East,WEST=@West,NORTH=@North,SOUTH=@South,FlorName=@FlorName WHERE Wing_DetailsId=@Wing_DetailsId; SELECT @Wing_DetailsId;";
                    }
                    cmd.CommandText = strCommand;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Wing_MasterId", wingMasterId);
                    cmd.Parameters.AddWithValue("@FlatNo", wingDetail.FlatNo);
                    cmd.Parameters.AddWithValue("@Wing_Name", wingDetail.Wing_Name);

                    cmd.Parameters.AddWithValue("@Land", wingDetail.Land);
                    cmd.Parameters.AddWithValue("@Carpet", wingDetail.Carpet);
                    cmd.Parameters.AddWithValue("@WB", wingDetail.WB);
                    cmd.Parameters.AddWithValue("@Amount", wingDetail.Amount);
                    cmd.Parameters.AddWithValue("@Total", Total);
                    cmd.Parameters.AddWithValue("@East", wingDetail.EAST);
                    cmd.Parameters.AddWithValue("@West", wingDetail.WEST);
                    cmd.Parameters.AddWithValue("@North", wingDetail.NORTH);
                    cmd.Parameters.AddWithValue("@South", wingDetail.SOUTH);
                    cmd.Parameters.AddWithValue("@FlorName", wingDetail.FlorName);

                    if (isEdit)
                    {
                        cmd.Parameters.AddWithValue("@Wing_DetailsId", wingDetail.Wing_DetailsId);
                    }
                    var Valeu = await DaDatabaseConnection.ExecSacaler(cmd);
                    wingDetail.Wing_DetailsId = Convert.ToInt32(Valeu);
                    totalWingInsert.Add(Convert.ToInt32(Valeu));
                }
                catch (Exception ex)
                {
                    ReceiptLog.clsLog.InstanceCreation().InsertLog(ex.Message, ReceiptLog.clsLog.logType.Error, "DaWingMaster.InsertUpdateWingDetails");
                    throw ex;
                }
                finally
                {
                    cmd.Dispose();
                }
            }
            return totalWingInsert;
        }
    }
}
