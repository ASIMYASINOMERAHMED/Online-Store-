using OnlineStoreDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreBusiness
{
    public class clsSubCategory
    {
        public int SubCategoryID { get; set; }
        public string SubCategoryName { get; set;}
        public int CategoryID { get; set; }
        public clsProductCategory Category { get; set; }
        public enum enMode { AddNew=1,Update = 2}
        public enMode Mode;
        public clsSubCategory(int SubCategoryID,string SubCategoryName,int CategoryID)
        {
            this.SubCategoryID = SubCategoryID;
            this.SubCategoryName = SubCategoryName;
            this.CategoryID = CategoryID;
            this.Category = clsProductCategory.Find(CategoryID);
            Mode = enMode.Update;
        }
        public clsSubCategory()
        {
            this.SubCategoryID = -1;
            this.SubCategoryName = "";
            this.CategoryID = -1;
            Mode = enMode.AddNew;
        }

        private bool _AddNewProductSubCategory()
        {
            this.SubCategoryID = clsSubCategoryData.AddNewProductSubCategory(this.SubCategoryName,this.CategoryID);
            return (this.SubCategoryID != -1);
        }
        private bool _UpdateProductSubCategory()
        {
            return clsSubCategoryData.UpdateProductSubCategory(this.SubCategoryID,this.SubCategoryName,this.CategoryID);
        }
        public static bool Delete(int SubCategoryID)
        {
            return clsSubCategoryData.DeleteProductSubCategory(SubCategoryID);
        }
        public bool Delete()
        {
            return clsSubCategoryData.DeleteProductSubCategory(this.SubCategoryID);
        }
        public static clsSubCategory Find(int SubCategoryID)
        {
            string SubCategoryName = "";
            int CategoryID = -1;
            if (clsSubCategoryData.FindProductSubCategoryByID(SubCategoryID, ref SubCategoryName,ref CategoryID))
                return new clsSubCategory(SubCategoryID, SubCategoryName,CategoryID);
            else
                return null;
        }
        public static clsSubCategory Find(string SubCategoryName)
        {
            int SubCategoryID = -1,CategoryID=-1;

            if (clsSubCategoryData.FindProductSubCategoryByName(SubCategoryName, ref SubCategoryID, ref CategoryID))
                return new clsSubCategory(SubCategoryID, SubCategoryName, CategoryID);
            else
                return null;
        }
        public static bool IsSubCategoryExist(string SubCategoryName)
        {
            return clsSubCategoryData.IsSubCategoryExist(SubCategoryName);
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
                    if (_AddNewProductSubCategory())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateProductSubCategory();

            }

            return false;
        }
    }
}
