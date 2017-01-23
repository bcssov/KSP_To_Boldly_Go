// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-23-2017
// ***********************************************************************
// <copyright file="KopernicusScaledVersion.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using KSP_To_Boldly_Go.Common.Converters.Object;
using KSP_To_Boldly_Go.Common.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace KSP_To_Boldly_Go.Common.Models
{
    /// <summary>
    /// Class KopernicusScaledVersion.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Models.KopernicusObject" />
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class KopernicusScaledVersion : KopernicusObject
    {
        #region Properties

        /// <summary>
        /// Gets or sets the coronas.
        /// </summary>
        /// <value>The coronas.</value>
        [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        public List<KopernicusCorona> Coronas { get; set; }

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
        /// Gets the name of the object.
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string GetObjectName()
        {
            return "ScaledVersion";
        }

        #endregion Methods
    }
}