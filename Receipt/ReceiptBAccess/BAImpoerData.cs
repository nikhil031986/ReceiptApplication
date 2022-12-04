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
        public static async Task<DataTable> ImportData(DataTable dtForImport)
            => await DAImportData.ImportData(dtForImport);
    }
}
