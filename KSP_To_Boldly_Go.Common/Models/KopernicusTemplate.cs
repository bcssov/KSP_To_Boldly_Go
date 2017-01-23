// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-20-2017
// ***********************************************************************
// <copyright file="KopernicusTemplate.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using KSP_To_Boldly_Go.Common.Converters.Object;
using System;
using System.ComponentModel;

namespace KSP_To_Boldly_Go.Common.Models
{
    /// <summary>
    /// Class KopernicusTemplate.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Models.KopernicusObject" />
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    public class KopernicusTemplate : KopernicusObject
    {
        #region Properties

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string name
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
            return string.IsNullOrWhiteSpace(Header) ? "Template" : Header;
        }

        #endregion Methods
    }
}