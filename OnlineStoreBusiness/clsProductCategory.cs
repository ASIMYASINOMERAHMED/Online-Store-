using OnlineStoreDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreBusiness
{
    public class clsProductCategory
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImage { get; set; }
        public enum enMode { AddNew=1,Update =2};
        public enMode Mode;
        public clsProductCategory(int CategoryID,string CategoryName, string categoryImage)
        {
            this.CategoryID = CategoryID;
            this.CategoryName = CategoryName;
            this.CategoryImage = categoryImage;
            Mode = enMode.Update;
        }
        public clsProductCategory()
        {
            this.CategoryID = -1;
            this.CategoryName = "";
            this.CategoryImage = "";
            Mode = enMode.AddNew;
        }
        private bool _AddNewProductCategory()
        {
            this.CategoryID = clsProductCategoryData.AddNewProductCategory(this.CategoryName,this.CategoryImage);
            return (this.CategoryID != -1);
        }
        private bool _UpdateProductCategory()
        {
            return clsProductCategoryData.UpdateProductCategory(this.CategoryID,this.CategoryName,this.CategoryImage);
        }
        public bool Delete(int CategoryID)
        {
            return clsProductCategoryData.DeleteProductCategory(CategoryID);
        }
        public bool Delete()
        {
            return clsProductCategoryData.DeleteProductCategory(this.CategoryID);
        }
        public static clsProductCategory Find(int CategoryID)
        {
            string CategoryName = "",CategoryImage="";
            if(clsProductCategoryData.FindProductCategoryByID(CategoryID,ref CategoryName,ref CategoryImage))
                return new clsProductCategory(CategoryID,CategoryName,CategoryImage);
            else
                return null;
        }
        public static clsProductCategory Find(string CategoryName)
        {
            int CategoryID = -1;
            string CategoryImage = "";
            if (clsProductCategoryData.FindProductCategoryByName(CategoryName,ref CategoryID, ref CategoryImage))
                return new clsProductCategory(CategoryID, CategoryName, CategoryImage);
            else
                return null;
        }
        public static bool IsCategoryExist(string CategoryName)
        {
            return clsProductCategoryData.IsCategoryExist(CategoryName);
        }

        public static DataTable GetAllCategories()
        {
            return clsProductCategoryData.GetAllCategories();
        }
        public static DataTable GetAllSubCategories(int CategoryID)
        {
            return clsSubCategoryData.GetAllSubCategory(CategoryID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewProductCategory())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateProductCategory();

            }

            return false;
        }
    }
}
