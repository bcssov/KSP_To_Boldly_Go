// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-22-2017
//
// Last Modified By : Mario
// Last Modified On : 01-23-2017
// ***********************************************************************
// <copyright file="KopernicusPostSpawnOrbit.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using KSP_To_Boldly_Go.Common.Converters;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace KSP_To_Boldly_Go.Common.Models
{
    /// <summary>
    /// Class KopernicusPostSpawnOrbit.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Models.KopernicusObject" />
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class KopernicusPostSpawnOrbit : KopernicusObject
    {
        #region Properties

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>The header.</value>
        [JsonIgnore]
        [Browsable(false)]
        [KopernicusSerializerIgnore]
        [Description("Kopernicus node header. Internal program property.")]
        public override string Header
        {
            get
            {
                return base.Header;
            }

            set
            {
                base.Header = value;
            }
        }

        /// <summary>
        /// Gets or sets the reference body.
        /// </summary>
        /// <value>The reference body.</value>
        public string referenceBody { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return string.IsNullOrWhiteSpace(Header) ? "PostSpawnOrbit" : Header;
        }

        #endregion Methods
    }
}