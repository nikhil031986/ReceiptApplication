﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Receipt
{
    public partial class frmRecipt : Form
    {
        private enum Form_Name
        {
            UserForm = 0,
            WingMaster = 1,
            CustomerDetails = 3,
            ReceiptDetails=4,
            CheqDetails=5,
            Report=6,
            ImportData=7
        }
        private Form myForm;
        private Form_Name FormName ;
        public frmRecipt()
        {
            InitializeComponent();
            btnUserDetails.Visible= false;
        }

        private void btnUserDetails_Click(object sender, EventArgs e)
        {
            if (myForm != null)
            {
                myForm.Close();
                MyForm_CloseUserDetails(null, null);
            }
            FormName = Form_Name.UserForm;
            btnUserDetails.Text = btnUserDetails.Text.Replace("<", ">");
            myForm = new frmUser();
            ((frmUser)myForm).CloseUserDetails += MyForm_CloseUserDetails;
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            myForm.Dock = DockStyle.Fill;
            this.PlnMainForm.Controls.Add(myForm);
            myForm.Show();
        }

        private void MyForm_CloseUserDetails(object sender, EventArgs e)
        {
            switch(FormName)
            {
                case Form_Name.UserForm:
                    ((frmUser)myForm).CloseUserDetails -= MyForm_CloseUserDetails;
                    btnUserDetails.Text = btnUserDetails.Text.Replace(">", "<");
                    myForm = null;
                    GC.Collect();
                    break;
                case Form_Name.WingMaster:
                    ((Wing_Master)myForm).CloseUserDetails -= MyForm_CloseUserDetails;
                    btnWingDetails.Text = btnWingDetails.Text.Replace(">", "<");
                    myForm = null;
                    GC.Collect();
                    break;
                case Form_Name.CustomerDetails:
                    ((frmCustomer)myForm).CloseUserDetails -= MyForm_CloseUserDetails;
                    btnCustomer.Text = btnCustomer.Text.Replace(">", "<");
                    myForm = null;
                    GC.Collect();
                    break;
                case Form_Name.ReceiptDetails:
                    ((frmReceiptList)myForm).CloseUserDetails -= MyForm_CloseUserDetails;
                    btnReceiptDetails.Text = btnReceiptDetails.Text.Replace(">", "<");
                    myForm = null;
                    GC.Collect();
                    break;
                case Form_Name.CheqDetails:
                    ((frmCheqDetailsList)myForm).CloseUserDetails -= MyForm_CloseUserDetails;
                    btnChqDetails.Text = btnChqDetails.Text.Replace(">", "<");
                    myForm = null;
                    GC.Collect();
                    break;
                case Form_Name.Report:
                    ((frmReport)myForm).CloseUserDetails -= MyForm_CloseUserDetails;
                    btnReport.Text=btnReport.Text.Replace(">", "<");
                    myForm = null;
                    GC.Collect();
                    break;
                case Form_Name.ImportData:
                    ((frmImportData)myForm).CloseUserDetails -= MyForm_CloseUserDetails;
                    btnImport.Text = btnImport.Text.Replace(">", "<");
                    myForm = null;
                    GC.Collect();
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (myForm != null)
            {
                myForm.Close();
                MyForm_CloseUserDetails(null, null);
            }
            FormName = Form_Name.WingMaster;
            btnWingDetails.Text = btnWingDetails.Text.Replace("<", ">");
            myForm = new Wing_Master();
            ((Wing_Master)myForm).CloseUserDetails += MyForm_CloseUserDetails;
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            myForm.Dock = DockStyle.Fill;
            this.PlnMainForm.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            if (myForm != null)
            {
                myForm.Close();
                MyForm_CloseUserDetails(null, null);
            }
            FormName = Form_Name.CustomerDetails;
            btnCustomer.Text = btnCustomer.Text.Replace("<", ">");
            myForm = new frmCustomer();
            ((frmCustomer)myForm).CloseUserDetails += MyForm_CloseUserDetails;
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            myForm.Dock = DockStyle.Fill;
            this.PlnMainForm.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnReceiptDetails_Click(object sender, EventArgs e)
        {
            if (myForm != null)
            {
                myForm.Close();
                MyForm_CloseUserDetails(null, null);
            }
            FormName = Form_Name.ReceiptDetails;
            btnReceiptDetails.Text = btnReceiptDetails.Text.Replace("<", ">");
            myForm = new frmReceiptList();
            ((frmReceiptList)myForm).CloseUserDetails += MyForm_CloseUserDetails;
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            myForm.Dock = DockStyle.Fill;
            this.PlnMainForm.Controls.Add(myForm);
            myForm.Show();
        }
        private void btnChqDetails_Click(object sender, EventArgs e)
        {
            if (myForm != null)
            {
                myForm.Close();
                MyForm_CloseUserDetails(null, null);
            }
            FormName = Form_Name.CheqDetails;
            btnChqDetails.Text = btnChqDetails.Text.Replace("<", ">");
            myForm = new frmCheqDetailsList();
            ((frmCheqDetailsList)myForm).CloseUserDetails += MyForm_CloseUserDetails;
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            myForm.Dock = DockStyle.Fill;
            this.PlnMainForm.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (myForm != null)
            {
                myForm.Close();
                MyForm_CloseUserDetails(null, null);
            }
            FormName = Form_Name.Report;
            btnReport.Text = btnReport.Text.Replace("<", ">");
            myForm = new frmReport();
            ((frmReport)myForm).CloseUserDetails += MyForm_CloseUserDetails;
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            myForm.Dock = DockStyle.Fill;
            this.PlnMainForm.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Process installer = new Process();
            installer.StartInfo.FileName = Application.ExecutablePath;
            installer.Start();
            Application.Exit();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (myForm != null)
            {
                myForm.Close();
                MyForm_CloseUserDetails(null, null);
            }
            FormName = Form_Name.ImportData;
            btnImport.Text = btnImport.Text.Replace("<", ">");
            myForm = new frmImportData();
            ((frmImportData)myForm).CloseUserDetails += MyForm_CloseUserDetails;
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            myForm.Dock = DockStyle.Fill;
            this.PlnMainForm.Controls.Add(myForm);
            myForm.Show();
        }
    }
}