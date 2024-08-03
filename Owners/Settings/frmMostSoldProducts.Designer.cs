namespace Online_Store_Project
{
    partial class frmMostSoldProducts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMostSoldProducts));
            this.btnClose = new Guna.UI2.WinForms.Guna2GradientButton();
            this.dgvMostSoldProducts = new System.Windows.Forms.DataGridView();
            this.lbTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DTPFrom = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.DTPTo = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnSearch = new Guna.UI2.WinForms.Guna2ImageButton();
            this.lbNotFound = new System.Windows.Forms.Label();
            this.lbRecords = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.labelRecords = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostSoldProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Animated = true;
            this.btnClose.AnimatedGIF = true;
            this.btnClose.BorderRadius = 20;
            this.btnClose.BorderThickness = 1;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(956, 552);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(187, 60);
            this.btnClose.TabIndex = 174;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvMostSoldProducts
            // 
            this.dgvMostSoldProducts.AllowUserToAddRows = false;
            this.dgvMostSoldProducts.AllowUserToDeleteRows = false;
            this.dgvMostSoldProducts.AllowUserToOrderColumns = true;
            this.dgvMostSoldProducts.AllowUserToResizeColumns = false;
            this.dgvMostSoldProducts.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(184)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvMostSoldProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMostSoldProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMostSoldProducts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMostSoldProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvMostSoldProducts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMostSoldProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvMostSoldProducts.ColumnHeadersHeight = 75;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(184)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMostSoldProducts.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvMostSoldProducts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvMostSoldProducts.EnableHeadersVisualStyles = false;
            this.dgvMostSoldProducts.Location = new System.Drawing.Point(13, 234);
            this.dgvMostSoldProducts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvMostSoldProducts.MultiSelect = false;
            this.dgvMostSoldProducts.Name = "dgvMostSoldProducts";
            this.dgvMostSoldProducts.ReadOnly = true;
            this.dgvMostSoldProducts.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMostSoldProducts.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvMostSoldProducts.RowHeadersVisible = false;
            this.dgvMostSoldProducts.RowHeadersWidth = 82;
            this.dgvMostSoldProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMostSoldProducts.Size = new System.Drawing.Size(1130, 310);
            this.dgvMostSoldProducts.TabIndex = 173;
            this.dgvMostSoldProducts.TabStop = false;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Sitka Small", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbTitle.Location = new System.Drawing.Point(397, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(405, 54);
            this.lbTitle.TabIndex = 175;
            this.lbTitle.Text = "Most Sold Products";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Small", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SlateGray;
            this.label1.Location = new System.Drawing.Point(12, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(401, 54);
            this.label1.TabIndex = 176;
            this.label1.Text = "Time Interval From:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Small", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SlateGray;
            this.label2.Location = new System.Drawing.Point(702, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 54);
            this.label2.TabIndex = 177;
            this.label2.Text = "To:";
            // 
            // DTPFrom
            // 
            this.DTPFrom.Animated = true;
            this.DTPFrom.BackColor = System.Drawing.Color.Transparent;
            this.DTPFrom.BorderColor = System.Drawing.Color.DimGray;
            this.DTPFrom.BorderRadius = 20;
            this.DTPFrom.BorderThickness = 1;
            this.DTPFrom.Checked = true;
            this.DTPFrom.FillColor = System.Drawing.SystemColors.HotTrack;
            this.DTPFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DTPFrom.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DTPFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPFrom.Location = new System.Drawing.Point(406, 117);
            this.DTPFrom.MaxDate = new System.DateTime(2024, 7, 15, 0, 0, 0, 0);
            this.DTPFrom.MinDate = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            this.DTPFrom.Name = "DTPFrom";
            this.DTPFrom.Size = new System.Drawing.Size(290, 54);
            this.DTPFrom.TabIndex = 178;
            this.DTPFrom.UseTransparentBackground = true;
            this.DTPFrom.Value = new System.DateTime(2024, 7, 15, 0, 0, 0, 0);
            this.DTPFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DTPFrom_KeyPress);
            // 
            // DTPTo
            // 
            this.DTPTo.Animated = true;
            this.DTPTo.BackColor = System.Drawing.Color.Transparent;
            this.DTPTo.BorderColor = System.Drawing.Color.DimGray;
            this.DTPTo.BorderRadius = 20;
            this.DTPTo.BorderThickness = 1;
            this.DTPTo.Checked = true;
            this.DTPTo.FillColor = System.Drawing.SystemColors.HotTrack;
            this.DTPTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DTPTo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DTPTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPTo.Location = new System.Drawing.Point(778, 117);
            this.DTPTo.MaxDate = new System.DateTime(2024, 7, 15, 0, 0, 0, 0);
            this.DTPTo.MinDate = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            this.DTPTo.Name = "DTPTo";
            this.DTPTo.Size = new System.Drawing.Size(290, 54);
            this.DTPTo.TabIndex = 179;
            this.DTPTo.UseTransparentBackground = true;
            this.DTPTo.Value = new System.DateTime(2024, 7, 15, 0, 0, 0, 0);
            this.DTPTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DTPTo_KeyPress);
            // 
            // btnSearch
            // 
            this.btnSearch.AnimatedGIF = true;
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnSearch.ImageRotate = 0F;
            this.btnSearch.Location = new System.Drawing.Point(1079, 117);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnSearch.Size = new System.Drawing.Size(67, 64);
            this.btnSearch.TabIndex = 180;
            this.btnSearch.UseTransparentBackground = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lbNotFound
            // 
            this.lbNotFound.AutoSize = true;
            this.lbNotFound.Font = new System.Drawing.Font("Sitka Small", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotFound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbNotFound.Location = new System.Drawing.Point(434, 361);
            this.lbNotFound.Name = "lbNotFound";
            this.lbNotFound.Size = new System.Drawing.Size(289, 54);
            this.lbNotFound.TabIndex = 181;
            this.lbNotFound.Text = "--Not Found--";
            this.lbNotFound.Visible = false;
            // 
            // lbRecords
            // 
            this.lbRecords.BackColor = System.Drawing.Color.Transparent;
            this.lbRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecords.ForeColor = System.Drawing.Color.SlateGray;
            this.lbRecords.Location = new System.Drawing.Point(147, 552);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(51, 33);
            this.lbRecords.TabIndex = 184;
            this.lbRecords.Text = "???";
            // 
            // labelRecords
            // 
            this.labelRecords.BackColor = System.Drawing.Color.Transparent;
            this.labelRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRecords.ForeColor = System.Drawing.Color.SlateGray;
            this.labelRecords.Location = new System.Drawing.Point(12, 552);
            this.labelRecords.Name = "labelRecords";
            this.labelRecords.Size = new System.Drawing.Size(129, 33);
            this.labelRecords.TabIndex = 183;
            this.labelRecords.Text = "Records :";
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
            // frmMostSoldProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 637);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.labelRecords);
            this.Controls.Add(this.lbNotFound);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.DTPTo);
            this.Controls.Add(this.DTPFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvMostSoldProducts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMostSoldProducts";
            this.Text = "frmMostSoldProducts";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostSoldProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientButton btnClose;
        private System.Windows.Forms.DataGridView dgvMostSoldProducts;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DateTimePicker DTPFrom;
        private Guna.UI2.WinForms.Guna2DateTimePicker DTPTo;
        private Guna.UI2.WinForms.Guna2ImageButton btnSearch;
        private System.Windows.Forms.Label lbNotFound;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbRecords;
        private Guna.UI2.WinForms.Guna2HtmlLabel labelRecords;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}