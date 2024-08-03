using OnlineStoreDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreBusiness
{
    public class clsResponse
    {
        public int ResponseID { get; set; }
        public int OwnerID { get; set; }
        public clsUser Owner;
        public string Name { get; set; }
        public string Response { get; set; }
        public int MessageID { get; set; }
        public clsMessage Message { get; set; }
        public DateTime DateTime { get; set; }
        public int CustomerID { get; set; }
        public enum enMode { AddNew = 1, Update = 2 };
        public enMode Mode;
        public clsResponse(int ResponseID, int OwnerID,string Name, string Response, int MessageID, DateTime dateTime, int customerID)
        {
            this.MessageID = MessageID;
            this.OwnerID = OwnerID;
            this.Owner = clsUser.Find(OwnerID);
            this.Response = Response;
            this.Name = Name;
            this.DateTime = dateTime;
            this.CustomerID = customerID;
            this.Message = clsMessage.Find(MessageID);
            Mode = enMode.Update;
        }
        public clsResponse()
        {
            this.MessageID = -1;
            this.OwnerID = -1;
            this.Response = "";
            this.Name = "";
            this.DateTime = DateTime.Now;
            this.CustomerID = -1;
            Mode = enMode.AddNew;

        }

        private bool _AddNewResponse()
        {
            this.ResponseID = clsResponseData.AddNewResponse(this.OwnerID,this.Name,this.Response,this.MessageID,this.DateTime,this.CustomerID);
            return this.ResponseID != -1;
        }
        private bool _UpdateResponse()
        {
            return clsResponseData.UpdateResponse(this.ResponseID,this.Response);
        }
        public bool DeleteResponse()
        {
            return clsResponseData.DeleteResponse(this.ResponseID);
        }
        public static clsResponse Find(int ResponseID)
        {
               int  MessageID = -1;
               int OwnerID = -1,CustomerID=-1;
               string  Response = "", Name = "";
               DateTime DateTime = DateTime.Now;
                
            if (clsResponseData.FindResponseByID(ResponseID, ref OwnerID,ref Name, ref MessageID,ref Response, ref DateTime,ref CustomerID))
                return new clsResponse(ResponseID,OwnerID,Name,Response,MessageID,DateTime,CustomerID);
            else
                return null;
        }
        public static DataTable GetResponsesForCustomerID(int CustomerID)
        {
            return clsResponseData.GetResponsesForCustomerID(CustomerID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewResponse())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateResponse();

            }

            return false;
        }
    }
}
