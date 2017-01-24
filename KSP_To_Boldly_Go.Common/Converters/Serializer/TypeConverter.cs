// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-23-2017
//
// Last Modified By : Mario
// Last Modified On : 01-23-2017
// ***********************************************************************
// <copyright file="RangeConverter.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using KSP_To_Boldly_Go.Common.Types;
using Newtonsoft.Json;
using System;

namespace KSP_To_Boldly_Go.Common.Converters.Serializer
{
    /// <summary>
    /// Class TypeConverter.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Newtonsoft.Json.JsonConverter" />
    /// <seealso cref="KSP_To_Boldly_Go.Common.Converters.Serializer.IConverter" />
    public abstract class TypeConverter<T> : JsonConverter, IConverter<T> where T : IType
    {
        #region Methods

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns><c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            var result = objectType == typeof(T);
            return result;
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = reader.Value;
            if (value != null)
            {
                return ToObject(value.ToString());
            }
            return default(T);
        }

        /// <summary>
        /// To the object.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>T.</returns>
        public T ToObject(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return default(T);
            }
            var instance = Activator.CreateInstance<T>();
            if (instance.Parse(value))
            {
                return instance;
            }
            return default(T);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="random">The random.</param>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public string ToString(object value, Random random)
        {
            if (value != null)
            {
                return ((T)value).ToString(random);
            }
            return string.Empty;
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value != null)
            {
                writer.WriteValue(ToString(value, null));
            }
        }

        #endregion Methods
    }
}