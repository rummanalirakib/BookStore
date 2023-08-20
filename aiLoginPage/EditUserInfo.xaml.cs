using BookStoreDATA;
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
    /// Interaction logic for EditUserInfo.xaml
    /// </summary>
    public partial class EditUserInfo : Window
    {
        public EditUserInfo()
        {
            InitializeComponent();
        }

        private void Update_info(object sender, RoutedEventArgs e)
        {
            string firstname = this.fnameedit.Text;
            string lastname = this.lnameedit.Text;
            string username = this.unameedit.Text;

            var edituser = new DALUserInfo();
            edituser.EditUser(firstname, lastname, username);

            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
