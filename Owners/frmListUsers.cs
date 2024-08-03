using Online_Store_Project.Properties;
using OnlineStoreBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Store_Project
{
    public partial class frmListUsers : Form
    {
        private DataTable _dtUsers;
        private clsUser _Owner;
        public frmListUsers()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListUsers_Load(object sender, EventArgs e)
        {
            _dtUsers = clsUser.GetAllOwners();
            if (_dtUsers != null && _dtUsers.Rows.Count > 0)
            {
                dgvUsers.DataSource = _dtUsers;
                lbRecords.Text = dgvUsers.Rows.Count.ToString();
                bool DeleteColumnExists = dgvUsers.Columns.Cast<DataGridViewColumn>().Any(column => column.Name == "btnDelete");
              
                if (!DeleteColumnExists)
                {
                    DataGridViewImageColumn btnDelete = new DataGridViewImageColumn();
                    btnDelete.HeaderText = "Delete Information";
                    btnDelete.DefaultCellStyle.BackColor = Color.LightPink;
                    btnDelete.Image = Resources.delete;
                    btnDelete.ToolTipText = "Delete User";
                    btnDelete.Name = "btnDelete";
                    dgvUsers.Columns.Add(btnDelete);
                }
                dgvUsers.CellContentClick += DgvUsers_CellContentClick;
            }
            else
            {
                lbNoUsers.Visible = true;
                dgvUsers.Visible = false;
                lbRecords.Visible = false;
                labelRecords.Visible = false;
            }
        }

        private void DgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn &&
               e.RowIndex >= 0)
            {
                int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
                if (dgvUsers.Columns[e.ColumnIndex].Name == "btnDelete")
                {
                    if (MessageBox.Show("Confirm Delete.", "Confirm", MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        _Owner = clsUser.Find(UserID);
                        if (_Owner == null)
                        {
                            MessageBox.Show("User has Already been Deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (_Owner.Delete())
                        {
                            MessageBox.Show("Deleted Succssfully.", "Succss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
        }

        private void lbNoUsers_Click(object sender, EventArgs e)
        {

        }

        private void dgvUsers_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
