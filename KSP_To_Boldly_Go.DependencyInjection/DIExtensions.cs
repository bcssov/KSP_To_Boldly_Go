// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.DependencyInjection
// Author           : Mario
// Created          : 02-23-2019
//
// Last Modified By : Mario
// Last Modified On : 02-23-2019
// ***********************************************************************
// <copyright file="DIExtensions.cs" company="Mario">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using SimpleInjector;

/// <summary>
/// The DependencyInjection namespace.
/// </summary>
namespace KSP_To_Boldly_Go.DependencyInjection
{
    /// <summary>
    /// Class DIExtensions.
    /// </summary>
    public static class DIExtensions
    {
        #region Methods

        /// <summary>
        /// Registers the without transient warning.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="container">The container.</param>
        public static void RegisterWithoutTransientWarning<T>(this Container container) where T : class
        {
            container.Register<T>();
            var registration = container.GetRegistration(typeof(T)).Registration;
            registration.SuppressDiagnosticWarning(SimpleInjector.Diagnostics.DiagnosticType.DisposableTransientComponent, "Using WinForms.");
        }

        #endregion Methods
    }
}