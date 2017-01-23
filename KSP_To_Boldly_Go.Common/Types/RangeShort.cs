// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-24-2017
//
// Last Modified By : Mario
// Last Modified On : 01-24-2017
// ***********************************************************************
// <copyright file="RangeShort.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using KSP_To_Boldly_Go.Common.Converters.Object;
using KSP_To_Boldly_Go.Common.Extensions;
using System;
using System.ComponentModel;

namespace KSP_To_Boldly_Go.Common.Types
{
    /// <summary>
    /// Class RangeShort.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Types.RangeNumber{System.Int16}" />
    [TypeConverter(typeof(RangeShortConverter))]
    public class RangeShort : RangeNumber<short>
    {
        #region Methods

        /// <summary>
        /// Gets the random in range.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <returns>T.</returns>
        protected override short GetRandomInRange(Random random)
        {
            return random.NextShort(Min.GetValueOrDefault(), Max.GetValueOrDefault());
        }

        /// <summary>
        /// Parses the maximum.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Nullable&lt;T&gt;.</returns>
        protected override short? ParseMax(string value)
        {
            return Convert.ToInt16(value);
        }

        /// <summary>
        /// Parses the minimum.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Nullable&lt;T&gt;.</returns>
        protected override short? ParseMin(string value)
        {
            return Convert.ToInt16(value);
        }

        /// <summary>
        /// Validates the maximum.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Max value should be greater than Min value</exception>
        protected override void ValidateMax(short? newValue)
        {
            if (newValue.GetValueOrDefault() < Min.GetValueOrDefault())
            {
                throw new ArgumentOutOfRangeException("Max value should be greater than Min value");
            }
        }

        /// <summary>
        /// Validates the minimum.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Min value should be lesser than Max value</exception>
        protected override void ValidateMin(short? newValue)
        {
            if (Max.HasValue && newValue.GetValueOrDefault() > Max.GetValueOrDefault())
            {
                throw new ArgumentOutOfRangeException("Min value should be lesser than Max value");
            }
        }

        #endregion Methods
    }
}