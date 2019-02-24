// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.DIConfig
// Author           : Mario
// Created          : 02-23-2019
//
// Last Modified By : Mario
// Last Modified On : 02-23-2019
// ***********************************************************************
// <copyright file="DIContainer.cs" company="Mario">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using SimpleInjector;

/// <summary>
/// The DIConfig namespace.
/// </summary>
namespace KSP_To_Boldly_Go.DependencyInjection
{
    /// <summary>
    /// Class DIContainer.
    /// </summary>
    public static class DIContainer
    {
        #region Properties

        /// <summary>
        /// Gets the container.
        /// </summary>
        /// <value>The container.</value>
        public static Container Container { get; private set; }

        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <value>The path.</value>
        public static string Path { get; private set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Initializes the specified container.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="path">The path.</param>
        internal static void Init(Container container, string path)
        {
            Container = container;
            Path = path;
        }

        #endregion Methods
    }
}