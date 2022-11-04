using ReceiptBAccess;
using ReceiptEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Receipt
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            FillSiteName();
            ReceiptLog.clsLog.InstanceCreation().filePath = ClsUtil.getCurrentPath();
            ReceiptLog.clsLog.InstanceCreation().CreateLogFile();
        }
        private async void FillSiteName()
        {
            var siteMasterData = await BASiteMaster.GetSiteMaster(0);
            cmbsiteName.DisplayMember = "Site_Name";
            cmbsiteName.ValueMember = "Site_Master_Id";
            cmbsiteName.DataSource=siteMasterData;
            cmbsiteName.SelectedIndex = -1;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text.Trim() == string.Empty)
            {
                error.SetError(txtUserID, "Enter User Name.");
                return;
            }
            if (txtPassword.Text.Trim() == string.Empty)
            {
                error.SetError(txtPassword, "Enter Password.");
                return;
            }
            if(string.IsNullOrWhiteSpace(cmbsiteName.Text))
            {
                error.SetError(cmbsiteName, "Select Site from the list.");
                return;
            }
            try
            {
                EnSiteMaster dbName =(EnSiteMaster)cmbsiteName.SelectedItem;
               
                ClsUtil.currentUserInfo = await BAUserDetails.GetUserDetails(txtUserID.Text.Trim(), txtPassword.Text.Trim());
                if (ClsUtil.currentUserInfo != null && ClsUtil.currentUserInfo.UserId > 0)
                {
                    ReceiptLog.clsLog.InstanceCreation().InsertLog("User Login User Name :"+txtUserID.Text, ReceiptLog.clsLog.logType.Info, "frmLogin.btnLogin");
                    BAUserDetails.SetDataBaseString(dbName.DB_Name);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("The userid or password is incorrect.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ReceiptLog.clsLog.InstanceCreation().InsertLog(ex.Message, ReceiptLog.clsLog.logType.Error, "frmLogin.btnLogin");
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUserID_TextChanged(object sender, EventArgs e)
        {
            error.SetError(txtUserID, "");
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            error.SetError(txtPassword, "");
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
            base.OnKeyDown(e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmbsiteName_SelectedIndexChanged(object sender, EventArgs e)
        {
            error.SetError(cmbsiteName, "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSiteMaster frmSite = new frmSiteMaster();
            frmSite.ShowDialog();
            FillSiteName();
        }
    }
}
