using Microsoft.Win32;
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
    public partial class frmAddUpdateCategory : Form
    {
        private clsProductCategory _category;
        private int _CategoryID;
        public delegate void DataBackEventHandler(object sender, int CategoryID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;

        public frmAddUpdateCategory()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
            _category = new clsProductCategory();
            btnAddCategory.Text = "Add Category";
            this.Text = "Add Category";
        }
        public frmAddUpdateCategory(int CategoryID)
        {
            InitializeComponent();
            _CategoryID = CategoryID;
            _Mode = enMode.Update;
            btnAddCategory.Text = "Update Category";
            this.Text = "Update Category";
        }

        private void frmAddUpdateCategory_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
                _LoadData();

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
                txtboxCategoryImage.Text = selectedFilePath;
            }
        }

        private void txtboxCategoryName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxCategoryName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtboxCategoryName, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtboxCategoryName, null);
            }
            if (_Mode == enMode.Update)
                return;
            if (clsProductCategory.IsCategoryExist(txtboxCategoryName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtboxCategoryName, "Category Already Exist!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtboxCategoryName, null);
            }
        }

        private void txtboxCategoryImage_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxCategoryImage.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtboxCategoryImage, "Please Select an Image!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtboxCategoryImage, null);
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
    
            _category.CategoryName = txtboxCategoryName.Text.Trim();
            _category.CategoryImage = txtboxCategoryImage.Text.Trim();
            try
            {
                if (_category.Save())
                {
                    DataBack?.Invoke(this, _category.CategoryID);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An Error Occurred {ex.Message}");
            }

        }

        private void _LoadData()
        {
            _category = clsProductCategory.Find(_CategoryID);
            if (_category == null)
            {
                MessageBox.Show("Category Not Found.");
                return;
            }
            txtboxCategoryName.Text = _category.CategoryName;
            txtboxCategoryImage.Text = _category.CategoryImage;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
