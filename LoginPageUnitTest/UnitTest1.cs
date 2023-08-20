using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BookStoreLIB
{
    [TestClass]
    public class UnitTest1
    {
        UserData userData = new UserData();
        string inputName, inputPassword;
        int actualUserId;

        [TestMethod]
        public void TestMethod1()
        {
            //specify the value of test inputs
            inputName = "selse";
            inputPassword = "se1234";
            //specify the value of expected outputs
            Boolean expectedReturn = true;
            int expectedUserId = 6;
            //obtain actual output values by calling the method under testing
            Boolean actualReturn = userData.LogIn(inputName, inputPassword);
            actualUserId = userData.UserID;
            //compare and verify the results
            Assert.AreEqual(actualReturn, expectedReturn);
            Assert.AreEqual(actualUserId, expectedUserId);
        }

        [TestMethod]
        public void TestMethod2() 
        {
            //specify the value of test inputs
            inputName = "";
            inputPassword = "ai1234";
            //specify the value of expected outputs
            Boolean expectedReturn = false;
            int expectedUserId = -1;
            //obtain actual output values by calling the method under testing
            Boolean actualReturn = userData.LogIn(inputName, inputPassword);
            actualUserId = userData.UserID;
            //compare and verify the results
            Assert.AreEqual(actualReturn, expectedReturn);
            Assert.AreEqual(actualUserId, expectedUserId);
        }

        [TestMethod]
        public void TestMethod3() 
        {
            //specify the value of test inputs
            inputName = "aiktider";
            inputPassword = "ai123456";
            //specify the value of expected outputs
            Boolean expectedReturn = false;
            int expectedUserId = -1;
            //obtain actual output values by calling the method under testing
            Boolean actualReturn = userData.LogIn(inputName, inputPassword);
            actualUserId = userData.UserID;
            //compare and verify the results
            Assert.AreEqual(actualReturn, expectedReturn);
            Assert.AreEqual(actualUserId, expectedUserId);
        }

        [TestMethod]
        public void TestMethod4() 
        {
            //specify the value of test inputs
            inputName = "aiktider";
            inputPassword = "ai1@34";
            //specify the value of expected outputs
            Boolean expectedReturn = false;
            int expectedUserId = -1;
            //obtain actual output values by calling the method under testing
            Boolean actualReturn = userData.LogIn(inputName, inputPassword);
            actualUserId = userData.UserID;
            //compare and verify the results
            Assert.AreEqual(actualReturn, expectedReturn);
            Assert.AreEqual(actualUserId, expectedUserId);
        }
    }
}
