using OnlineStoreDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreBusiness
{
    public class clsShippers
    {
        public int CarrierID { get; set; }
        public string CarrierName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public enum enMode { AddNew=1,Update=2};
        public enMode Mode;
        public clsShippers(int CarrierID,string CarrierName,string Email,string Phone,string UserName,string Password)
        {
            this.CarrierID = CarrierID;
            this.CarrierName = CarrierName;
            this.Email = Email;
            this.Phone = Phone;
            this.UserName = UserName;
            this.Password = Password;
            Mode = enMode.Update;
        }
        public clsShippers()
        {
            this.CarrierID = -1;
            this.CarrierName = "";
            this.Email = "";
            this.Phone = "";
            this.UserName = "";
            this.Password = "";
            Mode = enMode.AddNew;
        }

        private bool _AddNewShipper()
        {
            this.CarrierID = clsShippersData.AddNewShipper(this.CarrierName, this.Email, this.Phone, this.UserName, this.Password);
            return (this.CarrierID!=-1);
        }
        private bool _UpdateShipper()
        {
            return clsShippersData.UpdateShipper(this.CarrierID,this.CarrierName,this.Email,this.Phone,this.UserName,this.Password);
        }
        public static bool DeleteShipper(int CarrierID)
        {
            return clsShippersData.DeleteShipper(CarrierID);
        }
        public bool DeleteShipper()
        {
            return clsShippersData.DeleteShipper(this.CarrierID);
        }
        public static clsShippers Find(int CarrierID)
        {
            string CarrierName = "", Email = "", Phone = "", UserName = "", Password = "";
            if(clsShippersData.FindShipperByID(CarrierID,ref CarrierName,ref Email,ref Phone,ref UserName,ref Password))
                return new clsShippers(CarrierID,CarrierName,Email,Phone,UserName,Password);
            else
                return null;
        }
        public static clsShippers Find(string CarrierName)
        {
            int CarrierID = -1;
            string Email = "", Phone = "", UserName = "", Password = "";
            if (clsShippersData.FindShipperByName(CarrierName, ref CarrierID, ref Email, ref Phone, ref UserName, ref Password))
                return new clsShippers(CarrierID, CarrierName, Email, Phone, UserName, Password);
            else
                return null;
        }
        public static clsShippers FindByUserName(string UserName)
        {
            int CarrierID = -1;
            string Email = "", Phone = "", CarrierName = "", Password = "";
            if (clsShippersData.FindShipperByUserName(UserName, ref CarrierName, ref CarrierID, ref Email, ref Phone, ref Password))
                return new clsShippers(CarrierID, CarrierName, Email, Phone, UserName, Password);
            else
                return null;
        }
        public static clsShippers Find(string UserName,string Password)
        {
            int CarrierID = -1;
            string CarrierName = "", Email = "", Phone = "";
            if (clsShippersData.FindShipperByUserNamePassword(UserName,Password,ref CarrierID,ref CarrierName,ref Email,ref Phone))
                return new clsShippers(CarrierID, CarrierName, Email, Phone, UserName, Password);
            else
                return null;
        }
        public static bool IsUserExist(string UserName)
        {
            return clsShippersData.IsUserExist(UserName);
        }
        public static DataTable GetAllShippersName()
        {
            return clsShippersData.GetAllShippersName();
        }
        public static DataTable GetAllShipperData()
        {
            return clsShippersData.GetAllShippersData();
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewShipper())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateShipper();

            }

            return false;
        }
    }
}
