// ***********************************************************************
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
            return (objectType == typeof(Color));
        }

        /// <summary>
        /// Froms the serialized string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Object.</returns>
        public object FromSerializedString(string value)
        {
            if (value != null)
            {
                return FromStringToColor(value.ToString());
            }
            return null;
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
                return FromSerializedString(value.ToString());
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
            return ToSerializedString(value, true);
        }

        /// <summary>
        /// To the serialized string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="useDecimal">if set to <c>true</c> [use decimal].</param>
        /// <returns>System.String.</returns>
        public string ToSerializedString(object value, bool useDecimal)
        {
            if (value != null)
            {
                return FromColorToString((Color)value, useDecimal);
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
                writer.WriteValue(ToSerializedString(value, false));
            }
        }

        /// <summary>
        /// Froms the color to string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="useDecimal">if set to <c>true</c> [use decimal].</param>
        /// <returns>System.String.</returns>
        private string FromColorToString(Color value, bool useDecimal)
        {
            if (useDecimal)
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
            var values = value.Split(",".ToCharArray(), 4, StringSplitOptions.RemoveEmptyEntries);
            var r = Convert.ToInt32(values[0]);
            var g = Convert.ToInt32(values[1]);
            var b = Convert.ToInt32(values[2]);
            var a = Convert.ToInt32(values[3]);
            return new Color()
            {
                R = r,
                G = g,
                B = b,
                A = a
            };
        }

        #endregion Methods
    }
}