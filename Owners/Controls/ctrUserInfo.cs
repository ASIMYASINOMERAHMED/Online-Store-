using Online_Store_Project.Properties;
using OnlineStoreBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Store_Project
{
    public partial class ctrUserInfo : UserControl
    {
        private int _CustomerID;
        private clsUser _Customer;
        private bool _EditVisible;
        public ctrUserInfo(int CustomerID)
        {
            InitializeComponent();
            _CustomerID = CustomerID;
        }

        public bool EditVisible
        {
            get
            {
                return _EditVisible;
            }
            set
            {
                _EditVisible = value;
                llEditInfo.Visible = _EditVisible;
                llAddManager.Visible = _EditVisible;
            }
        }
        private void ctrUserInfo_Load(object sender, EventArgs e)
        {
            _Customer = clsUser.Find(_CustomerID);
            if( _Customer == null )
            {
                MessageBox.Show("User has been deleted.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            _FillUserInfo();
        }
        private void _FillUserInfo()
        {
            lbUserID.Text = _Customer.UserID.ToString();
            lbUserName.Text = _Customer.UserName.ToString();
            lbEmail.Text = _Customer.Email.ToString();
            lbPhone.Text = _Customer.Phone.ToString();
            lbAddress.Text = _Customer.Address.ToString();
            lbCustomerName.Text = _Customer.Name.ToString();
            llEditInfo.Enabled = true;
            llAddManager.Enabled = true;
            _LoadUserImage();
        }
        private void _LoadUserImage()
        {
         
            string ImagePath = _Customer.ImageURL;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    Userpic.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

      

        private void llEditInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditUser addEditUser = new frmAddEditUser(_CustomerID);
            addEditUser.DataBack += AddEditUser_DataBack;
            addEditUser.ShowDialog();
        }

        private void AddEditUser_DataBack(object sender, int UserID)
        {
            ctrUserInfo_Load(null, null);
        }

        private void llAddManager_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditUser addEditUser = new frmAddEditUser();
            addEditUser.DataBack += AddEditUser_DataBack;
            addEditUser.ShowDialog();
        }
    }
}
