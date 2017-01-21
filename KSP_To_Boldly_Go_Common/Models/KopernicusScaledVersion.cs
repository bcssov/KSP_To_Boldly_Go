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
using KSP_To_Boldly_Go_Common.Converters;
using System;
using System.ComponentModel;

namespace KSP_To_Boldly_Go_Common.Models
{
    /// <summary>
    /// Class KopernicusScaledVersion.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go_Common.Models.KopernicusObject" />
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class KopernicusScaledVersion : KopernicusObject
    {
        #region Properties

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

        #region Methods

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return string.IsNullOrWhiteSpace(Header) ? "ScaledVersion" : Header;
        }

        #endregion Methods
    }
}