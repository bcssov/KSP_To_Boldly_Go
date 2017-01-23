// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-23-2017
//
// Last Modified By : Mario
// Last Modified On : 01-23-2017
// ***********************************************************************
// <copyright file="IRange.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace KSP_To_Boldly_Go.Common.Types
{
    /// <summary>
    /// Interface IRangeNumber
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Types.IRange" />
    public interface IRangeNumber<T> : IRange where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {
        #region Properties

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        T? Max { get; set; }

        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        T? Min { get; set; }

        #endregion Properties
    }
}