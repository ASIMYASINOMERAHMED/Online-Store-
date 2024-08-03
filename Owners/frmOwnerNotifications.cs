using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Store_Project
{
    public partial class frmOwnerNotifications : Form
    {
        public frmOwnerNotifications()
        {
            InitializeComponent();
        }

        private void frmOwnerNotifications_Load(object sender, EventArgs e)
        {
            ctrOwnerNotifications ownerNotifications = new ctrOwnerNotifications();
            ownerNotifications.Dock = DockStyle.Bottom;
  //          ownerNotifications.Height = 672;
            ownerNotifications.BringToFront();
            this.Controls.Add(ownerNotifications);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
