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
    public partial class ctrOwnerNotification : UserControl
    {
        private int _NotificationID;
        private clsNotificationOwner _OwnerNotification;
        private clsPayment _Payment;
        public ctrOwnerNotification(int NotificationID)
        {
            InitializeComponent();
            _NotificationID = NotificationID;
        }

        private void ctrOwnerNotification_Load(object sender, EventArgs e)
        {
            _OwnerNotification = clsNotificationOwner.Find(_NotificationID);
            if (_OwnerNotification == null)
            {
                MessageBox.Show("Notification Not Exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(_OwnerNotification.NewCustomerID!=-1)
            {
                lbNotificationText.Text = "New Visitor To The System";
                picNotification.Image = Resources.guest;
                lbDateTime.Text = _OwnerNotification.DateTime.ToString();
            }
            else
            {
                lbNotificationText.Text = "New Order";
                picNotification.Image = Resources.order;
                lbDateTime.Text = _OwnerNotification.DateTime.ToString();
            }
        }

        private void guna2CustomGradientPanel1_DoubleClick(object sender, EventArgs e)
        {
            if(_OwnerNotification.NewCustomerID!=-1)
            {
                frmUserInfo frm = new frmUserInfo(_OwnerNotification.NewCustomerID);
                frm.EditVisible = false;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
            else
            {
                _Payment = clsPayment.Find(_OwnerNotification.NewPaymentID);
                if (_Payment == null)
                {
                    MessageBox.Show("Payment Not Exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                frmOrderDetails frm = new frmOrderDetails(_Payment.OrderID);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
        }
    }
}
