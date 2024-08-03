using OnlineStoreDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreBusiness
{
    public class clsProductImages
    {
        public int ID { get; set; }
        public string ImageUrl { get; set; }
        public int ProductID { get; set; }
        public short ImageOrder { set; get; }
        public clsProductCatalog Product { set; get; }
        public enum enMode { AddNew=1,Update=2};
        public enMode Mode;

        public clsProductImages(int ID,string ImageUrl,int ProductID,short ImageOrder)
        {
            this.ID = ID;
            this.ProductID = ProductID;
            this.Product = clsProductCatalog.Find(ProductID);
            this.ImageUrl = ImageUrl;
            this.ImageOrder = ImageOrder;
            Mode = enMode.Update;
        }
        public clsProductImages()
        {
            this.ID = -1;
            this.ProductID = -1;
            this.ImageUrl = "";
            this.ImageOrder = -1;
            Mode = enMode.AddNew;
        }

        private bool _AddNewProductImage()
        {
            this.ID = clsProductImagesData.AddNewProductImage(this.ImageUrl,this.ImageOrder,this.ProductID);
            return (this.ID != -1);
        }
        private bool _UpdateProductImage()
        {
            return clsProductImagesData.UpdateProductImage(this.ID,this.ImageUrl,this.ImageOrder,this.ProductID);
        }
        public static clsProductImages Find(int ID)
        {
            string ImageUrl = "";
            short ImageOrder = -1;
            int ProductID = -1;
            if (clsProductImagesData.FindProductImageByID(ID, ref ImageUrl, ref ImageOrder, ref ProductID))
                return new clsProductImages(ID, ImageUrl, ProductID, ImageOrder);
            else
                return null;
        }
        public static DataTable GetProductImages(int ProductID)
        {
            return clsProductImagesData.GetAllImagesForProductID(ProductID);
        }
        public bool Delete()
        {
            return clsProductImagesData.DeleteProductImage(this.ID);
        }
        public static bool Delete(int ID)
        {
            return clsProductImagesData.DeleteProductImage(ID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewProductImage())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateProductImage();

            }

            return false;
        }
    }
}
