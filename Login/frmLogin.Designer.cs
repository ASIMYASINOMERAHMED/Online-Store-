namespace Online_Store_Project
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.btnLogin1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.ckbRememberme = new System.Windows.Forms.CheckBox();
            this.ResetPassword = new System.Windows.Forms.LinkLabel();
            this.lbError = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FocusDot = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnClose = new Guna.UI2.WinForms.Guna2ImageButton();
            this.Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btneye = new System.Windows.Forms.Button();
            this.ProgressIndicator1 = new Guna.UI2.WinForms.Guna2WinProgressIndicator();
            this.txtBoxUserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSignUp = new Guna.UI2.WinForms.Guna2GradientButton();
            this.txtBoxPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2GradientPanel3 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.guna2GradientPanel2.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogin1
            // 
            this.btnLogin1.Animated = true;
            this.btnLogin1.AnimatedGIF = true;
            this.btnLogin1.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin1.BorderColor = System.Drawing.Color.DimGray;
            this.btnLogin1.BorderRadius = 20;
            this.btnLogin1.BorderThickness = 1;
            this.btnLogin1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogin1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogin1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogin1.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnLogin1.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnLogin1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin1.ForeColor = System.Drawing.Color.White;
            this.btnLogin1.Location = new System.Drawing.Point(202, 599);
            this.btnLogin1.Name = "btnLogin1";
            this.btnLogin1.Size = new System.Drawing.Size(550, 68);
            this.btnLogin1.TabIndex = 184;
            this.btnLogin1.Tag = "";
            this.btnLogin1.Text = "Login";
            this.btnLogin1.Click += new System.EventHandler(this.btnLogin1_Click);
            // 
            // ckbRememberme
            // 
            this.ckbRememberme.AutoSize = true;
            this.ckbRememberme.BackColor = System.Drawing.Color.Transparent;
            this.ckbRememberme.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ckbRememberme.Location = new System.Drawing.Point(220, 495);
            this.ckbRememberme.Name = "ckbRememberme";
            this.ckbRememberme.Size = new System.Drawing.Size(187, 31);
            this.ckbRememberme.TabIndex = 174;
            this.ckbRememberme.Text = "Remember me";
            this.ckbRememberme.UseVisualStyleBackColor = false;
            // 
            // ResetPassword
            // 
            this.ResetPassword.AutoSize = true;
            this.ResetPassword.BackColor = System.Drawing.Color.Transparent;
            this.ResetPassword.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ResetPassword.LinkColor = System.Drawing.Color.White;
            this.ResetPassword.Location = new System.Drawing.Point(196, 688);
            this.ResetPassword.Name = "ResetPassword";
            this.ResetPassword.Size = new System.Drawing.Size(226, 33);
            this.ResetPassword.TabIndex = 163;
            this.ResetPassword.TabStop = true;
            this.ResetPassword.Text = "Forget Password?";
            this.ResetPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ResetPassword_LinkClicked);
            // 
            // lbError
            // 
            this.lbError.AutoSize = true;
            this.lbError.BackColor = System.Drawing.Color.Transparent;
            this.lbError.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.lbError.ForeColor = System.Drawing.Color.Red;
            this.lbError.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbError.Location = new System.Drawing.Point(213, 542);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(328, 29);
            this.lbError.TabIndex = 165;
            this.lbError.Text = "invalid UserName/Password !";
            this.lbError.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(190, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(572, 66);
            this.label2.TabIndex = 164;
            this.label2.Text = "Login To Your Account";
            // 
            // FocusDot
            // 
            this.FocusDot.BackColor = System.Drawing.Color.White;
            this.FocusDot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FocusDot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FocusDot.FlatAppearance.BorderSize = 0;
            this.FocusDot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FocusDot.ForeColor = System.Drawing.Color.Transparent;
            this.FocusDot.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.FocusDot.Location = new System.Drawing.Point(711, 435);
            this.FocusDot.Name = "FocusDot";
            this.FocusDot.Size = new System.Drawing.Size(10, 10);
            this.FocusDot.TabIndex = 169;
            this.FocusDot.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(371, 853);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 33);
            this.label3.TabIndex = 144;
            this.label3.Text = "Version 1.0";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Georgia", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(86, 574);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(713, 232);
            this.label1.TabIndex = 143;
            this.label1.Text = "            WELCOME TO              Online Store";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BorderRadius = 20;
            this.guna2GradientPanel1.Controls.Add(this.pictureBox1);
            this.guna2GradientPanel1.Controls.Add(this.label3);
            this.guna2GradientPanel1.Controls.Add(this.label1);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.Chocolate;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(866, 971);
            this.guna2GradientPanel1.TabIndex = 164;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Online_Store_Project.Properties.Resources.country_store_clipart_3;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(862, 622);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 142;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // guna2GradientPanel2
            // 
            this.guna2GradientPanel2.BorderRadius = 20;
            this.guna2GradientPanel2.Controls.Add(this.btnClose);
            this.guna2GradientPanel2.Controls.Add(this.Panel1);
            this.guna2GradientPanel2.Controls.Add(this.ProgressIndicator1);
            this.guna2GradientPanel2.Controls.Add(this.txtBoxUserName);
            this.guna2GradientPanel2.Controls.Add(this.label4);
            this.guna2GradientPanel2.Controls.Add(this.btnSignUp);
            this.guna2GradientPanel2.Controls.Add(this.btnLogin1);
            this.guna2GradientPanel2.Controls.Add(this.label2);
            this.guna2GradientPanel2.Controls.Add(this.lbError);
            this.guna2GradientPanel2.Controls.Add(this.ResetPassword);
            this.guna2GradientPanel2.Controls.Add(this.ckbRememberme);
            this.guna2GradientPanel2.Controls.Add(this.FocusDot);
            this.guna2GradientPanel2.Controls.Add(this.txtBoxPassword);
            this.guna2GradientPanel2.Controls.Add(this.guna2GradientPanel3);
            this.guna2GradientPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2GradientPanel2.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.guna2GradientPanel2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.guna2GradientPanel2.Location = new System.Drawing.Point(872, 0);
            this.guna2GradientPanel2.Name = "guna2GradientPanel2";
            this.guna2GradientPanel2.Size = new System.Drawing.Size(826, 971);
            this.guna2GradientPanel2.TabIndex = 165;
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
            this.btnClose.Location = new System.Drawing.Point(750, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.PressedState.Image = global::Online_Store_Project.Properties.Resources.close__3_;
            this.btnClose.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnClose.Size = new System.Drawing.Size(64, 58);
            this.btnClose.TabIndex = 190;
            this.btnClose.UseTransparentBackground = true;
            this.btnClose.Click += new System.EventHandler(this.roundButton2_Click);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Controls.Add(this.btneye);
            this.Panel1.Location = new System.Drawing.Point(681, 407);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(59, 56);
            this.Panel1.TabIndex = 189;
            // 
            // btneye
            // 
            this.btneye.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btneye.BackgroundImage = global::Online_Store_Project.Properties.Resources.eyePassword_removebg_preview;
            this.btneye.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btneye.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btneye.FlatAppearance.BorderSize = 0;
            this.btneye.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btneye.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btneye.ForeColor = System.Drawing.Color.Transparent;
            this.btneye.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btneye.Location = new System.Drawing.Point(7, 6);
            this.btneye.Name = "btneye";
            this.btneye.Size = new System.Drawing.Size(46, 45);
            this.btneye.TabIndex = 172;
            this.btneye.UseVisualStyleBackColor = false;
            this.btneye.Visible = false;
            this.btneye.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button3_MouseDown);
            this.btneye.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button3_MouseUp);
            // 
            // ProgressIndicator1
            // 
            this.ProgressIndicator1.BackColor = System.Drawing.Color.Transparent;
            this.ProgressIndicator1.CircleSize = 3.5F;
            this.ProgressIndicator1.Location = new System.Drawing.Point(2, 436);
            this.ProgressIndicator1.Name = "ProgressIndicator1";
            this.ProgressIndicator1.ProgressColor = System.Drawing.SystemColors.HotTrack;
            this.ProgressIndicator1.Size = new System.Drawing.Size(90, 90);
            this.ProgressIndicator1.TabIndex = 188;
            this.ProgressIndicator1.UseTransparentBackground = true;
            this.ProgressIndicator1.Visible = false;
            // 
            // txtBoxUserName
            // 
            this.txtBoxUserName.BackColor = System.Drawing.Color.Transparent;
            this.txtBoxUserName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBoxUserName.BorderRadius = 20;
            this.txtBoxUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBoxUserName.DefaultText = "";
            this.txtBoxUserName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBoxUserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBoxUserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxUserName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxUserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxUserName.IconLeft = global::Online_Store_Project.Properties.Resources.user__3_;
            this.txtBoxUserName.IconLeftSize = new System.Drawing.Size(60, 60);
            this.txtBoxUserName.Location = new System.Drawing.Point(202, 304);
            this.txtBoxUserName.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.txtBoxUserName.Name = "txtBoxUserName";
            this.txtBoxUserName.PasswordChar = '\0';
            this.txtBoxUserName.PlaceholderText = "UserName";
            this.txtBoxUserName.SelectedText = "";
            this.txtBoxUserName.Size = new System.Drawing.Size(549, 63);
            this.txtBoxUserName.TabIndex = 186;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(351, 773);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(254, 33);
            this.label4.TabIndex = 145;
            this.label4.Text = "Don\'t have Account ?";
            // 
            // btnSignUp
            // 
            this.btnSignUp.Animated = true;
            this.btnSignUp.AnimatedGIF = true;
            this.btnSignUp.BackColor = System.Drawing.Color.Transparent;
            this.btnSignUp.BorderColor = System.Drawing.Color.DimGray;
            this.btnSignUp.BorderRadius = 20;
            this.btnSignUp.BorderThickness = 1;
            this.btnSignUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSignUp.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSignUp.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSignUp.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSignUp.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSignUp.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSignUp.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnSignUp.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnSignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignUp.ForeColor = System.Drawing.Color.White;
            this.btnSignUp.Location = new System.Drawing.Point(201, 818);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(550, 68);
            this.btnSignUp.TabIndex = 185;
            this.btnSignUp.Tag = "";
            this.btnSignUp.Text = "Sign up";
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtBoxPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBoxPassword.BorderRadius = 20;
            this.txtBoxPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBoxPassword.DefaultText = "";
            this.txtBoxPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBoxPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBoxPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxPassword.IconLeft = global::Online_Store_Project.Properties.Resources.password__1_;
            this.txtBoxPassword.IconLeftSize = new System.Drawing.Size(60, 60);
            this.txtBoxPassword.Location = new System.Drawing.Point(202, 403);
            this.txtBoxPassword.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.PasswordChar = '●';
            this.txtBoxPassword.PlaceholderText = "Password";
            this.txtBoxPassword.SelectedText = "";
            this.txtBoxPassword.Size = new System.Drawing.Size(549, 63);
            this.txtBoxPassword.TabIndex = 187;
            this.txtBoxPassword.UseSystemPasswordChar = true;
            this.txtBoxPassword.TextChanged += new System.EventHandler(this.txtBoxPassword_TextChanged);
            // 
            // guna2GradientPanel3
            // 
            this.guna2GradientPanel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel3.BorderRadius = 20;
            this.guna2GradientPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2GradientPanel3.FillColor = System.Drawing.Color.Chocolate;
            this.guna2GradientPanel3.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.guna2GradientPanel3.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel3.Name = "guna2GradientPanel3";
            this.guna2GradientPanel3.Size = new System.Drawing.Size(114, 971);
            this.guna2GradientPanel3.TabIndex = 166;
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
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1698, 971);
            this.Controls.Add(this.guna2GradientPanel2);
            this.Controls.Add(this.guna2GradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.Activated += new System.EventHandler(this.frmLogin_Activated);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.guna2GradientPanel2.ResumeLayout(false);
            this.guna2GradientPanel2.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox ckbRememberme;
        private System.Windows.Forms.Button btneye;
        private System.Windows.Forms.Button FocusDot;
        private System.Windows.Forms.LinkLabel ResetPassword;
        private System.Windows.Forms.Label lbError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2GradientButton btnLogin1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2GradientButton btnSignUp;
        private Guna.UI2.WinForms.Guna2TextBox txtBoxUserName;
        private Guna.UI2.WinForms.Guna2TextBox txtBoxPassword;
        private Guna.UI2.WinForms.Guna2WinProgressIndicator ProgressIndicator1;
        private Guna.UI2.WinForms.Guna2Panel Panel1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel3;
        private Guna.UI2.WinForms.Guna2ImageButton btnClose;
    }
}