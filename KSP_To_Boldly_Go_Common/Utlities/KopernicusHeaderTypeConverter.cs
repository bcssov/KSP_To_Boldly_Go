// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go_Common
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-20-2017
// ***********************************************************************
// <copyright file="KopernicusHeaderTypeConverter.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Globalization;

namespace KSP_To_Boldly_Go_Common.Utlities
{
    /// <summary>
    /// Class KopernicusHeaderTypeConverter.
    /// </summary>
    /// <seealso cref="System.ComponentModel.StringConverter" />
    public class KopernicusHeaderTypeConverter : StringConverter
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
            if (sourceType == typeof(string) || sourceType == typeof(KopernicusHeader))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        /// <summary>
        /// Returns whether this converter can convert the object to the specified type, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="destinationType">A <see cref="T:System.Type" /> that represents the type you want to convert to.</param>
        /// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string) || destinationType == typeof(KopernicusHeader))
            {
                return true;
            }
            return base.CanConvertFrom(context, destinationType);
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
                return new KopernicusHeader();
            }
            else if (value is KopernicusHeader)
            {
                return (KopernicusHeader)value;
            }
            else if (value is string)
            {
                return new KopernicusHeader(value.ToString());
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
                    return string.Empty;
                }
                else if (value is KopernicusHeader)
                {
                    return value.ToString();
                }
                else if (value is string)
                {
                    return value.ToString();
                }
            }
            else if (destinationType == typeof(KopernicusHeader))
            {
                if (value == null)
                {
                    return new KopernicusHeader();
                }
                else if (value is KopernicusHeader)
                {
                    return (KopernicusHeader)value;
                }
                else if (value is string)
                {
                    return new KopernicusHeader(value.ToString());
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        #endregion Methods
    }
}