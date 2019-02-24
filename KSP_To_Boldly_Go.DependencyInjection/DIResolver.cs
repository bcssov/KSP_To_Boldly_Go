// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.DIResolver
// Author           : Mario
// Created          : 02-23-2019
//
// Last Modified By : Mario
// Last Modified On : 02-23-2019
// ***********************************************************************
// <copyright file="DIResolver.cs" company="Mario">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

/// <summary>
/// The DependencyInjection namespace.
/// </summary>
namespace KSP_To_Boldly_Go.DependencyInjection
{
    /// <summary>
    /// Class DIResolver.
    /// </summary>
    public static class DIResolver
    {
        #region Methods

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T.</returns>
        /// <exception cref="NullReferenceException">Container is null.</exception>
        public static T Get<T>() where T : class
        {
            if (DIContainer.Container == null)
            {
                throw new NullReferenceException("Container is null.");
            }
            return DIContainer.Container.GetInstance<T>();
        }

        #endregion Methods
    }
}