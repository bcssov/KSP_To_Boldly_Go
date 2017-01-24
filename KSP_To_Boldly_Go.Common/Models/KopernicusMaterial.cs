// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-24-2017
// ***********************************************************************
// <copyright file="KopernicusMaterial.cs" company="">
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
    /// Class KopernicusMaterial.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Models.KopernicusObject" />
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class KopernicusMaterial : KopernicusObject
    {
        #region Fields

        /// <summary>
        /// The custom header
        /// </summary>
        private string _customHeader = string.Empty;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KopernicusMaterial" /> class.
        /// </summary>
        public KopernicusMaterial() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KopernicusMaterial" /> class.
        /// </summary>
        /// <param name="customHeader">The custom header.</param>
        public KopernicusMaterial(string customHeader) : base()
        {
            if (!string.IsNullOrWhiteSpace(customHeader))
            {
                _customHeader = customHeader;
            }
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the emit color0.
        /// </summary>
        /// <value>The emit color0.</value>
        public RangeColor emitColor0
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the emit color1.
        /// </summary>
        /// <value>The emit color1.</value>
        public RangeColor emitColor1
        {
            get;
            set;
        }

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
                // Corona can be its parent, in that case we use a custom header
                if (!string.IsNullOrWhiteSpace(_customHeader))
                {
                    return base.Header;
                }
                return _customHeader;
            }

            set
            {
                // Can only be set incase an object was not created internally
                if (!string.IsNullOrWhiteSpace(_customHeader))
                {
                    base.Header = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the inverse fade.
        /// </summary>
        /// <value>The inverse fade.</value>
        public RangeDouble inverseFade { get; set; }

        /// <summary>
        /// Gets the color of the rim.
        /// </summary>
        /// <value>The color of the rim.</value>
        public RangeColor rimColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the sunspot colors.
        /// </summary>
        /// <value>The sunspot colors.</value>
        public RangeColor sunspotColors
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the texture.
        /// </summary>
        /// <value>The texture.</value>
        public string texture { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Filters the properties.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <param name="ignoreProperties">The ignore properties.</param>
        /// <returns>PropertyDescriptorCollection.</returns>
        protected override PropertyDescriptorCollection FilterProperties(PropertyDescriptorCollection properties, string[] ignoreProperties)
        {
            if (!string.IsNullOrWhiteSpace(_customHeader))
            {
                List<string> propsToIgnore = new List<string>() { "Header" };
                propsToIgnore.AddRange(ignoreProperties);
                return base.FilterProperties(properties, propsToIgnore.ToArray());
            }
            return base.FilterProperties(properties, ignoreProperties);
        }

        /// <summary>
        /// Gets the name of the object.
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string GetObjectName()
        {
            return "Material";
        }

        #endregion Methods
    }
}