using Online_Store_Project.Properties;
using OnlineStoreBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Store_Project
{
    public partial class ctrMessage : UserControl
    {
        private int _MessageID;
        private clsMessage _Message;
        public bool _ReplayButtonVisiable;
        public ctrMessage(int MessageID)
        {
            InitializeComponent();
            _MessageID = MessageID;
        }
        public bool ReplayButtonVisiable
        {
            get { return _ReplayButtonVisiable; }
            set
            {
                _ReplayButtonVisiable = value;
                btnReplayToCustomer.Visible = _ReplayButtonVisiable;
            }
        }
  
        private void ctrMessage_Load(object sender, EventArgs e)
        {
            _Message = clsMessage.Find(_MessageID);
            if( _Message == null )
            {
                MessageBox.Show("Message has been deleted.","Erorr",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            lbDateTime.Text = _Message.DateTime.ToString();
            lbMessage.Text = _Message.Message;
            ToolTip1.SetToolTip(lbMessage,lbMessage.Text);
            lbName.Text = _Message.Customer.Name;
            if (_Message.Customer.ImageURL != null || _Message.Customer.ImageURL != "")
                picCustomer.ImageLocation = _Message.Customer.ImageURL;
            else
                picCustomer.Image = Resources.PersonEmptyPhoto;
           
        }

  

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            frmReplyToCustomer replyToCustomer = new frmReplyToCustomer(_Message.Customer.UserID, _MessageID);
            replyToCustomer.StartPosition = FormStartPosition.CenterScreen;
            replyToCustomer.ShowDialog();
        }
    }
}
