using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptEntity
{
    public class EnWingDetails
    {
        public int Wing_DetailsId { get; set; }
        public int Wing_Master_Id { get; set; }
        public string FlatNo { get; set; }
        public string Wing_Name { get; set; }
        public EnWingDetails()
        {
        }
        public EnWingDetails(int wing_DetailsId, int wing_Master_Id, string flatNo, string wing_Name)
        {
            Wing_DetailsId = wing_DetailsId;
            Wing_Master_Id = wing_Master_Id;
            FlatNo = flatNo;
            Wing_Name=wing_Name;
        }
    }
}
