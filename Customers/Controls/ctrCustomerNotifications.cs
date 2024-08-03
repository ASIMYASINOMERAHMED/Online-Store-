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

namespace Online_Store_Project
{
    public partial class ctrCustomerNotifications : UserControl
    {
        private DataTable _dtResponses;
        private int spacing = 10;
        private int _CustomerID;
        private DataTable _dtNotifications;
        public ctrCustomerNotifications(int customerID,DataTable CustomerNotifications)
        {
            InitializeComponent();
            _CustomerID = customerID;
            _dtNotifications = CustomerNotifications;
        }

        public EventHandler ShowCategories;

        private List<ctrResponse> _LoadResponses(DataTable dataTable)
        {
            ctrResponse response;
            ConcurrentBag<ctrResponse> responses = new ConcurrentBag<ctrResponse>();
            //Parallel.ForEach(dataTable.AsEnumerable(), drow =>
            foreach (DataRow drow in dataTable.Rows)
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
                NotificationsPanel.Controls.Add(response);
            }
        }

        private List<ctrCustomerNotification> _LoadNotifictions(DataTable dataTable)
        {
            ctrCustomerNotification notification;
            ConcurrentBag<ctrCustomerNotification> notifications = new ConcurrentBag<ctrCustomerNotification>();
           // Parallel.ForEach(dataTable.AsEnumerable(), drow =>
            foreach(DataRow drow in dataTable.Rows)
            {
                notification = new ctrCustomerNotification((int)drow["NotificationID"]);
                notification.Margin = new Padding(spacing);
                notification.Width = 1141;
                notification.ShowCategories += CtrNotification_ShowCategories;
                notifications.Add(notification);
            }
            return notifications.ToList();
        }
        private void CtrNotification_ShowCategories(object sender, EventArgs e)
        {
            ShowCategories.Invoke(this, EventArgs.Empty);
        }
        private void _DisplayNotifications(List<ctrCustomerNotification> notifications)
        {
            foreach (ctrCustomerNotification notification in notifications)
            {
                NotificationsPanel.Controls.Add(notification);
            }
        }
        private void ctrCustomerNotifications_Load(object sender, EventArgs e)
        {
            _dtResponses = clsResponse.GetResponsesForCustomerID(_CustomerID);
            _DisplayResponses(_LoadResponses(_dtResponses));
            _DisplayNotifications(_LoadNotifictions(_dtNotifications));
        }
    }
}
