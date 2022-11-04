using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptEntity
{
    public class EnSiteMaster
    {
        public int Site_Master_Id { get; set; }
        public string Site_Name { get; set; }
        public string DB_Name { get; set; }
        public string Site_Address { get; set; }
        public string Created_Date { get; set; }
        public EnSiteMaster()
        {

        }
        public EnSiteMaster(int site_Master_Id, string site_Name, string dB_Name, string site_Address, string created_Date)
        {
            Site_Master_Id = site_Master_Id;
            Site_Name = site_Name;
            DB_Name = dB_Name;
            Site_Address = site_Address;
            Created_Date = created_Date;
        }
    }
}
