using OnlineStoreBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Store_Project
{
    public partial class frmAddUpdateProduct : Form
    {
        private int _ProductID;
        private clsProductCatalog _Product;
        private clsProductColor _ProductColors;
        private clsProductSize _ProductSize;
        private int _CategoryID;
        private int _SubCategoryID;
        private enum enMode { AddNew = 1, Update = 2 };
        private enMode _Mode;
        private string _CategoryName;
        private SortedList<int,string> _SLImages = new SortedList<int,string>();
        private DataTable _dtImages;
        private bool _EnableCBProductCategory = true;
        public bool EnableCBProductCategory
        {
            get { return _EnableCBProductCategory; }
            set
            {
                _EnableCBProductCategory = value;
                cbCategory.Enabled = _EnableCBProductCategory;
            }
        }
        public delegate void DataBackNewProductEventHandler(object sender, int ProductID);

        // Declare an event using the delegate
        public event DataBackNewProductEventHandler DataBackNewProduct;
        public delegate void DataBackUpdatedProductEventHandler(object sender, int ProductID);

        // Declare an event using the delegate
        public event DataBackUpdatedProductEventHandler DataBackUpdatedProduct;
        public frmAddUpdateProduct(int productID)
        {
            InitializeComponent();
            _ProductID = productID;
            _Mode = enMode.Update;
            lbTitle.Text = "Update Product";
            btnAddUpdateProduct.Text = "Update Product";
        }
        public frmAddUpdateProduct(string CategoryName)
        {
            InitializeComponent();
            _Product = new clsProductCatalog();
            _Mode = enMode.AddNew;
            lbTitle.Text = "Add Product";
            btnAddUpdateProduct.Text = "Add Product";
            _CategoryName = CategoryName;
        }
        public frmAddUpdateProduct()
        {
            InitializeComponent();
            _Product = new clsProductCatalog();
            _Mode = enMode.AddNew;
            lbTitle.Text = "Add Product";
            btnAddUpdateProduct.Text = "Add Product";
        }

        private void _LoadData()
        {
          
            txtboxProductName.Text = _Product.ProductName;
            txtProductprice.Text = _Product.Price.ToString();
            txtboxProductImage.Text = _Product.ImageURL;
            txtboxDescription.Text = _Product.ShortDescription;
            txtLongDescription.Text = _Product.LongDescription;
            txtQuantityInStock.Text = _Product.QuantityInStock.ToString();
            if (_Product.Discount > 0)
                txtBoxDiscount.Text = _Product.Discount.ToString();
            txtboxProductImage.Text = _Product.ImageURL;
            picThumbnail.ImageLocation = _Product.ImageURL;
            if(_Product.VideoURL!=null)
                txtBoxVideo.Text = _Product.VideoURL.ToString();
            cbCategory.SelectedIndex = cbCategory.FindString(_Product.Category.CategoryName);
            cbCategory.Enabled = false;
            cbSubCategory.SelectedIndex = cbSubCategory.FindString(_Product.SubCategory.SubCategoryName);
            txtProductSizes.Text = clsProductSize.GetProductSizes(_Product.ProductID);
            txtboxColors.Text = clsProductColor.GetProductColors(_Product.ProductID);
            _DisplayProductImages();
        }
        private void _DisplayProductImages()
        {
            PictureBox picture;
            _dtImages = clsProductImages.GetProductImages(_ProductID);
            foreach (DataRow img in _dtImages.Rows)
            {
                picture = new PictureBox();
                picture.SizeMode = PictureBoxSizeMode.Zoom;
                picture.Size = new Size(119, 89);
                picture.ImageLocation = img["ImageURL"].ToString();
                panelProductPics.Controls.Add(picture);
            }

        }
        private void _FillCategoriesInComboBox()
        {
            DataTable dtCategories = clsProductCategory.GetAllCategories();
            foreach(DataRow row in  dtCategories.Rows)
            {
                cbCategory.Items.Add(row["CategoryName"]);
            }
            if (_CategoryName != null)
                cbCategory.SelectedIndex = cbCategory.FindString(_CategoryName);
            else
                cbCategory.SelectedIndex = 0;
        }
        private void _FillSubCategoriesInComboBox()
        {
            cbSubCategory.Items.Clear();
            cbSubCategory.Items.Add("--SELECT--");
            DataTable dtSubCategories = clsSubCategory.GetAllSubCategories(_CategoryID);
            foreach (DataRow row in dtSubCategories.Rows)
            {
                cbSubCategory.Items.Add(row["SubCategoryName"]);
            }
            cbSubCategory.SelectedIndex = 0;
        }
        private void frmAddUpdateProduct_Load(object sender, EventArgs e)
        {
            if(_Mode ==enMode.Update)
            {
                _Product = clsProductCatalog.Find(_ProductID);
                if (_Product == null)
                {
                    MessageBox.Show("Product has been deleted.", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _CategoryName = _Product.Category.CategoryName;
            }
             _FillCategoriesInComboBox();
             _FillSubCategoriesInComboBox();
            if (_Mode == enMode.Update)
                _LoadData();
        
          
        }
        private void SaveColorsInDB(clsProductCatalog Product)
        {
            _ProductColors = new clsProductColor();
            _ProductColors.Colors = txtboxColors.Text.Trim();
            _ProductColors.ProductID = Product.ProductID;
            try
            {
                if (_ProductColors.Save())
                    return;
                else
                {
                    MessageBox.Show("Unable To Save Product Colors.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An Error Occurred {ex.Message}");
            }
        }
        private void UpdateColors(clsProductCatalog Product)
        {
            _ProductColors = clsProductColor.Find(Product.ProductID);
            if (_ProductColors != null)
            {
                _ProductColors.Colors = txtboxColors.Text.Trim();
                try
                {
                    if (_ProductColors.Save())
                        return;
                    else
                    {
                        MessageBox.Show("Unable To Save Product Colors.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An Error Occurred {ex.Message}");
                }
            }
            else
                return;
        }
        private void SaveSizesInDB(clsProductCatalog Product)
        {
            _ProductSize = new clsProductSize();
            _ProductSize.Size = txtProductSizes.Text.Trim();
            _ProductSize.ProductID = Product.ProductID;
            try
            {
                if (_ProductSize.Save())
                    return;
                else
                {
                    MessageBox.Show("Unable To Save Product Sizes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An Error Occurred {ex.Message}");
            }

        }
        private void UpdateSizes(clsProductCatalog Product)
        {
            _ProductSize = clsProductSize.Find(Product.ProductID);
            if (_ProductSize != null)
            {
                _ProductSize.Size = txtProductSizes.Text.Trim();
                try
                {
                    if (_ProductSize.Save())
                        return;
                    else
                    {
                        MessageBox.Show("Unable To Save Product Sizes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"An Error Occurred {ex.Message}");
                }
            }
            else
                return;
        }
        private bool SaveProductImagesInDB(int ProductID)
        {
            clsProductImages productImage;
            for (int i = 0; i < _SLImages.Count; i++)
            {
                productImage = new clsProductImages();
                productImage.ProductID = ProductID;
                productImage.ImageOrder = (short)_SLImages.Keys.IndexOf(i);
                productImage.ImageUrl = _SLImages[i];
                try
                {
                    if (productImage.Save())
                    {
                        continue;
                    }
                    else
                    {
                        MessageBox.Show("Unable To Save Product Images.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An Error Occurred {ex.Message}");
                }
            }
            return true;
    
        }
        private async void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Product.ProductName = txtboxProductName.Text.Trim();
            _Product.Price = Convert.ToDecimal(txtProductprice.Text.Trim());
            _Product.ImageURL = txtboxProductImage.Text.Trim();
            _Product.VideoURL = txtBoxVideo.Text.Trim();
            _Product.ShortDescription = txtboxDescription.Text.Trim();
            _Product.LongDescription = txtLongDescription.Text.Trim();
            _Product.CategoryID = _CategoryID;
            _Product.SubCategoryID = _SubCategoryID;
            _Product.QuantityInStock = Convert.ToInt32(txtQuantityInStock.Text.Trim());
            if (txtBoxDiscount.Text == string.Empty)
                _Product.Discount = 0;
            else
                _Product.Discount = Convert.ToInt32(txtBoxDiscount.Text.Trim());
            try
            {
                if (_Product.Save())
                {

                    if (SaveProductImagesInDB(_Product.ProductID))
                    {
                        if (_Mode == enMode.AddNew)
                        {
                            await Task.Run(() => SaveColorsInDB(_Product));
                            await Task.Run(() => SaveSizesInDB(_Product));
                            MessageBox.Show("Product Added Successfully.", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataBackNewProduct?.Invoke(this, _Product.ProductID);
                        }
                        else
                        {
                            await Task.Run(() => UpdateColors(_Product));
                            await Task.Run(() => UpdateSizes(_Product));
                            MessageBox.Show("Product Updated Successfully.", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataBackUpdatedProduct?.Invoke(this, _Product.ProductID);
                        }

                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Unable To Save Product.", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An Error Occurred {ex.Message}");
            }

        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategory.SelectedIndex != 0)
            {
                if (_Mode == enMode.AddNew)
                {
                    clsProductCategory productCategory = clsProductCategory.Find(cbCategory.Text);
                    if (productCategory == null)
                    {
                        MessageBox.Show("Category has been deleted.", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _CategoryID = productCategory.CategoryID;
                }
                else
                {
                    clsProductCategory productCategory = clsProductCategory.Find(_Product.Category.CategoryName);
                    if (productCategory == null)
                    {
                        MessageBox.Show("Category has been deleted.", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _CategoryID = productCategory.CategoryID;
                }
                _FillSubCategoriesInComboBox();
            }
            else
                return;
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                txtboxProductImage.Text = selectedFilePath;
                picThumbnail.ImageLocation = selectedFilePath;
            }
        }

        private void txtboxProductName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxProductName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtboxProductName, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtboxProductName, null);
            }
        }

        private void cbCategory_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cbCategory.Text.Trim())||cbCategory.SelectedIndex==0)
            {
                e.Cancel = true;
                errorProvider1.SetError(cbCategory, "Please Select Category!");
                return;
            }
            else
            {
                errorProvider1.SetError(cbCategory, null);
            }
        }

        private void txtboxDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtboxDescription, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtboxDescription, null);
            }
        }

        private void txtProductprice_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductprice.Text.Trim())|| decimal.TryParse(txtProductprice.Text,out decimal result)==false)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtProductprice, "This field is required, Only Numbers Allowed!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtProductprice, null);
            }
        }

        private void txtQuantityInStock_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtQuantityInStock.Text.Trim()) || decimal.TryParse(txtQuantityInStock.Text, out decimal result) == false)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtQuantityInStock, "This field is required, Only Numbers Allowed!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtQuantityInStock, null);
            }
        }

        private void cbSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSubCategory.SelectedIndex != 0)
            {
            
                    clsSubCategory subCategory = clsSubCategory.Find(cbSubCategory.SelectedItem.ToString());
                    if (subCategory == null)
                    {
                        MessageBox.Show("SubCategory has been deleted.", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _SubCategoryID = subCategory.SubCategoryID;
 
            }
            else
                return;
        }

        private void txtboxColors_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtboxColors.Text)&&!Regex.IsMatch(txtboxColors.Text,clsGlobal.pattern))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtboxColors, "This field is required, Only one space between Colors Allowed!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtboxColors, null);
            }
        }

        private void txtLongDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLongDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLongDescription, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtLongDescription, null);
            }
        }

        private void txtBoxDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private PictureBox selectedPictureBox;
        private Point previousMouseLocation;
        private void roundButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                txtBoxProductImages.Text = selectedFilePath;
                PictureBox picture = new PictureBox();
                picture.Size = new Size(119, 89);
                picture.SizeMode = PictureBoxSizeMode.Zoom;
                picture.ImageLocation = selectedFilePath;
                picture.Padding = new Padding(10);
                picture.AllowDrop = true;
                picture.MouseDown += Picture_MouseDown; 
                picture.MouseMove += Picture_MouseMove; 
                picture.MouseUp += Picture_MouseUp; 
                panelProductPics.Controls.Add(picture);
                int index = panelProductPics.Controls.IndexOf(picture);
                _SLImages.Add(index, selectedFilePath);
            }
        }

        private void Picture_MouseUp(object sender, MouseEventArgs e)
        {
            selectedPictureBox = null;
        }

        private void Picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (selectedPictureBox != null && e.Button == MouseButtons.Left)
            {
                // Calculate the distance moved by the mouse
                int deltaX = e.X - previousMouseLocation.X;
                int deltaY = e.Y - previousMouseLocation.Y;

                // Move the PictureBox control
                selectedPictureBox.Left += deltaX;
                selectedPictureBox.Top += deltaY;
            }
        }

        private void Picture_MouseDown(object sender, MouseEventArgs e)
        {
            selectedPictureBox = (PictureBox)sender; // Store the selected PictureBox
            previousMouseLocation = e.Location; // Store the initial mouse location
            if (e.Button == MouseButtons.Left)
            {
                PictureBox pictureBox = (PictureBox)sender;
                pictureBox.DoDragDrop(pictureBox, DragDropEffects.Move);
            }
        }

        private void panelProductPics_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PictureBox)))
            {
                e.Effect = DragDropEffects.Move; // Allow the PictureBox to be dropped
            }
        }

        private void panelProductPics_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox droppedPictureBox = (PictureBox)e.Data.GetData(typeof(PictureBox)); // Get the dropped PictureBox
            panelProductPics.Controls.Add(droppedPictureBox); // Add the dropped PictureBox to the FlowLayoutPanel
        }

        private void txtProductSizes_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductSizes.Text) && !Regex.IsMatch(txtboxColors.Text, clsGlobal.pattern))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtProductSizes, "This field is required, Only one space between Sizes Allowed!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtProductSizes, null);
            }
        }

        private void cbSubCategory_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cbSubCategory.Text.Trim()) || cbCategory.SelectedIndex == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(cbSubCategory, "Please Select SubCategory!");
                return;
            }
            else
            {
                errorProvider1.SetError(cbSubCategory, null);
            }
        }

        private void btnAddVideo_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "video Files|*.mp4";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                txtBoxVideo.Text = selectedFilePath;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBoxDiscount_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxDiscount.Text)&& !int.TryParse(txtBoxDiscount.Text, out int discount))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtBoxDiscount, "Only Numbers Allowed!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtBoxDiscount, null);
            }
        }
    }
}
