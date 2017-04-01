// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 04-01-2017
//
// Last Modified By : Mario
// Last Modified On : 04-01-2017
// ***********************************************************************
// <copyright file="OrderValidator.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using KSP_To_Boldly_Go.Common.Models;
using System.Collections.Generic;
using System.Linq;

namespace KSP_To_Boldly_Go.Common.Validators
{
    /// <summary>
    /// Class OrderValidator.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Validator.IValidator" />
    public class OrderValidator : IValidator
    {
        #region Methods

        /// <summary>
        /// Validates the specified kopernicus object.
        /// </summary>
        /// <param name="kopernicusObject">The kopernicus object.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public List<string> Validate(IEnumerable<IKopernicusObject> kopernicusObject)
        {
            var orders = kopernicusObject.GroupBy(p => p.Order).Where(p => p.Skip(1).Any()).SelectMany(p => p);
            if (orders != null && orders.Count() > 0)
            {
                List<string> results = new List<string>();
                foreach (var order in orders)
                {
                    results.Add(string.Format("File {0} has the same order as {1}", order.FileName, order.Order));
                }
                return results;
            }
            return null;
        }

        #endregion Methods
    }
}