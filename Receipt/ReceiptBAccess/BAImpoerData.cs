using ReceiptDataAcess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptBAccess
{
    public static class BAImpoerData
    {
        public static async Task<DataTable> ImportReceiptData(DataTable dtForImport)
            => await DAImportData.ImportReceiptData(dtForImport);

        public static async Task ImportWingDetails(DataTable dtForImport)
            => await DAImportData.ImportWingDetails(dtForImport);
        public static async Task<List<string>> GetTableName()
            => await DAImportData.GetTableName();
    }
}
