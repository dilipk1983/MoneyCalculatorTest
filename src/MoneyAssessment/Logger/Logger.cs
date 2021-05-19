using log4net;
using System;

namespace MoneyAssessment
{
    public class Logger : ILogger
    {
        #region Field
        private ILog logger;
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        private Logger()
        {
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));
            this.logger = LogManager.GetLogger(typeof(Logger));
        }
        #endregion


        #region static fields
        /// <summary>
        /// lazy loading of the instance
        /// </summary>
        private static readonly Lazy<Logger> lazy = new Lazy<Logger>(() => new Logger());

        /// <summary>
        /// Instance property
        /// </summary>
        public static ILogger Instance
        {
            get
            {
                return lazy.Value;
            }
        }
        #endregion

        #region Methods

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Warning(string message)
        {
            logger.Warn(message);
        }

        #endregion
    }
}
