// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go_Common
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-20-2017
// ***********************************************************************
// <copyright file="KopernicusScaledVersion.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using KSP_To_Boldly_Go_Common.Types;
using System;

namespace KSP_To_Boldly_Go_Common.Models
{
    /// <summary>
    /// Class KopernicusScaledVersion.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go_Common.Models.IKopernicusObject" />
    public class KopernicusScaledVersion : IKopernicusObject
    {
        #region Properties

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>The header.</value>
        public KopernicusHeader Header
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the light.
        /// </summary>
        /// <value>The light.</value>
        public KopernicusLight Light
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the material.
        /// </summary>
        /// <value>The material.</value>
        public KopernicusMaterial Material
        {
            get;
            set;
        }

        #endregion Properties
    }
}