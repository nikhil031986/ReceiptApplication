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
using ReceiptLog;
using System.Reflection;

namespace Receipt
{
    public partial class frmCustomer : Form
    {
        public event EventHandler CloseUserDetails;
        private DataTable dtCustomer;
        private EnCustomer customer;
        public frmCustomer()
        {
            try
            {
                InitializeComponent();
                FillWing(true);
                FillCustomerTable();
                this.btnClose.Image = (Image)(new Bitmap(Receipt.Properties.Resources.Close, new Size(32, 25)));
                this.btnClose.ImageAlign = ContentAlignment.MiddleCenter;
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
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
        private async void GetCustomerDetails(int CustomerId = -0)
        {
            try
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
                            dr["Pan"] = customer.Pan;
                            dr["Aadhar"] = customer.Aadhar;
                            dr["Customer1"] = customer.Customer1;
                            dr["Pan1"] = customer.Pan1;
                            dr["Aadhar1"] = customer.Aadhar1;
                            dr["Customer2"] = customer.Customer2;
                            dr["Pan2"] = customer.Pan2;
                            dr["Aadhar2"] = customer.Aadhar2;
                            dr["Customer3"] = customer.Customer3;
                            dr["Pan3"] = customer.Pan3;
                            dr["Aadhar3"] = customer.Aadhar3;
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
                        drNew["Pan"] = customer.Pan;
                        drNew["Aadhar"] = customer.Aadhar;
                        drNew["Customer1"] = customer.Customer1;
                        drNew["Pan1"] = customer.Pan1;
                        drNew["Aadhar1"] = customer.Aadhar1;
                        drNew["Customer2"] = customer.Customer2;
                        drNew["Pan2"] = customer.Pan2;
                        drNew["Aadhar2"] = customer.Aadhar2;
                        drNew["Customer3"] = customer.Customer3;
                        drNew["Pan3"] = customer.Pan3;
                        drNew["Aadhar3"] = customer.Aadhar3;
                        dtCustomer.Rows.Add(drNew);
                    }
                });

                dgCustomer.Invoke(new MethodInvoker(() => dgCustomer.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing));

                // or even better, use .DisableResizing. Most time consuming enum is DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders

                // set it to false if not needed
                dgCustomer.Invoke(new MethodInvoker(() => dgCustomer.RowHeadersVisible = true));
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
        private async void FillCustomerTable()
        {
            try
            {
                dgCustomer.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                // or even better, use .DisableResizing. Most time consuming enum is DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders

                // set it to false if not needed
                dgCustomer.RowHeadersVisible = false;
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
                await ClsUtil.AddColumn(dtCustomer, "Pan", ClsUtil.ColumnType.dbString, "0");
                await ClsUtil.AddColumn(dtCustomer, "Aadhar", ClsUtil.ColumnType.dbString, "0");
                await ClsUtil.AddColumn(dtCustomer, "Customer1", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtCustomer, "Pan1", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtCustomer, "Aadhar1", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtCustomer, "Customer2", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtCustomer, "Pan2", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtCustomer, "Aadhar2", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtCustomer, "Customer3", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtCustomer, "Pan3", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtCustomer, "Aadhar3", ClsUtil.ColumnType.dbString, "");


                dgCustomer.DataSource = dtCustomer;
                new System.Threading.Thread(()=> GetCustomerDetails()).Start();
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
        private async void cmbWingName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int wingMasterId = Convert.ToInt32(cmbWingName.SelectedValue);
                await FillWing(false, wingMasterId);
                CreateWingCustomerName();
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (CloseUserDetails != null)
                {
                    CloseUserDetails.Invoke(sender, e);
                }
                this.Close();
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private void CreateWingCustomerName()
        {
            try
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
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CreateWingCustomerName();
                txtCustomer1.Text = txtCustomerName.Text;
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
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
            try
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
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
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
            txtPan.Text = String.Empty;
            txtAadhar.Text = String.Empty;
            txtCustomer1.Text = String.Empty;
            txtPan1.Text = String.Empty;
            txtAadhar1.Text = String.Empty;
            txtCustomer2.Text = String.Empty;
            txtPan2.Text = String.Empty;
            txtAadhar2.Text = String.Empty;
            txtCustomer3.Text = String.Empty;
            txtPan3.Text = String.Empty;
            txtAadhar3.Text = String.Empty;
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
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
                    txtCustomerWingName.Text,
                    txtPan.Text,
                    txtAadhar.Text,
                    txtCustomer1.Text,
                    txtPan1.Text,
                    txtAadhar1.Text,
                    txtCustomer2.Text,
                    txtPan2.Text,
                    txtAadhar2.Text,
                    txtCustomer3.Text,
                    txtPan3.Text,
                    txtAadhar3.Text);
                customerId = await BACustomerMaster.InsertUpdateCustomer(customer);

                GetCustomerDetails(Convert.ToInt32(customerId));

                ClearControl();
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
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
                        await FillWing(false, selectedRow.Wing_Master_Id);
                        cmbFlatNo.SelectedValue = selectedRow.Wing_Details_Id;
                        txtEmailId.Text = selectedRow.Email_Id;
                        txtAddress.Text = selectedRow.Address;
                        txtContactNo.Text = selectedRow.Con_Details;
                        txtCustomerWingName.Text = selectedRow.Customer_Wing_Name;
                        txtPan.Text = selectedRow.Pan;
                        txtAadhar.Text = selectedRow.Aadhar;
                        txtCustomer1.Text = selectedRow.Customer1;
                        txtPan1.Text = selectedRow.Pan1;
                        txtAadhar1.Text = selectedRow.Aadhar1;
                        txtCustomer2.Text = selectedRow.Customer2;
                        txtPan2.Text = selectedRow.Pan2;
                        txtAadhar2.Text = selectedRow.Aadhar2;
                        txtCustomer3.Text = selectedRow.Customer3;
                        txtPan3.Text = selectedRow.Pan3;
                        txtAadhar3.Text = selectedRow.Aadhar3;
                    }
                }
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

    }
}
