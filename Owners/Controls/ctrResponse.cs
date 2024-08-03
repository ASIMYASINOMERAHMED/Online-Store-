using Online_Store_Project.Properties;
using OnlineStoreBusiness;
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
    public partial class ctrResponse : UserControl
    {
        private int _ResponseID;
        private clsResponse _Response;
        public ctrResponse(int ResponseID)
        {
            InitializeComponent();
            _ResponseID = ResponseID;
        }

        private void ctrResponse_Load(object sender, EventArgs e)
        {
            _Response = clsResponse.Find(_ResponseID);
            if (_Response == null)
            {
                MessageBox.Show("Message has been deleted.", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lbDateTime.Text = _Response.DateTime.ToString();
            lbMessage.Text = _Response.Response;
            ToolTip1.SetToolTip(lbMessage, lbMessage.Text);
            lbName.Text = _Response.Owner.Name;
            if (_Response.Owner.ImageURL != null && _Response.Owner.ImageURL != "")
                picCustomer.ImageLocation = _Response.Owner.ImageURL;
            else
                picCustomer.Image = Resources.PersonEmptyPhoto;
        }
    }
}
