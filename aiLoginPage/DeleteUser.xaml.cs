using System;
using System.Data.SqlClient;
using System.Security;
using System.Windows;
using BookStoreDATA;

namespace BookStoreGUI
{
    public partial class DeleteUser : Window
    {
        public DeleteUser()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            string userName = usernameTextBox.Text;
            string password = ConvertSecureStringToString(passwordTextBox.SecurePassword);

            var deleteuser = new DALUserInfo();
            deleteuser.DeleteUser(userName, password);
        }

        private string ConvertSecureStringToString(SecureString secureString)
        {
            IntPtr ptr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(secureString);
            string unsecureString = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(ptr);
            System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(ptr);
            return unsecureString;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
