﻿// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-23-2017
// ***********************************************************************
// <copyright file="Initialize.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using KSP_To_Boldly_Go.Common.Converters.Serializer;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace KSP_To_Boldly_Go.Common
{
    /// <summary>
    /// Class Startup.
    /// </summary>
    public static class Startup
    {
        #region Methods

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public static void Initialize()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.None,
                // Don't use camel case, using a bit non standard approach to map classes and properties directly
                ContractResolver = new DefaultContractResolver(),
                Converters = ConverterManager.GetJsonConverters()
            };
        }

        #endregion Methods
    }
}