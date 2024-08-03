using OnlineStoreBusiness;
using System;
using System.Collections.Concurrent;
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
    public partial class ctrCategories : UserControl
    {
        private DataTable _dtCategories;
        int spacing = 30;
        private bool _DisplayOwnerMode=false;
        private DoubleBufferedFlowLayoutPanel flowLayoutPanel1;
        private bool _ClickableSubCategory = true;
        public ctrCategories()
        {
            InitializeComponent(); 
        }
        public bool ClickableSubCategory
        {
            get { return _ClickableSubCategory; }
            set
            {
                _ClickableSubCategory = value;

            }
        }
        public bool DisplayOwnerMode
        {
            get { return _DisplayOwnerMode; }
            set { _DisplayOwnerMode = value; }
        }
        private bool _ShowAddCategory;
        public bool ShowAddCategory
        {
            get { return _ShowAddCategory; }
            set
            { 
                _ShowAddCategory = value;
                btnAddCategory.Visible = value;
                
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
        private void _LoadCategories(DataTable Table)
        {
            ctrCategory category;

            ConcurrentBag<ctrCategory> categories = new ConcurrentBag<ctrCategory>();
           // Parallel.ForEach(Table.AsEnumerable(), drow =>
            foreach(DataRow drow in Table.Rows) 
            {
                category = new ctrCategory((int)drow["CategoryID"]);
                category.ShowEditDelete = _ShowAddCategory;
                category.ProductAddedToCart += Category_ProductAddedToCart;
                category.ProductAddedToFavourite += Category_ProductAddedToFavourite;
                category.ProductRemovedFromFavourite += Category_ProductRemovedFromFavourite;
                // category.OnCategoryDeletedUpdated += Category_OnCategoryDeletedUpdated;
                if (_DisplayOwnerMode)
                {
                    category.DisplayOwnerMode = true;
                    category.CategoryDeleted += Category_CategoryDeleted1;
                    category.CategoryUpdated += Category_CategoryUpdated;
                }
                category.Margin = new Padding(spacing);
                category.ClickableSubCategory = ClickableSubCategory;
                categories.Add(category);
            
            }
            Invoke(new Action(() =>
            {
                foreach (ctrCategory category1 in categories)
                {
                    flowLayoutPanel1.Controls.Add(category1);
                }
            }));
        }

        private void Category_CategoryDeleted1(object sender, EventArgs e)
        {
            int index = flowLayoutPanel1.Controls.IndexOf((Control)sender);
            flowLayoutPanel1.Controls.RemoveAt(index);
        }

        private void Category_CategoryUpdated(object sender, int CategoryID)
        {
            int index = flowLayoutPanel1.Controls.IndexOf((Control)sender);
            flowLayoutPanel1.Controls.RemoveAt(index);
            ctrCategory UpdatedCategory = new ctrCategory(CategoryID);
            UpdatedCategory.Margin = new Padding(spacing);
            UpdatedCategory.CategoryDeleted += Category_CategoryDeleted1;
            UpdatedCategory.CategoryUpdated += Category_CategoryUpdated;
            flowLayoutPanel1.Controls.Add(UpdatedCategory);
        }

    
        private void Category_ProductAddedToCart(object sender, ctrProduct.ProductArgs e)
        {
            RaiseOnProductAddedToCart(e.ProductID, e.Quantity, e.Color, e.Size);
        }

        private void Category_ProductRemovedFromFavourite(object sender, EventArgs e)
        {
            OnProductRemovedFromFavourite();
        }

        private void Category_ProductAddedToFavourite(object sender, EventArgs e)
        {
            OnProductAddedToFavourite();
        }

     
        private void _displayCategories()
        {
            flowLayoutPanel1 = new DoubleBufferedFlowLayoutPanel();
            flowLayoutPanel1.DoubleBufferPanel = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.AutoScroll = true;
            this.Controls.Add(flowLayoutPanel1);
            flowLayoutPanel1.BringToFront();
            flowLayoutPanel1.Controls.Clear();
            _dtCategories = clsProductCategory.GetAllCategories();
            _LoadCategories(_dtCategories);
            if (flowLayoutPanel1.Controls.Count == 1)
            {
                label1.Visible = true;
                label1.Location = new Point(this.Width / 2, this.Height / 2);
            }
            else
                label1.Visible = false;

        }
        private void ctrCategories_Load(object sender, EventArgs e)
        {
          
            _displayCategories();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            frmAddUpdateCategory addUpdateCategory = new frmAddUpdateCategory();
            addUpdateCategory.DataBack += AddUpdateCategory_DataBack;
            addUpdateCategory.StartPosition = FormStartPosition.CenterScreen;
            addUpdateCategory.ShowDialog();
        }

        private void AddUpdateCategory_DataBack(object sender, int CategoryID)
        {
            ctrCategory NewCategory = new ctrCategory(CategoryID);
            NewCategory.Margin = new Padding(spacing);
            NewCategory.ShowEditDelete = _ShowAddCategory;
            NewCategory.CategoryDeleted += Category_CategoryDeleted1;
            NewCategory.CategoryUpdated += Category_CategoryUpdated;
            flowLayoutPanel1.Controls.Add(NewCategory);
        }

      
    }
}
