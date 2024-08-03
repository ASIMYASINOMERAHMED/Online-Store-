namespace Online_Store_Project
{
    partial class frmOwnerNotifications
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOwnerNotifications));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.btnClose = new Guna.UI2.WinForms.Guna2ImageButton();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnNotifications = new Guna.UI2.WinForms.Guna2ImageButton();
            this.SuspendLayout();
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
            this.btnClose.HoverState.ImageSize = new System.Drawing.Size(60, 60);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnClose.ImageRotate = 0F;
            this.btnClose.ImageSize = new System.Drawing.Size(60, 60);
            this.btnClose.Location = new System.Drawing.Point(1133, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.PressedState.Image = global::Online_Store_Project.Properties.Resources.close__3_;
            this.btnClose.PressedState.ImageSize = new System.Drawing.Size(60, 60);
            this.btnClose.Size = new System.Drawing.Size(58, 55);
            this.btnClose.TabIndex = 191;
            this.btnClose.UseTransparentBackground = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Sitka Small", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.SlateGray;
            this.lbTitle.Location = new System.Drawing.Point(75, 3);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(282, 54);
            this.lbTitle.TabIndex = 194;
            this.lbTitle.Text = "Notifications";
            // 
            // btnNotifications
            // 
            this.btnNotifications.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNotifications.BackColor = System.Drawing.Color.Transparent;
            this.btnNotifications.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnNotifications.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNotifications.HoverState.Image = global::Online_Store_Project.Properties.Resources.bell__2_;
            this.btnNotifications.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnNotifications.Image = ((System.Drawing.Image)(resources.GetObject("btnNotifications.Image")));
            this.btnNotifications.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnNotifications.ImageRotate = 0F;
            this.btnNotifications.Location = new System.Drawing.Point(5, 2);
            this.btnNotifications.Name = "btnNotifications";
            this.btnNotifications.PressedState.Image = global::Online_Store_Project.Properties.Resources.bell;
            this.btnNotifications.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnNotifications.Size = new System.Drawing.Size(64, 54);
            this.btnNotifications.TabIndex = 196;
            this.btnNotifications.UseTransparentBackground = true;
            // 
            // frmOwnerNotifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1194, 732);
            this.Controls.Add(this.btnNotifications);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmOwnerNotifications";
            this.Text = "Owner Notifications";
            this.Load += new System.EventHandler(this.frmOwnerNotifications_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ImageButton btnClose;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Label lbTitle;
        private Guna.UI2.WinForms.Guna2ImageButton btnNotifications;
    }
}