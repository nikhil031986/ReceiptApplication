using ReceiptDataAcess;
using ReceiptEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReceiptBAccess
{
    public static class BAReceiptDetails
    {
        public static async Task<List<EnReceiptDetails>> GetReceiptDetails(int ReceiptId)
            => await DAReciptDetails.GetReceiptDetails(ReceiptId);

        public static async Task<int> InsertUpdateReceiptDetails(EnReceiptDetails enReceiptDetails)
            => await DAReciptDetails.InsertUpdateReceiptDetails(enReceiptDetails);

        public static async Task<string> getReceiptNo()
            => await DAReciptDetails.getReceiptNo();

         public static async Task<List<EnReceiptDetails>> GetReceiptDetailsFromDateToDate(int fromDate, int Todate)
            => await DAReciptDetails.GetReceiptDetailsFromDateToDate(fromDate,Todate);
        public static async Task<List<EnReceiptDetails>> GetReceiptByCustomer(int CustomerID)
            => await DAReciptDetails.GetReceiptByCustomer(CustomerID);
    }
}
