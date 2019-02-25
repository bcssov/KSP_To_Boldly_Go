// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 02-25-2019
// ***********************************************************************
// <copyright file="KopernicusLight.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel;
using System.Drawing.Design;
using KSP_To_Boldly_Go.Common.Converters.Object;
using KSP_To_Boldly_Go.Common.Types;
using System;
using KSP_To_Boldly_Go.Common.UI;

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
        /// Gets or sets the color of the ambient light.
        /// </summary>
        /// <value>The color of the ambient light.</value>
        [Editor(typeof(RangeColorEditor), typeof(UITypeEditor))]
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
        /// Gets or sets the color of the iva sun.
        /// </summary>
        /// <value>The color of the iva sun.</value>
        [Editor(typeof(RangeColorEditor), typeof(UITypeEditor))]
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
        /// Gets or sets the color of the scaled sunlight.
        /// </summary>
        /// <value>The color of the scaled sunlight.</value>
        [Editor(typeof(RangeColorEditor), typeof(UITypeEditor))]
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
        /// Gets or sets the color of the sun lens flare.
        /// </summary>
        /// <value>The color of the sun lens flare.</value>
        [Editor(typeof(RangeColorEditor), typeof(UITypeEditor))]
        public RangeColor sunLensFlareColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the color of the sunlight.
        /// </summary>
        /// <value>The color of the sunlight.</value>
        [Editor(typeof(RangeColorEditor), typeof(UITypeEditor))]
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