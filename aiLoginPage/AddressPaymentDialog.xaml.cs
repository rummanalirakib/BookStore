using BookStoreLIB;
using System;
using System.Collections.Generic;
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

namespace BookStoreGUI
{
    /// <summary>
    /// Interaction logic for AddressPaymentDialog.xaml
    /// </summary>
    public partial class AddressPaymentDialog : Window
    {
        int userID;
        String userDeliveryAddress;
        String userPaymentInformation;
        public AddressPaymentDialog()
        {
            InitializeComponent();
        }

        public void setUserID(int userId)
        {
            userID = userId;
        }

        public void AddressPaymentUIChanges(String Username, String city, String state, String address, String cardNum, String cvv, String expirationDate )
        {
            UserName.Text = Username;
            UserName2.Text = Username;
            CityBox.Text = city;
            StateBox.Text = state;
            AddressBox.Text = address;
            ExpirationBox.Text = expirationDate;
            CardNumBox.Text = cardNum;
            CVVBox.Text = cvv;
        }

        public void setUserDeliveryAddress(string deliveryAddress)
        {
            userDeliveryAddress = deliveryAddress;
        }

        public void setUserPaymentInfo(string userPaymentInfo)
        {
            userPaymentInformation = userPaymentInfo;
        }

        private void AddPayButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(userPaymentInformation))
            {
                UserData userData = new UserData();

                string cardNo = CardNumBox.Text;
                string cvvNo = CVVBox.Text;
                string expiryDateNo = ExpirationBox.Text;

                if (cardNo == "" || cvvNo == "" || expiryDateNo == "")
                {
                    MessageBox.Show("Please fill in all the slots.");
                }
                else
                {
                    bool cvvDigits = cvvNo.All(char.IsDigit);

                    bool cardDigits = cardNo.Replace(" ", "").All(char.IsDigit);

                    bool expDateDigits = expiryDateNo.All(char.IsDigit);

                    int cvvDigitCount = cvvNo.ToCharArray().Count();

                    int cardDigitCount = cardNo.Replace(" ", "").ToCharArray().Count();

                    int expDateCharCount = expiryDateNo.ToCharArray().Count();

                    if (cvvDigits && cvvDigitCount == 3 && cardDigits && cardDigitCount == 16 && expDateDigits && expDateCharCount == 4)
                    {
                        bool isPaymentSaved = userData.SaveUserPaymentInfo(userID, cardNo, cvvNo, expiryDateNo);

                        if (isPaymentSaved)
                        {
                            MessageBox.Show("Payment Information Saved Successfully");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please check Card#, CVV, and Expiry Date.");
                    }
                }

                
            }
        }

        private void RemovePayButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(userPaymentInformation))
            {
                //if string is empty
                MessageBox.Show("No payment information to remove");
            }
            else
            {
                ConfirmationDialog confirmationDialog = new ConfirmationDialog();
                confirmationDialog.Owner = this;
                confirmationDialog.ShowDialog();

                UserData userData = new UserData();

                if (confirmationDialog.DialogResult == true)
                {
                    bool isPaymentInfoDeleted = userData.DeleteUserPaymentInfo(userID);

                    if (isPaymentInfoDeleted)
                    {
                        MessageBox.Show("Payment information removed Successfully");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Could Not Remove Payment Information Due To Server Error.");
                    }
                }
            }
        }

        private void AddAddressButton_Click(object sender, RoutedEventArgs e)
        {
            string city = CityBox.Text;
            string state = StateBox.Text;
            string address = AddressBox.Text;

            if (city == "" || state == "" || address == "")
            {
                MessageBox.Show("Please fill in all the slots.");
            }
            else
            {
                UserData userData = new UserData();

                bool stateHasDigits = state.Any(char.IsDigit);

                int stateCharCount = state.ToCharArray().Count();

                if (!stateHasDigits && stateCharCount == 2)
                {
                    bool isAddressSaved = userData.SaveUserAddress(userID, city, state, address);

                    if (isAddressSaved)
                    {
                        MessageBox.Show("Address Saved Successfully");
                    }
                }
                else
                {
                    MessageBox.Show("Could not save user address. Possible Reasons: - Address Already Saved");
                }
            }
        }

        private void RemoveAddressButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(userDeliveryAddress))
            {
                //if string is empty
                MessageBox.Show("No address information to remove.");
            }
            else
            {
                ConfirmationDialog confirmationDialog = new ConfirmationDialog();
                confirmationDialog.Owner = this;
                confirmationDialog.ShowDialog();

                UserData userData = new UserData();

                if (confirmationDialog.DialogResult == true)
                {
                    bool isAddressDeleted = userData.DeleteUserAddress(userID);

                    if (isAddressDeleted)
                    {
                        MessageBox.Show("Delivery Address information removed Successfully");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Could Not Remove Delivery Address Information Due To Server Error.");
                    }
                }
            }
        }

        private void CityBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
