// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 04-01-2017
//
// Last Modified By : Mario
// Last Modified On : 04-01-2017
// ***********************************************************************
// <copyright file="IValidator.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using KSP_To_Boldly_Go.Common.Models;
using System;
using System.Collections.Generic;

namespace KSP_To_Boldly_Go.Common.Validators
{
    /// <summary>
    /// Interface IValidator
    /// </summary>
    public interface IValidator
    {
        #region Methods

        /// <summary>
        /// Validates the specified kopernicus object.
        /// </summary>
        /// <param name="kopernicusObject">The kopernicus object.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        List<string> Validate(IEnumerable<IKopernicusObject> kopernicusObject);

        #endregion Methods
    }
}