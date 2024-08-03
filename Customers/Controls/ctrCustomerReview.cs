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
    public partial class ctrCustomerReview : UserControl
    {
        private int _ReviewID;
        private clsReview _Review;
        private clsUser _Customer;
        public ctrCustomerReview(int ReviewID)
        {
            InitializeComponent();
            _ReviewID = ReviewID;
        }

        private void ctrCustomerReview_Load(object sender, EventArgs e)
        {
            _Review = clsReview.Find(_ReviewID);
            if( _Review == null )
            {
                MessageBox.Show("Review has been Deleted.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            _Customer = clsUser.Find(_Review.CustomerID);
            if( _Customer == null )
            {
                MessageBox.Show("Customer has been Deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            picCustomer.ImageLocation = _Customer.ImageURL;
            lbReviewDate.Text = _Review.ReviewDate.ToString();
            lbReviewText.Text = _Review.ReviewText;
            RatingStar1.Value = Convert.ToSingle(_Review.Rating);
            lbName.Text = _Customer.Name;
            ToolTip1.SetToolTip(lbReviewText,lbReviewText.Text);
        }
    }
}
