using OnlineStoreBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using System.IO.Pipes;
using System.IO;
using System.Collections.Concurrent;
using Microsoft.AspNet.SignalR.Hosting;
using Bunifu.Framework.UI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Threading;
using System.Reflection;

namespace Online_Store_Project
{
    public partial class frmCustomerScreen : Form
    {
        private Form _frmLogin;

        private int spacing = 30;
        private int _PageNumber = 1;
        private int _TotalPages = 1;
        private int _FavouritesNum = 0;
        private int _NotificationNum=0;
        private int _CartNum = 0;
        private int _MessagesNum = 0;
        private DataTable _dtCustomerNotifications;
        private DataTable _dtFavourites;
        private DataTable _dtProducts;
        private DataTable _dtAllProducts;
        private DataTable _dtSentMessages;
        private DataTable _dtReceivedMessages;
        private DataTable _dtOrders;
        private decimal _TotalPrice;
        private ctrCartItem cartItem;
        private clsUser _Customer;
        private clsOrderItem _OrderItem;
        private List<ctrCartItem> _cartItems =new List<ctrCartItem>();
        private clsPayment _Payment;
        private NamedPipeClientStream pipeClient;
        private List<ctrProduct> _ProductList;
        private int _CurrentProductIndex;
        private bool _DarkMode = false;
        private bool _logoutButtonPressed = false;
        private NamedPipeServerStream ResponsePipe;
        public frmCustomerScreen(Form frm)
        {
            InitializeComponent();
            _frmLogin = frm;

            var doubleBufferPropertyInfo = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            doubleBufferPropertyInfo?.SetValue(panelHomeContainer, true, null);

        }
        public void StartListening()
        {
            // Create a named pipe server
            ResponsePipe = new NamedPipeServerStream("ResponsePipe", PipeDirection.In, -1);

            // Start listening for connections in a separate thread
            Thread listenThread = new Thread(ListenForResponses);
            listenThread.Start();
        }
        private void CloseNamedPipeServer()
        {
            // Check if the named pipe server is not null and is connected
            if (ResponsePipe != null && ResponsePipe.IsConnected)
            {
                // Disconnect the named pipe server
                ResponsePipe.Disconnect();
            }

            // Check if the named pipe server is not null
            if (ResponsePipe != null)
            {
                // Close the named pipe server and release resources
                ResponsePipe.Close();
                ResponsePipe.Dispose();
                ResponsePipe = null;

            }
        }
        private void ListenForResponses()
        {
            // Wait for a connection
            try
            {
                ResponsePipe.WaitForConnection();

                // Read the message from the pipe
                StreamReader reader = new StreamReader(ResponsePipe);
                string message = reader.ReadToEnd();

                // Process the received order message
                ProcessResponse(message);

                // Close the named pipe server
                ResponsePipe.Disconnect();
                ResponsePipe.Close();

                // Restart listening for new orders
                StartListening();
            }
            catch (Exception ex)
            {
                return;
            }
        }
        private void ProcessResponse(string ResponseMsg)
        {
            if (ResponseMsg == "Refresh")
            {
                _MessagesNum++;
                 lbMessagesNum.Text = _MessagesNum.ToString();
                 lbMessagesNum.Visible = true;
                _GetNotifications();
                notifyIcon1.Text = "New Message.";
                notifyIcon1.BalloonTipText = "New Message from Owner.";
                notifyIcon1.BalloonTipTitle = "Message";
                notifyIcon1.ShowBalloonTip(5000);
            }
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            _logoutButtonPressed = true;
            clsGlobal.CurrentUser = null;
            CloseNamedPipeServer();
            _frmLogin.Show();
            this.Close();
        }

    
        private ConcurrentBag<ctrProduct> _LoadFavourite(DataTable Table)
        {
            ctrProduct product;

              ConcurrentBag<ctrProduct> products = new ConcurrentBag<ctrProduct>(); 
              Parallel.ForEach(Table.AsEnumerable(), drow =>
              {
                  product = new ctrProduct((int)drow["ProductID"]);
                  product.OnProductAddedToFavorite += Product_OnProductAddedToFavorite;
                  product.OnProductRemoveFromFavorite += Product_OnProductRemoveFromFavorite;
                  product.ShowEditDelete = false;
                  product.Margin = new Padding(spacing);
                  products.Add(product);
              });
            return products;
        }

