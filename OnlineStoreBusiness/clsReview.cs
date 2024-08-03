using OnlineStoreDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreBusiness
{
    public class clsReview
    {
        public int ReviewID { get; set; }
        public int ProductID { get; set; }
        public clsProductCatalog Product { get; set; }
        public int CustomerID { get; set; }
        public clsUser Customer { get; set; }
        public string ReviewText { get; set; }
        public decimal Rating { get; set; }
        public DateTime ReviewDate { get; set; }
        public enum enMode { AddNew=1,Update=2};
        public enMode Mode;

        public clsReview(int ReviewID,int ProductID,int CustomerID,string ReviewText,decimal Rating,DateTime ReviewDate)
        {
            this.ReviewID = ReviewID;
            this.ProductID = ProductID;
            this.Product = clsProductCatalog.Find(ProductID);
            this.CustomerID = CustomerID;
            this.Customer = clsUser.Find(CustomerID);
            this.ReviewText = ReviewText;
            this.Rating = Rating;
            this.ReviewDate = ReviewDate;
            Mode = enMode.Update;
        }
        public clsReview()
        {
            this.ReviewID = -1;
            this.ProductID = -1;
            this.CustomerID = -1;
            this.ReviewText = "";
            this.Rating = 0;
            this.ReviewDate = DateTime.Now;
            Mode = enMode.AddNew;
        }

        private bool _AddNewReview()
        {
            this.ReviewID = clsReviewData.AddNewReview(this.ProductID,this.CustomerID,this.ReviewText,this.Rating,this.ReviewDate);
            return (this.ReviewID != -1);
        }
        private bool _UpdateReview()
        {
            return clsReviewData.UpdateReview(this.ReviewID,this.ProductID,this.CustomerID, this.ReviewText,this.Rating, this.ReviewDate);
        }
        public bool Delete()
        {
            return clsReviewData.DeleteReview(this.ReviewID);
        }
        public bool Delete(int ReviewID)
        {
            return clsReviewData.DeleteReview(ReviewID);
        }
        public static clsReview Find(int ReviewID)
        {
            int ProductID=-1,CustomerID=-1;
            string ReviewText = "";
            decimal Rating = 0;
            DateTime ReviewDate = DateTime.Now;
            if(clsReviewData.FindReviewByID(ReviewID,ref ProductID,ref CustomerID,ref ReviewText,ref Rating,ref ReviewDate))
                return new clsReview(ReviewID,ProductID,CustomerID,ReviewText,Rating,ReviewDate);
            else
                return null;
        }
        public static DataTable GetAllReviewsForCustomerID(int CustomerID)
        {
            return clsReviewData.GetAllReviewsForCustomerID(CustomerID);
        }
        public static DataTable GetAllReviewsForProductID(int ProductID)
        {
            return clsReviewData.GetAllReviewsForProductID(ProductID);
        }
        public static DataTable GetAllReviews()
        {
            return clsReviewData.GetAllReviews();
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewReview())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateReview();

            }

            return false;
        }
    }
}
