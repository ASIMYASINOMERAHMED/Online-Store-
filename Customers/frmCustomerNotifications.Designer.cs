namespace Online_Store_Project
{
    partial class frmCustomerNotifications
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerNotifications));
            this.btnClose = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.btnNotifications = new Guna.UI2.WinForms.Guna2ImageButton();
            this.lbTitle = new System.Windows.Forms.Label();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2GradientPanel1.SuspendLayout();
            this.SuspendLayout();
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
            this.btnClose.Location = new System.Drawing.Point(1106, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.PressedState.Image = global::Online_Store_Project.Properties.Resources.close__3_;
            this.btnClose.PressedState.ImageSize = new System.Drawing.Size(60, 60);
            this.btnClose.Size = new System.Drawing.Size(55, 54);
            this.btnClose.TabIndex = 191;
            this.btnClose.UseTransparentBackground = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.btnNotifications.Location = new System.Drawing.Point(0, 8);
            this.btnNotifications.Name = "btnNotifications";
            this.btnNotifications.PressedState.Image = global::Online_Store_Project.Properties.Resources.bell;
            this.btnNotifications.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnNotifications.Size = new System.Drawing.Size(64, 54);
            this.btnNotifications.TabIndex = 198;
            this.btnNotifications.UseTransparentBackground = true;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Font = new System.Drawing.Font("Sitka Small", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(70, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(282, 54);
            this.lbTitle.TabIndex = 197;
            this.lbTitle.Text = "Notifications";
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BorderRadius = 20;
            this.guna2GradientPanel1.Controls.Add(this.btnNotifications);
            this.guna2GradientPanel1.Controls.Add(this.lbTitle);
            this.guna2GradientPanel1.Controls.Add(this.btnClose);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.MidnightBlue;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(1168, 75);
            this.guna2GradientPanel1.TabIndex = 199;
            // 
            // frmCustomerNotifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1168, 703);
            this.Controls.Add(this.guna2GradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCustomerNotifications";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notifications";
            this.Load += new System.EventHandler(this.frmNotifications_Load);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ImageButton btnClose;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ImageButton btnNotifications;
        private System.Windows.Forms.Label lbTitle;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
    }
}