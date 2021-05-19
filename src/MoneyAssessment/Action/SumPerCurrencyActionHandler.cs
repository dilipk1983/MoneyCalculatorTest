using MoneyAssessment.Helper;
using MoneyAssessment.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MoneyAssessment
{
    public class SumPerCurrencyActionHandler : IActionHandler
    {
        #region Fields
        private IMoneyCalculator MoneyCalculator;
        private ILogger Logger;
        #endregion

        #region Constructor
        /// <summary>
        /// default constructor
        /// </summary>
        public SumPerCurrencyActionHandler(IMoneyCalculator moneyCalculator, ILogger logger)
        {
            MoneyCalculator = moneyCalculator;
            Logger = logger;
        }

        #endregion

        #region Methods
        /// <summary>
        /// trigger method to execute actual action 
        /// </summary>
        /// <param name="param"></param>
        public void Invoke(object param)
        {
            var monies = param as IEnumerable<IMoney>;
            var sumations = MoneyCalculator.SumPerCurrency(monies).Select(m => m.Currency + m.Amount);
            var output = $"Sum per currencies: {{ { string.Join(",", sumations) } }}";
            Logger.Info(output);
            Common.Print(output);
        }
        #endregion
    }
}
