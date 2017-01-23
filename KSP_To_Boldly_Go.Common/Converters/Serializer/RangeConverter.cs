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
    /// Class RangeConverter.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Newtonsoft.Json.JsonConverter" />
    /// <seealso cref="KSP_To_Boldly_Go.Common.Converters.Serializer.IConverter" />
    public abstract class RangeConverter<T> : JsonConverter, IConverter where T : IRange
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
                return FromStringToObject(value.ToString());
            }
            return default(T);
        }

        /// <summary>
        /// To the serialized string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public string ToSerializedString(object value)
        {
            return ToSerializedString(value, null);
        }

        /// <summary>
        /// To the serialized string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="random">The random.</param>
        /// <returns>System.String.</returns>
        public string ToSerializedString(object value, Random random)
        {
            if (value != null)
            {
                return FromObjectToString((T)value, random);
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
                writer.WriteValue(ToSerializedString(value));
            }
        }

        /// <summary>
        /// Froms the object to string.
        /// </summary>
        /// <typeparam name="TRandom">The type of the t random.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="random">The random.</param>
        /// <returns>System.String.</returns>
        private string FromObjectToString<TRandom>(TRandom value, Random random) where TRandom : T
        {
            // If random is available this means that we are called from kopernicus serializer
            if (random != null)
            {
                return value.ToString(random);
            }
            else
            {
                return value.ToString();
            }
        }

        /// <summary>
        /// Froms the string to object.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>T.</returns>
        private T FromStringToObject(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return default(T);
            }
            var instance = Activator.CreateInstance<T>();
            instance.SetValues(value);
            return instance;
        }

        #endregion Methods
    }
}