        private void Product_OnProductRemoveFromFavorite(int obj)
        {
            _RefreshFavourites();
            _FavouritesNum--;
            lbFavouriteNum.Text = _FavouritesNum.ToString();
            if (lbFavouriteNum.Text == "0")
                lbFavouriteNum.Visible = false;
            else
                lbFavouriteNum.Visible = true;
        }

        private void Product_OnProductAddedToFavorite(int obj)
        {
            _RefreshFavourites();
            _FavouritesNum++;
            lbFavouriteNum.Text = _FavouritesNum.ToString();
            lbFavouriteNum.Visible = true;
            _FavouritesNum = PanelFavourit.Controls.Count;
            lbFavouriteNum.Text = _FavouritesNum.ToString();
            if (lbFavouriteNum.Text == "0")
                lbFavouriteNum.Visible = false;
            else
                lbFavouriteNum.Visible = true;
        }
        private async Task _RefreshFavouritesAsync()
        {
            PanelFavourit.Controls.Clear();
            _dtFavourites =await Task.Run(()=> clsProductCatalog.GetAllFavouritesForCustomerID(clsGlobal.CurrentUser.UserID));
            if (_dtFavourites != null)
            {
                ConcurrentBag<ctrProduct> products = await Task.Run(() => _LoadFavourite(_dtFavourites));
                PanelFavourit.Controls.AddRange(products.ToArray());
                if (PanelFavourit.Controls.Count == 0)
                {
                    lbNoFavourits.Visible = true;
                    lbNoFavourits.Location = new Point(PanelFavourit.Width / 2, PanelFavourit.Height / 2);
                }
                else
                    lbNoFavourits.Visible = false;
                _FavouritesNum = PanelFavourit.Controls.Count;
                if (_FavouritesNum == 0)
                    lbFavouriteNum.Visible = false;
                else
                {
                    lbFavouriteNum.Visible = true;
                    lbFavouriteNum.Text = _FavouritesNum.ToString();
                }
            }
          
        }
        private async void _RefreshFavourites()
        {
            await _RefreshFavouritesAsync();
        }
        private List<ctrProduct> _LoadProducts(DataTable Table)
        {
            ctrProduct product;

            List<ctrProduct> products = new List<ctrProduct>();
           // Parallel.ForEach(Table.AsEnumerable(), drow =>
            foreach(DataRow drow in Table.Rows)
            {
                product = new ctrProduct((int)drow["ProductID"]);
                product.ShowEditDelete = false;
                // product.OnProductDeletedUpdated += Product_OnProductDeletedUpdated;
                product.ProductAddedToCart += Product_ProductAddedToCart; ;
                product.OnProductAddedToFavorite += Product_OnProductAddedToFavorite;
                product.OnProductRemoveFromFavorite += Product_OnProductRemoveFromFavorite;
                product.NextItemClicked += Product_NextItemClicked;
                product.BackItemClicked += Product_BackItemClicked;
                product.Margin = new Padding(spacing);
                products.Add(product);
            }
            return products;
        }

        private void Product_BackItemClicked(object sender, int ProductID)
        {
            _CurrentProductIndex = _ProductList.FindIndex(p => p.ProductID == ProductID);
            if (_CurrentProductIndex ==0)
                _CurrentProductIndex = _ProductList.Count;
            ctrProduct Product = _ProductList[_CurrentProductIndex - 1];
            Product.PreformAddToCartClick();
        }

        private void Product_NextItemClicked(object sender, int ProductID)
        {
            _CurrentProductIndex= _ProductList.FindIndex(p=>p.ProductID==ProductID);
            if (_CurrentProductIndex >= _ProductList.Count-1)
                _CurrentProductIndex = -1;
            ctrProduct Product = _ProductList[_CurrentProductIndex + 1];
            Product.PreformAddToCartClick();
        }
        
        private void Product_ProductAddedToCart(object sender, ctrProduct.ProductArgs e)
        {
            _LoadCartItem(e);
            _CartNum++;
            lbCartNumber.Text = _CartNum.ToString();
            lbCartNumber.Visible = true;
            lbCartEmpty.Visible = false;
            PanelCartItems.Visible = true;
            panelConfirmInfo.Visible = true;
        }

