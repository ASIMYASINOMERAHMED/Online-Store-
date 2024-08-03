using Online_Store_Project.Properties;
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
using System.Xml;
using WMPLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Online_Store_Project
{
    public partial class ctrProductDetails : UserControl
    {
        private clsProductCatalog _Product;
        private string _ProductColors;
        private string _ProductSizes;
        private int _ProductID;
        private DataTable _dtProductImages;
        private List<string> _picBoxesImgLocation;
        private int _currentIndex =0;
        private bool _ShowNextBackButton=true;
        private bool _StoppingMediaPlayer=false;
        private const int MaxDisplayedCharacters = 100; // Maximum number of characters to display initially
        private bool isExpanded = false; // Flag to track the expanded state
        public ctrProductDetails(int ProductID)
        {
            _ProductID = ProductID;
            InitializeComponent();
           
        }
        public event Action<int> OnProductAddedToFavorite;
        // Create a protected method to raise the event with a parameter
        protected virtual void ProductAddedToFavorite(int ProductID)
        {
            Action<int> handler = OnProductAddedToFavorite;
            if (handler != null)
            {
                handler(ProductID); // Raise the event with the parameter
            }
        }
        public event Action<int> OnProductRemoveFromFavorite;
        // Create a protected method to raise the event with a parameter
        protected virtual void ProductRemoveFromFavorite(int ProductID)
        {
            Action<int> handler = OnProductRemoveFromFavorite;
            if (handler != null)
            {
                handler(ProductID); // Raise the event with the parameter
            }
        }

        public bool StoppingMediaPlayer
        {
            get { return _StoppingMediaPlayer; }
            set
            {
                _StoppingMediaPlayer = value;
                if(value) 
                    WindowsMediaPlayer1.Dispose();
            }
        }
        public bool ShowNextBackButton
        {
            get { return _ShowNextBackButton; }
            set 
            { 
                _ShowNextBackButton = value;
                btnNextItem.Visible = _ShowNextBackButton;
                btnBackItem.Visible = _ShowNextBackButton;
            }
        }
        public class ProductArgs: EventArgs
        {
          public   int ProductID { get; }
          public   int Quantity { get; }
          public  string Color { get; }
          public  string Size { get; }
            public ProductArgs(int ProductID, int Quantity, string Color, string Size)
            {
                this.ProductID = ProductID;
                this.Quantity = Quantity;
                this.Color = Color;
                this.Size = Size;
            }
        }
        public delegate void DataBackNextItemEventHandler(object sender, int ProductID);

        // Declare an event using the delegate
        public event DataBackNextItemEventHandler NextItemClicked;

        public delegate void DataBackItemEventHandler(object sender, int ProductID);

        // Declare an event using the delegate
        public event DataBackItemEventHandler BackItemClicked;

        public event EventHandler<ProductArgs> ProductAddedToCart;
        public void RaiseOnProductAddedToCart(int ProductID, int Quantity, string Color, string Size)
        {
            OnProductAddedToCart(new ProductArgs(ProductID, Quantity, Color, Size));
        }
        protected virtual void OnProductAddedToCart(ProductArgs e)
        {
            ProductAddedToCart?.Invoke(this, e);
        }
   
        private void _LoadProductColorsInComboBox()
        {
            _ProductColors = clsProductColor.GetProductColors(_ProductID);
            string[] Color = _ProductColors.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            for (int i = 0; i < Color.Length; i++)
            {
                cbColors.Items.Add(Color[i]);
            }

        }
        private void _LoadProductSizesInComboBox()
        {
            _ProductSizes = clsProductSize.GetProductSizes(_ProductID);
            string[] Size = _ProductSizes.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            for (int i = 0; i < Size.Length; i++)
            {
                cbSize.Items.Add(Size[i]);
            }
        }
        private void _LoadProductImages(DataTable dt)
        {
            if (_Product.VideoURL != "")
            {
                ctrProductVideo productVideo = new ctrProductVideo(_Product.ImageURL);
                productVideo.PlayVideoClicked += ProductVideo_PlayVideoClicked;
                productVideo.Cursor = Cursors.Hand;
                panelProductPics.Controls.Add(productVideo);
            }

            foreach (DataRow row in  dt.Rows)
            {
                PictureBox picture = new PictureBox();
                picture.Size = new Size(290, 208);
                picture.SizeMode = PictureBoxSizeMode.Zoom;
                picture.ImageLocation = row["ImageURL"].ToString();
                picture.Padding = new Padding(20);
                picture.Cursor = Cursors.Hand;
                picture.Click += Picture_Click;
                panelProductPics.Controls.Add(picture);
            }
            if (panelProductPics.Controls.Count > 0)
                lbTotalPics.Text = (panelProductPics.Controls.Count - 1).ToString();
            else
                lbTotalPics.Text = "0";
      

                
        }

        private void ProductVideo_PlayVideoClicked(object sender, EventArgs e)
        {
            picBoxItem.Visible = false;
            WindowsMediaPlayer1.Visible = true;
            WindowsMediaPlayer1.URL = _Product.VideoURL;
        }

        private void Picture_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = (PictureBox)sender; // Get the clicked PictureBox
            picBoxItem.ImageLocation = clickedPictureBox.ImageLocation;
            picBoxItem.Visible=true;
            WindowsMediaPlayer1.Visible = false;
        }
        private void _HandleProductPriceDiscount(clsProductCatalog Product)
        {
            if (Product.Discount > 0)
            {
                decimal discountAmount = (Product.Price * Product.Discount) / 100;
                lbPrice.Text = (Product.Price - discountAmount).ToString()+"$";
                lbDiscount.Text = Product.Price.ToString()+"$";
            }
            else
            {
                lbDiscount.Visible = false;
                lbPrice.Text = Product.Price.ToString()+"$";
            }
        }
        private void _RefreshReviews(clsProductCatalog Product)
        {
            gbReviews.SuspendLayout();
            gbReviews.Controls.Clear();
            ctrCustomersReviews customersReviews = new ctrCustomersReviews(Product.ProductID);
            customersReviews.Dock = DockStyle.Fill;
            gbReviews.Controls.Add(customersReviews);
            gbReviews.ResumeLayout();
        }
        private void _HandleProductDiscription(clsProductCatalog Product)
        {
            if (Product.LongDescription.Length > MaxDisplayedCharacters)
            {
                // Truncate the text and add ellipsis
                string displayedText = Product.LongDescription.Substring(0, MaxDisplayedCharacters) + " Read More...";

                // Set the truncated text as the label's initial text
                lbLongDescription.Text = displayedText;

                // Enable the "Read More" functionality
                lbLongDescription.Cursor = Cursors.Hand;
                lbLongDescription.ForeColor = Color.Blue;
                lbLongDescription.Click += lbDescription_Click;
            }
            else
            {
                // The full text fits within the label, no truncation needed
                lbLongDescription.Text = Product.LongDescription;
            }
        }
        private void lbDescription_Click(object sender, EventArgs e)
        {
            if (!isExpanded)
            {
                // Expand the label to show the full text
                lbLongDescription.Text = _Product.LongDescription + " Read Less..."; // Replace with the actual full text
                lbLongDescription.Height = 579;
                lbLongDescription.ForeColor = Color.Black;

            }
            else
            {
                // Collapse the label to the truncated text
                string displayedText = lbLongDescription.Text.Substring(0, MaxDisplayedCharacters) + " Read More...";
                lbLongDescription.Height = 123;
                lbLongDescription.Text = displayedText;
                lbLongDescription.ForeColor = Color.Blue;

            }

            isExpanded = !isExpanded; // Toggle the expanded state
 
        }
  
    
        private void _LoadData()
        {
            _Product = clsProductCatalog.Find(_ProductID);
            if (_Product == null)
            {
                MessageBox.Show("Product has been deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
             lbShortDescription.Text = _Product.ShortDescription;
            _HandleProductDiscription(_Product);
            ToolTip1.SetToolTip(lbLongDescription, lbLongDescription.Text);
            lbName.Text = _Product.ProductName;
            numaricQuantity.Maximum = _Product.QuantityInStock;
            picBoxItem.ImageLocation = _Product.ImageURL;
            _HandleProductPriceDiscount(_Product);
            _RefreshReviews(_Product);
            _LoadProductColorsInComboBox();
            _LoadProductSizesInComboBox();
            if (_Product.AddedToFavouriteByCustomerID(clsGlobal.CurrentUser.UserID))
            {
                picAddToFavourit.Image = Resources.heart__1_;
                picAddToFavourit.Tag = "Redheart";
            }
            else
            {
                picAddToFavourit.Image = Resources.heart;
                picAddToFavourit.Tag = "Emptyheart";
            }
            cbColors.SelectedIndex = 0;
            cbSize.SelectedIndex = 0;
            _dtProductImages = clsProductImages.GetProductImages(_ProductID);
            _LoadProductImages(_dtProductImages);
      
            ctrRatings1.LoadData(_ProductID, clsGlobal.CurrentUser.UserID); //Initilize Variables for Rating Control
            ctrRatings1.DataBack += CtrRatings1_DataBack;
            _picBoxesImgLocation = panelProductPics.Controls
                                .OfType<PictureBox>()
                                .Select(pictureBox => pictureBox.ImageLocation)
                                .ToList();

        }

        private void CtrRatings1_DataBack(object sender, EventArgs e)
        {
            _RefreshReviews(_Product);
        }

        private void ctrProductDetails_Load(object sender, EventArgs e)
        {
            _LoadData();
        
        }

      

 

        private void numericUpDown1_Validating(object sender, CancelEventArgs e)
        {
            if(numaricQuantity.Value==0)
            {
                e.Cancel = true;
                errorProvider1.SetError(numaricQuantity, "This Feild is requird.");
                return;
            }
            if(numaricQuantity.Value>Convert.ToDecimal(_Product.QuantityInStock))
            {
                e.Cancel = true;
                errorProvider1.SetError(numaricQuantity, $"Quantity Exeeds the Quantity In Stock!, Available Quantity {_Product.QuantityInStock}");
                return;
            }
            else
            {
                errorProvider1.SetError(numaricQuantity, null);
            }
        
        }

        private void btnAddToBasket_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            RaiseOnProductAddedToCart(_ProductID,Convert.ToInt32(numaricQuantity.Value),cbColors.Text.Trim(),cbSize.Text.Trim());
            
        }

        private void cbColors_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(cbColors.Text)||cbColors.SelectedIndex==0)
            {
                e.Cancel = true;
                errorProvider1.SetError(cbColors,"Please Choose Color.");
                return;
            }
            else
            {
                errorProvider1.SetError(cbColors, null);
            }
        }

        private void cbSize_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cbSize.Text) || cbSize.SelectedIndex == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(cbSize, "Please Choose Size.");
                return;
            }
            else
            {
                errorProvider1.SetError(cbSize, null);
            }
        }

     
        private void lbDiscount_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(lbDiscount.ForeColor, 2))
            {
                var y = lbDiscount.Height / 2;
                e.Graphics.DrawLine(pen, lbDiscount.Padding.Left, y, lbDiscount.Width - lbDiscount.Padding.Right, y);
            }
        }


        private void btnNextPic_Click(object sender, EventArgs e)
        {
            _currentIndex++;
            if (_currentIndex >= _picBoxesImgLocation.Count)
                _currentIndex = 0;

            // Display the image on the largePictureBox
            _DisplaySelectedImage();
            lbCurrentPic.Text = _currentIndex.ToString();
        }

        private void btnBackPic_Click(object sender, EventArgs e)
        {
            _currentIndex--;
            if (_currentIndex < 0)
                _currentIndex = _picBoxesImgLocation.Count - 1;

            // Display the image on the largePictureBox
            _DisplaySelectedImage();
            lbCurrentPic.Text = _currentIndex.ToString();
        }
        private void _DisplaySelectedImage()
        {
            // Get the PictureBoxImage control based on the currentIndex
            if (_currentIndex >= 0 && _currentIndex < _picBoxesImgLocation.Count)
            {
                string selectedPictureBoxImgLocation = _picBoxesImgLocation[_currentIndex];
                // Set the largePictureBox image to the selected picture box image
                picBoxItem.ImageLocation = selectedPictureBoxImgLocation;
                picBoxItem.Visible = true;
                WindowsMediaPlayer1.Visible = false;
            }
  
        }

        private void btnNextItem_Click(object sender, EventArgs e)
        {
            NextItemClicked?.Invoke(this, _ProductID);
        }

        private void btnBackItem_Click(object sender, EventArgs e)
        {
            BackItemClicked?.Invoke(this, _ProductID);
        }

        private void picAddToFavourit_Click(object sender, EventArgs e)
        {
            if (picAddToFavourit.Tag.ToString() == "Emptyheart")
            {
                if (_Product.AddToFavourit(clsGlobal.CurrentUser.UserID))
                {
                    picAddToFavourit.Image = Resources.heart__1_;
                    picAddToFavourit.Tag = "Redheart";
                    ProductAddedToFavorite(_Product.ProductID);
                }
            }
            else
            {
                if (_Product.RemoveFormFavourit(clsGlobal.CurrentUser.UserID))
                {
                    picAddToFavourit.Image = Resources.heart;
                    picAddToFavourit.Tag = "Emptyheart";
                    ProductRemoveFromFavorite(_Product.ProductID);
                }
            }
        }

   
    }
}