// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go_Common
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-20-2017
// ***********************************************************************
// <copyright file="KopernicusBody.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using KSP_To_Boldly_Go_Common.Types;
using System;

namespace KSP_To_Boldly_Go_Common.Models
{
    /// <summary>
    /// Class KopernicusBody.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go_Common.Models.IKopernicusObject" />
    public class KopernicusBody : IKopernicusObject
    {
        #region Properties

        /// <summary>
        /// Gets the cb name later.
        /// </summary>
        /// <value>The cb name later.</value>
        public string cbNameLater
        {
            get;
            set;
        }

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
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the orbit.
        /// </summary>
        /// <value>The orbit.</value>
        public KopernicusOrbit Orbit
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the propereties.
        /// </summary>
        /// <value>The propereties.</value>
        public KopernicusProperties Propereties
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the scaled version.
        /// </summary>
        /// <value>The scaled version.</value>
        public KopernicusScaledVersion ScaledVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the template.
        /// </summary>
        /// <value>The template.</value>
        public KopernicusTemplate Template
        {
            get;
            set;
        }

        #endregion Properties
    }
}