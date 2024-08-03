using OnlineStoreBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO.Pipes;
using System.IO;
using System.Threading;
using Online_Store_Project.Properties;
using LiveCharts.Wpf;
using LiveCharts;
using LiveCharts.WinForms;
using FastReport.DataVisualization.Charting;
using LiveCharts.Definitions.Charts;
using System.Globalization;
using SeriesCollection = LiveCharts.SeriesCollection;
using System.Collections.Concurrent;
using System.Web;

namespace Online_Store_Project
{
    public partial class frmOwnerDashboard : Form
    {
        //declare variables
        private Form _frmLogin;
        private int spacing = 30;
        private int _PageNumber = 1;
        private int _TotalPages = 1;
        private DataTable _dtProducts;
        private DataTable _dtAllProducts;
        private DataTable _dtPendingOrders;
        private NamedPipeServerStream OrderPipe;
        private NamedPipeServerStream MessagesPipe;
        private int _OrderNum = 0;
        private int _MessagesNum = 0;
        private int _NotificationNum = 0;
        private int _TotalVisitors = 0;
        private decimal _TotalRevenue = 0;
        private DataTable _dtAllMessages;
        private DataTable _dtAllNotification;
        private DataTable _dtProcessingOrders;
        private DataTable _dtAllOrders;
        private DataTable _dtCompeleteOrders;
        private clsOrder _Order;
        private DataTable _dtShippings;
        private DataTable _dtChartData;
        private DataTable _dtWeeklySales;
        private bool _DarkMode = false;
        private bool _logoutButtonPressed = false;
        public frmOwnerDashboard(Form frm)
        {
            InitializeComponent();
            _frmLogin = frm;
        }

    
        public void StartListening()
        {
            // Create a named pipe server
            OrderPipe = new NamedPipeServerStream("OrderPipe",PipeDirection.In,-1);

            // Start listening for connections in a separate thread
            Thread listenThread = new Thread(ListenForOrders);
            listenThread.Start();
        }
        private void CloseNamedPipeServer()
        {
            // Check if the named pipe server is not null and is connected
            if (OrderPipe != null && OrderPipe.IsConnected)
            {
                // Disconnect the named pipe server
                OrderPipe.Disconnect();
            }

            // Check if the named pipe server is not null
            if (OrderPipe != null)
            {
                // Close the named pipe server and release resources
                OrderPipe.Close();
                OrderPipe.Dispose();
                OrderPipe = null;
           
            }
        }
        private void ListenForOrders()
        {
            // Wait for a connection
            try
            {
                OrderPipe.WaitForConnection();

                // Read the message from the pipe
                StreamReader reader = new StreamReader(OrderPipe);
                string message = reader.ReadToEnd();

                // Process the received order message
                ProcessOrder(message);

                // Close the named pipe server
                OrderPipe.Disconnect();
                OrderPipe.Close();

                // Restart listening for new orders
                StartListening();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void ProcessOrder(string orderMessage)
        {
            if (orderMessage == "Pending")
            {
                _OrderNum++;   
                lbOrdersNumber.Text = _OrderNum.ToString();
                this.Invoke(new Action(() => _LoadPendingOrders()));
                lbOrdersNumber.Visible = true;
                notifyIcon2.Text = "New Pending Order.";
                notifyIcon2.BalloonTipText = "New Order from customer.";
                notifyIcon2.BalloonTipTitle = "New Order";
                notifyIcon2.ShowBalloonTip(5000);
            }
        }
        public void StartListeningforMessages()
        {
            // Create a named pipe server
            MessagesPipe = new NamedPipeServerStream("MessagePipe",PipeDirection.In,-1);

            // Start listening for connections in a separate thread
            Thread listenThread = new Thread(ListenForMessages);
            listenThread.Start();
        }
        private void CloseNamedPipeServer2()
        {
            // Check if the named pipe server is not null and is connected
            if (MessagesPipe != null && MessagesPipe.IsConnected)
            {
                // Disconnect the named pipe server
                MessagesPipe.Disconnect();
            }

            // Check if the named pipe server is not null
            if (MessagesPipe != null)
            {
                // Close the named pipe server and release resources
                MessagesPipe.Close();
                MessagesPipe.Dispose();
                MessagesPipe = null;

            }
        }
        private void ListenForMessages()
        {
            // Wait for a connection
            MessagesPipe.WaitForConnection();

            // Read the message from the pipe
            StreamReader reader = new StreamReader(MessagesPipe);
            string message = reader.ReadToEnd();

            // Process the received order message
            RefreshMessages(message);

            // Close the named pipe server
            MessagesPipe.Disconnect();
            MessagesPipe.Close();

            // Restart listening for new orders
            StartListeningforMessages();
        }
        private void RefreshMessages(string Message)
        {
            if (Message == "Refresh")
            {
                _MessagesNum++;
                 lbMessagesNumber.Text = _MessagesNum.ToString();
                Task.Run(()=> _dtAllMessages = clsMessage.GetAllMessages());
                lbMessagesNumber.Visible = true;
                _NotificationNum++;
                lbNotificationNum.Text=_NotificationNum.ToString();
                lbNotificationNum.Visible = true;
                lbTotalMessages.Invoke(new Action(() => lbTotalMessages.Text = _MessagesNum.ToString()));
                notifyIcon1.Text = "New Message.";
                notifyIcon1.BalloonTipText = "New Message from customer.";
                notifyIcon1.BalloonTipTitle = "Message";
                notifyIcon1.ShowBalloonTip(5000);
            }
        }
        private List<ctrProduct> _LoadProducts(DataTable Table)
        {
            ctrProduct product;

            ConcurrentBag<ctrProduct> products = new ConcurrentBag<ctrProduct>();
           // Parallel.ForEach(Table.AsEnumerable(), drow =>
              foreach(DataRow drow in Table.Rows)
            {
                product = new ctrProduct((int)drow["ProductID"]);
                product.OnProductUpdated += Product_OnProductUpdated;
                product.ProductRemoved += ProductRemoved;
                product.Margin = new Padding(spacing);
                product.DisplayOwnerMode();
                products.Add(product);
                //Task.Delay(1);
            }
            return products.ToList();
        }
        private void ProductRemoved(object sender, EventArgs e)
        {
            int index = HomePanel.Controls.GetChildIndex((Control)sender);
            HomePanel.Controls.RemoveAt(index);
        }
        private async void Product_OnProductUpdated(int obj)
        {
            HomePanel.Controls.Clear();
            await _DisplayProductsAsync(_PageNumber);
        }

       
        private void _LoadAllOrders()
        {
            _dtAllOrders = clsOrder.GetAllOrders();
            dgvAllOrders.Invoke(new Action(() => dgvAllOrders.DataSource = _dtAllOrders));
            bool detailsColumnExists = dgvAllOrders.Columns.Cast<DataGridViewColumn>().Any(column => column.Name == "btnDetails");
            if (!detailsColumnExists)
            {
           
                DataGridViewImageColumn btnDetails = new DataGridViewImageColumn(); 
                btnDetails.HeaderText = "Order Details";
                btnDetails.Image = Resources.action_items_list_zoom;
                btnDetails.ToolTipText = "View Details";
                btnDetails.Name = "btnDetails";
                dgvAllOrders.Columns.Add(btnDetails);

            }
            dgvAllOrders.CellContentClick += DgvAllOrders_CellContentClick;
            if (dgvAllOrders.Rows.Count == 0)
            {
                lbNoOrders.Visible = true;
                lbNoOrders.Location = new Point(tbAllOrders.Width / 2, tbAllOrders.Height / 2);
                dgvAllOrders.Visible = false;
            }
        }

        private void DgvAllOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn &&
                e.RowIndex >= 0)
            {
                int OrderID = (int)dgvAllOrders.CurrentRow.Cells["OrderID"].Value;
                if (dgvAllOrders.Columns[e.ColumnIndex].Name == "btnDetails")
                {
                    frmOrderDetails orderDetails = new frmOrderDetails(OrderID);
                    orderDetails.StartPosition = FormStartPosition.CenterScreen;
                    orderDetails.ShowDialog();
                }
            }
        
        }

