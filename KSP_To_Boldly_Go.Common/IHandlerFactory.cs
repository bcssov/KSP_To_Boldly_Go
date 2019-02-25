// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 02-25-2019
//
// Last Modified By : Mario
// Last Modified On : 02-25-2019
// ***********************************************************************
// <copyright file="IHandlerFactory.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using KSP_To_Boldly_Go.Common.Converters.Serializer;
using KSP_To_Boldly_Go.Common.Models;
using KSP_To_Boldly_Go.Common.Types;
using KSP_To_Boldly_Go.Common.Validators;

namespace KSP_To_Boldly_Go.Common
{
    /// <summary>
    /// Interface IHandlerFactory
    /// </summary>
    public interface IHandlerFactory
    {
        #region Methods

        /// <summary>
        /// Creates the converter handler.
        /// </summary>
        /// <returns>IConverterHandler.</returns>
        IConverterHandler CreateConverterHandler();

        /// <summary>
        /// Creates the model handler.
        /// </summary>
        /// <returns>IModelHandler.</returns>
        IModelHandler CreateModelHandler();

        /// <summary>
        /// Creates the type handler.
        /// </summary>
        /// <returns>ITypeHandler.</returns>
        ITypeHandler CreateTypeHandler();

        /// <summary>
        /// Creates the validation handler.
        /// </summary>
        /// <returns>IValidatorHandler.</returns>
        IValidatorHandler CreateValidationHandler();

        #endregion Methods
    }
}