namespace Online_Store_Project
{
    partial class ctrCustomerNotification
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
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.lbDateTime = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lbNotificationText = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.picNotification = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2CustomGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNotification)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.BorderRadius = 20;
            this.guna2CustomGradientPanel1.Controls.Add(this.lbDateTime);
            this.guna2CustomGradientPanel1.Controls.Add(this.picNotification);
            this.guna2CustomGradientPanel1.Controls.Add(this.lbNotificationText);
            this.guna2CustomGradientPanel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2CustomGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.MidnightBlue;
            this.guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.LightSkyBlue;
            this.guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.Lime;
            this.guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.DeepSkyBlue;
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(1062, 150);
            this.guna2CustomGradientPanel1.TabIndex = 9;
            this.guna2CustomGradientPanel1.DoubleClick += new System.EventHandler(this.guna2CustomGradientPanel1_DoubleClick);
            // 
            // lbDateTime
            // 
            this.lbDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDateTime.AutoSize = true;
            this.lbDateTime.BackColor = System.Drawing.Color.Transparent;
            this.lbDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDateTime.ForeColor = System.Drawing.Color.White;
            this.lbDateTime.Location = new System.Drawing.Point(819, 10);
            this.lbDateTime.Name = "lbDateTime";
            this.lbDateTime.Size = new System.Drawing.Size(60, 25);
            this.lbDateTime.TabIndex = 5;
            this.lbDateTime.Text = "[???]";
            // 
            // lbNotificationText
            // 
            this.lbNotificationText.AutoSize = true;
            this.lbNotificationText.BackColor = System.Drawing.Color.Transparent;
            this.lbNotificationText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotificationText.ForeColor = System.Drawing.Color.White;
            this.lbNotificationText.Location = new System.Drawing.Point(312, 54);
            this.lbNotificationText.Name = "lbNotificationText";
            this.lbNotificationText.Size = new System.Drawing.Size(292, 33);
            this.lbNotificationText.TabIndex = 4;
            this.lbNotificationText.Text = "New Product Arrival";
            // 
            // picNotification
            // 
            this.picNotification.BackColor = System.Drawing.Color.Transparent;
            this.picNotification.Image = global::Online_Store_Project.Properties.Resources.boxes;
            this.picNotification.ImageRotate = 0F;
            this.picNotification.Location = new System.Drawing.Point(29, 24);
            this.picNotification.Name = "picNotification";
            this.picNotification.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picNotification.Size = new System.Drawing.Size(110, 111);
            this.picNotification.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNotification.TabIndex = 0;
            this.picNotification.TabStop = false;
            // 
            // ctrCustomerNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Name = "ctrCustomerNotification";
            this.Size = new System.Drawing.Size(1062, 150);
            this.Load += new System.EventHandler(this.ctrNotification_Load);
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNotification)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Bunifu.Framework.UI.BunifuCustomLabel lbDateTime;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picNotification;
        private Bunifu.Framework.UI.BunifuCustomLabel lbNotificationText;
    }
}
