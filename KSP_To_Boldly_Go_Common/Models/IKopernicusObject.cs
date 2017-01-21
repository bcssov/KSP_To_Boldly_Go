// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go_Common
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-21-2017
// ***********************************************************************
// <copyright file="IKopernicusObject.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace KSP_To_Boldly_Go_Common.Models
{
    /// <summary>
    /// Interface IKopernicusObject
    /// </summary>
    public interface IKopernicusObject
    {
        #region Properties

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>The header.</value>
        string Header { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is internal browsable.
        /// </summary>
        /// <value><c>true</c> if this instance is internal browsable; otherwise, <c>false</c>.</value>
        bool ShowInternalProperties { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        int Order { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        string Type { get; set; }

        #endregion Properties
    }
}