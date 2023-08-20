using BookStoreDATA;
using BookStoreLIB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BookStoreGUI
{
    /// <summary>
    /// Interaction logic for PlaceAnOrder.xaml
    /// </summary>
    public partial class PlaceAnOrder : Window
    {
        String userDeliveryAddress;
        String userPaymentInfo;
        int userID;
        MainWindow mainWindow = new MainWindow();
        UserData userData = new UserData();
        DALUserInfo userInfo = new DALUserInfo();
        BookOrder bookOrder = new BookOrder();
        public PlaceAnOrder()
        {
            InitializeComponent();
        }

        public void PlaceAnOrderUIChanges(int itemNumber, double itemTotal, string userName, string deliveryAddress, string paymentInformation, ObservableCollection<OrderItem> orderItems)
        {
            double deliveryCharge = 5.0;
            double beforeTaxTotal = itemTotal + deliveryCharge;
            double tax = beforeTaxTotal * 0.2;
            double inTotal = itemTotal + tax;
            shippingToText.Text = userName;
            placeonOrderItems.Content = "Items (" + itemNumber + ")";
            placeonOrderText.Text = "$" + itemTotal.ToString("F2");
            shippingHandlingText.Text = "$" + deliveryCharge.ToString("F2");
            totalBeforeTax.Text = "$" + beforeTaxTotal.ToString("F2");
            estimatedGst.Text = "$" + tax.ToString("F2");
            orderTotal.Text = "$" + inTotal.ToString("F2");
            deliveryAddressInfo.Text = deliveryAddress.ToString();

            string[] payBreakdown;

            if (string.IsNullOrWhiteSpace(paymentInformation))
            {
                //if string is empty
                payBreakdown = new string[3] { "", "", "" };
            }
            else
            {
                payBreakdown = paymentInformation.Split(',');
            }

            if (string.IsNullOrWhiteSpace(payBreakdown[0])) {
                //if string is empty
                paymentInfo.Text = "";
            }
            else
            {
                paymentInfo.Text = "XXXX-XXXX-XXXX-" + payBreakdown[0].Substring(payBreakdown[0].Length - 4);
            }
            
            this.placeOrderListView.ItemsSource = orderItems;
        }

        public void setUserDeliveryAddress(string deliveryAddress)
        {
            userDeliveryAddress = deliveryAddress;
        }

        public void setUserPaymentInfo(string paymentInfo)
        {
            userPaymentInfo = paymentInfo;
        }

        public void setUserID(int userId)
        {
            userID = userId;
        }

        private int getUserID()
        {
            return userID;
        }

        private void placeOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(userDeliveryAddress))
            {
                MessageBox.Show("Please add a delivery address before placing an order ");
            }
            else
            {
                if (string.IsNullOrWhiteSpace(userPaymentInfo))
                {
                    MessageBox.Show("Please add payment information before placing an order ");
                }
                else 
                {
                    BookOrder bookOrder = new BookOrder();
                    bookOrder.GetAddtoCart(getUserID());
                    int orderId = bookOrder.PlaceOrder(getUserID());
                    if (orderId > 0)
                    {
                        DALAddToCart dALAddToCart = new DALAddToCart();
                        MessageBox.Show("Your order has been placed. Your order id is " + orderId.ToString());
                        dALAddToCart.EmptyBookCart(userID);
                        this.Close();
                        mainWindow.setCartEmpty();
                    }
                    else
                    {
                        MessageBox.Show("The order could not be placed");
                    }
                }
            }
            
        }

        private void deliveryAddressButton_Click_1(object sender, RoutedEventArgs e)
        {
            UserData userData = new UserData();

            if (userDeliveryAddress == "")
            {
                AddDeliveryAddressDialog addDeliveryAddressDialog = new AddDeliveryAddressDialog();
                addDeliveryAddressDialog.Owner = this;
                addDeliveryAddressDialog.ShowDialog();

                string city = addDeliveryAddressDialog.cityTextBox.Text;
                string state = addDeliveryAddressDialog.stateTextBox.Text;
                string address = addDeliveryAddressDialog.addressTextBox.Text;

                if (addDeliveryAddressDialog.DialogResult == true)
                {

                    if (city == "" || state == "" || address == "")
                    {
                        MessageBox.Show("Please fill in all the slots.");
                    }
                    else
                    {
                        bool stateHasDigits = state.Any(char.IsDigit);

                        int stateCharCount = state.ToCharArray().Count();
                        
                        int itemNumbers = bookOrder.ItemNumbers();

                        if (!stateHasDigits && stateCharCount == 2)
                        {
                            bool isAddressSaved = userData.SaveUserAddress(userID, city, state, address);

                            if (isAddressSaved)
                            {
                                MessageBox.Show("Address Saved Successfully. Please Reopen the window to see changes.");
                            }
                            String updatedAddress = userInfo.GetDeliveryInformation(userData.UserID);
                            deliveryAddressInfo.Text = updatedAddress;
                            Application.Current.Dispatcher.Invoke(DispatcherPriority.Render,
                                          new Action(delegate { }));
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("State should not have more than 2 Alphabets");
                        }
                    } 

                }
            }
            else
            {
                MessageBox.Show("You already have a delivery address");
            }
        }
    }
}