        private void _LoadCartItem(ctrProduct.ProductArgs e)
        {
            cartItem = new ctrCartItem(e.ProductID, e.Quantity, e.Color, e.Size);
            cartItem.ProductRemovefromCart += CartItem_ProductRemoveFromCart;
            cartItem.OnProductRemovedfromCart += CartItem_OnProductRemovedfromCart;
            cartItem.OnQuantityIncrement += CartItem_OnQuantityIncrement;
            cartItem.OnQuantitydecrement += CartItem_OnQuantitydecrement;
            cartItem.Margin = new Padding(30);
            PanelCartItems.Controls.Add(cartItem);
            _cartItems.Add(cartItem);
   
        }

        private void CartItem_OnProductRemovedfromCart(decimal ProductTotalPrice)
        {
            _TotalPrice -= ProductTotalPrice;
            lbTotalPrice.Text = _TotalPrice.ToString()+" $";
        }

        private void CartItem_OnQuantitydecrement(decimal ProductPrice)
        {
            _TotalPrice -= ProductPrice;
            lbTotalPrice.Text = _TotalPrice.ToString()+" $";
        }

        private void CartItem_OnQuantityIncrement(decimal ProductPrice)
        {
            _TotalPrice += ProductPrice;
            lbTotalPrice.Text = _TotalPrice.ToString()+ " $";
        }

        private void CartItem_ProductRemoveFromCart(object sender, EventArgs e)
        {
            int index = PanelCartItems.Controls.GetChildIndex((Control)sender);
            PanelCartItems.Controls.RemoveAt(index);
            _CartNum--;
            lbCartNumber.Text = _CartNum.ToString();
            if (_CartNum == 0)
            {
                lbCartEmpty.Visible = true;
                lbCartEmpty.Location = new Point(497, 300);
                PanelCartItems.Visible = false;
                panelConfirmInfo.Visible = false;
            }
        }

        private async Task _DisplayProductsAsync(int pageNumber)
        {
            _dtProducts = await Task.Run(() => clsProductCatalog.GetProductsPerPage(pageNumber));

            if (_dtProducts != null)
            {
                panelHomeContainer.Controls.Clear();
                List<ctrProduct> products = await Task.Run(() => _LoadProducts(_dtProducts));
                panelHomeContainer.Controls.AddRange(products.ToArray());
            }
            _ProductList = panelHomeContainer.Controls.OfType<ctrProduct>().ToList();

        }
  
        private void _DisplayCategories()
        {
            ctrCategories categories = new ctrCategories();
            categories.Dock = DockStyle.Fill;
            categories.ProductAddedToCart += Categories_ProductAddedToCart;
            categories.ProductAddedToFavourite += Categories_ProductAddedToFavourite;
            categories.ProductRemovedFromFavourite += Categories_ProductRemovedFromFavourite;
            categories.ClickableSubCategory = false;
            categories.ShowAddCategory = false;
            Categories.Controls.Add(categories);
        }

        private void Categories_ProductAddedToCart(object sender, ctrProduct.ProductArgs e)
        {
            _LoadCartItem(e);
            _CartNum++;
            lbCartNumber.Text = _CartNum.ToString();
            lbCartNumber.Visible = true;
            lbCartEmpty.Visible = false;
            PanelCartItems.Visible = true;
            panelConfirmInfo.Visible = true;
        }

