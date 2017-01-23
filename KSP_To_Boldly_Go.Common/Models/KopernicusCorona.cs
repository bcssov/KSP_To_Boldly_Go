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
using KSP_To_Boldly_Go.Common.Serializers;
using KSP_To_Boldly_Go.Common.Types;
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

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            Material = new KopernicusMaterial("Material");
        }

        #endregion Methods
    }
}