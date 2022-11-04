using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptEntity
{
    public  class EnCheqDetails
    {
        public int Cheq_Details_Id { get; set; }
        public string Customer_Name { get; set; }
        public string Cheq_Date { get; set; }
        public decimal Amount { get; set; }
        public string Amount_InWord { get; set; }
        public string Bank_Name { get; set; }
        public string Cheq_No { get; set; }

        public EnCheqDetails()
        {

        }

        public EnCheqDetails(int cheq_Details_Id, string customer_Name, string cheq_Date, decimal amount, string amount_InWord, string bank_Name, string cheq_No)
        {
            Cheq_Details_Id = cheq_Details_Id;
            Customer_Name = customer_Name;
            Cheq_Date = cheq_Date;
            Amount = amount;
            Amount_InWord = amount_InWord;
            Bank_Name = bank_Name;
            Cheq_No = cheq_No;
        }
    }
}
