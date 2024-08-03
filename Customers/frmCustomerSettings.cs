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
    public partial class frmCustomerSettings : Form
    {
        private bool _DarkMode = false;
        public frmCustomerSettings(bool darkMode)
        {
            InitializeComponent();
            _DarkMode = darkMode;
        }

        public delegate void DataBackDarkModeEventHandler(object sender, bool Value);

        // Declare an event using the delegate
        public event DataBackDarkModeEventHandler DataBackDarkMode;

        public delegate void DataBackCustmizeColorEventHandler(object sender, EventArgs e);

        // Declare an event using the delegate
        public event DataBackCustmizeColorEventHandler DataBackCustomizeColor;

        public delegate void DataBackUpdateEventHandler(object sender, EventArgs e);

        // Declare an event using the delegate
        public event DataBackUpdateEventHandler DataBackInfoUpdated;


        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            DataBackDarkMode?.Invoke(this, guna2ToggleSwitch1.Checked);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DataBackCustomizeColor?.Invoke(this, EventArgs.Empty);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            frmResetPassword frm = new frmResetPassword();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            frmAddUpdateCustomer frm = new frmAddUpdateCustomer(clsGlobal.CurrentUser.UserID);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            DataBackInfoUpdated?.Invoke(this, EventArgs.Empty); 
        }

        private void frmCustomerSettings_Load(object sender, EventArgs e)
        {
            guna2ToggleSwitch1.Checked = _DarkMode;
        }

       
    }
}
