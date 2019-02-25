// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 02-24-2019
//
// Last Modified By : Mario
// Last Modified On : 02-24-2019
// ***********************************************************************
// <copyright file="ConverterHandler.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using KSP_To_Boldly_Go.Common.Types;
using Newtonsoft.Json;

namespace KSP_To_Boldly_Go.Common.Converters.Serializer
{
    /// <summary>
    /// Class ConverterHandler.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Converters.Serializer.IConverterHandler" />
    public class ConverterHandler : IConverterHandler
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ConverterHandler" /> class.
        /// </summary>
        /// <param name="converters">The converters.</param>
        public ConverterHandler(IEnumerable<IConverter<IType>> converters)
        {
            Converters = converters;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the converters.
        /// </summary>
        /// <value>The converters.</value>
        protected IEnumerable<IConverter<IType>> Converters { get; private set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Creates the converter.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>IConverter&lt;IType&gt;.</returns>
        public IConverter<IType> CreateConverter(Type type)
        {
            if (Converters?.Count() > 0)
            {
                return Converters.SingleOrDefault(p => p.CanConvert(type));
            }
            return null;
        }

        /// <summary>
        /// Creates the converter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>IConverter&lt;T&gt;.</returns>
        public IConverter<T> CreateConverter<T>() where T : IType
        {
            return (IConverter<T>)CreateConverter(typeof(T));
        }

        /// <summary>
        /// Creates the json converters.
        /// </summary>
        /// <returns>IEnumerable&lt;JsonConverter&gt;.</returns>
        public IEnumerable<JsonConverter> CreateJsonConverters()
        {
            return Converters.Where(p => p.CanConvertJson).Select(p => (JsonConverter)p);
        }

        #endregion Methods
    }
}