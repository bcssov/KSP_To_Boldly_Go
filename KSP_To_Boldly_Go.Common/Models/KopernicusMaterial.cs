// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 02-25-2019
// ***********************************************************************
// <copyright file="KopernicusMaterial.cs" company="Mario">
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
    /// Class KopernicusMaterial.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Models.KopernicusObject" />
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class KopernicusMaterial : KopernicusObject
    {
        #region Properties

        /// <summary>
        /// Gets or sets the emit color0.
        /// </summary>
        /// <value>The emit color0.</value>
        [Editor(typeof(RangeColorEditor), typeof(UITypeEditor))]
        public RangeColor emitColor0
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the emit color1.
        /// </summary>
        /// <value>The emit color1.</value>
        [Editor(typeof(RangeColorEditor), typeof(UITypeEditor))]
        public RangeColor emitColor1
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the inverse fade.
        /// </summary>
        /// <value>The inverse fade.</value>
        public RangeDouble inverseFade { get; set; }

        /// <summary>
        /// Gets or sets the color of the rim.
        /// </summary>
        /// <value>The color of the rim.</value>
        [Editor(typeof(RangeColorEditor), typeof(UITypeEditor))]
        public RangeColor rimColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the sunspot colors.
        /// </summary>
        /// <value>The sunspot colors.</value>
        [Editor(typeof(RangeColorEditor), typeof(UITypeEditor))]
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