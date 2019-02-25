// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 04-01-2017
//
// Last Modified By : Mario
// Last Modified On : 02-25-2019
// ***********************************************************************
// <copyright file="IValidator.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using KSP_To_Boldly_Go.Common.Models;
using System;

namespace KSP_To_Boldly_Go.Common.Validators
{
    /// <summary>
    /// Interface IValidator
    /// </summary>
    public interface IValidator
    {
        #region Properties

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Validates the specified kopernicus objects.
        /// </summary>
        /// <param name="kopernicusObjects">The kopernicus objects.</param>
        /// <returns>IValidationResult.</returns>
        IValidationResult Validate(IEnumerable<IKopernicusObject> kopernicusObjects);

        #endregion Methods
    }
}