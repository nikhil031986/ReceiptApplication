using ReceiptBAccess;
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
    public partial class frmCheqDetailsList : Form
    {
        private DataTable dtCheqDetails;
        public event EventHandler CloseUserDetails;
        public frmCheqDetailsList()
        {
            InitializeComponent();
            FillTableRecords();
            FillGridReceiptList(0);
        }
        private async Task FillGridReceiptList(int CheqDetailsId = 0)
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

                throw ex;
            }

        }
        private async Task FillTableRecords()
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
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            await OpenReceiptEntryForm(0);
        }
        private async Task OpenReceiptEntryForm(int cheqDtlId = 0)
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
        private async void btnEdit_Click(object sender, EventArgs e)
        {
            var cheqId = dgvReceiptList.SelectedRows[0].Cells[0].Value;
            await OpenReceiptEntryForm(Convert.ToInt32(cheqId));
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
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

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsUtil.ExportDataToExcel(dgvReceiptList);
        }
    }
}
