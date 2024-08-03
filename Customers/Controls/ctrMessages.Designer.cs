namespace Online_Store_Project
{
    partial class ctrMessages
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
            this.MessagesContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.lbNoMessages = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MessagesContainer
            // 
            this.MessagesContainer.AutoScroll = true;
            this.MessagesContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessagesContainer.Location = new System.Drawing.Point(0, 0);
            this.MessagesContainer.Name = "MessagesContainer";
            this.MessagesContainer.Size = new System.Drawing.Size(1141, 636);
            this.MessagesContainer.TabIndex = 0;
            // 
            // lbNoMessages
            // 
            this.lbNoMessages.AutoSize = true;
            this.lbNoMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoMessages.ForeColor = System.Drawing.Color.Red;
            this.lbNoMessages.Location = new System.Drawing.Point(345, 314);
            this.lbNoMessages.Name = "lbNoMessages";
            this.lbNoMessages.Size = new System.Drawing.Size(434, 42);
            this.lbNoMessages.TabIndex = 3;
            this.lbNoMessages.Text = "--No Messages Found--";
            this.lbNoMessages.Visible = false;
            // 
            // ctrMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbNoMessages);
            this.Controls.Add(this.MessagesContainer);
            this.Name = "ctrMessages";
            this.Size = new System.Drawing.Size(1141, 636);
            this.Load += new System.EventHandler(this.ctrMessages_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel MessagesContainer;
        private System.Windows.Forms.Label lbNoMessages;
    }
}
