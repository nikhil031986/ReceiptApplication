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
using ReceiptBAccess;
using ReceiptEntity;
using ReceiptLog;

namespace Receipt
{
    public partial class Wing_Master : Form
    {
        private DataTable dtWingDetails;
        private DataTable dtWingMaster;
        public event EventHandler CloseUserDetails;
        public Wing_Master()
        {
            try
            {

                InitializeComponent();
                AddContrial();
                this.btnClose.Image = (Image)(new Bitmap(Receipt.Properties.Resources.Close, new Size(32, 25)));
                this.btnClose.ImageAlign = ContentAlignment.MiddleCenter;
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
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
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
            }

        }
        private async Task AddContrial()
        {
            try
            {
                dtWingDetails = new DataTable();
                await ClsUtil.AddColumn(dtWingDetails, "Wing_DetailsId", ClsUtil.ColumnType.dbLong, "0");
                await ClsUtil.AddColumn(dtWingDetails, "Wing_MasterId", ClsUtil.ColumnType.dbLong, "0");
                await ClsUtil.AddColumn(dtWingDetails, "Flat_No", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtWingDetails, "Wing_Name", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtWingDetails, "Land", ClsUtil.ColumnType.dbDecimal, "");
                await ClsUtil.AddColumn(dtWingDetails, "Carpet", ClsUtil.ColumnType.dbDecimal, "");
                await ClsUtil.AddColumn(dtWingDetails, "WB", ClsUtil.ColumnType.dbDecimal, "");
                await ClsUtil.AddColumn(dtWingDetails, "Amount", ClsUtil.ColumnType.dbDecimal, "");
                await ClsUtil.AddColumn(dtWingDetails, "Total", ClsUtil.ColumnType.dbDecimal, "");
                await ClsUtil.AddColumn(dtWingDetails, "EAST", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtWingDetails, "WEST", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtWingDetails, "NORTH", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtWingDetails, "SOUTH", ClsUtil.ColumnType.dbString, "");
                await ClsUtil.AddColumn(dtWingDetails, "FlorName", ClsUtil.ColumnType.dbString, "");
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
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
            }

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

        private async void btnCreateFloarNumber_Click(object sender, EventArgs e)
        {
            int StartNo = Convert.ToInt32(txtStartNo.Text);
            int FlateCount = Convert.ToInt32(txtHouseCount.Text);
            int TotalFloar = Convert.ToInt32(txtFloar_Count.Text);
            int FlatNo = 0;
            int florNumber = 0;
            await Task.Run(() =>
            {
                try
                {
                    for (int i = 1; i <= TotalFloar; i++)
                    {
                        FlatNo = 0;
                        florNumber = florNumber + 1;
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
                                drNew["Land"] = 0;
                                drNew["Carpet"] = 0;
                                drNew["WB"] = 0;
                                drNew["Amount"] = 0;
                                drNew["Total"] = 0;
                                drNew["EAST"] = 0;
                                drNew["WEST"] = 0;
                                drNew["NORTH"] = 0;
                                drNew["SOUTH"] = 0;
                                drNew["FlorName"] = ClsUtil.ConvertWord(florNumber);
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
                                        x["FlorName"] = ClsUtil.ConvertWord(florNumber);
                                    });
                                }
                            }

                        }
                        StartNo = StartNo + 100;
                    }
                }
                catch (Exception ex)
                {
                    clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
                }
            });
            dtWingDetails.AcceptChanges();
        }
        private async Task ClearControlData()
        {
            await Task.Run(() => this.Invoke(new MethodInvoker(() =>
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
            try
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
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
            }
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
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
                    enWingDetails.Add(new EnWingDetails(
                        Convert.ToInt32(x["Wing_DetailsId"]),
                        wingMasterId,
                        Convert.ToString(x["Flat_No"]),
                        enWingMaster.Wing_Name,
                        Convert.ToDecimal(x["Land"]),
                        Convert.ToDecimal(x["Carpet"]),
                        Convert.ToDecimal(x["WB"]),
                        Convert.ToDecimal(x["Amount"]),
                        Convert.ToDecimal(x["Total"]),
                        Convert.ToString(x["EAST"]),
                        Convert.ToString(x["WEST"]),
                        Convert.ToString(x["NORTH"]),
                        Convert.ToString(x["SOUTH"]),
                        Convert.ToString(x["FlorName"])
                        ));
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
            catch (Exception ex)
            {
                ReceiptLog.clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
            }
        }

        private async void dgvWingMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                await ClearControlData();
                int selectedWingMasterId = Convert.ToInt32(dgvWingMaster[0, e.RowIndex].Value);
                var selectedRow = await ReceiptBAccess.BaWingMaster.getWingMaster(selectedWingMasterId);
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
                        drNew["Land"] = wingDetails.Land;
                        drNew["Carpet"] = wingDetails.Carpet;
                        drNew["WB"] = wingDetails.WB;
                        drNew["Amount"] = wingDetails.Amount;
                        drNew["Total"] = wingDetails.Total;
                        drNew["EAST"] = wingDetails.EAST;
                        drNew["WEST"] = wingDetails.WEST;
                        drNew["NORTH"] = wingDetails.NORTH;
                        drNew["SOUTH"] = wingDetails.SOUTH;
                        drNew["FlorName"] = wingDetails.FlorName;
                        dtWingDetails.Rows.Add(drNew);
                    });
                }
            }
            catch (Exception ex)
            {
                clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dgWingDetails_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                decimal total = 0;
                var cell = dgWingDetails[e.ColumnIndex, e.RowIndex];
                if (cell.OwningColumn.Name == "Land" || cell.OwningColumn.Name == "Carpet" || cell.OwningColumn.Name == "WB")
                {
                    //update the Amount cell
                    cell.OwningRow.Cells["Total"].Value = Convert.ToDecimal(cell.OwningRow.Cells["Carpet"].Value) +
                                                          Convert.ToDecimal(cell.OwningRow.Cells["WB"].Value);
                }
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }

        private void dgWingDetails_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
                if (dgWingDetails.CurrentCell.OwningColumn.Name == "Land" ||
                    dgWingDetails.CurrentCell.OwningColumn.Name == "Carpet" ||
                    dgWingDetails.CurrentCell.OwningColumn.Name == "WB" || dgWingDetails.CurrentCell.OwningColumn.Name == "Amount") //Desired Column
                {
                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                    }
                }
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }

                // allow 1 dot:


                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    if ((sender as TextBox).Text != ".")
                    {
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex) { clsLog.InstanceCreation().InsertLog(ex.ToString(), clsLog.logType.Error, MethodBase.GetCurrentMethod().Name); }
        }
    }
}