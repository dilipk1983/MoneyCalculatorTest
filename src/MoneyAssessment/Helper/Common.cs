using System;

namespace MoneyAssessment.Helper
{

    /// <summary>
    /// This classs is meant to contain only common functions
    /// </summary>
    public class Common
    {       

        /// <summary>
        /// common function to Print to console 
        /// </summary>
        /// <param name="message"></param>
        public static void Print(string message)
        {
            Console.Write(message);
        }

        /// <summary>
        /// common function to Print line to console 
        /// </summary>
        /// <param name="message"></param>
        public static void PrintLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
