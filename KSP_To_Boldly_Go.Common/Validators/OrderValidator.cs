// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 04-01-2017
//
// Last Modified By : Mario
// Last Modified On : 02-25-2019
// ***********************************************************************
// <copyright file="OrderValidator.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using KSP_To_Boldly_Go.Common.Models;

namespace KSP_To_Boldly_Go.Common.Validators
{
    /// <summary>
    /// Class OrderValidator.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Validators.IValidator" />
    public class OrderValidator : IValidator
    {
        #region Properties

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name => typeof(OrderValidator).Name;

        #endregion Properties

        #region Methods

        /// <summary>
        /// Validates the specified kopernicus objects.
        /// </summary>
        /// <param name="kopernicusObjects">The kopernicus objects.</param>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        public IValidationResult Validate(IEnumerable<IKopernicusObject> kopernicusObjects)
        {
            var result = new ValidationResult()
            {
                ValidationType = Name
            };
            var orders = kopernicusObjects.GroupBy(p => p.Order).Where(p => p.Skip(1).Any()).SelectMany(p => p);
            if (orders?.Count() > 0)
            {
                var errors = new List<string>();
                foreach (var order in orders)
                {
                    errors.Add($"File {order.FileName} has the same order as {order.Order}");
                }
                result.Errors = errors;
            }
            return result;
        }

        #endregion Methods
    }
}