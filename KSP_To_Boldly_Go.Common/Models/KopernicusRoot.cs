// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-23-2017
// ***********************************************************************
// <copyright file="KopernicusMain.cs" company="">
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
    /// Class KopernicusMain.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Models.IKopernicusRootObject" />
    /// <seealso cref="KSP_To_Boldly_Go.Common.Models.KopernicusObject" />
    [TypeConverter(typeof(SerializableExpandableObjectConverter))]
    [ObjectOrder(1)]
    public class KopernicusRoot : KopernicusObject, IKopernicusRootObject
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KopernicusRoot"/> class.
        /// </summary>
        public KopernicusRoot()
        {
            Body = new KopernicusBody();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        public KopernicusBody Body
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
            return string.IsNullOrWhiteSpace(Header) ? "Root" : Header;
        }

        #endregion Methods
    }
}