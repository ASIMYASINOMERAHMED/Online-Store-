using OnlineStoreDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreBusiness
{
    public class clsOrder
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public clsUser Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public enum enOrderStatus { Pending=1, Processing=2,Compelete=3, Shipped=4, Delivered=5,Canceled=6 }
        public enOrderStatus OrderStatus;
        public enum enMode { AddNew=1,Update =2};
        public enMode Mode;

        public clsOrder(int OrderID,int CustomerID,DateTime OrderDate,decimal TotalAmount,enOrderStatus Status)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.Customer = clsUser.Find(CustomerID);
            this.OrderDate = OrderDate;
            this.TotalAmount = TotalAmount;
            this.OrderStatus = Status;
            Mode = enMode.Update;
        }

        public clsOrder()
        {
            this.OrderID = -1;
            this.CustomerID = -1;
            this.OrderDate = DateTime.Now;
            this.TotalAmount = 0;
            this.OrderStatus = enOrderStatus.Pending;
            Mode = enMode.AddNew;
        }

        private bool _AddNewOrder()
        {
            this.OrderID = clsOrderData.AddNewOrder(this.CustomerID,this.OrderDate,this.TotalAmount,(Int16)this.OrderStatus);
            return (this.OrderID != -1);
        }
        private bool _UpdateOrder()
        {
            return clsOrderData.UpdateOrder(this.OrderID,this.CustomerID,this.OrderDate, this.TotalAmount,(Int16)this.OrderStatus);
        }

        public bool Delete()
        {
            return clsOrderData.DeleteOrder(this.OrderID);
        }
        public bool Delete(int OrderID)
        {
            return clsOrderData.DeleteOrder(OrderID);
        }
        public static clsOrder Find(int OrderID)
        {
            int CustomerID = -1;
            DateTime OrderDate = DateTime.Now;
            decimal TotalAmount = 0;
            Int16 OrderStatus = 0;
            if (clsOrderData.FindOrderByID(OrderID, ref CustomerID, ref OrderDate, ref TotalAmount, ref OrderStatus))
                return new clsOrder(OrderID, CustomerID, OrderDate, TotalAmount,(enOrderStatus)OrderStatus);
            else
                return null;
        }
        public static DataTable GetAllOrdersForCustomerID(int CustomerID)
        {
            return clsOrderData.GetAllOrdersForCustomerID(CustomerID);
        }
        public static DataTable GetAllOrders()
        {
            return clsOrderData.GetAllOrders();
        }
        public static DataTable GetAllProcessingOrders()
        {
            return clsOrderData.GetAllProcessingOrders();
        }
        public static DataTable GetAllPendingOrders()
        {
            return clsOrderData.GetAllPendingOrders();
        }
        public static DataTable GetAllCompeleteOrders()
        {
            return clsOrderData.GetAllCompeleteOrders();
        }
        public static decimal GetTotalRevenue()
        {
            return clsOrderData.GetTotalRevenue();
        }
        public bool ProcessOrder()
        {
            bool StatusUpdated = clsOrderData.UpdatePendingOrderStatus(this.OrderID, (int)enOrderStatus.Processing);
            if (StatusUpdated)
                return clsOrderData.DeletePendingOrder(this.OrderID);
            else
                return false;
        }
        public bool CompeleteOrder()
        {
            bool StatusUpdated = clsOrderData.UpdateProcessingOrderStatus(this.OrderID, (int)enOrderStatus.Compelete);
            if (StatusUpdated)
                return clsOrderData.DeleteProcessingOrder(this.OrderID);
            else
                return false;
        }
        public static bool ProcessOrder(int OrderID)
        {
            bool StatusUpdated = clsOrderData.UpdatePendingOrderStatus(OrderID, (int)enOrderStatus.Processing);
            if (StatusUpdated)
                return clsOrderData.DeletePendingOrder(OrderID);
            else
                return false;
        }
        public static bool CompeleteOrder(int OrderID)
        {
            bool StatusUpdated = clsOrderData.UpdateProcessingOrderStatus(OrderID, (int)enOrderStatus.Compelete);
            if (StatusUpdated)
                return clsOrderData.DeleteProcessingOrder(OrderID);
            else
                return false;
        }
        public static bool OrderDelivered(int OrderID)
        {
            //Delete Order From Complete Order
            return clsOrderData.DeleteCompleteOrder(OrderID);
        }
        public static bool ProcessAllOrders()
        {
            return clsOrderData.ProcessAllOrders();
        }
        public static bool CompleteAllOrders()
        {
            return clsOrderData.CompleteAllOrders();
        }
        public static bool DeleteCompeleteOrder(int OrderID)
        {
            return clsOrderData.DeleteCompleteOrder(OrderID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewOrder())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateOrder();

            }

            return false;
        }
    }
}
