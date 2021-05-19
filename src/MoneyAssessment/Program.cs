using MoneyAssessment.BusinessLogic;
using MoneyAssessment.Helper;
using MoneyAssessment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyAssessment
{
    class Program
    {
        #region Fields
        private static ILogger logger = Logger.Instance;
        private static IMoneyCalculator moneyCalculator = new MoneyCalculator();
        #endregion

        static void Main(string[] args)
        {
            //Banner
            Common.PrintLine("**********************************************************************");
            Common.PrintLine("***********************Money Calculator*******************************");
            Common.PrintLine("**********************************************************************");

            //Get number of monies  to be entered from user
            Common.Print("Enter number of currencies to add = ");
            int n = Convert.ToInt32(Console.ReadLine());
            logger.Info("Number of currencies to add :" + n);

                     
            Common.PrintLine("Enter currency and amount seperated by space (e.g. GBP 10)");
            var monies = new List<IMoney>();
            for (int i = 0; i < n; i++)
            {
                var valid = false;
                while (!valid)
                {
                    //Get Money from user
                    var input = Console.ReadLine();
                    logger.Info(input);

                    //Check if input contains string or else raise alert to user
                    if (!input.Trim().Contains(' '))
                    {
                        valid = false;
                        Common.PrintLine("ALERT: Invalid data entered, Please enter data in correct format (eg GBP 10)");
                        continue;
                    }

                    valid = true;
                    var splitString = input.Split(' ');
                    monies.Add(new Money(splitString[0], Convert.ToInt32(splitString[1])));
                }
            }

            StartInteractiveSession(monies);
        }

        /// <summary>
        /// This method is to perform some actions on input monies
        /// this will print available actions and ask user to selected any one at a time
        /// </summary>
        /// <param name="monies"></param>
        private static void StartInteractiveSession(IEnumerable<IMoney> monies)
        {
            ConsoleKeyInfo keyInfo;
            do
            {
                Common.Print(Environment.NewLine);
                Common.PrintLine("Select action to continue: ");
                Common.PrintLine("1. Find Max");
                Common.PrintLine("2. Find Sum Per Currency");
                Common.PrintLine("3. Exit");
                Common.Print(Environment.NewLine);

                Common.Print("Selection : ");
              
                keyInfo = Console.ReadKey();

                logger.Info("Selected Action : " + keyInfo.KeyChar);

                Common.Print(Environment.NewLine);
                 HandlerUserSelection(keyInfo, monies);
            }
            while (keyInfo.KeyChar != '3');
        }

        /// <summary>
        /// this method will execute the selected action
        /// </summary>
        /// <param name="keyInfo"></param>
        /// <param name="monies"></param>
        private static void HandlerUserSelection(ConsoleKeyInfo keyInfo, IEnumerable<IMoney> monies)
        {
            try
            {
                // TODO : Introduce any DI framework, 
                // Inject dependencies manully 
                var handler = keyInfo.GetAction(moneyCalculator, logger); 
                handler.Invoke(monies);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                Common.Print(ex.Message);
            }

        }
    }
}
