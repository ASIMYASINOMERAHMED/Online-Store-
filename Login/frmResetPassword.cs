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
    public partial class frmResetPassword : Form
    {
        private clsUser _User;
        private clsShippers _Shipper;
        public frmResetPassword()
        {
            InitializeComponent();
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
            if (!clsUser.IsUserExist(txtUserName.Text.Trim())&&!clsShippers.IsUserExist(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "UserName is not Exists!");

            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
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

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
            if (txtConfirmPassword.Text.Trim()!= txtPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password does not Match!!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _User = clsUser.Find(txtUserName.Text.Trim());
            if (_User == null)
            {
                _Shipper = clsShippers.FindByUserName(txtUserName.Text.Trim());
                if (_Shipper == null)
                {
                    MessageBox.Show("User has been deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _Shipper.Password = clsGlobal.ComputeHash(txtPassword.Text.Trim());
                try
                {
                    if (_Shipper.Save())
                    {
                        MessageBox.Show("Password Updated Succussfully.", "Succuss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Unable to Update Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An Error Occurred {ex.Message}");
                }
            }
            else
            {
                _User.Password = clsGlobal.ComputeHash(txtPassword.Text.Trim());
                try
                {
                    if (_User.Save())
                    {
                        MessageBox.Show("Password Updated Succussfully.", "Succuss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Unable to Update Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"An Error Occurred {ex.Message}");
                }
            }

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
            txtConfirmPassword.UseSystemPasswordChar = false;
            txtConfirmPassword.PasswordChar = '\0';
            focusdot2.Focus();
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {

            button1.BackgroundImage = Resources.eyeClose_removebg_preview;
            txtConfirmPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.PasswordChar = '●';
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

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text != string.Empty)
            {
                button1.Visible = true;
                txtConfirmPassword.UseSystemPasswordChar = true;
                txtConfirmPassword.PasswordChar = '●';
                button1.BackgroundImage = Resources.eyeClose_removebg_preview;
            }
            else
                button1.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
