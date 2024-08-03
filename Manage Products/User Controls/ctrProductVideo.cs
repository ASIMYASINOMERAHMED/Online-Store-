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
    public partial class ctrProductVideo : UserControl
    {
        public ctrProductVideo(string ProductImage)
        {
            InitializeComponent();
            picBoxItem.ImageLocation = ProductImage;
        }
        public delegate void DataBackPlayVideoEventHandler(object sender,EventArgs e);

        // Declare an event using the delegate
        public event DataBackPlayVideoEventHandler PlayVideoClicked;

        private void btnPlayVideo_Click(object sender, EventArgs e)
        {
            PlayVideoClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
