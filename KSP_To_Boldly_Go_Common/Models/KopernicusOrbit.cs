// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go_Common
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-20-2017
// ***********************************************************************
// <copyright file="KopernicusOrbit.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using KSP_To_Boldly_Go_Common.Types;
using System;
using System.Drawing;

namespace KSP_To_Boldly_Go_Common.Models
{
    /// <summary>
    /// Class KopernicusOrbit.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go_Common.Models.IKopernicusObject" />
    public class KopernicusOrbit : IKopernicusObject
    {
        #region Properties

        /// <summary>
        /// Gets the argument of periapsis.
        /// </summary>
        /// <value>The argument of periapsis.</value>
        public long argumentOfPeriapsis
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <value>The color.</value>
        public Color color
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
        /// Gets the inclination.
        /// </summary>
        /// <value>The inclination.</value>
        public long inclination
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the mode.
        /// </summary>
        /// <value>The mode.</value>
        public long mode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the reference body.
        /// </summary>
        /// <value>The reference body.</value>
        public string referenceBody
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the semi major axis.
        /// </summary>
        /// <value>The semi major axis.</value>
        public long semiMajorAxis
        {
            get;
            set;
        }

        #endregion Properties
    }
}