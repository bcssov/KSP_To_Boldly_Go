// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-24-2017
//
// Last Modified By : Mario
// Last Modified On : 01-24-2017
// ***********************************************************************
// <copyright file="RangeFloat.cs" company="">
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
    /// Class RangeFloat.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Types.RangeNumber{System.Single}" />
    [TypeConverter(typeof(RangeFloatConverter))]
    public class RangeFloat : RangeNumber<float>
    {
        #region Methods

        /// <summary>
        /// Gets the random in range.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <returns>T.</returns>
        protected override float GetRandomInRange(Random random)
        {
            return Convert.ToSingle(Math.Round(random.NextFloat(Min.GetValueOrDefault(), Max.GetValueOrDefault()), 2));
        }

        /// <summary>
        /// Parses the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Nullable&lt;T&gt;.</returns>
        protected override float? ParseValue(string value)
        {
            return Convert.ToSingle(value);
        }

        /// <summary>
        /// Validates the maximum.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Max value should be greater than Min value</exception>
        protected override void ValidateMax(float? newValue)
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
        protected override void ValidateMin(float? newValue)
        {
            if (Max.HasValue && newValue.GetValueOrDefault() > Max.GetValueOrDefault())
            {
                throw new ArgumentOutOfRangeException("Min value should be lesser than Max value");
            }
        }

        #endregion Methods
    }
}