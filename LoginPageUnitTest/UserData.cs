/* ************************************************************
 * For students to work on assignments and project.
 * Permission required material. Contact: xyuan@uwindsor.ca 
 * ************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using BookStoreDATA;

namespace BookStoreLIB
{
    public class UserData
    {
        public int UserID { set; get; }
        public string LoginName { set; get; }
        public string Password { set; get; }
        public Boolean LoggedIn { set; get; }
        public string FullName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }

        public Boolean LogIn(string loginName, string passWord)
        {
            var dbUser = new DALUserInfo();
            UserID = dbUser.LogIn(loginName, passWord);
            if (UserID > 0)
            {
                LoginName = loginName;
                Password = passWord;
                LoggedIn = true;
                return true;
            }
            else
            {
                LoggedIn = false;
                return false;
            }

        }

        public Boolean GetFullName(int userID, string fullName)
        {
            var dbUser = new DALUserInfo();
            FullName = dbUser.GetFullName(userID);
            if (FullName == fullName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetUserID(string loginName, string passWord)
        {
            var dbUser = new DALUserInfo();
            UserID = dbUser.LogIn(loginName, passWord);

            return UserID;
        }

        public bool SaveUserAddress(int userId, string city, string state, string address)
        {
            var dbUser = new DALUserInfo();
            
            bool isUserAddressSaved = dbUser.SetDeliveryInformation(userId, city, state, address);

            return isUserAddressSaved;
        }

        public bool DeleteUserAddress(int userId)
        {
            var dbUser = new DALUserInfo();

            bool isUserAddressRemoved = dbUser.DeleteUserDeliveryInformation(userId);

            return isUserAddressRemoved;
        }

        public bool SaveUserPaymentInfo(int userId, string cardNum, string cvv, string expDate)
        {
            var dbUser = new DALUserInfo();

            bool isUserPaymentSaved = dbUser.SetUserPaymentInformation(userId, cardNum, cvv, expDate);

            return isUserPaymentSaved;
        }

        public bool DeleteUserPaymentInfo(int userId)
        {
            var dbUser = new DALUserInfo();

            bool isUserPaymentRemoved = dbUser.DeleteUserPaymentInformation(userId);

            return isUserPaymentRemoved;
        }

        public Boolean GetDeliveryAddress(int userID, string address, int index)
        {
            var dbUser = new DALUserInfo();
            Address = dbUser.GetDeliveryInformation(userID);
            if (address == Address.Split(',')[index].Trim())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
