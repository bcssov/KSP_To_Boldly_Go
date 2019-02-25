// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 02-25-2019
//
// Last Modified By : Mario
// Last Modified On : 02-25-2019
// ***********************************************************************
// <copyright file="ValidationResult.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;

namespace KSP_To_Boldly_Go.Common.Validators
{
    /// <summary>
    /// Class ValidationResult.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Validators.IValidationResult" />
    public class ValidationResult : IValidationResult
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationResult" /> class.
        /// </summary>
        public ValidationResult()
        {
            Errors = new List<string>();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the errors.
        /// </summary>
        /// <value>The errors.</value>
        public IEnumerable<string> Errors { get; set; }

        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <value>The state.</value>
        public ValidationResultState State
        {
            get
            {
                return Errors?.Count() > 0 ? ValidationResultState.Error : ValidationResultState.Valid;
            }
        }

        /// <summary>
        /// Gets the type of the validation.
        /// </summary>
        /// <value>The type of the validation.</value>
        public string ValidationType { get; set; }

        #endregion Properties
    }
}