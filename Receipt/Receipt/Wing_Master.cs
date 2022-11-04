using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReceiptBAccess;
using ReceiptEntity;

namespace Receipt
{
    public partial class Wing_Master : Form
    {
        private DataTable dtWingDetails;
        private DataTable dtWingMaster;
        public event EventHandler CloseUserDetails;
        public Wing_Master()
        {
            InitializeComponent();
            AddContrial();
        }
        private async Task FillGridWingMaster(int wingMasterId = 0)
        {
            try
            {
                List<EnWingMaster> wingMaster = new List<EnWingMaster>();
                if (wingMasterId == 0)
                {
                    wingMaster = await ReceiptBAccess.BaWingMaster.GetWingMaster(0);
                }
                else
                {
                    wingMaster = await ReceiptBAccess.BaWingMaster.GetWingMaster(wingMasterId);
                }
                wingMaster.ForEach(wing =>
                {
                    if (dtWingMaster.AsEnumerable().Any(x => x.Field<int>("Wing_Master_Id") == wing.Wing_Master_Id))
                    {
                        dtWingMaster.AsEnumerable().Where<DataRow>(x => x.Field<int>("Wing_Master_Id") == wing.Wing_Master_Id).ToList().ForEach(dr =>
                        {
                            dr["Wing_Names"] = wing.Wing_Name;
                            dr["Floar_Count"] = wing.Floar_Count;
                            dr["House_Count"] = wing.Hous_Count;
                            dr["Start_Number"] = wing.Start_Number;
                            dr["End_Number"] = wing.End_Number;
                        });
                        dtWingDetails.AcceptChanges();
                    }
                    else
                    {
                        DataRow drNew = dtWingMaster.NewRow();
                        drNew["Wing_Master_Id"] = wing.Wing_Master_Id;
                        drNew["Wing_Names"] = wing.Wing_Name;
                        drNew["Floar_Count"] = wing.Floar_Count;
                        drNew["House_Count"] = wing.Hous_Count;
                        drNew["Start_Number"] = wing.Start_Number;
                        drNew["End_Number"] = wing.End_Number;
                        dtWingMaster.Rows.Add(drNew);
                    }
                });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private async Task AddContrial()
        {
            dtWingDetails = new DataTable();
            await ClsUtil.AddColumn(dtWingDetails, "Wing_DetailsId", ClsUtil.ColumnType.dbLong, "0");
            await ClsUtil.AddColumn(dtWingDetails, "Wing_MasterId", ClsUtil.ColumnType.dbLong, "0");
            await ClsUtil.AddColumn(dtWingDetails, "Flat_No", ClsUtil.ColumnType.dbString, "");
            await ClsUtil.AddColumn(dtWingDetails, "Wing_Name", ClsUtil.ColumnType.dbString, "");
            dgWingDetails.DataSource = dtWingDetails;
            dtWingMaster = new DataTable();
            await ClsUtil.AddColumn(dtWingMaster, "Wing_Master_Id", ClsUtil.ColumnType.dbLong, "0");
            await ClsUtil.AddColumn(dtWingMaster, "Wing_Names", ClsUtil.ColumnType.dbString, "");
            await ClsUtil.AddColumn(dtWingMaster, "Floar_Count", ClsUtil.ColumnType.dbInt, "");
            await ClsUtil.AddColumn(dtWingMaster, "House_Count", ClsUtil.ColumnType.dbInt, "");
            await ClsUtil.AddColumn(dtWingMaster, "Start_Number", ClsUtil.ColumnType.dbInt, "");
            await ClsUtil.AddColumn(dtWingMaster, "End_Number", ClsUtil.ColumnType.dbInt, "");
            dgvWingMaster.DataSource = dtWingMaster;
            await FillGridWingMaster();
            dgvWingMaster.Columns["Wing_Master_Id"].Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (CloseUserDetails != null)
            {
                CloseUserDetails.Invoke(sender, e);
            }
            this.Close();
        }

        private async void btnCreateFloarNumber_Click(object sender, EventArgs e)
        {
            int StartNo = Convert.ToInt32(txtStartNo.Text);
            int FlateCount = Convert.ToInt32(txtHouseCount.Text);
            int TotalFloar = Convert.ToInt32(txtFloar_Count.Text);
            int FlatNo = 0;
            await Task.Run(() =>
            {
                for (int i = 1; i <= TotalFloar; i++)
                {
                    FlatNo = 0;
                    for (int b = 1; b <= FlateCount; b++)
                    {
                        FlatNo = StartNo + b;
                        if (string.IsNullOrWhiteSpace(Convert.ToString(txtwingName.Tag)))
                        {
                            var drNew = dtWingDetails.NewRow();
                            drNew["Wing_DetailsId"] = 0;
                            drNew["Wing_MasterId"] = 0;
                            drNew["Flat_No"] = FlatNo.ToString();
                            drNew["Wing_Name"] = txtwingName.Text;
                            dtWingDetails.Rows.Add(drNew);
                        }
                        else
                        {
                            if (dtWingDetails.AsEnumerable().Where<DataRow>(x => x.Field<string>("Flat_No") == FlatNo.ToString()).Count() > 0)
                            {
                                dtWingDetails.AsEnumerable().Where<DataRow>(x => x.Field<string>("Flat_No") == FlatNo.ToString()).ToList().ForEach(x =>
                                {
                                    x["Flat_No"] = FlatNo.ToString();
                                    x["Wing_Name"] = txtwingName.Text;
                                });
                            }
                        }

                    }
                    StartNo = StartNo + 100;
                }
            });
            dtWingDetails.AcceptChanges();
        }
        private async Task ClearControlData()
        {
            await Task.Run(()=>this.Invoke(new MethodInvoker(() =>
            {
                dtWingDetails.Rows.Clear();
                txtEndNo.Text = "0";
                txtStartNo.Text = "0";
                txtFloar_Count.Text = "0";
                txtHouseCount.Text = "0";
                txtwingName.Text = "";
                txtwingName.Tag = null;
            })));
        }
        private async void btnCancel_Click(object sender, EventArgs e)
        {
            await ClearControlData();
        }
        private void txtNumberOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            int wingMasterId = 0;
            if (!string.IsNullOrEmpty(Convert.ToString(txtwingName.Tag)))
            {
                wingMasterId = Convert.ToInt32(txtwingName.Tag);
            }
            EnWingMaster enWingMaster = new EnWingMaster(wingMasterId,
                txtwingName.Text,
                Convert.ToInt32(txtFloar_Count.Text),
                Convert.ToInt32(txtHouseCount.Text),
                Convert.ToInt32(txtStartNo.Text),
                Convert.ToInt32(txtEndNo.Text));
            List<EnWingDetails> enWingDetails = new List<EnWingDetails>();
            dtWingDetails.AsEnumerable().ToList().ForEach(x =>
            {
                enWingDetails.Add(new EnWingDetails(Convert.ToInt32(x["Wing_DetailsId"]),
                    wingMasterId, Convert.ToString(x["Flat_No"]),
                    enWingMaster.Wing_Name));
            });
            var result = await BaWingMaster.InsertWingMaster(enWingMaster, enWingDetails, 1);
            if (result > 0)
            {
                if (result > 0)
                {
                    MessageBox.Show("Data Save", "Recipt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await FillGridWingMaster(result);
                    await ClearControlData();
                }
                if (result == -1)
                {

                }
            }
        }

        private async void dgvWingMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                await ClearControlData();
                int selectedWingMasterId = Convert.ToInt32(dgvWingMaster[0, e.RowIndex].Value);
                var selectedRow =  await ReceiptBAccess.BaWingMaster.getWingMaster(selectedWingMasterId);
                if (selectedRow != null)
                {
                    txtwingName.Tag = selectedWingMasterId;
                    txtwingName.Text = selectedRow.Wing_Name;
                    txtFloar_Count.Text = selectedRow.Floar_Count.ToString();
                    txtHouseCount.Text = selectedRow.Hous_Count.ToString();
                    txtStartNo.Text = selectedRow.Start_Number.ToString();
                    txtEndNo.Text = selectedRow.End_Number.ToString();
                    selectedRow.enWingDetails.ForEach(wingDetails =>
                    {
                        var drNew = dtWingDetails.NewRow();
                        drNew["Wing_DetailsId"] = wingDetails.Wing_DetailsId;
                        drNew["Wing_MasterId"] = selectedRow.Wing_Master_Id;
                        drNew["Flat_No"] = wingDetails.FlatNo;
                        drNew["Wing_Name"] = wingDetails.Wing_Name;
                        dtWingDetails.Rows.Add(drNew);
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
