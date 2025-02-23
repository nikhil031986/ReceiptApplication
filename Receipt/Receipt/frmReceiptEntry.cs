using ReceiptBAccess;
using ReceiptEntity;
using ReceiptLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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
            try
            {
                InitializeComponent();
                Task.Run(() => FillCustomerData()).Wait();
                receiptDetails = new EnReceiptDetails();
                txtReceiptNo.Text = BAReceiptDetails.getReceiptNo().Result;
                cmbReceivedAs.SelectedIndex = 0;
                dtpReceiptDate.Focus();
                FillBankNameAndBranchName();
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
        public async Task PrintDocument()
        {
            try
            {
                clsWaitForm.ShowWaitForm();

                //await Task.Run(()=>GetReceiptDetails(this.Receipt_ID));

                await FillDataInToEntity();

                await FillReplaceStrList();

                PrintDocumentView();

                // Get the default printer name
                PrinterSettings settings = new PrinterSettings();
                string defaultPrinterName = settings.PrinterName;

                System.Threading.Thread.Sleep(1000);
                PrintDialog printDlg = new PrintDialog();
                //pdocument.DocumentName = "fileName";
                printDlg.Document = pdocument;
                printDlg.AllowSelection = true;
                printDlg.AllowSomePages = true;
                printDlg.PrinterSettings.Copies = 2;
                printDlg.PrinterSettings.PrinterName = defaultPrinterName;
                //Call ShowDialog
                clsWaitForm.CloseWaitForm();
                if (printDlg.ShowDialog() == DialogResult.OK)
                {
                    pdocument.Print();
                    await BAReceiptDetails.UpdateReceiptPrint(Receipt_ID);
                }
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
            this.Close();
        }
        public frmReceiptEntry(int receiptId, bool IsPrint = false)
        {
            try
            {
                InitializeComponent();
                Task.Run(() => FillCustomerData()).Wait();
                receiptDetails = new EnReceiptDetails();
                Receipt_ID = receiptId;
                FillBankNameAndBranchName();
                Task.Run(()=> GetReceiptDetails(receiptId)).Wait();
                cmbReceivedAs.SelectedIndex = 0;
                dtpReceiptDate.Focus();


            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
        private async void FillBankNameAndBranchName()
        {
            var BankName = await BAReceiptDetails.GetBankName();
            cboBankName.Items.Clear();
            cboBankName.Items.AddRange(BankName.ToArray());
            var BranchName = await BAReceiptDetails.GetBranchName();
            cboBranchName.Items.Clear();
            cboBranchName.Items.AddRange(BranchName.ToArray());
        }
        private async void GetReceiptDetails(int receiptId)
        {
            try
            {

                var _receiptDetails = await BAReceiptDetails.GetReceiptDetails(receiptId);
                receiptDetails = _receiptDetails.FirstOrDefault();
                txtReceiptNo.Tag = receiptDetails.Receipt_Id;
                txtReceiptNo.Text = receiptDetails.Receipt_No;
                cmbCustomerName.SelectedValue = receiptDetails.Customer_Id;
                cmbReceivedAs.Text = receiptDetails.ReceivedAs;


                txtFlatShopNo.Text = receiptDetails.Flate_ShopNo;
                txtImpsCheqDetails.Text = receiptDetails.Cheq_Rtgs_Neft_ImpsNo;
                txtAmount.Text = receiptDetails.Amount.ToString();
                cboBankName.Text = receiptDetails.Bank_Name;
                cboBranchName.Text = receiptDetails.Branch_Name;
                txtAmountInWord.Text = receiptDetails.Amount_Word;

                ChkIsCancel.Checked = receiptDetails.IsCancel == 1 ? true : false;

                var strReceiptDate = receiptDetails.Receipt_Date;
                strReceiptDate = strReceiptDate.Replace(".", "/").Replace("-", "/");
                if (!string.IsNullOrWhiteSpace(strReceiptDate))
                {
                    string dateFormate = (strReceiptDate.Split('/')[2].Length < 3 ? DateTime.Now.Year.ToString().Substring(0, 2) + strReceiptDate.Split('/')[2] : strReceiptDate.Split('/')[2])
                                        + "/" + strReceiptDate.Split('/')[1] + "/" + strReceiptDate.Split('/')[0];
                    dtpReceiptDate.Value = Convert.ToDateTime(dateFormate);

                }
                var paymentDate = receiptDetails.PaymentDate;
                paymentDate = paymentDate.Replace(".", "/").Replace("-", "/");
                if (!string.IsNullOrWhiteSpace(paymentDate))
                {
                    string dateFormate = (paymentDate.Split('/')[2].Length < 3 ? DateTime.Now.Year.ToString().Substring(0, 2) + paymentDate.Split('/')[2] : paymentDate.Split('/')[2])
                                        + "/" + paymentDate.Split('/')[1] + "/" + paymentDate.Split('/')[0];
                    dtpPaymentDate.Value = Convert.ToDateTime(dateFormate);

                }

                //if (strReceiptDate.Length < 10)
                //{
                //    strReceiptDate = strReceiptDate.Remove(6, 2) + DateTime.Now.Year.ToString();
                //}
                //if (paymentDate.Length < 10)
                //{
                //    paymentDate = paymentDate.Remove(6, 2) + DateTime.Now.Year.ToString();
                //}
                //dtpReceiptDate.Value = DateTime.ParseExact(strReceiptDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //dtpPaymentDate.Value = DateTime.ParseExact(paymentDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
        private async Task FillCustomerData()
        {
            try
            {
                var customer = await BACustomerMaster.GetCustomer();
                cmbCustomerName.Items.Clear();
                cmbCustomerName.DataSource = null;
                cmbCustomerName.DisplayMember = "Customer_Name";
                cmbCustomerName.ValueMember = "Customer_Id";
                cmbCustomerName.DataSource = customer;
                cmbCustomerName.SelectedIndex = -1;
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private async Task FillReplaceStrList()
        {
            try
            {
                await Task.Run(async () =>
                    {
                        var custDetails = await BACustomerMaster.GetCustomer(receiptDetails.Customer_Id);
                        string customerName = custDetails.FirstOrDefault().Customer_Name;
                        customerName += string.IsNullOrWhiteSpace(Convert.ToString(custDetails.FirstOrDefault().Customer1)) == true ? " " : " & " + Convert.ToString(custDetails.FirstOrDefault().Customer1);
                        customerName += string.IsNullOrWhiteSpace(Convert.ToString(custDetails.FirstOrDefault().Customer2)) == true ? " " : " & " + Convert.ToString(custDetails.FirstOrDefault().Customer2);
                        customerName += string.IsNullOrWhiteSpace(Convert.ToString(custDetails.FirstOrDefault().Customer3)) == true ? " " : " & " + Convert.ToString(custDetails.FirstOrDefault().Customer3);
                        replaceStr = new Dictionary<string, string>();
                        replaceStr.Add("_DBReceiptNO", receiptDetails.Receipt_No.ToUpper());
                        replaceStr.Add("_DBCustomerName", customerName.ToUpper());
                        replaceStr.Add("_DBFlatShopNo", receiptDetails.Flate_ShopNo.ToUpper());
                        replaceStr.Add("_DBAmountInWord", receiptDetails.Amount_Word.ToUpper());
                        replaceStr.Add("_DBCheqRtgsNeftImps", receiptDetails.Cheq_Rtgs_Neft_ImpsNo + "\t");
                        replaceStr.Add("_DBDate", ClsUtil.getDateFormate(receiptDetails.PaymentDate));
                        replaceStr.Add("_DBBankName", receiptDetails.Bank_Name.ToUpper());
                        replaceStr.Add("_DBBranch", receiptDetails.Branch_Name.ToUpper());
                        replaceStr.Add("_DBReceivedAs", receiptDetails.ReceivedAs);
                        replaceStr.Add("_DBAmount", receiptDetails.Amount.ToString() + "/-");
                        replaceStr.Add("_DBReceiptDate", ClsUtil.getDateFormate(receiptDetails.PaymentDate));
                    });
                System.Threading.Thread.Sleep(100);
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
        private void Pdocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            int floatx = 55;
            int floaty = 10;
            e.Graphics.DrawString(string.Empty, new Font("Times New Roman", 12, FontStyle.Bold),
      Brushes.Black, floatx, floaty);
            floaty = floaty + 70;
            foreach (string strLine in printDocumentControls)
            {
                if (strLine.ToUpper().Contains("NAME") && !strLine.ToUpper().Contains("BANK NAME"))
                {
                    string[] custmor = strLine.Split('&');
                    for (int i = 0; i <= custmor.Length - 1; i++)
                    {
                        if (i == 0)
                        {
                            e.Graphics.DrawString(custmor[i] +(custmor.Count()>1 ? " & ":"") , new Font("Times New Roman", 12, FontStyle.Bold),
                            Brushes.Black, floatx, floaty);
                        }
                        else if(i<custmor.Length-1)
                        {
                            floaty = floaty + 20;
                            e.Graphics.DrawString("\t\t\t\t\t\t\t\t\t  "+ custmor[i]+ (custmor.Count() > 2 ? " & " : ""), new Font("Times New Roman", 12, FontStyle.Bold),
                            Brushes.Black, floatx, floaty);
                        }
                        else
                        {
                            floaty = floaty + 20;
                            e.Graphics.DrawString("\t\t\t\t\t\t\t\t  "+ custmor[i] + " ", new Font("Times New Roman", 12, FontStyle.Bold),
                            Brushes.Black, floatx, floaty);
                        }
                    }
                }
                else if (strLine.ToUpper().Contains("RS.(IN WORDS)"))
                {
                    if (strLine.Length > 60)
                    {
                        string[] displaytxt = strLine.Split(' ');
                        string displayadd = "";
                        for(int ln = 0; ln < 10; ln++)
                        {
                            displayadd += displaytxt[ln]+" ";
                        }
                        floaty = floaty + 20;
                        // e.Graphics.DrawString(strLine.Substring(0,74) + " ", new Font("Times New Roman", 12, FontStyle.Bold),
                        //Brushes.Black, floatx, floaty);
                        e.Graphics.DrawString(displayadd + " ", new Font("Times New Roman", 12, FontStyle.Bold),
                        Brushes.Black, floatx, floaty);
                        displayadd = "";
                        for (int ln = 10; ln < displaytxt.Length; ln++)
                        {
                            displayadd += displaytxt[ln] + " ";
                        }
                        floaty = floaty + 20;
                        e.Graphics.DrawString("\t\t\t\t\t\t\t   "+ displayadd + " ", new Font("Times New Roman", 12, FontStyle.Bold),
                        Brushes.Black, floatx, floaty);
                    }
                    else
                    {
                        floaty = floaty + 20;
                        e.Graphics.DrawString( strLine + " ", new Font("Times New Roman", 12, FontStyle.Bold),
                        Brushes.Black, floatx, floaty);
                    }
                }
                else
                {
                    e.Graphics.DrawString(strLine, new Font("Times New Roman", 12, FontStyle.Bold),
           Brushes.Black, floatx, floaty);
                }
                floaty = floaty + 20;
            }

        }

        private async Task FillDataInToEntity()
        {
            try
            {
                receiptDetails = new EnReceiptDetails();
                if (!string.IsNullOrWhiteSpace(Convert.ToString(txtReceiptNo.Tag)))
                {
                    receiptDetails.Receipt_Id = Convert.ToInt32(txtReceiptNo.Tag);
                }

                receiptDetails.Receipt_No = txtReceiptNo.Text.Trim();
                receiptDetails.Receipt_Date = dtpReceiptDate.Value.ToString("dd/MM/yyyy");
                receiptDetails.Bank_Name = cboBankName.Text;
                receiptDetails.Branch_Name = cboBranchName.Text;
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
                receiptDetails.IsCancel = ChkIsCancel.Checked == true ? 1 : 0;
                receiptDetails.IsPrint = 0;
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
        private void PrintDocumentView()
        {
            try
            {

                string receiptFilePath = ClsUtil.getCurrentPath() + "ReceiptTemplate.txt";
                try
                {
                    if (System.IO.File.Exists(ClsUtil.templateFolderPath + @"\ReceiptTemplate.txt"))
                    {
                        receiptFilePath = ClsUtil.templateFolderPath + @"\ReceiptTemplate.txt";
                    }
                }
                catch
                { }
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
                pdocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA5", 1024, 1024);
                pdocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                pdocument.PrintPage += Pdocument_PrintPage;
                prntprvControl.Document = pdocument;

            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled= false;
            try
            {
                clsWaitForm.ShowWaitForm();
                await FillDataInToEntity();

                Receipt_ID = await BAReceiptDetails.InsertUpdateReceiptDetails(receiptDetails);
                txtReceiptNo.Tag = Receipt_ID;
                await Task.Run(() => FillReplaceStrList());

                PrintDocumentView();

                clsWaitForm.CloseWaitForm();

            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
            btnSave.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtAmount.Text))
                {
                    txtAmountInWord.Text = ClsUtil.ConvertAmount(double.Parse(txtAmount.Text));
                }
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
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
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private async void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                clsWaitForm.ShowWaitForm();
                FillDataInToEntity();

                await Task.Run(() => FillReplaceStrList());

                PrintDocumentView();

                // Get the default printer name
                PrinterSettings settings = new PrinterSettings();
                string defaultPrinterName = settings.PrinterName;

                System.Threading.Thread.Sleep(1000);
                PrintDialog printDlg = new PrintDialog();
                //pdocument.DocumentName = "fileName";
                printDlg.Document = pdocument;
                printDlg.AllowSelection = true;
                printDlg.AllowSomePages = true;
                printDlg.PrinterSettings.Copies = 2;
                printDlg.PrinterSettings.PrinterName=defaultPrinterName;
                //Call ShowDialog
                clsWaitForm.CloseWaitForm();
                if (printDlg.ShowDialog() == DialogResult.OK)
                {
                    pdocument.Print();
                    await BAReceiptDetails.UpdateReceiptPrint(Receipt_ID);
                }
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private async void btnPrintPreviw_Click(object sender, EventArgs e)
        {
            try
            {
                clsWaitForm.ShowWaitForm();
                FillDataInToEntity();

                await Task.Run(() => FillReplaceStrList());

                PrintDocumentView();
                clsWaitForm.CloseWaitForm();
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private void txtFlatShopNo_Validated(object sender, EventArgs e)
        {
            try
            {
                if (txtFlatShopNo.Text.ToString().ToUpper().Contains("-"))
                {
                    int selectedindex = 0;
                    string[] strWingFlat = txtFlatShopNo.Text.Split('-');
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
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
    }
}
