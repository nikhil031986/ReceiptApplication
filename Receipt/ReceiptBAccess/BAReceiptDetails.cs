using ReceiptDataAcess;
using ReceiptEntity;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ReceiptBAccess
{
    public static class BAReceiptDetails
    {
        public static async Task<List<string>> GetBranchName()
            => await DAReciptDetails.GetBranchName();
        public static async Task<List<string>> GetBankName()
            => await DAReciptDetails.GetBankName();
        public static async Task<List<EnReceiptDetails>> GetReceiptDetails(int ReceiptId)
            => await DAReciptDetails.GetReceiptDetails(ReceiptId);

        public static async Task<int> InsertUpdateReceiptDetails(EnReceiptDetails enReceiptDetails)
            => await DAReciptDetails.InsertUpdateReceiptDetails(enReceiptDetails);
        public static async Task<int> UpdateReceiptPrint(int receiptId)
            => await DAReciptDetails.UpdateReceiptPrint(receiptId);

        public static async Task<string> getReceiptNo()
            => await DAReciptDetails.getReceiptNo();

         public static async Task<List<EnReceiptDetails>> GetReceiptDetailsFromDateToDate(int fromDate, int Todate)
            => await DAReciptDetails.GetReceiptDetailsFromDateToDate(fromDate,Todate);
        public static async Task<List<EnReceiptDetails>> GetReceiptByCustomer(int CustomerID)
            => await DAReciptDetails.GetReceiptByCustomer(CustomerID);

         public async static Task<DataTable> GetBanakhatDetails()
            => await DAReciptDetails.GetBanakhatDetails();
        public async static Task<int> UpdatePrintedBanakhat(string customerIds)
            => await DAReciptDetails.UpdatePrintedBanakhat(customerIds);
        public static async Task<List<EnReceiptDetails>> GetReciptPageing(int incrimentSize,int rtRows)
            => await DAReciptDetails.GetReciptPageing(incrimentSize, rtRows);
        public static async Task<string> GetPageCount(int rowCount)
            => await DAReciptDetails.GetPageCount(rowCount);
        public static async Task<List<EnReceiptDetails>> GetReceiptByCond(string whereCond)
            => await DAReciptDetails.GetReceiptByCond(whereCond);

        public static async Task ImportReceiptFromExcel(DataTable dtImport)
            => await DAReciptDetails.ImportReceiptFromExcel(dtImport);
    }
}
