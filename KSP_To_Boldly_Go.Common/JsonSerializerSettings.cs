// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 02-24-2019
//
// Last Modified By : Mario
// Last Modified On : 02-24-2019
// ***********************************************************************
// <copyright file="JsonSerializerSettings.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using KSP_To_Boldly_Go.Common.Converters.Serializer;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace KSP_To_Boldly_Go.Common
{
    /// <summary>
    /// Class JsonSerializerSettings.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Common.IJsonSerializerSettings" />
    public class JsonSerializerSettings : IJsonSerializerSettings
    {
        #region Fields

        /// <summary>
        /// The converter handler
        /// </summary>
        private IConverterHandler converterHandler;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSerializerSettings" /> class.
        /// </summary>
        /// <param name="converterHandler">The converter handler.</param>
        public JsonSerializerSettings(IConverterHandler converterHandler)
        {
            this.converterHandler = converterHandler;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <returns>Newtonsoft.Json.JsonSerializerSettings.</returns>
        public Newtonsoft.Json.JsonSerializerSettings GetSettings()
        {
            return new Newtonsoft.Json.JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.None,
                // Don't use camel case, using a bit non standard approach to map classes and properties directly
                ContractResolver = new DefaultContractResolver(),
                Converters = converterHandler.CreateJsonConverters().ToList()
            };
        }

        #endregion Methods
    }
}