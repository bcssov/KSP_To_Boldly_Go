// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 02-23-2019
// ***********************************************************************
// <copyright file="Configuration.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using System.Windows.Forms;

namespace KSP_To_Boldly_Go
{
    /// <summary>
    /// Class Configuration.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.IConfiguration" />
    public class Configuration : IConfiguration
    {
        #region Properties

        /// <summary>
        /// Gets a value indicating whether [dev mode].
        /// </summary>
        /// <value><c>true</c> if [dev mode]; otherwise, <c>false</c>.</value>
        public bool DevMode { get; } = Properties.Settings.Default.DeveloperMode;

        /// <summary>
        /// Gets the json configuration path.
        /// </summary>
        /// <value>The json configuration path.</value>
        public string JsonConfigPath { get; } = Path.Combine(Application.StartupPath, Constants.ConfigResources);

        #endregion Properties

        #region Classes

        /// <summary>
        /// Class Constants.
        /// </summary>
        private class Constants
        {
            #region Fields

            /// <summary>
            /// The configuration resources
            /// </summary>
            public const string ConfigResources = "ConfigResources";

            #endregion Fields
        }

        #endregion Classes
    }
}