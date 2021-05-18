using MoneyAssessment.Interfaces;

namespace MoneyAssessment.BusinessLogic
{
    public class Money: IMoney
    {
        #region Properties
        public decimal Amount { get; private set; }

        public string Currency { get; private set; }
        #endregion

        #region Constructor

        /// <summary>
        /// parameterised constructor 
        /// </summary>
        /// <param name="currency"></param>
        /// <param name="amount"></param>
        public Money(string currency, decimal amount)
        {
            Amount = amount;
            Currency = currency;
        }

        /// <summary>
        /// default constructor to populate defsault values
        /// </summary>
        public Money()
        {

        }
        #endregion
    }
}
