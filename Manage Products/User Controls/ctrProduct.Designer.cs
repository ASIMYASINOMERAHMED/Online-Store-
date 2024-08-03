namespace Online_Store_Project
{
    partial class ctrProduct
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
            this.lbName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.panelEditDelete = new System.Windows.Forms.Panel();
            this.lbQuantity = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbDescription = new System.Windows.Forms.Label();
            this.btnAddToCart = new Guna.UI2.WinForms.Guna2GradientButton();
            this.lbDiscount = new System.Windows.Forms.Label();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.pictureBoxItem = new Guna.UI2.WinForms.Guna2PictureBox();
            this.picAddToFavourit = new Guna.UI2.WinForms.Guna2ImageButton();
            this.ctrRatings1 = new Online_Store_Project.ctrRatings();
            this.panelEditDelete.SuspendLayout();
            this.guna2CustomGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem)).BeginInit();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.Color.DimGray;
            this.lbName.Location = new System.Drawing.Point(14, 273);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(82, 29);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(14, 434);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Price :";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrice.ForeColor = System.Drawing.Color.DimGray;
            this.lbPrice.Location = new System.Drawing.Point(108, 434);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(52, 29);
            this.lbPrice.TabIndex = 3;
            this.lbPrice.Text = "???";
            // 
            // panelEditDelete
            // 
            this.panelEditDelete.Controls.Add(this.lbQuantity);
            this.panelEditDelete.Controls.Add(this.label3);
            this.panelEditDelete.Controls.Add(this.btnEdit);
            this.panelEditDelete.Controls.Add(this.btnDelete);
            this.panelEditDelete.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEditDelete.Location = new System.Drawing.Point(0, 667);
            this.panelEditDelete.Name = "panelEditDelete";
            this.panelEditDelete.Size = new System.Drawing.Size(424, 64);
            this.panelEditDelete.TabIndex = 5;
            // 
            // lbQuantity
            // 
            this.lbQuantity.AutoSize = true;
            this.lbQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuantity.Location = new System.Drawing.Point(128, 18);
            this.lbQuantity.Name = "lbQuantity";
            this.lbQuantity.Size = new System.Drawing.Size(52, 29);
            this.lbQuantity.TabIndex = 9;
            this.lbQuantity.Text = "???";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 29);
            this.label3.TabIndex = 9;
            this.label3.Text = "Quantity";
            // 
            // btnEdit
            // 
            this.btnEdit.BackgroundImage = global::Online_Store_Project.Properties.Resources.edit__3_;
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEdit.Location = new System.Drawing.Point(270, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(59, 58);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = global::Online_Store_Project.Properties.Resources.delete;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.Location = new System.Drawing.Point(335, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 58);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(14, 498);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "Rating";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(14, 326);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 29);
            this.label4.TabIndex = 9;
            this.label4.Text = "Description";
            // 
            // lbDescription
            // 
            this.lbDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescription.ForeColor = System.Drawing.Color.DimGray;
            this.lbDescription.Location = new System.Drawing.Point(34, 367);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(361, 66);
            this.lbDescription.TabIndex = 10;
            this.lbDescription.Text = "???";
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddToCart.Animated = true;
            this.btnAddToCart.AnimatedGIF = true;
            this.btnAddToCart.BorderRadius = 20;
            this.btnAddToCart.BorderThickness = 1;
            this.btnAddToCart.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddToCart.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddToCart.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddToCart.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddToCart.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddToCart.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnAddToCart.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnAddToCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToCart.ForeColor = System.Drawing.Color.White;
            this.btnAddToCart.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.btnAddToCart.Image = global::Online_Store_Project.Properties.Resources.shopping_cart__4_;
            this.btnAddToCart.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddToCart.ImageSize = new System.Drawing.Size(48, 48);
            this.btnAddToCart.Location = new System.Drawing.Point(19, 600);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(331, 55);
            this.btnAddToCart.TabIndex = 184;
            this.btnAddToCart.Tag = "";
            this.btnAddToCart.Text = "Add To Cart";
            this.btnAddToCart.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToBasket_Click);
            // 
            // lbDiscount
            // 
            this.lbDiscount.AutoSize = true;
            this.lbDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbDiscount.Location = new System.Drawing.Point(265, 434);
            this.lbDiscount.Name = "lbDiscount";
            this.lbDiscount.Size = new System.Drawing.Size(51, 34);
            this.lbDiscount.TabIndex = 188;
            this.lbDiscount.Text = "???";
            this.lbDiscount.UseCompatibleTextRendering = true;
            this.lbDiscount.Paint += new System.Windows.Forms.PaintEventHandler(this.lbDiscount_Paint);
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.BorderRadius = 20;
            this.guna2CustomGradientPanel1.Controls.Add(this.pictureBoxItem);
            this.guna2CustomGradientPanel1.Controls.Add(this.picAddToFavourit);
            this.guna2CustomGradientPanel1.Controls.Add(this.panelEditDelete);
            this.guna2CustomGradientPanel1.Controls.Add(this.lbDiscount);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnAddToCart);
            this.guna2CustomGradientPanel1.Controls.Add(this.label2);
            this.guna2CustomGradientPanel1.Controls.Add(this.lbName);
            this.guna2CustomGradientPanel1.Controls.Add(this.lbDescription);
            this.guna2CustomGradientPanel1.Controls.Add(this.label1);
            this.guna2CustomGradientPanel1.Controls.Add(this.label4);
            this.guna2CustomGradientPanel1.Controls.Add(this.lbPrice);
            this.guna2CustomGradientPanel1.Controls.Add(this.ctrRatings1);
            this.guna2CustomGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(424, 731);
            this.guna2CustomGradientPanel1.TabIndex = 189;
            // 
            // pictureBoxItem
            // 
            this.pictureBoxItem.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxItem.ImageRotate = 0F;
            this.pictureBoxItem.Location = new System.Drawing.Point(19, 15);
            this.pictureBoxItem.Name = "pictureBoxItem";
            this.pictureBoxItem.Size = new System.Drawing.Size(383, 241);
            this.pictureBoxItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxItem.TabIndex = 190;
            this.pictureBoxItem.TabStop = false;
            this.pictureBoxItem.UseTransparentBackground = true;
            this.pictureBoxItem.Click += new System.EventHandler(this.pictureBoxItem_Click);
            // 
            // picAddToFavourit
            // 
            this.picAddToFavourit.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.picAddToFavourit.HoverState.Image = global::Online_Store_Project.Properties.Resources.heart__3_;
            this.picAddToFavourit.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.picAddToFavourit.Image = global::Online_Store_Project.Properties.Resources.heart;
            this.picAddToFavourit.ImageOffset = new System.Drawing.Point(0, 0);
            this.picAddToFavourit.ImageRotate = 0F;
            this.picAddToFavourit.Location = new System.Drawing.Point(356, 599);
            this.picAddToFavourit.Name = "picAddToFavourit";
            this.picAddToFavourit.PressedState.Image = global::Online_Store_Project.Properties.Resources.heart__4_;
            this.picAddToFavourit.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.picAddToFavourit.Size = new System.Drawing.Size(60, 56);
            this.picAddToFavourit.TabIndex = 189;
            this.picAddToFavourit.Click += new System.EventHandler(this.picAddToFavourit_Click);
            // 
            // ctrRatings1
            // 
            this.ctrRatings1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ctrRatings1.Location = new System.Drawing.Point(19, 539);
            this.ctrRatings1.Name = "ctrRatings1";
            this.ctrRatings1.Size = new System.Drawing.Size(378, 55);
            this.ctrRatings1.TabIndex = 6;
            // 
            // ctrProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.Name = "ctrProduct";
            this.Size = new System.Drawing.Size(424, 731);
            this.Load += new System.EventHandler(this.ctrProduct_Load);
            this.panelEditDelete.ResumeLayout(false);
            this.panelEditDelete.PerformLayout();
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.Panel panelEditDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private ctrRatings ctrRatings1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbDescription;
        private Guna.UI2.WinForms.Guna2GradientButton btnAddToCart;
        private System.Windows.Forms.Label lbDiscount;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2ImageButton picAddToFavourit;
        private Guna.UI2.WinForms.Guna2PictureBox pictureBoxItem;
    }
}