        private async void _LoadPendingOrders()
        {
            dgvPendingOrders.CellContentClick -= DgvOrders_CellContentClick;
            _dtPendingOrders = await Task.Run(() => clsOrder.GetAllPendingOrders());
            dgvPendingOrders.Invoke(new Action(()=>dgvPendingOrders.DataSource =  _dtPendingOrders));


            bool detailsColumnExists = dgvPendingOrders.Columns.Cast<DataGridViewColumn>().Any(column => column.Name == "btnDetails");
            bool processOrderColumnExists = dgvPendingOrders.Columns.Cast<DataGridViewColumn>().Any(column => column.Name == "btnProcessOrder");
            dgvPendingOrders.AutoGenerateColumns = false;
            if (!detailsColumnExists)
            {
              
                DataGridViewImageColumn btnDetails = new DataGridViewImageColumn();
                btnDetails.HeaderText = "Order Details";
                btnDetails.Image = Resources.action_items_list_zoom;
                btnDetails.ToolTipText = "View Details";
                btnDetails.Name = "btnDetails";
                dgvPendingOrders.Columns.Add(btnDetails);
            }

            if (!processOrderColumnExists)
            {
              
                DataGridViewImageColumn btnProcessOrder = new DataGridViewImageColumn();
                btnProcessOrder.HeaderText = "Process Order";
                btnProcessOrder.Image = Resources.our_process;
                btnProcessOrder.ToolTipText = "Process Order";
                btnProcessOrder.Name = "btnProcessOrder";
                dgvPendingOrders.Columns.Add(btnProcessOrder);
            }
          
            dgvPendingOrders.CellContentClick += DgvOrders_CellContentClick;

            if (dgvPendingOrders.Rows.Count == 0)
            {
                lbNoPendingOrders.Visible = true;
                lbNoPendingOrders.Location = new Point(tbPendingOrders.Width / 2, tbPendingOrders.Height / 2);
                dgvPendingOrders.Visible = false;
                btnProcessAllOrders.Visible = false;
                guna2ShadowPanel1.Visible = false;
            }
            else
            {
                lbNoPendingOrders.Visible = false;
                dgvPendingOrders.Visible = true;
                btnProcessAllOrders.Visible = true;
                guna2ShadowPanel1.Visible = true;
            }
        }

