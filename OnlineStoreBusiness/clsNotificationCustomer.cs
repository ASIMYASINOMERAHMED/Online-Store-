using OnlineStoreDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreBusiness
{
    public class clsNotificationCustomer
    {
        public int NotificationID { get; set; }
        public int NewProductID { get; set; }
        public int NewCategoryID { get; set; }
        public DateTime DateTime { get; set; }
        public clsNotificationCustomer(int notificationID, int newProductID, int newCategoryID,DateTime dateTime)
        {
           this.NotificationID = notificationID;
           this.NewProductID = newProductID;
           this.NewCategoryID = newCategoryID;
           this.DateTime = dateTime;
        }
        

        public static DataTable GetAllCustomerNotifications()
        {
            return clsNotificationCustomerData.GetAllCustomerNotifications();
        }
        public static clsNotificationCustomer Find(int notificationID)
        {
            int NewProductID=-1, NewCategoryID=-1;
            DateTime DateTime = DateTime.Now;
            if(clsNotificationCustomerData.FindCustomerNotificationByID(notificationID,ref  NewProductID,ref NewCategoryID,ref DateTime))
                return new clsNotificationCustomer(notificationID,NewProductID,NewCategoryID,DateTime);
            else 
                return null;
        }

    }
}
