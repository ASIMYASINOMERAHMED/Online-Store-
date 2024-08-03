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
    public partial class frmMostSoldProducts : Form
    {
        private DataTable _dtProducts;
        public frmMostSoldProducts()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvMostSoldProducts.CellContentClick -= DgvMostSoldProducts_CellContentClick;
            _dtProducts = clsProductCatalog.GetMostSoldProducts(DTPFrom.Value,DTPTo.Value);
            if (_dtProducts != null)
            {
                dgvMostSoldProducts.DataSource = _dtProducts;
                lbRecords.Text = dgvMostSoldProducts.Rows.Count.ToString();
                bool detailsColumnExists = dgvMostSoldProducts.Columns.Cast<DataGridViewColumn>().Any(column => column.Name == "btnDetails");
                if (!detailsColumnExists)
                {
                    
                    DataGridViewImageColumn btnDetails = new DataGridViewImageColumn();
                    btnDetails.HeaderText = "Order Details";
                    btnDetails.Image = Resources.action_items_list_zoom;
                    btnDetails.ToolTipText = "View Details";
                    btnDetails.Name = "btnDetails";
                    dgvMostSoldProducts.Columns.Add(btnDetails);

                }
                dgvMostSoldProducts.CellContentClick += DgvMostSoldProducts_CellContentClick; 
                if (dgvMostSoldProducts.Rows.Count == 0)
                {
                    dgvMostSoldProducts.Columns.Clear();
                    lbNotFound.Visible = true;
                    lbNotFound.Location = new Point(this.Width / 2, this.Height / 2);
                }
                else
                    lbNotFound.Visible = false;
            }
        }

        private void DgvMostSoldProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn &&
                e.RowIndex >= 0)
            {
                int ProductID = (int)dgvMostSoldProducts.CurrentRow.Cells["ProductID"].Value;
                if (dgvMostSoldProducts.Columns[e.ColumnIndex].Name == "btnDetails")
                {
                    frmAddUpdateProduct frm = new frmAddUpdateProduct(ProductID);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                }
            }
        }

        private void DTPFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                btnSearch.PerformClick();
            }
        }

        private void DTPTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                btnSearch.PerformClick();
            }
        }
    }
}
