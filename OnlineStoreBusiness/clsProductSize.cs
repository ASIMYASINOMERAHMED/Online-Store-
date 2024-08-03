using OnlineStoreDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreBusiness
{
    public class clsProductSize
    {
        public int SizeID { get; set; }
        public string Size { set; get; }
        public int ProductID { get; set; }
        public clsProductCatalog Product { get; set; }

        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode;
        public clsProductSize(int SizeID, string Size, int productID)
        {
            this.SizeID = SizeID;
            this.Size = Size;
            this.ProductID = productID;
            this.Product = clsProductCatalog.Find(ProductID);
            Mode = enMode.Update;
        }
        public clsProductSize()
        {
            this.SizeID = -1;
            this.Size = "";
            this.ProductID = -1;
            Mode = enMode.AddNew;
        }

        private bool _AddNewProductSize()
        {
            this.SizeID = clsProductSizeData.AddNewProductSize(this.Size, this.ProductID);
            return (this.SizeID != -1);
        }

        private bool _UpdateProductSize()
        {
            return clsProductSizeData.UpdateProductColor(this.Size, this.ProductID);
        }
        public static string GetProductSizes(int ProductID)
        {
            return clsProductSizeData.GetAllProductSizes(ProductID);
        }
        public static clsProductSize Find(int ProductID)
        {
            int SizeID = -1;
            string Size = "";
            if (clsProductSizeData.FindProductSizeByID(ProductID, ref SizeID, ref Size))
                return new clsProductSize(SizeID, Size, ProductID);
            else
                return null;
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewProductSize())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateProductSize();

            }

            return false;
        }
    }
}
