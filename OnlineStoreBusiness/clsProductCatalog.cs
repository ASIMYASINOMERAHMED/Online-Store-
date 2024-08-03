using OnlineStoreDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreBusiness
{
    public class clsProductCatalog
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }
        public clsSubCategory SubCategory { get; set; }
        public clsProductCategory Category { get; set; }
        public string ImageURL { get; set; }
        public string VideoURL { get; set; }
        public int Discount { get; set; }
        public enum enMode { AddNew=1, Update=2};
        public enMode Mode;
        public clsProductCatalog(int ProductID,string ProductName, string Description, string LongDescription, decimal Price, int QuantityInStock, int CategoryID, int SubCategoryID, string ImageURL, string videoURL, int Discount)
        {
            this.ProductID = ProductID;
            this.ProductName = ProductName;
            this.ShortDescription = Description;
            this.LongDescription = LongDescription;
            this.Price = Price;
            this.QuantityInStock = QuantityInStock;
            this.CategoryID = CategoryID;
            this.Category = clsProductCategory.Find(CategoryID);
            this.SubCategoryID = SubCategoryID;
            this.SubCategory = clsSubCategory.Find(SubCategoryID);
            this.ImageURL = ImageURL;
            this.Discount = Discount;
            this.VideoURL = videoURL;
            Mode = enMode.Update;

        }
        public clsProductCatalog()
        {
            this.ProductID = -1;
            this.ProductName = "";
            this.ShortDescription = "";
            this.LongDescription = "";
            this.Price = 0;
            this.QuantityInStock = 0;
            this.CategoryID = -1;
            this.SubCategoryID= -1;
            this.ImageURL = "";
            this.Discount = 0;
            Mode = enMode.AddNew;
        }
        private bool _AddNewProductCatalog()
        {
            this.ProductID = clsProductCatalogData.AddNewProductCatalog(this.ProductName, this.ShortDescription,this.LongDescription, this.Price, this.QuantityInStock, this.CategoryID,this.SubCategoryID, this.ImageURL,this.VideoURL,this.Discount);
            return (this.ProductID != -1);
        }
        private bool _UpdateProductCatalog()
        {
            return clsProductCatalogData.UpdateProductCatalog(this.ProductID,this.ProductName, this.ShortDescription,this.LongDescription,this.Price, this.QuantityInStock,this.CategoryID,this.SubCategoryID, this.ImageURL,this.VideoURL,this.Discount);
        }
        public bool Delete()
        {
            return clsProductCatalogData.DeleteProductCatalog(this.ProductID);
        }
        public bool Delete(int ProductID)
        {
            return clsProductCatalogData.DeleteProductCatalog(ProductID);
        }
        public static clsProductCatalog Find(int ProductID)
        {
            string ProductName = "", ImageURL = "",VideoURL="", Description = "",LongDescription = "";
            decimal Price = 0;
            int QuantityInStock = 0,CategoryID=-1,SubCategoryID = -1,Discount = 0;
            if(clsProductCatalogData.FindProductCatalogByID(ProductID,ref ProductName,ref Description,ref LongDescription,ref Price,ref QuantityInStock,ref CategoryID,ref SubCategoryID,ref ImageURL,ref VideoURL,ref Discount))
                return new clsProductCatalog(ProductID,ProductName,Description,LongDescription,Price,QuantityInStock,CategoryID,SubCategoryID,ImageURL,VideoURL,Discount);
            else
                return null;
        }
        public static clsProductCatalog Find(string ProductName)
        {
            string  ImageURL = "",VideoURL="", Description = "",LongDescription="";
            decimal Price = 0;
            int QuantityInStock = 0, CategoryID = -1,ProductID=-1,SubCategoryID=-1,Discount=0;
            if (clsProductCatalogData.FindProductCatalogByName(ProductName, ref ProductID, ref Description,ref LongDescription, ref Price, ref QuantityInStock, ref CategoryID,ref SubCategoryID, ref ImageURL,ref VideoURL,ref Discount))
                return new clsProductCatalog(ProductID, ProductName, Description,LongDescription, Price, QuantityInStock, CategoryID,SubCategoryID, ImageURL,VideoURL,Discount);
            else
                return null;
        }
        public bool AddToFavourit(int CustomerID)
        {
            return clsProductCatalogData.AddToFavourit(this.ProductID,CustomerID);
        }
        public bool RemoveFormFavourit(int CustomerID)
        {
            return clsProductCatalogData.RemoveFromFavourit(this.ProductID, CustomerID);
        }
        public bool AddedToFavouriteByCustomerID(int CustomerID)
        {
            return clsProductCatalogData.IsProductAddedToFavourite(this.ProductID, CustomerID);
        }
        public static DataTable GetAllFavouritesForCustomerID(int CustomerID)
        {
            return clsProductCatalogData.GetAllFavouritesForCustomerID(CustomerID);
        }
        public static DataTable GetProductsForCategoryID(int CategoryID)
        {
            return clsProductCatalogData.GetProductsForCategoryID(CategoryID);
        }
        public static DataTable GetProductsPerPageForCategoryID(int PageNamer,int CategoryID)
        {
            return clsProductCatalogData.GetProductsPerPageForCategoryID(PageNamer,CategoryID);
        }
        public static DataTable GetProductsForSubCategoryID(int SubCategoryID)
        {
            return clsProductCatalogData.GetProductsForSubCategoryID(SubCategoryID);
        }
        public static DataTable GetAllProducts()
        {
            return clsProductCatalogData.GetAllProducts();
        }
        public static DataTable GetMostSoldProducts(DateTime From,DateTime To)
        {
            return clsProductCatalogData.GetMostSoldProducts(From,To);
        }
        public static DataTable GetProductsPerPage(int PageNumber)
        {
            return clsProductCatalogData.GetProductsPerPage(PageNumber);
        }
        public static DataTable GetProductsPerPageForSubCategoryID(int PageNumber,int SubcategoryID)
        {
            return clsProductCatalogData.GetProductsPerPageForSubCategoryID(PageNumber,SubcategoryID);
        }
        public static int GetTotalPages()
        {
            return clsProductCatalogData.GetTotalPages();
        }
        public static int GetTotalPagesForSubCategoryID(int SubCategoryID)
        {
            return clsProductCatalogData.GetTotalPagesForSubCategoryID(SubCategoryID);
        }
        public static int GetTotalPagesForCategoryID(int CategoryID)
        {
            return clsProductCatalogData.GetTotalPagesForCategoryID(CategoryID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewProductCatalog())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateProductCatalog();

            }

            return false;
        }
    }

}
