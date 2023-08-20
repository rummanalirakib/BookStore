using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BookStoreLIB
{
    [TestClass]
    public class ShippingAddressTests
    {

        UserData userData = new UserData();
        int userId;
        String city, state, address;

        [TestMethod]
        public void TestMethod1()
        {
            // specify the values of test inputs
            userId = userData.GetUserID("jsmith", "js1234");
            city = "Windsor";
            state = "";
            address = "";

            //specify the value of expected outputs
            bool expectedReturn = false;

            //obtain actual results from function call
            bool actualReturn = userData.SaveUserAddress(userId, city, state, address);

            //compare the results
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // specify the values of test inputs
            userId = userData.GetUserID("jsmith", "js1234");
            city = "Windsor";
            state = "2N";
            address = "717 Partington Avenue";

            //specify the value of expected outputs
            bool expectedReturn = false;

            //obtain actual results from function call
            bool actualReturn = userData.SaveUserAddress(userId, city, state, address);

            //compare the results
            Assert.AreEqual(expectedReturn, actualReturn);
        }


        [TestMethod]
        public void TestMethod3()
        {
            // specify the values of test inputs
            userId = userData.GetUserID("aiktider", "ai1234");
            city = "Windsor";
            state = "ON";
            address = "717 Partington Avenue";

            //specify the value of expected outputs
            bool expectedReturn = true;

            //obtain actual results from function call
            bool actualReturn = userData.SaveUserAddress(userId, city, state, address);

            //compare the results
            Assert.AreEqual(expectedReturn, actualReturn);
        }
    }
}
