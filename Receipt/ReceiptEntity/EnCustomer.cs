using Microsoft.SqlServer.Server;
using System;

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
        public string Pan { get; set; }
        public string Aadhar { get; set; }
        public string Customer1 { get; set; }
        public string Pan1 { get; set; }
        public string Aadhar1 { get; set; }
        public string Customer2 { get; set; }
        public string Pan2 { get; set; }
        public string Aadhar2 { get; set; }
        public string Customer3 { get; set; }
        public string Pan3 { get; set; }
        public string Aadhar3 { get; set; }
        public string BanakhatNo { get; set; }
        public string BanakhatDate { get; set; }
        public string Ocupation { get; set; }
        public string Ocupation1 { get; set; }
        public string Ocupation2 { get; set; }
        public string Ocupation3 { get; set; }
        public string Financial_Name { get; set; }
        public string Dastavg_No { get;set; }
        public string Dastavg_Date { get; set; }
        public decimal Dastavej_Amount { get; set; }
        public EnCustomer()
        {

        }
        public EnCustomer(int customerId, int wing_Master_Id, int wing_Details_Id, string wing_Name, string flatNo, string custoimer_Name, 
            string address, string con_Details, string emailId, string customer_Wing_Name, string pan, string aadhar, string customer1, string pan1,
            string aadhar1, string customer2, string pan2, string aadhar2, string customer3, string pan3, string aadhar3,
            string banakhatNo, string bankhatDate, string ocupation, string ocupation1, string ocupation2, string ocupation3, 
            string financial_Name, string dastavg_No, string dastavg_Date , decimal dastavej_amount)
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
            this.Pan = pan;
            this.Aadhar = aadhar;
            this.Customer1 = customer1;
            this.Pan1 = pan1;
            this.Aadhar1 = aadhar1;
            this.Customer2 = customer2;
            this.Pan2 = pan2;
            this.Aadhar2 = aadhar2;
            this.Customer3 = customer3;
            this.Pan3 = pan3;
            this.Aadhar3 = aadhar3;
            this.BanakhatNo = banakhatNo;
            this.BanakhatDate = bankhatDate;
            this.Ocupation = ocupation;
            this.Ocupation1 = ocupation1;
            this.Ocupation2 = ocupation2;
            this.Ocupation3 = ocupation3;
            this.Financial_Name = financial_Name;
            this.Dastavg_No = dastavg_No;
            this.Dastavg_Date = dastavg_Date;
            this.Dastavej_Amount = dastavej_amount;
        }

    }
}
