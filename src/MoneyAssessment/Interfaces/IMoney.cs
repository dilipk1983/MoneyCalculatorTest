
namespace MoneyAssessment.Interfaces
{
    ///<summary>
    /// An amount of money in a particular currency 
    ///</summary>
    ///
    /// I have made this interface public  
    /// other wise  MoneyCalculator implementation would also needs to be private 
    /// which will make it not to be accessible from external test library 
    /// 
    /// another solution would be to add test classes in the same library 
    /// which would create some more problems later on if project goes big 
    public interface IMoney
    {
        ///<summary>
        /// The amount of money this instance represents 
        ///</summary>
        decimal Amount { get; }

        ///<summary>
        /// The ISO currency code of this instance 
        ///<summary>
        string Currency { get; }

    }
}
