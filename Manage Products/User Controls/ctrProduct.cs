using Online_Store_Project.Properties;
using OnlineStoreBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Store_Project
{
    public partial class ctrProduct : UserControl
    {
        private int _ProductID;
        private clsProductCatalog _Product;
        private string _ProductName;
        private decimal _Price;
        private bool _ShowEditDelete;

        public ctrProduct(int ProductID)
        {
            InitializeComponent();
            _ProductID = ProductID;
            var doubleBufferPropertyInfo = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            doubleBufferPropertyInfo?.SetValue(guna2CustomGradientPanel1, true, null);
        }
      
        public int ProductID
        {
            get { return _ProductID; }
        }
        public class ProductArgs : EventArgs
        {
            public int ProductID { get; }
            public int Quantity { get; }
            public string Color { get; }
            public string Size { get; }
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
        public EventHandler ProductRemoved;

        public event Action<int> OnProductUpdated;
        // Create a protected method to raise the event with a parameter
        protected virtual void ProductUpdated(int ProductID)
        {
            Action<int> handler = OnProductUpdated;
            if (handler != null)
            {
                handler(ProductID); // Raise the event with the parameter
            }
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

        public bool ShowEditDelete
        {
            get { return _ShowEditDelete; }
            set
            {
                _ShowEditDelete = value;
                panelEditDelete.Visible = _ShowEditDelete;
                ctrRatings1.Enabled = !_ShowEditDelete;
            }
        }
        private void ctrProduct_Load(object sender, EventArgs e)
        {
            _Product = clsProductCatalog.Find(_ProductID);
            if (_Product == null)
            {
                MessageBox.Show("Product has been deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lbName.Text = _Product.ProductName;
            if (_Product.Discount > 0)
            {
                decimal discountAmount = (_Product.Price * _Product.Discount) / 100;
                lbPrice.Text = (_Product.Price - discountAmount).ToString() + "$";
                lbDiscount.Text = _Product.Price.ToString() + "$";
            }
            else
            {
                lbDiscount.Visible = false;
                lbPrice.Text = _Product.Price.ToString()+"$";
            }
            lbQuantity.Text = _Product.QuantityInStock.ToString();
            lbDescription.Text = _Product.ShortDescription;
            pictureBoxItem.ImageLocation = _Product.ImageURL;
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
            ctrRatings1.LoadData(_ProductID,clsGlobal.CurrentUser.UserID);
      
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            clsProductCatalog Product = clsProductCatalog.Find(_ProductID);
            if (Product == null)
            {
                MessageBox.Show("Product has been deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete it?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (Product.Delete())
                {
                    MessageBox.Show("Product has been Deleted succssfully.", "succss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ProductRemoved?.Invoke(this,EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Unable To delete Product.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
                return;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmAddUpdateProduct UpdateProduct = new frmAddUpdateProduct(_ProductID);
            UpdateProduct.StartPosition = FormStartPosition.CenterScreen;
            UpdateProduct.DataBackUpdatedProduct += UpdatedProduct_DataBack;
            UpdateProduct.ShowDialog();
        }

        private void UpdatedProduct_DataBack(object sender, int ProductID)
        {
            ProductUpdated(ProductID);
        }

        private void picAddToFavourit_Click(object sender, EventArgs e)
        {
            if(picAddToFavourit.Tag.ToString() == "Emptyheart")
            {
                if(_Product.AddToFavourit(clsGlobal.CurrentUser.UserID))
                {
                    picAddToFavourit.Image = Resources.heart__1_;
                    picAddToFavourit.Tag = "Redheart";
                    ProductAddedToFavorite(_Product.ProductID);
                }
            }
            else
            {
                if(_Product.RemoveFormFavourit(clsGlobal.CurrentUser.UserID))
                {
                    picAddToFavourit.Image = Resources.heart;
                    picAddToFavourit.Tag = "Emptyheart";
                    ProductRemoveFromFavorite(_Product.ProductID);
                }
            }
        }

   
        public void DisplayOwnerMode()
        {
            this.Size = new Size(403, 549);

            pictureBoxItem.Click -= pictureBoxItem_Click;
        }
        private void pictureBoxItem_Click(object sender, EventArgs e)
        {
            frmProductDetails productDetails = new frmProductDetails(_ProductID);
            productDetails.ProductAddedToCart += ProductDetails_ProductAddedToCart;
            productDetails.OnProductAddedToFavorite += ProductDetails_OnProductAddedToFavorite;
            productDetails.OnProductRemoveFromFavorite += ProductDetails_OnProductRemoveFromFavorite;
            productDetails.NextItemClicked += ProductDetails_NextItemClicked;
            productDetails.BackItemClicked += ProductDetails_BackItemClicked;
            productDetails.StartPosition = FormStartPosition.CenterScreen;
            productDetails.ShowDialog();
        }

        private void ProductDetails_OnProductRemoveFromFavorite(int obj)
        {
            ProductRemoveFromFavorite(obj);
        }

        private void ProductDetails_OnProductAddedToFavorite(int obj)
        {
            ProductAddedToFavorite(obj);
        }

        private void ProductDetails_ProductAddedToCart(object sender, frmProductDetails.ProductArgs e)
        {
            RaiseOnProductAddedToCart(e.ProductID, e.Quantity, e.Color, e.Size);
        }

        private void btnAddToBasket_Click(object sender, EventArgs e)
        {
            frmProductDetails productDetails = new frmProductDetails(_ProductID);
            productDetails.ProductAddedToCart += ProductDetails_ProductAddedToCart;
            productDetails.OnProductAddedToFavorite += ProductDetails_OnProductAddedToFavorite;
            productDetails.OnProductRemoveFromFavorite += ProductDetails_OnProductRemoveFromFavorite;
            productDetails.NextItemClicked += ProductDetails_NextItemClicked;
            productDetails.BackItemClicked += ProductDetails_BackItemClicked;
            productDetails.StartPosition = FormStartPosition.CenterScreen;
            productDetails.ShowDialog();
        }

        private void ProductDetails_BackItemClicked(object sender, int ProductID)
        {
            BackItemClicked?.Invoke(sender, ProductID);
        }

        private void ProductDetails_NextItemClicked(object sender, int ProductID)
        {
            NextItemClicked?.Invoke(sender, ProductID);
        }
        
        private void lbDiscount_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(lbDiscount.ForeColor, 2))
            {
                var y = lbDiscount.Height / 2;
                e.Graphics.DrawLine(pen, lbDiscount.Padding.Left, y, lbDiscount.Width - lbDiscount.Padding.Right, y);
            }
        }
        public void PreformAddToCartClick()
        {
            btnAddToCart.PerformClick();
        }
    }
}
