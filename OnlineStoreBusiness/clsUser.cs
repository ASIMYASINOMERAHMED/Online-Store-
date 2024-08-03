using OnlineStoreDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OnlineStoreBusiness
{
    public class clsUser
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool IsOnwer { set; get; }
        public string ImageURL { set; get; }
        public enum enMode { AddNew =1,Update =2}
        public enMode Mode;
        public clsUser(int UserID,string Name, string Email, string Phone, string Address, string UserName, string Password, bool isOnwer,string ImageURL)
        {
            this.UserID = UserID;
            this.Name = Name;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.UserName = UserName;
            this.Password = Password;
            this.IsOnwer = isOnwer;
            this.ImageURL = ImageURL;
            Mode = enMode.Update;
        }
        public clsUser()
        {
            this.UserID = -1;
            this.Name = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.UserName = "";
            this.Password = "";
            this.IsOnwer = false;
            this.ImageURL = "";
            Mode = enMode.AddNew;
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(this.Name,this.Email,this.Phone,this.Address,this.UserName,this.Password,this.IsOnwer,this.ImageURL);
            return (this.UserID != -1);
        }
        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(this.UserID,this.Name,this.Email,this.Phone,this.Address,this.UserName,this.Password,this.IsOnwer,this.ImageURL);
        }
        public static bool Delete(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }
        public bool Delete()
        {
            return clsUserData.DeleteUser(this.UserID);
        }
        public static clsUser Find(int UserID)
        {
            string Name = "", Email = "", Phone = "", Address = "", UserName = "", Password = "",ImageURL="";
            bool IsOwner = false;
            if(clsUserData.FindUserByID(UserID,ref Name,ref Email,ref Phone,ref Address,ref UserName,ref Password,ref IsOwner,ref ImageURL))
                return new clsUser(UserID,Name,Email,Phone,Address,UserName,Password,IsOwner,ImageURL);
            else
                return null;
        }
        public static clsUser Find(string UserName)
        {
            string Name = "", Email = "", Phone = "", Address = "", Password = "", ImageURL = "";
            int UserID = -1;
            bool IsOwner = false;
            if (clsUserData.FindUserByUserName(UserName,ref UserID, ref Name, ref Email, ref Phone, ref Address, ref Password, ref IsOwner, ref ImageURL))
                return new clsUser(UserID, Name, Email, Phone, Address, UserName, Password, IsOwner, ImageURL);
            else
                return null;
        }

        public static clsUser Find(string UserName,string Password)
        {
            int UserID = -1;
            string Name = "", Email = "", Phone = "", Address = "",ImageURL="";
            bool IsOwner = false;
            if (clsUserData.FindUserByUserNamePassword(UserName,Password,ref UserID, ref Name, ref Email, ref Phone, ref Address,ref IsOwner,ref ImageURL))
                return new clsUser(UserID, Name, Email, Phone, Address, UserName, Password, IsOwner,ImageURL);
            else
                return null;
        }
        public static bool IsUserExist(string UserName)
        {
            return clsUserData.IsUserExist(UserName);
        }
        public static int GetCustomersCount()
        {
            return clsUserData.GetCustomersCount();
        }
        public static DataTable GetAllOwners()
        {
            return clsUserData.GetAllOwners();
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateUser();

            }

            return false;
        }
    }
}
