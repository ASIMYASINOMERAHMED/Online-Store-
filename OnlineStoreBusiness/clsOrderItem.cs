using OnlineStoreDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreBusiness
{
    public class clsOrderItem
    {
        public int OrderID { get; set; }
        public clsOrder Order;
        public int ProductID { get; set; }
        public clsProductCatalog Product;
        public int Quantity { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public decimal TotalItemsPrice { get; set; }
        public enum enMode { AddNew=1,Update=2}
        public enMode Mode;

        public clsOrderItem(int OrderID,int ProductID, int Quantity, decimal Price, decimal TotalItemsPrice, string color, string size)
        {
            this.OrderID = OrderID;
            this.Order = clsOrder.Find(OrderID);
            this.ProductID = ProductID;
            this.Product = clsProductCatalog.Find(ProductID);
            this.Quantity = Quantity;
            this.Price = Price;
            this.TotalItemsPrice = TotalItemsPrice;
            this.Color = color;
            this.Size = size;
            Mode = enMode.Update;
    
        }
        public clsOrderItem()
        {
            this.OrderID = -1;
            this.ProductID = -1;
            this.Quantity = 0;
            this.Price = 0;
            this.TotalItemsPrice = 0;
            this.Color = "";
            this.Size = "";
            Mode = enMode.AddNew;
        }
        private bool _AddNewOrderItem()
        {
            return clsOrderItemsData.AddNewOrderItem(this.OrderID,this.ProductID, this.Quantity,this.Color,this.Size, this.Price, this.TotalItemsPrice);
        }
        private bool _UpdateOrderItem()
        {
            return clsOrderItemsData.UpdateOrderItem(this.OrderID, this.ProductID, this.Quantity,this.Color,this.Size, this.Price, this.TotalItemsPrice);
        }
        public static clsOrderItem Find(int OrderID,int ProductID)
        {
            int Quantity = 0;
            decimal Price = 0;
            decimal TotalItemsPrice = 0;
            string Color = "";
            string Size = "";
            if(clsOrderItemsData.FindOrderItemByOrderIDAndProductID(OrderID,ProductID,ref Quantity,ref Color,ref Size,ref Price,ref TotalItemsPrice))
                return new clsOrderItem(OrderID,ProductID,Quantity,Price,TotalItemsPrice,Color,Size);
            else
                return null;
        }
        public bool Delete()
        {
            return clsOrderItemsData.DeleteOrderItem(this.ProductID);
        }
        public static bool Delete(int ProductID)
        {
            return clsOrderItemsData.DeleteOrderItem(ProductID);
        }
        public static DataTable GetAllOrderItems(int OrderID)
        {
            return clsOrderItemsData.GetAllOrderItems(OrderID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewOrderItem())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateOrderItem();

            }

            return false;
        }

    }
}
