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
    public partial class frmProductDetails : Form
    {
        private clsProductCatalog _Product;
        private int _ProductID;
        private bool _ShowNextBack=true;
        private ctrProductDetails _productDetails;
        public frmProductDetails(int ProductID)
        {
            InitializeComponent();
            _ProductID = ProductID;
        }
        public bool ShowNextBack
        {
            get { return _ShowNextBack; }
            set { _ShowNextBack = value; }
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

        public delegate void DataBackNextItemEventHandler(object sender,int ProductID);

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

        private void frmProductDetails_Load(object sender, EventArgs e)
        {
            _Product = clsProductCatalog.Find(_ProductID);
            if (_Product == null)
            {
                MessageBox.Show("Product has been deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
             _productDetails = new ctrProductDetails(_Product.ProductID);
            _productDetails.ProductAddedToCart += ProductDetails_ProductAddedToCart;
            _productDetails.OnProductAddedToFavorite += _productDetails_OnProductAddedToFavorite;
            _productDetails.OnProductRemoveFromFavorite += _productDetails_OnProductRemoveFromFavorite;
            _productDetails.NextItemClicked += ProductDetails_NextItemClicked;
            _productDetails.BackItemClicked += ProductDetails_BackItemClicked;
            _productDetails.ShowNextBackButton = _ShowNextBack;
            _productDetails.Dock = DockStyle.Top;
            this.Controls.Add(_productDetails);
        }

        private void _productDetails_OnProductRemoveFromFavorite(int obj)
        {
            ProductRemoveFromFavorite(obj);
        }

        private void _productDetails_OnProductAddedToFavorite(int obj)
        {
            ProductAddedToFavorite(obj);
        }

        private async void ProductDetails_BackItemClicked(object sender, int ProductID)
        {
            this.Close();
            await Task.Delay(10);
            BackItemClicked?.Invoke(this, ProductID);
        }

        private async void ProductDetails_NextItemClicked(object sender, int ProductID)
        {
            this.Close();
            await Task.Delay(10);
            NextItemClicked?.Invoke(this, ProductID);
        }

        private void ProductDetails_ProductAddedToCart(object sender, ctrProductDetails.ProductArgs e)
        {
            RaiseOnProductAddedToCart(e.ProductID,e.Quantity,e.Color,e.Size);
            this.Close();
        }




        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProductDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            _productDetails.StoppingMediaPlayer = true;
        }
    }
}
