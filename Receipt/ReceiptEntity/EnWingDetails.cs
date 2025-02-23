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

        public decimal Land { get; set; }
        public decimal Carpet { get; set; }
        public decimal WB { get; set; }
        public decimal Amount { get; set; }
        public decimal Total { get; set; }


        public string EAST { get; set; }
        public string WEST { get; set; }
        public string NORTH { get; set; }
        public string SOUTH { get; set; }
        public string FlorName { get; set;}
        public decimal Open_Terrace { get; set; }
        public EnWingDetails()
        {
        }
        public EnWingDetails(int wing_DetailsId, int wing_Master_Id, string flatNo, string wing_Name, decimal land, decimal carpet, decimal wb, decimal amount, 
            decimal total, string east, string west, string north, string south, string florName, decimal open_Terrace)
        {
            Wing_DetailsId = wing_DetailsId;
            Wing_Master_Id = wing_Master_Id;
            FlatNo = flatNo;
            Wing_Name = wing_Name;

            Land = land;
            Carpet = carpet;
            WB = wb;
            Amount = amount;
            Total = total;

            EAST = east;
            WEST = west;
            NORTH = north;
            SOUTH = south;
            FlorName = florName;
            Open_Terrace = open_Terrace;
        }
    }
}
