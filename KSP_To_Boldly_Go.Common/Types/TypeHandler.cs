// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 02-25-2019
//
// Last Modified By : Mario
// Last Modified On : 02-25-2019
// ***********************************************************************
// <copyright file="TypeHandler.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace KSP_To_Boldly_Go.Common.Types
{
    /// <summary>
    /// Class TypeHandler.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Types.ITypeHandler" />
    public class TypeHandler : ITypeHandler
    {
        #region Methods

        /// <summary>
        /// Creates the model.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T.</returns>
        public T CreateModel<T>() where T : IType => (T)CreateModel(typeof(T));

        /// <summary>
        /// Creates the model.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>IKopernicusObject.</returns>
        /// <exception cref="ArgumentException">Invalid type.</exception>
        public IType CreateModel(Type type)
        {
            if (!typeof(IType).IsAssignableFrom(type))
            {
                throw new ArgumentException("Invalid type.");
            }
            return (IType)DependencyInjection.DIContainer.Container.GetInstance(type);
        }

        #endregion Methods
    }
}