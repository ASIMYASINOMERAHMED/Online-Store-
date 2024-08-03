namespace Online_Store_Project
{
    partial class frmPredictor
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
            this.lbTitle = new System.Windows.Forms.Label();
            this.txtMonth = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtYear = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.Close = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnPredict = new Guna.UI2.WinForms.Guna2GradientButton();
            this.lbPredictions = new System.Windows.Forms.Label();
            this.ProgressIndicator1 = new Guna.UI2.WinForms.Guna2WinProgressIndicator();
            this.btnTrain = new Guna.UI2.WinForms.Guna2GradientButton();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Sitka Small", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbTitle.Location = new System.Drawing.Point(232, 18);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(373, 63);
            this.lbTitle.TabIndex = 74;
            this.lbTitle.Text = "Sales Predictor";
            // 
            // txtMonth
            // 
            this.txtMonth.Animated = true;
            this.txtMonth.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMonth.BorderRadius = 10;
            this.txtMonth.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMonth.DefaultText = "";
            this.txtMonth.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMonth.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMonth.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMonth.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMonth.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMonth.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMonth.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMonth.Location = new System.Drawing.Point(229, 231);
            this.txtMonth.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.PasswordChar = '\0';
            this.txtMonth.PlaceholderText = "Enter Month";
            this.txtMonth.SelectedText = "";
            this.txtMonth.Size = new System.Drawing.Size(511, 61);
            this.txtMonth.TabIndex = 78;
            // 
            // txtYear
            // 
            this.txtYear.Animated = true;
            this.txtYear.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtYear.BorderRadius = 10;
            this.txtYear.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtYear.DefaultText = "";
            this.txtYear.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtYear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtYear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtYear.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtYear.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtYear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtYear.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtYear.Location = new System.Drawing.Point(229, 149);
            this.txtYear.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtYear.Name = "txtYear";
            this.txtYear.PasswordChar = '\0';
            this.txtYear.PlaceholderText = "Enter Year";
            this.txtYear.SelectedText = "";
            this.txtYear.Size = new System.Drawing.Size(511, 61);
            this.txtYear.TabIndex = 77;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SlateGray;
            this.label2.Location = new System.Drawing.Point(145, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 31);
            this.label2.TabIndex = 75;
            this.label2.Text = "Year";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SlateGray;
            this.label3.Location = new System.Drawing.Point(126, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 31);
            this.label3.TabIndex = 76;
            this.label3.Text = "Month";
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
            // Close
            // 
            this.Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Close.Animated = true;
            this.Close.AnimatedGIF = true;
            this.Close.BorderColor = System.Drawing.Color.DimGray;
            this.Close.BorderRadius = 20;
            this.Close.BorderThickness = 1;
            this.Close.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Close.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Close.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Close.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Close.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Close.FillColor = System.Drawing.Color.RoyalBlue;
            this.Close.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close.ForeColor = System.Drawing.Color.White;
            this.Close.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.Close.Location = new System.Drawing.Point(229, 407);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(511, 68);
            this.Close.TabIndex = 80;
            this.Close.Tag = "Dashboard";
            this.Close.Text = "Close";
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // btnPredict
            // 
            this.btnPredict.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPredict.Animated = true;
            this.btnPredict.AnimatedGIF = true;
            this.btnPredict.BorderColor = System.Drawing.Color.DimGray;
            this.btnPredict.BorderRadius = 20;
            this.btnPredict.BorderThickness = 1;
            this.btnPredict.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPredict.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPredict.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPredict.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPredict.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPredict.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnPredict.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnPredict.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPredict.ForeColor = System.Drawing.Color.White;
            this.btnPredict.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnPredict.Location = new System.Drawing.Point(496, 320);
            this.btnPredict.Name = "btnPredict";
            this.btnPredict.Size = new System.Drawing.Size(244, 68);
            this.btnPredict.TabIndex = 79;
            this.btnPredict.Tag = "Dashboard";
            this.btnPredict.Text = "Predict";
            this.btnPredict.Click += new System.EventHandler(this.btnPredict_Click);
            // 
            // lbPredictions
            // 
            this.lbPredictions.AutoSize = true;
            this.lbPredictions.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbPredictions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPredictions.ForeColor = System.Drawing.Color.SlateGray;
            this.lbPredictions.Location = new System.Drawing.Point(223, 503);
            this.lbPredictions.Name = "lbPredictions";
            this.lbPredictions.Size = new System.Drawing.Size(80, 31);
            this.lbPredictions.TabIndex = 81;
            this.lbPredictions.Text = "[???]";
            this.lbPredictions.Visible = false;
            // 
            // ProgressIndicator1
            // 
            this.ProgressIndicator1.BackColor = System.Drawing.Color.Transparent;
            this.ProgressIndicator1.CircleSize = 3.5F;
            this.ProgressIndicator1.Location = new System.Drawing.Point(355, 303);
            this.ProgressIndicator1.Name = "ProgressIndicator1";
            this.ProgressIndicator1.ProgressColor = System.Drawing.SystemColors.HotTrack;
            this.ProgressIndicator1.Size = new System.Drawing.Size(90, 90);
            this.ProgressIndicator1.TabIndex = 189;
            this.ProgressIndicator1.UseTransparentBackground = true;
            this.ProgressIndicator1.Visible = false;
            // 
            // btnTrain
            // 
            this.btnTrain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTrain.Animated = true;
            this.btnTrain.AnimatedGIF = true;
            this.btnTrain.BorderColor = System.Drawing.Color.DimGray;
            this.btnTrain.BorderRadius = 20;
            this.btnTrain.BorderThickness = 1;
            this.btnTrain.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTrain.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTrain.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTrain.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTrain.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTrain.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnTrain.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnTrain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrain.ForeColor = System.Drawing.Color.White;
            this.btnTrain.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnTrain.Location = new System.Drawing.Point(229, 320);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(244, 68);
            this.btnTrain.TabIndex = 190;
            this.btnTrain.Tag = "Dashboard";
            this.btnTrain.Text = "Train";
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // frmPredictor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 697);
            this.Controls.Add(this.ProgressIndicator1);
            this.Controls.Add(this.lbPredictions);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.btnPredict);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.txtMonth);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnTrain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPredictor";
            this.Text = "frmPredictor";
            this.Load += new System.EventHandler(this.frmPredictor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtMonth;
        private Guna.UI2.WinForms.Guna2TextBox txtYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Label lbPredictions;
        private Guna.UI2.WinForms.Guna2GradientButton Close;
        private Guna.UI2.WinForms.Guna2GradientButton btnPredict;
        private Guna.UI2.WinForms.Guna2WinProgressIndicator ProgressIndicator1;
        private Guna.UI2.WinForms.Guna2GradientButton btnTrain;
    }
}