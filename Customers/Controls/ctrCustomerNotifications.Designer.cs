namespace Online_Store_Project
{
    partial class ctrCustomerNotifications
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
            this.NotificationsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // NotificationsPanel
            // 
            this.NotificationsPanel.AutoScroll = true;
            this.NotificationsPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NotificationsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.NotificationsPanel.Location = new System.Drawing.Point(0, 67);
            this.NotificationsPanel.Name = "NotificationsPanel";
            this.NotificationsPanel.Size = new System.Drawing.Size(1093, 621);
            this.NotificationsPanel.TabIndex = 0;
            // 
            // ctrCustomerNotifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NotificationsPanel);
            this.Name = "ctrCustomerNotifications";
            this.Size = new System.Drawing.Size(1093, 688);
            this.Load += new System.EventHandler(this.ctrCustomerNotifications_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel NotificationsPanel;
    }
}
