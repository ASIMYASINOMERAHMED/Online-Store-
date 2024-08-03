using Online_Store_Project.Properties;
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
    public partial class ctrRatings : UserControl
    {
        public ctrRatings()
        {
            InitializeComponent();
        }
        private int _ProductID, _CustomerID;
        private decimal _Rating;
        public void LoadData(int ProductID,int CustomerID)
        {
            _CustomerID = CustomerID;
            _ProductID = ProductID;
        }
        public delegate void DataBackEventHandler(object sender, EventArgs e);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;
        private void picStar1_MouseEnter(object sender, EventArgs e)
        {
            picStar1.Image = Resources.star__1_;
            picStar2.Image = Resources.EmptyStar;
            picStar3.Image = Resources.EmptyStar;
            picStar4.Image = Resources.EmptyStar;
            picStar5.Image = Resources.EmptyStar;    
            picStar6.Image = Resources.EmptyStar;
            _Rating = 1;
        }

        private void picStar2_MouseEnter(object sender, EventArgs e)
        {
            picStar1.Image = Resources.star__1_;
            picStar2.Image = Resources.star__1_;
            picStar3.Image = Resources.EmptyStar;
            picStar4.Image = Resources.EmptyStar;
            picStar5.Image = Resources.EmptyStar;
            picStar6.Image = Resources.EmptyStar;
            _Rating = 2;
        }

        private void picStar3_MouseEnter(object sender, EventArgs e)
        {
            picStar1.Image = Resources.star__1_;
            picStar2.Image = Resources.star__1_;
            picStar3.Image = Resources.star__1_;
            picStar4.Image = Resources.EmptyStar;
            picStar5.Image = Resources.EmptyStar;
            picStar6.Image = Resources.EmptyStar;
            _Rating = 3;
        }

        private void picStar4_MouseEnter(object sender, EventArgs e)
        {
            picStar1.Image = Resources.star__1_;
            picStar2.Image = Resources.star__1_;
            picStar3.Image = Resources.star__1_;
            picStar4.Image = Resources.star__1_;
            picStar5.Image = Resources.EmptyStar;
            picStar6.Image = Resources.EmptyStar;
            _Rating = 4;
        }

        private void picStar5_MouseEnter(object sender, EventArgs e)
        {
            picStar1.Image = Resources.star__1_;
            picStar2.Image = Resources.star__1_;
            picStar3.Image = Resources.star__1_;
            picStar4.Image = Resources.star__1_;
            picStar5.Image = Resources.star__1_;
            picStar6.Image = Resources.EmptyStar;
            _Rating = 5;
        }

        private void picStar6_MouseEnter(object sender, EventArgs e)
        {
            picStar1.Image = Resources.star__1_;
            picStar2.Image = Resources.star__1_;
            picStar3.Image = Resources.star__1_;
            picStar4.Image = Resources.star__1_;
            picStar5.Image = Resources.star__1_;
            picStar6.Image = Resources.star__1_;
            _Rating = 6;
        }

        private void picStar_MouseLeave(object sender, EventArgs e)
        {
            picStar1.Image = Resources.EmptyStar;
            picStar2.Image = Resources.EmptyStar;
            picStar3.Image = Resources.EmptyStar;
            picStar4.Image = Resources.EmptyStar;
            picStar5.Image = Resources.EmptyStar;
            picStar6.Image = Resources.EmptyStar;
        }

        private void picStar_Click(object sender, EventArgs e)
        {
            frmRating rating = new frmRating(_ProductID,_CustomerID,_Rating);
            rating.DataBack += Rating_DataBack;
            rating.StartPosition = FormStartPosition.CenterScreen;
            rating.ShowDialog();
        }

        private void Rating_DataBack(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, EventArgs.Empty);
        }
    }
}
