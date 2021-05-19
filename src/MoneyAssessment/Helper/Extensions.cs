using MoneyAssessment.Interfaces;
using System;

namespace MoneyAssessment.Helper
{
    public static class Extensions
    {
        /// <summary>
        /// Extension m ethod to get proper action handler against key stroke
        /// </summary>
        /// <param name="keyInfo"></param>
        /// <returns></returns>
        public static IActionHandler GetAction(this ConsoleKeyInfo keyInfo, IMoneyCalculator moneyCalculator, ILogger logger)
        {
            switch (keyInfo.KeyChar)
            {
                case '1':
                    return new MaxMoneyActionHandler(moneyCalculator, logger);

                case '2':
                    return new SumPerCurrencyActionHandler(moneyCalculator, logger);

                default:
                    throw new NotImplementedException("Invalid Action");

            }
        }
    }
}
