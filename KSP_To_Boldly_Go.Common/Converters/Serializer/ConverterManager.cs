// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-23-2017
//
// Last Modified By : Mario
// Last Modified On : 01-24-2017
// ***********************************************************************
// <copyright file="ConverterManager.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using KSP_To_Boldly_Go.Common.Types;
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
        private static List<IConverter<IType>> converters = null;

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
        /// <returns>IConverter&lt;IType&gt;.</returns>
        public static IConverter<IType> GetConverterForType(Type type)
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
        /// Gets the type of the converter for.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>IConverter&lt;IType&gt;.</returns>
        public static IConverter<T> GetConverterForType<T>() where T : IType
        {
            return (IConverter<T>)GetConverterForType(typeof(T));
        }

        /// <summary>
        /// Gets the converters.
        /// </summary>
        /// <returns>List&lt;IConverter&lt;IType&gt;&gt;.</returns>
        public static List<IConverter<IType>> GetConverters()
        {
            if (converters == null)
            {
                List<IConverter<IType>> result = new List<IConverter<IType>>();
                var objects = Assembly.GetExecutingAssembly().GetTypes().Where(t => !t.IsAbstract && t.GetInterfaces().ToList().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IConverter<>))).ToList();
                foreach (var item in objects)
                {
                    result.Add((IConverter<IType>)Activator.CreateInstance(item));
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