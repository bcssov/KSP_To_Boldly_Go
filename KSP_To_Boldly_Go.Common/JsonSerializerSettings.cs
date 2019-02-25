// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 02-24-2019
//
// Last Modified By : Mario
// Last Modified On : 02-25-2019
// ***********************************************************************
// <copyright file="JsonSerializerSettings.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
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
        /// The handler factory
        /// </summary>
        private IHandlerFactory handlerFactory;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSerializerSettings" /> class.
        /// </summary>
        /// <param name="handlerFactory">The handler factory.</param>
        public JsonSerializerSettings(IHandlerFactory handlerFactory)
        {
            this.handlerFactory = handlerFactory;
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
                Converters = handlerFactory.CreateConverterHandler().CreateJsonConverters().ToList()
            };
        }

        #endregion Methods
    }
}