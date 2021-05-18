using MoneyAssessment.BusinessLogic;
using MoneyAssessment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyAssessment.Tests
{
    public class BigDataHelper
    {
        //Sample big data currencies
        private static string[] Currencies = new string[]
        {
            "GBP", "USD", "INR", "NOK", "EUR" ,"AUD", "ILS", "ZAR", "SBD", "TUV"
        };

        /// <summary>
        /// This method will generate [count] number of monies 
        /// Currencies will be picked from Curriencies collection and Amount would be any randome number between 0 - 1000
        /// </summary>
        /// <param name="count">number of monies to be generated (Max supported value  : 999999999)</param>
        /// <returns></returns>
        public static IEnumerable<IMoney> GetMonies(int count)
        {

            var random = new Random();
            return Enumerable.Range(0, count).Select(x => new Money(Currencies[random.Next(0, 10)], random.Next(0, 1000)));

        }
    }
}
