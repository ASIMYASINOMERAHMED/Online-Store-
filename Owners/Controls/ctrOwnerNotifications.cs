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
    public partial class ctrOwnerNotifications : UserControl
    {
        private DataTable _dtNotifications;
        private DataTable _dtMessages;

        private int spacing = 10;
        public ctrOwnerNotifications()
        {
            InitializeComponent();
        }
        private ConcurrentBag<ctrMessage> _LoadMessages(DataTable dataTable)
        {
            ctrMessage message;

            ConcurrentBag<ctrMessage> messages = new ConcurrentBag<ctrMessage>();
            // Parallel.ForEach(dataTable.AsEnumerable(), drow =>
            foreach (DataRow drow in dataTable.Rows)
            {
                message = new ctrMessage((int)drow["MessageID"]);
                message.Margin = new Padding(spacing);
                message.Width = 1141;
                messages.Add(message);
            }
            return messages;
        }
        private void _DisplayMessages(ConcurrentBag<ctrMessage> messages)
        {
        
                NotificationsContainer.Controls.AddRange(messages.ToArray());
        }

        private ConcurrentBag<ctrOwnerNotification> _LoadNotifictions(DataTable dataTable)
        {
            ctrOwnerNotification notification;
            ConcurrentBag<ctrOwnerNotification> notifications = new ConcurrentBag<ctrOwnerNotification>();
       //     Parallel.ForEach(dataTable.AsEnumerable(), drow =>
            foreach(DataRow drow in dataTable.Rows)
            {
                notification = new ctrOwnerNotification((int)drow["NoticficationID"]);
                notification.Margin = new Padding(spacing);
                notification.Width = 1141;
                notifications.Add(notification);
            }
            return notifications;
        }
        private void _DisplayNotifications(ConcurrentBag<ctrOwnerNotification> notifications)
        {

                NotificationsContainer.Controls.AddRange(notifications.ToArray());
        }
        private void ctrOwnerNotifications_Load(object sender, EventArgs e)
        {
            _dtMessages = clsMessage.GetAllMessages();
            _dtNotifications = clsNotificationOwner.GetAllOwnerNotifications();
            _DisplayMessages(_LoadMessages(_dtMessages));
            _DisplayNotifications(_LoadNotifictions(_dtNotifications));

        }
    }
}
