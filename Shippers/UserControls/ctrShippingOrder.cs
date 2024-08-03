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
    public partial class ctrShippingOrder : UserControl
    {
        private int _ShippingID;
        private clsShipping _Shipping;
        private bool _ShowDeliveredCancel;
        public ctrShippingOrder(int ShippingID)
        {
            InitializeComponent();
            _ShippingID = ShippingID;
        }
        public bool ShowDeliveredCancel
        {
            get { return _ShowDeliveredCancel; }
            set
            {
                _ShowDeliveredCancel = value;
                panelDeliveredCanceled.Visible = _ShowDeliveredCancel;
            }
        }
        public delegate void DataBackShippingDeliveredEventHandler(object sender, int ShippingID);

        // Declare an event using the delegate
        public event DataBackShippingDeliveredEventHandler ShippingDelivered;

        public delegate void DataBackShippingCanceledEventHandler(object sender, int ShippingID);

        // Declare an event using the delegate
        public event DataBackShippingCanceledEventHandler ShippingCanceled;
        private void ctrShippingOrder_Load(object sender, EventArgs e)
        {
            _Shipping = clsShipping.Find(_ShippingID);
            if( _Shipping == null )
            {
                MessageBox.Show("Shipping Details has been Deleted.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            lbOrderID.Text = _Shipping.Order.OrderID.ToString();
            lbTotalAmount.Text = _Shipping.Order.TotalAmount.ToString();
            lbStatus.Text = _Shipping.Status.ToString();
            lbTrackingNumber.Text = _Shipping.TrackingNumber.ToString();
            lbEstimatedDate.Text = _Shipping.EstimatedDeliveryDate.ToString();
            if (_Shipping.ActualDeliveryDate == null)
                lbActualDate.Text = "UNKNOWN";
            else
                lbActualDate.Text = _Shipping.ActualDeliveryDate.ToString();
            lbAddress.Text = _Shipping.Order.Customer.Address;
        }

        private void btnDelivered_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Shipping.DeliverOrder())
                {
                    if (clsOrder.OrderDelivered(_Shipping.OrderID))
                    {
                        ShippingDelivered?.Invoke(this, _Shipping.ShippingID);
                    }
                }
                else
                    MessageBox.Show("An Error Occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An Error Occurred {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cancel Order.", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    if (_Shipping.CancelOrder())
                        ShippingCanceled?.Invoke(this, _Shipping.ShippingID);
                    else
                        MessageBox.Show("An Error Occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"An Error Occurred {ex.Message}");
                }
            }
            else
                return;
        }

        private void llOrderDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmOrderDetails frm = new frmOrderDetails(_Shipping.OrderID);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }
    }
}
