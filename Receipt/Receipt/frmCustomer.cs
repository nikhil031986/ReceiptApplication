using ReceiptBAccess;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ReceiptEntity;

namespace Receipt
{
    public partial class frmCustomer : Form
    {
        public event EventHandler CloseUserDetails;
        private DataTable dtCustomer;
        private EnCustomer customer;
        public frmCustomer()
        {
            InitializeComponent();
            FillWing(true);
            FillCustomerTable();
        }
        protected async Task FillWing(bool fillWingMaster = false, int wingMasterId = 0)
        {
            if (fillWingMaster)
            {
                var wingMaster = await BaWingMaster.GetWingMaster();
                cmbWingName.DataSource = null;
                cmbWingName.DisplayMember = "Wing_Name";
                cmbWingName.ValueMember = "Wing_Master_Id";
                cmbWingName.DataSource = wingMaster.OrderBy(x => x.Wing_Name).ToList();
                cmbWingName.SelectedIndex = 1;
                return;
            }
            var wingDetails = await BaWingMaster.GetWingDetails(wingMasterId);
            cmbFlatNo.DataSource = null;
            cmbFlatNo.DisplayMember = "FlatNo";
            cmbFlatNo.ValueMember = "Wing_DetailsId";
            cmbFlatNo.DataSource = wingDetails.OrderBy(x => x.Wing_DetailsId).ToList();
            cmbFlatNo.SelectedIndex = -1;

        }
        private async void GetCustomerDetails(int CustomerId = -0)
        {
            var customerDetails = await BACustomerMaster.GetCustomer(CustomerId);
            customerDetails.ForEach(customer =>
            {
                if (dtCustomer.AsEnumerable().Any(x => x.Field<int>("Customer_Id") == customer.Customer_Id))
                {
                    dtCustomer.AsEnumerable().Where<DataRow>(x => x.Field<int>("Customer_Id") == customer.Customer_Id).ToList().ForEach(dr =>
                    {
                        dr["Customer_Id"] = customer.Customer_Id;
                        dr["Wing_Master_Id"] = customer.Wing_Master_Id;
                        dr["Wing_Details_Id"] = customer.Wing_Details_Id;
                        dr["Wing_Name"] = customer.Wing_Name;
                        dr["FlatNo"] = customer.FlatNo;
                        dr["Customer_Name"] = customer.Customer_Name;
                        dr["Address"] = customer.Address;
                        dr["Con_Details"] = customer.Con_Details;
                        dr["Email_Id"] = customer.Email_Id;
                        dr["Customer_Wing_Name"] = customer.Customer_Wing_Name;
                    });
                    dtCustomer.AcceptChanges();
                }
                else
                {
                    DataRow drNew = dtCustomer.NewRow();
                    drNew["Customer_Id"] = customer.Customer_Id;
                    drNew["Wing_Master_Id"] = customer.Wing_Master_Id;
                    drNew["Wing_Details_Id"] = customer.Wing_Details_Id;
                    drNew["Wing_Name"] = customer.Wing_Name;
                    drNew["FlatNo"] = customer.FlatNo;
                    drNew["Customer_Name"] = customer.Customer_Name;
                    drNew["Address"] = customer.Address;
                    drNew["Con_Details"] = customer.Con_Details;
                    drNew["Email_Id"] = customer.Email_Id;
                    drNew["Customer_Wing_Name"] = customer.Customer_Wing_Name;
                    dtCustomer.Rows.Add(drNew);
                }
            });
        }
        private async void FillCustomerTable()
        {
            dtCustomer = new DataTable();
            await ClsUtil.AddColumn(dtCustomer, "Customer_Id", ClsUtil.ColumnType.dbLong, "0");
            await ClsUtil.AddColumn(dtCustomer, "Wing_Master_Id", ClsUtil.ColumnType.dbInt, "");
            await ClsUtil.AddColumn(dtCustomer, "Wing_Details_Id", ClsUtil.ColumnType.dbInt, "");
            await ClsUtil.AddColumn(dtCustomer, "Wing_Name", ClsUtil.ColumnType.dbString, "");
            await ClsUtil.AddColumn(dtCustomer, "FlatNo", ClsUtil.ColumnType.dbString, "");
            await ClsUtil.AddColumn(dtCustomer, "Customer_Name", ClsUtil.ColumnType.dbString, "");
            await ClsUtil.AddColumn(dtCustomer, "Address", ClsUtil.ColumnType.dbString, "");
            await ClsUtil.AddColumn(dtCustomer, "Con_Details", ClsUtil.ColumnType.dbString, "");
            await ClsUtil.AddColumn(dtCustomer, "Email_Id", ClsUtil.ColumnType.dbString, "");
            await ClsUtil.AddColumn(dtCustomer, "Customer_Wing_Name", ClsUtil.ColumnType.dbString, "");
            dgCustomer.DataSource = dtCustomer;
            GetCustomerDetails();
        }
        private async void cmbWingName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int wingMasterId = Convert.ToInt32(cmbWingName.SelectedValue);
            await FillWing(false, wingMasterId);
            CreateWingCustomerName();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (CloseUserDetails != null)
            {
                CloseUserDetails.Invoke(sender, e);
            }
            this.Close();
        }

