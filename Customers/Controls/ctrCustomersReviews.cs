using OnlineStoreBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Store_Project
{
    public partial class ctrCustomersReviews : UserControl
    {
        private DataTable _dtReviews;
        private int _ProductID;
        private enum enMode { AllReviews=1,ProductReviews=2};
        private enMode _Mode;
        public ctrCustomersReviews()
        {
            InitializeComponent();
            _Mode = enMode.AllReviews;
        }
        public ctrCustomersReviews(int ProductID)
        {
            InitializeComponent();
            _ProductID = ProductID;
            _Mode = enMode.ProductReviews;
        }
        private List<ctrCustomerReview> _LoadReviews(DataTable Table)
        {
            ctrCustomerReview customerReview;
            List<ctrCustomerReview> customerReviews = new List<ctrCustomerReview>();
            Parallel.ForEach(Table.AsEnumerable(), drow =>
            {
                customerReview = new ctrCustomerReview((int)drow["ReviewID"]);
        
                customerReview.Margin = new Padding(20);
                customerReviews.Add(customerReview);
            });
            return customerReviews;
        }
        private void _DisplayReviews(List<ctrCustomerReview> customerReviews)
        {
            foreach(ctrCustomerReview customerReview in customerReviews)
            {
                PanelReviews.Controls.Add(customerReview);
            }
            if(PanelReviews.Controls.Count ==0)
            {
                lbNoReviews.Visible = true;
                lbNoReviews.Location = new Point(204, 322);
                PanelReviews.Visible = false;
            }
        }
        private void ctrCustomersReviews_Load(object sender, EventArgs e)
        {
            if(_Mode==enMode.AllReviews)
            {
                _dtReviews = clsReview.GetAllReviews();
               _DisplayReviews(_LoadReviews(_dtReviews));
            }
            else
            {
                _dtReviews = clsReview.GetAllReviewsForProductID(_ProductID);
                _DisplayReviews(_LoadReviews(_dtReviews));
            }
        }
    }
}
