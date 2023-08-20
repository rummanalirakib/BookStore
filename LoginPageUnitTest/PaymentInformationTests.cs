using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BookStoreLIB
{
    [TestClass]
    public class PaymentInformationTests
    {

        UserData userData = new UserData();
        int userId;
        String cardNum, cvv, expDate;

        [TestMethod]
        public void TestMethod1()
        {
            // specify the values of test inputs
            userId = userData.GetUserID("jsmith", "js1234");
            cardNum = "1234 5678 9999 0000";
            cvv = "123";
            expDate = "0828";

            //specify the value of expected outputs
            bool expectedReturn = true;

            //obtain actual results from function call
            bool actualReturn = userData.SaveUserPaymentInfo(userId, cardNum, cvv, expDate);

            //compare the results
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // specify the values of test inputs
            userId = userData.GetUserID("jsmith", "js1234");
            cardNum = "1234 5678 ";
            cvv = "123";
            expDate = "0828";

            //specify the value of expected outputs
            bool expectedReturn = false;

            //obtain actual results from function call
            bool actualReturn = userData.SaveUserPaymentInfo(userId, cardNum, cvv, expDate);

            //compare the results
            Assert.AreEqual(expectedReturn, actualReturn);
        }


        [TestMethod]
        public void TestMethod3()
        {
            // specify the values of test inputs
            userId = userData.GetUserID("jsmith", "js1234");
            cardNum = "";
            cvv = "123";
            expDate = "0828";

            //specify the value of expected outputs
            bool expectedReturn = false;

            //obtain actual results from function call
            bool actualReturn = userData.SaveUserPaymentInfo(userId, cardNum, cvv, expDate);

            //compare the results
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod4()
        {
            // specify the values of test inputs
            userId = userData.GetUserID("jsmith", "js1234");
            cardNum = "1234 5678 9999 0000";
            cvv = "13";
            expDate = "088";

            //specify the value of expected outputs
            bool expectedReturn = false;

            //obtain actual results from function call
            bool actualReturn = userData.SaveUserPaymentInfo(userId, cardNum, cvv, expDate);

            //compare the results
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod5()
        {
            // specify the values of test inputs
            userId = userData.GetUserID("jsmith", "js1234");
            cardNum = "1234 5678 9999 0000";
            cvv = "";
            expDate = "0828";

            //specify the value of expected outputs
            bool expectedReturn = false;

            //obtain actual results from function call
            bool actualReturn = userData.SaveUserPaymentInfo(userId, cardNum, cvv, expDate);

            //compare the results
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod6()
        {
            // specify the values of test inputs
            userId = userData.GetUserID("jsmith", "js1234");
            cardNum = "1234 5678 9999 0000";
            cvv = "123";
            expDate = "";

            //specify the value of expected outputs
            bool expectedReturn = false;

            //obtain actual results from function call
            bool actualReturn = userData.SaveUserPaymentInfo(userId, cardNum, cvv, expDate);

            //compare the results
            Assert.AreEqual(expectedReturn, actualReturn);
        }
    }
}