        private void DgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

                var senderGrid = (DataGridView)sender;
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn &&
                    e.RowIndex >= 0)
                {
                    int OrderID = (int)dgvPendingOrders.CurrentRow.Cells[0].Value;
                    if (dgvPendingOrders.Columns[e.ColumnIndex].Name == "btnDetails")
                    {
                        frmOrderDetails orderDetails = new frmOrderDetails(OrderID);
                        orderDetails.StartPosition = FormStartPosition.CenterScreen;
                        orderDetails.ShowDialog();
                    }
                    else if (dgvPendingOrders.Columns[e.ColumnIndex].Name == "btnProcessOrder")
                    {
                        _Order = clsOrder.Find(OrderID);
                        if (_Order == null)
                        {
                            MessageBox.Show("Order has been deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (_Order.ProcessOrder())
                        {

                            MessageBox.Show("Order has been directed to Processing Orders Screen.", "InProgress", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _LoadPendingOrders();
                            _LoadProcessingOrders();
                            return;
                        }
                    }
                }
     
        }
        private async void _LoadProcessingOrders()
        { 

             dgvProcessingOrders.CellContentClick -= dgvProcessingOrders_CellContentClick_1;
            _dtProcessingOrders = await Task.Run(()=> clsOrder.GetAllProcessingOrders());
            dgvProcessingOrders.Invoke(new Action(() => dgvProcessingOrders.DataSource = _dtProcessingOrders));
            dgvProcessingOrders.AutoGenerateColumns = false;
            bool detailsColumnExists = dgvProcessingOrders.Columns.Cast<DataGridViewColumn>().Any(column => column.Name == "btnDetails");
            bool CompeleteOrderColumnExists = dgvProcessingOrders.Columns.Cast<DataGridViewColumn>().Any(column => column.Name == "btnCompelete");
           
            if (!detailsColumnExists)
            {
               
                DataGridViewImageColumn btnDetails = new DataGridViewImageColumn();
                btnDetails.HeaderText = "Order Details";
                btnDetails.Image = Resources.action_items_list_zoom;
                btnDetails.ToolTipText = "View Details";
                btnDetails.Name = "btnDetails";
                dgvProcessingOrders.Columns.Add(btnDetails);
            }
            if (!CompeleteOrderColumnExists)
            {
             
                DataGridViewImageColumn btnCompelete = new DataGridViewImageColumn();
                btnCompelete.HeaderText = "Compelete Order";
                btnCompelete.Image = Resources.task_completed;
                btnCompelete.ToolTipText = "Compelete Order";
                btnCompelete.Name = "btnCompelete";
                dgvProcessingOrders.Columns.Add(btnCompelete);
            }
            dgvProcessingOrders.CellContentClick += dgvProcessingOrders_CellContentClick_1;
            if (dgvProcessingOrders.Rows.Count == 0)
            {
                lbNoProcessingOrders.Visible = true;
                lbNoProcessingOrders.Location = new Point(tbProcessingOrders.Width / 2, tbProcessingOrders.Height / 2);
                dgvProcessingOrders.Visible = false;
                btnCompleteAllOrders.Visible = false;
                guna2ShadowPanel2.Visible = false;
            }
            else
            {
                lbNoProcessingOrders.Visible = false;
                dgvProcessingOrders.Visible = true;
                btnCompleteAllOrders.Visible = true;
                guna2ShadowPanel2.Visible = true;
            }
       
        }
        private async void _LoadCompeleteOrders()
        {
            dgvCompeleteOrders.CellContentClick -= DgvCompeleteOrders_CellContentClick;
            _dtCompeleteOrders = await Task.Run(() => clsOrder.GetAllCompeleteOrders());
            dgvCompeleteOrders.Invoke(new Action(() => dgvCompeleteOrders.DataSource = _dtCompeleteOrders));
            dgvCompeleteOrders.AutoGenerateColumns = false;
            bool detailsColumnExists = dgvCompeleteOrders.Columns.Cast<DataGridViewColumn>().Any(column => column.Name == "btnDetails");
            bool ShippingOrderColumnExists = dgvCompeleteOrders.Columns.Cast<DataGridViewColumn>().Any(column => column.Name == "btnShipping");
            if (!detailsColumnExists)
            {

              
                DataGridViewImageColumn btnDetails = new DataGridViewImageColumn();
                btnDetails.HeaderText = "Order Details";
                btnDetails.DefaultCellStyle.BackColor = Color.LightSlateGray;
                btnDetails.Image = Resources.action_items_list_zoom;
                btnDetails.ToolTipText = "View Details";
                btnDetails.Name = "btnDetails";
                dgvCompeleteOrders.Columns.Add(btnDetails);
            }
            if (!ShippingOrderColumnExists)
            {
             
                DataGridViewImageColumn btnShipping = new DataGridViewImageColumn();
                btnShipping.HeaderText = "Shipping Order";
                btnShipping.DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                btnShipping.Image = Resources.delivery_motorcycle;
                btnShipping.ToolTipText = "Shipping Order";
                btnShipping.Name = "btnShipping";
                dgvCompeleteOrders.Columns.Add(btnShipping);
            }
                dgvCompeleteOrders.CellContentClick += DgvCompeleteOrders_CellContentClick;
        
            if (dgvCompeleteOrders.Rows.Count == 0)
            {
                lbNoCompeleteOrders.Visible = true;
                lbNoCompeleteOrders.Location = new Point(tbCompeleteOrders.Width / 2, tbCompeleteOrders.Height / 2);
                dgvCompeleteOrders.Visible = false;
                guna2ShadowPanel3.Visible = false;
            }
            else
            {
                lbNoCompeleteOrders.Visible = false;
                dgvCompeleteOrders.Visible = true;
                guna2ShadowPanel3.Visible = true;
            }
       
        }

        private void DgvCompeleteOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
      
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn &&
                   e.RowIndex >= 0)
                {
                    int OrderID = (int)dgvCompeleteOrders.CurrentRow.Cells[0].Value;
                    if (dgvCompeleteOrders.Columns[e.ColumnIndex].Name == "btnDetails")
                    {

                        frmOrderDetails orderDetails = new frmOrderDetails(OrderID);
                        orderDetails.StartPosition = FormStartPosition.CenterScreen;
                        orderDetails.ShowDialog();
                    }
                    else if (dgvCompeleteOrders.Columns[e.ColumnIndex].Name == "btnShipping")
                    {
                        frmShippingOrder frm = new frmShippingOrder(OrderID);
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.ShowDialog();
                    }
                }
        
        }
        
