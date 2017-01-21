// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go_Common
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-20-2017
// ***********************************************************************
// <copyright file="KopernicusMaterial.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using KSP_To_Boldly_Go_Common.Converters;
using System;
using System.ComponentModel;
using System.Drawing;

namespace KSP_To_Boldly_Go_Common.Models
{
    /// <summary>
    /// Class KopernicusMaterial.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go_Common.Models.KopernicusObject" />
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class KopernicusMaterial : KopernicusObject
    {
        #region Properties

        /// <summary>
        /// Gets the emit color0.
        /// </summary>
        /// <value>The emit color0.</value>
        public Color emitColor0
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the emit color1.
        /// </summary>
        /// <value>The emit color1.</value>
        public Color emitColor1
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the color of the rim.
        /// </summary>
        /// <value>The color of the rim.</value>
        public Color rimColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the sunspot colors.
        /// </summary>
        /// <value>The sunspot colors.</value>
        public Color sunspotColors
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
            return string.IsNullOrWhiteSpace(Header) ? "Material" : Header;
        }

        #endregion Methods
    }
}