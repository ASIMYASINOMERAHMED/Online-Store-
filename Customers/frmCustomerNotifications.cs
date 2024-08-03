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
    public partial class frmCustomerNotifications : Form
    {
        private int _CustomerID;
        private DataTable _dtCustomerNotifications;
        public frmCustomerNotifications(int customerID,DataTable CustomerNotifications)
        {
            InitializeComponent();
            _CustomerID = customerID;
            _dtCustomerNotifications = CustomerNotifications;
        }
        public EventHandler ShowCategories;
        private void frmNotifications_Load(object sender, EventArgs e)
        {
            ctrCustomerNotifications customerNotifications = new ctrCustomerNotifications(_CustomerID, _dtCustomerNotifications);
            customerNotifications.Dock = DockStyle.Bottom;
            customerNotifications.BringToFront();
            customerNotifications.ShowCategories += CtrCustomerNotifications_ShowCategories;
            this.Controls.Add(customerNotifications);
        }
        private void CtrCustomerNotifications_ShowCategories(object sender, EventArgs e)
        {
            ShowCategories.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
