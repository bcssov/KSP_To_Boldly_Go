// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 02-25-2019
//
// Last Modified By : Mario
// Last Modified On : 02-25-2019
// ***********************************************************************
// <copyright file="ValidatorHandler.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KSP_To_Boldly_Go.Common.Models;

namespace KSP_To_Boldly_Go.Common.Validators
{
    /// <summary>
    /// Class ValidatorHandler.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Validators.IValidatorHandler" />
    public class ValidatorHandler : IValidatorHandler
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatorHandler" /> class.
        /// </summary>
        /// <param name="validators">The validators.</param>
        public ValidatorHandler(IEnumerable<IValidator> validators)
        {
            Validators = validators;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the validators.
        /// </summary>
        /// <value>The validators.</value>
        protected IEnumerable<IValidator> Validators { get; private set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Formats the messages.
        /// </summary>
        /// <param name="results">The results.</param>
        /// <returns>System.String.</returns>
        public string FormatMessages(IEnumerable<IValidationResult> results)
        {
            if (results == null || results.Count() == 0)
            {
                return string.Empty;
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in results)
            {
                string messages = string.Join(Environment.NewLine, item.Errors);
                sb.Append($"Validator Type: {item.ValidationType}{Environment.NewLine}Status: {item.State}{Environment.NewLine}");
                if (!string.IsNullOrWhiteSpace(messages))
                {
                    sb.Append($"Messages: {messages}{Environment.NewLine}");
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Validates the specified kopernicus objects.
        /// </summary>
        /// <param name="kopernicusObjects">The kopernicus objects.</param>
        /// <returns>IEnumerable&lt;IValidationResult&gt;.</returns>
        public IEnumerable<IValidationResult> Validate(IEnumerable<IKopernicusObject> kopernicusObjects)
        {
            List<IValidationResult> results = new List<IValidationResult>();
            if (kopernicusObjects?.Count() > 0)
            {
                foreach (var validator in Validators)
                {
                    var validatorResult = validator.Validate(kopernicusObjects);
                    if (validatorResult != null)
                    {
                        results.Add(validatorResult);
                    }
                }
            }
            return results;
        }

        /// <summary>
        /// Validates the results.
        /// </summary>
        /// <param name="results">The results.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ValidateResults(IEnumerable<IValidationResult> results)
        {
            if (results == null || results.Count() == 0)
            {
                return true;
            }
            return results.All(p => p.State == ValidationResultState.Valid);
        }

        #endregion Methods
    }
}