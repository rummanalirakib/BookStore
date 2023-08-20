/* ************************************************************
 * For students to work on assignments and project.
 * Permission required material. Contact: xyuan@uwindsor.ca 
 * ************************************************************/
using BookStoreDATA;
using BookStoreLIB;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace BookStoreGUI
{
    /// Interaction logic for MainWindow.xaml
    public partial class MainWindow : Window
    {
        UserData userData;
        BookOrder bookOrder;
        BookCatalog bookCatalog;
        String searchType;
        public static bool isCartEmpty = false;

        private void exitButton_Click(object sender, RoutedEventArgs e) { this.Close(); }
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new LoginDialog();
            dlg.Owner = this;
            dlg.ShowDialog();

            string username = dlg.nameTextBox.Text;
            string pwd = dlg.passwordTextBox.Password;
            Match match = null;

            Regex r = new Regex("^[a-zA-Z][0-9a-zA-Z]{5,}");

            MatchCollection regexCheck = r.Matches(pwd);
            if (r.Matches(pwd).Count > 0)
            {
                match = regexCheck[0];
            }


            if (dlg.DialogResult == true && (username == "" || pwd == ""))
            {
                MessageBox.Show("Please fill in all the slots.");
            }
            else
            {
                if (match != null && match.Length == pwd.Length)
                {
                    if (userData.LogIn(username, pwd) == true)
                    {
                        this.statusTextBlock.Text = "You are logged in as User #" + userData.UserID;
                        MessageBox.Show("You are logged in as User # " + userData.UserID);
                        if (bookOrder.ItemNumbers() > 0)
                        {
                            bookOrder.SaveAddToCart(userData.UserID);
                        }
                        this.orderListView.ItemsSource = bookOrder.GetAddtoCart(userData.UserID);
                    }
                    else
                        MessageBox.Show("You could not be verified. Please try again.");
                }
                else
                {
                    if (dlg.DialogResult == true)
                        MessageBox.Show("A valid password needs to have at least six characters starting with a letter containing both letters and numbers.");
                }
            }
        }

        public MainWindow() { InitializeComponent(); }
        public void loadBooks()
        {
            var books = bookCatalog.GetBookInfo();
            this.DataContext = books.Tables["Categories"];
            this.productsDataGrid.ItemsSource = books.Tables[1].DefaultView;
            this.categoriesComboBox.ItemsSource = books.Tables[0].DefaultView;
            this.categoryToDelete.ItemsSource = books.Tables[0].DefaultView;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            userData = new UserData();

            bookCatalog = new BookCatalog();
            loadBooks();

            bookOrder = new BookOrder();
            this.orderListView.ItemsSource = bookOrder.OrderItemList;
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            OrderItemDialog orderItemDialog = new OrderItemDialog();
            DataRowView selectedRow;
            if (this.productsDataGrid.SelectedItems.Count > 0)
            {
                selectedRow = (DataRowView)this.productsDataGrid.SelectedItems[0];
                orderItemDialog.isbnTextBox.Text = selectedRow.Row.ItemArray[0].ToString();
                orderItemDialog.titleTextBox.Text = selectedRow.Row.ItemArray[2].ToString();
                orderItemDialog.priceTextBox.Text = selectedRow.Row.ItemArray[4].ToString();
                orderItemDialog.Owner = this;
                orderItemDialog.ShowDialog();
                if (orderItemDialog.DialogResult == true)
                {
                    string isbn = orderItemDialog.isbnTextBox.Text;
                    string title = orderItemDialog.titleTextBox.Text;
                    float unitPrice = float.Parse(orderItemDialog.priceTextBox.Text);
                    int quantity = int.Parse(orderItemDialog.quantityTextBox.Text);
                    bookOrder.AddItem(new OrderItem(isbn, title, unitPrice, quantity), userData.UserID);
                }
            }
            else
            {
                MessageBox.Show("Please select a book first.");
            }
        }
        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.orderListView.SelectedItem != null)
            {
                var selectedOrderItem = this.orderListView.SelectedItem as OrderItem;
                bookOrder.RemoveItem(selectedOrderItem.BookID, userData.UserID);
                MessageBox.Show("The Book has been removed from the cart.");
            }
        }

        private void addPayButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckUserLoggedIn())
            {
                AddressPaymentDialog addressPaymentDialog = new AddressPaymentDialog();
                DALUserInfo userInfo = new DALUserInfo();
                addressPaymentDialog.Owner = this;
                addressPaymentDialog.setUserID(userData.UserID);
                addressPaymentDialog.setUserDeliveryAddress(userInfo.GetDeliveryInformation(userData.UserID));
                addressPaymentDialog.setUserPaymentInfo(userInfo.GetPaymentInformation(userData.UserID));

                String delivery_address = userInfo.GetDeliveryInformation(userData.UserID);
                string[] addressBreakdown;

                if (string.IsNullOrWhiteSpace(delivery_address)) {
                    //if string is empty
                    addressBreakdown = new string[3] { "", "", ""};
                }
                else
                {
                    addressBreakdown = delivery_address.Split(',');
                }
                

                String payment_info = userInfo.GetPaymentInformation(userData.UserID);
                string[] payBreakdown;

                if (string.IsNullOrWhiteSpace(payment_info))
                {
                    //if string is empty
                    payBreakdown = new string[3] { "", "", "" };
                }
                else
                {
                    payBreakdown = payment_info.Split(',');
                }



                addressPaymentDialog.AddressPaymentUIChanges(userInfo.GetFullName(userData.UserID), addressBreakdown[1], addressBreakdown[2], addressBreakdown[0], payBreakdown[0], payBreakdown[1], payBreakdown[2]);
                addressPaymentDialog.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please login to add/update your address and payment information.");
            }
        }
        private void chechoutButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckUserLoggedIn())
            {
                PlaceAnOrder placeAnOrderDialog = new PlaceAnOrder();
                DALUserInfo userInfo = new DALUserInfo();
                int itemNumbers = bookOrder.ItemNumbers();
                if (itemNumbers > 0)
                {
                    placeAnOrderDialog.PlaceAnOrderUIChanges(itemNumbers, bookOrder.GetOrderTotal(), userInfo.GetFullName(userData.UserID), userInfo.GetDeliveryInformation(userData.UserID), userInfo.GetPaymentInformation(userData.UserID), bookOrder.OrderItemList);
                    placeAnOrderDialog.setUserDeliveryAddress(userInfo.GetDeliveryInformation(userData.UserID));
                    placeAnOrderDialog.setUserPaymentInfo(userInfo.GetPaymentInformation(userData.UserID));
                    placeAnOrderDialog.setUserID(userData.UserID);
                    placeAnOrderDialog.ShowDialog();
                    if (isCartEmpty)
                    {
                        bookOrder.EmptyOrderList();
                        this.orderListView.ItemsSource = bookOrder.OrderItemList;
                        isCartEmpty = false;
                    }
                }
                else
                {
                    MessageBox.Show("Add items to the cart before placing order.");
                }
            }
            else
            {
                MessageBox.Show("Please log in before proceeding to checkout.");
            }
        }

        public bool CheckUserLoggedIn()
        {
            if (userData.UserID > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void setCartEmpty()
        {
            isCartEmpty = true;
        }

        private void categoriesComboBox_DropdownClosed(object sender, EventArgs e)
        {
            var item = (DataRowView)categoriesComboBox.SelectedValue;
            if (item == null)
                return;

            int categoryId = (int)item["CategoryID"];
            var books = bookCatalog.SearchByCategory(categoryId);
            this.productsDataGrid.ItemsSource = books.Tables[1].DefaultView;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var query = this.searchQuery.Text;
            var books = bookCatalog.SearchBy(query, searchType);
            this.productsDataGrid.ItemsSource = books.Tables[1].DefaultView;
        }

        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (this.searchTypeCombobox.SelectedItem == null)
                return;
            searchType = ((ComboBoxItem)this.searchTypeCombobox.SelectedItem).Content.ToString();
        }

        private void New_user(object sender, RoutedEventArgs e)
        {
            CreateNewUser newUser = new CreateNewUser();
            newUser.ShowDialog();
        }

        private void Profile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = myComboBox.SelectedItem as ComboBoxItem;
            if (selectedItem != null)
            {
                string selectedOption = selectedItem.Content.ToString();
                if (selectedOption == "Change Password")
                {

                    PasswordChanging changePassword = new PasswordChanging();
                    changePassword.ShowDialog();


                }
                else if (selectedOption == "Edit User Info")
                {
                    EditUserInfo changeUserInfo = new EditUserInfo();
                    changeUserInfo.ShowDialog();

                }
                else if (selectedOption == "Delete Account")
                {
                    DeleteUser deleteUser = new DeleteUser();
                    deleteUser.ShowDialog();

                }
                else if (selectedOption == "View User Info")
                {
                    DisplayUserInfo viewuser = new DisplayUserInfo();
                    viewuser.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Under development");

                }
            }
        }

        public int getCategoryId()
        {
            var category = (DataRowView)categoriesComboBox.SelectedValue;
            if (category == null)
                return -1;
            return (int)category["CategoryID"];
        }

        private void NewBook_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new BookAddWindow();
            var books = bookCatalog.GetBookInfo();
            dialog.categoriesComboBox.ItemsSource = books.Tables[0].DefaultView;
            dialog.ShowDialog();
            if (dialog.DialogResult == true)
            {
                var category = (DataRowView)dialog.categoriesComboBox.SelectedValue;
                if (category == null)
                    return;

                try
                {
                    bookCatalog.AddBook(dialog.isbn.Text, dialog.title.Text, dialog.author.Text, float.Parse(dialog.price.Text), int.Parse(dialog.year.Text), (int)category["CategoryID"]);
                    loadBooks();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void RemoveBook_Click(object sender, RoutedEventArgs e)
        {
            var selection = (DataRowView)productsDataGrid.SelectedValue;
            if (selection == null) return;
            var selectedBookIsbn = (string)selection["ISBN"];
            if (bookCatalog.RemoveBook(selectedBookIsbn))
            {
                MessageBox.Show("Successfully removed the book!");
                loadBooks();
            }
            else
            {
                MessageBox.Show("Failed to delete the book because it's an order item or hasn't been selected.");
            }
        }

        private void NewCategory_Click(object sender, RoutedEventArgs e)
        {
            if (bookCatalog.AddCategory(newCategoryName.Text))
                MessageBox.Show("Successfully added the new category");
            else
                MessageBox.Show("Failed to add category");
            loadBooks();
            newCategoryName.Text = string.Empty;
        }

        private void RemoveCategory_Click(object sender, RoutedEventArgs e)
        {
            var category = (DataRowView)categoryToDelete.SelectedValue;
            if (category == null)
                return;
            var categoryId = (int)category["CategoryID"];

            if (bookCatalog.RemoveCategory(categoryId))
                MessageBox.Show("Successfully removed the category");
            else
                MessageBox.Show("Failed to remove the category");
            loadBooks();
        }
        private void log_out(object sender, RoutedEventArgs e)
        {
            var logOut = new DALUserInfo();
            if (logOut.logout() == true)
            {
                this.statusTextBlock.Text = "User has been successfully logged out";
                bookOrder.EmptyOrderList();
                this.orderListView.ItemsSource = bookOrder.OrderItemList;
                PlaceAnOrder placeAnOrderDialog = new PlaceAnOrder();
                placeAnOrderDialog.setUserID(0);
                userData.UserID = 0;
            }
        }

        private void orderDetails_Click(object sender, RoutedEventArgs e)
        {
            if(CheckUserLoggedIn())
            {
                OrderDetailsWindow orderDetailsWindow = new OrderDetailsWindow();
                orderDetailsWindow.ShowOrderDetails(bookOrder.GetOrderDetails(userData.UserID));
                orderDetailsWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please log in before proceeding to checkout.");
            }
        }
    }
}
