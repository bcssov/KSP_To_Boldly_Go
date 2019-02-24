// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-24-2017
//
// Last Modified By : Mario
// Last Modified On : 02-24-2019
// ***********************************************************************
// <copyright file="RangeFloatConverter.cs" company="Mario">
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
    /// Class RangeFloatConverter.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Converters.Serializer.TypeConverter{KSP_To_Boldly_Go.Common.Types.RangeFloat}" />
    public class RangeFloatConverter : TypeConverter<RangeFloat>
    {
        #region Properties

        /// <summary>
        /// Gets a value indicating whether this instance can convert json.
        /// </summary>
        /// <value><c>true</c> if this instance can convert json; otherwise, <c>false</c>.</value>
        public override bool CanConvertJson
        {
            get { return this is JsonConverter; }
        }

        #endregion Properties
    }
}