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
    public partial class frmAddUpdateShipper : Form
    {
        private clsShippers _Shipper;
        private int _ShipperID;
        private enum enMode { AddNew = 1, Update = 2 };
        private enMode _Mode;
        public frmAddUpdateShipper()
        {
            InitializeComponent();
            _Shipper = new clsShippers();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateShipper(int ShipperID)
        {
            InitializeComponent();
            _ShipperID = ShipperID;
            _Mode = enMode.Update;
        }
        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values

            if (_Mode == enMode.AddNew)
            {
                _Shipper = new clsShippers();
            }
            lbTitle.Text = "Add Carrier";
            txtEmail.Text = "";
            txtName.Text = "";
            txtPassword.Text = "";
            txtPasswordagain.Text = "";
            txtPhone.Text = "";
            txtUserName.Text = "";
        }
        private void _LoadData()
        {
            _Shipper = clsShippers.Find(_ShipperID);
            if (_Shipper == null)
            {
                MessageBox.Show("This Form Will Be Closed Because Shipper with ID " + _ShipperID + " is Deleted");
                this.Close();
                return;
            }

            txtEmail.Text = _Shipper.Email;
            txtName.Text = _Shipper.CarrierName;
            txtPhone.Text = _Shipper.Phone;
            txtUserName.Text = _Shipper.UserName;
            this.Text = "Update Information";
            gbShipperInfo.Text = "Update Info";
            lbTitle.Text = "Update Information";
            gbShipperInfo.Height = 532;
            this.Height = 642;
        }
        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {

            // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 
            Guna.UI2.WinForms.Guna2TextBox Temp = ((Guna.UI2.WinForms.Guna2TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
            if (!clsGlobal.IsValidEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            };
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }
            //Make sure the User Name is not used by another User
            if (txtUserName.Text.Trim() != _Shipper.UserName && clsShippers.IsUserExist(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "UserName is used for another Carrier!");

            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtPassword, "This field is required!");
                    return;
                }
                else
                {
                    errorProvider1.SetError(txtPassword, null);
                }
                if (!clsGlobal.IsValidPassword(txtPassword.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtPassword, "Password should contain Numbers, Upper Case Characters, and at least 8 Characters!");

                }
                else
                {
                    errorProvider1.SetError(txtPassword, null);
                }
            }
        }

        private void txtPasswordagain_Validating(object sender, CancelEventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                if (string.IsNullOrEmpty(txtPasswordagain.Text.Trim()))
                {
                    e.Cancel = true;
                    txtPasswordagain.Focus();
                    errorProvider1.SetError(txtPasswordagain, "Please Confirm Password!");

                }
                else if (txtPasswordagain.Text.Trim() != txtPassword.Text.Trim())
                {
                    e.Cancel = true;
                    txtPasswordagain.Focus();
                    errorProvider1.SetError(txtPasswordagain, "Password does not match!");
                }
                else
                {
                    errorProvider1.Clear();
                    return;
                }
            }
        }
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Shipper.CarrierName = txtName.Text.Trim();
            _Shipper.Email = txtEmail.Text.Trim();  
            _Shipper.Phone = txtPhone.Text.Trim();
            _Shipper.UserName = txtUserName.Text.Trim();
            if (_Mode == enMode.AddNew)
                _Shipper.Password = clsGlobal.ComputeHash(txtPassword.Text.Trim());
            try
            {
                if (_Shipper.Save())
                {
                    MessageBox.Show("Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Unable to Save Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An Error Occurred {ex.Message}");
            }
        }

        private void frmAddShipper_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            if (_Mode == enMode.Update)
                _LoadData();
        }
        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            button4.BackgroundImage = Resources.eyePassword_removebg_preview;
            txtPassword.UseSystemPasswordChar = false;
            txtPassword.PasswordChar = '\0';
            focusdot1.Focus();
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            button4.BackgroundImage = Resources.eyeClose_removebg_preview;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.PasswordChar = '●';
            focusdot1.Focus();
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {

            button1.BackgroundImage = Resources.eyePassword_removebg_preview;
            txtPasswordagain.UseSystemPasswordChar = false;
            txtPasswordagain.PasswordChar = '\0';
            focusdot2.Focus();
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {

            button1.BackgroundImage = Resources.eyeClose_removebg_preview;
            txtPasswordagain.UseSystemPasswordChar = true;
            txtPasswordagain.PasswordChar = '●';
            focusdot2.Focus();
        }


        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != string.Empty)
            {
                button4.Visible = true;
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.PasswordChar = '●';
                button4.BackgroundImage = Resources.eyeClose_removebg_preview;
            }
            else
                button4.Visible = false;
        }

        private void txtPasswordagain_TextChanged(object sender, EventArgs e)
        {
            if (txtPasswordagain.Text != string.Empty)
            {
                button1.Visible = true;
                txtPasswordagain.UseSystemPasswordChar = true;
                txtPasswordagain.PasswordChar = '●';
                button1.BackgroundImage = Resources.eyeClose_removebg_preview;
            }
            else
                button1.Visible = false;
        }
    }
}
