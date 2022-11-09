using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptEntity
{
    public class EnWingMaster
    {
        public int Wing_Master_Id { get; set; }
        public string Wing_Name { get; set; }
        public int Floar_Count { get; set; }
        public int Hous_Count { get; set; }
        public int Start_Number { get; set; }
        public int End_Number { get; set; }


 
        public List<EnWingDetails> enWingDetails { get; set; }
        public EnWingMaster()
        { }
        public EnWingMaster(int wing_Master_Id, string wing_Name, int floar_Count, int hous_Count, int start_Number, int end_Number)
        {
            Wing_Master_Id = wing_Master_Id;
            Wing_Name = wing_Name;
            Floar_Count = floar_Count;
            Hous_Count = hous_Count;
            Start_Number = start_Number;
            End_Number = end_Number;
        }
        public EnWingMaster(int wing_Master_Id, string wing_Name, int floar_Count, int hous_Count, int start_Number, int end_Number, List<EnWingDetails> envingDetail)
        {
            Wing_Master_Id = wing_Master_Id;
            Wing_Name = wing_Name;
            Floar_Count = floar_Count;
            Hous_Count = hous_Count;
            Start_Number = start_Number;
            End_Number = end_Number;
            enWingDetails = envingDetail;
        }
    }
}
