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
    public partial class frmUser : Form
    {
        private DataTable dtUserDetails;
        List<ReceiptEntity.EnUserDetails> UserDetails;
        public event EventHandler  CloseUserDetails;
        public frmUser()
        {
            InitializeComponent();
            FillDataGrid();
            ClearControlData();
        }
        private void ClearControlData()
        {
            try
            {
                txtUserName.Tag = null;
                txtUserName.Text = string.Empty;
                txtPassword.Text = string.Empty;
                chkIsAdmin.Checked = false;
                chkDelete.Checked = false;
                chkIsEdit.Checked = false;
                txtPassword.Enabled = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private async void FillDataGrid()
        {
            if (dtUserDetails != null) dtUserDetails.Dispose();
            
            dtUserDetails=new DataTable();
            await ClsUtil.AddColumn(dtUserDetails, "UserId", ClsUtil.ColumnType.dbLong, "0");
            await ClsUtil.AddColumn(dtUserDetails, "UserName", ClsUtil.ColumnType.dbString, "");
            await ClsUtil.AddColumn(dtUserDetails, "Password", ClsUtil.ColumnType.dbString, "");
            await ClsUtil.AddColumn(dtUserDetails, "IsAdmin", ClsUtil.ColumnType.dbboolean, "false");
            await ClsUtil.AddColumn(dtUserDetails, "IsEdit", ClsUtil.ColumnType.dbboolean, "false");
            await ClsUtil.AddColumn(dtUserDetails, "IsDelete", ClsUtil.ColumnType.dbboolean, "false");
            UserDetails = new List<EnUserDetails>();
            UserDetails = await ReceiptBAccess.BAUserDetails.GetAllUser();
            UserDetails.ForEach(user => 
            {
                DataRow newRow = dtUserDetails.NewRow();
                newRow["UserId"] = user.UserId;
                newRow["UserName"] = user.UserName;
                newRow["Password"] = user.Password;
                newRow["IsAdmin"] = Convert.ToString(user.IsAdmin)=="0"?false:true;
                newRow["IsEdit"] = Convert.ToString(user.IsEdit)=="0"?false:true;
                newRow["IsDelete"] = Convert.ToString(user.IsDelete)=="0"?false:true;
                dtUserDetails.Rows.Add(newRow);
            });
            dgUserDetails.DataSource = dtUserDetails;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                EnUserDetails enUserDetails = new EnUserDetails();
                if(string.IsNullOrWhiteSpace(Convert.ToString(txtUserName.Tag)))
                {
                    enUserDetails.UserId = 0;
                    enUserDetails.Password = ReceiptBAccess.BAUserDetails.HasPassword(txtPassword.Text);
                }
                else 
                {
                    enUserDetails.UserId = Convert.ToInt32(txtUserName.Tag);
                }
                enUserDetails.UserName = txtUserName.Text;
                enUserDetails.IsAdmin = chkIsAdmin.Checked == true ? 1 : 0;
                enUserDetails.IsDelete = chkDelete.Checked == true ? 1 :0;
                enUserDetails.IsEdit = chkIsEdit.Checked == true ? 1 : 0;
                var IsInsert = await ReceiptBAccess.BAUserDetails.InsertUpdateUser(enUserDetails);
                enUserDetails = await ReceiptBAccess.BAUserDetails.GetUserDetails(Convert.ToInt32(IsInsert));
                if (dtUserDetails.AsEnumerable().Where<DataRow>(x => x.Field<int>("UserID") == enUserDetails.UserId).Count()>0)
                {
                    dtUserDetails.AsEnumerable().Where<DataRow>(x => x.Field<int>("UserId") == enUserDetails.UserId).ToList<DataRow>().ForEach(x => {
                        x["UserId"] = enUserDetails.UserId;
                        x["UserName"] = enUserDetails.UserName;
                        x["Password"] = enUserDetails.Password;
                        x["IsAdmin"] = Convert.ToString(enUserDetails.IsAdmin) == "0" ? false : true;
                        x["IsEdit"] = Convert.ToString(enUserDetails.IsEdit) == "0" ? false : true;
                        x["IsDelete"] = Convert.ToString(enUserDetails.IsDelete) == "0" ? false : true;
                    });
                }
                else
                {
                    DataRow newRow = dtUserDetails.NewRow();
                    newRow["UserId"] = enUserDetails.UserId;
                    newRow["UserName"] = enUserDetails.UserName;
                    newRow["Password"] = enUserDetails.Password;
                    newRow["IsAdmin"] = Convert.ToString(enUserDetails.IsAdmin) == "0" ? false : true;
                    newRow["IsEdit"] = Convert.ToString(enUserDetails.IsEdit) == "0" ? false : true;
                    newRow["IsDelete"] = Convert.ToString(enUserDetails.IsDelete) == "0" ? false : true;
                    dtUserDetails.Rows.Add(newRow);
                }
                ClearControlData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dgUserDetails_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgUserDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int selectedUserId = Convert.ToInt32(dgUserDetails[0, e.RowIndex].Value);
                var selectedRow = dtUserDetails.AsEnumerable().Where<DataRow>(x => x.Field<int>("UserId") == selectedUserId).FirstOrDefault();
                if (selectedRow != null)
                {
                    txtUserName.Tag = selectedRow["UserId"];
                    txtUserName.Text = Convert.ToString(selectedRow["UserName"]);
                    txtPassword.Text = Convert.ToString(selectedRow["Password"]);
                    chkIsAdmin.Checked = Convert.ToInt16(selectedRow["IsAdmin"]) == 1 ? true : false;
                    chkDelete.Checked = Convert.ToInt16(selectedRow["IsDelete"]) == 1 ? true : false;
                    chkIsEdit.Checked = Convert.ToInt16(selectedRow["IsEdit"]) == 1 ? true : false;
                    txtPassword.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControlData();
        }

        private void dgUserDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.ColumnIndex == 2) && e.Value != null)
            {
                dgUserDetails.Rows[e.RowIndex].Tag = e.Value;
                e.Value = new String('\u25CF', e.Value.ToString().Length);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if(CloseUserDetails != null)
            {
                CloseUserDetails.Invoke(sender,e);
            }
            this.Close();
        }
    }
}
