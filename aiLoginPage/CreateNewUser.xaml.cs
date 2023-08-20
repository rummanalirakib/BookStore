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

namespace BookStoreGUI
{
    /// <summary>
    /// Interaction logic for CreateNewUser.xaml
    /// </summary>
    public partial class CreateNewUser : Window
    {
        public CreateNewUser()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // create button
        {
            string firstname = this.fname.Text;
            string lastname = this.lname.Text;
            string pwd = this.newpwd.Password;

            var newuser = new DALUserInfo();
            newuser.NewUser(firstname, lastname, pwd);

            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
