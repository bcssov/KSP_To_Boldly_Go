// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 01-21-2017
//
// Last Modified By : Mario
// Last Modified On : 02-14-2019
// ***********************************************************************
// <copyright file="Logger.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using NLog;

namespace KSP_To_Boldly_Go
{
    /// <summary>
    /// Class Log.
    /// </summary>
    public class Log
    {
        #region Fields

        /// <summary>
        /// The log
        /// </summary>
        private static Logger log = LogManager.GetCurrentClassLogger();

        #endregion Fields

        #region Methods

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public static void Error(Exception ex)
        {
            if (ex != null)
            {
                log.Error(ex);
            }
        }

        /// <summary>
        /// Logs the information.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void Info(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                log.Info(message);
            }
        }

        #endregion Methods
    }
}