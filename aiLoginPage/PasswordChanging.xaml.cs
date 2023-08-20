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
using BookStoreDATA;
using BookStoreLIB;

namespace BookStoreGUI
{
    /// <summary>
    /// Interaction logic for PasswordChanging.xaml
    /// </summary>
    public partial class PasswordChanging : Window
    {
        private int x = 0;
        public PasswordChanging()
        {
            InitializeComponent();
        }

        private void verify_button(object sender, RoutedEventArgs e)
        {
            // Retrieve the logged-in user's username
            string username = this.nameofuser2.Text;
            // Retrieve the logged-in user's password
            string password = this.password2.Password;
            //string username = ((LoginDialog)Application.Current.MainWindow).nameofuser.Text;
            //string password = ((LoginDialog)Application.Current.MainWindow).password.Password;
            DALUserInfo userInfo = new DALUserInfo();
            x = userInfo.LogIn(username, password);
            if (x > 0)
            {
                //reminder: retrieve first name and display it in the following message box
                MessageBox.Show("You are verified, please proceed on changing password");
                //x = userInfo.LogIn(username, password);
            }

            else
                MessageBox.Show("You couldn't be verified, please enter your details again");
        }

        private void Update_button(object sender, RoutedEventArgs e)
        {
            string newPwd = this.updatepass.Password;
            int len = newPwd.Length;
            if (x == -1 || x == 0)
            {
                MessageBox.Show("You need to verify yourself before changing the password");

            }
            else if (newPwd == "")
            {
                MessageBox.Show("Password cannot be NULL");
            }
            else if (len < 6)
            {
                MessageBox.Show("A valid password needs to have at least six characters.");
            }
            else
            {
                if (!char.IsLetter(newPwd[0]))
                {
                    MessageBox.Show("A valid password should start with a letter");
                }
                else
                {
                    int j = 0;
                    int k = 0;
                    for (int i = 0; i < len; i++)
                    {
                        char c = newPwd[i];
                        if (char.IsLetter(c))
                        {
                            j++;
                        }
                        else if (char.IsDigit(c))
                        {
                            k++;
                        }
                    }
                    if (j == 0)
                    {
                        MessageBox.Show("A valid password needs to have at least a letter.");
                    }
                    else if (k == 0)
                    {
                        MessageBox.Show("A valid password needs to have at least a number.");

                    }
                    else
                    {
                        var passwdchng = new DALUserInfo();
                        passwdchng.PasswordChange(newPwd, x);
                    }
                }
            }
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e) // cancel button
        {
            this.Close();

        }
    }
}
