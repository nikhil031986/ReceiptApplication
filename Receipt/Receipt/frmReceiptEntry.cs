using ReceiptBAccess;
using ReceiptEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Receipt
{
    public partial class frmReceiptEntry : Form
    {
        private string[] printDocumentControls;
        private EnReceiptDetails receiptDetails;
        private PrintDocument pdocument;
        public int Receipt_ID { get; set; }

        private Dictionary<string, string> replaceStr;
        public frmReceiptEntry()
        {
            InitializeComponent();
            Task.Run(() => FillCustomerData()).Wait();
            receiptDetails = new EnReceiptDetails();
            txtReceiptNo.Text = BAReceiptDetails.getReceiptNo().Result;
            cmbReceivedAs.SelectedIndex = 0;
            dtpReceiptDate.Focus();
        }
        public frmReceiptEntry(int receiptId)
        {
            InitializeComponent();
            Task.Run(() => FillCustomerData()).Wait();
            receiptDetails = new EnReceiptDetails();
            Task.Run(() => GetReceiptDetails(receiptId)).Wait();
            cmbReceivedAs.SelectedIndex = 0;
            dtpReceiptDate.Focus();
        }
        private async Task GetReceiptDetails(int receiptId)
        {
            var receiptDetails = await BAReceiptDetails.GetReceiptDetails(receiptId);

            txtReceiptNo.Tag = receiptDetails.FirstOrDefault().Receipt_Id;
            txtReceiptNo.Text = receiptDetails.FirstOrDefault().Receipt_No;
            cmbCustomerName.SelectedValue = receiptDetails.FirstOrDefault().Customer_Id;
            cmbReceivedAs.Text = receiptDetails.FirstOrDefault().ReceivedAs;
            dtpReceiptDate.Value = DateTime.ParseExact(receiptDetails.FirstOrDefault().Receipt_Date, "dd/MM/yyyy", CultureInfo.InvariantCulture); ;
            txtFlatShopNo.Text = receiptDetails.FirstOrDefault().Flate_ShopNo;
            txtImpsCheqDetails.Text = receiptDetails.FirstOrDefault().Cheq_Rtgs_Neft_ImpsNo;
            txtAmount.Text = receiptDetails.FirstOrDefault().Amount.ToString();
            txtBankName.Text = receiptDetails.FirstOrDefault().Bank_Name;
            txtBranchName.Text = receiptDetails.FirstOrDefault().Branch_Name;
            txtAmountInWord.Text = receiptDetails.FirstOrDefault().Amount_Word;
            dtpPaymentDate.Value = DateTime.ParseExact(receiptDetails.FirstOrDefault().PaymentDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        private async Task FillCustomerData()
        {
            var customer = await BACustomerMaster.GetCustomer();
            cmbCustomerName.Items.Clear();
            cmbCustomerName.DataSource = null;
            cmbCustomerName.DisplayMember = "Customer_Name";
            cmbCustomerName.ValueMember = "Customer_Id";
            cmbCustomerName.DataSource = customer;
            cmbCustomerName.SelectedIndex = -1;
        }

        private async Task FillReplaceStrList()
        {
            await Task.Run(() =>
            {
                replaceStr = new Dictionary<string, string>();
                replaceStr.Add("_DBReceiptNO", receiptDetails.Receipt_No.ToUpper());
                replaceStr.Add("_DBCustomerName", receiptDetails.Customer_Name.ToUpper());
                replaceStr.Add("_DBFlatShopNo", receiptDetails.Flate_ShopNo.ToUpper());
                replaceStr.Add("_DBAmountInWord", receiptDetails.Amount_Word.ToUpper());
                replaceStr.Add("_DBCheqRtgsNeftImps", receiptDetails.Cheq_Rtgs_Neft_ImpsNo);
                replaceStr.Add("_DBDate", receiptDetails.PaymentDate);
                replaceStr.Add("_DBBankName", receiptDetails.Bank_Name.ToUpper());
                replaceStr.Add("_DBBranch", receiptDetails.Branch_Name.ToUpper());
                replaceStr.Add("_DBReceivedAs", receiptDetails.ReceivedAs);
                replaceStr.Add("_DBAmount", receiptDetails.Amount.ToString() + "/-");
                replaceStr.Add("_DBReceiptDate", receiptDetails.Receipt_Date);
            });
        }
        private void Pdocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            int floatx = 55;
            int floaty = 10;
            e.Graphics.DrawString(string.Empty, new Font("Times New Roman", 10, FontStyle.Bold),
      Brushes.Black, floatx, floaty);
            floaty = floaty + 70;
            foreach (string strLine in printDocumentControls)
            {
                if(strLine.ToUpper().Contains("NAME"))
                {
                    if(strLine.Length<70)
                    {
                       e.Graphics.DrawString(strLine, new Font("Times New Roman", 10, FontStyle.Bold),
                       Brushes.Black, floatx, floaty);
                    }
                    else
                    {
                        string printData = strLine;
                        //Line one
                        string strNewPrint = printData.Substring(0, 70);
                        e.Graphics.DrawString(strNewPrint, new Font("Times New Roman", 10, FontStyle.Bold),
                       Brushes.Black, floatx, floaty);
                        floaty = floaty + 20;
                        // Line two
                        strNewPrint = "\t\t\t  "+printData.Replace(strNewPrint,"");
                        e.Graphics.DrawString(strNewPrint, new Font("Times New Roman", 10, FontStyle.Bold),
                       Brushes.Black, floatx, floaty);
                    }
                }
                else
                {
                            e.Graphics.DrawString(strLine, new Font("Times New Roman", 10, FontStyle.Bold),
                   Brushes.Black, floatx, floaty);
                }
                floaty = floaty + 20;
            }
        }

        private void FillDataInToEntity()
        {
            receiptDetails = new EnReceiptDetails();
            if (!string.IsNullOrWhiteSpace(Convert.ToString(txtReceiptNo.Tag)))
            {
                receiptDetails.Receipt_Id = Convert.ToInt32(txtReceiptNo.Tag);
            }

            receiptDetails.Receipt_No = txtReceiptNo.Text.Trim();
            receiptDetails.Receipt_Date = dtpReceiptDate.Value.ToString("dd/MM/yyyy");
            receiptDetails.Bank_Name = txtBankName.Text;
            receiptDetails.Branch_Name = txtBranchName.Text;
            receiptDetails.Customer_Name = cmbCustomerName.Text;
            receiptDetails.Customer_Id = Convert.ToInt32(cmbCustomerName.SelectedValue);
            receiptDetails.Year_Id = 1;
            receiptDetails.Amount = Convert.ToDecimal(txtAmount.Text);
            receiptDetails.Amount_Word = txtAmountInWord.Text;
            receiptDetails.Flate_ShopNo = txtFlatShopNo.Text;
            receiptDetails.Cheq_Rtgs_Neft_ImpsNo = txtImpsCheqDetails.Text;
            receiptDetails.ReceivedAs = cmbReceivedAs.Text;
            receiptDetails.PaymentDate = dtpPaymentDate.Value.ToString("dd/MM/yyyy");
            receiptDetails.ReceiptDateNo = Convert.ToInt32(dtpPaymentDate.Value.ToString("yyyyMMdd"));
        }
        private void PrintDocumentView()
        {
            var receiptFilePath = ClsUtil.getCurrentPath()+ "ReceiptTemplate.txt";
            printDocumentControls = System.IO.File.ReadAllLines(receiptFilePath);
            foreach (var repl in replaceStr)
            {
                for (int lineNo = 0; lineNo <= printDocumentControls.Length; lineNo++)
                {
                    if (printDocumentControls[lineNo].ToLower().Contains(repl.Key.ToLower()))
                    {
                        printDocumentControls[lineNo] = printDocumentControls[lineNo].Replace(repl.Key, repl.Value);
                        break;
                    }
                }
            }

            pdocument = new PrintDocument();
            pdocument.PrinterSettings.PrinterName = "Microsoft XPS Document Writer";
            pdocument.PrinterSettings.PrintToFile = false;
            pdocument.DefaultPageSettings.Landscape = true;
            pdocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA4", 750, 1024);
            pdocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
            pdocument.PrintPage += Pdocument_PrintPage;
            prntprvControl.Document = pdocument;

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {

            FillDataInToEntity();

            Receipt_ID = await BAReceiptDetails.InsertUpdateReceiptDetails(receiptDetails);

            await Task.Run(() => FillReplaceStrList());

            PrintDocumentView();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedCustomer = cmbCustomerName.SelectedItem;
            if (selectedCustomer != null)
            {
                txtFlatShopNo.Text = ((EnCustomer)selectedCustomer).Wing_Name + "-" + ((EnCustomer)selectedCustomer).FlatNo;
            }
            else
            {
                txtFlatShopNo.Text = string.Empty;
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                txtAmountInWord.Text = ClsUtil.ConvertAmount(double.Parse(txtAmount.Text));
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            pdocument.DocumentName = "fileName";
            printDlg.Document = pdocument;
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;
            //Call ShowDialog
            if (printDlg.ShowDialog() == DialogResult.OK)
                pdocument.Print();
        }

        private async void btnPrintPreviw_Click(object sender, EventArgs e)
        {

            FillDataInToEntity();

            await Task.Run(() => FillReplaceStrList());

            PrintDocumentView();
        }

        private void txtFlatShopNo_Validated(object sender, EventArgs e)
        {
            try
            {
                if(txtFlatShopNo.Text.ToString().ToUpper().Contains("-"))
                {
                    int selectedindex = 0;
                    string[] strWingFlat= txtFlatShopNo.Text.Split('-');
                    if (strWingFlat.Length >= 1)
                    {
                        foreach (EnCustomer items in cmbCustomerName.Items)
                        {
                            if (items.Wing_Name.Trim().ToUpper() == strWingFlat[0].Trim().ToUpper() && items.FlatNo.ToUpper() == strWingFlat[1].ToUpper())
                            {
                                cmbCustomerName.SelectedIndex = selectedindex;
                                break;
                            }
                            selectedindex = selectedindex + 1;
                        }
                    }
                    else
                    {
                        cmbCustomerName.SelectedIndex = -1;
                    }
                }
                else
                {
                    cmbCustomerName.SelectedIndex = -1;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
