using OnlineStoreDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreBusiness
{
    public class clsProductColor
    {
        public int ColorsID { get; set; }
        public string Colors { set; get; }
        public int ProductID { get; set; }
        public clsProductCatalog Product { get; set; }

        public enum enMode { AddNew=1,Update=2}
        public enMode Mode;
        public clsProductColor(int ColorID,string Colors,int productID)
        {
             this.ColorsID = ColorID;
            this.Colors = Colors;
            this.ProductID = productID;
            this.Product = clsProductCatalog.Find(ProductID);
            Mode = enMode.Update;
        }
        public clsProductColor()
        {
            this.ColorsID = -1;
            this.Colors = "";
            this.ProductID = -1;
            Mode = enMode.AddNew;
        }

        private bool _AddNewProductColor()
        {
            this.ColorsID = clsProductColorData.AddNewProductColor(this.Colors,this.ProductID);
            return (this.ColorsID != -1);
        }

        private bool _UpdateProductColor()
        {
            return clsProductColorData.UpdateProductColor(this.Colors, this.ProductID);
        }
        public static string GetProductColors(int ProductID)
        {
            return clsProductColorData.GetAllProductColors(ProductID);
        }
        public static clsProductColor Find(int ProductID)
        {
            int ColorsID = -1;
            string Colors = "";
            if(clsProductColorData.FindProductColorByID(ProductID,ref ColorsID,ref Colors))
                return new clsProductColor(ColorsID, Colors,ProductID);
            else
                return null;
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewProductColor())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateProductColor();

            }

            return false;
        }
    }
}
