// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 02-14-2019
//
// Last Modified By : Mario
// Last Modified On : 02-25-2019
// ***********************************************************************
// <copyright file="DIPackage.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using KSP_To_Boldly_Go.Common.Converters.Serializer;
using KSP_To_Boldly_Go.Common.Models;
using KSP_To_Boldly_Go.Common.Serializers;
using KSP_To_Boldly_Go.Common.Types;
using KSP_To_Boldly_Go.Common.Validators;
using KSP_To_Boldly_Go.DependencyInjection;
using SimpleInjector.Packaging;

/// <summary>
/// The Common namespace.
/// </summary>
namespace KSP_To_Boldly_Go.Common
{
    /// <summary>
    /// Class DIPackage.
    /// </summary>
    /// <seealso cref="SimpleInjector.Packaging.IPackage" />
    public class DIPackage : IPackage
    {
        #region Methods

        /// <summary>
        /// Registers the set of services in the specified <paramref name="container" />.
        /// </summary>
        /// <param name="container">The container the set of services is registered into.</param>
        public void RegisterServices(SimpleInjector.Container container)
        {
            #region Converters

            container.Collection.Register(typeof(IConverter<>), typeof(IConverter<>).Assembly);

            #endregion Converters

            #region Models

            container.Collection.Register(typeof(IKopernicusObject), typeof(IKopernicusObject).Assembly);
            container.Collection.Register(typeof(IKopernicusRootObject), typeof(IKopernicusRootObject).Assembly);

            #endregion Models

            #region Types

            container.Collection.Register(typeof(IRangeNumber<>), typeof(IRangeNumber<>).Assembly);
            container.Collection.Register(typeof(IRangeType<>), typeof(IRangeType<>).Assembly);
            container.Collection.Register(typeof(IType), typeof(IType).Assembly);

            #endregion Types

            #region Validators

            container.Collection.Register(typeof(IValidator), typeof(IValidator).Assembly);

            #endregion Validators

            #region Serializers

            container.Register<IKopernicusSerializer, KopernicusSerializer>();

            #endregion Serializers

            #region Handlers

            container.RegisterSingleton<IConverterHandler, ConverterHandler>();
            container.RegisterSingleton<IModelHandler, ModelHandler>();
            container.RegisterSingleton<ITypeHandler, TypeHandler>();

            #endregion Handlers

            #region Program Management

            container.RegisterSingleton<IJsonSerializerSettings, JsonSerializerSettings>();

            #endregion Program Management

            #region Factories

            container.RegisterFactory<IHandlerFactory>();

            #endregion Factories
        }

        #endregion Methods
    }
}