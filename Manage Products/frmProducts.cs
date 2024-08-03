using OnlineStoreBusiness;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Store_Project
{
    public partial class frmProducts : Form
    {
        private DataTable _dtProducts;
        private DataTable _dtProductsForSubCategoryID;
        private int spacing = 50;
        private int _CategoryID;
        private clsProductCategory _Category;
        private bool _DisplayOwnerMode=false;
        private int _PageNumber = 1;
        private int _TotalPages = 1;
        private List<ctrProduct> _ProductList;
        private int _CurrentProductIndex;
        private int _SubCategoryID;
        public frmProducts(int CategoryID)
        {
            InitializeComponent();
            _CategoryID = CategoryID;
        }
        public bool DisplayOwnerMode
        {
            set { _DisplayOwnerMode = value; }
            get { return _DisplayOwnerMode; }
        }
        private bool _ShowAddProduct;
        public bool ShowAddProduct
        {
            get { return _ShowAddProduct; }
            set
            {
                _ShowAddProduct = value;
                btnAddProduct.Visible = value;
            }
        }
    
        public event EventHandler<ctrProduct.ProductArgs> ProductAddedToCart;
        public void RaiseOnProductAddedToCart(int ProductID, int Quantity, string Color, string Size)
        {
            OnProductAddedToCart(new ctrProduct.ProductArgs(ProductID, Quantity, Color, Size));
        }
        protected virtual void OnProductAddedToCart(ctrProduct.ProductArgs e)
        {
            ProductAddedToCart?.Invoke(this, e);
        }
        public delegate void ProductAddedToFavoritesEventHandler(object sender, EventArgs e);
        public event ProductAddedToFavoritesEventHandler ProductAddedToFavourite;
        protected virtual void OnProductAddedToFavourite()
        {
            ProductAddedToFavourite?.Invoke(this, EventArgs.Empty);
        }
        public delegate void ProductRemovedFromFavoritesEventHandler(object sender, EventArgs e);
        public event ProductAddedToFavoritesEventHandler ProductRemovedFromFavourite;
        protected virtual void OnProductRemovedFromFavourite()
        {
            ProductRemovedFromFavourite?.Invoke(this, EventArgs.Empty);
        }
        private void _FillSubCategoriesInComboBox()
        {
    
            DataTable dtSubCategories = clsSubCategory.GetAllSubCategories(_CategoryID);
            foreach (DataRow row in dtSubCategories.Rows)
            {
                cbSubCategory.Items.Add(row["SubCategoryName"]);
            }
            cbSubCategory.SelectedIndex = 0;
        }
        private List<ctrProduct> _LoadProducts(DataTable Table)
        {
            ctrProduct product;

            ConcurrentBag<ctrProduct> products = new ConcurrentBag<ctrProduct>();
           // Parallel.ForEach(Table.AsEnumerable(), drow =>
            foreach(DataRow drow in Table.Rows)
            {
                product = new ctrProduct((int)drow["ProductID"]);
                product.ProductAddedToCart += Product_ProductAddedToCart;
                product.OnProductUpdated += Product_OnProductUpdated;
                product.ProductRemoved += ProductRemoved;
                product.OnProductAddedToFavorite += Product_OnProductAddedToFavorite;
                product.OnProductRemoveFromFavorite += Product_OnProductRemoveFromFavorite;
                product.NextItemClicked += Product_NextItemClicked;
                product.BackItemClicked += Product_BackItemClicked;
                if (_DisplayOwnerMode)
                {
                    product.DisplayOwnerMode();
                    product.ShowEditDelete = true;
                }
                else
                    product.ShowEditDelete = false;
                product.Margin = new Padding(spacing);
                products.Add(product);
            }
            return products.ToList();
        }

        private void Product_BackItemClicked(object sender, int ProductID)
        {
            _CurrentProductIndex = _ProductList.FindIndex(p => p.ProductID == ProductID);
            if (_CurrentProductIndex == 0)
                _CurrentProductIndex = _ProductList.Count;
            ctrProduct Product = _ProductList[_CurrentProductIndex - 1];
            Product.PreformAddToCartClick();
        }

        private void Product_NextItemClicked(object sender, int ProductID)
        {
            _CurrentProductIndex = _ProductList.FindIndex(p => p.ProductID == ProductID);
            if (_CurrentProductIndex >= _ProductList.Count - 1)
                _CurrentProductIndex = -1;
            ctrProduct Product = _ProductList[_CurrentProductIndex + 1];
            Product.PreformAddToCartClick();
        }

        private void Product_ProductAddedToCart(object sender, ctrProduct.ProductArgs e)
        {
            RaiseOnProductAddedToCart(e.ProductID, e.Quantity, e.Color, e.Size);
        }

        private void Product_OnProductRemoveFromFavorite(int obj)
        {
            OnProductRemovedFromFavourite();
        }

        private void Product_OnProductAddedToFavorite(int obj)
        {
            OnProductAddedToFavourite();
        }

        private void Product_OnProductUpdated(int ProductID)
        {
            frmProducts_Load(null, null);
        }
     
        private async void frmProducts_Load(object sender, EventArgs e)
        {
            // _displayProducts();
         //   await _DisplayFirstPageForCategoryID();
            await Task.Run(() => _Category = clsProductCategory.Find(_CategoryID));
            _FillSubCategoriesInComboBox();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            frmAddUpdateProduct addUpdateProduct = new frmAddUpdateProduct(_Category.CategoryName);
            addUpdateProduct.DataBackNewProduct += AddedProduct_DataBack;
            addUpdateProduct.DataBackUpdatedProduct += AddUpdateProduct_DataBackUpdatedProduct;
            addUpdateProduct.EnableCBProductCategory = false;
            addUpdateProduct.StartPosition = FormStartPosition.CenterScreen;
            addUpdateProduct.ShowDialog();
        }

        private void AddUpdateProduct_DataBackUpdatedProduct(object sender, int ProductID)
        {
            return;
        }

        private void AddedProduct_DataBack(object sender, int ProductID)
        {
            ctrProduct product = new ctrProduct(ProductID);
            product.OnProductUpdated += Product_OnProductUpdated;
            product.ProductRemoved += ProductRemoved;
            product.Margin = new Padding(spacing);
            product.DisplayOwnerMode();
            panelContainer.Controls.Add(product);
            panelContainer.Visible = true;
            lbNoProduct.Visible = false;
        }
        private void ProductRemoved(object sender, EventArgs e)
        {
            int index = panelContainer.Controls.GetChildIndex((Control)sender);
            panelContainer.Controls.RemoveAt(index);
        }
        private async void cbSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {    
            if (cbSubCategory.SelectedIndex != 0)
            {
                _SubCategoryID = clsSubCategory.Find(cbSubCategory.Text).SubCategoryID;

                await _DisplayFirstPageForSubCategoryID();
                if (panelContainer.Controls.Count == 0)
                {
                    lbNoProduct.Visible = true;
                    lbNoProduct.Location = new Point(this.Width / 2, this.Height / 2);
                    panelContainer.Visible = false;
                }
                else
                {
                    lbNoProduct.Visible = false;
                    panelContainer.Visible = true;
                }
            }
            else
               await _DisplayFirstPageForCategoryID();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearch.Enabled = false;

            // Start the background worker
            backgroundWorker1.RunWorkerAsync(txtBoxSearch.Text);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSearch.Enabled = true;

            if (e.Error != null)
            {
                MessageBox.Show("An Error Occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                List<ctrProduct> products = (List<ctrProduct>)e.Result;

                // Clear and add the products to the panel
                panelContainer.SuspendLayout();
                panelContainer.Controls.Clear();
                panelContainer.Controls.AddRange(products.ToArray());
                panelContainer.ResumeLayout(true);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string searchText = (string)e.Argument;

            DataView dataView = new DataView(_dtProducts);
            dataView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "ProductName", searchText);
            DataTable filteredTable = dataView.ToTable();
            List<ctrProduct> products = _LoadProducts(filteredTable);

            e.Result = products;
        }

        private async void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxSearch.Text == string.Empty)
            {
                panelContainer.Controls.Clear();
                if (cbSubCategory.SelectedIndex == 0)
                    await _DisplayFirstPageForCategoryID();
                else
                    await _DisplayFirstPageForSubCategoryID();
            }
        }
        private async Task _DisplayAllProductsAsync(int pageNumber)
        {
            _dtProducts = await Task.Run(() => clsProductCatalog.GetProductsPerPageForCategoryID(pageNumber, _CategoryID));

            if (_dtProducts != null)
            {
                panelContainer.Controls.Clear();
                List<ctrProduct> products = await Task.Run(() => _LoadProducts(_dtProducts));
                panelContainer.Controls.AddRange(products.ToArray());
                if (panelContainer.Controls.Count == 0)
                {
                    lbNoProduct.Visible = true;
                    lbNoProduct.Location = new Point(this.Width / 2, this.Height / 2);
                    panelContainer.Visible = false;
                }
                else
                {
                    lbNoProduct.Visible = false;
                    panelContainer.Visible = true;
                }
            }
            _ProductList = panelContainer.Controls.OfType<ctrProduct>().ToList();

        }
        private async Task _DisplayFirstPageForCategoryID()
        {
            await _DisplayAllProductsAsync(1);
            btnBackPage.Enabled = false;
            DataTable dtProducts = await Task.Run(() => clsProductCatalog.GetProductsPerPageForCategoryID(2, _CategoryID));
            if (dtProducts.Rows.Count == 0)
                btnNextPage.Enabled = false;

            //Get Total Pages for SubCategory
            _TotalPages = await Task.Run(() => clsProductCatalog.GetTotalPagesForCategoryID(_CategoryID));
            lbTotalPages.Text = _TotalPages.ToString();

        }
        private async Task _DisplayProductsForSubCategoryIDAsync(int pageNumber)
        {
            _dtProductsForSubCategoryID = await Task.Run(() => clsProductCatalog.GetProductsPerPageForSubCategoryID(pageNumber, _SubCategoryID));

            if (_dtProductsForSubCategoryID != null)
            {
                panelContainer.Controls.Clear();
                List<ctrProduct> products = await Task.Run(() => _LoadProducts(_dtProductsForSubCategoryID));
                panelContainer.Controls.AddRange(products.ToArray());
                if (panelContainer.Controls.Count == 0)
                {
                    lbNoProduct.Visible = true;
                    lbNoProduct.Location = new Point(this.Width / 2, this.Height / 2);
                    panelContainer.Visible = false;
                }
                else
                {
                    lbNoProduct.Visible = false;
                    panelContainer.Visible = true;
                }
            }
            _ProductList = panelContainer.Controls.OfType<ctrProduct>().ToList();

        }

        private async Task _DisplayFirstPageForSubCategoryID()
        {
            await _DisplayProductsForSubCategoryIDAsync(1);
            btnBackPage.Enabled = false;
            _dtProductsForSubCategoryID = await Task.Run(() => clsProductCatalog.GetProductsPerPageForSubCategoryID(2, _SubCategoryID));
            if (_dtProductsForSubCategoryID.Rows.Count == 0)
                btnNextPage.Enabled = false;

            //Get Total Pages for SubCategory
            _TotalPages = await Task.Run(() => clsProductCatalog.GetTotalPagesForSubCategoryID(_SubCategoryID));
            lbTotalPages.Text = _TotalPages.ToString();

        }
        private async void btnNextPage_Click(object sender, EventArgs e)
        {
            _PageNumber++;
            await _DisplayProductsForSubCategoryIDAsync(_PageNumber);
            lbPageNumber.Text = _PageNumber.ToString();
            btnBackPage.Enabled = true;

            if (_PageNumber == _TotalPages)
                btnNextPage.Enabled = false;
        }

        private async void btnBackPage_Click(object sender, EventArgs e)
        {
            _PageNumber--;
            await _DisplayProductsForSubCategoryIDAsync(_PageNumber);
            lbPageNumber.Text = _PageNumber.ToString();
            btnNextPage.Enabled = true;

            if (_PageNumber == 1)
                btnBackPage.Enabled = false;
        }

        private void txtBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                btnSearch.PerformClick();
            }
        }

        
    }
}
