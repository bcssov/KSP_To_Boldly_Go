// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-23-2017
//
// Last Modified By : Mario
// Last Modified On : 01-23-2017
// ***********************************************************************
// <copyright file="ConverterManager.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace KSP_To_Boldly_Go.Common.Converters.Serializer
{
    /// <summary>
    /// Class ConverterManager.
    /// </summary>
    public static class ConverterManager
    {
        #region Fields

        /// <summary>
        /// The converters
        /// </summary>
        private static List<IConverter> converters = null;

        /// <summary>
        /// The json converters
        /// </summary>
        private static List<JsonConverter> jsonConverters = null;

        #endregion Fields

        #region Methods

        /// <summary>
        /// Gets the type of the converter for.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>IConverter.</returns>
        public static IConverter GetConverterForType(Type type)
        {
            var converters = GetConverters();
            if (converters != null)
            {
                // There can be only one :)
                return converters.SingleOrDefault(p => p.CanConvert(type));
            }
            return null;
        }

        /// <summary>
        /// Gets the converters.
        /// </summary>
        /// <returns>List&lt;IConverter&gt;.</returns>
        public static List<IConverter> GetConverters()
        {
            if (converters == null)
            {
                List<IConverter> result = new List<IConverter>();
                var objects = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IConverter))).ToList();
                foreach (var item in objects)
                {
                    result.Add((IConverter)Activator.CreateInstance(item));
                }
                converters = result;
            }
            return converters;
        }

        /// <summary>
        /// Gets the json converters.
        /// </summary>
        /// <returns>List&lt;JsonConverter&gt;.</returns>
        public static List<JsonConverter> GetJsonConverters()
        {
            if (jsonConverters == null)
            {
                var converters = GetConverters();
                if (converters != null && converters.Count > 0)
                {
                    List<JsonConverter> result = new List<JsonConverter>();
                    foreach (var item in converters)
                    {
                        if (typeof(JsonConverter).IsAssignableFrom(item.GetType()))
                        {
                            result.Add((JsonConverter)item);
                        }
                    }
                    jsonConverters = result;
                }
            }
            return jsonConverters;
        }

        #endregion Methods
    }
}