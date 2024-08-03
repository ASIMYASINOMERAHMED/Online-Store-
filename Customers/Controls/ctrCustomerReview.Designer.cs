namespace Online_Store_Project
{
    partial class ctrCustomerReview
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
            this.picCustomer = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lbReviewDate = new System.Windows.Forms.Label();
            this.lbReviewText = new System.Windows.Forms.Label();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.ToolTip1 = new Guna.UI2.WinForms.Guna2HtmlToolTip();
            this.RatingStar1 = new Guna.UI2.WinForms.Guna2RatingStar();
            this.lbName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCustomer)).BeginInit();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picCustomer
            // 
            this.picCustomer.BackColor = System.Drawing.Color.Transparent;
            this.picCustomer.Image = global::Online_Store_Project.Properties.Resources.PersonEmptyPhoto;
            this.picCustomer.ImageRotate = 0F;
            this.picCustomer.Location = new System.Drawing.Point(28, 14);
            this.picCustomer.Name = "picCustomer";
            this.picCustomer.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picCustomer.Size = new System.Drawing.Size(94, 87);
            this.picCustomer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCustomer.TabIndex = 0;
            this.picCustomer.TabStop = false;
            // 
            // lbReviewDate
            // 
            this.lbReviewDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbReviewDate.AutoSize = true;
            this.lbReviewDate.BackColor = System.Drawing.Color.Transparent;
            this.lbReviewDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReviewDate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbReviewDate.Location = new System.Drawing.Point(317, 14);
            this.lbReviewDate.Name = "lbReviewDate";
            this.lbReviewDate.Size = new System.Drawing.Size(60, 25);
            this.lbReviewDate.TabIndex = 1;
            this.lbReviewDate.Text = "[???]";
            // 
            // lbReviewText
            // 
            this.lbReviewText.AutoSize = true;
            this.lbReviewText.BackColor = System.Drawing.Color.Transparent;
            this.lbReviewText.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReviewText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbReviewText.Location = new System.Drawing.Point(141, 58);
            this.lbReviewText.Name = "lbReviewText";
            this.lbReviewText.Size = new System.Drawing.Size(60, 25);
            this.lbReviewText.TabIndex = 2;
            this.lbReviewText.Text = "[???]";
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.BorderRadius = 20;
            this.guna2CustomGradientPanel1.BorderThickness = 20;
            this.guna2CustomGradientPanel1.Controls.Add(this.lbName);
            this.guna2CustomGradientPanel1.Controls.Add(this.RatingStar1);
            this.guna2CustomGradientPanel1.Controls.Add(this.lbReviewText);
            this.guna2CustomGradientPanel1.Controls.Add(this.lbReviewDate);
            this.guna2CustomGradientPanel1.Controls.Add(this.picCustomer);
            this.guna2CustomGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.MidnightBlue;
            this.guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.LightSkyBlue;
            this.guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.Lime;
            this.guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.DeepSkyBlue;
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(578, 131);
            this.guna2CustomGradientPanel1.TabIndex = 3;
            // 
            // ToolTip1
            // 
            this.ToolTip1.AllowLinksHandling = true;
            this.ToolTip1.BackColor = System.Drawing.Color.Gray;
            this.ToolTip1.IsBalloon = true;
            this.ToolTip1.MaximumSize = new System.Drawing.Size(0, 0);
            // 
            // RatingStar1
            // 
            this.RatingStar1.BackColor = System.Drawing.Color.Transparent;
            this.RatingStar1.Location = new System.Drawing.Point(400, 93);
            this.RatingStar1.Name = "RatingStar1";
            this.RatingStar1.RatingColor = System.Drawing.Color.Gold;
            this.RatingStar1.Size = new System.Drawing.Size(156, 35);
            this.RatingStar1.TabIndex = 3;
            // 
            // lbName
            // 
            this.lbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbName.AutoSize = true;
            this.lbName.BackColor = System.Drawing.Color.Transparent;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbName.Location = new System.Drawing.Point(141, 14);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(60, 25);
            this.lbName.TabIndex = 4;
            this.lbName.Text = "[???]";
            // 
            // ctrCustomerReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Name = "ctrCustomerReview";
            this.Size = new System.Drawing.Size(578, 131);
            this.Load += new System.EventHandler(this.ctrCustomerReview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCustomer)).EndInit();
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox picCustomer;
        private System.Windows.Forms.Label lbReviewDate;
        private System.Windows.Forms.Label lbReviewText;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2HtmlToolTip ToolTip1;
        private Guna.UI2.WinForms.Guna2RatingStar RatingStar1;
        private System.Windows.Forms.Label lbName;
    }
}
