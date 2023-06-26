using ReceiptBAccess;
using ReceiptEntity;
using ReceiptLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Receipt
{
    public partial class frmCustomerEntry : Form
    {
        private int customerId = 0;
        public int CustomerId { get { return this.customerId; } set { this.customerId = value; } }
        public frmCustomerEntry()
        {
            InitializeComponent();
            FillWing(true);
            FillCoupations();
            this.customerId = 0;
        }

        public frmCustomerEntry(int _customerId)
        {
            InitializeComponent();
            FillWing(true);
            FillCoupations();
            this.customerId = _customerId;
            getCustomerDetails();
        }
        private async void FillCoupations()
        {
            txtOcupation.Items.Clear();
            txtCoApOneOcupation.Items.Clear();
            txtCoAppTwoOcupation.Items.Clear();
            txtCoAppThreeOcupation.Items.Clear();
            var listOcupation = await BACustomerMaster.GetOcupations();
            listOcupation.ForEach(x =>
            {
                txtOcupation.Items.Add(x);
                txtCoApOneOcupation.Items.Add(x);
                txtCoAppTwoOcupation.Items.Add(x);
                txtCoAppThreeOcupation.Items.Add(x);
            });
        }
        private Task<bool> Validation()
        {

            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("Please Enter customer name!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return Task.FromResult(false);
            }

            if (string.IsNullOrWhiteSpace(cboWing.Text) && Convert.ToInt32(cboWing.SelectedValue)==0)
            {
                MessageBox.Show("Please Enter customer name!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return Task.FromResult(false);
            }

            if (string.IsNullOrWhiteSpace(cboFlatNo.Text) && Convert.ToInt32(cboFlatNo.SelectedValue)==0)
            {
                MessageBox.Show("Please Enter customer name!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }
        private void CreateWingCustomerName()
        {
            try
            {
                string wingCustomerName = string.Empty;
                if (!string.IsNullOrWhiteSpace(cboWing.Text))
                {
                    wingCustomerName = cboWing.Text;
                }
                if (!string.IsNullOrWhiteSpace(cboFlatNo.Text))
                {
                    wingCustomerName = wingCustomerName + " - " + cboFlatNo.Text;
                }
                if (!string.IsNullOrWhiteSpace(txtCustomerName.Text))
                {
                    wingCustomerName = wingCustomerName + " " + txtCustomerName.Text;
                }
                txtCustomerWingName.Text = wingCustomerName;

            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        protected async Task FillWing(bool fillWingMaster = false, int wingMasterId = 0)
        {
            try
            {
                if (fillWingMaster)
                {
                    var wingMaster = await BaWingMaster.GetWingMaster();
                    cboWing.DataSource = null;
                    cboWing.DisplayMember = "Wing_Name";
                    cboWing.ValueMember = "Wing_Master_Id";
                    cboWing.DataSource = wingMaster.OrderBy(x => x.Wing_Name).ToList();
                    cboWing.SelectedIndex = 1;
                    return;
                }
                var wingDetails = await BaWingMaster.GetWingDetails(wingMasterId);
                cboFlatNo.DataSource = null;
                cboFlatNo.DisplayMember = "FlatNo";
                cboFlatNo.ValueMember = "Wing_DetailsId";
                cboFlatNo.DataSource = wingDetails.OrderBy(x => x.Wing_DetailsId).ToList();
                cboFlatNo.SelectedIndex = -1;

            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
        private async void getCustomerDetails()
        {
            try
            {
                var customerDetails = await BACustomerMaster.GetCustomer(this.customerId);
                if(customerDetails != null)
                {
                    var selectedCustomer = customerDetails.FirstOrDefault();
                    txtCustomerName.Text = selectedCustomer.Customer_Name;
                    cboWing.SelectedValue = selectedCustomer.Wing_Master_Id;
                    await FillWing(false, selectedCustomer.Wing_Master_Id);
                    cboFlatNo.SelectedValue = selectedCustomer.Wing_Details_Id;
                    txtMobileNo.Text = selectedCustomer.Con_Details;
                    txtPanNo.Text = selectedCustomer.Pan;
                    txtAadharNo.Text = selectedCustomer.Aadhar;
                    txtCoApOneName.Text = selectedCustomer.Customer1;
                    txtCoApPanNo.Text = selectedCustomer.Pan1;
                    txtCoAppAadharNo.Text = selectedCustomer.Aadhar1;
                    txtCoAppTwoName.Text = selectedCustomer.Customer2;
                    txtCoAppTwoPanNo.Text = selectedCustomer.Pan2;
                    txtCoAppTwoAadharNo.Text= selectedCustomer.Aadhar2;
                    txtCoAppThreeName.Text = selectedCustomer.Customer3;
                    txtCoAppThreePanNo.Text = selectedCustomer.Pan3;
                    txtCoAppTwoAadharNo.Text=selectedCustomer.Aadhar3;
                    txtAddress.Text = selectedCustomer.Address;
                    txtBankhatNo.Text = selectedCustomer.BanakhatNo;
                    if (!string.IsNullOrWhiteSpace(selectedCustomer.BanakhatDate))
                    {
                        string dateFormate = selectedCustomer.BanakhatDate.Split('/')[2] + "/" + selectedCustomer.BanakhatDate.Split('/')[1] + "/" + selectedCustomer.BanakhatDate.Split('/')[0];
                        dtpBankhatDate.Value = Convert.ToDateTime(dateFormate);
                    }
                    txtOcupation.Text = selectedCustomer.Ocupation;
                    txtCoApOneOcupation.Text = selectedCustomer.Ocupation1;
                    txtCoAppTwoOcupation.Text = selectedCustomer.Ocupation2;
                    txtCoAppThreeOcupation.Text = selectedCustomer.Ocupation3;
                    txtFinancial_Name.Text = selectedCustomer.Financial_Name;
                    txtDastavgNo.Text = selectedCustomer.Dastavg_No;
                    if (!string.IsNullOrWhiteSpace(selectedCustomer.Dastavg_Date))
                    {
                        string dateFormate = selectedCustomer.Dastavg_Date.Split('/')[2] + "/" + selectedCustomer.Dastavg_Date.Split('/')[1] + "/" + selectedCustomer.Dastavg_Date.Split('/')[0];
                        dtpDastavgDate.Value = Convert.ToDateTime(dateFormate);
                    }
                }
                else
                {
                    this.customerId = 0;
                }
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, "frmCustomerEntry");
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validation().Result)
                {
                    return;
                }
                if (customerId == 0)
                {
                    var CustomerCheck = await BACustomerMaster.CheckAnyCustomerExists(Convert.ToInt32(cboWing.SelectedValue),
            Convert.ToInt32(cboFlatNo.SelectedValue));
                    if (CustomerCheck != null && CustomerCheck == 0)
                    {
                        MessageBox.Show("Wing and flat/Shop already assign to another customer.\n\n\t Please select another wing and flat/shop.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                clsWaitForm.ShowWaitForm();
                var customer = new EnCustomer(customerId,
                    Convert.ToInt32(cboWing.SelectedValue),
                    Convert.ToInt32(cboFlatNo.SelectedValue),
                    Convert.ToString(cboWing.Text),
                    Convert.ToString(cboFlatNo.Text),
                    txtCustomerName.Text,
                    txtAddress.Text,
                    txtMobileNo.Text,
                    "",
                    txtCustomerWingName.Text,
                    txtPanNo.Text,
                    txtAadharNo.Text,
                    txtCoApOneName.Text,
                    txtCoApPanNo.Text,
                    txtCoAppAadharNo.Text,
                    txtCoAppTwoName.Text,
                    txtCoAppTwoPanNo.Text,
                    txtCoAppTwoAadharNo.Text,
                    txtCoAppThreeName.Text,
                    txtCoAppThreePanNo.Text,
                    txtCoAppThreeAadharNo.Text, txtBankhatNo.Text, dtpBankhatDate.Value.ToString("dd/MM/yyyy"),txtOcupation.Text,txtCoApOneOcupation.Text,
                    txtCoAppTwoOcupation.Text,txtCoAppThreeOcupation.Text,txtFinancial_Name.Text,
                    txtDastavgNo.Text, dtpDastavgDate.Value.ToString("dd/MM/yyyy"));
                int isBanakhat=0;
                if(!string.IsNullOrWhiteSpace(txtBankhatNo.Text) )
                {
                    isBanakhat = 1;
                }
                customerId = await BACustomerMaster.InsertUpdateCustomer(customer, isBanakhat);
                clsWaitForm.CloseWaitForm();
                this.Close();
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private async void cboWing_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int wingMasterId = Convert.ToInt32(cboWing.SelectedValue);
                await FillWing(false, wingMasterId);
                CreateWingCustomerName();
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private void cboFlatNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateWingCustomerName();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            CreateWingCustomerName();
        }
    }
}
