// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-22-2017
//
// Last Modified By : Mario
// Last Modified On : 01-22-2017
// ***********************************************************************
// <copyright file="KopernicusCorona.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using KSP_To_Boldly_Go.Common.Converters.Object;
using KSP_To_Boldly_Go.Common.Serializers;
using System;
using System.Collections.Generic;
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
        #region Fields

        /// <summary>
        /// The header
        /// </summary>
        private string _header = "Corona";

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KopernicusCorona" /> class.
        /// </summary>
        public KopernicusCorona()
        {
            Material = new KopernicusMaterial("Material");
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>The header.</value>
        [KopernicusSerializeIgnore]
        [Description("Kopernicus node header. Internal program property.")]
        public override string Header
        {
            get
            {
                return _header;
            }

            set
            {
                // Internal only, cannot be set externally.
            }
        }

        /// <summary>
        /// Gets or sets the material.
        /// </summary>
        /// <value>The material.</value>
        public KopernicusMaterial Material { get; set; }

        /// <summary>
        /// Gets or sets the rotation.
        /// </summary>
        /// <value>The rotation.</value>
        public long? rotation { get; set; }

        /// <summary>
        /// Gets or sets the scale limit x.
        /// </summary>
        /// <value>The scale limit x.</value>
        public long? scaleLimitX { get; set; }

        /// <summary>
        /// Gets or sets the scale limit y.
        /// </summary>
        /// <value>The scale limit y.</value>
        public long? scaleLimitY { get; set; }

        /// <summary>
        /// Gets or sets the scale speed.
        /// </summary>
        /// <value>The scale speed.</value>
        public double? scaleSpeed { get; set; }

        /// <summary>
        /// Gets or sets the speed.
        /// </summary>
        /// <value>The speed.</value>
        public long? speed { get; set; }

        /// <summary>
        /// Gets or sets the update interval.
        /// </summary>
        /// <value>The update interval.</value>
        public long? updateInterval { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return !string.IsNullOrWhiteSpace(Header) ? Header : "Corona";
        }

        /// <summary>
        /// Filters the properties.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <param name="ignoreProperties">The ignore properties.</param>
        /// <returns>PropertyDescriptorCollection.</returns>
        protected override PropertyDescriptorCollection FilterProperties(PropertyDescriptorCollection properties, string[] ignoreProperties)
        {
            // Header cannot be set externaly, so hide it from editors
            List<string> propsToIgnore = new List<string>() { "Header" };
            propsToIgnore.AddRange(ignoreProperties);
            return base.FilterProperties(properties, propsToIgnore.ToArray());
        }

        #endregion Methods
    }
}