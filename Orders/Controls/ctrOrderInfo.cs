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
    public partial class ctrOrderInfo : UserControl
    {
        private int _OrderID;
        private clsOrder _Order;
        private bool _OrderDetailsVisable=false;
        public ctrOrderInfo(int OrderID)
        {
            InitializeComponent();
            _OrderID = OrderID;
        }
        public bool OrderDetailsVisable
        {
            get { return _OrderDetailsVisable;}
            set 
            {
                _OrderDetailsVisable = value;
                linkLabel1.Visible = _OrderDetailsVisable;
            }
        }
        private void ctrOrderInfo_Load(object sender, EventArgs e)
        {
            _Order = clsOrder.Find(_OrderID);
            if( _Order == null )
            {
                MessageBox.Show("Order has been deleted.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            lbOrderID.Text = _Order.OrderID.ToString();
            lbCustomerName.Text = _Order.Customer.Name;
            lbOrderDate.Text = _Order.OrderDate.ToString();
            lbTotalPrice.Text = _Order.TotalAmount.ToString();
            lbStatus.Text = _Order.OrderStatus.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmOrderDetails frm = new frmOrderDetails(_OrderID);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }
    }
}
