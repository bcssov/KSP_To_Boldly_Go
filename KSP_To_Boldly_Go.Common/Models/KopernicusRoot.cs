// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 02-25-2019
// ***********************************************************************
// <copyright file="KopernicusMain.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel;
using KSP_To_Boldly_Go.Common.Converters.Object;
using System;

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
        /// Gets the name of the object.
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string GetObjectName()
        {
            return "Root";
        }

        #endregion Methods
    }
}