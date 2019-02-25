// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 02-25-2019
//
// Last Modified By : Mario
// Last Modified On : 02-25-2019
// ***********************************************************************
// <copyright file="ITypeHandler.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace KSP_To_Boldly_Go.Common.Types
{
    /// <summary>
    /// Interface ITypeHandler
    /// </summary>
    public interface ITypeHandler
    {
        #region Methods

        /// <summary>
        /// Creates the model.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>IType.</returns>
        IType CreateModel(Type type);

        /// <summary>
        /// Creates the model.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T.</returns>
        T CreateModel<T>() where T : IType;

        #endregion Methods
    }
}