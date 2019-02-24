// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.DIConfig
// Author           : Mario
// Created          : 02-23-2019
//
// Last Modified By : Mario
// Last Modified On : 02-23-2019
// ***********************************************************************
// <copyright file="Bootstrap.cs" company="Mario">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using SimpleInjector;

/// <summary>
/// The DIConfig namespace.
/// </summary>
namespace KSP_To_Boldly_Go.DependencyInjection
{
    /// <summary>
    /// Class Bootstrap.
    /// </summary>
    public static class Bootstrap
    {
        #region Methods

        /// <summary>
        /// Completes this instance.
        /// </summary>
        public static void Complete()
        {
            var files = new DirectoryInfo(DIContainer.Path).GetFiles().ToList();
            var assemblies = from file in files
                             where file.Extension.ToLowerInvariant() == ".dll"
                             select Assembly.Load(AssemblyName.GetAssemblyName(file.FullName));

            DIContainer.Container.RegisterPackages(assemblies);

            DIContainer.Container.Verify();
        }

        /// <summary>
        /// Initializes the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        public static void Init(string path)
        {
            var container = new Container();
            DIContainer.Init(container, path);
        }

        #endregion Methods
    }
}