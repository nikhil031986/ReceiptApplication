using Microsoft.SqlServer.Server;

namespace ReceiptEntity
{
    public class EnCustomer
    {
        public int Customer_Id { get; set; }
        public int Wing_Master_Id { get; set; }
        public int Wing_Details_Id { get; set; }
        public string Customer_Name { get; set; }
        public string Address { get; set; }
        public string Con_Details { get; set; }
        public string Email_Id { get; set; }
        public string Customer_Wing_Name { get; set; }
        public string Wing_Name { get; set; }
        public string FlatNo { get; set; }
        public EnCustomer()
        {

        }
        public EnCustomer(int customerId,int wing_Master_Id,int wing_Details_Id,string wing_Name,string flatNo, string custoimer_Name,string address,string con_Details,string emailId,string customer_Wing_Name)
        {
            this.Customer_Id = customerId;
            this.Wing_Master_Id = wing_Master_Id;
            this.Wing_Details_Id = wing_Details_Id;
            this.Wing_Name = wing_Name;
            this.FlatNo = flatNo;
            this.Customer_Name = custoimer_Name;
            this.Address = address;
            this.Con_Details = con_Details;
            this.Email_Id = emailId;
            this.Customer_Wing_Name = customer_Wing_Name;
        }

    }
}
