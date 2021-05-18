using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyAssessment.Tests
{
    /// <summary>
    /// Mock logger class
    /// </summary>
    public class MockLogger : ILogger
    {
        /// <summary>
        /// Log message as error
        /// </summary>
        /// <param name="message"></param>
        public void Error(string message)
        {

        }

        /// <summary>
        /// Log messages as Information
        /// </summary>
        /// <param name="message"></param>
        public void Info(string message)
        {

        }

        /// <summary>
        /// Log messages as warning
        /// </summary>
        /// <param name="message"></param>
        public void Warning(string message)
        {

        }
    }
}
