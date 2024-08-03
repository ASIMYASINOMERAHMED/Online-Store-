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
    public partial class frmItemDetails : Form
    {
        private int _ProductID;
        private int _OrderID;
        public frmItemDetails(int OrderID,int ProductID)
        {
            InitializeComponent();
            _OrderID = OrderID;
            _ProductID = ProductID;
        }

        private void frmItemDetails_Load(object sender, EventArgs e)
        {
            ctrCartItem ItemDetails = new ctrCartItem(_OrderID,_ProductID);
            ItemDetails.Dock = DockStyle.Top;
            this.Controls.Add(ItemDetails);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
