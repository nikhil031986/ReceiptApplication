﻿using ReceiptBAccess;
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
    public partial class frmCheqDetailsList : Form
    {
        private DataTable dtCheqDetails;
        public event EventHandler CloseUserDetails;
        int LastRecordNumber = 0;
        int CurrentPage = 1;
        public frmCheqDetailsList()
        {
            try
            {
                InitializeComponent();
                FillTableRecords();
                FillGridReceiptList(0);
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, "frmCheqDetailsList"); }
        }
        private async Task FillGridReceiptList(int CheqDetailsId)
        {
            try
            {
                var cheqDetails = await BACheqDetails.GetCheqDetails(CheqDetailsId);
                cheqDetails.ForEach(cheqDetail =>
                {
                    if (dtCheqDetails.AsEnumerable().Any(x => x.Field<int>("Cheq_Details_Id") == cheqDetail.Cheq_Details_Id))
                    {
                        dtCheqDetails.AsEnumerable().Where<DataRow>(x => x.Field<int>("Cheq_Details_Id") == cheqDetail.Cheq_Details_Id).ToList().ForEach(dr =>
                        {
                            dr["Cheq_Details_Id"] = cheqDetail.Cheq_Details_Id;
                            dr["Customer_Name"] = cheqDetail.Customer_Name;
                            dr["Cheq_Date"] = cheqDetail.Cheq_Date;
                            dr["Amount"] = cheqDetail.Amount;
                            dr["Amount_InWord"] = cheqDetail.Amount_InWord;
                            dr["Bank_Name"] = cheqDetail.Bank_Name;
                            dr["Cheq_No"] = cheqDetail.Cheq_No;
                        });
                        dtCheqDetails.AcceptChanges();
                    }
                    else
                    {
                        DataRow drNew = dtCheqDetails.NewRow();
                        drNew["Cheq_Details_Id"] = cheqDetail.Cheq_Details_Id;
                        drNew["Customer_Name"] = cheqDetail.Customer_Name;
                        drNew["Cheq_Date"] = cheqDetail.Cheq_Date;
                        drNew["Amount"] = cheqDetail.Amount;
                        drNew["Amount_InWord"] = cheqDetail.Amount_InWord;
                        drNew["Bank_Name"] = cheqDetail.Bank_Name;
                        drNew["Cheq_No"] = cheqDetail.Cheq_No;
                        dtCheqDetails.Rows.Add(drNew);
                    }
                });

            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
            }

        }
        private async Task FillTableRecords()
        {
            try
            {
                dtCheqDetails = new DataTable();
                List<clsColumn> clsColumns = new List<clsColumn>();
                clsColumns.Add(new clsColumn("Cheq_Details_Id", ClsUtil.ColumnType.dbLong, "0"));
                clsColumns.Add(new clsColumn("Customer_Name", ClsUtil.ColumnType.dbString, ""));
                clsColumns.Add(new clsColumn("Cheq_Date", ClsUtil.ColumnType.dbString, ""));
                clsColumns.Add(new clsColumn("Amount", ClsUtil.ColumnType.dbDecimal, "0"));
                clsColumns.Add(new clsColumn("Amount_InWord", ClsUtil.ColumnType.dbString, ""));
                clsColumns.Add(new clsColumn("Bank_Name", ClsUtil.ColumnType.dbString, ""));
                clsColumns.Add(new clsColumn("Cheq_No", ClsUtil.ColumnType.dbString, ""));
                await ClsUtil.AddColumn(dtCheqDetails, clsColumns);
                dgvReceiptList.DataSource = dtCheqDetails;
                dtCheqDetails.TableName = "CheqDetails";
                cmbColumnName.Items.Clear();
                foreach (DataColumn column in dtCheqDetails.Columns)
                {
                    if (!column.ColumnName.ToLower().Contains("id"))
                        cmbColumnName.Items.Add(column.ColumnName);
                }
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            await OpenReceiptEntryForm(0);
        }
        private async Task OpenReceiptEntryForm(int cheqDtlId = 0)
        {
            try
            {
                frmCheqDetail _frmCheqDetail;
                if (cheqDtlId == 0)
                {
                    _frmCheqDetail = new frmCheqDetail();
                }
                else
                {
                    _frmCheqDetail = new frmCheqDetail(cheqDtlId);
                }
                _frmCheqDetail.ShowDialog();
                if (_frmCheqDetail.cheqDetailsId > 0)
                    await FillGridReceiptList(_frmCheqDetail.cheqDetailsId);
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, "OpenReceiptEntryForm"); }
        }
        private async void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var cheqId = dgvReceiptList.SelectedRows[0].Cells[0].Value;
                await OpenReceiptEntryForm(Convert.ToInt32(cheqId));
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, "btnEdit_Click"); }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    dtCheqDetails.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", cmbColumnName.Text, txtSearch.Text);
                }
                else
                {
                    dtCheqDetails.DefaultView.RowFilter = String.Empty;
                }
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, "txtSearch_TextChanged"); }
        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ClsUtil.ExportDataToExcel(dgvReceiptList);
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
    }
}
