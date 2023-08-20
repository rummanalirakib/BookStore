using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BookStoreDATA;

namespace BookStoreGUI
{
    public partial class DisplayUserInfo : Window
    {
        public DisplayUserInfo()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            string userName = nameTextBox.Text;
            var viewuserinfo = new DALUserInfo();
            viewuserinfo.ViewUserInfo(userName);
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
