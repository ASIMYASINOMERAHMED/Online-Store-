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
    public partial class ctrCustomerNotification : UserControl
    {
        private int _NotificationID;

        private clsNotificationCustomer _CustomerNotification;

        public ctrCustomerNotification(int NotificationID)
        {
            InitializeComponent();
            _NotificationID = NotificationID;
        }

        public EventHandler ShowCategories;
        private void ctrNotification_Load(object sender, EventArgs e)
        {
            _CustomerNotification = clsNotificationCustomer.Find(_NotificationID);
            if( _CustomerNotification == null )
            {
                MessageBox.Show("Notification Not Exists.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if( _CustomerNotification.NewProductID !=-1 )
            {
             
                lbNotificationText.Text = "New Product Arrival";
                picNotification.Image = Resources.box;
                lbDateTime.Text = _CustomerNotification.DateTime.ToString();
            }
            else
            {
         
                lbNotificationText.Text = "New Collection Arrival";
                picNotification.Image = Resources.boxes;
                lbDateTime.Text = _CustomerNotification.DateTime.ToString();
            }
        }

        private void guna2CustomGradientPanel1_DoubleClick(object sender, EventArgs e)
        {
            if (_CustomerNotification.NewProductID != -1)
            {
                frmProductDetails productDetails = new frmProductDetails(_CustomerNotification.NewProductID);
                productDetails.StartPosition = FormStartPosition.CenterScreen;
                productDetails.ShowDialog();
            }
            else
            {
                ShowCategories.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
