using OnlineStoreDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreBusiness
{
    public class clsShipping
    {
        public int ShippingID { get; set; }
        public int OrderID { get; set; }
        public clsOrder Order { get; set; }
        public int CarrierID { get; set; }
        public clsShippers Carrier { get; set; }
        public string TrackingNumber { get; set; }
        public enum enShippingStatus { Pendding=1,Delivered=5,Canceled=6};
        public enShippingStatus Status { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }
        public enum enMode {AddNew=1,Update =2};
        public enMode Mode;
        public clsShipping(int ShippingID,int OrderID,int CarrierID,string TrackingNumber,enShippingStatus Status,DateTime EstimatedDeliveryDate,DateTime? ActualDeliveryDate)
        {
            this.ShippingID = ShippingID;
            this.OrderID = OrderID;
            this.Order = clsOrder.Find(OrderID);
            this.CarrierID = CarrierID;
            this.Carrier = clsShippers.Find(CarrierID);
            this.TrackingNumber = TrackingNumber;
            this.Status = Status;
            this.EstimatedDeliveryDate = EstimatedDeliveryDate;
            this.ActualDeliveryDate = ActualDeliveryDate;
            Mode = enMode.Update;
        }
        public clsShipping()
        {
            this.ShippingID = -1;
            this.OrderID = -1;
            this.CarrierID = -1;
            this.TrackingNumber = "";
            this.Status = enShippingStatus.Pendding;
            this.EstimatedDeliveryDate = DateTime.Now;
            this.ActualDeliveryDate = DateTime.Now;
            Mode = enMode.AddNew;
        }
        private bool _AddNewShipping()
        {
            this.ShippingID = clsShippingData.AddNewShipping(this.OrderID, this.CarrierID, this.TrackingNumber,(short)this.Status,this.EstimatedDeliveryDate,this.ActualDeliveryDate);
            return (this.ShippingID != -1);
        }
        private bool _UpdateShipping()
        {
            return clsShippingData.UpdateShipping(this.ShippingID, this.OrderID, this.CarrierID, this.TrackingNumber,(short)this.Status, this.EstimatedDeliveryDate, this.ActualDeliveryDate);
        }
        public static bool Delete(int ShippingID)
        {
            return clsShippingData.DeleteShipping(ShippingID);
        }
        public bool Delete()
        {
            return clsShippingData.DeleteShipping(this.ShippingID);
        }
        public static clsShipping Find(int ShippingID)
        {
            int OrderID = -1, CarrierID = -1;
            short Status = 0;
            string TrackingNumber = "";
            DateTime EstimatedDeliveryDate = DateTime.Now;
            DateTime? ActualDeliveryDate = DateTime.Now;
            if (clsShippingData.FindShippingByID(ShippingID, ref OrderID, ref CarrierID, ref TrackingNumber, ref Status, ref EstimatedDeliveryDate, ref ActualDeliveryDate))
                return new clsShipping(ShippingID, OrderID, CarrierID, TrackingNumber,(enShippingStatus)Status, EstimatedDeliveryDate, ActualDeliveryDate);
            else
                return null;
        }
        public static clsShipping Find(string TrackingNumber)
        {
            int OrderID = -1, CarrierID = -1,ShippingID=-1;
            short Status = 0;
            DateTime EstimatedDeliveryDate = DateTime.Now;
            DateTime? ActualDeliveryDate = DateTime.Now;
            if (clsShippingData.FindShippingByTrackingNumber(TrackingNumber, ref OrderID, ref CarrierID, ref ShippingID, ref Status, ref EstimatedDeliveryDate, ref ActualDeliveryDate))
                return new clsShipping(ShippingID, OrderID, CarrierID, TrackingNumber, (enShippingStatus)Status, EstimatedDeliveryDate, ActualDeliveryDate);
            else
                return null;
        }
        public static DataTable GetAllShippingsForCarrierID(int CarrierID)
        {
            return clsShippingData.GetAllShippingsForCarrierID(CarrierID);
        }
        public static DataTable GetAllDeliveredShippingsForCarrierID(int CarrierID)
        {
            return clsShippingData.GetAllDeliveredShippingsForCarrierID(CarrierID);
        }
        public static DataTable GetAllShippings()
        {
            return clsShippingData.GetAllShippings();
        }
        public bool DeliverOrder()
        {
            this.Status = enShippingStatus.Delivered;
            this.ActualDeliveryDate = DateTime.Now;
            return this.Save() ? true : false;

        }
        public bool CancelOrder()
        {
            this.Status = enShippingStatus.Canceled;
            return this.Save() ? true : false;
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewShipping())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateShipping();

            }

            return false;
        }
    }
}
