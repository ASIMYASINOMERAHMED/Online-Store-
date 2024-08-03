namespace Online_Store_Project
{
    partial class ctrCustomersReviews
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
            this.PanelReviews = new System.Windows.Forms.FlowLayoutPanel();
            this.lbNoReviews = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PanelReviews
            // 
            this.PanelReviews.AutoScroll = true;
            this.PanelReviews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelReviews.Location = new System.Drawing.Point(0, 0);
            this.PanelReviews.Name = "PanelReviews";
            this.PanelReviews.Size = new System.Drawing.Size(633, 689);
            this.PanelReviews.TabIndex = 0;
            // 
            // lbNoReviews
            // 
            this.lbNoReviews.AutoSize = true;
            this.lbNoReviews.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoReviews.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbNoReviews.Location = new System.Drawing.Point(204, 322);
            this.lbNoReviews.Name = "lbNoReviews";
            this.lbNoReviews.Size = new System.Drawing.Size(239, 37);
            this.lbNoReviews.TabIndex = 23;
            this.lbNoReviews.Text = "--No Reviews--";
            this.lbNoReviews.Visible = false;
            // 
            // ctrCustomersReviews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.lbNoReviews);
            this.Controls.Add(this.PanelReviews);
            this.Name = "ctrCustomersReviews";
            this.Size = new System.Drawing.Size(633, 689);
            this.Load += new System.EventHandler(this.ctrCustomersReviews_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel PanelReviews;
        private System.Windows.Forms.Label lbNoReviews;
    }
}
