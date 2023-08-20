using BookStoreDATA;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BookStoreLIB
{
    [TestClass]
    public class UserMgnt
    {
        //TestMethod 1-6 - Edit User Info
        [TestMethod]
        public void TestMethod1() // Null values as input
        {
            bool expopt = false;
            DALUserInfo user = new DALUserInfo();
            //user.LogIn("ggrandhi", "qwer12");
            bool actopt = user.EditUser("", "", "");
            Assert.AreEqual(actopt, expopt);
        }

        [TestMethod]
        public void TestMethod2() // Incorrect Firstname
        {
            bool expopt = false;
            DALUserInfo user = new DALUserInfo();
            //user.LogIn("ggrandhi", "qwer12");
            bool actopt = user.EditUser("5Ganesh", "Grandhi", "ggran");
            Assert.AreEqual(actopt, expopt);
        }

        [TestMethod]
        public void TestMethod3() // Incorrect lastname
        {
            bool expopt = false;
            DALUserInfo user = new DALUserInfo();
            //user.LogIn("ggrandhi", "qwer12");
            bool actopt = user.EditUser("Ganesh", "2Grandhi", "ggrand");
            Assert.AreEqual(actopt, expopt);
        }

        [TestMethod]
        public void TestMethod4() // Incorrect username
        {
            bool expopt = false;
            DALUserInfo user = new DALUserInfo();
            //user.LogIn("ggrandhi", "qwer12");
            bool actopt = user.EditUser("Ganesh", "Grandhi", "1ggrand");
            Assert.AreEqual(actopt, expopt);
        }

        [TestMethod]
        public void TestMethod5() //  Inputs are correct but user didn't login 
        {
            bool expopt = false;
            DALUserInfo user = new DALUserInfo();
            //user.LogIn("ggrandhi", "qwer12");
            bool actopt = user.EditUser("Ganesh", "Grandhi", "ggrandhi");
            Assert.AreEqual(actopt, expopt);
        }

        [TestMethod]
        public void TestMethod6() // Edit inputs are correct and user logged in
        {
            bool expopt = true;
            DALUserInfo user = new DALUserInfo();
            user.LogIn("ggrandhi12", "qwer12");
            bool actopt = user.EditUser("Ganesh", "Grandhi", "ggrandhi12");
            Assert.AreEqual(actopt, expopt);
        }
        // Logout test cases - TestMethod 8-9
        [TestMethod]
        public void TestMethod8() // Logout with an active user 
        {
            bool expopt = true;
            DALUserInfo user = new DALUserInfo();
            user.LogIn("ggrandhi12", "qwer12");
            bool actopt = user.logout();
            Assert.AreEqual(actopt, expopt);
        }

        [TestMethod]
        // This test case needs to be run individually/debug because of login functionality
        public void TestMethod7() // Logout without an active user (logged in user)
        {
            bool expopt = false;
            DALUserInfo user = new DALUserInfo();
            //user.LogIn("ggrandhi12", "qwer12");
            bool actopt = user.logout();
            Assert.AreEqual(actopt, expopt);
        }

        // User Creation - TestMethod 9-14

        [TestMethod]
        public void TestMethod9() // Empty password field
        {
            bool expopt = false;
            DALUserInfo user = new DALUserInfo();
            //user.LogIn("ggrandhi12", "qwer12");
            bool actopt = user.NewUser("Sai", "Grandhi", "");
            Assert.AreEqual(actopt, expopt);
        }

        [TestMethod]
        public void TestMethod10() // Empty lastname field
        {
            bool expopt = false;
            DALUserInfo user = new DALUserInfo();
            //user.LogIn("ggrandhi12", "qwer12");
            bool actopt = user.NewUser("Sai", "", "gsg123");
            Assert.AreEqual(actopt, expopt);
        }

        [TestMethod]
        public void TestMethod11() // Empty firstname field
        {
            bool expopt = false;
            DALUserInfo user = new DALUserInfo();
            //user.LogIn("ggrandhi12", "qwer12");
            bool actopt = user.NewUser("", "Grandhi", "gsg123");
            Assert.AreEqual(actopt, expopt);
        }

        [TestMethod]
        public void TestMethod12() // Invalid firstname/ lastname
        {
            bool expopt = false;
            DALUserInfo user = new DALUserInfo();
            //user.LogIn("ggrandhi12", "qwer12");
            bool actopt = user.NewUser("1Sai", "1Grandhi", "gsg123");
            Assert.AreEqual(actopt, expopt);
        }

        [TestMethod]
        public void TestMethod13() // Invalid password
        {
            bool expopt = false;
            DALUserInfo user = new DALUserInfo();
            //user.LogIn("ggrandhi12", "qwer12");
            bool actopt = user.NewUser("Ganesh", "Grandhi", "12qwer");
            Assert.AreEqual(actopt, expopt);
        }

        [TestMethod]
        public void TestMethod14() // Correct input
        {
            bool expopt = true;
            DALUserInfo user = new DALUserInfo();
            //user.LogIn("ggrandhi12", "qwer12");
            bool actopt = user.NewUser("Sai", "Grandhi", "gsg123");
            Assert.AreEqual(actopt, expopt);
        }
    }

}
