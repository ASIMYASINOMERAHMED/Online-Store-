namespace Online_Store_Project
{
    partial class ctrCategory
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.doubleBufferGunaPanel1 = new Online_Store_Project.DoubleBufferGunaPanel();
            this.panelSubCategories = new Online_Store_Project.DoubleBufferedFlowLayoutPanel();
            this.picCategory = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lbCategoryName = new System.Windows.Forms.Label();
            this.panelEditDelete = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.btnDelete = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnEdit = new Guna.UI2.WinForms.Guna2ImageButton();
            this.llAddSubCategory = new System.Windows.Forms.LinkLabel();
            this.doubleBufferGunaPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCategory)).BeginInit();
            this.panelEditDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // doubleBufferGunaPanel1
            // 
            this.doubleBufferGunaPanel1.BorderRadius = 30;
            this.doubleBufferGunaPanel1.Controls.Add(this.panelSubCategories);
            this.doubleBufferGunaPanel1.Controls.Add(this.picCategory);
            this.doubleBufferGunaPanel1.Controls.Add(this.lbCategoryName);
            this.doubleBufferGunaPanel1.Controls.Add(this.panelEditDelete);
            this.doubleBufferGunaPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doubleBufferGunaPanel1.DoubleBufferPanel = true;
            this.doubleBufferGunaPanel1.FillColor = System.Drawing.Color.RosyBrown;
            this.doubleBufferGunaPanel1.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.doubleBufferGunaPanel1.FillColor3 = System.Drawing.Color.Cyan;
            this.doubleBufferGunaPanel1.FillColor4 = System.Drawing.Color.MidnightBlue;
            this.doubleBufferGunaPanel1.Location = new System.Drawing.Point(0, 0);
            this.doubleBufferGunaPanel1.Name = "doubleBufferGunaPanel1";
            this.doubleBufferGunaPanel1.Size = new System.Drawing.Size(418, 560);
            this.doubleBufferGunaPanel1.TabIndex = 7;
            // 
            // panelSubCategories
            // 
            this.panelSubCategories.AutoScroll = true;
            this.panelSubCategories.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSubCategories.DoubleBufferPanel = true;
            this.panelSubCategories.ForeColor = System.Drawing.Color.White;
            this.panelSubCategories.Location = new System.Drawing.Point(0, 324);
            this.panelSubCategories.Name = "panelSubCategories";
            this.panelSubCategories.Size = new System.Drawing.Size(418, 172);
            this.panelSubCategories.TabIndex = 12;
            // 
            // picCategory
            // 
            this.picCategory.FillColor = System.Drawing.Color.Transparent;
            this.picCategory.ImageRotate = 0F;
            this.picCategory.Location = new System.Drawing.Point(18, 15);
            this.picCategory.Name = "picCategory";
            this.picCategory.Size = new System.Drawing.Size(380, 211);
            this.picCategory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCategory.TabIndex = 11;
            this.picCategory.TabStop = false;
            this.picCategory.UseTransparentBackground = true;
            this.picCategory.DoubleClick += new System.EventHandler(this.picCategory_DoubleClick);
            // 
            // lbCategoryName
            // 
            this.lbCategoryName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCategoryName.BackColor = System.Drawing.Color.Transparent;
            this.lbCategoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCategoryName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbCategoryName.Location = new System.Drawing.Point(19, 239);
            this.lbCategoryName.Name = "lbCategoryName";
            this.lbCategoryName.Size = new System.Drawing.Size(389, 82);
            this.lbCategoryName.TabIndex = 9;
            this.lbCategoryName.Text = "CategoryName";
            // 
            // panelEditDelete
            // 
            this.panelEditDelete.Controls.Add(this.btnDelete);
            this.panelEditDelete.Controls.Add(this.btnEdit);
            this.panelEditDelete.Controls.Add(this.llAddSubCategory);
            this.panelEditDelete.CustomBorderColor = System.Drawing.Color.Black;
            this.panelEditDelete.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEditDelete.FillColor = System.Drawing.Color.RosyBrown;
            this.panelEditDelete.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.panelEditDelete.FillColor3 = System.Drawing.Color.Cyan;
            this.panelEditDelete.FillColor4 = System.Drawing.Color.MidnightBlue;
            this.panelEditDelete.Location = new System.Drawing.Point(0, 496);
            this.panelEditDelete.Name = "panelEditDelete";
            this.panelEditDelete.Size = new System.Drawing.Size(418, 64);
            this.panelEditDelete.TabIndex = 7;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnDelete.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnDelete.Image = global::Online_Store_Project.Properties.Resources.delete;
            this.btnDelete.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnDelete.ImageRotate = 0F;
            this.btnDelete.Location = new System.Drawing.Point(350, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnDelete.Size = new System.Drawing.Size(58, 61);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.UseTransparentBackground = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnEdit.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnEdit.Image = global::Online_Store_Project.Properties.Resources.edit__3_;
            this.btnEdit.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnEdit.ImageRotate = 0F;
            this.btnEdit.Location = new System.Drawing.Point(271, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnEdit.Size = new System.Drawing.Size(55, 58);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.UseTransparentBackground = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // llAddSubCategory
            // 
            this.llAddSubCategory.AutoSize = true;
            this.llAddSubCategory.BackColor = System.Drawing.Color.Transparent;
            this.llAddSubCategory.Location = new System.Drawing.Point(17, 20);
            this.llAddSubCategory.Name = "llAddSubCategory";
            this.llAddSubCategory.Size = new System.Drawing.Size(179, 27);
            this.llAddSubCategory.TabIndex = 4;
            this.llAddSubCategory.TabStop = true;
            this.llAddSubCategory.Text = "Add SubCategory";
            this.llAddSubCategory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llAddSubCategory_LinkClicked);
            // 
            // ctrCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.doubleBufferGunaPanel1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.Name = "ctrCategory";
            this.Size = new System.Drawing.Size(418, 560);
            this.Load += new System.EventHandler(this.Category_Load);
            this.doubleBufferGunaPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCategory)).EndInit();
            this.panelEditDelete.ResumeLayout(false);
            this.panelEditDelete.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.LinkLabel llAddSubCategory;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel panelEditDelete;
        private Guna.UI2.WinForms.Guna2ImageButton btnDelete;
        private Guna.UI2.WinForms.Guna2ImageButton btnEdit;
        private DoubleBufferGunaPanel doubleBufferGunaPanel1;
        private Guna.UI2.WinForms.Guna2PictureBox picCategory;
        private System.Windows.Forms.Label lbCategoryName;
        private DoubleBufferedFlowLayoutPanel panelSubCategories;
    }
}
