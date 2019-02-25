// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 02-25-2019
// ***********************************************************************
// <copyright file="KopernicusOrbit.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel;
using System.Drawing.Design;
using KSP_To_Boldly_Go.Common.Converters.Object;
using KSP_To_Boldly_Go.Common.Types;
using KSP_To_Boldly_Go.Common.UI;
using System;

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
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        [Editor(typeof(RangeColorEditor), typeof(UITypeEditor))]
        public RangeColor color
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
        /// Gets the name of the object.
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string GetObjectName()
        {
            return "Orbit";
        }

        #endregion Methods
    }
}