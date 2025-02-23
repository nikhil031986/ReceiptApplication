using ReceiptBAccess;
using ReceiptEntity;
using ReceiptLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Navigation;

namespace Receipt
{
    public partial class frmBanakhat : Form
    {
        public event EventHandler CloseUserDetails;
        private string htmlFilePath = string.Empty;

        
        public frmBanakhat()
        {
            try
            {
                InitializeComponent();
                FillCustomer();
                clsLog.InstanceCreation().InsertLog("Banakhat Open", clsLog.logType.Info, "");
                string FileName = ClsUtil.getCurrentPath() + "BlankFile.html";
                wbHtmlView.Url = new Uri("file:///" + FileName);
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, "frmBanakhat.frmBanakhat");
            }
        }
        private async Task FillCustomer()
        {
            try
            {
                var customer = await BACustomerMaster.GetCustomer();
                cmbCustomer.Items.Clear();
                cmbCustomer.DataSource = null;
                cmbCustomer.DisplayMember = "Customer_Name";
                cmbCustomer.ValueMember = "Customer_Id";
                cmbCustomer.DataSource = customer;
                cmbCustomer.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
            }
        }

        private async Task CreateHTMLFile()
        {
            try
            {
                htmlFilePath = "";
                StringBuilder strNewHTMLFile = new StringBuilder();
                var selectedCustomer = cmbCustomer.SelectedItem;
                var wingDetails = await BaWingMaster.GetWingDetails(((EnCustomer)selectedCustomer).Wing_Master_Id);
                var wingMaster = await BaWingMaster.GetWingMaster(((EnCustomer)selectedCustomer).Wing_Master_Id);
                var selectedWingDetails = wingDetails.AsEnumerable().Where(x => x.Wing_DetailsId == ((EnCustomer)selectedCustomer).Wing_Details_Id).SingleOrDefault();
                var selectReceiptDetails = await BAReceiptDetails.GetReceiptByCustomer(((EnCustomer)selectedCustomer).Customer_Id);
                strNewHTMLFile.AppendLine(@"<html>");
                strNewHTMLFile.AppendLine(@"<body>");
                strNewHTMLFile.AppendLine(@"<table border='1' cellpadding = '1' cellspacing = '1' style = 'width:100%' > ");
                strNewHTMLFile.AppendLine(@"	<tbody>");
                strNewHTMLFile.AppendLine(@"		<tr>");
                strNewHTMLFile.AppendLine(@"			<td style='text-align:center'><strong>" + ClsUtil.SiteAddress + "</strong></td>");
                strNewHTMLFile.AppendLine(@"		</tr>");
                strNewHTMLFile.AppendLine(@"		<tr>");
                strNewHTMLFile.AppendLine(@"			<td style='text-align:center'><strong>REG. BANAKHAT</strong></td>");
                strNewHTMLFile.AppendLine(@"		</tr>");
                strNewHTMLFile.AppendLine(@"		<tr>");
                strNewHTMLFile.AppendLine(@"			<td>");
                strNewHTMLFile.AppendLine(@"			<table border='1' cellpadding = '1' cellspacing='1' style='width: 100%'>");
                strNewHTMLFile.AppendLine(@"				<tbody>");
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td style='width:108px;background-color:#E8E8E8;'><strong>FLAT NO.:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td colspan='2' rowspan = '1' style = 'text-align:center; width:226px' >" + ((EnCustomer)selectedCustomer).Wing_Name + "-" + ((EnCustomer)selectedCustomer).FlatNo + "</td> ");
                strNewHTMLFile.AppendLine(@"						<td style='width:95px;background-color:#E8E8E8;'><strong>BLOCK.:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td colspan='2' rowspan = '1' style = 'text-align:center; width:340px' > " + ((EnCustomer)selectedCustomer).Wing_Name + " </ td > ");
                strNewHTMLFile.AppendLine(@"						<td style='width:225px;background-color:#E8E8E8;'><strong>FLOOR.:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:168px' colspan='2'>" + selectedWingDetails.FlorName.ToUpper() + "</td>");
                strNewHTMLFile.AppendLine(@"					</tr>");
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td style='width:108px;background-color:#E8E8E8;'><strong>LAND.:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:89px'>" + selectedWingDetails.Land.ToString() + "</td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:132px'>SQ.MTR</td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:95px;background-color:#E8E8E8;'><strong>TOTAL.:-</strong></td>");                
                strNewHTMLFile.AppendLine(@"						<td style='width:167px'>" + selectedWingDetails.Total.ToString() + "</td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:168px'>SQ.MTR</td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:225px;background-color:#E8E8E8;' rowspan='2'><strong>Open Tarrace :-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:168px'  rowspan='2'>" + selectedWingDetails.Open_Terrace.ToString("0.00") + "</td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:168px'  rowspan='2'>SQ.MTR</td>");
                strNewHTMLFile.AppendLine(@"					</tr>");
                
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td style='width:108px;background-color:#E8E8E8;'><strong>CARPET.:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:89px'>" + selectedWingDetails.Carpet.ToString() + "</td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:132px'>SQ.MTR</td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:95px;background-color:#E8E8E8;'><strong>W/B</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:167px'>" + selectedWingDetails.WB.ToString() + "</td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:168px'>SQ.MTR</td>");

               

                strNewHTMLFile.AppendLine(@"					</tr>");
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td style='width:225px;background-color:#E8E8E8;' colspan='3'><strong>AMT.:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:168px' colspan='2'>" + selectedWingDetails.Amount.ToString() + "</td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:225px;background-color:#E8E8E8;'  colspan='3'><strong>RELIGION.:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:168px'>HINDU</td>");
                strNewHTMLFile.AppendLine(@"					</tr>");
                strNewHTMLFile.AppendLine(@"				</tbody>");
                strNewHTMLFile.AppendLine(@"			</table>");
                strNewHTMLFile.AppendLine(@"");
                strNewHTMLFile.AppendLine(@"			<table border='1' cellpadding='1' cellspacing='1' style='width:100%'>");
                strNewHTMLFile.AppendLine(@"				<tbody>");
                if (!string.IsNullOrWhiteSpace(((EnCustomer)selectedCustomer).Customer_Name))
                {
                    strNewHTMLFile.AppendLine(@"					<tr>");
                    strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8;'><strong>NAME.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td colspan='1' rowspan='2'>" + ((EnCustomer)selectedCustomer).Customer_Name + "</td>");
                    strNewHTMLFile.AppendLine(@"						<td ><strong>OCCUPATION.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td>" + ((EnCustomer)selectedCustomer).Ocupation + "</td>");
                    strNewHTMLFile.AppendLine(@"					</tr>");
                    strNewHTMLFile.AppendLine(@"					<tr>");
                    strNewHTMLFile.AppendLine(@"						<td>&nbsp;</td>");
                    strNewHTMLFile.AppendLine(@"						<td><strong>BANAKHAT. NO.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td>" + ((EnCustomer)selectedCustomer).BanakhatNo + "</td>");
                    strNewHTMLFile.AppendLine(@"					</tr>");
                    strNewHTMLFile.AppendLine(@"					<tr>");
                    strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8;'><strong>PAN NO.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td>" + ((EnCustomer)selectedCustomer).Pan + "</td>");
                    strNewHTMLFile.AppendLine(@"						<td><strong>DATE:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td>" + ClsUtil.getDateFormate( ((EnCustomer)selectedCustomer).BanakhatDate) + "</td>");
                    strNewHTMLFile.AppendLine(@"					</tr>");
                    strNewHTMLFile.AppendLine(@"					<tr>");
                    strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8;'><strong>ADHAR NO.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td colspan='3' rowspan = '1' > " + ((EnCustomer)selectedCustomer).Aadhar + " </ td > ");
                    strNewHTMLFile.AppendLine(@"					</tr>");
                }
                if (!string.IsNullOrWhiteSpace(((EnCustomer)selectedCustomer).Customer1))
                {
                    strNewHTMLFile.AppendLine(@"					<tr>");
                    strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8;'><strong>NAME.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td colspan='1'>" + ((EnCustomer)selectedCustomer).Customer1 + "</td>");
                    strNewHTMLFile.AppendLine(@"						<td><strong>OCCUPATION.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td>" + ((EnCustomer)selectedCustomer).Ocupation1 + "</td>");
                    strNewHTMLFile.AppendLine(@"					</tr>");
                    strNewHTMLFile.AppendLine(@"					<tr>");
                    strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8;'><strong>PAN NO.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td>" + ((EnCustomer)selectedCustomer).Pan1 + "</td>");
                    strNewHTMLFile.AppendLine(@"					</tr>");
                    strNewHTMLFile.AppendLine(@"					<tr>");
                    strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8;'><strong>ADHAR NO.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td colspan='3' rowspan = '1' > " + ((EnCustomer)selectedCustomer).Aadhar1 + "</td>");
                    strNewHTMLFile.AppendLine(@"					</tr>");
                }
                if (!string.IsNullOrWhiteSpace(((EnCustomer)selectedCustomer).Customer2))
                {
                    strNewHTMLFile.AppendLine(@"					<tr>");
                    strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8;'><strong>NAME.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td colspan='1'>" + ((EnCustomer)selectedCustomer).Customer2 + "</td>");
                    strNewHTMLFile.AppendLine(@"						<td><strong>OCCUPATION.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td>" + ((EnCustomer)selectedCustomer).Ocupation2 + "</td>");
                    strNewHTMLFile.AppendLine(@"					</tr>");
                    strNewHTMLFile.AppendLine(@"					<tr>");
                    strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8;'><strong>PAN NO.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td>" + ((EnCustomer)selectedCustomer).Pan2 + "</td>");
                    strNewHTMLFile.AppendLine(@"					</tr>");
                    strNewHTMLFile.AppendLine(@"					<tr>");
                    strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8;'><strong>ADHAR NO.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td colspan='3' rowspan = '1' > " + ((EnCustomer)selectedCustomer).Aadhar2 + "</ td > ");
                    strNewHTMLFile.AppendLine(@"					</tr>");
                }
                if (!string.IsNullOrWhiteSpace(((EnCustomer)selectedCustomer).Customer3))
                {
                    strNewHTMLFile.AppendLine(@"					<tr>");
                    strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8;'><strong>NAME.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td colspan='1'>" + ((EnCustomer)selectedCustomer).Customer3 + "</td>");
                    strNewHTMLFile.AppendLine(@"						<td><strong>OCCUPATION.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td>" + ((EnCustomer)selectedCustomer).Ocupation3 + "</td>");
                    strNewHTMLFile.AppendLine(@"					</tr>");
                    strNewHTMLFile.AppendLine(@"					<tr>");
                    strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8;'><strong>PAN NO.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td>" + ((EnCustomer)selectedCustomer).Pan3 + "</td>");
                    strNewHTMLFile.AppendLine(@"					</tr>");
                    strNewHTMLFile.AppendLine(@"					<tr>");
                    strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8;'><strong>ADHAR NO.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td colspan='3' rowspan = '1' > " + ((EnCustomer)selectedCustomer).Aadhar3 + "</ td > ");
                    strNewHTMLFile.AppendLine(@"					</tr>");
                }
                if (!string.IsNullOrWhiteSpace(((EnCustomer)selectedCustomer).Address))
                {
                    strNewHTMLFile.AppendLine(@"					<tr>");
                    strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8;'><strong>ADDRESS.:-</strong></td>");
                    strNewHTMLFile.AppendLine(@"						<td colspan='3' rowspan='2'>" + ((EnCustomer)selectedCustomer).Address.ToUpper() + "</td>");
                    strNewHTMLFile.AppendLine(@"					</tr>");
                }
                strNewHTMLFile.AppendLine(@"				</tbody>");
                strNewHTMLFile.AppendLine(@"			</table>");
                strNewHTMLFile.AppendLine(@"			</td>");
                strNewHTMLFile.AppendLine(@"		</tr>");
                strNewHTMLFile.AppendLine(@"		<tr>");
                strNewHTMLFile.AppendLine(@"			<td>");
                strNewHTMLFile.AppendLine(@"			<table border='1' cellpadding = '1' cellspacing = '1' style = 'width:100%' > ");
                strNewHTMLFile.AppendLine(@"				<tbody>");
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td style='text-align:center;background-color:#E8E8E8;'><strong>AMT.</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='text-align:center; width:404px;background-color:#E8E8E8;'><strong>BANK</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='text-align:center; width:229px;background-color:#E8E8E8;'><strong>BRANCH</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='text-align:center; width:232px;background-color:#E8E8E8;'><strong>CH./RTGS. NO.</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='text-align:center; width:144px;background-color:#E8E8E8;'><strong>DATE</strong></td>");
                strNewHTMLFile.AppendLine(@"					</tr>");
                decimal TotalAmount = 0;
                foreach (var receipt in selectReceiptDetails)
                {
                    strNewHTMLFile.AppendLine(@"					<tr>");
                    strNewHTMLFile.AppendLine(@"						<td style='text-align:right'>" + receipt.Amount + "</td>");
                    strNewHTMLFile.AppendLine(@"						<td style='width:404px'>" + receipt.Bank_Name + "</td>");
                    strNewHTMLFile.AppendLine(@"						<td style='text-align:center; width:229px'>" + receipt.Branch_Name + "</td>");
                    strNewHTMLFile.AppendLine(@"						<td style='text-align:center; width:232px'>" + receipt.Cheq_Rtgs_Neft_ImpsNo + "</td>");
                    strNewHTMLFile.AppendLine(@"						<td style='text-align:center; width:144px'>" + ClsUtil.getDateFormate(receipt.PaymentDate).Replace("/", ".") + "</td>");
                    strNewHTMLFile.AppendLine(@"					</tr>");
                    TotalAmount = TotalAmount + receipt.Amount;
                }
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td style='text-align:right'><strong>" + TotalAmount.ToString() + "</strong></td>");
                decimal pendingAmount = selectedWingDetails.Amount - TotalAmount;
                strNewHTMLFile.AppendLine(@"						<td style='width:404px'>-<strong>" + pendingAmount + "</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='text-align:center; width:229px'>&nbsp;</td>");
                strNewHTMLFile.AppendLine(@"						<td style='text-align:center; width:232px'>&nbsp;</td>");
                strNewHTMLFile.AppendLine(@"						<td style='text-align:center; width:144px'>&nbsp;</td>");
                strNewHTMLFile.AppendLine(@"					</tr>");
                strNewHTMLFile.AppendLine(@"				</tbody>");
                strNewHTMLFile.AppendLine(@"			</table>");
                strNewHTMLFile.AppendLine(@"			</td>");
                strNewHTMLFile.AppendLine(@"		</tr>");

                strNewHTMLFile.AppendLine(@"		<tr>");
                strNewHTMLFile.AppendLine(@"			<td style='background-color:#E8E8E8;'><strong>ALL BOUNDRIES DETAIL</strong></td>");
                strNewHTMLFile.AppendLine(@"		</tr>");
                strNewHTMLFile.AppendLine(@"		<tr>");
                strNewHTMLFile.AppendLine(@"			<td>");
                strNewHTMLFile.AppendLine(@"			<table border='1' cellpadding='1' cellspacing='1' style='width:100%'>");
                strNewHTMLFile.AppendLine(@"				<tbody>");
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td style='text-align:center; width:89px'><strong>EAST</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:1070px'>" + selectedWingDetails.EAST + "</td>");
                strNewHTMLFile.AppendLine(@"						<td rowspan='4' style='width:1070px'>");
                if(((EnCustomer)selectedCustomer).Financial_Name.ToUpper()=="SBI")
                {
                    string FilePathAdd = ClsUtil.getCurrentPath() + "SBI\\";
                    List<string> UpdateStr = new List<string>();
                    List<string> repValue = ClsUtil.GetALLOTMENTLST();
                }
                if (((EnCustomer)selectedCustomer).Financial_Name.ToUpper().Trim() == "AXIS BANK LTD.")
                {
                    string FilePathAdd = ClsUtil.getCurrentPath() + "AxisBank\\";
                    List<string> UpdateStr = new List<string>();
                    List<string> repValue = ClsUtil.GetALLOTMENTLST();
                    var custwingDetail = wingDetails.Where(x => x.Wing_DetailsId == ((EnCustomer)selectedCustomer).Wing_Details_Id).FirstOrDefault();
                    UpdateListBaseInRepStr(repValue, UpdateStr, (EnCustomer)selectedCustomer, custwingDetail, wingMaster.FirstOrDefault(),TotalAmount,pendingAmount);
                    UpdateCustomerFile(FilePathAdd + "ALLOTMENT LETTER.docx", FilePathAdd + ((EnCustomer)selectedCustomer).Customer_Id + "ALLOTMENT LETTER.docx",
                        repValue, UpdateStr);
                    strNewHTMLFile.AppendLine(@"                <p><a href='" + FilePathAdd + ((EnCustomer)selectedCustomer).Customer_Id + "ALLOTMENT LETTER.docx" + "'>ALLOTMENT LETTER</a></p>");
                    repValue = ClsUtil.GetDEMANDLST();
                    UpdateStr = new List<string>();
                    UpdateListBaseInRepStr(repValue, UpdateStr, (EnCustomer)selectedCustomer, custwingDetail, wingMaster.FirstOrDefault(), TotalAmount, pendingAmount);
                    UpdateCustomerFile(FilePathAdd + "DEMAND LETTER.doc", FilePathAdd + ((EnCustomer)selectedCustomer).Customer_Id + "DEMAND LETTER.doc",
                        repValue, UpdateStr);
                    strNewHTMLFile.AppendLine(@"                <p><a href='" + FilePathAdd + ((EnCustomer)selectedCustomer).Customer_Id + "DEMAND LETTER.doc" + "'>DEMAND LETTER</a></p>");
                    repValue = ClsUtil.GetMARGINLST();
                    UpdateStr = new List<string>();
                    UpdateListBaseInRepStr(repValue, UpdateStr, (EnCustomer)selectedCustomer, custwingDetail, wingMaster.FirstOrDefault(), TotalAmount, pendingAmount);
                    UpdateCustomerFile(FilePathAdd + "MARGIN MONEY LETTER.docx", FilePathAdd + ((EnCustomer)selectedCustomer).Customer_Id + "MARGIN MONEY LETTER.docx",
                        repValue, UpdateStr);
                    strNewHTMLFile.AppendLine(@"                <p><a href='" + FilePathAdd + ((EnCustomer)selectedCustomer).Customer_Id + "MARGIN MONEY LETTER.docx" + "'>MARGIN MONEY LETTER</a></p>");
                    repValue = ClsUtil.GetNOCLST();
                    UpdateStr = new List<string>();
                    UpdateListBaseInRepStr(repValue, UpdateStr, (EnCustomer)selectedCustomer, custwingDetail, wingMaster.FirstOrDefault(), TotalAmount, pendingAmount);
                    UpdateCustomerFile(FilePathAdd + "NOC-FLAT.doc", FilePathAdd + ((EnCustomer)selectedCustomer).Customer_Id + "NOC-FLAT.doc",
                        repValue, UpdateStr);
                    strNewHTMLFile.AppendLine(@"                <p><a href='" + FilePathAdd + ((EnCustomer)selectedCustomer).Customer_Id + "NOC-FLAT.doc" + "'>NOC-FLAT</a></p>");
                }
                strNewHTMLFile.AppendLine(@"			</td>");
                strNewHTMLFile.AppendLine(@"					</tr>");
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td style='text-align:center; width:89px'><strong>WEST</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:1070px'>" + selectedWingDetails.WEST + "</td>");
                strNewHTMLFile.AppendLine(@"					</tr>");
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td style='text-align:center; width:89px'><strong>NORTH</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:1070px'>" + selectedWingDetails.NORTH + "</td>");
                strNewHTMLFile.AppendLine(@"					</tr>");
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td style='text-align:center; width:89px'><strong>SOUTH</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td style='width:1070px'>" + selectedWingDetails.SOUTH + "</td>");
                strNewHTMLFile.AppendLine(@"					</tr>");
                strNewHTMLFile.AppendLine(@"				</tbody>");
                strNewHTMLFile.AppendLine(@"			</table>");
                strNewHTMLFile.AppendLine(@"			</td>");


                strNewHTMLFile.AppendLine(@"		</tr>");
                strNewHTMLFile.AppendLine(@"	</tbody>");
                strNewHTMLFile.AppendLine(@"</table>");
                strNewHTMLFile.AppendLine(@"");
                strNewHTMLFile.AppendLine(@"</body>");
                strNewHTMLFile.AppendLine(@"</html>");

                string FileName = ClsUtil.getCurrentPath() + "Banakhat.html";


                if (System.IO.File.Exists(FileName))
                {
                    System.IO.File.Delete(FileName);
                }

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(FileName))
                {
                    file.WriteLine(strNewHTMLFile.ToString()); // "sb" is the StringBuilder
                }

                htmlFilePath = FileName;

                wbHtmlView.Url = new Uri("file:///" + FileName);

            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Module.Name);
            }
        }
        private void UpdateListBaseInRepStr(List<string> repList, List<string> UpList,EnCustomer customer,EnWingDetails wingDetails,EnWingMaster wingMaster,decimal TotalAmount, decimal pendingAmount)
        {
            try
            {
                for(int i = 0; i < repList.Count;i++)
                {
                    if (repList[i].ToUpper() == "{CURRENTDATE}")
                    {
                        UpList.Add(DateTime.Now.ToString("dd/MM/yyyy"));
                    }
                    if (repList[i].ToUpper() == "{BLOCK}")
                    {
                        UpList.Add(wingMaster.Wing_Name.ToUpper());
                    }
                    if (repList[i].ToUpper() == "{FLATNO}")
                    {
                        UpList.Add(wingDetails.FlatNo.ToString());
                    }
                    if (repList[i].ToUpper() == "{FLORNAME}")
                    {
                        UpList.Add(wingDetails.FlorName.ToUpper());
                    }
                    if (repList[i].ToUpper() == "{CUSTOMERNAME}")
                    {
                        string custName = customer.Customer_Name.ToUpper();
                        if (!string.IsNullOrEmpty(Convert.ToString(customer.Customer1)))
                        {
                            custName = custName + " & " + customer.Customer1.ToUpper();
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(customer.Customer2)))
                        {
                            custName = custName + " & " + customer.Customer2.ToUpper();
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(customer.Customer3)))
                        {
                            custName = custName + " & " + customer.Customer3.ToUpper();
                        }
                        UpList.Add(custName);
                    }
                    if (repList[i].ToUpper() == "{CARPET}")
                    {
                        UpList.Add(wingDetails.Carpet.ToString());
                    }
                    if (repList[i].ToUpper() == "{WASH}")
                    {
                        UpList.Add(wingDetails.WB.ToString());
                    }
                    if (repList[i].ToUpper() == "{AMOUNTWITHNAME}")
                    {
                        var amountwithName = "Rs." + wingDetails.Amount.ToString() + "/- (" + ClsUtil.ConvertWord(Convert.ToInt32(wingDetails.Amount)).ToUpper() + " ONLY)";
                        UpList.Add(amountwithName);
                    }
                    if (repList[i].ToUpper() == "{EAST}")
                    {
                        UpList.Add(wingDetails.EAST.ToUpper());
                    }
                    if (repList[i].ToUpper() == "{WEST}")
                    {
                        UpList.Add(wingDetails.WEST.ToUpper());
                    }
                    if (repList[i].ToUpper() == "{NORTH}")
                    {
                        UpList.Add(wingDetails.NORTH.ToUpper());
                    }
                    if (repList[i].ToUpper() == "{SOUTH}")
                    {
                        UpList.Add(wingDetails.SOUTH.ToUpper());
                    }
                    if (repList[i].ToUpper() == "{CURRENTDT}")
                    {
                        UpList.Add(DateTime.Now.ToString("dd/MM/yyyy"));
                    }
                    
                    if (repList[i].ToUpper() == "{AMOUNTONLY}")
                    {
                        UpList.Add(TotalAmount.ToString());
                    }
                    if (repList[i].ToUpper() == "{DUEAMOUNT}")
                    {
                        UpList.Add(pendingAmount.ToString());
                    }

                    if (repList[i].ToUpper() == "{FLATNOS}")
                    {
                        UpList.Add(wingMaster.Wing_Name.ToUpper() + "-" + wingDetails.FlatNo.ToString());
                    }
                    if (repList[i].ToUpper() == "{FLOORNAME}")
                    {
                        UpList.Add(wingDetails.FlorName.ToString().ToUpper());
                    }
                    if (repList[i].ToUpper() == "{AMOUNTINWORDS}")
                    {
                        var amountwithName = "Rs." + wingDetails.Amount.ToString() + "/- (" + ClsUtil.ConvertWord(Convert.ToInt32(wingDetails.Amount)).ToUpper() + " ONLY)";
                        UpList.Add(amountwithName);
                    }
                    if (repList[i].ToUpper() == "{RECEIVEDAMOUNT}")
                    {
                        UpList.Add(TotalAmount.ToString());
                    }

                    if (repList[i].ToUpper() == "{CURRNETDATE}")
                    {
                        UpList.Add(DateTime.Now.ToString("dd/MM/yyyy"));
                    }
                    if (repList[i].ToUpper() == "{FLATAMOUNT}")
                    {
                        UpList.Add(wingDetails.Amount.ToString());
                    }
                    if (repList[i].ToUpper() == "{LAND}")
                    {
                        UpList.Add(wingDetails.Land.ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Module.Name);
            }
        }
        private async void UpdateCustomerFile(string FilePath, string replaceFilePath, List<string> replatce, List<string> update)
        {
            try
            {

                if (System.IO.File.Exists(replaceFilePath))
                {
                    System.IO.File.Delete(replaceFilePath);
                }
                var wordApp = new Microsoft.Office.Interop.Word.Application();
                var doc = wordApp.Documents.Open(FilePath, false, true);

                try
                {
                    for (int i = 0; i < replatce.Count; i++)
                    {
                        var Upstatus = doc.Content.Find.Execute(FindText: replatce[i],
                                                MatchCase: false,
                                                MatchWholeWord: false,
                                                MatchWildcards: false,
                                                MatchSoundsLike: false,
                                                MatchAllWordForms: false,
                                                Forward: true, //this may be the one
                                                Wrap: false,
                                                Format: false,
                                                ReplaceWith: update[i],
                                                Replace: Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll
                                                );
                    }
                    doc.SaveAs(replaceFilePath);
                }
                catch (Exception ex)
                {
                    clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Module.Name);
                }
                finally
                {
                    if (wordApp != null)
                    {
                        doc.Close();
                        wordApp.Quit();
                        doc = null;
                        wordApp = null;
                    }
                    GC.Collect();
                }
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Module.Name);
            }
        }
        private async void btnprintprivew_Click(object sender, EventArgs e)
        {
            clsWaitForm.ShowWaitForm();
            try
            {
                await CreateHTMLFile();
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                clsWaitForm.CloseWaitForm();
                GC.Collect();
            }
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            wbHtmlView.ShowPrintDialog();
        }

        private void txtFlatNo_Validated(object sender, EventArgs e)
        {
            try
            {
                if (txtFlatNo.Text.ToString().ToUpper().Contains("-"))
                {
                    int selectedindex = 0;
                    string[] strWingFlat = txtFlatNo.Text.Split('-');
                    if (strWingFlat.Length >= 1)
                    {
                        foreach (EnCustomer items in cmbCustomer.Items)
                        {
                            if (items.Wing_Name.Trim().ToUpper() == strWingFlat[0].Trim().ToUpper() && items.FlatNo.ToUpper() == strWingFlat[1].ToUpper())
                            {
                                cmbCustomer.SelectedIndex = selectedindex;
                                break;
                            }
                            selectedindex = selectedindex + 1;
                        }
                    }
                    else
                    {
                        cmbCustomer.SelectedIndex = -1;
                    }
                }
                else
                {
                    cmbCustomer.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
