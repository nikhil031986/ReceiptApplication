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
using System.Windows.Forms;

namespace Receipt
{
    public partial class frmCheqDetail : Form
    {
        private string[] printDocumentControls;
        private EnCheqDetails cheqDetails;
        private PrintDocument pdocument;
        private Dictionary<string, string> replaceStr;
        public int cheqDetailsId { get; set; }

        bool _isSaveRecords = false;
        public frmCheqDetail()
        {
            try
            {
                InitializeComponent();
                Task.Run(() => FillCustomerData()).Wait();
                cheqDetails = new EnCheqDetails();
                clsLog.InstanceCreation().InsertLog("Open CheqDetail", clsLog.logType.Info, "frmCheqDetail.frmCheqDetail");
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, "frmCheqDetail.frmCheqDetail");
            }        
        }
        public frmCheqDetail(int cheqId)
        {
            try
            {
                InitializeComponent();
                Task.Run(() => FillCustomerData()).Wait();
                cheqDetails = new EnCheqDetails();
                Task.Run(() => GetCheqDetails(cheqId)).Wait();
                clsLog.InstanceCreation().InsertLog("Open CheqDetail", clsLog.logType.Info, "frmCheqDetail.frmCheqDetail(CeqId="+cheqId.ToString()+")");
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, "frmCheqDetail.frmCheqDetail(CeqId="+cheqId.ToString()+")");
            }
        }
        private async Task FillReplaceStrList()
        {
            try
            {
                await Task.Run(() =>
                    {
                        replaceStr = new Dictionary<string, string>();
                        string cheqDate = "  " + cheqDetails.Cheq_Date.Substring(0, 1) + "    "
                                          + cheqDetails.Cheq_Date.Substring(1, 1) + "   "
                                          + cheqDetails.Cheq_Date.Substring(3, 1) + "    "
                                          + cheqDetails.Cheq_Date.Substring(4, 1) + "    "
                                          + cheqDetails.Cheq_Date.Substring(6, 1) + "    "
                                          + cheqDetails.Cheq_Date.Substring(7, 1) + "    "
                                          + cheqDetails.Cheq_Date.Substring(8, 1) + "    "
                                          + cheqDetails.Cheq_Date.Substring(9, 1);

                        replaceStr.Add("_D__D__M__M__Y__Y__Y__Y", cheqDate);
                        replaceStr.Add("_memberName", cheqDetails.Customer_Name.ToUpper());
                        replaceStr.Add("_AmountInWord", cheqDetails.Amount_InWord.ToUpper());
                        replaceStr.Add("_Amount", cheqDetails.Amount.ToString().ToUpper());
                    });
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, "frmCheqDetail.frmCheqDetail"); }
        }
        private void Pdocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                int floatx = 5;
                int floaty = 215;

                e.Graphics.DrawString(string.Empty, new Font("Times New Roman", 10, FontStyle.Bold),
          Brushes.Black, floatx, floaty);
                floaty = floaty + 22;
                //     for(int blankLine=0;blankLine<6;blankLine++)
                //     {
                //         e.Graphics.DrawString(string.Empty, new Font("Times New Roman", 10, FontStyle.Bold),
                //Brushes.Black, floatx, floaty);
                //         floaty = floaty + 20;
                //     }
                int linespace = 0;
                foreach (string strLine in printDocumentControls)
                {
                    if (linespace == 10)
                    {
                        floaty = floaty - 3;
                    }
                    e.Graphics.DrawString(strLine, new Font("Times New Roman", 10, FontStyle.Bold),
           Brushes.Black, floatx, floaty);

                    if (linespace == 0 || (linespace >= 1 && linespace <= 4))
                    {
                        floaty = floaty + 10;
                    }
                    if (linespace >= 5)
                    {
                        floaty = floaty + 8;
                    }
                    if (linespace == 6)
                    {
                        floaty = floaty + 10;
                    }
                    if (linespace == 7)
                    {
                        floaty = floaty + 10;
                    }
                    if (linespace == 8)
                    {
                        floaty = floaty + 20;
                    }
                    linespace = linespace + 1;
                }
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
        private async Task GetCheqDetails(int cheqDetailId)
        {
            try
            {
                var cheqdtl = await BACheqDetails.GetCheqDetails(cheqDetailId);
                txtAmount.Tag = cheqdtl.FirstOrDefault().Cheq_Details_Id;
                cmbCustomer.Text = cheqdtl.FirstOrDefault().Customer_Name;
                dtpCheqDate.Value = DateTime.ParseExact(cheqdtl.FirstOrDefault().Cheq_Date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                txtAmount.Text = cheqdtl.FirstOrDefault().Amount.ToString();
                txtAmountInWord.Text = cheqdtl.FirstOrDefault().Amount_InWord;
                txtCheqNo.Text = cheqdtl.FirstOrDefault().Cheq_No;
                txtBankName.Text = cheqdtl.FirstOrDefault().Bank_Name;
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
        private bool validateion()
        {
            bool rtnValidation = true;
            //if (string.IsNullOrWhiteSpace(txtBankName.Text))
            //{
            //    txtBankName.Focus();
            //    return false;
            //}
            //if (string.IsNullOrWhiteSpace(txtCheqNo.Text))
            //{
            //    txtCheqNo.Focus();
            //    return false;
            //}
            if (string.IsNullOrWhiteSpace(cmbCustomer.Text))
            {
                cmbCustomer.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                txtAmount.Focus();
                return false;
            }
            if (txtAmount.Text.Trim() == "0")
            {
                txtAmount.Focus();
                return false;
            }
            return rtnValidation;
        }
        private void FillDataInToEntity()
        {
            try
            {
                cheqDetails = new EnCheqDetails();
                if (!string.IsNullOrWhiteSpace(Convert.ToString(txtAmount.Tag)))
                {
                    cheqDetails.Cheq_Details_Id = Convert.ToInt32(txtAmount.Tag);
                }

                cheqDetails.Cheq_Date = dtpCheqDate.Value.ToString("dd/MM/yyyy");
                cheqDetails.Amount = Convert.ToDecimal(txtAmount.Text);
                cheqDetails.Customer_Name = cmbCustomer.Text;
                cheqDetails.Amount_InWord = txtAmountInWord.Text;
                cheqDetails.Cheq_No = txtCheqNo.Text;
                cheqDetails.Bank_Name = txtBankName.Text;

            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
            }        
        }
        private void PrintDocumentView()
        {
            try
            {
                var receiptFilePath = ClsUtil.getCurrentPath() + "CheqPrint.txt";
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
                pdocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA4", 840, 1024);
                pdocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                pdocument.PrintPage += Pdocument_PrintPage;
                prntprvControl.Document = pdocument;

            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
        private async Task FillCustomerData()
        {
            try
            {
                var customer = await BACheqDetails.GetCustomerName();
                cmbCustomer.Items.Clear();
                cmbCustomer.DataSource = null;
                cmbCustomer.DisplayMember = "Customer_Name";
                cmbCustomer.ValueMember = "Customer_Name";
                cmbCustomer.DataSource = customer;
                cmbCustomer.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validateion())
                    return;

                FillDataInToEntity();

                cheqDetailsId = await BACheqDetails.InsertUpdateCheqDetqails(cheqDetails);

                await Task.Run(() => FillReplaceStrList());

                _isSaveRecords = true;

                PrintDocumentView();
            }
            catch (Exception ex)
            {
                ReceiptLog.clsLog.InstanceCreation().InsertLog(ex.Message, ReceiptLog.clsLog.logType.Error, "frmCheqDetails.btnSave_Click");
            }
        }

        private async void btnPrintPrivew_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validateion())
                    return;

                FillDataInToEntity();

                await Task.Run(() => FillReplaceStrList());

                PrintDocumentView();
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(),clsLog.logType.Error,MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            try
            {
                if (!_isSaveRecords)
                {
                    MessageBox.Show("Records must be save first then print..", "Cheq Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                PrintDialog printDlg = new PrintDialog();
                pdocument.DocumentName = "fileName";
                printDlg.Document = pdocument;
                printDlg.AllowSelection = true;
                printDlg.AllowSomePages = true;
                //Call ShowDialog
                if (printDlg.ShowDialog() == DialogResult.OK)
                    pdocument.Print();
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, "btnPrint_Click");
            }
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
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, "txtAmount_TextChanged");
            }
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
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, "txtAmount_KeyPress");
            }
        }

        private void frmCheqDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!_isSaveRecords && !string.IsNullOrWhiteSpace(Convert.ToString(cheqDetails.Cheq_Details_Id)) && cheqDetails.Cheq_Details_Id > 0)
                {
                    MessageBox.Show("Records must be save first then close..", "Cheq Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, "txtAmount_TextChanged"); }
        }
    }
}
