// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-23-2017
//
// Last Modified By : Mario
// Last Modified On : 01-23-2017
// ***********************************************************************
// <copyright file="RangeDouble.cs" company="">
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
    /// Class RangeDouble.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Types.RangeNumber{System.Double}" />
    [TypeConverter(typeof(RangeDoubleConverter))]
    public class RangeDouble : RangeNumber<double>
    {
        #region Methods

        /// <summary>
        /// Gets the random in range.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <returns>T.</returns>
        protected override double GetRandomInRange(Random random)
        {
            return random.NextDouble(Min.GetValueOrDefault(), Max.GetValueOrDefault());
        }

        /// <summary>
        /// Parses the maximum.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Nullable&lt;T&gt;.</returns>
        protected override double? ParseMax(string value)
        {
            return Convert.ToDouble(value);
        }

        /// <summary>
        /// Parses the minimum.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Nullable&lt;T&gt;.</returns>
        protected override double? ParseMin(string value)
        {
            return Convert.ToDouble(value);
        }

        /// <summary>
        /// Validates the maximum.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Max value should be greater than Min value</exception>
        protected override void ValidateMax(double? newValue)
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
        protected override void ValidateMin(double? newValue)
        {
            if (Max.HasValue && newValue.GetValueOrDefault() > Max.GetValueOrDefault())
            {
                throw new ArgumentOutOfRangeException("Min value should be lesser than Max value");
            }
        }

        #endregion Methods
    }
}