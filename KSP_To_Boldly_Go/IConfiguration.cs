// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 02-24-2019
//
// Last Modified By : Mario
// Last Modified On : 02-24-2019
// ***********************************************************************
// <copyright file="IConfiguration.cs" company="Mario">
//     Copyright ©  2017-2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;

namespace KSP_To_Boldly_Go
{
    /// <summary>
    /// Interface IConfiguration
    /// </summary>
    public interface IConfiguration
    {
        #region Properties

        /// <summary>
        /// Gets the application icon.
        /// </summary>
        /// <value>The application icon.</value>
        Icon AppIcon { get; }

        /// <summary>
        /// Gets a value indicating whether [dev mode].
        /// </summary>
        /// <value><c>true</c> if [dev mode]; otherwise, <c>false</c>.</value>
        bool DevMode { get; }

        /// <summary>
        /// Gets the json configuration path.
        /// </summary>
        /// <value>The json configuration path.</value>
        string JsonConfigPath { get; }

        /// <summary>
        /// Gets or sets the theme.
        /// </summary>
        /// <value>The theme.</value>
        Theme Theme { get; set; }

        #endregion Properties
    }
}