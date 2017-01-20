// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go_Common
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-20-2017
// ***********************************************************************
// <copyright file="KopernicusProperties.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using KSP_To_Boldly_Go_Common.Types;
using System;

namespace KSP_To_Boldly_Go_Common.Models
{
    /// <summary>
    /// Class KopernicusProperties.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go_Common.Models.IKopernicusObject" />
    public class KopernicusProperties : IKopernicusObject
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
        /// Gets the sphere of influence.
        /// </summary>
        /// <value>The sphere of influence.</value>
        public long sphereOfInfluence
        {
            get;
            set;
        }

        #endregion Properties
    }
}