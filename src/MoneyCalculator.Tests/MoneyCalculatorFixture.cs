﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

using MoneyAssessment.Interfaces;
using MoneyAssessment.BusinessLogic;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MoneyAssessment.Tests
{
    [TestClass]
    public class MoneyCalculatorFixture
    {
        private IMoneyCalculator MoneyCalc;

        #region Initilize
        /// <summary>
        ///  Test in ititlize instsanciate money calculator and supplies mock logger
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            MoneyCalc = new MoneyCalculator();
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
