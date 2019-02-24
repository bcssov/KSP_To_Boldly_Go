// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-23-2017
//
// Last Modified By : Mario
// Last Modified On : 02-24-2019
// ***********************************************************************
// <copyright file="RangeConverter.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Globalization;
using KSP_To_Boldly_Go.Common.Converters.Serializer;
using KSP_To_Boldly_Go.Common.Types;

using System;

namespace KSP_To_Boldly_Go.Common.Converters.Object
{
    /// <summary>
    /// Class TypeConverter.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.ComponentModel.StringConverter" />
    public abstract class TypeConverter<T> : StringConverter where T : IType
    {
        #region Methods

        /// <summary>
        /// Gets a value indicating whether this converter can convert an object in the given source type to a string using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="sourceType">A <see cref="T:System.Type" /> that represents the type you wish to convert from.</param>
        /// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) ? true : base.CanConvertFrom(context, sourceType);
        }

        /// <summary>
        /// Returns whether this converter can convert the object to the specified type, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="destinationType">A <see cref="T:System.Type" /> that represents the type you want to convert to.</param>
        /// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string) || destinationType == typeof(T) ? true : base.CanConvertFrom(context, destinationType);
        }

        /// <summary>
        /// Converts the specified value object to a <see cref="T:System.String" /> object.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo" /> to use.</param>
        /// <param name="value">The <see cref="T:System.Object" /> to convert.</param>
        /// <returns>An <see cref="T:System.Object" /> that represents the converted value.</returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value == null)
            {
                return null;
            }
            else if (value is string)
            {
                return ConvertStringToObject(value);
            }
            return base.ConvertFrom(context, culture, value);
        }

        /// <summary>
        /// Converts the given value object to the specified type, using the specified context and culture information.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="culture">A <see cref="T:System.Globalization.CultureInfo" />. If null is passed, the current culture is assumed.</param>
        /// <param name="value">The <see cref="T:System.Object" /> to convert.</param>
        /// <param name="destinationType">The <see cref="T:System.Type" /> to convert the <paramref name="value" /> parameter to.</param>
        /// <returns>An <see cref="T:System.Object" /> that represents the converted value.</returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                if (value == null)
                {
                    return null;
                }
                else if (value is T)
                {
                    return ConvertObjectToString(value);
                }
            }
            else if (destinationType == typeof(T))
            {
                if (value == null)
                {
                    return null;
                }
                else if (value is string)
                {
                    return ConvertStringToObject(value);
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        /// <summary>
        /// Converts the object to string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Object.</returns>
        private object ConvertObjectToString(object value)
        {
            var converter = ConverterManager.GetConverterForType<T>();
            return converter.ToString(value, null);
        }

        /// <summary>
        /// Converts the string to object.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Object.</returns>
        private object ConvertStringToObject(object value)
        {
            var converter = ConverterManager.GetConverterForType<T>();
            return converter.ToObject(value.ToString());
        }

        #endregion Methods
    }
}