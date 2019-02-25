// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 02-24-2019
// ***********************************************************************
// <copyright file="Extensions.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;

/// <summary>
/// The Extensions namespace.
/// </summary>
namespace KSP_To_Boldly_Go.Common.Extensions
{
    /// <summary>
    /// Class EnumerableExtensions.
    /// </summary>
    public static class EnumerableExtensions
    {
        #region Methods

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Int32.</returns>
        public static int GetCount(this IEnumerable value)
        {
            var collection = value as ICollection;
            if (collection != null)
            {
                return collection.Count;
            }
            int count = 0;
            foreach (var val in value)
            {
                count++;
            }
            return count;
        }

        #endregion Methods
    }
}