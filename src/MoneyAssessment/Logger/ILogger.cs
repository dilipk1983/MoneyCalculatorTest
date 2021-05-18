using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyAssessment
{

    public interface ILogger
    {
        /// <summary>
        /// Log message as information
        /// </summary>
        /// <param name="message"></param>
        void Info(string message);

        /// <summary>
        /// log message as Error
        /// </summary>
        /// <param name="message"></param>
        void Error(string message);

        /// <summary>
        /// Log message as Warning
        /// </summary>
        /// <param name="message"></param>
        void Warning(string message);
    }

}
