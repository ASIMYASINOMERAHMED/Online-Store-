using OnlineStoreDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreBusiness
{
    public class clsMessage
    {

        public int MessageID { get; set; }
        public int CustomerID { get; set; }
        public clsUser Customer;
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public enum enMode { AddNew=1,Update=2};
        public enMode Mode;
        public clsMessage(int MessageID,int CustomerID,string Message,DateTime dateTime)
        {
            this.MessageID = MessageID;
            this.CustomerID = CustomerID;
            this.Customer = clsUser.Find(CustomerID);
            this.Message = Message;
            this.DateTime = dateTime;
            Mode = enMode.Update;
        }
        public clsMessage()
        {
            this.MessageID = -1;
            this.CustomerID = -1;
            this.Message = "";
            this.DateTime = DateTime.Now;
            Mode = enMode.AddNew;
        }

        private bool _AddNewMessage()
        {
            this.MessageID = clsMessageData.AddNewMessage(this.CustomerID,this.Message,this.DateTime);
            return this.MessageID != -1;
        }
        private bool _UpdateMessage()
        {
            return clsMessageData.UpdateMessage(this.MessageID, this.Message);
        }
        public bool DeleteMessage()
        {
            return clsMessageData.DeleteMessage(this.MessageID);
        }
        public static clsMessage Find(int MessageID)
        {
            int CustomerID = -1;
            string Message = "";
            DateTime dateTime = DateTime.Now;
            if(clsMessageData.FindMessageByID(MessageID,ref CustomerID,ref Message,ref dateTime))
                return new clsMessage(MessageID,CustomerID,Message,dateTime);
            else
                return null;
        }
        public static DataTable GetAllMessages()
        {
            return clsMessageData.GetAllMessages();
        }
        public static DataTable GetAllMessagesForCustomerID(int CustomerID)
        {
            return clsMessageData.GetAllMessagesForCustomerID(CustomerID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewMessage())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateMessage();

            }

            return false;
        }
    }
}