        private void CreateWingCustomerName()
        {
            string wingCustomerName = string.Empty;
            if (!string.IsNullOrWhiteSpace(cmbWingName.Text))
            {
                wingCustomerName = cmbWingName.Text;
            }
            if (!string.IsNullOrWhiteSpace(cmbFlatNo.Text))
            {
                wingCustomerName = wingCustomerName + " - " + cmbFlatNo.Text;
            }
            if (!string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                wingCustomerName = wingCustomerName + " " + txtCustomerName.Text;
            }
            txtCustomerWingName.Text = wingCustomerName;

        }
        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            CreateWingCustomerName();
        }

        private void cmbFlatNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateWingCustomerName();
        }
        private static Regex email_validation()
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(pattern, RegexOptions.IgnoreCase);
        }
        private void txtEmailId_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEmailId.Text))
            {
                if (email_validation().IsMatch(txtEmailId.Text) != true)
                {
                    MessageBox.Show("Invalid Email Address!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
            }
        }
        private Task<bool> Validation()
        {

            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("Please Enter customer name!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return Task.FromResult(false);
            }

            if (string.IsNullOrWhiteSpace(cmbWingName.Text))
            {
                MessageBox.Show("Please Enter customer name!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return Task.FromResult(false);
            }

            if (string.IsNullOrWhiteSpace(cmbFlatNo.Text))
            {
                MessageBox.Show("Please Enter customer name!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return Task.FromResult(false);
            }

            if (!string.IsNullOrEmpty(txtEmailId.Text))
            {
                if (email_validation().IsMatch(txtEmailId.Text) != true)
                {
                    MessageBox.Show("Invalid Email Address!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return Task.FromResult(false);
                }
            }

            return Task.FromResult(true);
        }
        private void ClearControl()
        {
            txtCustomerName.Tag = null;
            txtCustomerName.Text = String.Empty;
            cmbWingName.SelectedIndex = 1;
            cmbFlatNo.SelectedIndex = -1;
            txtAddress.Text = String.Empty;
            txtContactNo.Text = String.Empty;
            txtCustomerWingName.Text = String.Empty;
            txtEmailId.Text = String.Empty;
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!Validation().Result)
            {
                return;
            }

            var customerId = string.IsNullOrWhiteSpace(Convert.ToString(txtCustomerName.Tag)) ? 0 : Convert.ToInt32(Convert.ToString(txtCustomerName.Tag));
            customer = new EnCustomer(customerId,
                Convert.ToInt32(cmbWingName.SelectedValue),
                Convert.ToInt32(cmbFlatNo.SelectedValue),
                Convert.ToString(cmbWingName.Text),
                Convert.ToString(cmbFlatNo.Text),
                txtCustomerName.Text,
                txtAddress.Text,
                txtContactNo.Text,
                txtEmailId.Text,
                txtCustomerWingName.Text);
            customerId = await BACustomerMaster.InsertUpdateCustomer(customer);

            GetCustomerDetails(Convert.ToInt32(customerId));

            ClearControl();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControl();
        }

        private async void dgCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ClearControl();
                int selectedCustomer = Convert.ToInt32(dgCustomer[0, e.RowIndex].Value);
                var customerResult = await BACustomerMaster.GetCustomer(selectedCustomer);
                if (customerResult != null)
                {
                    var selectedRow = customerResult.FirstOrDefault();
                    if (selectedRow != null)
                    {
                        txtCustomerName.Tag = selectedCustomer;
                        txtCustomerName.Text = selectedRow.Customer_Name;
                        cmbWingName.SelectedValue = selectedRow.Wing_Master_Id;
                        await FillWing(false,selectedRow.Wing_Master_Id);
                        cmbFlatNo.SelectedValue = selectedRow.Wing_Details_Id;
                        txtEmailId.Text = selectedRow.Email_Id;
                        txtAddress.Text = selectedRow.Address;
                        txtContactNo.Text = selectedRow.Con_Details;
                        txtCustomerWingName.Text = selectedRow.Customer_Wing_Name;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
