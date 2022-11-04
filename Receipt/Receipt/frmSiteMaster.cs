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
    public partial class frmSiteMaster : Form
    {
        public frmSiteMaster()
        {
            InitializeComponent();
        }
        private bool Validation()
        {
            if(string.IsNullOrWhiteSpace(txtSiteName.Text))
            {
                txtSiteName.Focus();
                return false;
            }
            if(string.IsNullOrWhiteSpace(txtDBName.Text))
            {
                txtDBName.Focus();
                return false;
            }
            return true;
        }
        private void CreateNewDataBase()
        {
            System.IO.File.Copy(ClsUtil.getCurrentPath()+ "MasterCopy.db", ClsUtil.getCurrentPath()+ txtDBName.Text.Trim()+".db");
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if(!Validation())
            {
                return;
            }
            EnSiteMaster siteMaster = new EnSiteMaster();
            siteMaster.Site_Name=txtSiteName.Text;
            siteMaster.Site_Address = txtSiteAddress.Text;
            siteMaster.DB_Name = txtDBName.Text;
            siteMaster.Created_Date = DateTime.Now.ToString("dd/MM/yyyy");
            var SiteMasterId = await BASiteMaster.InsertUpdateSiteMaster(siteMaster);
            CreateNewDataBase();
            this.Close();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