        private async void _LoadOwnerInfo()
        {
            clsUser Owner = await Task.Run(() => clsUser.Find(clsGlobal.CurrentUser.UserID));
            if (Owner.ImageURL == "")
                picOwner.Image = Resources.PersonEmptyPhoto;
            else
                picOwner.ImageLocation = clsGlobal.CurrentUser.ImageURL;
            lbName.Text = Owner.Name;
            lbEmail.Text = Owner.Email;
        }
        private void _LoadCategories()
        {
            ctrCategories categories = new ctrCategories();
            categories.ShowAddCategory = true;
            categories.Dock = DockStyle.Fill;
            categories.DisplayOwnerMode = true;
            CategoriesSubCategories.Controls.Add(categories);
        }
        private async Task _DisplayProductsAsync(int pageNumber)
        {
            _dtProducts = await Task.Run(() => clsProductCatalog.GetProductsPerPage(pageNumber));

            if (_dtProducts != null)
            {
                HomePanel.Controls.Clear();
                List<ctrProduct> products = await Task.Run(() => _LoadProducts(_dtProducts));
                HomePanel.Controls.AddRange(products.ToArray());
            }
        }
        private async Task _DisplayFirstPage()
        {
            await _DisplayProductsAsync(1);
            btnBackPage.Enabled = false;
            _dtProducts = await Task.Run(() => clsProductCatalog.GetProductsPerPage(2));
            if (_dtProducts.Rows.Count == 0)
                btnNextPage.Enabled = false;

            //Get Total Pages
            _TotalPages = await Task.Run(() => clsProductCatalog.GetTotalPages());
            lbTotalPages.Text = _TotalPages.ToString();

            await Task.Run(() => _dtAllProducts = clsProductCatalog.GetAllProducts());
        }
        private void _LoadAllMessages(DataTable dtMessages)
        {
            ctrMessages Allmessages = new ctrMessages(dtMessages);
            Allmessages.Dock = DockStyle.Fill;
            Messages.Controls.Add(Allmessages);
        }
        private void _DisplayCartesianChart()
        {
            int orders = 0 ;
            int visitors=0;
            int Sales = 0;
            _dtChartData = clsNotificationOwner.GetChartData();
            var seriesCollection = new LiveCharts.SeriesCollection();

            // Create the LineSeries objects for each data category
            var ordersSeries = new LineSeries { Title = "Total Orders", Values = new ChartValues<int>() };
            var visitorsSeries = new LineSeries { Title = "Total Visitors", Values = new ChartValues<int>() };
            var SalesSeries = new LineSeries { Title = "Total Month Sales", Values = new ChartValues<int>() };

            // Add data points to the series
            foreach (DataRow row in _dtChartData.Rows)
            {
                // Extract the values for each month
                string month = row["Month"].ToString();
                 orders = (int)row["TotalOrders"];
                 visitors = (int)row["TotalVisitors"];
                 Sales = (int)row["TotalMonthSales"];

                // Add data points to the series
                ordersSeries.Values.Add(orders);
                visitorsSeries.Values.Add(visitors);
                SalesSeries.Values.Add(Sales);
            
            }
            // Add the series to the SeriesCollection
            seriesCollection.Add(ordersSeries);
            seriesCollection.Add(visitorsSeries);
            seriesCollection.Add(SalesSeries);

            // Set the X-axis labels
            var labels = _dtChartData.AsEnumerable().Select(row => row["Month"].ToString()).ToArray();

            // Set the ChartValues object for the X-axis
            var xValues = new ChartValues<string>(labels);

            // Update the cartesianChart control with the series collection and X-axis values
            cartesianChart2.Series = seriesCollection;
            cartesianChart2.AxisX.Add(new LiveCharts.Wpf.Axis { Labels = xValues });
  


        }
        private void _DisplayPieChart()
        {
            _dtWeeklySales = clsNotificationOwner.GetWeeklySales();
            SeriesCollection seriesCollection = new SeriesCollection();

            // Create a new PieSeries
    
            var Week1SalesSeries = new PieSeries
            {
                Title = "First Week",
                Values = new ChartValues<int> { (int)_dtWeeklySales.Rows[0]["Week1Sales"] },
                DataLabels = true,
                Fill = System.Windows.Media.Brushes.SteelBlue // Customize the color for the slice
            };

     
            var Week2SalesSeries = new PieSeries
            {
                Title = "Second Week",
                Values = new ChartValues<int> { (int)_dtWeeklySales.Rows[0]["Week2Sales"] },
                DataLabels = true,
                Fill = System.Windows.Media.Brushes.Orange // Customize the color for the slice
            };

            var Week3SalesSeries = new PieSeries
            {
                Title = "Third Week",
                Values = new ChartValues<decimal> { (int)_dtWeeklySales.Rows[0]["Week3Sales"] },
                DataLabels = true,
                Fill = System.Windows.Media.Brushes.OrangeRed // Customize the color for the slice
            };

            var Week4SalesSeries = new PieSeries
            {
                Title = "Forth Week",
                Values = new ChartValues<decimal> { (int)_dtWeeklySales.Rows[0]["Week4Sales"] },
                DataLabels = true,
                Fill = System.Windows.Media.Brushes.SlateGray // Customize the color for the slice
            };

            // Add the PieSeries to the SeriesCollection
            seriesCollection.Add(Week1SalesSeries);
            seriesCollection.Add(Week2SalesSeries);
            seriesCollection.Add(Week3SalesSeries);
            seriesCollection.Add(Week4SalesSeries);
            // Set the data source for the chart
            pieChart2.Series = seriesCollection;
         
       
             lbMonth.Text = _dtWeeklySales.Rows[0]["Month"].ToString();

            // Refresh the chart
            pieChart2.Update(true,true);
           
            pieChart2.InnerRadius = 65;
            // Customize the appearance of the pie chart
            pieChart2.LegendLocation = LegendLocation.Bottom; // Move the legend to the right side
            pieChart2.StartingRotationAngle = 270;
        }
     
