// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-22-2017
//
// Last Modified By : Mario
// Last Modified On : 01-22-2017
// ***********************************************************************
// <copyright file="KopernicusRootObjectOrderAttribute.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace KSP_To_Boldly_Go.Common.Models
{
    /// <summary>
    /// Class KopernicusRootObjectOrderAttribute.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    public class ObjectOrderAttribute : Attribute
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectOrderAttribute"/> class.
        /// </summary>
        /// <param name="order">The order.</param>
        public ObjectOrderAttribute(int order)
        {
            this.Order = order;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets a value indicating whether this <see cref="ObjectOrderAttribute"/> is order.
        /// </summary>
        /// <value><c>true</c> if order; otherwise, <c>false</c>.</value>
        public int Order { get; private set; }

        #endregion Properties
    }
}