using System.Collections.Generic;

namespace MoneyAssessment.Interfaces
{
    ///<summary>
    /// Some fun things to do with money 
    /// <summary>
    public interface IMoneyCalculator
    {
        ///<summary>
        /// Find the largest amount of Money.
        /// </summary>
        /// <returns> The <see cref="IMoney"/> instance having the largest amount </return>
        ///<exception cref = "Argumant Exception"> All monies are not in the same currency. </exception>
        /// <example>{GBP10, GBP20, GBP50} => {GBP50}</example> 
        /// <example>{GBP10, GBP20, EUR50} => Exception <example> 
        IMoney Max(IEnumerable<IMoney> monies);


        /// <summary>
        /// Return one <see cref="IMoney"/> per currency with the sum of all monies of the same currency
        ///</summary>
        ///<example> {GBP10, GBP20, GBP50} => {GBP80}</example>
        ///<example> {GBP10, GBP20, EUR50} => {GBP30, EUR50}</example>
        ///<example> {GBP10, USD20, EUR50} => {GBP10, USD20, EUR50}</example>
        IEnumerable<IMoney> SumPerCurrency(IEnumerable<IMoney> monies);

    }

}
