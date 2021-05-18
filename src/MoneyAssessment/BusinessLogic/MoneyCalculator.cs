using MoneyAssessment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyAssessment.BusinessLogic
{
    public class MoneyCalculator : IMoneyCalculator
    {
        #region Fields
        private ILogger logger;

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public MoneyCalculator() :
            this(Logger.Instance)
        {
            
        }

        /// <summary>
        ///  Parameterized constructor
        /// </summary>
        public MoneyCalculator(ILogger _logger)
        {
            logger = _logger;
        }

        #endregion

        #region Methods
        /// <summary>
        ///  Method to find maximum money among list of Monies
        ///  </summary>
        /// <param name="monies"></param>
        /// <returns> return max money against multiple input monies 
        /// if the currency of input money entity is different then it should through Argument Exception
        /// </returns>       
        public IMoney Max(IEnumerable<IMoney> monies)
        {
            logger.Info("Input monies Count >> " + monies.Count());
            if (monies.GroupBy(g => g.Currency.ToUpper()).Skip(1).Any())
            {
                logger.Error("all monies are not of same currencies (inpiut currencies ): " + string.Join(",", monies.Select(m => m.Currency).Distinct()));
                throw new ArgumentException("All monies are not in the same currency.");
            }
            return monies.Where(m => m.Amount == monies.Max(money => money.Amount)).FirstOrDefault();
        }

        /// <summary>
        /// This method will return sum of the mones on basis of currency group  
        /// </summary>
        /// <param name="monies"></param>
        /// <returns>Sum per currency in the input monies </returns>
        public IEnumerable<IMoney> SumPerCurrency(IEnumerable<IMoney> monies)
        {
            logger.Info("Input monies Count >> " + monies.Count());
            var result = from m in monies
                         group m by m.Currency.ToUpper() into groupped
                         orderby groupped.Key
                         select new Money(
                             groupped.Key,
                             groupped.Sum(m => m.Amount)
                         );
            return result;
        }

        #endregion
    }
}
