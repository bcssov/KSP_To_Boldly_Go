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
namespace KSP_To_Boldly_Go
{
    /// <summary>
    /// Interface IConfiguration
    /// </summary>
    public interface IConfiguration
    {
        #region Properties

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

        #endregion Properties
    }
}