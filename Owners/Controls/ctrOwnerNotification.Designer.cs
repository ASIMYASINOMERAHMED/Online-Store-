namespace Online_Store_Project
{
    partial class ctrOwnerNotification
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
            this.picNotification = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lbDateTime = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lbNotificationText = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.guna2CustomGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNotification)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.BorderRadius = 20;
            this.guna2CustomGradientPanel1.Controls.Add(this.picNotification);
            this.guna2CustomGradientPanel1.Controls.Add(this.lbDateTime);
            this.guna2CustomGradientPanel1.Controls.Add(this.lbNotificationText);
            this.guna2CustomGradientPanel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2CustomGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.MidnightBlue;
            this.guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.LightSkyBlue;
            this.guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.Lime;
            this.guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.DeepSkyBlue;
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(994, 166);
            this.guna2CustomGradientPanel1.TabIndex = 10;
            this.guna2CustomGradientPanel1.DoubleClick += new System.EventHandler(this.guna2CustomGradientPanel1_DoubleClick);
            // 
            // picNotification
            // 
            this.picNotification.Image = global::Online_Store_Project.Properties.Resources.guest;
            this.picNotification.ImageRotate = 0F;
            this.picNotification.Location = new System.Drawing.Point(34, 21);
            this.picNotification.Name = "picNotification";
            this.picNotification.Size = new System.Drawing.Size(145, 120);
            this.picNotification.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picNotification.TabIndex = 6;
            this.picNotification.TabStop = false;
            this.picNotification.UseTransparentBackground = true;
            // 
            // lbDateTime
            // 
            this.lbDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDateTime.AutoSize = true;
            this.lbDateTime.BackColor = System.Drawing.Color.Transparent;
            this.lbDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDateTime.ForeColor = System.Drawing.Color.White;
            this.lbDateTime.Location = new System.Drawing.Point(751, 10);
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
            this.lbNotificationText.Size = new System.Drawing.Size(394, 33);
            this.lbNotificationText.TabIndex = 4;
            this.lbNotificationText.Text = "New Visitor To The System";
            // 
            // ctrOwnerNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Name = "ctrOwnerNotification";
            this.Size = new System.Drawing.Size(994, 166);
            this.Load += new System.EventHandler(this.ctrOwnerNotification_Load);
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNotification)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2PictureBox picNotification;
        private Bunifu.Framework.UI.BunifuCustomLabel lbDateTime;
        private Bunifu.Framework.UI.BunifuCustomLabel lbNotificationText;
    }
}
