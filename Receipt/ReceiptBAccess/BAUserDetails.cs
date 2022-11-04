using ReceiptDataAcess;
using ReceiptEntity;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ReceiptBAccess
{
    public static class BAUserDetails
    {
        public async static Task<int> InsertUpdateUser(EnUserDetails userDetails)
        {
            return await ReceiptDataAcess.DAUserDetails.InsertUpdateUserDetails(userDetails);
        }
        public static async Task<EnUserDetails> GetUserDetails(int UserId)
        {
            return await ReceiptDataAcess.DAUserDetails.GetUserDetails(UserId);
        }
        public static async Task<List<EnUserDetails>> GetAllUser()
        {
            return await ReceiptDataAcess.DAUserDetails.GetAllUser();
        }
        public static string HasPassword(string password)
        {
            return ReceiptDataAcess.SecretHasher.Hash(password);
        }

        public static async Task<EnUserDetails> GetUserDetails(string UserName, string password)
            => await ReceiptDataAcess.DAUserDetails.GetUserDetails(UserName, password);

        public static void SetDataBaseString(string DBName)
            => DAUserDetails.SetDataBaseString(DBName);
    }
}
