using Online_Store_Project.Properties;
using OnlineStoreBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Store_Project
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private string Credential1;
        private string Credential2;
   

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            btneye.BackgroundImage = Resources.eyePassword_removebg_preview;
            txtBoxPassword.UseSystemPasswordChar = false;
            txtBoxPassword.PasswordChar = '\0';
            FocusDot.Focus();
        }

  

        private void txtBoxPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxPassword.Text != string.Empty)
            {
                btneye.Visible = true;
                txtBoxPassword.UseSystemPasswordChar = true;
                txtBoxPassword.PasswordChar = '●';
                btneye.BackgroundImage = Resources.eyeClose_removebg_preview;
            }
            else
                btneye.Visible = false;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string Credential1 = "", Credential2 = "";
            if (clsGlobal.GetStoredCredentialFromRegistery(ref Credential1, ref Credential2))
            {
                txtBoxUserName.Text = Credential1;
                txtBoxPassword.Text = Credential2;
                txtBoxPassword.UseSystemPasswordChar = true;
                btneye.BackgroundImage = Resources.eyeClose_removebg_preview;
                ckbRememberme.Checked = true;
            }
            else
            {
                ckbRememberme.Checked = false;
            }
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            btneye.BackgroundImage = Resources.eyeClose_removebg_preview;
            txtBoxPassword.UseSystemPasswordChar = true;
            txtBoxPassword.PasswordChar = '●';
            FocusDot.Focus();
        }

    

       

        private async void btnLogin1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
         
            if (txtBoxUserName.Text == "UserName" || txtBoxPassword.Text == "Password")
            {
                lbError.Text = "Enter credentials!";
                lbError.Visible = true;
                SystemSounds.Hand.Play();
                Cursor = Cursors.Default;
                await Task.Delay(1500);
                lbError.Visible = false;
                return;
            }
            ProgressIndicator1.Start();
            ProgressIndicator1.Visible = true;
            Credential1 = txtBoxUserName.Text;
            Credential2 = txtBoxPassword.Text;
            clsUser User = clsUser.Find(Credential1.Trim(),clsGlobal.ComputeHash(Credential2.Trim()));
            if (User != null)
            {
                if (ckbRememberme.Checked)
                {
                    clsGlobal.RememberCredentialsInRegistry(Credential1.Trim(), Credential2.Trim());
                }
                else
                {
                    clsGlobal.RememberCredentialsInRegistry("", "");
                }
     
                if (User.IsOnwer)
                {
                    clsGlobal.CurrentUser = User;
               

                    frmOwnerDashboard frm = new frmOwnerDashboard(this);
                    await Task.Delay(2000);
                    ProgressIndicator1.AutoStart = false;
                    ProgressIndicator1.Visible = false;
                    this.Hide();
                    Cursor = Cursors.Default;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.ShowDialog();
                }
                else
                {
                    clsGlobal.CurrentUser = User;
           
   
                    frmCustomerScreen frm = new frmCustomerScreen(this);
                    await Task.Delay(2000);
                    ProgressIndicator1.AutoStart = false;
                    ProgressIndicator1.Visible = false;
                    this.Hide();
                    Cursor = Cursors.Default;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.ShowDialog();

                }

            }
            else
            {
                clsShippers shipper = clsShippers.Find(Credential1.Trim(), clsGlobal.ComputeHash(Credential2.Trim()));
                if (shipper != null)
                {
                    if (ckbRememberme.Checked)
                    {
                        clsGlobal.RememberCredentialsInRegistry(Credential1.Trim(), Credential2.Trim());
                    }
                    else
                    {
                        clsGlobal.RememberCredentialsInRegistry("", "");
                    }
                    ProgressIndicator1.AutoStart = true;
                    ProgressIndicator1.Visible = true;
                    clsGlobal.CurrentShipper = shipper;
                    frmShipping frm = new frmShipping(this);
                    await Task.Delay(2000);
                    ProgressIndicator1.AutoStart = false;
                    ProgressIndicator1.Visible = false;
                    this.Hide();
                    Cursor = Cursors.Default;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.ShowDialog();
                }
                else
                {
                    lbError.Text = "Wrong credentials!";
                    lbError.Visible = true;
                    SystemSounds.Hand.Play();
                    Cursor = Cursors.Default;
                    await Task.Delay(1500);
                    lbError.Visible = false;
                    return;
                }
            }
        }
   
   

        private bool _dragging = false;
        private Point _offset;
        private Point _start_point = new Point(0, 0);
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            frmAddUpdateCustomer signUp = new frmAddUpdateCustomer();
            signUp.ShowDialog();
        }

        private void ResetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmResetPassword frm = new frmResetPassword();
            frm.ShowDialog();
        }

        private void frmLogin_Activated(object sender, EventArgs e)
        {
            btnLogin1.Focus();
        }
    }
}
