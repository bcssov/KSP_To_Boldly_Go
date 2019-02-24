// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 02-24-2019
//
// Last Modified By : Mario
// Last Modified On : 02-24-2019
// ***********************************************************************
// <copyright file="IConverterHandler.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using KSP_To_Boldly_Go.Common.Types;
using Newtonsoft.Json;

namespace KSP_To_Boldly_Go.Common.Converters.Serializer
{
    /// <summary>
    /// Interface IConverterHandler
    /// </summary>
    public interface IConverterHandler
    {
        #region Methods

        /// <summary>
        /// Creates the converter.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>IConverter&lt;IType&gt;.</returns>
        IConverter<IType> CreateConverter(Type type);

        /// <summary>
        /// Creates the converter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>IConverter&lt;T&gt;.</returns>
        IConverter<T> CreateConverter<T>() where T : IType;

        /// <summary>
        /// Creates the json converters.
        /// </summary>
        /// <returns>IEnumerable&lt;JsonConverter&gt;.</returns>
        IEnumerable<JsonConverter> CreateJsonConverters();

        #endregion Methods
    }
}