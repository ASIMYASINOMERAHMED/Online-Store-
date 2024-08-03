namespace Online_Store_Project
{
    partial class frmAddUpdateProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddUpdateProduct));
            this.lbTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.picThumbnail = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panelProductPics = new System.Windows.Forms.FlowLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.txtboxProductName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtProductprice = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtBoxDiscount = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtQuantityInStock = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtboxDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtboxColors = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtProductSizes = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbSubCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnAddUpdateProduct = new Guna.UI2.WinForms.Guna2GradientButton();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.btnClose = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnAddVideo = new Online_Store_Project.RoundButton();
            this.txtBoxVideo = new Online_Store_Project.RoundTextBox();
            this.roundButton1 = new Online_Store_Project.RoundButton();
            this.txtBoxProductImages = new Online_Store_Project.RoundTextBox();
            this.btnChooseImage = new Online_Store_Project.RoundButton();
            this.txtboxProductImage = new Online_Store_Project.RoundTextBox();
            this.txtLongDescription = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThumbnail)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbTitle.Location = new System.Drawing.Point(609, 25);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(235, 42);
            this.lbTitle.TabIndex = 24;
            this.lbTitle.Text = "Add Product";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(892, 423);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 29);
            this.label2.TabIndex = 21;
            this.label2.Text = "Product Thumbnail*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(100, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 29);
            this.label1.TabIndex = 19;
            this.label1.Text = "Product Title*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(954, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 29);
            this.label3.TabIndex = 25;
            this.label3.Text = "Product Price*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(48, 416);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(226, 29);
            this.label4.TabIndex = 28;
            this.label4.Text = "Short Description*";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(48, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(226, 29);
            this.label5.TabIndex = 30;
            this.label5.Text = "Product Category*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(917, 326);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(219, 29);
            this.label6.TabIndex = 32;
            this.label6.Text = "Quantity In Stock*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(2, 315);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(272, 29);
            this.label7.TabIndex = 34;
            this.label7.Text = "Product SubCategory*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(76, 812);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(198, 29);
            this.label8.TabIndex = 36;
            this.label8.Text = "Product Colors*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1011, 230);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 29);
            this.label9.TabIndex = 38;
            this.label9.Text = "Discount";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(48, 608);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(222, 29);
            this.label10.TabIndex = 40;
            this.label10.Text = "Long Description*";
            // 
            // picThumbnail
            // 
            this.picThumbnail.Location = new System.Drawing.Point(1157, 484);
            this.picThumbnail.Name = "picThumbnail";
            this.picThumbnail.Size = new System.Drawing.Size(119, 89);
            this.picThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picThumbnail.TabIndex = 42;
            this.picThumbnail.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(944, 597);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(206, 29);
            this.label12.TabIndex = 43;
            this.label12.Text = "Product Images*";
            // 
            // panelProductPics
            // 
            this.panelProductPics.AutoScroll = true;
            this.panelProductPics.Location = new System.Drawing.Point(939, 651);
            this.panelProductPics.Name = "panelProductPics";
            this.panelProductPics.Size = new System.Drawing.Size(476, 269);
            this.panelProductPics.TabIndex = 48;
            this.panelProductPics.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelProductPics_DragDrop);
            this.panelProductPics.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelProductPics_DragEnter);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(85, 966);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(185, 29);
            this.label13.TabIndex = 49;
            this.label13.Text = "Product Sizes*";
            // 
            // txtboxProductName
            // 
            this.txtboxProductName.Animated = true;
            this.txtboxProductName.BorderColor = System.Drawing.Color.Black;
            this.txtboxProductName.BorderRadius = 20;
            this.txtboxProductName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtboxProductName.DefaultText = "";
            this.txtboxProductName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtboxProductName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtboxProductName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtboxProductName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtboxProductName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtboxProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxProductName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtboxProductName.Location = new System.Drawing.Point(314, 110);
            this.txtboxProductName.Margin = new System.Windows.Forms.Padding(6);
            this.txtboxProductName.Name = "txtboxProductName";
            this.txtboxProductName.PasswordChar = '\0';
            this.txtboxProductName.PlaceholderText = "";
            this.txtboxProductName.SelectedText = "";
            this.txtboxProductName.Size = new System.Drawing.Size(527, 53);
            this.txtboxProductName.TabIndex = 51;
            this.txtboxProductName.Validating += new System.ComponentModel.CancelEventHandler(this.txtboxProductName_Validating);
            // 
            // txtProductprice
            // 
            this.txtProductprice.Animated = true;
            this.txtProductprice.BorderColor = System.Drawing.Color.Black;
            this.txtProductprice.BorderRadius = 20;
            this.txtProductprice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProductprice.DefaultText = "";
            this.txtProductprice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtProductprice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtProductprice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProductprice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProductprice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProductprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductprice.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProductprice.Location = new System.Drawing.Point(1157, 110);
            this.txtProductprice.Margin = new System.Windows.Forms.Padding(6);
            this.txtProductprice.Name = "txtProductprice";
            this.txtProductprice.PasswordChar = '\0';
            this.txtProductprice.PlaceholderText = "";
            this.txtProductprice.SelectedText = "";
            this.txtProductprice.Size = new System.Drawing.Size(258, 53);
            this.txtProductprice.TabIndex = 52;
            this.txtProductprice.Validating += new System.ComponentModel.CancelEventHandler(this.txtProductprice_Validating);
            // 
            // txtBoxDiscount
            // 
            this.txtBoxDiscount.Animated = true;
            this.txtBoxDiscount.BorderColor = System.Drawing.Color.Black;
            this.txtBoxDiscount.BorderRadius = 20;
            this.txtBoxDiscount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBoxDiscount.DefaultText = "";
            this.txtBoxDiscount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBoxDiscount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBoxDiscount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxDiscount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxDiscount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxDiscount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxDiscount.Location = new System.Drawing.Point(1157, 210);
            this.txtBoxDiscount.Margin = new System.Windows.Forms.Padding(6);
            this.txtBoxDiscount.Name = "txtBoxDiscount";
            this.txtBoxDiscount.PasswordChar = '\0';
            this.txtBoxDiscount.PlaceholderText = "0";
            this.txtBoxDiscount.SelectedText = "";
            this.txtBoxDiscount.Size = new System.Drawing.Size(258, 53);
            this.txtBoxDiscount.TabIndex = 53;
            this.txtBoxDiscount.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxDiscount_Validating);
            // 
            // txtQuantityInStock
            // 
            this.txtQuantityInStock.Animated = true;
            this.txtQuantityInStock.BorderColor = System.Drawing.Color.Black;
            this.txtQuantityInStock.BorderRadius = 20;
            this.txtQuantityInStock.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtQuantityInStock.DefaultText = "";
            this.txtQuantityInStock.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtQuantityInStock.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtQuantityInStock.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtQuantityInStock.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtQuantityInStock.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtQuantityInStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantityInStock.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtQuantityInStock.Location = new System.Drawing.Point(1157, 315);
            this.txtQuantityInStock.Margin = new System.Windows.Forms.Padding(6);
            this.txtQuantityInStock.Name = "txtQuantityInStock";
            this.txtQuantityInStock.PasswordChar = '\0';
            this.txtQuantityInStock.PlaceholderText = "";
            this.txtQuantityInStock.SelectedText = "";
            this.txtQuantityInStock.Size = new System.Drawing.Size(267, 53);
            this.txtQuantityInStock.TabIndex = 54;
            this.txtQuantityInStock.Validating += new System.ComponentModel.CancelEventHandler(this.txtQuantityInStock_Validating);
            // 
            // txtboxDescription
            // 
            this.txtboxDescription.AcceptsReturn = true;
            this.txtboxDescription.AcceptsTab = true;
            this.txtboxDescription.Animated = true;
            this.txtboxDescription.AutoSize = true;
            this.txtboxDescription.BorderColor = System.Drawing.Color.Black;
            this.txtboxDescription.BorderRadius = 20;
            this.txtboxDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtboxDescription.DefaultText = "";
            this.txtboxDescription.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtboxDescription.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtboxDescription.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtboxDescription.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtboxDescription.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtboxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxDescription.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtboxDescription.Location = new System.Drawing.Point(314, 392);
            this.txtboxDescription.Margin = new System.Windows.Forms.Padding(6);
            this.txtboxDescription.Multiline = true;
            this.txtboxDescription.Name = "txtboxDescription";
            this.txtboxDescription.PasswordChar = '\0';
            this.txtboxDescription.PlaceholderText = "";
            this.txtboxDescription.SelectedText = "";
            this.txtboxDescription.Size = new System.Drawing.Size(527, 141);
            this.txtboxDescription.TabIndex = 55;
            this.txtboxDescription.Validating += new System.ComponentModel.CancelEventHandler(this.txtboxDescription_Validating);
            // 
            // txtboxColors
            // 
            this.txtboxColors.AcceptsReturn = true;
            this.txtboxColors.Animated = true;
            this.txtboxColors.BorderColor = System.Drawing.Color.Black;
            this.txtboxColors.BorderRadius = 20;
            this.txtboxColors.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtboxColors.DefaultText = "";
            this.txtboxColors.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtboxColors.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtboxColors.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtboxColors.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtboxColors.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtboxColors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxColors.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtboxColors.Location = new System.Drawing.Point(314, 791);
            this.txtboxColors.Margin = new System.Windows.Forms.Padding(6);
            this.txtboxColors.Multiline = true;
            this.txtboxColors.Name = "txtboxColors";
            this.txtboxColors.PasswordChar = '\0';
            this.txtboxColors.PlaceholderText = "Write each color in a new line...";
            this.txtboxColors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtboxColors.SelectedText = "";
            this.txtboxColors.Size = new System.Drawing.Size(527, 100);
            this.txtboxColors.TabIndex = 57;
            this.txtboxColors.Validating += new System.ComponentModel.CancelEventHandler(this.txtboxColors_Validating);
            // 
            // txtProductSizes
            // 
            this.txtProductSizes.AcceptsReturn = true;
            this.txtProductSizes.Animated = true;
            this.txtProductSizes.BorderColor = System.Drawing.Color.Black;
            this.txtProductSizes.BorderRadius = 20;
            this.txtProductSizes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProductSizes.DefaultText = "";
            this.txtProductSizes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtProductSizes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtProductSizes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProductSizes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProductSizes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProductSizes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductSizes.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProductSizes.Location = new System.Drawing.Point(314, 941);
            this.txtProductSizes.Margin = new System.Windows.Forms.Padding(6);
            this.txtProductSizes.Multiline = true;
            this.txtProductSizes.Name = "txtProductSizes";
            this.txtProductSizes.PasswordChar = '\0';
            this.txtProductSizes.PlaceholderText = "Write each size in a new line...";
            this.txtProductSizes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtProductSizes.SelectedText = "";
            this.txtProductSizes.Size = new System.Drawing.Size(527, 100);
            this.txtProductSizes.TabIndex = 58;
            this.txtProductSizes.Validating += new System.ComponentModel.CancelEventHandler(this.txtProductSizes_Validating);
            // 
            // cbCategory
            // 
            this.cbCategory.BackColor = System.Drawing.Color.Transparent;
            this.cbCategory.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbCategory.BorderRadius = 20;
            this.cbCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbCategory.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbCategory.ItemHeight = 30;
            this.cbCategory.Items.AddRange(new object[] {
            "--SELECT--"});
            this.cbCategory.ItemsAppearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategory.Location = new System.Drawing.Point(314, 230);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(527, 36);
            this.cbCategory.TabIndex = 59;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            this.cbCategory.Validating += new System.ComponentModel.CancelEventHandler(this.cbCategory_Validating);
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
            this.cbSubCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSubCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbSubCategory.ItemHeight = 30;
            this.cbSubCategory.ItemsAppearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSubCategory.Location = new System.Drawing.Point(314, 315);
            this.cbSubCategory.Name = "cbSubCategory";
            this.cbSubCategory.Size = new System.Drawing.Size(527, 36);
            this.cbSubCategory.TabIndex = 60;
            this.cbSubCategory.SelectedIndexChanged += new System.EventHandler(this.cbSubCategory_SelectedIndexChanged);
            this.cbSubCategory.Validating += new System.ComponentModel.CancelEventHandler(this.cbSubCategory_Validating);
            // 
            // btnAddUpdateProduct
            // 
            this.btnAddUpdateProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddUpdateProduct.Animated = true;
            this.btnAddUpdateProduct.AnimatedGIF = true;
            this.btnAddUpdateProduct.BackColor = System.Drawing.Color.Transparent;
            this.btnAddUpdateProduct.BorderRadius = 20;
            this.btnAddUpdateProduct.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddUpdateProduct.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddUpdateProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddUpdateProduct.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddUpdateProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddUpdateProduct.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnAddUpdateProduct.FillColor2 = System.Drawing.Color.LightSkyBlue;
            this.btnAddUpdateProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUpdateProduct.ForeColor = System.Drawing.Color.White;
            this.btnAddUpdateProduct.Location = new System.Drawing.Point(938, 1019);
            this.btnAddUpdateProduct.Name = "btnAddUpdateProduct";
            this.btnAddUpdateProduct.Size = new System.Drawing.Size(477, 68);
            this.btnAddUpdateProduct.TabIndex = 61;
            this.btnAddUpdateProduct.Tag = "Home";
            this.btnAddUpdateProduct.Text = "Add Product";
            this.btnAddUpdateProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(1411, 127);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 29);
            this.label11.TabIndex = 62;
            this.label11.Text = "$";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(1411, 230);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 29);
            this.label14.TabIndex = 63;
            this.label14.Text = "%";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(944, 944);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(178, 29);
            this.label15.TabIndex = 64;
            this.label15.Text = "Product Video";
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
            this.btnClose.Location = new System.Drawing.Point(1374, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.PressedState.Image = global::Online_Store_Project.Properties.Resources.close__3_;
            this.btnClose.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnClose.Size = new System.Drawing.Size(64, 58);
            this.btnClose.TabIndex = 191;
            this.btnClose.UseTransparentBackground = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddVideo
            // 
            this.btnAddVideo.BackColor = System.Drawing.Color.AliceBlue;
            this.btnAddVideo.BackgroundImage = global::Online_Store_Project.Properties.Resources.more_vertical;
            this.btnAddVideo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddVideo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddVideo.FlatAppearance.BorderSize = 0;
            this.btnAddVideo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddVideo.Location = new System.Drawing.Point(1369, 936);
            this.btnAddVideo.Name = "btnAddVideo";
            this.btnAddVideo.Size = new System.Drawing.Size(47, 46);
            this.btnAddVideo.TabIndex = 66;
            this.btnAddVideo.UseVisualStyleBackColor = false;
            this.btnAddVideo.Click += new System.EventHandler(this.btnAddVideo_Click);
            // 
            // txtBoxVideo
            // 
            this.txtBoxVideo.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtBoxVideo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxVideo.Enabled = false;
            this.txtBoxVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxVideo.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtBoxVideo.Location = new System.Drawing.Point(1155, 933);
            this.txtBoxVideo.Multiline = true;
            this.txtBoxVideo.Name = "txtBoxVideo";
            this.txtBoxVideo.Size = new System.Drawing.Size(263, 51);
            this.txtBoxVideo.TabIndex = 65;
            // 
            // roundButton1
            // 
            this.roundButton1.BackColor = System.Drawing.Color.AliceBlue;
            this.roundButton1.BackgroundImage = global::Online_Store_Project.Properties.Resources.more_vertical;
            this.roundButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.roundButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.roundButton1.FlatAppearance.BorderSize = 0;
            this.roundButton1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.roundButton1.Location = new System.Drawing.Point(1369, 589);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.Size = new System.Drawing.Size(47, 46);
            this.roundButton1.TabIndex = 45;
            this.roundButton1.UseVisualStyleBackColor = false;
            this.roundButton1.Click += new System.EventHandler(this.roundButton1_Click);
            // 
            // txtBoxProductImages
            // 
            this.txtBoxProductImages.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtBoxProductImages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxProductImages.Enabled = false;
            this.txtBoxProductImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxProductImages.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtBoxProductImages.Location = new System.Drawing.Point(1155, 586);
            this.txtBoxProductImages.Multiline = true;
            this.txtBoxProductImages.Name = "txtBoxProductImages";
            this.txtBoxProductImages.Size = new System.Drawing.Size(263, 51);
            this.txtBoxProductImages.TabIndex = 44;
            // 
            // btnChooseImage
            // 
            this.btnChooseImage.BackColor = System.Drawing.Color.AliceBlue;
            this.btnChooseImage.BackgroundImage = global::Online_Store_Project.Properties.Resources.more_vertical;
            this.btnChooseImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnChooseImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChooseImage.FlatAppearance.BorderSize = 0;
            this.btnChooseImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChooseImage.Location = new System.Drawing.Point(1373, 416);
            this.btnChooseImage.Name = "btnChooseImage";
            this.btnChooseImage.Size = new System.Drawing.Size(47, 46);
            this.btnChooseImage.TabIndex = 27;
            this.btnChooseImage.UseVisualStyleBackColor = false;
            this.btnChooseImage.Click += new System.EventHandler(this.btnChooseImage_Click);
            // 
            // txtboxProductImage
            // 
            this.txtboxProductImage.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtboxProductImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtboxProductImage.Enabled = false;
            this.txtboxProductImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxProductImage.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtboxProductImage.Location = new System.Drawing.Point(1154, 412);
            this.txtboxProductImage.Multiline = true;
            this.txtboxProductImage.Name = "txtboxProductImage";
            this.txtboxProductImage.Size = new System.Drawing.Size(267, 51);
            this.txtboxProductImage.TabIndex = 22;
            // 
            // txtLongDescription
            // 
            this.txtLongDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLongDescription.Location = new System.Drawing.Point(314, 595);
            this.txtLongDescription.Name = "txtLongDescription";
            this.txtLongDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtLongDescription.Size = new System.Drawing.Size(530, 175);
            this.txtLongDescription.TabIndex = 192;
            this.txtLongDescription.Text = "";
            // 
            // frmAddUpdateProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1450, 1116);
            this.Controls.Add(this.txtLongDescription);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddVideo);
            this.Controls.Add(this.txtBoxVideo);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnAddUpdateProduct);
            this.Controls.Add(this.cbSubCategory);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.txtProductSizes);
            this.Controls.Add(this.txtboxColors);
            this.Controls.Add(this.txtboxDescription);
            this.Controls.Add(this.txtQuantityInStock);
            this.Controls.Add(this.txtBoxDiscount);
            this.Controls.Add(this.txtProductprice);
            this.Controls.Add(this.txtboxProductName);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panelProductPics);
            this.Controls.Add(this.roundButton1);
            this.Controls.Add(this.txtBoxProductImages);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.picThumbnail);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnChooseImage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.txtboxProductImage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label14);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddUpdateProduct";
            this.Text = "Add / Update Product";
            this.Load += new System.EventHandler(this.frmAddUpdateProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThumbnail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private RoundButton btnChooseImage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox picThumbnail;
        private System.Windows.Forms.FlowLayoutPanel panelProductPics;
        private RoundButton roundButton1;
        private RoundTextBox txtBoxProductImages;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2TextBox txtboxProductName;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2TextBox txtProductprice;
        private Guna.UI2.WinForms.Guna2TextBox txtBoxDiscount;
        private Guna.UI2.WinForms.Guna2TextBox txtQuantityInStock;
        private Guna.UI2.WinForms.Guna2TextBox txtboxDescription;
        private RoundTextBox txtboxProductImage;
        private Guna.UI2.WinForms.Guna2TextBox txtboxColors;
        private Guna.UI2.WinForms.Guna2TextBox txtProductSizes;
        private Guna.UI2.WinForms.Guna2ComboBox cbCategory;
        private Guna.UI2.WinForms.Guna2ComboBox cbSubCategory;
        private Guna.UI2.WinForms.Guna2GradientButton btnAddUpdateProduct;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private RoundButton btnAddVideo;
        private RoundTextBox txtBoxVideo;
        private System.Windows.Forms.Label label15;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ImageButton btnClose;
        private System.Windows.Forms.RichTextBox txtLongDescription;
    }
}