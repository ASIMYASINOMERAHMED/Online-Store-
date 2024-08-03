using Guna.UI2.WinForms;
using OnlineStoreBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Store_Project
{
    public partial class ctrCategory : UserControl
    {
        private clsProductCategory _category;
        private DataTable _dtSubCategories;
        private int _CategoryID;
        private string _CategoryName;
        private string _CategoryImage;
        private bool _ShowEditDelete=false;
        private bool _DisplayOwnerMode = false;
        private bool _ClickableSubCategory = true;
        public ctrCategory(int categoryID)
        {
            InitializeComponent();
            _CategoryID = categoryID;
        }
        public bool ClickableSubCategory
        {
            get { return _ClickableSubCategory; }
            set
            {
                _ClickableSubCategory = value;
      
            }
        }
        public delegate void DataBackDeleteEventHandler(object sender, EventArgs e);

        // Declare an event using the delegate
        public event DataBackDeleteEventHandler CategoryDeleted;
        public delegate void DataBackUpdateEventHandler(object sender,int CategoryID);

        // Declare an event using the delegate
        public event DataBackUpdateEventHandler CategoryUpdated;
       
   
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
        public bool DisplayOwnerMode
        {
            get { return _DisplayOwnerMode; } 
            set
            {
               _DisplayOwnerMode = value ;
            }
        }
        public bool ShowEditDelete
        {
            get { return _ShowEditDelete; } 
            set
            {
                _ShowEditDelete = value;
                panelEditDelete.Visible = _ShowEditDelete;
            }
        }
        public string CategoryName
        {
            get { return _CategoryName; }
            set { _CategoryName = value; }
        }
        public string CategoryImage
        {
            set { _CategoryImage = value; }
            get { return _CategoryImage; }
        }

        private void Category_Load(object sender, EventArgs e)
        {
             _category = clsProductCategory.Find(_CategoryID);
            if (_category == null)
            {
                MessageBox.Show("Category has been deleted.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            picCategory.ImageLocation = _category.CategoryImage;
            lbCategoryName.Text = _category.CategoryName;
             _DisplaySubCategories();
      
        }
        private void _DisplaySubCategories()
        {
            Guna2Chip subcategory;
            _dtSubCategories = clsSubCategory.GetAllSubCategories(_CategoryID);
            foreach(DataRow row in _dtSubCategories.Rows)
            {
                subcategory = new Guna2Chip();
                subcategory.Text = $"{row["SubCategoryName"]}";
                subcategory.TextAlign = HorizontalAlignment.Left;
                subcategory.Font = lbCategoryName.Font;
                subcategory.BorderColor = lbCategoryName.ForeColor;
                subcategory.FillColor = lbCategoryName.BackColor;
                subcategory.Margin = new Padding(10);
                subcategory.Visible = true;
                subcategory.AutoSize = true;
                subcategory.TextFormatNoPrefix = true;
                subcategory.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
                subcategory.Cursor = Cursors.Hand;
                if(!ClickableSubCategory)
                {
                    subcategory.Click -= Subcategory_Click;
                    subcategory.IsClosable = false;
                }
                else
                    subcategory.Click += Subcategory_Click;
                panelSubCategories.Controls.Add(subcategory);
            }

            if (panelSubCategories.Controls.Count == 0)
                panelSubCategories.Visible = false;
        }

        private void Subcategory_Click(object sender, EventArgs e)
        {
          
                clsSubCategory subCategory = clsSubCategory.Find(((Control)sender).Text);
                if (subCategory.Delete())
                {     
                    return;
                }
                else
                {
                    MessageBox.Show("An Error Occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            clsProductCategory category = clsProductCategory.Find(_CategoryID);
            if (category == null)
            {
                MessageBox.Show("Category has been deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete it?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (category.Delete())
                {
                    CategoryDeleted?.Invoke(this, EventArgs.Empty);
                    
                }
                else
                {
                    MessageBox.Show("Unable To delete Category.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
                return;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmAddUpdateCategory addUpdateCategory = new frmAddUpdateCategory(_CategoryID);
            addUpdateCategory.DataBack += UpdateCategory_DataBack;
            addUpdateCategory.StartPosition = FormStartPosition.CenterScreen;
            addUpdateCategory.ShowDialog();
   
        }

        private void UpdateCategory_DataBack(object sender, int CategoryID)
        {
            CategoryUpdated?.Invoke(this, CategoryID);
        }

        private void picCategory_DoubleClick(object sender, EventArgs e)
        {
            frmProducts frmProducts = new frmProducts(_CategoryID);
            frmProducts.ShowAddProduct = ShowEditDelete;
            frmProducts.ProductAddedToCart += FrmProducts_ProductAddedToCart;
            frmProducts.ProductAddedToFavourite += FrmProducts_ProductAddedToFavourite;
            frmProducts.ProductRemovedFromFavourite += FrmProducts_ProductRemovedFromFavourite;
            if (_DisplayOwnerMode)
                frmProducts.DisplayOwnerMode = true;
            frmProducts.Dock = DockStyle.Fill;
            frmProducts.ShowDialog();
        }

        private void FrmProducts_ProductAddedToCart(object sender, ctrProduct.ProductArgs e)
        {
            RaiseOnProductAddedToCart(e.ProductID, e.Quantity, e.Color, e.Size);
        }

        private void FrmProducts_ProductRemovedFromFavourite(object sender, EventArgs e)
        {
            OnProductRemovedFromFavourite();
        }

        private void FrmProducts_ProductAddedToFavourite(object sender, EventArgs e)
        {
            OnProductAddedToFavourite();
        }

        private void llAddSubCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddSubCategory addSubCategory = new frmAddSubCategory(_CategoryID);
            addSubCategory.StartPosition = FormStartPosition.CenterScreen;
            addSubCategory.DataBack += AddSubCategory_DataBack;
            addSubCategory.ShowDialog();

        }

        private void AddSubCategory_DataBack(object sender, string SubCategoryName)
        {

            Guna2Chip subcategory = new Guna2Chip();
            subcategory.Text = $"{SubCategoryName}";
            subcategory.TextAlign = HorizontalAlignment.Left;
            subcategory.Font = lbCategoryName.Font;
            subcategory.BorderColor = lbCategoryName.ForeColor;
            subcategory.FillColor = lbCategoryName.BackColor;
            subcategory.Margin = new Padding(10);
            subcategory.Visible = true;
            subcategory.AutoSize = true;
            subcategory.TextFormatNoPrefix = true;
            subcategory.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
            subcategory.Cursor = Cursors.Hand;
            subcategory.Click += Subcategory_Click;
            panelSubCategories.Controls.Add(subcategory);
            panelSubCategories.Visible = true;
        }
    }
}
