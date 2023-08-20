using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreLIB
{
    /// <summary>
    /// Summary description for PlaceAnOrderTesting
    /// </summary>
    [TestClass]
    public class PlaceAnOrderTest
    {
        UserData userData = new UserData();

        // Shipping to related test cases
        [TestMethod]
        public void TestMethod1()
        {
            int userID = 1;
            Boolean expectedReturn = true;
            string expectedFullName = "Donald Clark";
            bool actualReturn = userData.GetFullName(userID, expectedFullName);
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int userID = 1;
            Boolean expectedReturn = false;
            string expectedFullName = "Donald";
            bool actualReturn = userData.GetFullName(userID, expectedFullName);
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod6()
        {
            int userID = 9;
            Boolean expectedReturn = true;
            string expectedFullName = "Rumman Ali";
            bool actualReturn = userData.GetFullName(userID, expectedFullName);
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod7()
        {
            int userID = 5;
            Boolean expectedReturn = true;
            string expectedFullName = "Some One";
            bool actualReturn = userData.GetFullName(userID, expectedFullName);
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod8()
        {
            int userID = 40;
            Boolean expectedReturn = false;
            string expectedFullName = "Grandhi Ganesh One";
            bool actualReturn = userData.GetFullName(userID, expectedFullName);
            Assert.AreEqual(expectedReturn, actualReturn);
        }


        //Delivery Location Related Test Cases
        [TestMethod]
        public void TestMethod3()
        {
            int userID = 2;
            Boolean expectedReturn = true;
            string expectedAdress = "2090 Longfellow Avenue";
            bool actualReturn = userData.GetDeliveryAddress(userID, expectedAdress, 0);
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod4()
        {
            int userID = 1;
            Boolean expectedReturn = true;
            string expectedCity = "Windsor";
            bool actualReturn = userData.GetDeliveryAddress(userID, expectedCity, 1);
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod5()
        {
            int userID = 1;
            Boolean expectedReturn = true;
            string expectedState = "ON";
            bool actualReturn = userData.GetDeliveryAddress(userID, expectedState, 2);
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod9()
        {
            int userID = 2;
            Boolean expectedReturn = false;
            string expectedCity = "Toronto";
            bool actualReturn = userData.GetDeliveryAddress(userID, expectedCity, 1);
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod10()
        {
            int userID = 3;
            Boolean expectedReturn = true;
            string expectedAddress = "21 Scarborough Avenue";
            bool actualReturn = userData.GetDeliveryAddress(userID, expectedAddress, 0);
            Assert.AreEqual(expectedReturn, actualReturn);
        }
    }
}
