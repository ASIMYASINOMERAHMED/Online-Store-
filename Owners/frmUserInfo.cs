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
    public partial class frmUserInfo : Form
    {
        private int _UserID;
        private clsUser _User;
        private bool _EditVisible = true;
        public frmUserInfo(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }
        public bool EditVisible
        {
            get { return _EditVisible; }
            set
            {
                _EditVisible = value;

            }
        }
        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            ctrUserInfo userInfo = new ctrUserInfo(_UserID);
            userInfo.EditVisible = EditVisible;
            userInfo.Dock = DockStyle.Top;
            this.Controls.Add(userInfo);

        }
    }
}
