// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 01-21-2017
//
// Last Modified By : Mario
// Last Modified On : 02-23-2019
// ***********************************************************************
// <copyright file="Logger.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using NLog;

namespace KSP_To_Boldly_Go
{
    /// <summary>
    /// Class Logger.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.ILogger" />
    public class Logger : ILogger
    {
        #region Fields

        /// <summary>
        /// The log
        /// </summary>
        private static NLog.Logger log = LogManager.GetCurrentClassLogger();

        #endregion Fields

        #region Methods

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public void Error(Exception ex)
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
        public void Info(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                log.Info(message);
            }
        }

        #endregion Methods
    }
}