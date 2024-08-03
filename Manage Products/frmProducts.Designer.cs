namespace Online_Store_Project
{
    partial class frmProducts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProducts));
            this.panelContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.lbNoProduct = new System.Windows.Forms.Label();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cbSubCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnSearch = new Guna.UI2.WinForms.Guna2ImageButton();
            this.txtBoxSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAddProduct = new Guna.UI2.WinForms.Guna2GradientButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.lbTotalPages = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnBackPage = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnNextPage = new Guna.UI2.WinForms.Guna2ImageButton();
            this.lbPageNumber = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2CustomGradientPanel2 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.guna2CustomGradientPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.AutoScroll = true;
            this.panelContainer.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 133);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1608, 757);
            this.panelContainer.TabIndex = 0;
            // 
            // lbNoProduct
            // 
            this.lbNoProduct.AutoSize = true;
            this.lbNoProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoProduct.ForeColor = System.Drawing.Color.Red;
            this.lbNoProduct.Location = new System.Drawing.Point(1117, 459);
            this.lbNoProduct.Name = "lbNoProduct";
            this.lbNoProduct.Size = new System.Drawing.Size(410, 42);
            this.lbNoProduct.TabIndex = 1;
            this.lbNoProduct.Text = "--No Products Found--";
            this.lbNoProduct.Visible = false;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(578, 49);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(200, 39);
            this.guna2HtmlLabel1.TabIndex = 186;
            this.guna2HtmlLabel1.Text = "SubCategory";
            // 
            // cbSubCategory
            // 
            this.cbSubCategory.BackColor = System.Drawing.Color.Transparent;
            this.cbSubCategory.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbSubCategory.BorderRadius = 20;
            this.cbSubCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSubCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubCategory.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbSubCategory.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbSubCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbSubCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbSubCategory.ItemHeight = 30;
            this.cbSubCategory.Items.AddRange(new object[] {
            "All"});
            this.cbSubCategory.Location = new System.Drawing.Point(782, 49);
            this.cbSubCategory.Name = "cbSubCategory";
            this.cbSubCategory.Size = new System.Drawing.Size(381, 36);
            this.cbSubCategory.TabIndex = 185;
            this.cbSubCategory.SelectedIndexChanged += new System.EventHandler(this.cbSubCategory_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.AnimatedGIF = true;
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnSearch.ImageRotate = 0F;
            this.btnSearch.Location = new System.Drawing.Point(478, 35);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnSearch.Size = new System.Drawing.Size(64, 66);
            this.btnSearch.TabIndex = 184;
            this.btnSearch.UseTransparentBackground = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtBoxSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBoxSearch.BorderRadius = 20;
            this.txtBoxSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBoxSearch.DefaultText = "";
            this.txtBoxSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBoxSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBoxSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxSearch.Location = new System.Drawing.Point(18, 32);
            this.txtBoxSearch.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.PasswordChar = '\0';
            this.txtBoxSearch.PlaceholderText = "Search Product";
            this.txtBoxSearch.SelectedText = "";
            this.txtBoxSearch.Size = new System.Drawing.Size(533, 72);
            this.txtBoxSearch.TabIndex = 183;
            this.txtBoxSearch.TextChanged += new System.EventHandler(this.txtBoxSearch_TextChanged);
            this.txtBoxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxSearch_KeyPress);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddProduct.Animated = true;
            this.btnAddProduct.AnimatedGIF = true;
            this.btnAddProduct.BackColor = System.Drawing.Color.Transparent;
            this.btnAddProduct.BorderColor = System.Drawing.Color.DimGray;
            this.btnAddProduct.BorderRadius = 20;
            this.btnAddProduct.BorderThickness = 1;
            this.btnAddProduct.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddProduct.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddProduct.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddProduct.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnAddProduct.FillColor2 = System.Drawing.Color.LightSkyBlue;
            this.btnAddProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProduct.ForeColor = System.Drawing.Color.White;
            this.btnAddProduct.Location = new System.Drawing.Point(1197, 32);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(399, 68);
            this.btnAddProduct.TabIndex = 182;
            this.btnAddProduct.Tag = "";
            this.btnAddProduct.Text = "Add Product";
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.BorderRadius = 20;
            this.guna2CustomGradientPanel1.BorderThickness = 1;
            this.guna2CustomGradientPanel1.Controls.Add(this.lbTotalPages);
            this.guna2CustomGradientPanel1.Controls.Add(this.guna2HtmlLabel2);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnBackPage);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnNextPage);
            this.guna2CustomGradientPanel1.Controls.Add(this.lbPageNumber);
            this.guna2CustomGradientPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.RoyalBlue;
            this.guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.MidnightBlue;
            this.guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.MediumBlue;
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(0, 890);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(1608, 103);
            this.guna2CustomGradientPanel1.TabIndex = 2;
            // 
            // lbTotalPages
            // 
            this.lbTotalPages.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalPages.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lbTotalPages.Location = new System.Drawing.Point(876, 36);
            this.lbTotalPages.Name = "lbTotalPages";
            this.lbTotalPages.Size = new System.Drawing.Size(19, 39);
            this.lbTotalPages.TabIndex = 4;
            this.lbTotalPages.Text = "1";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.DimGray;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(848, 36);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(12, 39);
            this.guna2HtmlLabel2.TabIndex = 3;
            this.guna2HtmlLabel2.Text = "/";
            // 
            // btnBackPage
            // 
            this.btnBackPage.BackColor = System.Drawing.Color.Transparent;
            this.btnBackPage.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnBackPage.HoverState.ImageFlip = Guna.UI2.WinForms.Enums.FlipOrientation.Horizontal;
            this.btnBackPage.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnBackPage.Image = ((System.Drawing.Image)(resources.GetObject("btnBackPage.Image")));
            this.btnBackPage.ImageFlip = Guna.UI2.WinForms.Enums.FlipOrientation.Horizontal;
            this.btnBackPage.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnBackPage.ImageRotate = 0F;
            this.btnBackPage.Location = new System.Drawing.Point(672, 24);
            this.btnBackPage.Name = "btnBackPage";
            this.btnBackPage.PressedState.ImageFlip = Guna.UI2.WinForms.Enums.FlipOrientation.Horizontal;
            this.btnBackPage.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnBackPage.Size = new System.Drawing.Size(64, 67);
            this.btnBackPage.TabIndex = 2;
            this.btnBackPage.Click += new System.EventHandler(this.btnBackPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.BackColor = System.Drawing.Color.Transparent;
            this.btnNextPage.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnNextPage.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnNextPage.Image = ((System.Drawing.Image)(resources.GetObject("btnNextPage.Image")));
            this.btnNextPage.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnNextPage.ImageRotate = 0F;
            this.btnNextPage.Location = new System.Drawing.Point(959, 23);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnNextPage.Size = new System.Drawing.Size(64, 67);
            this.btnNextPage.TabIndex = 1;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // lbPageNumber
            // 
            this.lbPageNumber.BackColor = System.Drawing.Color.Transparent;
            this.lbPageNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPageNumber.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lbPageNumber.Location = new System.Drawing.Point(795, 36);
            this.lbPageNumber.Name = "lbPageNumber";
            this.lbPageNumber.Size = new System.Drawing.Size(19, 39);
            this.lbPageNumber.TabIndex = 0;
            this.lbPageNumber.Text = "1";
            // 
            // guna2CustomGradientPanel2
            // 
            this.guna2CustomGradientPanel2.BorderRadius = 10;
            this.guna2CustomGradientPanel2.Controls.Add(this.btnSearch);
            this.guna2CustomGradientPanel2.Controls.Add(this.guna2HtmlLabel1);
            this.guna2CustomGradientPanel2.Controls.Add(this.txtBoxSearch);
            this.guna2CustomGradientPanel2.Controls.Add(this.btnAddProduct);
            this.guna2CustomGradientPanel2.Controls.Add(this.cbSubCategory);
            this.guna2CustomGradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2CustomGradientPanel2.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.guna2CustomGradientPanel2.FillColor2 = System.Drawing.Color.RoyalBlue;
            this.guna2CustomGradientPanel2.FillColor3 = System.Drawing.Color.MidnightBlue;
            this.guna2CustomGradientPanel2.FillColor4 = System.Drawing.Color.MediumBlue;
            this.guna2CustomGradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.guna2CustomGradientPanel2.Name = "guna2CustomGradientPanel2";
            this.guna2CustomGradientPanel2.Size = new System.Drawing.Size(1608, 133);
            this.guna2CustomGradientPanel2.TabIndex = 0;
            // 
            // frmProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1608, 993);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.guna2CustomGradientPanel2);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Controls.Add(this.lbNoProduct);
            this.Name = "frmProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Products";
            this.Load += new System.EventHandler(this.frmProducts_Load);
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.PerformLayout();
            this.guna2CustomGradientPanel2.ResumeLayout(false);
            this.guna2CustomGradientPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panelContainer;
        private System.Windows.Forms.Label lbNoProduct;
        private Guna.UI2.WinForms.Guna2GradientButton btnAddProduct;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2ComboBox cbSubCategory;
        private Guna.UI2.WinForms.Guna2ImageButton btnSearch;
        private Guna.UI2.WinForms.Guna2TextBox txtBoxSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbTotalPages;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2ImageButton btnBackPage;
        private Guna.UI2.WinForms.Guna2ImageButton btnNextPage;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbPageNumber;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel2;
    }
}