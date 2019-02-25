// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 02-25-2019
//
// Last Modified By : Mario
// Last Modified On : 02-25-2019
// ***********************************************************************
// <copyright file="IValidationResult.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

namespace KSP_To_Boldly_Go.Common.Validators
{
    /// <summary>
    /// Interface IValidationResult
    /// </summary>
    public interface IValidationResult
    {
        #region Properties

        /// <summary>
        /// Gets the errors.
        /// </summary>
        /// <value>The errors.</value>
        IEnumerable<string> Errors { get; }

        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <value>The state.</value>
        ValidationResultState State { get; }

        /// <summary>
        /// Gets the type of the validation.
        /// </summary>
        /// <value>The type of the validation.</value>
        string ValidationType { get; }

        #endregion Properties
    }
}