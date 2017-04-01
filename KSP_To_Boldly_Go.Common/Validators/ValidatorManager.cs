// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 04-01-2017
//
// Last Modified By : Mario
// Last Modified On : 04-01-2017
// ***********************************************************************
// <copyright file="ValidatorManager.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using KSP_To_Boldly_Go.Common.Models;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace KSP_To_Boldly_Go.Common.Validators
{
    /// <summary>
    /// Class ValidatorManager.
    /// </summary>
    public static class ValidatorManager
    {
        #region Fields

        /// <summary>
        /// The validators
        /// </summary>
        private static List<IValidator> validators;

        #endregion Fields

        #region Methods

        /// <summary>
        /// Validates the models.
        /// </summary>
        /// <param name="kopernicusObjects">The kopernicus objects.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public static List<string> ValidateModels(List<IKopernicusObject> kopernicusObjects)
        {
            if (kopernicusObjects == null || kopernicusObjects.Count == 0)
            {
                return null;
            }
            var validators = GetValidators();
            List<string> results = new List<string>();
            foreach (var validator in validators)
            {
                var validatorResult = validator.Validate(kopernicusObjects);
                if (validatorResult != null)
                {
                    results.AddRange(validatorResult);
                }
            }
            return results;
        }

        /// <summary>
        /// Gets the validators.
        /// </summary>
        /// <returns>List&lt;IValidator&gt;.</returns>
        private static List<IValidator> GetValidators()
        {
            if (validators == null)
            {
                List<IValidator> result = new List<IValidator>();
                var objects = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IValidator))).ToList();
                foreach (var item in objects)
                {
                    result.Add((IValidator)Activator.CreateInstance(item));
                }
                validators = result;
            }
            return validators;
        }

        #endregion Methods
    }
}