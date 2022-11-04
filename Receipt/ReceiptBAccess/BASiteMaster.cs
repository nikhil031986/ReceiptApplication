using ReceiptDataAcess;
using ReceiptEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptBAccess
{
    public static class BASiteMaster
    {
        public static async Task<List<EnSiteMaster>> GetSiteMaster(int SiteMasterId)
        {
            return await DASiteMaster.GetSiteMaster(SiteMasterId);
        }

        public static async Task<int> InsertUpdateSiteMaster(EnSiteMaster enSiteMaster)
        {
            return await DASiteMaster.InsertUpdateSiteMaster(enSiteMaster);
        }
    }
}
