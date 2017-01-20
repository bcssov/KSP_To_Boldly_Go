// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-20-2017
// ***********************************************************************
// <copyright file="Configuration.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace KSP_To_Boldly_Go
{
    /// <summary>
    /// Class Configuration.
    /// </summary>
    public static class Configuration
    {
        #region Fields

        /// <summary>
        /// The dev mode
        /// </summary>
        public static readonly bool DevMode = Properties.Settings.Default.DeveloperMode;

        #endregion Fields
    }
}