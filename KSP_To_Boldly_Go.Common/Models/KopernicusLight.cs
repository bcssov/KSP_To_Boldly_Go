﻿// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-24-2017
// ***********************************************************************
// <copyright file="KopernicusLight.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel;
using KSP_To_Boldly_Go.Common.Converters.Object;
using KSP_To_Boldly_Go.Common.Types;
using System;

namespace KSP_To_Boldly_Go.Common.Models
{
    /// <summary>
    /// Class KopernicusLight.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Models.KopernicusObject" />
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class KopernicusLight : KopernicusObject
    {
        #region Properties

        /// <summary>
        /// Gets the color of the ambient light.
        /// </summary>
        /// <value>The color of the ambient light.</value>
        public RangeColor ambientLightColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [gives off light].
        /// </summary>
        /// <value><c>true</c> if [gives off light]; otherwise, <c>false</c>.</value>
        public bool? givesOffLight { get; set; } = null;

        /// <summary>
        /// Gets the color of the iva sun.
        /// </summary>
        /// <value>The color of the iva sun.</value>
        public RangeColor IVASunColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the iva sun intensity.
        /// </summary>
        /// <value>The iva sun intensity.</value>
        public RangeDouble IVASunIntensity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the luminosity.
        /// </summary>
        /// <value>The luminosity.</value>
        public RangeLong luminosity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the color of the scaled sunlight.
        /// </summary>
        /// <value>The color of the scaled sunlight.</value>
        public RangeColor scaledSunlightColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the scaled sunlight intensity.
        /// </summary>
        /// <value>The scaled sunlight intensity.</value>
        public RangeDouble scaledSunlightIntensity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the color of the sun lens flare.
        /// </summary>
        /// <value>The color of the sun lens flare.</value>
        public RangeColor sunLensFlareColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the color of the sunlight.
        /// </summary>
        /// <value>The color of the sunlight.</value>
        public RangeColor sunlightColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the sunlight intensity.
        /// </summary>
        /// <value>The sunlight intensity.</value>
        public RangeDouble sunlightIntensity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the sunlight shadow strength.
        /// </summary>
        /// <value>The sunlight shadow strength.</value>
        public RangeDouble sunlightShadowStrength
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
            return "Light";
        }

        #endregion Methods
    }
}