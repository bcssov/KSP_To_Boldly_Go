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
    /// Interface IRange
    /// </summary>
    public interface IType
    {
        #region Methods

        /// <summary>
        /// Parses the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool Parse(string value);

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        string ToString(Random random);

        #endregion Methods
    }
}