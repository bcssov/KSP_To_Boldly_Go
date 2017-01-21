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
using System.IO;
using System.Windows.Forms;

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
        private static readonly bool _devMode = Properties.Settings.Default.DeveloperMode;

        /// <summary>
        /// The json configuration path
        /// </summary>
        private static readonly string _jsonConfigPath = Path.Combine(Application.StartupPath, "ConfigResources");

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets a value indicating whether [dev mode].
        /// </summary>
        /// <value><c>true</c> if [dev mode]; otherwise, <c>false</c>.</value>
        public static bool DevMode
        {
            get
            {
                return _devMode;
            }
        }

        /// <summary>
        /// Gets the json configuration path.
        /// </summary>
        /// <value>The json configuration path.</value>
        public static string JsonConfigPath
        {
            get
            {
                return _jsonConfigPath;
            }
        }

        #endregion Properties
    }
}