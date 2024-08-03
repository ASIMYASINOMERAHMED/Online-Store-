namespace Online_Store_Project
{
    partial class ctrProductVideo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrProductVideo));
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2HtmlToolTip1 = new Guna.UI2.WinForms.Guna2HtmlToolTip();
            this.btnPlayVideo = new Guna.UI2.WinForms.Guna2ImageButton();
            this.picBoxItem = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxItem)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2GradientPanel1.BorderRadius = 20;
            this.guna2GradientPanel1.Controls.Add(this.btnPlayVideo);
            this.guna2GradientPanel1.Controls.Add(this.picBoxItem);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.Magenta;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(290, 208);
            this.guna2GradientPanel1.TabIndex = 0;
            // 
            // guna2HtmlToolTip1
            // 
            this.guna2HtmlToolTip1.AllowLinksHandling = true;
            this.guna2HtmlToolTip1.IsBalloon = true;
            this.guna2HtmlToolTip1.MaximumSize = new System.Drawing.Size(0, 0);
            // 
            // btnPlayVideo
            // 
            this.btnPlayVideo.BackColor = System.Drawing.Color.Transparent;
            this.btnPlayVideo.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnPlayVideo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlayVideo.HoverState.ImageRotate = 90F;
            this.btnPlayVideo.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnPlayVideo.Image = ((System.Drawing.Image)(resources.GetObject("btnPlayVideo.Image")));
            this.btnPlayVideo.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnPlayVideo.ImageRotate = 90F;
            this.btnPlayVideo.Location = new System.Drawing.Point(114, 79);
            this.btnPlayVideo.Name = "btnPlayVideo";
            this.btnPlayVideo.PressedState.ImageRotate = 90F;
            this.btnPlayVideo.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnPlayVideo.Size = new System.Drawing.Size(64, 54);
            this.btnPlayVideo.TabIndex = 1;
            this.guna2HtmlToolTip1.SetToolTip(this.btnPlayVideo, "Play");
            this.btnPlayVideo.UseTransparentBackground = true;
            this.btnPlayVideo.Click += new System.EventHandler(this.btnPlayVideo_Click);
            // 
            // picBoxItem
            // 
            this.picBoxItem.BackColor = System.Drawing.Color.Transparent;
            this.picBoxItem.BorderRadius = 20;
            this.picBoxItem.FillColor = System.Drawing.Color.Transparent;
            this.picBoxItem.ImageRotate = 0F;
            this.picBoxItem.Location = new System.Drawing.Point(23, 17);
            this.picBoxItem.Name = "picBoxItem";
            this.picBoxItem.Size = new System.Drawing.Size(246, 176);
            this.picBoxItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxItem.TabIndex = 3;
            this.picBoxItem.TabStop = false;
            this.picBoxItem.UseTransparentBackground = true;
            // 
            // ctrProductVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2GradientPanel1);
            this.Name = "ctrProductVideo";
            this.Size = new System.Drawing.Size(290, 208);
            this.guna2GradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2ImageButton btnPlayVideo;
        private Guna.UI2.WinForms.Guna2HtmlToolTip guna2HtmlToolTip1;
        private Guna.UI2.WinForms.Guna2PictureBox picBoxItem;
    }
}
