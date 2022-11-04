using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using ReceiptEntity;
namespace ReceiptDataAcess
{
    public static class DAUserDetails
    {
        public static async Task<List<EnUserDetails>> GetAllUser()
        {
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                string strCommand = "SELECT * FROM User_Details";
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strCommand;
                cmd.Parameters.Clear();
                return await DaDatabaseConnection.GetData(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<EnUserDetails> GetUserDetails(int UserId)
        {
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                List<EnUserDetails> userDetails = new List<EnUserDetails>();
                string strCommand = "SELECT * FROM User_Details WHERE  Use_DetailId=@Use_DetailId";
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strCommand;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Use_DetailId", UserId);
                userDetails = await DaDatabaseConnection.GetData(cmd);
                return userDetails.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void SetDataBaseString(string DBName)
        {
            DaDatabaseConnection.SelectedSiteDataBase = @"Data Source = "+DBName+".db";
        }
        public static async Task<EnUserDetails> GetUserDetails(string UserName,string password)
        {
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                List<EnUserDetails> userDetails = new List<EnUserDetails>();
                string strCommand = "SELECT * FROM User_Details WHERE  User_Name=@UserName AND Password=@Password;";
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strCommand;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Password", password);
                userDetails = await DaDatabaseConnection.GetData(cmd);
                return userDetails.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<int> InsertUpdateUserDetails(EnUserDetails userDetails)
        {
            int intRetValeu = 0;
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                string strCommand = "";
                bool isEdit = false;
                if (string.IsNullOrEmpty(Convert.ToString(userDetails.UserId)) || userDetails.UserId == 0)
                {
                    strCommand = "Insert into User_Details (User_Name,Password,IsAdmin,ISEdit,IsDelete,IsView) VALUES(@User_Name,@Password,@IsAdmin,@ISEdit,@IsDelete,@IsView); SELECT last_insert_rowid() FROM User_Details;";
                }
                else
                {
                    isEdit = true;
                    strCommand = "Update User_Details set User_Name=@User_Name,IsAdmin=@IsAdmin,ISEdit=@ISEdit,IsDelete=@IsDelete,IsView=@IsView WHERE Use_DetailId=@Use_DetailId; SELECT @Use_DetailId;";
                }
                cmd.CommandText = strCommand;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@User_Name", userDetails.UserName);
                if (!isEdit) cmd.Parameters.AddWithValue("@Password", userDetails.Password);
                cmd.Parameters.AddWithValue("@IsAdmin", userDetails.IsAdmin);
                cmd.Parameters.AddWithValue("@ISEdit", userDetails.IsEdit);
                cmd.Parameters.AddWithValue("@IsDelete", userDetails.IsDelete);
                cmd.Parameters.AddWithValue("@IsView", 0);
                if (isEdit) cmd.Parameters.AddWithValue("@Use_DetailId", userDetails.UserId);
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