        private void _LoadMessages()
        {
            _dtAllMessages = clsMessage.GetAllMessages();
            _MessagesNum = _dtAllMessages.Rows.Count;
            _LoadAllMessages(_dtAllMessages);
            lbMessagesNumber.Text = _MessagesNum.ToString();
            lbTotalMessages.Text = _MessagesNum.ToString();
            if (lbMessagesNumber.Text != "0")
                lbMessagesNumber.Visible = true;
            progressMessages.Value = _dtAllMessages.Rows.Count;
        }
        private void _LoadNotifications()
        {
            _dtAllNotification = clsNotificationOwner.GetAllOwnerNotifications();
            _NotificationNum = _dtAllNotification.Rows.Count + _dtAllMessages.Rows.Count;
            lbNotificationNum.Text = _NotificationNum.ToString();
            if (lbNotificationNum.Text != "0")
                lbNotificationNum.Visible = true;
        }
        private void _LoadTotalRevenue()
        {
            _TotalRevenue = clsOrder.GetTotalRevenue();
            lbTotalRevenue.Text = _TotalRevenue.ToString() + "$";
            ProgressRevenue.Value = (int)_TotalRevenue;
        }
        private void _LoadOrdersInfo()
        {
            _LoadAllOrders();
            lbTotalOrders.Text = dgvAllOrders.Rows.Count.ToString();
            progressTotalOrders.Value = dgvAllOrders.Rows.Count;
            cbFilter.SelectedIndex = 0;
        }
        private void _LoadVisitors()
        {
            _TotalVisitors = clsUser.GetCustomersCount();
            lbTotalVisitors.Text = _TotalVisitors.ToString();
            ProgressVisitors.Value = _TotalVisitors;
        }
        private void _PrepareDashboard()
        {
            _LoadOwnerInfo();
            Task.Run(() => _DisplayFirstPage());
            Task.Run(() => _dtShippings = clsShipping.GetAllShippings());
            _LoadPendingOrders();
            _LoadProcessingOrders();
            _LoadCompeleteOrders();
             _LoadCategories();
            _LoadOrdersInfo();
            _LoadMessages();
            _LoadNotifications();
            _LoadTotalRevenue();
            _LoadVisitors();
            _DisplayCartesianChart();
            _DisplayPieChart();

        }

