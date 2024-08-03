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
    public partial class frmMessages : Form
    {
        private int _CustomerID;
        private DataTable _dtMessages;
        private enum enMode { ShowAllMessages=1,ShowCustomerMessages=2};
        private enMode _Mode;

        public frmMessages(DataTable dtMessages)
        {
            InitializeComponent();
            _Mode = enMode.ShowAllMessages;
            _dtMessages = dtMessages;
        }
        public frmMessages(int CustomerID)
        {
            InitializeComponent();
            this._CustomerID = CustomerID;
            _Mode = enMode.ShowCustomerMessages;
        }

        private void frmMessages_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.ShowAllMessages)
            {
                ctrMessages Allmessages = new ctrMessages(_dtMessages);
                Allmessages.Dock = DockStyle.Bottom;
                Allmessages.Height = 600;
                this.Controls.Add(Allmessages);
                btnSend.Visible = false;
            }
            else
            {
                ctrMessages messages = new ctrMessages(_CustomerID);
                messages.Dock = DockStyle.Bottom;
                messages.Height = 600;
                this.Controls.Add(messages);
                btnSend.Visible = true;
            }
            ToolTip1.SetToolTip(btnSend, "Send Message...");
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            frmSendMessageToOwner frm = new frmSendMessageToOwner(_CustomerID);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }
    }
}
