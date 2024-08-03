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
    public partial class frmAddSubCategory : Form
    {
        private int _SubCategoryID;
        private enum enMode { AddNew=1,Update=2}
        private enMode Mode;
        private clsSubCategory _SubCategory;
        private int _CategoryID;
        public frmAddSubCategory(int CategoryID)
        {
            InitializeComponent();
            _CategoryID = CategoryID;
            Mode = enMode.AddNew;
        }
        public frmAddSubCategory(int SubCategoryID,int CategoryID)
        {
            InitializeComponent();
            _SubCategoryID = SubCategoryID;
            _CategoryID = CategoryID;
            Mode = enMode.Update;
        }
        public delegate void DataBackEventHandler(object sender, string SubCategoryName);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;
        private void txtboxCategoryName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxSubCategoryName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtboxSubCategoryName, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtboxSubCategoryName, null);
            }
            if (clsSubCategory.IsSubCategoryExist(txtboxSubCategoryName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtboxSubCategoryName, "SubCategory Already Exist!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtboxSubCategoryName, null);
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _SubCategory = new clsSubCategory();
            _SubCategory.SubCategoryName = txtboxSubCategoryName.Text.Trim();
            _SubCategory.CategoryID = _CategoryID;
            try
            {
                if (_SubCategory.Save())
                {
                    MessageBox.Show("SubCategory has been Added", "succss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataBack?.Invoke(this, _SubCategory.SubCategoryName);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Unable to Add SubCategory", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An Error Occurred {ex.Message}");
            }
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
