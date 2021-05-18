using Microsoft.VisualStudio.TestTools.UnitTesting;

using MoneyAssessment.Interfaces;
using MoneyAssessment.BusinessLogic;
using System.Collections.Generic;
using System.Linq;
using System;
using MoneyAssessment.Tests;

namespace MoneyAssessment.Tests
{
    [TestClass]
    public class MoneyCalculatorFixture
    {
        #region Fields
        private IMoneyCalculator MoneyCalc;
        #endregion

        #region Initilize
        /// <summary>
        ///  Test in ititlize instsanciate money calculator and supplies mock logger
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            MoneyCalc = new MoneyCalculator(new MockLogger());
        }
        #endregion

        #region Find Max Tests
        /// <summary>
        /// Empty list test
        /// </summary>
        [TestMethod]
        public void EmptyList_FindMax_Test()
        {
            //Arrange 
            var testData = "";
            var monies = GenerateMonies(testData);

            //Act
            var actual = MoneyCalc.Max(monies);

            //Assert
            Assert.IsNull(actual);
        }


        /// <summary>
        /// Single currency Find max money test
        /// </summary>
        [TestMethod]
        public void SingleCurrency_FindMax_Test()
        {
            //Arrange 
            var testData = "GBP 10, GBP 20, GBP 30, GBP 40";
            var monies = GenerateMonies(testData);
            var expected = new Money("GBP", 40);

            //Act
            var actual = MoneyCalc.Max(monies);

            //Assert
            Assert.AreEqual(expected.Currency, actual.Currency);
            Assert.AreEqual(expected.Amount, actual.Amount);
        }

        /// <summary>
        /// Single currencu find max where money has negative values
        /// </summary>
        [TestMethod]
        public void SingleCurrency_FindMax_NegativeValues_Test()
        {
            //Arrange 
            var testData = "GBP -10, GBP -20, GBP -30, GBP -40";
            var monies = GenerateMonies(testData);
            var expected = new Money("GBP", -10);

            //Act
            var actual = MoneyCalc.Max(monies);

            //Assert
            Assert.AreEqual(expected.Currency, actual.Currency);
            Assert.AreEqual(expected.Amount, actual.Amount);
        }

        /// <summary>
        /// Single currency find maximum where currencies are in different cases
        /// </summary>
        [TestMethod]
        public void SingleCurrency_CaseSensitivity_FindMax_Test()
        {
            //Arrange 
            var testData = "gbp 10, GBP 20, GbP 30, gBp 40";
            var monies = GenerateMonies(testData);
            var expected = new Money("gBp", 40);

            //Act
            var actual = MoneyCalc.Max(monies);

            //Assert
            Assert.AreEqual(expected.Currency, actual.Currency);
            Assert.AreEqual(expected.Amount, actual.Amount);
        }

        /// <summary>
        /// Multiple currency find max check for exception and exception message test
        /// </summary>
        [TestMethod]
        public void MultipleCurrency_FindMax_CheckArgumentException_test()
        {
            //Arrange 
            var testData = "GBP 10, GBP 20, GBP 30, USD 40";
            var monies = GenerateMonies(testData);
            var expected = new Money("GBP", 40);

            //Act        
            var ex = Assert.ThrowsException<ArgumentException>(() => MoneyCalc.Max(monies));

            //Assert
            Assert.AreSame(ex.Message, "All monies are not in the same currency.");
        }



        #endregion

        #region Find Sum Per Currency Tests

        /// <summary>
        /// Dum per currency empty list test
        /// </summary>
        [TestMethod]
        public void EmptyList_FindSumPerCurrency_Test()
        {
            //Arrange 
            var testData = "";
            var monies = GenerateMonies(testData);

            //Act
            var actual = MoneyCalc.SumPerCurrency(monies);

            //Assert
            Assert.IsTrue(actual.Count() == 0);
        }

        /// <summary>
        /// Single currency find sum per currency test
        /// </summary>
        [TestMethod]
        public void SingleCurrency_FindSumPerCurrency_test()
        {
            //Arrange 
            var testData = "GBP 10, GBP 20, GBP 30, GBP 40";
            var monies = GenerateMonies(testData);
            var expected = new Money("GBP", 100);

            //Act
            var actual = MoneyCalc.SumPerCurrency(monies);

            //Assert
            Assert.IsTrue(actual.Count() == 1);
            Assert.AreEqual(expected.Currency, actual.First().Currency);
            Assert.AreEqual(expected.Amount, actual.First().Amount);
        }

