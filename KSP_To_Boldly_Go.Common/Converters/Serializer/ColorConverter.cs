﻿// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-23-2017
// ***********************************************************************
// <copyright file="ColorConverter.cs" company="">
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
    /// Class ColorConverter.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Converters.Serializer.IConverter" />
    /// <seealso cref="Newtonsoft.Json.JsonConverter" />
    public class ColorConverter : JsonConverter, IConverter
    {
        #region Methods

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns><c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            var result = objectType == typeof(Color);
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
                return FromStringToColor(value.ToString());
            }
            return new Color();
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
                return FromColorToString((Color)value, random);
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
        /// Froms the color to string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="random">The random.</param>
        /// <returns>System.String.</returns>
        private string FromColorToString(Color value, Random random)
        {
            // If random is available this means that we are called from kopernicus serializer
            if (random != null)
            {
                return string.Format("{0},{1},{2},{3}",
                Math.Round(Convert.ToDouble(value.R.GetValueOrDefault()) / 255D, 2).ToString(),
                Math.Round(Convert.ToDouble(value.G.GetValueOrDefault()) / 255D, 2).ToString(),
                Math.Round(Convert.ToDouble(value.B.GetValueOrDefault()) / 255D, 2).ToString(),
                Math.Round(Convert.ToDouble(value.A.GetValueOrDefault()) / 255D, 2).ToString());
            }
            else
            {
                return value.ToString();
            }
        }

        /// <summary>
        /// Froms the color of the string to.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Color.</returns>
        private Color FromStringToColor(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            return new Color(value);
        }

        #endregion Methods
    }
}