        private List<ctrOrderInfo> _LoadOrders(DataTable dt)
        {
            ctrOrderInfo order;
            List<ctrOrderInfo> orders=new List<ctrOrderInfo>();
            //Parallel.ForEach(dt.AsEnumerable(), drow =>
            foreach(DataRow drow in dt.Rows)
            {
                order = new ctrOrderInfo((int)drow["OrderID"]);
                order.Margin = new Padding(spacing);
                order.Anchor = AnchorStyles.Left| AnchorStyles.Right;
                order.OrderDetailsVisable = true;
                orders.Add(order);
            }
            return orders;
        }
        private async Task _DisplayOrdersAsync()
        {
            _dtOrders =await Task.Run(()=> clsOrder.GetAllOrdersForCustomerID(clsGlobal.CurrentUser.UserID));
            List<ctrOrderInfo> orders = await Task.Run(() => _LoadOrders(_dtOrders));
             panelOrders.Controls.AddRange(orders.ToArray());
         
            if(panelOrders.Controls.Count == 0)
            {
                panelOrders.Visible = false;
                lbNoOrders.Visible = true;
                lbNoOrders.Location = new Point(Orders.Width / 2, Orders.Height / 2);
            }
         
        }
        private void _ResetCartPage()
        {
            lbCartEmpty.Visible = true;
            lbCartEmpty.Location = new Point(Cart.Width/2, Cart.Height/2);
            panelConfirmInfo.Visible = false;
            PanelCartItems.Visible = false;
            PanelCartItems.Controls.Clear();
            panelConfirmInfo.Visible = false;
            _CartNum = 0;
            _TotalPrice = 0;
            lbCartNumber.Visible = false;
            cbPaymentMethod.SelectedIndex = 0;
            txtboxAddress.Text = clsGlobal.CurrentUser.Address;
            txtEmail.Text = clsGlobal.CurrentUser.Email;
            txtPhone.Text = clsGlobal.CurrentUser.Phone;

        }
        private List<ctrMessage> _LoadMessages(DataTable dataTable)
        {
            ctrMessage message;

            ConcurrentBag<ctrMessage> messages = new ConcurrentBag<ctrMessage>();
            Parallel.ForEach(dataTable.AsEnumerable(), drow =>
            {
                message = new ctrMessage((int)drow["MessageID"]);    
                messages.Add(message);
            });
            return messages.ToList();
        }
        private async Task _DisplaySentMessages()
        {
            SentMessagesContainer.Controls.Clear();
            _dtSentMessages =await Task.Run(()=> clsMessage.GetAllMessagesForCustomerID(clsGlobal.CurrentUser.UserID));
            List<ctrMessage> messages = await Task.Run(() => _LoadMessages(_dtSentMessages));
            foreach (ctrMessage message in messages)
            {
                message.Margin = new Padding(20);
                message.ReplayButtonVisiable = false;
               // message.Width = SentMessagesContainer.Width;
                SentMessagesContainer.Controls.Add(message);
            }
            if (SentMessagesContainer.Controls.Count == 0)
            {
                SentMessagesContainer.Visible = false;
                lbNoSentMessages.Location = new Point(SentMessages.Width / 2, SentMessages.Height / 2);
                lbNoSentMessages.Visible = true; 
            }
            else
            {
                SentMessagesContainer.Visible = true;
                lbNoSentMessages.Visible = false;
            }
        }
        private List<ctrResponse> _LoadResponses(DataTable dataTable)
        {
            ctrResponse Response;

            ConcurrentBag<ctrResponse> responses = new ConcurrentBag<ctrResponse>();
            Parallel.ForEach(dataTable.AsEnumerable(), drow =>
            {
                Response = new ctrResponse((int)drow["ResponseID"]);     
                responses.Add(Response);
            });
            return responses.ToList();
        }
        private async Task _DisplayReseivedMessages()
        {
            ReseivedMessagesContainer.Controls.Clear();
            _dtReceivedMessages =await Task.Run(()=> clsResponse.GetResponsesForCustomerID(clsGlobal.CurrentUser.UserID));
            List<ctrResponse> responses = await Task.Run(() => _LoadResponses(_dtReceivedMessages));
       
            foreach (ctrResponse response in responses)
            {
                response.Margin = new Padding(20);
                response.Width = ReseivedMessagesContainer.Width;
                ReseivedMessagesContainer.Controls.Add(response);
            }
            if (ReseivedMessagesContainer.Controls.Count == 0)
            {
                ReseivedMessagesContainer.Visible = false;
                lbNoReseivedMessages.Location = new Point(SentMessages.Width / 2, SentMessages.Height / 2);
                lbNoReseivedMessages.Visible = true;
            }
            else
            {
                ReseivedMessagesContainer.Visible = true;
                lbNoReseivedMessages.Visible = false;
                _MessagesNum = _dtReceivedMessages.Rows.Count;
                lbMessagesNum.Text = _MessagesNum.ToString();
                lbMessagesNum.Visible = true;
            }
           
        }
        private async Task _DisplayFirstPage()
        {
            await _DisplayProductsAsync(1);
            btnBackPage.Enabled = false;
            _dtProducts =await Task.Run(()=> clsProductCatalog.GetProductsPerPage(2));
            if (_dtProducts.Rows.Count ==0)
                btnNextPage.Enabled = false;

            //Get Total Pages
            _TotalPages = await Task.Run(() => clsProductCatalog.GetTotalPages());
            lbTotalPages.Text = _TotalPages.ToString();

            await  Task.Run(()=>_dtAllProducts = clsProductCatalog.GetAllProducts());
        }
        private void _GetNotifications()
        {
            _dtCustomerNotifications = clsNotificationCustomer.GetAllCustomerNotifications();
            lbNotifications.Text = (_dtCustomerNotifications.Rows.Count+_MessagesNum).ToString();
            lbNotifications.Visible = true;
        }
        private async void _LoadCustomerInfo()
        {
            clsUser customer = await Task.Run(() => clsUser.Find(clsGlobal.CurrentUser.UserID));
            picCustomer.ImageLocation = customer.ImageURL;
            lbName.Text = customer.Name;
            lbEmail.Text = customer.Email;

        }
        private async void frmMain_Load(object sender, EventArgs e)
        {
            _LoadCustomerInfo();
            await _DisplayFirstPage();
            await _RefreshFavouritesAsync();
            await _DisplayOrdersAsync();
            _DisplayCategories();
            await  _DisplaySentMessages();
            await  _DisplayReseivedMessages();
            _GetNotifications();
            _ResetCartPage();
            StartListening();
        }

