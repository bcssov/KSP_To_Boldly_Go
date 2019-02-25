// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 02-25-2019
//
// Last Modified By : Mario
// Last Modified On : 02-25-2019
// ***********************************************************************
// <copyright file="IValidatorHandler.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using KSP_To_Boldly_Go.Common.Models;

namespace KSP_To_Boldly_Go.Common.Validators
{
    /// <summary>
    /// Interface IValidatorHandler
    /// </summary>
    public interface IValidatorHandler
    {
        #region Methods

        /// <summary>
        /// Formats the messages.
        /// </summary>
        /// <param name="results">The results.</param>
        /// <returns>System.String.</returns>
        string FormatMessages(IEnumerable<IValidationResult> results);

        /// <summary>
        /// Validates the specified kopernicus objects.
        /// </summary>
        /// <param name="kopernicusObjects">The kopernicus objects.</param>
        /// <returns>IEnumerable&lt;IValidationResult&gt;.</returns>
        IEnumerable<IValidationResult> Validate(IEnumerable<IKopernicusObject> kopernicusObjects);

        /// <summary>
        /// Validates the results.
        /// </summary>
        /// <param name="results">The results.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool ValidateResults(IEnumerable<IValidationResult> results);

        #endregion Methods
    }
}