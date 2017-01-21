// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-20-2017
// ***********************************************************************
// <copyright file="Extensions.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;

/// <summary>
/// The Serializers namespace.
/// </summary>
namespace KSP_To_Boldly_Go_Common.Serializers
{
    /// <summary>
    /// Class Extensions.
    /// </summary>
    public static class Extensions
    {
        #region Methods

        /// <summary>
        /// To the configuration string.
        /// </summary>
        /// <param name="value">The c.</param>
        /// <returns>System.String.</returns>
        public static string ToConfigString(this Color value)
        {
            return string.Format("{0},{1},{2},{3}", Math.Round(Convert.ToDouble(value.R) / 255D, 2).ToString(), Math.Round(Convert.ToDouble(value.G) / 255D, 2).ToString(), Math.Round(Convert.ToDouble(value.B) / 255D, 2).ToString(), Math.Round(Convert.ToDouble(value.A) / 255D, 2).ToString());
        }

        /// <summary>
        /// To the color.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Color.</returns>
        public static Color ToColor(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Color.Empty;
            }
            var values = value.Split(",".ToCharArray(), 4, StringSplitOptions.RemoveEmptyEntries);
            var r = Convert.ToInt32(Convert.ToDouble(values[0]) * 255D);
            var g = Convert.ToInt32(Convert.ToDouble(values[1]) * 255D);
            var b = Convert.ToInt32(Convert.ToDouble(values[2]) * 255D);
            var a = Convert.ToInt32(Convert.ToDouble(values[3]) * 255D);
            return Color.FromArgb(a, r, g, b);
        }

        #endregion Methods
    }
}