using Online_Store_Project.Properties;
using OnlineStoreBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Store_Project
{
    public partial class frmListCarriers : Form
    {
        private DataTable _dtCarriers;
        private clsShippers _Carrier;
        public frmListCarriers()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListCarriers_Load(object sender, EventArgs e)
        {
            _dtCarriers = clsShippers.GetAllShipperData();
            if (_dtCarriers != null && _dtCarriers.Rows.Count > 0)
            {

                dgvCarriers.DataSource = _dtCarriers;
                lbRecords.Text = dgvCarriers.Rows.Count.ToString();
                bool EditColumnExists = dgvCarriers.Columns.Cast<DataGridViewColumn>().Any(column => column.Name == "btnEdit");
                bool DeleteColumnExists = dgvCarriers.Columns.Cast<DataGridViewColumn>().Any(column => column.Name == "btnDelete");
                if (!EditColumnExists)
                {

                    DataGridViewImageColumn btnEdit = new DataGridViewImageColumn();
                    btnEdit.HeaderText = "Edit Information";
                   // btnEdit.DefaultCellStyle.BackColor = Color.LightSlateGray;
                    btnEdit.Image = Resources.edit__3_;
                    btnEdit.ToolTipText = "Edit Information";
                    btnEdit.Name = "btnEdit";
                    dgvCarriers.Columns.Add(btnEdit);
                }
                if (!DeleteColumnExists)
                {  
                    DataGridViewImageColumn btnDelete = new DataGridViewImageColumn();
                    btnDelete.HeaderText = "Delete Information";
                  //  btnDelete.DefaultCellStyle.BackColor = Color.LightPink;
                    btnDelete.Image = Resources.delete;
                    btnDelete.ToolTipText = "Delete Carrier";
                    btnDelete.Name = "btnDelete";
                    dgvCarriers.Columns.Add(btnDelete);
                }
                dgvCarriers.CellContentClick += DgvCarriers_CellContentClick;
            }
            else
            {
                lbNoCarriers.Visible = true;
                dgvCarriers.Visible=false;
                lbRecords.Visible = false;
                labelRecords.Visible = false;
            }

        }
  
        private void DgvCarriers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn &&
               e.RowIndex >= 0)
            {
                if (dgvCarriers.CurrentRow.Cells[0].Value is int carrierID)
                {
                    if (dgvCarriers.Columns[e.ColumnIndex].Name == "btnEdit")
                    {
                        frmAddUpdateShipper frm = new frmAddUpdateShipper(carrierID);
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.ShowDialog();
                        this.Close();
                    }
                    else if (dgvCarriers.Columns[e.ColumnIndex].Name == "btnDelete")
                    {
                        if (MessageBox.Show("Confirm Delete.", "Confirm", MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            _Carrier = clsShippers.Find(carrierID);
                            if (_Carrier == null)
                            {
                                MessageBox.Show("Carrier has Already been Deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                            if (_Carrier.DeleteShipper())
                            {
                                MessageBox.Show("Deleted Succssfully.", "Succss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                        }
                    }
                }
            }
        }
    }
}
