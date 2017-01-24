// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-22-2017
//
// Last Modified By : Mario
// Last Modified On : 01-23-2017
// ***********************************************************************
// <copyright file="KopernicusCorona.cs" company="">
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
    /// Class KopernicusCorona.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Models.KopernicusObject" />
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class KopernicusCorona : KopernicusObject
    {
        #region Properties

        /// <summary>
        /// Gets or sets the material.
        /// </summary>
        /// <value>The material.</value>
        public KopernicusMaterial Material { get; set; }

        /// <summary>
        /// Gets or sets the rotation.
        /// </summary>
        /// <value>The rotation.</value>
        public RangeLong rotation { get; set; }

        /// <summary>
        /// Gets or sets the scale limit x.
        /// </summary>
        /// <value>The scale limit x.</value>
        public RangeLong scaleLimitX { get; set; }

        /// <summary>
        /// Gets or sets the scale limit y.
        /// </summary>
        /// <value>The scale limit y.</value>
        public RangeLong scaleLimitY { get; set; }

        /// <summary>
        /// Gets or sets the scale speed.
        /// </summary>
        /// <value>The scale speed.</value>
        public RangeDouble scaleSpeed { get; set; }

        /// <summary>
        /// Gets or sets the speed.
        /// </summary>
        /// <value>The speed.</value>
        public RangeLong speed { get; set; }

        /// <summary>
        /// Gets or sets the update interval.
        /// </summary>
        /// <value>The update interval.</value>
        public RangeLong updateInterval { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets the name of the object.
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string GetObjectName()
        {
            return "Corona";
        }

        #endregion Methods
    }
}