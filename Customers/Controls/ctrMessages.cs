using Microsoft.AspNet.SignalR.Messaging;
using OnlineStoreBusiness;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace Online_Store_Project
{
    public partial class ctrMessages : UserControl
    {
        private DataTable _dtAllMessages;
        private DataTable _dtResponses;
        private int spacing = 20;
        private int _CustomerID;
        private enum enMode { LoadMessages=1,LoadResponses=2};
        private enMode _Mode;
        public ctrMessages(DataTable dtMessages)
        {
            InitializeComponent();
            _Mode = enMode.LoadMessages;
            _dtAllMessages = dtMessages;
        }
        public ctrMessages(int CustomerID)
        {
            InitializeComponent();
            _CustomerID = CustomerID;
            _Mode = enMode.LoadResponses;
        }
        
     
        private List<ctrResponse> _LoadResponses(DataTable dataTable)
        {
            ctrResponse response;
            ConcurrentBag<ctrResponse> responses = new ConcurrentBag<ctrResponse>();
            //Parallel.ForEach(dataTable.AsEnumerable(), drow =>
            foreach(DataRow drow in dataTable.Rows)
            {
                response = new ctrResponse((int)drow["ResponseID"]);
                response.Margin = new Padding(spacing);
                response.Width = 1141;
                responses.Add(response);
            }
            return responses.ToList();
        }
        private void _DisplayResponses(List<ctrResponse> responses)
        {
            foreach (ctrResponse response in responses)
            {
                MessagesContainer.Controls.Add(response);
            }
            if (MessagesContainer.Controls.Count == 0)
            {
                MessagesContainer.Visible = false;
                lbNoMessages.Visible = true;
            }
            else
            {
                MessagesContainer.Visible = true;
                lbNoMessages.Visible = false;
            }
        }
        private List<ctrMessage> _LoadMessages(DataTable dataTable)
        {
            ctrMessage message;

            ConcurrentBag<ctrMessage> messages = new ConcurrentBag<ctrMessage>();
            //Parallel.ForEach(dataTable.AsEnumerable(), drow =>
            foreach (DataRow drow in dataTable.Rows)
            {
                message = new ctrMessage((int)drow["MessageID"]);
                message.Margin = new Padding(spacing);
                message.Width = 1141;
               // message.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                messages.Add(message);
            }
            return messages.ToList();
        }
        private void _DisplayMessages(List<ctrMessage> messages)
        {
            foreach (ctrMessage message in messages)
            {
                MessagesContainer.Controls.Add(message);
            }
            if (MessagesContainer.Controls.Count == 0)
            {
                MessagesContainer.Visible = false;
                lbNoMessages.Visible = true;
            }
            else
            {
                MessagesContainer.Visible = true;
                lbNoMessages.Visible = false;
            }
        }
        private void ctrMessages_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.LoadMessages)
            {
                _DisplayMessages(_LoadMessages(_dtAllMessages));
            }
            else
            {
                _dtResponses = clsResponse.GetResponsesForCustomerID(_CustomerID);
                _DisplayResponses(_LoadResponses(_dtResponses));
            }
            
        }
    }
}
