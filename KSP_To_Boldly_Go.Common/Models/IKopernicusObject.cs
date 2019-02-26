// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 02-26-2019
// ***********************************************************************
// <copyright file="IKopernicusObject.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace KSP_To_Boldly_Go.Common.Models
{
    /// <summary>
    /// Interface IKopernicusObject
    /// </summary>
    public interface IKopernicusObject
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        string FileName { get; set; }

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>The header.</value>
        string Header { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is changed.
        /// </summary>
        /// <value><c>true</c> if this instance is changed; otherwise, <c>false</c>.</value>
        bool IsChanged { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        int Order { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is internal browsable.
        /// </summary>
        /// <value><c>true</c> if this instance is internal browsable; otherwise, <c>false</c>.</value>
        bool ShowInternalProperties { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        string Type { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Determines whether this instance is dirty.
        /// </summary>
        /// <returns><c>true</c> if this instance is dirty; otherwise, <c>false</c>.</returns>
        bool IsDirty();

        /// <summary>
        /// Determines whether this instance is empty.
        /// </summary>
        /// <returns><c>true</c> if this instance is empty; otherwise, <c>false</c>.</returns>
        bool IsEmpty();

        /// <summary>
        /// Sets the dirty flag.
        /// </summary>
        /// <param name="isDirty">if set to <c>true</c> [is dirty].</param>
        void SetDirtyFlag(bool isDirty);

        #endregion Methods
    }
}