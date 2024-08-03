using OnlineStoreBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Store_Project
{
    public partial class frmSendMessageToOwner : Form
    {
        private int _CustomerID;
        private clsUser _Customer;
        private clsMessage _Message;
        private NamedPipeClientStream pipeClient;
        public frmSendMessageToOwner(int customerID)
        {
            InitializeComponent();
            _CustomerID = customerID;
        }

        private void frmSendMessageToOwner_Load(object sender, EventArgs e)
        {
            _Customer = clsUser.Find(_CustomerID);
            if( _Customer == null )
            {
                 MessageBox.Show($"This Form Will Be Close, Because Customer With ID {_CustomerID} has been deleted.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            lbCustomerName.Text = _Customer.Name;
            lbGmail.Text = _Customer.Email;

        }
        public void InformOwner()
        {
            // Connect to the named pipe server
            pipeClient = new NamedPipeClientStream(".", "MessagePipe", PipeDirection.Out);
            pipeClient.Connect();

            // Send the  message to the server
            StreamWriter writer = new StreamWriter(pipeClient);
            string CustomerMessage = "Refresh"; 
            writer.Write(CustomerMessage);
            writer.Flush();

            // Close the named pipe client
            pipeClient.Close();
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text == string.Empty)
            {
                MessageBox.Show("Type Your Message.", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Message = new clsMessage();
            _Message.CustomerID = _CustomerID;
            _Message.Message = txtMessage.Text;
            _Message.DateTime = DateTime.Now;
            try
            {
                if (_Message.Save())
                {
                    InformOwner();
                    MessageBox.Show("Message Sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("Unable to send the Message.", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An Error Occurred {ex.Message}");
            }
        }
    }
}
