// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-24-2017
//
// Last Modified By : Mario
// Last Modified On : 01-24-2017
// ***********************************************************************
// <copyright file="IRangeType.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace KSP_To_Boldly_Go.Common.Types
{
    /// <summary>
    /// Interface IRangeType
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Types.IType" />
    public interface IRangeType<T> : IType where T : IType
    {
        #region Properties

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        T Max { get; set; }

        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        T Min { get; set; }

        #endregion Properties
    }
}