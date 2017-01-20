// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go_Common
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-20-2017
// ***********************************************************************
// <copyright file="KopernicusHeader.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace KSP_To_Boldly_Go_Common
{
    /// <summary>
    /// Class KopernicusHeader.
    /// </summary>
    public class KopernicusHeader
    {
        #region Fields

        /// <summary>
        /// The header
        /// </summary>
        private string _value;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KopernicusHeader" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public KopernicusHeader(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                _value = value;
            }
            else
            {
                _value = string.Empty;
            }
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String" /> to <see cref="KopernicusHeader" />.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator KopernicusHeader(string value)
        {
            return new KopernicusHeader(value);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="KopernicusHeader" /> to <see cref="System.String" />.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator string(KopernicusHeader value)
        {
            return value != null ? value.ToString() : string.Empty;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return _value;
        }

        #endregion Methods
    }
}