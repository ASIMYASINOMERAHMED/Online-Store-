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
    public partial class frmOrderDetails : Form
    {
        private int _OrderID;
        private DataTable _dtOrderItems;
        private clsProductCatalog _Product;
        private clsOrder _Order;
        public frmOrderDetails(int OrderID)
        {
            InitializeComponent();
            _OrderID = OrderID;
        }
        public EventHandler OrderProcessed;
        private void frmOrderDetails_Load(object sender, EventArgs e)
        {
            ctrOrderInfo orderInfo = new ctrOrderInfo(_OrderID);
            orderInfo.Dock = DockStyle.Top;
            orderInfo.OrderDetailsVisable = false;
            this.Controls.Add(orderInfo);
            _RefreshOrderItems();
        }
        private void _RefreshOrderItems()
        {
           _dtOrderItems = clsOrderItem.GetAllOrderItems(_OrderID);
            dgvOrderItems.DataSource = _dtOrderItems;
            if (dgvOrderItems.Rows.Count > 0)
            {
               
                DataGridViewImageColumn btnDetails = new DataGridViewImageColumn();
                btnDetails.HeaderText = "Order Details";
                btnDetails.DefaultCellStyle.BackColor = Color.LightSlateGray;
                btnDetails.Image = Resources.action_items_list_zoom;
                btnDetails.ToolTipText = "View Details";
                btnDetails.Name = "btnDetails";
                dgvOrderItems.Columns.Add(btnDetails);
                dgvOrderItems.CellContentClick += DgvOrderItems_CellContentClick;
            }
            else
                this.Close();
        }

        private void DgvOrderItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
            var senderGrid = (DataGridView)sender;
            int OrderID = (int)dgvOrderItems.CurrentRow.Cells[0].Value;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn &&
                e.RowIndex >= 0)
            {
                string ProductName = (string)dgvOrderItems.CurrentRow.Cells[1].Value;
                _Product = clsProductCatalog.Find(ProductName);
                if (_Product == null)
                {
                    MessageBox.Show("Product has been deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                frmItemDetails itemDetails = new frmItemDetails(OrderID,_Product.ProductID);
                itemDetails.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
