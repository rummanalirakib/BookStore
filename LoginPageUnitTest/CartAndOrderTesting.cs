using BookStoreDATA;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreLIB
{
    /// <summary>
    /// Summary description for CartAndOrderTesting
    /// </summary>
    [TestClass]
    public class CartAndOrderTesting
    {
        CartAndOrder cartAndOrder = new CartAndOrder();
        //This book exists in the cart
        [TestMethod]
        public void TestMethod1()
        {
            int userID = 9;
            Boolean expectedReturn = true;
            string expectedSearch = "A Good Book";
            bool actualReturn = cartAndOrder.GetBookSearchResult(userID, expectedSearch);
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int userID = 9;
            Boolean expectedReturn = false;
            float expectedPrice = 12;
            bool actualReturn = cartAndOrder.GetBookPrice(userID, expectedPrice);
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        //This book was removed from the cart check
        [TestMethod]
        public void TestMethod3()
        {
            int userID = 9;
            Boolean expectedReturn = false;
            string expectedSearch = "Some Title";
            bool actualReturn = cartAndOrder.GetBookSearchResult(userID, expectedSearch);
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        //This book was updated for the cart
        [TestMethod]
        public void TestMethod4()
        {
            int userID = 9;
            Boolean expectedReturn = true;
            int expectedQuantity = 3;
            bool actualReturn = cartAndOrder.GetUpdatedBookQuantity(userID, expectedQuantity);
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        //After placing order empty the order cart
        [TestMethod]
        public void TestMethod5()
        {
            int userID = 8;
            Boolean expectedReturn = true;
            bool actualReturn = cartAndOrder.CheckAddToCart(userID);
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        //Get All items from add to cart
        [TestMethod]
        public void TestMethod6()
        {
            int userID = 9;
            int expectedReturn = 1;
            int actualReturn = cartAndOrder.GetAddToCartItem(userID, expectedReturn);
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        //Place an order check
        [TestMethod]
        public void TestMethod7()
        {
            int userID = 5;
            bool expectedReturn = true;
            bool actualReturn = cartAndOrder.GetOrderCheck(userID);
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        //Count item numbers
        [TestMethod]
        public void TestMethod8()
        {
            int userID = 6;
            int expectedReturn = 7;
            int actualReturn = cartAndOrder.GetTotalItemsNumber(userID);
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        //Order Details Check
        [TestMethod]
        public void TestMethod9()
        {
            int userID = 5;
            int expectedReturn = 1;
            int actualReturn = cartAndOrder.GetTotalOrderDetails(userID);
            Assert.AreEqual(expectedReturn, actualReturn);
        }
    }
}
