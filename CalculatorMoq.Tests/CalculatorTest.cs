using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace CalculatorMoq.Tests
{
    [TestClass]
    public class CalculatorTest
    {
        // Step 6. Add the definition of the mock objects
        private IUSD_CLP_ExchangeRateFeed GetMockExchangeRateFeed()
        {
            Mock<IUSD_CLP_ExchangeRateFeed> mockObject = new Mock<IUSD_CLP_ExchangeRateFeed>();
            mockObject.Setup(m => m.GetActualUSDValue()).Returns(500);
            return mockObject.Object;
        }

        // Step 7. Add the test methods for each test case
        //[TestMethod(Description = "Divide 200 by 5. Expected result is 40.")]
        [TestMethod]

        public void TC1_Divide200By5()
        {
            Mock<IUSD_CLP_ExchangeRateFeed> mockObject = new Mock<IUSD_CLP_ExchangeRateFeed>();
            mockObject.Setup(m => m.GetActualUSDValue()).Returns(500);
            var retVal = mockObject.Object;
            ICalculator calculator = new Calculator(retVal);
            int actualResult = calculator.Divide(200, 5);
            int expectedResult = 40;
            Assert.AreEqual(expectedResult, actualResult);
        }
        // Step 7. Add the test methods for each test case
        //[TestMethod(Description = "Divide 9 by 3. Expected result is 3.")]
        [TestMethod]

        public void TC1_Divide9By3()
        {
            IUSD_CLP_ExchangeRateFeed feed = this.GetMockExchangeRateFeed();
            ICalculator calculator = new Calculator(feed);
            int actualResult = calculator.Divide(9, 3);
            int expectedResult = 3;
            Assert.AreEqual(expectedResult, actualResult);
        }
        //[TestMethod(Description = "Divide any number by zero. Should throw an System.DivideByZeroException exception.")]
        [ExpectedException(typeof(System.DivideByZeroException))]
        [TestMethod]

        public void TC2_DivideByZero()
        {
            IUSD_CLP_ExchangeRateFeed feed = this.GetMockExchangeRateFeed();
            ICalculator calculator = new Calculator(feed);
            int actualResult = calculator.Divide(9, 0);
        }
        //[TestMethod(Description = "Convert 1 USD to CLP. Expected result is 500.")]
        [TestMethod]
        public void TC3_ConvertUSDtoCLPTest()
        {
            IUSD_CLP_ExchangeRateFeed feed = this.GetMockExchangeRateFeed();
            ICalculator calculator = new Calculator(feed);
            int actualResult = calculator.ConvertUSDtoCLP(1);
            int expectedResult = 500;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
