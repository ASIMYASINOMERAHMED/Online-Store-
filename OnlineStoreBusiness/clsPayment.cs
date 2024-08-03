using OnlineStoreDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreBusiness
{
    public class clsPayment
    {
        public int PaymentID { get; set; }
        public int OrderID { get; set; }
        public clsOrder Order;
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime TransactionDate { get; set; }
        public enum enMode { AddNew=1,Update=2}
        public enMode Mode;
        public clsPayment(int PaymentID,int OrderID,decimal Amount,string PaymentMethod,DateTime TransactionDate)
        {
            this.PaymentID = PaymentID;
            this.OrderID = OrderID;
            this.Order = clsOrder.Find(OrderID);
            this.Amount = Amount;
            this.PaymentMethod = PaymentMethod;
            this.TransactionDate = TransactionDate;
            Mode = enMode.Update;
        }
        public clsPayment()
        {
            this.PaymentID = -1;
            this.OrderID = -1;
            this.Amount = 0;
            this.PaymentMethod = "";
            this.TransactionDate = DateTime.Now;
            Mode = enMode.AddNew;
        }
        private  bool _AddNewPayment()
        {
            this.PaymentID = clsPaymentData.AddNewPayment(this.OrderID,this.Amount,this.PaymentMethod,this.TransactionDate);
            return (this.PaymentID != -1);
        }
        private bool _UpdatePayment()
        {
            return clsPaymentData.UpdatePayment(this.PaymentID,this.OrderID,this.Amount, this.PaymentMethod,this.TransactionDate);
        }
        public bool Delete()
        {
            return clsPaymentData.DeletePayment(this.PaymentID);
        }
        public static bool Delete(int PaymentID)
        {
            return clsPaymentData.DeletePayment(PaymentID);
        }
        public static clsPayment Find(int PaymentID)
        {
            int OrderID = -1;
            decimal Amount = 0;
            string PaymentMethod = "";
            DateTime TransactionDate = DateTime.Now;
            if(clsPaymentData.FindPaymentByID(PaymentID,ref OrderID,ref Amount,ref PaymentMethod,ref TransactionDate))
                return new clsPayment(PaymentID,OrderID,Amount,PaymentMethod,TransactionDate);
            else
                return null;
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPayment())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePayment();

            }

            return false;
        }

    }
}
