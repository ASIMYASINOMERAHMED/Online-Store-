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
    public partial class frmReplyToCustomer : Form
    {
        private int _CustomerID;
        private clsUser _Customer;
        private clsResponse _Response;
        private int _MessageID;
        private NamedPipeClientStream pipeClient;
        public frmReplyToCustomer(int CustomerID,int MessageID)
        {
            InitializeComponent();
            _CustomerID = CustomerID;
            _MessageID = MessageID;
        }

        private void frmReplyToCustomer_Load(object sender, EventArgs e)
        {
            _Customer = clsUser.Find(_CustomerID);
            if( _Customer == null )
            {
                MessageBox.Show("This form will be closed because this Customer has been deleted.","Erorr",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            lbCustomerName.Text = _Customer.Name;
            lbGmail.Text = _Customer.Email;
        }
        public void InformCustomer()
        {
            try
            {
                // Connect to the named pipe server
                pipeClient = new NamedPipeClientStream(".", "ResponsePipe", PipeDirection.Out);
                pipeClient.Connect();

                // Send the message to the server
                StreamWriter writer = new StreamWriter(pipeClient);
                string customerMessage = "Refresh";
                writer.Write(customerMessage);
                writer.Flush();

                // Close the named pipe client
                pipeClient.Close();
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately (e.g., log the error, display an error message)
                Console.WriteLine("Error occurred during named pipe communication: " + ex.Message);
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtReply.Text == string.Empty)
            {
                MessageBox.Show("Type Your Response.", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Response = new clsResponse();
            _Response.DateTime = DateTime.Now;
            _Response.MessageID = _MessageID;
            _Response.OwnerID = clsGlobal.CurrentUser.UserID;
            _Response.Name = clsGlobal.CurrentUser.Name;
            _Response.Response = txtReply.Text;
            _Response.CustomerID = _CustomerID;
            try
            {
                if (_Response.Save())
                {
                    InformCustomer();
                    MessageBox.Show("Message Sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else MessageBox.Show("Unable to send Message.", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An Error Occurred {ex.Message}");
            }
        

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
