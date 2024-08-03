namespace Online_Store_Project
{
    partial class ctrMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrMessage));
            this.lbName = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lbDateTime = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lbMessage = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btnReplayToCustomer = new Guna.UI2.WinForms.Guna2ImageButton();
            this.picCustomer = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.ToolTip1 = new Guna.UI2.WinForms.Guna2HtmlToolTip();
            ((System.ComponentModel.ISupportInitialize)(this.picCustomer)).BeginInit();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.BackColor = System.Drawing.Color.Transparent;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.Color.White;
            this.lbName.Location = new System.Drawing.Point(179, 36);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(84, 33);
            this.lbName.TabIndex = 4;
            this.lbName.Text = "[???]";
            // 
            // lbDateTime
            // 
            this.lbDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDateTime.AutoSize = true;
            this.lbDateTime.BackColor = System.Drawing.Color.Transparent;
            this.lbDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDateTime.ForeColor = System.Drawing.Color.White;
            this.lbDateTime.Location = new System.Drawing.Point(1085, 10);
            this.lbDateTime.Name = "lbDateTime";
            this.lbDateTime.Size = new System.Drawing.Size(60, 25);
            this.lbDateTime.TabIndex = 5;
            this.lbDateTime.Text = "[???]";
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.BackColor = System.Drawing.Color.Transparent;
            this.lbMessage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMessage.ForeColor = System.Drawing.Color.White;
            this.lbMessage.Location = new System.Drawing.Point(179, 92);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(84, 33);
            this.lbMessage.TabIndex = 6;
            this.lbMessage.Text = "[???]";
            // 
            // btnReplayToCustomer
            // 
            this.btnReplayToCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReplayToCustomer.BackColor = System.Drawing.Color.Transparent;
            this.btnReplayToCustomer.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnReplayToCustomer.HoverState.Image = global::Online_Store_Project.Properties.Resources.reply__2_;
            this.btnReplayToCustomer.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnReplayToCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnReplayToCustomer.Image")));
            this.btnReplayToCustomer.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnReplayToCustomer.ImageRotate = 0F;
            this.btnReplayToCustomer.Location = new System.Drawing.Point(1243, 81);
            this.btnReplayToCustomer.Name = "btnReplayToCustomer";
            this.btnReplayToCustomer.PressedState.Image = global::Online_Store_Project.Properties.Resources.reply__1_1;
            this.btnReplayToCustomer.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnReplayToCustomer.Size = new System.Drawing.Size(64, 54);
            this.btnReplayToCustomer.TabIndex = 7;
            this.btnReplayToCustomer.Click += new System.EventHandler(this.guna2ImageButton1_Click);
            // 
            // picCustomer
            // 
            this.picCustomer.BackColor = System.Drawing.Color.Transparent;
            this.picCustomer.Image = global::Online_Store_Project.Properties.Resources.PersonEmptyPhoto;
            this.picCustomer.ImageRotate = 0F;
            this.picCustomer.Location = new System.Drawing.Point(29, 24);
            this.picCustomer.Name = "picCustomer";
            this.picCustomer.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picCustomer.Size = new System.Drawing.Size(110, 111);
            this.picCustomer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCustomer.TabIndex = 0;
            this.picCustomer.TabStop = false;
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.BorderRadius = 20;
            this.guna2CustomGradientPanel1.Controls.Add(this.btnReplayToCustomer);
            this.guna2CustomGradientPanel1.Controls.Add(this.lbDateTime);
            this.guna2CustomGradientPanel1.Controls.Add(this.picCustomer);
            this.guna2CustomGradientPanel1.Controls.Add(this.lbName);
            this.guna2CustomGradientPanel1.Controls.Add(this.lbMessage);
            this.guna2CustomGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.MidnightBlue;
            this.guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.LightSkyBlue;
            this.guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.Lime;
            this.guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.DeepSkyBlue;
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(1328, 150);
            this.guna2CustomGradientPanel1.TabIndex = 8;
            // 
            // ToolTip1
            // 
            this.ToolTip1.AllowLinksHandling = true;
            this.ToolTip1.BackColor = System.Drawing.Color.DarkGray;
            this.ToolTip1.IsBalloon = true;
            this.ToolTip1.MaximumSize = new System.Drawing.Size(0, 0);
            this.ToolTip1.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // ctrMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Name = "ctrMessage";
            this.Size = new System.Drawing.Size(1328, 150);
            this.Load += new System.EventHandler(this.ctrMessage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCustomer)).EndInit();
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox picCustomer;
        private Bunifu.Framework.UI.BunifuCustomLabel lbName;
        private Bunifu.Framework.UI.BunifuCustomLabel lbDateTime;
        private Bunifu.Framework.UI.BunifuCustomLabel lbMessage;
        private Guna.UI2.WinForms.Guna2ImageButton btnReplayToCustomer;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2HtmlToolTip ToolTip1;
    }
}