        private  void frmOwnerDashboard_Load(object sender, EventArgs e)
        {
        
            _PrepareDashboard();
            StartListening();
            StartListeningforMessages();

        }

        private void btnSideMenu_Click_1(object sender, EventArgs e)
        {
            tbPages.SelectTab(((Control)sender).Tag.ToString());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //Set Flag to true to handle it on the closing event 
            _logoutButtonPressed = true;
            this.Close();
        }

        //private void lbOrdersNumber_TextChanged(object sender, EventArgs e)
        //{
        //    this.Invoke(new Action(()=> _LoadPendingOrders()));
        //}

        private void dgvProcessingOrders_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn &&
                    e.RowIndex >= 0)
                {
                    int OrderID = (int)dgvProcessingOrders.CurrentRow.Cells[0].Value;
                    if (dgvProcessingOrders.Columns[e.ColumnIndex].Name == "btnDetails")
                    {
                        frmOrderDetails orderDetails = new frmOrderDetails(OrderID);
                        orderDetails.StartPosition = FormStartPosition.CenterScreen;
                        orderDetails.ShowDialog();
                    }
                    else if (dgvProcessingOrders.Columns[e.ColumnIndex].Name == "btnCompelete")
                    {
                        _Order = clsOrder.Find(OrderID);
                        if (_Order == null)
                        {
                            MessageBox.Show("Order has been deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (_Order.CompeleteOrder())
                        {
                            // OrderProcessed?.Invoke(this, EventArgs.Empty);
                            MessageBox.Show("Order has been directed to Compelete Orders Screen.", "Compeleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _LoadProcessingOrders();
                            _LoadCompeleteOrders();
                            return;
                        }
                    }
                }
         
        }

     
        private void picOwner_Click(object sender, EventArgs e)
        {
            frmUserInfo userInfo = new frmUserInfo(clsGlobal.CurrentUser.UserID);
            userInfo.ShowDialog();
            _LoadOwnerInfo();
        }

        private void bttnMessages_Click(object sender, EventArgs e)
        {
            frmMessages messages = new frmMessages(_dtAllMessages);
            messages.StartPosition = FormStartPosition.CenterScreen;
            messages.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            btnSearch.Enabled = false;

            // Start the background worker
            backgroundWorker1.RunWorkerAsync(txtBoxSearch.Text);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string searchText = (string)e.Argument;

            DataView dataView = new DataView(_dtAllProducts);
            dataView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "ProductName", searchText);
            DataTable filteredTable = dataView.ToTable();
            List<ctrProduct> products = _LoadProducts(filteredTable);

            e.Result = products;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSearch.Enabled = true;

            if (e.Error != null)
            {
                MessageBox.Show("An Error Occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                List<ctrProduct> products = (List<ctrProduct>)e.Result;

                // Clear and add the products to the panel
                HomePanel.SuspendLayout();
                HomePanel.Controls.Clear();
                HomePanel.Controls.AddRange(products.ToArray());
                HomePanel.ResumeLayout(true);
            }
        }

        private async void btnBackPage_Click(object sender, EventArgs e)
        {
            _PageNumber--;
            await _DisplayProductsAsync(_PageNumber);
            lbPageNumber.Text = _PageNumber.ToString();
            btnNextPage.Enabled = true;

            if (_PageNumber == 1)
                btnBackPage.Enabled = false;

        }

        private async void btnNextPage_ClickAsync(object sender, EventArgs e)
        {
            _PageNumber++;
            await _DisplayProductsAsync(_PageNumber);
            lbPageNumber.Text = _PageNumber.ToString();
            btnBackPage.Enabled = true;

            if (_PageNumber == _TotalPages)
                btnNextPage.Enabled = false;
        }

        private async void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxSearch.Text == string.Empty)
            {
                HomePanel.Controls.Clear();
                await _DisplayProductsAsync(_PageNumber);
            }
        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            frmOwnerNotifications frm = new frmOwnerNotifications();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            frmAddUpdateProduct addUpdateProduct = new frmAddUpdateProduct();
            addUpdateProduct.DataBackNewProduct += AddedProduct_DataBack;
            addUpdateProduct.DataBackUpdatedProduct += UpdatededProduct_DataBack;
            addUpdateProduct.StartPosition = FormStartPosition.CenterScreen;
            addUpdateProduct.ShowDialog();
        }
        private void UpdatededProduct_DataBack(object sender, int ProductID)
        {
            HomePanel.Controls.Clear();
            Task.Run(() => _DisplayFirstPage());
        }
        private void AddedProduct_DataBack(object sender, int ProductID)
        {
            ctrProduct product = new ctrProduct(ProductID);
            product.OnProductUpdated += Product_OnProductUpdated;
            product.ProductRemoved += ProductRemoved;
            product.Margin = new Padding(spacing);
            product.DisplayOwnerMode();
            HomePanel.Controls.Add(product);
        }

        private void frmOwnerDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(_logoutButtonPressed)
            {
                clsGlobal.CurrentUser = null;
                CloseNamedPipeServer();
                CloseNamedPipeServer2();
                _frmLogin.Show();
            }
            else if (e.CloseReason == CloseReason.UserClosing)
            {
              
                 Environment.Exit(0);
          
            }
            else
            {
                e.Cancel = true;
             
            }
          
        }

        private void btnProcessAllOrders_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Process All Orders?", "Confirm", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsOrder.ProcessAllOrders())
                {
                    _LoadPendingOrders();
                    MessageBox.Show("Orders has been directed to Processing Orders Screen.", "Succss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _LoadProcessingOrders();
                }
            }
            else
                return;

        }

        private void btnCompleteAllOrders_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Complete All Orders?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsOrder.CompleteAllOrders())
                {
                    _LoadProcessingOrders();
                    MessageBox.Show("Orders has been directed to Complete Orders Screen.", "Succss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _LoadCompeleteOrders();
                }
            }
            else
                return;
        }
       
        private void btnSearchOrderStatus_Click(object sender, EventArgs e)
        {
            btnSearchOrderStatus.Enabled = false;

            // Start the background worker
            backgroundWorker2.RunWorkerAsync(txtboxTrackNumber.Text);
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            string searchText = (string)e.Argument;

            DataView dataView = new DataView(_dtShippings);
           dataView.RowFilter = string.Format("[{0}] LIKE '{1}%'", "TrackingNumber", searchText);
            DataTable filteredTable = dataView.ToTable();
            if (filteredTable.Rows.Count == 0)
                e.Result = null;
            else
                e.Result = (int)filteredTable.Rows[0][0];
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSearchOrderStatus.Enabled = true;

            if (e.Error != null)
            {
                MessageBox.Show("An Error Occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (e.Result != null)
                {
                    lbOrderNotFound.Visible = false;
                    int ShippingID = (int)e.Result;
                    ctrShippingOrder shippingOrder = new ctrShippingOrder(ShippingID);
                    shippingOrder.ShowDeliveredCancel = false;
                    shippingOrder.Margin = new Padding(spacing);
                    PanelOrderStatus.SuspendLayout();
                    PanelOrderStatus.Controls.Clear();
                    PanelOrderStatus.Controls.Add(shippingOrder);
                    PanelOrderStatus.ResumeLayout(true);
                }
                else
                {
                    PanelOrderStatus.Controls.Clear();
                    lbOrderNotFound.Visible = true;
                }

    
            }
        }

        private void TotalOrdersCard_MouseHover(object sender, EventArgs e)
        {
            //{DateTime.Now.ToString("MMMM", CultureInfo.InvariantCulture)}
            ToolTip1.SetToolTip(TotalOrdersCard, $"Total Orders {lbTotalOrders.Text}");
        }

        private void TotalRevenueCard_MouseHover(object sender, EventArgs e)
        {
            ToolTip1.SetToolTip(TotalRevenueCard, $"Total Revenue {_TotalRevenue} $");
        }

        private void VisitorsCard_MouseHover(object sender, EventArgs e)
        {
            ToolTip1.SetToolTip(VisitorsCard, $"Total Visitors {_TotalVisitors}");
        }

        private void MessagesCard_MouseHover(object sender, EventArgs e)
        {
            ToolTip1.SetToolTip(MessagesCard, $"Total Messages {lbTotalMessages.Text}");
        }

    
        private void dgvAllOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
          
        }

        private void btnGenarteReport_Click(object sender, EventArgs e)
        {
            frmReport frm = new frmReport();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

     
        private void btnSettings_Click(object sender, EventArgs e)
        {
   
            frmSettings settings = new frmSettings(_DarkMode);
            settings.StartPosition = FormStartPosition.CenterScreen;
            settings.DataBackCustomizeColor += Settings_DataBackCustomizeColor;
            settings.DataBackDarkMode += Settings_DataBackDarkMode;
            settings.DataBackInfoUpdated += Settings_DataBackInfoUpdated;
            settings.ShowDialog();
        }

        private void Settings_DataBackInfoUpdated(object sender, EventArgs e)
        {
            _LoadOwnerInfo();
        }
        private void Settings_DataBackDarkMode(object sender, bool Value)
        {
            _DarkMode = Value;
            if(_DarkMode)
            {
                sidePanel.FillColor = Color.FromArgb(100, 64, 230);
                sidePanel.FillColor2 = Color.FromArgb(64, 64, 64);
                sidePanel.FillColor3 = Color.Black;
                sidePanel.FillColor4 = Color.LightBlue;
                UpperPanel.FillColor = Color.FromArgb(100, 64, 230);
                UpperPanel.FillColor2 = Color.FromArgb(64, 64, 64);
                bunifuCards6.BackColor = Color.FromArgb(64, 64, 64);
                cartesianChart2.BackColor = Color.FromArgb(64, 64, 64);
                HomePanel.BackColor = Color.FromArgb(64, 64, 64);
                panelCharts.FillColor = Color.FromArgb(64, 64, 64);
                PanelPieChart.FillColor = Color.FromArgb(64, 64, 64);
                pieChart2.BackColor = Color.FromArgb(64, 64, 64);
                HomeUpperPanel.FillColor = Color.FromArgb(100, 64, 230);
                HomeUpperPanel.FillColor2 = Color.FromArgb(64, 64, 64);
                HomeLowerPanel.FillColor = Color.FromArgb(100, 64, 230);
                HomeLowerPanel.FillColor2 = Color.FromArgb(64, 64, 64);
                CategoriesSubCategories.BackColor = Color.FromArgb(64, 64, 64);
                ManageOrders.BackColor = Color.FromArgb(64, 64, 64);
                tbPendingOrders.BackColor = Color.FromArgb(64, 64, 64);
                tbProcessingOrders.BackColor = Color.FromArgb(64, 64, 64);
                tbCompeleteOrders.BackColor = Color.FromArgb(64, 64, 64);
                tbAllOrders.BackColor = Color.FromArgb(64, 64, 64);
                tbCheckStatus.BackColor = Color.FromArgb(64, 64, 64);
                Messages.BackColor = Color.FromArgb(64, 64, 64);
                lbDataMonetoring.ForeColor = Color.White;
                lbWeeklySales.ForeColor = Color.White;
                lbMonth.ForeColor = Color.White;
            }
            else
            {
                sidePanel.FillColor = Color.FromArgb(100, 64, 230);
                sidePanel.FillColor2 = Color.SteelBlue;
                sidePanel.FillColor3 = Color.MediumBlue;
                sidePanel.FillColor4 = Color.Navy;
                UpperPanel.FillColor = Color.FromArgb(128, 128, 255);
                UpperPanel.FillColor2 = Color.MediumBlue;
                bunifuCards6.BackColor = Color.White;
                cartesianChart2.BackColor = Color.White;
                HomePanel.BackColor = Color.White;
                panelCharts.FillColor = Color.White;
                PanelPieChart.FillColor = Color.White;
                pieChart2.BackColor = Color.White;
                HomeUpperPanel.FillColor = Color.DeepSkyBlue;
                HomeUpperPanel.FillColor2 = Color.RoyalBlue;
                HomeUpperPanel.FillColor3 = Color.MidnightBlue;
                HomeUpperPanel.FillColor4 = Color.Navy;
                HomeLowerPanel.FillColor = Color.DeepSkyBlue;
                HomeLowerPanel.FillColor2 = Color.RoyalBlue;
                HomeLowerPanel.FillColor3 = Color.MidnightBlue;
                HomeLowerPanel.FillColor4 = Color.Navy;
                CategoriesSubCategories.BackColor = Color.White;
                ManageOrders.BackColor = Color.White;
                tbPendingOrders.BackColor = Color.White;
                tbProcessingOrders.BackColor = Color.White;
                tbCompeleteOrders.BackColor = Color.White;
                tbAllOrders.BackColor = Color.White;
                tbCheckStatus.BackColor = Color.White;
                Messages.BackColor = Color.White;
                lbDataMonetoring.ForeColor = Color.SlateGray;
                lbWeeklySales.ForeColor = Color.SlateGray;
                lbMonth.ForeColor = Color.SlateGray;
            }
        }

        private void Settings_DataBackCustomizeColor(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            UpperPanel.FillColor = colorDialog1.Color;
            sidePanel.FillColor = colorDialog1.Color;
            colorDialog1.ShowDialog();
            sidePanel.FillColor2 = colorDialog1.Color;
            UpperPanel.FillColor2 = colorDialog1.Color;
        }

        private void btnSearchDashboard_Click(object sender, EventArgs e)
        {
            txtBoxSearch.Text = txtBoxDashboard.Text;
            btnSearch.PerformClick();
            tbPages.SelectTab("Products");
        }

        //private void lbMessagesNumber_TextChanged(object sender, EventArgs e)
        //{
        //    _dtAllMessages = clsMessage.GetAllMessages();
        //    _LoadAllMessages(_dtAllMessages);
        //    if (lbMessagesNumber.Text != "0")
        //        lbMessagesNumber.Visible = true;
        //    progressMessages.Value = _dtAllMessages.Rows.Count;
        //    _LoadNotifications();
        //}

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "OrderStatus";
            string FilterValue = cbFilter.Text;
            switch (FilterValue)
            {
                case "All":
                    break;
                case "Pending Orders":
                    FilterValue = "Pending";
                    break;
                case "Processing Orders":
                    FilterValue = "Processing";
                    break;
                case "Compelete Orders":
                    FilterValue = "Compelete";
                    break;
                case "Delivered Orders":
                    FilterValue = "Deliverd";
                    break;
                case "Canceled Orders":
                    FilterValue = "Canceled";
                    break;

            }
            if (FilterValue == "All")
                _dtAllOrders.DefaultView.RowFilter = "";
            else
                _dtAllOrders.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, FilterValue);
            lbRecords.Text = dgvAllOrders.Rows.Count.ToString();
        }

    

        private void frmOwnerDashboard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.ControlKey)
            {
                frmSettings frm = new frmSettings(_DarkMode);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
        }

        private void txtBoxDashboard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                btnSearchDashboard.PerformClick();
            }
        }

        private void txtBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                btnSearch.PerformClick();
            }
        }
    }
}
