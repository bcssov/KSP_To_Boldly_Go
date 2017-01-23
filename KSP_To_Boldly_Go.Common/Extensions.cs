// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-22-2017
// ***********************************************************************
// <copyright file="Extensions.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;

/// <summary>
/// The Serializers namespace.
/// </summary>
namespace KSP_To_Boldly_Go.Common
{
    /// <summary>
    /// Class Extensions.
    /// </summary>
    public static class Extensions
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