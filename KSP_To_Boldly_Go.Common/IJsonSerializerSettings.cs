// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 02-24-2019
//
// Last Modified By : Mario
// Last Modified On : 02-24-2019
// ***********************************************************************
// <copyright file="IJsonSerializerSettings.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace KSP_To_Boldly_Go.Common
{
    /// <summary>
    /// Interface IJsonSerializerSettings
    /// </summary>
    public interface IJsonSerializerSettings
    {
        #region Methods

        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <returns>Newtonsoft.Json.JsonSerializerSettings.</returns>
        Newtonsoft.Json.JsonSerializerSettings GetSettings();

        #endregion Methods
    }
}