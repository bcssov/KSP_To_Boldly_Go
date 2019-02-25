// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 02-25-2019
//
// Last Modified By : Mario
// Last Modified On : 02-25-2019
// ***********************************************************************
// <copyright file="HandlerFactory.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using KSP_To_Boldly_Go.Common.Converters.Serializer;
using KSP_To_Boldly_Go.Common.Models;
using KSP_To_Boldly_Go.Common.Types;
using KSP_To_Boldly_Go.Common.Validators;

namespace KSP_To_Boldly_Go.Common
{
    /// <summary>
    /// Class HandlerFactory. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Common.IHandlerFactory" />
    public sealed class HandlerFactory : IHandlerFactory
    {
        #region Methods

        /// <summary>
        /// Creates the converter handler.
        /// </summary>
        /// <returns>IConverterHandler.</returns>
        public IConverterHandler CreateConverterHandler() => DependencyInjection.DIContainer.Container.GetInstance<IConverterHandler>();

        /// <summary>
        /// Creates the model handler.
        /// </summary>
        /// <returns>IModelHandler.</returns>
        public IModelHandler CreateModelHandler() => DependencyInjection.DIContainer.Container.GetInstance<IModelHandler>();

        /// <summary>
        /// Creates the type handler.
        /// </summary>
        /// <returns>ITypeHandler.</returns>
        public ITypeHandler CreateTypeHandler() => DependencyInjection.DIContainer.Container.GetInstance<ITypeHandler>();

        /// <summary>
        /// Creates the validation handler.
        /// </summary>
        /// <returns>IValidatorHandler.</returns>
        public IValidatorHandler CreateValidationHandler() => DependencyInjection.DIContainer.Container.GetInstance<IValidatorHandler>();

        #endregion Methods
    }
}