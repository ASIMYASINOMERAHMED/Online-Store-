namespace Online_Store_Project
{
    partial class ctrCartItem
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
            this.lbQuantity = new System.Windows.Forms.Label();
            this.lbTotalPrice = new System.Windows.Forms.Label();
            this.lbSizeColor = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnIncrement = new System.Windows.Forms.Button();
            this.btnDecrement = new System.Windows.Forms.Button();
            this.picboxItem = new System.Windows.Forms.PictureBox();
            this.panelControls = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbUnitPrice = new System.Windows.Forms.Label();
            this.lbTotalPriceBeforediscount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picboxItem)).BeginInit();
            this.panelControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbQuantity
            // 
            this.lbQuantity.AutoSize = true;
            this.lbQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbQuantity.Location = new System.Drawing.Point(490, 121);
            this.lbQuantity.Name = "lbQuantity";
            this.lbQuantity.Size = new System.Drawing.Size(68, 29);
            this.lbQuantity.TabIndex = 20;
            this.lbQuantity.Text = "[???]";
            // 
            // lbTotalPrice
            // 
            this.lbTotalPrice.AutoSize = true;
            this.lbTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalPrice.Location = new System.Drawing.Point(342, 334);
            this.lbTotalPrice.Name = "lbTotalPrice";
            this.lbTotalPrice.Size = new System.Drawing.Size(161, 29);
            this.lbTotalPrice.TabIndex = 17;
            this.lbTotalPrice.Text = "Total price =";
            // 
            // lbSizeColor
            // 
            this.lbSizeColor.AutoSize = true;
            this.lbSizeColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSizeColor.Location = new System.Drawing.Point(342, 191);
            this.lbSizeColor.Name = "lbSizeColor";
            this.lbSizeColor.Size = new System.Drawing.Size(138, 29);
            this.lbSizeColor.TabIndex = 16;
            this.lbSizeColor.Text = "Size / Color";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(342, 121);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(130, 29);
            this.label.TabIndex = 15;
            this.label.Text = "Quantity =";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(342, 57);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(63, 29);
            this.lbName.TabIndex = 14;
            this.lbName.Text = "Item";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackgroundImage = global::Online_Store_Project.Properties.Resources.delete;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelete.Location = new System.Drawing.Point(16, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(59, 53);
            this.btnDelete.TabIndex = 24;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnIncrement
            // 
            this.btnIncrement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIncrement.BackgroundImage = global::Online_Store_Project.Properties.Resources.plus;
            this.btnIncrement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnIncrement.Location = new System.Drawing.Point(78, 0);
            this.btnIncrement.Name = "btnIncrement";
            this.btnIncrement.Size = new System.Drawing.Size(59, 53);
            this.btnIncrement.TabIndex = 23;
            this.btnIncrement.UseVisualStyleBackColor = true;
            this.btnIncrement.Click += new System.EventHandler(this.btnIncrement_Click);
            // 
            // btnDecrement
            // 
            this.btnDecrement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDecrement.BackgroundImage = global::Online_Store_Project.Properties.Resources.minus;
            this.btnDecrement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDecrement.Location = new System.Drawing.Point(140, 0);
            this.btnDecrement.Name = "btnDecrement";
            this.btnDecrement.Size = new System.Drawing.Size(59, 53);
            this.btnDecrement.TabIndex = 22;
            this.btnDecrement.UseVisualStyleBackColor = true;
            this.btnDecrement.Click += new System.EventHandler(this.btnDecrement_Click);
            // 
            // picboxItem
            // 
            this.picboxItem.Location = new System.Drawing.Point(19, 32);
            this.picboxItem.Name = "picboxItem";
            this.picboxItem.Size = new System.Drawing.Size(317, 331);
            this.picboxItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picboxItem.TabIndex = 21;
            this.picboxItem.TabStop = false;
            // 
            // panelControls
            // 
            this.panelControls.Controls.Add(this.btnDelete);
            this.panelControls.Controls.Add(this.btnIncrement);
            this.panelControls.Controls.Add(this.btnDecrement);
            this.panelControls.Location = new System.Drawing.Point(729, 3);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(200, 56);
            this.panelControls.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(342, 261);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 29);
            this.label1.TabIndex = 26;
            this.label1.Text = "Unit price =";
            // 
            // lbUnitPrice
            // 
            this.lbUnitPrice.AutoSize = true;
            this.lbUnitPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUnitPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbUnitPrice.Location = new System.Drawing.Point(490, 261);
            this.lbUnitPrice.Name = "lbUnitPrice";
            this.lbUnitPrice.Size = new System.Drawing.Size(68, 29);
            this.lbUnitPrice.TabIndex = 27;
            this.lbUnitPrice.Text = "[???]";
            // 
            // lbTotalPriceBeforediscount
            // 
            this.lbTotalPriceBeforediscount.AutoSize = true;
            this.lbTotalPriceBeforediscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalPriceBeforediscount.Location = new System.Drawing.Point(643, 261);
            this.lbTotalPriceBeforediscount.Name = "lbTotalPriceBeforediscount";
            this.lbTotalPriceBeforediscount.Size = new System.Drawing.Size(68, 29);
            this.lbTotalPriceBeforediscount.TabIndex = 28;
            this.lbTotalPriceBeforediscount.Text = "[???]";
            this.lbTotalPriceBeforediscount.Paint += new System.Windows.Forms.PaintEventHandler(this.lbTotalPriceBeforediscount_Paint);
            // 
            // ctrCartItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbTotalPriceBeforediscount);
            this.Controls.Add(this.lbUnitPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picboxItem);
            this.Controls.Add(this.lbQuantity);
            this.Controls.Add(this.lbTotalPrice);
            this.Controls.Add(this.lbSizeColor);
            this.Controls.Add(this.label);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.panelControls);
            this.Name = "ctrCartItem";
            this.Size = new System.Drawing.Size(932, 391);
            this.Load += new System.EventHandler(this.ctrCartItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picboxItem)).EndInit();
            this.panelControls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbQuantity;
        private System.Windows.Forms.Label lbTotalPrice;
        private System.Windows.Forms.Label lbSizeColor;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.PictureBox picboxItem;
        private System.Windows.Forms.Button btnDecrement;
        private System.Windows.Forms.Button btnIncrement;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbUnitPrice;
        private System.Windows.Forms.Label lbTotalPriceBeforediscount;
    }
}
