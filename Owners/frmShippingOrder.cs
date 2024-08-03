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
    public partial class frmShippingOrder : Form
    {
        private int _OrderID;
        private clsOrder _Order;
        private static Random random = new Random();
        private clsShipping _Shipping;
        public frmShippingOrder(int OrderID)
        {
            InitializeComponent();
            _OrderID = OrderID;
        }

        private void _FillShippersInComboBox()
        {
            DataTable dtShippers = clsShippers.GetAllShippersName();
            foreach (DataRow row in dtShippers.Rows)
            {
                cbCarriers.Items.Add(row["CarrierName"]);
            }
            cbCarriers.SelectedIndex = 0;
        }
   

        public static string GenerateTrackingNumber()
        {
            StringBuilder trackingNumber = new StringBuilder();

            // Generate two random characters
            trackingNumber.Append(RandomCharacter());
            trackingNumber.Append(RandomCharacter());

            // Generate seven random numbers
            for (int i = 0; i < 7; i++)
            {
                trackingNumber.Append(random.Next(0, 10));
            }

            return trackingNumber.ToString();
        }

        private static char RandomCharacter()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return chars[random.Next(chars.Length)];
        }
        private void frmShippingOrder_Load(object sender, EventArgs e)
        {
            ctrOrderInfo orderInfo = new ctrOrderInfo(_OrderID);
            orderInfo.Dock = DockStyle.Top;
            this.Controls.Add(orderInfo);
            _FillShippersInComboBox();
            DTPEstimatedDate.MinDate = DateTime.Now;
            DTPEstimatedDate.Value = DateTime.Today.AddDays(3);
            lbActualDate.Text = "UNKNOWN";
            lbStatus.Text = clsShipping.enShippingStatus.Pendding.ToString();
            lbTrackingNumber.Text = GenerateTrackingNumber();
            _Order = clsOrder.Find(_OrderID);
            lbAddress.Text = _Order.Customer.Address;
            ToolTip1.SetToolTip(lbAddress,lbAddress.Text);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Shipping = new clsShipping();
            _Shipping.OrderID = _OrderID;
            _Shipping.CarrierID = clsShippers.Find(cbCarriers.Text.Trim()).CarrierID;
            _Shipping.TrackingNumber = lbTrackingNumber.Text;
            _Shipping.Status = clsShipping.enShippingStatus.Pendding;
            _Shipping.EstimatedDeliveryDate = DTPEstimatedDate.Value;
            _Shipping.ActualDeliveryDate = null;
            try
            {
                if (_Shipping.Save())
                {
                    MessageBox.Show("Shipping Confirmed Succssfully.", "Succss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Unable To Save Data.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An Error Occurred {ex.Message}");
            }
        }

        private void cbCarriers_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cbCarriers.Text.Trim()) || cbCarriers.SelectedIndex == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(cbCarriers, "Please Select Carrier!");
                return;
            }
            else
            {
                errorProvider1.SetError(cbCarriers, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            frmAddUpdateShipper frm = new frmAddUpdateShipper();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }
    }
}
