using MoneyAssessment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyAssessment.BusinessLogic
{
    public class MoneyCalculator : IMoneyCalculator
    {
        public IMoney Max(IEnumerable<IMoney> monies)
        {           
            if (monies.GroupBy(g => g.Currency.ToUpper()).Skip(1).Any())
            {               
                throw new ArgumentException("All monies are not in the same currency.");
            }
            return monies.Where(m => m.Amount == monies.Max(money => money.Amount)).FirstOrDefault();
        }

        public IEnumerable<IMoney> SumPerCurrency(IEnumerable<IMoney> monies)
        {
            var result = from m in monies
                         group m by m.Currency.ToUpper() into groupped
                         orderby groupped.Key
                         select new Money(
                             groupped.Key,
                             groupped.Sum(m => m.Amount)
                         );
            return result;
        }
    }
}
