// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-22-2017
// ***********************************************************************
// <copyright file="KopernicusLight.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using KSP_To_Boldly_Go.Common.Converters;
using System;
using System.ComponentModel;
using System.Drawing;

namespace KSP_To_Boldly_Go.Common.Models
{
    /// <summary>
    /// Class KopernicusLight.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Models.KopernicusObject" />
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class KopernicusLight : KopernicusObject
    {
        #region Fields

        /// <summary>
        /// The gives off light
        /// </summary>
        private bool? _givesOffLight = null;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the color of the ambient light.
        /// </summary>
        /// <value>The color of the ambient light.</value>
        public Color? ambientLightColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [gives off light].
        /// </summary>
        /// <value><c>true</c> if [gives off light]; otherwise, <c>false</c>.</value>
        public bool? givesOffLight
        {
            get
            {
                return _givesOffLight;
            }
            set
            {
                _givesOffLight = value;
            }
        }

        /// <summary>
        /// Gets the color of the iva sun.
        /// </summary>
        /// <value>The color of the iva sun.</value>
        public Color? IVASunColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the iva sun intensity.
        /// </summary>
        /// <value>The iva sun intensity.</value>
        public double? IVASunIntensity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the luminosity.
        /// </summary>
        /// <value>The luminosity.</value>
        public long? luminosity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the color of the scaled sunlight.
        /// </summary>
        /// <value>The color of the scaled sunlight.</value>
        public Color? scaledSunlightColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the scaled sunlight intensity.
        /// </summary>
        /// <value>The scaled sunlight intensity.</value>
        public double? scaledSunlightIntensity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the color of the sun lens flare.
        /// </summary>
        /// <value>The color of the sun lens flare.</value>
        public Color? sunLensFlareColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the color of the sunlight.
        /// </summary>
        /// <value>The color of the sunlight.</value>
        public Color? sunlightColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the sunlight intensity.
        /// </summary>
        /// <value>The sunlight intensity.</value>
        public double? sunlightIntensity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the sunlight shadow strength.
        /// </summary>
        /// <value>The sunlight shadow strength.</value>
        public double? sunlightShadowStrength
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
            return string.IsNullOrWhiteSpace(Header) ? "Light" : Header;
        }

        #endregion Methods
    }
}