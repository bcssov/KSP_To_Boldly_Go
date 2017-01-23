// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-23-2017
//
// Last Modified By : Mario
// Last Modified On : 01-23-2017
// ***********************************************************************
// <copyright file="IConverter.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace KSP_To_Boldly_Go.Common.Converters.Serializer
{
    /// <summary>
    /// Interface IConverter
    /// </summary>
    public interface IConverter
    {
        #region Methods

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns><c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.</returns>
        bool CanConvert(Type objectType);

        /// <summary>
        /// Froms the serialized string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Object.</returns>
        object FromSerializedString(string value);

        /// <summary>
        /// To the serialized string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        string ToSerializedString(object value);

        #endregion Methods
    }
}