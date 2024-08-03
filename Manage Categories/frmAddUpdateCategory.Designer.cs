namespace Online_Store_Project
{
    partial class frmAddUpdateCategory
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddUpdateCategory));
            this.label3 = new System.Windows.Forms.Label();
            this.btnChooseImage = new Online_Store_Project.RoundButton();
            this.txtboxCategoryImage = new Online_Store_Project.RoundTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtboxCategoryName = new Online_Store_Project.RoundTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnAddCategory = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.btnClose = new Guna.UI2.WinForms.Guna2ImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(319, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(259, 42);
            this.label3.TabIndex = 25;
            this.label3.Text = "Add Category";
            // 
            // btnChooseImage
            // 
            this.btnChooseImage.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnChooseImage.BackgroundImage = global::Online_Store_Project.Properties.Resources.more_vertical;
            this.btnChooseImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnChooseImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChooseImage.FlatAppearance.BorderSize = 0;
            this.btnChooseImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChooseImage.Location = new System.Drawing.Point(744, 261);
            this.btnChooseImage.Name = "btnChooseImage";
            this.btnChooseImage.Size = new System.Drawing.Size(50, 41);
            this.btnChooseImage.TabIndex = 24;
            this.btnChooseImage.UseVisualStyleBackColor = false;
            this.btnChooseImage.Click += new System.EventHandler(this.btnChooseImage_Click);
            // 
            // txtboxCategoryImage
            // 
            this.txtboxCategoryImage.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtboxCategoryImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtboxCategoryImage.Enabled = false;
            this.txtboxCategoryImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxCategoryImage.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtboxCategoryImage.Location = new System.Drawing.Point(269, 257);
            this.txtboxCategoryImage.Multiline = true;
            this.txtboxCategoryImage.Name = "txtboxCategoryImage";
            this.txtboxCategoryImage.Size = new System.Drawing.Size(527, 51);
            this.txtboxCategoryImage.TabIndex = 22;
            this.txtboxCategoryImage.Validating += new System.ComponentModel.CancelEventHandler(this.txtboxCategoryImage_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(53, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 29);
            this.label2.TabIndex = 21;
            this.label2.Text = "Category Image";
            // 
            // txtboxCategoryName
            // 
            this.txtboxCategoryName.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtboxCategoryName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtboxCategoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxCategoryName.Location = new System.Drawing.Point(269, 155);
            this.txtboxCategoryName.Multiline = true;
            this.txtboxCategoryName.Name = "txtboxCategoryName";
            this.txtboxCategoryName.Size = new System.Drawing.Size(527, 51);
            this.txtboxCategoryName.TabIndex = 20;
            this.txtboxCategoryName.Validating += new System.ComponentModel.CancelEventHandler(this.txtboxCategoryName_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 29);
            this.label1.TabIndex = 19;
            this.label1.Text = "Category Name";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCategory.Animated = true;
            this.btnAddCategory.AnimatedGIF = true;
            this.btnAddCategory.BorderRadius = 20;
            this.btnAddCategory.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddCategory.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddCategory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddCategory.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddCategory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddCategory.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnAddCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCategory.ForeColor = System.Drawing.Color.White;
            this.btnAddCategory.Location = new System.Drawing.Point(269, 360);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(527, 68);
            this.btnAddCategory.TabIndex = 26;
            this.btnAddCategory.Tag = "";
            this.btnAddCategory.Text = "Add Category";
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.AnimateWindow = true;
            this.guna2BorderlessForm1.BorderRadius = 40;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnClose.HoverState.Image = global::Online_Store_Project.Properties.Resources.close__2_;
            this.btnClose.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnClose.ImageRotate = 0F;
            this.btnClose.Location = new System.Drawing.Point(772, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.PressedState.Image = global::Online_Store_Project.Properties.Resources.close__3_;
            this.btnClose.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnClose.Size = new System.Drawing.Size(64, 58);
            this.btnClose.TabIndex = 192;
            this.btnClose.UseTransparentBackground = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAddUpdateCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(848, 453);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnChooseImage);
            this.Controls.Add(this.txtboxCategoryImage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtboxCategoryName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddUpdateCategory";
            this.Text = "frmAddUpdateCategory";
            this.Load += new System.EventHandler(this.frmAddUpdateCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private RoundButton btnChooseImage;
        private RoundTextBox txtboxCategoryImage;
        private System.Windows.Forms.Label label2;
        private RoundTextBox txtboxCategoryName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2GradientButton btnAddCategory;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ImageButton btnClose;
    }
}