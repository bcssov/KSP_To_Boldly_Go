// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 02-24-2019
//
// Last Modified By : Mario
// Last Modified On : 02-24-2019
// ***********************************************************************
// <copyright file="ILogger.cs" company="Mario">
//     Copyright ©  2017-2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace KSP_To_Boldly_Go
{
    /// <summary>
    /// Interface ILogger
    /// </summary>
    public interface ILogger
    {
        #region Methods

        /// <summary>
        /// Errors the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        void Error(Exception ex);

        /// <summary>
        /// Informations the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Info(string message);

        #endregion Methods
    }
}