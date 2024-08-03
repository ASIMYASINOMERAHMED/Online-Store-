using OnlineStoreDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreBusiness
{
    public class clsNotificationOwner
    {
        public int NotificationID { get; set; }
        public int NewCustomerID { get; set; }
        public int NewPaymentID { get; set; }
        public DateTime DateTime { get; set; }
        public clsNotificationOwner(int notificationID, int newCustomerID, int newPaymentID, DateTime dateTime)
        {
            NotificationID = notificationID;
            NewCustomerID = newCustomerID;
            NewPaymentID = newPaymentID;
            DateTime = dateTime;
        }

        public static DataTable GetAllOwnerNotifications()
        {
            return clsNotificationOwnerData.GetAllOwnerNotifications();
        }
        public static clsNotificationOwner Find(int notificationID)
        {
            int NewCustomerID = -1;
            int NewPaymentID = -1;
            DateTime dateTime = DateTime.Now;
            if(clsNotificationOwnerData.FindOwnerNotificationByID(notificationID,ref NewCustomerID,ref NewPaymentID,ref dateTime))
                return new clsNotificationOwner(notificationID,NewCustomerID,NewPaymentID,dateTime);
            else
                return null;    
        }

        public static DataTable GetChartData()
        {
            return clsNotificationOwnerData.GetChartData();
        }
        public static DataTable GetWeeklySales()
        {
            return clsNotificationOwnerData.GetWeeklySales();
        }
    }
}
