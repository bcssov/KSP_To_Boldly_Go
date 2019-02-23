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
using KSP_To_Boldly_Go.Common.Converters.Serializer;
using KSP_To_Boldly_Go.Common.Models;
using KSP_To_Boldly_Go.Common.Types;
using KSP_To_Boldly_Go.Common.Validators;
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
        public void RegisterServices(SimpleInjector.Container container)
        {
            container.Collection.Register(typeof(IConverter<>));
            container.Collection.Register(typeof(IKopernicusObject));
            container.Collection.Register(typeof(IKopernicusRootObject));
            container.Collection.Register(typeof(IRangeNumber<>));
            container.Collection.Register(typeof(IRangeType<>));
            container.Collection.Register(typeof(IType));
            container.Collection.Register(typeof(IValidator));
        }

        #endregion Methods
    }
}