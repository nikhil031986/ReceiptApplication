using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptEntity
{
    public class EnReceiptDetails
    {
        public int Receipt_Id { get; set; }
        public string Receipt_No { get; set; }
        public string Receipt_Date { get; set; }
        public int Customer_Id { get; set; }
        public string Flate_ShopNo { get; set; }
        public string Cheq_Rtgs_Neft_ImpsNo { get; set; }
        public int Year_Id { get; set; }
        public string Bank_Name { get; set; }
        public string Branch_Name { get; set; }
        public string ReceivedAs { get; set; }
        public decimal Amount { get; set; }
        public string Amount_Word { get; set; }
        public string Customer_Name { get; set; }
        public string PaymentDate { get; set; }
        public int ReceiptDateNo { get; set; }
        public int IsCancel { get; set; }

        private int _isPrinter = 0;
        public int IsPrint { get { return _isPrinter; } set { _isPrinter = value; } }
        public EnReceiptDetails()
        {       

        }
        public EnReceiptDetails(int receipt_Id, string receipt_No, string receipt_Date, int customer_Id, string flate_ShopNo, 
            string cheq_Rtgs_Neft_ImpsNo, int year_Id, string bank_Name, string branch_Name, string receivedAs,
            decimal amount, string amount_Word, string customer_Name, string paymentDate, int receiptDateNo, int isCancel, int isPrint)
        {
            Receipt_Id = receipt_Id;
            Receipt_No = receipt_No;
            Receipt_Date = receipt_Date;
            Customer_Id = customer_Id;
            Flate_ShopNo = flate_ShopNo;
            Cheq_Rtgs_Neft_ImpsNo = cheq_Rtgs_Neft_ImpsNo;
            Year_Id = year_Id;
            Bank_Name = bank_Name;
            Branch_Name = branch_Name;
            ReceivedAs = receivedAs;
            Amount = amount;
            Amount_Word = amount_Word;
            Customer_Name = customer_Name;
            PaymentDate = paymentDate;
            ReceiptDateNo = receiptDateNo;
            IsCancel = isCancel;
            IsPrint = isPrint;
        }
    }
}
