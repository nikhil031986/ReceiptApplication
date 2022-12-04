using ReceiptDataAcess;
using ReceiptEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReceiptBAccess
{
    public static class BACustomerMaster
    {
        public static async Task<int> InsertUpdateCustomer(EnCustomer enCustomer)
       => await DACustomerMaster.InsertUpdateCustomer(enCustomer);

        public static async Task<List<EnCustomer>> GetCustomer(int CustomerId = 0)
        => await DACustomerMaster.GetCustomer(CustomerId);

        public static async Task<EnCommonRet> GetCustomerDT(int customerId, bool isNext)
            => await DACustomerMaster.GetCustomerDT(customerId, isNext);
    }
}
