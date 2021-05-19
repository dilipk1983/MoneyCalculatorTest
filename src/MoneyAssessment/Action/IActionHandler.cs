namespace MoneyAssessment
{
    /// <summary>
    /// Action handler interface
    /// </summary>
    public interface IActionHandler
    {
        /// <summary>
        /// function to invoke action handler
        /// </summary>
        /// <param name="param"></param>
        void Invoke(object param);
    }
}
