// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 02-14-2019
//
// Last Modified By : Mario
// Last Modified On : 02-14-2019
// ***********************************************************************
// <copyright file="DIPackage.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace KSP_To_Boldly_Go.Common
{
    /// <summary>
    /// Class DIContainer.
    /// </summary>
    /// <seealso cref="SimpleInjector.Packaging.IPackage" />
    public class DIContainer : IPackage
    {
        #region Methods

        /// <summary>
        /// Registers the set of services in the specified <paramref name="container" />.
        /// </summary>
        /// <param name="container">The container the set of services is registered into.</param>
        public void RegisterServices(Container container)
        {
        }

        #endregion Methods
    }
}