using Microsoft.Office.Interop.Excel;
using ReceiptBAccess;
using ReceiptEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Receipt
{
    public partial class frmBanakhat : Form
    {
        public event EventHandler CloseUserDetails;
        private string htmlFilePath = string.Empty;
        public frmBanakhat()
        {
            InitializeComponent();
            FillCustomer();
        }
        private async Task FillCustomer()
        {
            var customer = await BACustomerMaster.GetCustomer();
            cmbCustomer.Items.Clear();
            cmbCustomer.DataSource = null;
            cmbCustomer.DisplayMember = "Customer_Name";
            cmbCustomer.ValueMember = "Customer_Id";
            cmbCustomer.DataSource = customer;
            cmbCustomer.SelectedIndex = -1;
        }

        private async Task CreateHTMLFile()
        {
            htmlFilePath = "";
            StringBuilder strNewHTMLFile = new StringBuilder();
            var selectedCustomer = cmbCustomer.SelectedItem;
            var wingDetails = await BaWingMaster.GetWingDetails(((EnCustomer)selectedCustomer).Wing_Master_Id);
            var selectedWingDetails = wingDetails.AsEnumerable().Where(x => x.Wing_DetailsId == ((EnCustomer)selectedCustomer).Wing_Details_Id).FirstOrDefault();
            var selectReceiptDetails = await BAReceiptDetails.GetReceiptByCustomer(((EnCustomer)selectedCustomer).Customer_Id);
            strNewHTMLFile.AppendLine(@"<html>");
            strNewHTMLFile.AppendLine(@"<body>");
            strNewHTMLFile.AppendLine(@"<table border='1' cellpadding = '1' cellspacing = '1' style = 'width:100%' > ");
            strNewHTMLFile.AppendLine(@"	<tbody>");
            strNewHTMLFile.AppendLine(@"		<tr>");
            strNewHTMLFile.AppendLine(@"			<td style='text-align:center'><strong>KARNAVATI APARTMENT - 6</strong></td>");
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
            strNewHTMLFile.AppendLine(@"						<td style='width:168px'>"+ selectedWingDetails.FlorName.ToUpper()+ "</td>");
            strNewHTMLFile.AppendLine(@"					</tr>");
            strNewHTMLFile.AppendLine(@"					<tr>");
            strNewHTMLFile.AppendLine(@"						<td style='width:108px;background-color:#E8E8E8;'><strong>LAND.:-</strong></td>");
            strNewHTMLFile.AppendLine(@"						<td style='width:89px'>" + selectedWingDetails.Land.ToString() + "</td>");
            strNewHTMLFile.AppendLine(@"						<td style='width:132px'>SQ.MTR</td>");
            strNewHTMLFile.AppendLine(@"						<td style='width:95px;background-color:#E8E8E8;'><strong>TOTAL.:-</strong></td>");
            strNewHTMLFile.AppendLine(@"						<td style='width:167px'>" + selectedWingDetails.Total.ToString() + "</td>");
            strNewHTMLFile.AppendLine(@"						<td style='width:168px'>SQ.MTR</td>");
            strNewHTMLFile.AppendLine(@"						<td style='width:225px;background-color:#E8E8E8;'><strong>AMT.:-</strong></td>");
            strNewHTMLFile.AppendLine(@"						<td style='width:168px'>" + selectedWingDetails.Amount.ToString() + "</td>");
            strNewHTMLFile.AppendLine(@"					</tr>");
            strNewHTMLFile.AppendLine(@"					<tr>");
            strNewHTMLFile.AppendLine(@"						<td style='width:108px;background-color:#E8E8E8;'><strong>CARPET.:-</strong></td>");
            strNewHTMLFile.AppendLine(@"						<td style='width:89px'>" + selectedWingDetails.Carpet.ToString() + "</td>");
            strNewHTMLFile.AppendLine(@"						<td style='width:132px'>SQ.MTR</td>");
            strNewHTMLFile.AppendLine(@"						<td style='width:95px;background-color:#E8E8E8;'><strong>W/B</strong></td>");
            strNewHTMLFile.AppendLine(@"						<td style='width:167px'>" + selectedWingDetails.WB.ToString() + "</td>");
            strNewHTMLFile.AppendLine(@"						<td style='width:168px'>SQ.MTR</td>");
            strNewHTMLFile.AppendLine(@"						<td style='width:225px;background-color:#E8E8E8;'><strong>RELIGION.:-</strong></td>");
            strNewHTMLFile.AppendLine(@"						<td style='width:168px'>HINDU</td>");
            strNewHTMLFile.AppendLine(@"					</tr>");
            strNewHTMLFile.AppendLine(@"				</tbody>");
            strNewHTMLFile.AppendLine(@"			</table>");
            strNewHTMLFile.AppendLine(@"");
            strNewHTMLFile.AppendLine(@"			<table border='1' cellpadding='1' cellspacing='1' style='width:100%'>");
            strNewHTMLFile.AppendLine(@"				<tbody>");
            if (!string.IsNullOrWhiteSpace(((EnCustomer)selectedCustomer).Customer1))
            {
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8;'><strong>NAME.:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td colspan='1' rowspan='2'>" + ((EnCustomer)selectedCustomer).Customer1 + "</td>");
                strNewHTMLFile.AppendLine(@"						<td ><strong>OCCUPATION.:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td>N/A</td>");
                strNewHTMLFile.AppendLine(@"					</tr>");
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td>&nbsp;</td>");
                strNewHTMLFile.AppendLine(@"						<td><strong>BANAKHAT. NO.:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td>N/A</td>");
                strNewHTMLFile.AppendLine(@"					</tr>");
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8;'><strong>PAN NO.:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td>" + ((EnCustomer)selectedCustomer).Pan1 + "</td>");
                strNewHTMLFile.AppendLine(@"						<td><strong>DATE:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td>&nbsp;</td>");
                strNewHTMLFile.AppendLine(@"					</tr>");
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8;'><strong>ADHAR NO.:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td colspan='3' rowspan = '1' > " + ((EnCustomer)selectedCustomer).Aadhar1 + " </ td > ");
                strNewHTMLFile.AppendLine(@"					</tr>");
            }
            if (!string.IsNullOrWhiteSpace(((EnCustomer)selectedCustomer).Customer2))
            {
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8;'><strong>NAME.:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td colspan='1' rowspan='2'>" + ((EnCustomer)selectedCustomer).Customer2 + "</td>");
                strNewHTMLFile.AppendLine(@"						<td><strong>OCCUPATION.:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td>N/A</td>");
                strNewHTMLFile.AppendLine(@"					</tr>");
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td>&nbsp;</td>");
                strNewHTMLFile.AppendLine(@"						<td><strong>BANAKHAT. NO.:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td>N/A</td>");
                strNewHTMLFile.AppendLine(@"					</tr>");
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8;'><strong>PAN NO.:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td>" + ((EnCustomer)selectedCustomer).Pan2 + "</td>");
                strNewHTMLFile.AppendLine(@"						<td><strong>DATE:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td>&nbsp;</td>");
                strNewHTMLFile.AppendLine(@"					</tr>");
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8;'><strong>ADHAR NO.:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td colspan='3' rowspan = '1' > " + ((EnCustomer)selectedCustomer).Aadhar2 + "</td>");
                strNewHTMLFile.AppendLine(@"					</tr>");
            }
            if (!string.IsNullOrWhiteSpace(((EnCustomer)selectedCustomer).Customer3))
            {
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8;'><strong>NAME.:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td colspan='1' rowspan='2'>" + ((EnCustomer)selectedCustomer).Customer3 + "</td>");
                strNewHTMLFile.AppendLine(@"						<td><strong>OCCUPATION.:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td>N/A</td>");
                strNewHTMLFile.AppendLine(@"					</tr>");
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td>&nbsp;</td>");
                strNewHTMLFile.AppendLine(@"						<td><strong>BANAKHAT. NO.:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td>N/A</td>");
                strNewHTMLFile.AppendLine(@"					</tr>");
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8;'><strong>PAN NO.:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td>" + ((EnCustomer)selectedCustomer).Pan3 + "</td>");
                strNewHTMLFile.AppendLine(@"						<td><strong>DATE:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td>&nbsp;</td>");
                strNewHTMLFile.AppendLine(@"					</tr>");
                strNewHTMLFile.AppendLine(@"					<tr>");
                strNewHTMLFile.AppendLine(@"						<td style='background-color:#E8E8E8;'><strong>ADHAR NO.:-</strong></td>");
                strNewHTMLFile.AppendLine(@"						<td colspan='3' rowspan = '1' > " + ((EnCustomer)selectedCustomer).Aadhar3 + "</ td > ");
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
                strNewHTMLFile.AppendLine(@"						<td style='text-align:center; width:144px'>" + receipt.PaymentDate.Replace("/", ".") + "</td>");
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
            strNewHTMLFile.AppendLine(@"						<td rowspan='4' style='width:1070px'>&nbsp;</td>");
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

        private async void btnprintprivew_Click(object sender, EventArgs e)
        {
            await CreateHTMLFile();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            wbHtmlView.ShowPrintDialog();
        }
    }
}