        private void Categories_ProductRemovedFromFavourite(object sender, EventArgs e)
        {
            _RefreshFavourites();
            _FavouritesNum--;
            lbFavouriteNum.Text = _FavouritesNum.ToString();
            if (lbFavouriteNum.Text == "0")
                lbFavouriteNum.Visible = false;
            else
                lbFavouriteNum.Visible = true;
        }

        private void Categories_ProductAddedToFavourite(object sender, EventArgs e)
        {
            _RefreshFavourites();
            _FavouritesNum++;
            lbFavouriteNum.Text = _FavouritesNum.ToString();
            lbFavouriteNum.Visible = true;
        }

        private void txtboxAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxAddress.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtboxAddress, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtboxAddress, null);
            }
        }
        private bool IsValidEmail(string email)
        {
            string trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                MailAddress addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!IsValidEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            };
        }


        private void _LoadOrder(int OrderID)
        {
            ctrOrderInfo order = new ctrOrderInfo(OrderID);
            order.Margin = new Padding(10);
            order.Anchor = AnchorStyles.Right | AnchorStyles.Left;
            panelOrders.Controls.Add(order);
            panelOrders.Visible = true;
            lbNoOrders.Visible = false;
        }
        private void _SaveOrderItems(int OrderID)
        {
            foreach(ctrCartItem item in _cartItems)
            {
                _OrderItem = new clsOrderItem();
                _OrderItem.OrderID = OrderID;
                _OrderItem.Price = item.ProductPrice;
                _OrderItem.Quantity = item.Quantity;
                _OrderItem.ProductID = item.ProductID;
                _OrderItem.Color = item.Color;
                _OrderItem.Size = item.Size1;
                _OrderItem.TotalItemsPrice = item.TotalPrice;
                if (_OrderItem.Save())
                {
                    continue;
                }
                else
                {
                    MessageBox.Show("Unable To Save Order Items.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        private void _SavePaymentMethod(clsOrder order)
        {
            _Payment = new clsPayment();
            _Payment.OrderID = order.OrderID;
            _Payment.Amount = order.TotalAmount;
            _Payment.PaymentMethod = cbPaymentMethod.Text;
            _Payment.TransactionDate = DateTime.Now;
            if(_Payment.Save())
            {
                return;
            }
            else
            {
                MessageBox.Show("Unable to save PaymentMethod.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void MakeOrder()
        {
            // Connect to the named pipe server
            pipeClient = new NamedPipeClientStream(".", "OrderPipe", PipeDirection.Out);
            try
            {
                // Connect to the named pipe server
                pipeClient.Connect();
                if (pipeClient.IsConnected)
                {
                    // Send the order message to the server
                    StreamWriter writer = new StreamWriter(pipeClient);
                    string orderMessage = "Pending";  // Customize this with your actual order information
                    writer.Write(orderMessage);
                    writer.Flush();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occurred during the connection or sending
                return;
            }
            finally
            {
                // Close the named pipe client
                pipeClient.Close();
            }
        }
        private void btnConfirmOrder_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Customer = clsUser.Find(clsGlobal.CurrentUser.UserID);
            if (_Customer == null)
            {
                MessageBox.Show("Your Info has been Deleted, contact your admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Confirm Order ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                _Customer.Address = txtboxAddress.Text.Trim();
                _Customer.Email = txtEmail.Text.Trim();
                _Customer.Phone = txtPhone.Text.Trim();
                if (_Customer.Save())
                {

                    clsOrder Order = new clsOrder();
                    Order.CustomerID = _Customer.UserID;
                    Order.OrderDate = DateTime.Now;
                    Order.TotalAmount = _TotalPrice;
                    Order.OrderStatus = clsOrder.enOrderStatus.Pending;
                    if (Order.Save())
                    {
                        _SaveOrderItems(Order.OrderID);
                        _SavePaymentMethod(Order);
                        _LoadOrder(Order.OrderID);
                        MakeOrder();
                        MessageBox.Show("Order Confirmed.", "Succss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _ResetCartPage();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Unable to Save data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Unable to Save data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
                return;

        }

        private void PanelCartItems_ControlAdded(object sender, ControlEventArgs e)
        {
            _TotalPrice += cartItem.TotalPrice;
            lbTotalPrice.Text = _TotalPrice.ToString()+" $";
        }

        private void cbPaymentMethod_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cbPaymentMethod.Text) || cbPaymentMethod.SelectedIndex==0)
            {
                e.Cancel = true;
                errorProvider1.SetError(cbPaymentMethod, "Choose Payment Method!");
                return;
            }
            else
            {
                errorProvider1.SetError(cbPaymentMethod, null);
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnSideMenu_Click_1(object sender, EventArgs e)
        {
            tbPages.SelectTab(((Control)sender).Tag.ToString());
        }

        private async void btnSendMessage_Click(object sender, EventArgs e)
        {
            frmSendMessageToOwner sendMessageToOwner = new frmSendMessageToOwner(clsGlobal.CurrentUser.UserID);
            sendMessageToOwner.StartPosition = FormStartPosition.CenterScreen;
            sendMessageToOwner.ShowDialog();
            await _DisplaySentMessages();
        }

        private void picCustomer_Click(object sender, EventArgs e)
        {
            frmAddUpdateCustomer updateCustomer = new frmAddUpdateCustomer(clsGlobal.CurrentUser.UserID);
            updateCustomer.ShowDialog();
            _LoadCustomerInfo();
        }

        private void bttnMessages_Click(object sender, EventArgs e)
        {
            frmMessages messages = new frmMessages(clsGlobal.CurrentUser.UserID);
            messages.StartPosition = FormStartPosition.CenterScreen;
            messages.ShowDialog();

        }

   

        private async void btnNextPage_Click(object sender, EventArgs e)
        {
            _PageNumber++;
            await _DisplayProductsAsync(_PageNumber);
            lbPageNumber.Text = _PageNumber.ToString();
            btnBackPage.Enabled = true;

            if(_PageNumber==_TotalPages)
                btnNextPage.Enabled = false;
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

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            frmCustomerNotifications notifications = new frmCustomerNotifications(clsGlobal.CurrentUser.UserID,_dtCustomerNotifications);
            notifications.ShowCategories += frmNotifications_ShowCategories;
            notifications.ShowDialog();
        }
        private void frmNotifications_ShowCategories(object sender, EventArgs e)
        {
            btnCategories.PerformClick();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
        
            btnSearch.Enabled = false;

            // Start the background worker
            backgroundWorker1.RunWorkerAsync(txtBoxSearch.Text);
        }

        private async void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxSearch.Text == string.Empty)
            {
                panelHomeContainer.Controls.Clear();
                await _DisplayProductsAsync(_PageNumber);
            }
            
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
                panelHomeContainer.SuspendLayout();
                panelHomeContainer.Controls.Clear();
                panelHomeContainer.Controls.AddRange(products.ToArray());
                panelHomeContainer.ResumeLayout(true);
            }
        }

        private void lbCartNumber_TextChanged(object sender, EventArgs e)
        {
            if (lbCartNumber.Text == "0")
                lbCartNumber.Visible = false;
        }

        private void lbFavouriteNum_TextChanged(object sender, EventArgs e)
        {
            if(lbFavouriteNum.Text=="0")
                lbFavouriteNum.Visible = false;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmCustomerSettings frm = new frmCustomerSettings(_DarkMode);
            frm.DataBackCustomizeColor += Frm_DataBackCustomizeColor;
            frm.DataBackDarkMode += Frm_DataBackDarkMode;
            frm.DataBackInfoUpdated += Frm_DataBackInfoUpdated;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void Frm_DataBackInfoUpdated(object sender, EventArgs e)
        {
            _LoadCustomerInfo();
        }

        private void Frm_DataBackDarkMode(object sender, bool Value)
        {
            _DarkMode = Value;
            if (_DarkMode)
            {
                sideMenu.FillColor = Color.FromArgb(100, 64, 230);
                sideMenu.FillColor2 = Color.FromArgb(64, 64, 64);
                sideMenu.FillColor3 = Color.Black;
                sideMenu.FillColor4 = Color.LightBlue;
                //UpperMenu.FillColor = Color.FromArgb(100, 64, 230);
                //UpperMenu.FillColor2 = Color.FromArgb(64, 64, 64);
                panelHomeContainer.BackColor = Color.FromArgb(64, 64, 64);
                Categories.BackColor = Color.FromArgb(64, 64, 64);
                panelOrders.BackColor = Color.FromArgb(64, 64, 64);
                PanelFavourit.BackColor = Color.FromArgb(64, 64, 64);
                SentMessagesContainer.BackColor = Color.FromArgb(64, 64, 64);
                SentMessages.BackColor = Color.FromArgb(64, 64, 64);
                ReseivedMessages.BackColor = Color.FromArgb(64, 64, 64);
                ReseivedMessagesContainer.BackColor = Color.FromArgb(64, 64, 64);

            }
            else
            {
                sideMenu.FillColor = Color.FromArgb(100, 64, 230);
                sideMenu.FillColor2 = Color.MediumBlue;
                sideMenu.FillColor3 = Color.RosyBrown;
                sideMenu.FillColor4 = Color.MidnightBlue;
                //UpperMenu.FillColor = Color.FromArgb(128, 128, 255);
                //UpperMenu.FillColor2 = Color.RosyBrown;
                panelHomeContainer.BackColor = Color.White;
                Categories.BackColor = Color.White;
                panelOrders.BackColor = Color.White;
                PanelFavourit.BackColor = Color.White;
                SentMessagesContainer.BackColor = Color.White;
                SentMessages.BackColor = Color.White;
                ReseivedMessages.BackColor = Color.White;
                ReseivedMessagesContainer.BackColor = Color.White;
            }
        }

        private void Frm_DataBackCustomizeColor(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            UpperMenu.FillColor = colorDialog1.Color;
            sideMenu.FillColor = colorDialog1.Color;
            colorDialog1.ShowDialog();
            UpperMenu.FillColor2 = colorDialog1.Color;
            sideMenu.FillColor2 = colorDialog1.Color;
        }

        private void frmCustomerScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_logoutButtonPressed)
            {
                if (clsGlobal.CurrentUser != null)
                {
                    clsGlobal.CurrentUser = null;
                    _frmLogin.Show();
                    this.Close();
                }
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

        private void btnSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                btnSearch.PerformClick();
            }
        }

        private void txtBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                btnSearch.PerformClick();
            }
        }

        private void frmCustomerScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.ControlKey)
            {
                frmCustomerSettings frm = new frmCustomerSettings(_DarkMode);
                frm.DataBackCustomizeColor += Frm_DataBackCustomizeColor;
                frm.DataBackDarkMode += Frm_DataBackDarkMode;
                frm.DataBackInfoUpdated += Frm_DataBackInfoUpdated;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
        }

      
    }
}
