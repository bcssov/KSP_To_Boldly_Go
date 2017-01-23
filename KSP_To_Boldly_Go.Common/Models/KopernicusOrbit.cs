// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
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
using KSP_To_Boldly_Go.Common.Converters.Object;
using KSP_To_Boldly_Go.Common.Types;
using System;
using System.ComponentModel;

namespace KSP_To_Boldly_Go.Common.Models
{
    /// <summary>
    /// Class KopernicusOrbit.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Models.KopernicusObject" />
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class KopernicusOrbit : KopernicusObject
    {
        #region Properties

        /// <summary>
        /// Gets the argument of periapsis.
        /// </summary>
        /// <value>The argument of periapsis.</value>
        public RangeLong argumentOfPeriapsis
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
        /// Gets the inclination.
        /// </summary>
        /// <value>The inclination.</value>
        public RangeLong inclination
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the mode.
        /// </summary>
        /// <value>The mode.</value>
        public RangeLong mode
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
        public RangeLong semiMajorAxis
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return string.IsNullOrWhiteSpace(Header) ? "Orbit" : Header;
        }

        #endregion Methods
    }
}