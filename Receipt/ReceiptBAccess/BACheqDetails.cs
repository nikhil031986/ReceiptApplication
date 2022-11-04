using ReceiptDataAcess;
using ReceiptEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptBAccess
{
    public static class BACheqDetails
    {
        public static async Task<List<EnCheqDetails>> GetCheqDetails(int CheqDetailsId)
            => await DACheqDetails.GetCheqDetails(CheqDetailsId);
        public static async Task<List<string>> GetCustomerName()
            => await DACheqDetails.GetCustomerName();
        public static async Task<int> InsertUpdateCheqDetqails(EnCheqDetails enCheqDetails)
            => await DACheqDetails.InsertUpdateCheqDetqails(enCheqDetails);
    }
}
