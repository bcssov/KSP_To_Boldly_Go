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
using System.Drawing;

namespace KSP_To_Boldly_Go_Common.Utlities
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
        /// <param name="color">The c.</param>
        /// <returns>System.String.</returns>
        public static string ToConfigString(this Color color)
        {
            return string.Format("{0},{1},{2},{3}", Math.Round(Convert.ToDouble(color.R) / 255D, 2).ToString(), Math.Round(Convert.ToDouble(color.G) / 255D, 2).ToString(), Math.Round(Convert.ToDouble(color.B) / 255D, 2).ToString(), Math.Round(Convert.ToDouble(color.A) / 255D, 2).ToString());
        }

        #endregion Methods
    }
}