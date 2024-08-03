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
    public partial class ctrCartItem : UserControl
    {
        private clsProductCatalog _Product;
        private int _ProductID;
        private int _OrderID;
        private string _Color;
        private string _Size;
        private int _Quantity;
        private decimal _TotalPrice = 0;
        private decimal _UnitPrice = 0;
        private clsOrderItem _OrderItem;
        private bool _ShowCartItemControls=true;
        private enum enMode { ItemDetails=1,CartItem=2};
        private enMode Mode;
        public ctrCartItem(int ProductID,int Quantity,string Color,string Size)
        {
            InitializeComponent();
            _ProductID = ProductID;
            _Color = Color;
            _Size = Size;
            _Quantity = Quantity;
            Mode = enMode.CartItem;
            ctrCartItem_Load(null, null);
        }
        public ctrCartItem(int OrderID,int ProductID)
        {
            InitializeComponent();
            _OrderID = OrderID;
            _ProductID = ProductID;
            Mode = enMode.ItemDetails;
        }
        public int Quantity
        {
            get { return _Quantity; }
        }
        public decimal ProductPrice
        {
            get { return _Product.Price; }
        }
        public int ProductID
        {
            get { return _ProductID; }
        }
        public decimal TotalPrice
        {
            get { return _TotalPrice; }
        }
        public string Color
        {
            get { return _Color; } 
        }
        public string Size1
        {
            get { return _Size; }
        }
        public bool ShowCartItemControls
        {
            get { return _ShowCartItemControls; }
            set
            {
                _ShowCartItemControls = value;
                panelControls.Visible = _ShowCartItemControls;
            }
        }
        public EventHandler ProductRemovefromCart;
        public event Action<decimal> OnProductRemovedfromCart;
        // Create a protected method to raise the event with a parameter
        protected virtual void ProductRemovedfromCart(decimal TotalPrice)
        {
            Action<decimal> handler = OnProductRemovedfromCart;
            if (handler != null)
            {
                handler(TotalPrice); // Raise the event with the parameter
            }
        }
        public event Action<decimal> OnQuantityIncrement;
        // Create a protected method to raise the event with a parameter
        protected virtual void QuantityIncrement(decimal ProductPrice)
        {
            Action<decimal> handler = OnQuantityIncrement;
            if (handler != null)
            {
                handler(ProductPrice); // Raise the event with the parameter
            }
        }
        public event Action<decimal> OnQuantitydecrement;
        // Create a protected method to raise the event with a parameter
        protected virtual void Quantitydecrement(decimal ProductPrice)
        {
            Action<decimal> handler = OnQuantitydecrement;
            if (handler != null)
            {
                handler(ProductPrice); // Raise the event with the parameter
            }
        }
        private void _HandleProductPriceDiscount(clsProductCatalog Product)
        {
            if (Product.Discount > 0)
            {
                decimal discountAmount = (Product.Price * Product.Discount) / 100;
                decimal PriceAfterDiscount = Product.Price - discountAmount;
                lbTotalPriceBeforediscount.Text = Product.Price.ToString()+"$";
                _TotalPrice = PriceAfterDiscount * _Quantity;
                lbUnitPrice.Text = PriceAfterDiscount.ToString() + "$";
                lbTotalPrice.Text = $"Total Price = {PriceAfterDiscount} X {_Quantity} = {_TotalPrice}$";
                _UnitPrice = PriceAfterDiscount;
            }
            else
            {
                _TotalPrice = Product.Price * _Quantity;
                lbUnitPrice.Text = Product.Price.ToString() + "$";
                lbTotalPriceBeforediscount.Visible = false;
                lbTotalPrice.Text = $"Total Price = {Product.Price} X {_Quantity} = {_TotalPrice}$";
                _UnitPrice = Product.Price;
            }
        }
        private void _LoadCartItem()
        {
            _Product = clsProductCatalog.Find(_ProductID);
            if (_Product == null)
            {
                MessageBox.Show("Product has been deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
      
            lbName.Text = _Product.ProductName;
            lbSizeColor.Text = $"Size {_Size} | Color {_Color}";
            lbQuantity.Text = _Quantity.ToString();
            _HandleProductPriceDiscount(_Product);
            picboxItem.ImageLocation = _Product.ImageURL;
        }
        private void _LoadItemDetails()
        {
            _OrderItem = clsOrderItem.Find(_OrderID, _ProductID);
            if(_OrderItem == null)
            {
                MessageBox.Show("Item has been deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Product = clsProductCatalog.Find(_ProductID);
            if (_Product == null)
            {
                MessageBox.Show("Product has been deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lbName.Text = _OrderItem.Product.ProductName;
            lbSizeColor.Text = $"Size {_OrderItem.Size} | Color {_OrderItem.Color}";
            lbQuantity.Text = _OrderItem.Quantity.ToString();
            _Quantity = _OrderItem.Quantity;
            _HandleProductPriceDiscount(_Product);
            picboxItem.ImageLocation = _OrderItem.Product.ImageURL;
        }
        private void ctrCartItem_Load(object sender, EventArgs e)
        {
            if (Mode == enMode.CartItem)
            {
                ShowCartItemControls = true;
                _LoadCartItem();
            }
            else
            {
                ShowCartItemControls = false;
                _LoadItemDetails();
            }

        }

        private void btnDecrement_Click(object sender, EventArgs e)
        {
            if(int.TryParse(lbQuantity.Text, out _Quantity))
            {
                if(_Quantity==1)
                    return;
                _Quantity--;
                lbQuantity.Text = _Quantity.ToString();
                _HandleProductPriceDiscount(_Product);
                Quantitydecrement(_UnitPrice);
            }
        }


        private void btnIncrement_Click(object sender, EventArgs e)
        {
            if (int.TryParse(lbQuantity.Text, out _Quantity))
            {
                _Quantity++;
                lbQuantity.Text = _Quantity.ToString();
                _HandleProductPriceDiscount(_Product);
                QuantityIncrement(_UnitPrice);
            }
        }
     
        private void btnDelete_Click(object sender, EventArgs e)
        {
            ProductRemovefromCart?.Invoke(this, EventArgs.Empty);
            ProductRemovedfromCart(_TotalPrice);
        }

        private void lbTotalPriceBeforediscount_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(lbTotalPriceBeforediscount.ForeColor, 2))
            {
                var y = lbTotalPriceBeforediscount.Height / 2;
                e.Graphics.DrawLine(pen, lbTotalPriceBeforediscount.Padding.Left, y, lbTotalPriceBeforediscount.Width - lbTotalPriceBeforediscount.Padding.Right, y);
            }
        }
    }
}
