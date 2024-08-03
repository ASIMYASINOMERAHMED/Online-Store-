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
    public partial class frmRating : Form
    {
        private clsReview review;
        private int _ProductID;
        private int _CustomerID;
        private decimal _Rating;
        public frmRating(int ProductID,int CustomerID,decimal Rating)
        {
            InitializeComponent();
            this._ProductID = ProductID;
            this._CustomerID = CustomerID;
            this._Rating = Rating;
        }
        public delegate void DataBackEventHandler(object sender, EventArgs e);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            review = new clsReview();
            review.ProductID = _ProductID;
            review.CustomerID = _CustomerID;
            review.Rating = _Rating;
            review.ReviewText = txtReview.Text.Trim();
            review.ReviewDate = DateTime.Now;
            try
            {
                if (review.Save())
                {
                    DataBack?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An Error Occurred {ex.Message}");
            }
        }
    }
}
