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
    public partial class frmShipping : Form
    {
        private Form _frmLogin;
        private DataTable _dtShippings;
        private DataTable _dtDeliveredShippings;
        private int spacing = 10;
        private clsShipping _Shipping;
        private int _ShippingNumber=0;
        private bool _logoutButtonPressed = false;
        public frmShipping(Form frmLogin)
        {
            InitializeComponent();
            _frmLogin = frmLogin;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            _logoutButtonPressed = true;
            clsGlobal.CurrentShipper = null;
            _frmLogin.Show();
            this.Close();
        }
        private List<ctrShippingOrder> _LoadShippings(DataTable Table)
        {
            ctrShippingOrder shippingOrder;

            List<ctrShippingOrder> shippingOrders = new List<ctrShippingOrder>();
            //Parallel.ForEach(Table.AsEnumerable(), drow =>
            foreach(DataRow drow in Table.Rows)
            {
                shippingOrder = new ctrShippingOrder((int)drow["ShippingID"]);
                shippingOrder.ShippingDelivered += ShippingOrder_ShippingDelivered;
                shippingOrder.ShippingCanceled += ShippingOrder_ShippingCanceled;
                shippingOrder.Margin = new Padding(spacing);
                shippingOrders.Add(shippingOrder);
            }
            return shippingOrders;
        }
        private List<ctrShippingOrder> _LoadDeliveredShippings(DataTable Table)
        {
            ctrShippingOrder shippingOrder;

            List<ctrShippingOrder> shippingOrders = new List<ctrShippingOrder>();
            //Parallel.ForEach(Table.AsEnumerable(), drow =>
            foreach (DataRow drow in Table.Rows)
            {
                shippingOrder = new ctrShippingOrder((int)drow["ShippingID"]);
                shippingOrder.ShowDeliveredCancel = false;
                shippingOrder.Margin = new Padding(spacing);
                shippingOrders.Add(shippingOrder);
            }
            return shippingOrders;
        }
        private void _LoadShippingOrderOnDeliverdScreen(int ShippingID)
        {
            ctrShippingOrder shippingOrder;
            shippingOrder = new ctrShippingOrder(ShippingID);
            shippingOrder.ShowDeliveredCancel = false;
            shippingOrder.Margin = new Padding(spacing);
            DeliveredOrdersPanel.Controls.Add(shippingOrder);
        }
        private void ShippingOrder_ShippingCanceled(object sender, int ShippingID)
        {
                int index = ShippingContainer.Controls.GetChildIndex((Control)sender);
                ShippingContainer.Controls.RemoveAt(index);
            if (ShippingContainer.Controls.Count != 0)
            {
                _ShippingNumber = ShippingContainer.Controls.Count;
                lbShippingOrdersNumber.Text = _ShippingNumber.ToString();
                lbShippingOrdersNumber.Visible = true;
                lbNoShippingOrders.Visible = false;
            }
            else
            {
                lbShippingOrdersNumber.Visible = false;
                lbNoShippingOrders.Visible = true;
            }
            _Shipping = clsShipping.Find(ShippingID);
            if (_Shipping != null)
            {
                if (_Shipping.Delete())
                {
                    if (clsOrder.DeleteCompeleteOrder(_Shipping.OrderID))
                    {
                        MessageBox.Show("Order Canceled.", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("An Error Occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Shipping not exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void ShippingOrder_ShippingDelivered(object sender, int ShippingID)
        {
            if (MessageBox.Show("Confirm Delivered Order.", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                int index = ShippingContainer.Controls.GetChildIndex((Control)sender);
                ShippingContainer.Controls.RemoveAt(index);
                _LoadShippingOrderOnDeliverdScreen(ShippingID);
                lbDeliveredOrdersNum.Text = DeliveredOrdersPanel.Controls.Count.ToString();
                lbShippingOrdersNumber.Text = ShippingContainer.Controls.Count.ToString();
                if(lbShippingOrdersNumber.Text =="0")
                {
                    lbShippingOrdersNumber.Visible = false;
                    lbNoShippingOrders.Visible = true;
                    ShippingContainer.Visible = false;
                }
            }
            else
                return;
        }

        private async Task _DisplayShippingsAsync()
        {
            _dtShippings = await Task.Run(() => clsShipping.GetAllShippingsForCarrierID(clsGlobal.CurrentShipper.CarrierID));

            if (_dtShippings != null)
            {
                List<ctrShippingOrder> shippingOrders = await Task.Run(() => _LoadShippings(_dtShippings));
                ShippingContainer.Controls.AddRange(shippingOrders.ToArray());
            }
            if (_dtShippings.Rows.Count != 0)
            {
                _ShippingNumber = _dtShippings.Rows.Count;
                lbShippingOrdersNumber.Text = _ShippingNumber.ToString();
                lbShippingOrdersNumber.Visible = true;
                lbNoShippingOrders.Visible = false;
            }
            else
            {
                lbShippingOrdersNumber.Visible = false;
                lbNoShippingOrders.Visible = true;
                ShippingContainer.Visible = false;
            }

        }

        private async Task _DisplayDeliveredShippingsAsync()
        {
            _dtDeliveredShippings = await Task.Run(() => clsShipping.GetAllDeliveredShippingsForCarrierID(clsGlobal.CurrentShipper.CarrierID));

            if (_dtDeliveredShippings != null)
            {
                List<ctrShippingOrder> shippingOrders = await Task.Run(() => _LoadDeliveredShippings(_dtDeliveredShippings));
                DeliveredOrdersPanel.Controls.AddRange(shippingOrders.ToArray());
            }
            if(_dtDeliveredShippings.Rows.Count != 0)
            {
                lbDeliveredOrdersNum.Text = _dtDeliveredShippings.Rows.Count.ToString();
                lbDeliveredOrdersNum.Visible = true;
            }
            else
                lbDeliveredOrdersNum.Visible= false;
        }

        private void btnSideMenu_Click(object sender, EventArgs e)
        {
            tbPages.SelectTab(((Control)sender).Tag.ToString());
        }

        private async void frmShipping_Load(object sender, EventArgs e)
        {
            await _DisplayShippingsAsync();
            await _DisplayDeliveredShippingsAsync();
        }

        private void frmShipping_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_logoutButtonPressed)
            {
                if (clsGlobal.CurrentShipper != null)
                {
                    clsGlobal.CurrentShipper = null;
                    _frmLogin.Show();
                    this.Close();
                }
            }
            else if (e.CloseReason == CloseReason.UserClosing)
            {

                Environment.Exit(0);

            }
            else
            {
                e.Cancel = true;

            }
        }
    }
}
