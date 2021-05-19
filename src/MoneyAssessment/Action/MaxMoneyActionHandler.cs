using MoneyAssessment.Helper;
using MoneyAssessment.Interfaces;
using System.Collections.Generic;

namespace MoneyAssessment
{
    public class MaxMoneyActionHandler : IActionHandler
    {
        #region Fiedls
        private IMoneyCalculator MoneyCalculator;
        private ILogger Logger;
        #endregion

        #region Constructor
        /// <summary>
        /// default constructor        
        /// </summary>
        public MaxMoneyActionHandler(IMoneyCalculator moneyCalculator, ILogger logger)
        {
            MoneyCalculator = moneyCalculator;
            Logger = logger;
        }
        #endregion

        #region Method
        /// <summary>
        /// call money calculator max function to find max money 
        /// </summary>
        /// <param name="param">monies</param>
        public void Invoke(object param)
        {
            var monies = param as IEnumerable<IMoney>;

            var max = MoneyCalculator.Max(monies);
            var output = $"Max: {{ {max.Currency}{max.Amount} }}";
            Logger.Info(output);
            Common.Print(output);
        }
        #endregion
    }
}
