using ReceiptDataAcess;
using ReceiptEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReceiptBAccess
{
    public static class BACustomerMaster
    {
        public static async Task<int> InsertUpdateCustomer(EnCustomer enCustomer,int IsBanakhat)
       => await DACustomerMaster.InsertUpdateCustomer(enCustomer, IsBanakhat);

        public static async Task<List<EnCustomer>> GetCustomer(int CustomerId = 0)
        => await DACustomerMaster.GetCustomer(CustomerId);

        public static async Task<List<string>> GetOcupations()
            => await DACustomerMaster.GetOcupations();
        public static async Task<EnCommonRet> GetCustomerDT(int customerId, bool isNext)
            => await DACustomerMaster.GetCustomerDT(customerId, isNext);

        public static async Task<int> CheckAnyCustomerExists(int wingMasterId, int WingDetailsId)
            => await DACustomerMaster.CheckAnyCustomerExists(wingMasterId, WingDetailsId);
        public static async Task<string> GetPageCount(int rowCount)
            => await DACustomerMaster.GetPageCount(rowCount);
        public static async Task<List<EnCustomer>> GetCustomerPageing(int incrimentSize, int rtRows)
            => await DACustomerMaster.GetCustomerPageing(incrimentSize, rtRows);

        public static async Task<List<EnCustomer>> GetCustomerByCond(string whereCond)
            => await DACustomerMaster.GetCustomerByCond(whereCond);
    }
}
