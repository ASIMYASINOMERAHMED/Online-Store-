using FastReport.DataVisualization.Charting;
using Guna.UI2.WinForms;
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
    public partial class frmAddUpdateCustomer : Form
    {
        private clsUser _Customer;
        private int _CustomerID;
        private string _selectedFilePath;
        private enum enMode { AddNew=1,Update=2};
        private enMode _Mode;
        public frmAddUpdateCustomer()
        {
            InitializeComponent();
            _Customer = new clsUser();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateCustomer(int CustomerID)
        {
            InitializeComponent();
            _CustomerID = CustomerID;
            _Mode = enMode.Update;
        }

        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values

            if (_Mode == enMode.AddNew)
            {
                _Customer = new clsUser();
            }

            txtAddress.Text = "";
            txtEmail.Text = "";
            txtName.Text = "";
            txtPassword.Text = "";
            txtPasswordagain.Text = "";
            txtPhone.Text = "";
            txtUserName.Text = "";
            picUser.Image = Resources.PersonEmptyPhoto;
        }
        private void _LoadData()
        {
            _Customer = clsUser.Find(_CustomerID);
            if (_Customer == null)
            {
                MessageBox.Show("This Form Will Be Closed Because Customer with ID " + _CustomerID + " is Deleted");
                this.Close();
                return;
            }

            txtAddress.Text = _Customer.Address;
            txtEmail.Text = _Customer.Email;
            txtName.Text = _Customer.Name;
            //txtPassword.Text = _Customer.Password;
            //txtPasswordagain.Text = _Customer.Password;
            txtPhone.Text = _Customer.Phone;
            txtUserName.Text = _Customer.UserName;
            if (_Customer.ImageURL == "" || _Customer.ImageURL == null)
                picUser.Image = Resources.PersonEmptyPhoto; 
            else
            {
                picUser.ImageLocation = _Customer.ImageURL;
                llRemove.Visible = true;
            }
            this.Text = "Update Information";
            gbCustomerInfo.Text = "Update Info";
            gbCustomerInfo.Height = 739;
            this.Height = 924;
        }
        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llChooseImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                 _selectedFilePath = openFileDialog1.FileName;
                //MessageBox.Show("Selected Image is:" + selectedFilePath);

                picUser.Load(_selectedFilePath);
                llRemove.Visible = true;
            }
        }

        private void llRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            picUser.ImageLocation = null;
            picUser.Image = Resources.PersonEmptyPhoto;

            llRemove.Visible = false;
        }
        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {

            // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 
            Guna2TextBox Temp = ((Guna2TextBox)sender);
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
            if (txtUserName.Text.Trim() != _Customer.UserName && clsUser.IsUserExist(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "UserName is used for another User!");

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
                    //e.Cancel = true;
                    //errorProvider.SetError(CTBFirstName, null);
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
            _Customer.Name = txtName.Text.Trim();
            _Customer.Address = txtAddress.Text.Trim();
            _Customer.Email = txtEmail.Text.Trim();
            if (_selectedFilePath != null)
                _Customer.ImageURL = _selectedFilePath;
            else
                _Customer.ImageURL = picUser.ImageLocation;
            _Customer.Phone = txtPhone.Text.Trim();
            _Customer.UserName = txtUserName.Text.Trim();
            if(_Mode == enMode.AddNew)
                _Customer.Password = clsGlobal.ComputeHash(txtPassword.Text.Trim());
            try
            {
                if (_Customer.Save())
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

        private void frmSignUp_Load(object sender, EventArgs e)
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
