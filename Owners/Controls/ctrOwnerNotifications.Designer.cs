namespace Online_Store_Project
{
    partial class ctrOwnerNotifications
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
            this.NotificationsContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // NotificationsContainer
            // 
            this.NotificationsContainer.AutoScroll = true;
            this.NotificationsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NotificationsContainer.Location = new System.Drawing.Point(0, 0);
            this.NotificationsContainer.Name = "NotificationsContainer";
            this.NotificationsContainer.Size = new System.Drawing.Size(1126, 675);
            this.NotificationsContainer.TabIndex = 0;
            // 
            // ctrOwnerNotifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.NotificationsContainer);
            this.Name = "ctrOwnerNotifications";
            this.Size = new System.Drawing.Size(1126, 675);
            this.Load += new System.EventHandler(this.ctrOwnerNotifications_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel NotificationsContainer;
    }
}