        /// <summary>
        /// Single currency find sum per currency test where money has negative values
        /// </summary>
        [TestMethod]
        public void SingleCurrency_FindSumPerCurrency_NegativeValue_test()
        {
            //Arrange 
            var testData = "GBP -10, GBP -20, GBP -30, GBP -40";
            var monies = GenerateMonies(testData);
            var expected = new Money("GBP", -100);

            //Act
            var actual = MoneyCalc.SumPerCurrency(monies);

            //Assert
            Assert.IsTrue(actual.Count() == 1);
            Assert.AreEqual(expected.Currency, actual.First().Currency);
            Assert.AreEqual(expected.Amount, actual.First().Amount);
        }

        /// <summary>
        /// Single currency find sum per currency where currencies has different case
        /// </summary>
        [TestMethod]
        public void SingleCurrency_CaseSensitivity_FindSumPerCurrency_test()
        {
            //Arrange 
            var testData = "gbp 10, GBP 20, gBp 30, GbP 40";
            var monies = GenerateMonies(testData);
            var expected = new Money("GBP", 100);

            //Act
            var actual = MoneyCalc.SumPerCurrency(monies);

            //Assert
            Assert.IsTrue(actual.Count() == 1);
            Assert.AreEqual(expected.Currency, actual.First().Currency);
            Assert.AreEqual(expected.Amount, actual.First().Amount);
        }

        /// <summary>
        /// multiple currency find sum per currency test
        /// </summary>
        [TestMethod]
        public void MultipleCurrency_FindSumPerCurrency_test()
        {
            //Arrange 
            var testData = "GBP 10, GBP 20, GBP 30, USD 10, USD 20, USD 30, INR 10, INR 10000000";
            var monies = GenerateMonies(testData);
            var expected = new List<IMoney>()
            {
                new Money("GBP", 60),
                new Money("INR", 10000010),
                new Money("USD", 60)
            };

            //Act
            var actual = MoneyCalc.SumPerCurrency(monies);

            //Assert
            Assert.AreEqual(expected.Count(), actual.Count());
            Assert.AreEqual(expected.First().Currency, actual.First().Currency);
            Assert.AreEqual(expected.First().Amount, actual.First().Amount);
            Assert.AreEqual(expected.Skip(1).First().Currency, actual.Skip(1).First().Currency);
            Assert.AreEqual(expected.Skip(1).First().Amount, actual.Skip(1).First().Amount);
            Assert.AreEqual(expected.Last().Currency, actual.Last().Currency);
            Assert.AreEqual(expected.Last().Amount, actual.Last().Amount);
        }

        /// <summary>
        /// Multiple currency find sum per currency test where money has negative values
        /// </summary>
        [TestMethod]
        public void MultipleCurrency_FindSumPerCurrency_NegativeValue_test()
        {
            //Arrange 
            var testData = "GBP -10, GBP -20, GBP -30, USD -10, USD -20, USD -30, INR -10, INR -10000000";
            var monies = GenerateMonies(testData);
            var expected = new List<IMoney>()
            {
                new Money("GBP", -60),
                new Money("INR", -10000010),
                new Money("USD", -60)
            };

            //Act
            var actual = MoneyCalc.SumPerCurrency(monies);

            //Assert
            Assert.AreEqual(expected.Count(), actual.Count());
            Assert.AreEqual(expected.First().Currency, actual.First().Currency);
            Assert.AreEqual(expected.First().Amount, actual.First().Amount);
            Assert.AreEqual(expected.Skip(1).First().Currency, actual.Skip(1).First().Currency);
            Assert.AreEqual(expected.Skip(1).First().Amount, actual.Skip(1).First().Amount);
            Assert.AreEqual(expected.Last().Currency, actual.Last().Currency);
            Assert.AreEqual(expected.Last().Amount, actual.Last().Amount);
        }


        /// <summary>
        /// Multiple currency Sum per curreency test with big data
        /// </summary>
        [TestMethod, Timeout(1000)]
        public void MultipleCurrency_FindSumPerCurrency_BigData_test()
        {
            //Arrange 
            var monies = BigDataHelper.GetMonies(999999);

            //Act
            var actual = MoneyCalc.SumPerCurrency(monies);

            //Assert
            Assert.IsTrue(actual.Count() == 10);
        }



        #endregion

        #region Private

        private IEnumerable<IMoney> GenerateMonies(string testData)
        {
            var monies = new List<IMoney>();
            if (string.IsNullOrWhiteSpace(testData))
            {
                return monies;
            }

            testData.Split(',').ToList().ForEach(s =>
            {
                var values = s.Trim().Split(' ');
                monies.Add(new Money(values[0].Trim(), Convert.ToDecimal(values[1].Trim())));
            });
            return monies;
        }

        #endregion
    }
}
