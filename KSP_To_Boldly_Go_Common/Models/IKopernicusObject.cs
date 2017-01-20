// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go_Common
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-20-2017
// ***********************************************************************
// <copyright file="IKopernicusObject.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using KSP_To_Boldly_Go_Common.Types;
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
        KopernicusHeader Header { get; set; }

        #endregion Properties
    }
}