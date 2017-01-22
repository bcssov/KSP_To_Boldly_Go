// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common[TypeConverter(typeof(SerializableExpandableObjectConverter))]
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-21-2017
// ***********************************************************************
// <copyright file="KopernicusBody.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using KSP_To_Boldly_Go.Common.Converters;
using System;
using System.ComponentModel;

namespace KSP_To_Boldly_Go.Common.Models
{
    /// <summary>
    /// Class KopernicusBody.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Models.KopernicusObject" />
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    [ObjectOrder(2)]
    public class KopernicusBody : KopernicusObject, IKopernicusRootObject
    {
        #region Properties

        /// <summary>
        /// Gets the cb name later.
        /// </summary>
        /// <value>The cb name later.</value>
        public string cbNameLater
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the orbit.
        /// </summary>
        /// <value>The orbit.</value>
        public KopernicusOrbit Orbit
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the post spawn orbit.
        /// </summary>
        /// <value>The post spawn orbit.</value>
        public KopernicusPostSpawnOrbit PostSpawnOrbit { get; set; }

        /// <summary>
        /// Gets or sets the properties.
        /// </summary>
        /// <value>The properties.</value>
        public KopernicusProperties Properties
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the scaled version.
        /// </summary>
        /// <value>The scaled version.</value>
        public KopernicusScaledVersion ScaledVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the template.
        /// </summary>
        /// <value>The template.</value>
        public KopernicusTemplate Template
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
            return string.IsNullOrWhiteSpace(Header) ? "Body" : Header;
        }

        #endregion Methods
    }
}