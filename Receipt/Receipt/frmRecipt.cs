﻿using Microsoft.Office.Interop.Excel;
using ReceiptLog;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;
using Image = System.Drawing.Image;

namespace Receipt
{
    public partial class frmRecipt : Form
    {
        private enum Form_Name
        {
            UserForm = 0,
            WingMaster = 1,
            CustomerDetails = 3,
            ReceiptDetails = 4,
            CheqDetails = 5,
            Report = 6,
            ImportData = 7,
            Banakhat = 8,
            BanakhatList = 9,
            dashboard=10
        }
        private Form myForm;
        private Form_Name FormName;
        public frmRecipt()
        {
            try
            {
                InitializeComponent();
                btnUserDetails.Visible = false;
                SetImageInToButton();
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
        private void openDashbord()
        {
            try
            {
                if (myForm != null)
                {
                    myForm.Close();
                    MyForm_CloseUserDetails(null, null);
                }
                FormName = Form_Name.dashboard;
                myForm = new frmdashboard();
                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                myForm.Dock = DockStyle.Fill;
                this.PlnMainForm.Controls.Add(myForm);
                myForm.Show();
                btnHome.Text = btnHome.Text.Replace("<", ">");
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
        private void SetImageInToButton()
        {
            try
            {

                this.btnUserDetails.Image = (Image)(new Bitmap(Receipt.Properties.Resources.userimage, new Size(35, 35)));
                this.btnWingDetails.Image = (Image)(new Bitmap(Receipt.Properties.Resources.wingDetails, new Size(95, 40)));
                this.btnWingDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.btnCustomer.Image = (Image)(new Bitmap(Receipt.Properties.Resources.CustomerDetails, new Size(80, 40)));
                this.btnCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.btnReceiptDetails.Image = (Image)(new Bitmap(Receipt.Properties.Resources.Banakhat, new Size(80, 40)));
                this.btnReceiptDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.btnBanakhat.Image = (Image)(new Bitmap(Receipt.Properties.Resources.Banakhat, new Size(80, 40)));
                this.btnBanakhat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.btnChqDetails.Image = (Image)(new Bitmap(Receipt.Properties.Resources.CheckDetails, new Size(80, 40)));
                this.btnChqDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.btnImport.Image = (Image)(new Bitmap(Receipt.Properties.Resources.ImportData, new Size(80, 40)));
                this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.btnReport.Image = (Image)(new Bitmap(Receipt.Properties.Resources.Report, new Size(80, 40)));
                this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.btnLogout.Image = (Image)(new Bitmap(Receipt.Properties.Resources.logout, new Size(80, 40)));
                this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
        private void btnUserDetails_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private void MyForm_CloseUserDetails(object sender, EventArgs e)
        {
            try
            {
                switch (FormName)
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
                        btnReport.Text = btnReport.Text.Replace(">", "<");
                        myForm = null;
                        GC.Collect();
                        break;
                    case Form_Name.ImportData:
                        ((frmImportData)myForm).CloseUserDetails -= MyForm_CloseUserDetails;
                        btnImport.Text = btnImport.Text.Replace(">", "<");
                        myForm = null;
                        GC.Collect();
                        break;
                    case Form_Name.Banakhat:
                        ((frmBanakhat)myForm).CloseUserDetails -= MyForm_CloseUserDetails;
                        btnBanakhat.Text = btnBanakhat.Text.Replace(">", "<");
                        myForm = null;
                        GC.Collect();
                        break;
                    case Form_Name.BanakhatList:
                        btnBanakhatList.Text = btnBanakhat.Text.Replace(">", "<");
                        myForm = null;
                        GC.Collect();
                        break;
                    case Form_Name.dashboard:
                        btnHome.Text = btnHome.Text.Replace(">", "<");
                        myForm = null;
                        GC.Collect();
                        break;
                }
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private void btnReceiptDetails_Click(object sender, EventArgs e)
        {
            try
            {

                if (myForm != null)
                {
                    myForm.Close();
                    MyForm_CloseUserDetails(null, null);
                    GC.Collect();
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
                this.PlnMainForm.Refresh();
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
        private void btnChqDetails_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                Process installer = new Process();
                installer.StartInfo.FileName = Application.ExecutablePath;
                installer.Start();
                Application.Exit();
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private void btnBanakhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (myForm != null)
                {
                    myForm.Close();
                    MyForm_CloseUserDetails(null, null);
                }
                FormName = Form_Name.Banakhat;
                btnBanakhat.Text = btnBanakhat.Text.Replace("<", ">");
                myForm = new frmBanakhat();
                ((frmBanakhat)myForm).CloseUserDetails += MyForm_CloseUserDetails;
                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                myForm.Dock = DockStyle.Fill;
                this.PlnMainForm.Controls.Add(myForm);
                myForm.Show();
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private void btnBanakhatList_Click(object sender, EventArgs e)
        {
            try
            {
                if (myForm != null)
                {
                    myForm.Close();
                    MyForm_CloseUserDetails(null, null);
                }
                FormName = Form_Name.BanakhatList;
                btnBanakhatList.Text = btnBanakhatList.Text.Replace("<", ">");
                myForm = new frmBanakhatList();
                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                myForm.Dock = DockStyle.Fill;
                this.PlnMainForm.Controls.Add(myForm);
                myForm.Show();
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private void btnBackUpDataBase_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.ShowDialog();
                clsWaitForm.ShowWaitForm();
                if (folderBrowserDialog.SelectedPath != null && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    System.IO.File.Copy(ClsUtil.getCurrentPath() + ClsUtil.SiteDBName + ".db", folderBrowserDialog.SelectedPath + @"\" + ClsUtil.SiteDBName + ".db", true);
                    clsWaitForm.CloseWaitForm();
                    MessageBox.Show("DataBase Backuped..", "Receipt Application",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                clsWaitForm.CloseWaitForm();
            }
            catch (Exception ex)
            {
                clsWaitForm.CloseWaitForm();
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, "btnBackUpDataBase_Click");
            }
        }

        private void frmRecipt_Load(object sender, EventArgs e)
        {
            openDashbord();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            openDashbord();
        }

        private void frmRecipt_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsWaitForm.ShowWaitForm();
            try
            {
                string filePath = "D:\\ReceiptDataBaseBackUp";
                if(!System.IO.Directory.Exists(filePath)) 
                {
                    System.IO.Directory.CreateDirectory(filePath);
                }
                System.IO.DirectoryInfo di = new DirectoryInfo(filePath);
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                System.IO.File.Copy(ClsUtil.getCurrentPath() + ClsUtil.SiteDBName + ".db", filePath + @"\" + ClsUtil.SiteDBName + ".db");
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                clsWaitForm.CloseWaitForm();
            }
        }
    }
}