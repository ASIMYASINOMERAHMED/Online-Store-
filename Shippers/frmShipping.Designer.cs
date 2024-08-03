namespace Online_Store_Project
{
    partial class frmShipping
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShipping));
            this.btnLogout = new Guna.UI2.WinForms.Guna2GradientButton();
            this.sidePanel = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.btnSideMenu = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.btnDeliverdOrders = new Guna.UI2.WinForms.Guna2GradientButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPages = new Guna.UI2.WinForms.Guna2TabControl();
            this.ShippingOrders = new System.Windows.Forms.TabPage();
            this.lbNoShippingOrders = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.DeliveredOrders = new System.Windows.Forms.TabPage();
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lbShippingOrdersNumber = new Guna.UI2.WinForms.Guna2NotificationPaint(this.components);
            this.lbDeliveredOrdersNum = new Guna.UI2.WinForms.Guna2NotificationPaint(this.components);
            this.DeliveredOrdersPanel = new Online_Store_Project.DoubleBufferedFlowLayoutPanel();
            this.ShippingContainer = new Online_Store_Project.DoubleBufferedFlowLayoutPanel();
            this.sidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tbPages.SuspendLayout();
            this.ShippingOrders.SuspendLayout();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.DeliveredOrders.SuspendLayout();
            this.guna2GradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Animated = true;
            this.btnLogout.AnimatedGIF = true;
            this.btnLogout.BorderRadius = 20;
            this.btnLogout.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogout.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogout.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(9, 913);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(491, 68);
            this.btnLogout.TabIndex = 22;
            this.btnLogout.Tag = "";
            this.btnLogout.Text = "Log out";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.Transparent;
            this.sidePanel.BorderRadius = 10;
            this.sidePanel.Controls.Add(this.btnLogout);
            this.sidePanel.Controls.Add(this.btnSideMenu);
            this.sidePanel.Controls.Add(this.guna2Separator1);
            this.sidePanel.Controls.Add(this.btnDeliverdOrders);
            this.sidePanel.Controls.Add(this.pictureBox1);
            this.sidePanel.Controls.Add(this.label1);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.FillColor = System.Drawing.Color.MediumBlue;
            this.sidePanel.FillColor2 = System.Drawing.Color.DarkBlue;
            this.sidePanel.FillColor3 = System.Drawing.Color.RoyalBlue;
            this.sidePanel.FillColor4 = System.Drawing.Color.Indigo;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(515, 993);
            this.sidePanel.TabIndex = 30;
            // 
            // btnSideMenu
            // 
            this.btnSideMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSideMenu.Animated = true;
            this.btnSideMenu.AnimatedGIF = true;
            this.btnSideMenu.BorderRadius = 20;
            this.btnSideMenu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSideMenu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSideMenu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSideMenu.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSideMenu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSideMenu.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnSideMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSideMenu.ForeColor = System.Drawing.Color.White;
            this.btnSideMenu.Location = new System.Drawing.Point(12, 273);
            this.btnSideMenu.Name = "btnSideMenu";
            this.btnSideMenu.Size = new System.Drawing.Size(491, 68);
            this.btnSideMenu.TabIndex = 11;
            this.btnSideMenu.Tag = "ShippingOrders";
            this.btnSideMenu.Text = "Shipping Orders";
            this.btnSideMenu.Click += new System.EventHandler(this.btnSideMenu_Click);
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Location = new System.Drawing.Point(35, 118);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(465, 10);
            this.guna2Separator1.TabIndex = 16;
            // 
            // btnDeliverdOrders
            // 
            this.btnDeliverdOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeliverdOrders.Animated = true;
            this.btnDeliverdOrders.AnimatedGIF = true;
            this.btnDeliverdOrders.BorderRadius = 20;
            this.btnDeliverdOrders.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDeliverdOrders.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDeliverdOrders.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDeliverdOrders.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDeliverdOrders.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDeliverdOrders.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnDeliverdOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeliverdOrders.ForeColor = System.Drawing.Color.White;
            this.btnDeliverdOrders.Location = new System.Drawing.Point(9, 379);
            this.btnDeliverdOrders.Name = "btnDeliverdOrders";
            this.btnDeliverdOrders.Size = new System.Drawing.Size(491, 68);
            this.btnDeliverdOrders.TabIndex = 20;
            this.btnDeliverdOrders.Tag = "DeliveredOrders";
            this.btnDeliverdOrders.Text = "Delivered Orders";
            this.btnDeliverdOrders.Click += new System.EventHandler(this.btnSideMenu_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Online_Store_Project.Properties.Resources._5231871_middle_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(31, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(108, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "General Shop";
            // 
            // tbPages
            // 
            this.tbPages.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tbPages.Controls.Add(this.ShippingOrders);
            this.tbPages.Controls.Add(this.DeliveredOrders);
            this.tbPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPages.ImageList = this.imageList1;
            this.tbPages.ItemSize = new System.Drawing.Size(300, 40);
            this.tbPages.Location = new System.Drawing.Point(515, 0);
            this.tbPages.Name = "tbPages";
            this.tbPages.SelectedIndex = 0;
            this.tbPages.Size = new System.Drawing.Size(1416, 993);
            this.tbPages.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tbPages.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tbPages.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tbPages.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tbPages.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tbPages.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tbPages.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tbPages.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tbPages.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.tbPages.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tbPages.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tbPages.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.tbPages.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tbPages.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tbPages.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.tbPages.TabButtonSize = new System.Drawing.Size(300, 40);
            this.tbPages.TabIndex = 31;
            this.tbPages.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tbPages.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalBottom;
            // 
            // ShippingOrders
            // 
            this.ShippingOrders.Controls.Add(this.ShippingContainer);
            this.ShippingOrders.Controls.Add(this.lbNoShippingOrders);
            this.ShippingOrders.Controls.Add(this.guna2GradientPanel1);
            this.ShippingOrders.ImageIndex = 0;
            this.ShippingOrders.Location = new System.Drawing.Point(4, 4);
            this.ShippingOrders.Name = "ShippingOrders";
            this.ShippingOrders.Padding = new System.Windows.Forms.Padding(3);
            this.ShippingOrders.Size = new System.Drawing.Size(1408, 945);
            this.ShippingOrders.TabIndex = 0;
            this.ShippingOrders.Text = "Shipping Orders";
            this.ShippingOrders.UseVisualStyleBackColor = true;
            // 
            // lbNoShippingOrders
            // 
            this.lbNoShippingOrders.BackColor = System.Drawing.Color.Transparent;
            this.lbNoShippingOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoShippingOrders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbNoShippingOrders.Location = new System.Drawing.Point(751, 359);
            this.lbNoShippingOrders.Name = "lbNoShippingOrders";
            this.lbNoShippingOrders.Size = new System.Drawing.Size(436, 53);
            this.lbNoShippingOrders.TabIndex = 0;
            this.lbNoShippingOrders.Text = "--No Shipping Orders--";
            this.lbNoShippingOrders.Visible = false;
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BorderRadius = 10;
            this.guna2GradientPanel1.Controls.Add(this.pictureBox4);
            this.guna2GradientPanel1.Controls.Add(this.guna2HtmlLabel2);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.MidnightBlue;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(3, 3);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(1402, 111);
            this.guna2GradientPanel1.TabIndex = 1;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::Online_Store_Project.Properties.Resources.truck_down;
            this.pictureBox4.Location = new System.Drawing.Point(3, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(183, 108);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 25;
            this.pictureBox4.TabStop = false;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(201, 27);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(329, 53);
            this.guna2HtmlLabel2.TabIndex = 0;
            this.guna2HtmlLabel2.Text = "Shipping Orders";
            // 
            // DeliveredOrders
            // 
            this.DeliveredOrders.Controls.Add(this.DeliveredOrdersPanel);
            this.DeliveredOrders.Controls.Add(this.guna2GradientPanel2);
            this.DeliveredOrders.ImageIndex = 1;
            this.DeliveredOrders.Location = new System.Drawing.Point(4, 4);
            this.DeliveredOrders.Name = "DeliveredOrders";
            this.DeliveredOrders.Padding = new System.Windows.Forms.Padding(3);
            this.DeliveredOrders.Size = new System.Drawing.Size(1408, 945);
            this.DeliveredOrders.TabIndex = 1;
            this.DeliveredOrders.Text = "Delivered Orders";
            this.DeliveredOrders.UseVisualStyleBackColor = true;
            // 
            // guna2GradientPanel2
            // 
            this.guna2GradientPanel2.BorderRadius = 10;
            this.guna2GradientPanel2.Controls.Add(this.pictureBox2);
            this.guna2GradientPanel2.Controls.Add(this.guna2HtmlLabel1);
            this.guna2GradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GradientPanel2.FillColor = System.Drawing.Color.MidnightBlue;
            this.guna2GradientPanel2.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.guna2GradientPanel2.Location = new System.Drawing.Point(3, 3);
            this.guna2GradientPanel2.Name = "guna2GradientPanel2";
            this.guna2GradientPanel2.Size = new System.Drawing.Size(1402, 111);
            this.guna2GradientPanel2.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Online_Store_Project.Properties.Resources.approved_delivery;
            this.pictureBox2.Location = new System.Drawing.Point(3, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(183, 108);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 25;
            this.pictureBox2.TabStop = false;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(201, 27);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(344, 53);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "Delivered Orders";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "truck_down.png");
            this.imageList1.Images.SetKeyName(1, "approved_delivery.png");
            // 
            // lbShippingOrdersNumber
            // 
            this.lbShippingOrdersNumber.Alignment = Guna.UI2.WinForms.Enums.CustomContentAlignment.MiddleRight;
            this.lbShippingOrdersNumber.BorderRadius = 10;
            this.lbShippingOrdersNumber.FillColor = System.Drawing.Color.Red;
            this.lbShippingOrdersNumber.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.lbShippingOrdersNumber.Location = new System.Drawing.Point(463, 20);
            this.lbShippingOrdersNumber.Size = new System.Drawing.Size(28, 28);
            this.lbShippingOrdersNumber.TargetControl = this.btnSideMenu;
            this.lbShippingOrdersNumber.Text = "";
            // 
            // lbDeliveredOrdersNum
            // 
            this.lbDeliveredOrdersNum.Alignment = Guna.UI2.WinForms.Enums.CustomContentAlignment.MiddleRight;
            this.lbDeliveredOrdersNum.BorderRadius = 10;
            this.lbDeliveredOrdersNum.FillColor = System.Drawing.Color.Red;
            this.lbDeliveredOrdersNum.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.lbDeliveredOrdersNum.Location = new System.Drawing.Point(463, 20);
            this.lbDeliveredOrdersNum.Size = new System.Drawing.Size(28, 28);
            this.lbDeliveredOrdersNum.TargetControl = this.btnDeliverdOrders;
            this.lbDeliveredOrdersNum.Text = "";
            // 
            // DeliveredOrdersPanel
            // 
            this.DeliveredOrdersPanel.AutoScroll = true;
            this.DeliveredOrdersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeliveredOrdersPanel.Location = new System.Drawing.Point(3, 114);
            this.DeliveredOrdersPanel.Name = "DeliveredOrdersPanel";
            this.DeliveredOrdersPanel.Size = new System.Drawing.Size(1402, 828);
            this.DeliveredOrdersPanel.TabIndex = 3;
            // 
            // ShippingContainer
            // 
            this.ShippingContainer.AutoScroll = true;
            this.ShippingContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShippingContainer.Location = new System.Drawing.Point(3, 114);
            this.ShippingContainer.Name = "ShippingContainer";
            this.ShippingContainer.Size = new System.Drawing.Size(1402, 828);
            this.ShippingContainer.TabIndex = 2;
            // 
            // frmShipping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1931, 993);
            this.Controls.Add(this.tbPages);
            this.Controls.Add(this.sidePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmShipping";
            this.Text = "Shipping";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmShipping_FormClosing);
            this.Load += new System.EventHandler(this.frmShipping_Load);
            this.sidePanel.ResumeLayout(false);
            this.sidePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tbPages.ResumeLayout(false);
            this.ShippingOrders.ResumeLayout(false);
            this.ShippingOrders.PerformLayout();
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.DeliveredOrders.ResumeLayout(false);
            this.guna2GradientPanel2.ResumeLayout(false);
            this.guna2GradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientButton btnLogout;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel sidePanel;
        private Guna.UI2.WinForms.Guna2GradientButton btnSideMenu;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2GradientButton btnDeliverdOrders;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TabControl tbPages;
        private System.Windows.Forms.TabPage ShippingOrders;
        private System.Windows.Forms.TabPage DeliveredOrders;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbNoShippingOrders;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Windows.Forms.ImageList imageList1;
        private Guna.UI2.WinForms.Guna2NotificationPaint lbShippingOrdersNumber;
        private Guna.UI2.WinForms.Guna2NotificationPaint lbDeliveredOrdersNum;
        private DoubleBufferedFlowLayoutPanel ShippingContainer;
        private DoubleBufferedFlowLayoutPanel DeliveredOrdersPanel;
    }
}