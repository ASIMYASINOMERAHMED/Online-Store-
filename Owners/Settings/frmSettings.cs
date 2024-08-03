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
    public partial class frmSettings : Form
    {
        private bool _DarkMode = false;
        public frmSettings(bool DarkMode)
        {
            InitializeComponent();
            _DarkMode = DarkMode;
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

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            frmAddUpdateProduct frm = new frmAddUpdateProduct();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            frmAddUpdateCategory frm = new frmAddUpdateCategory();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            frmResetPassword frm = new frmResetPassword();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser(clsGlobal.CurrentUser.UserID);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            DataBackInfoUpdated?.Invoke(this, EventArgs.Empty);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            frmAddUpdateShipper frm = new frmAddUpdateShipper();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            frmListCarriers frm = new frmListCarriers();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            frmListUsers frm = new frmListUsers();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            frmPredictor frm = new frmPredictor();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            frmMostSoldProducts frm = new frmMostSoldProducts();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            guna2ToggleSwitch1.Checked = _DarkMode;
        }
    }
}
