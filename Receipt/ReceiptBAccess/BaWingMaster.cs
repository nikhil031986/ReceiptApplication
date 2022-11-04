using ReceiptEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptBAccess
{
    public static class BaWingMaster
    {
        public static async Task<int> InsertWingMaster(EnWingMaster wingMaster, List<EnWingDetails> wingDetails, int UserId)
        =>await ReceiptDataAcess.DaWingMaster.InsertWingMaster(wingMaster, wingDetails, UserId);

        public static async Task<EnWingMaster> getWingMaster(int wingMasterId)
        =>await ReceiptDataAcess.DaWingMaster.getWingMaster(wingMasterId);

        public static async Task<List<EnWingMaster>> GetWingMaster(int WingMasterId = 0)
        => await ReceiptDataAcess.DaWingMaster.GetWingMaster(WingMasterId);

        public static async Task<List<EnWingDetails>> GetWingDetails(int wingMasterId = 0)
       => await ReceiptDataAcess.DaWingMaster.GetWingDetails(wingMasterId);
    }
}
