// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 02-23-2019
// ***********************************************************************
// <copyright file="Program.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using KSP_To_Boldly_Go.Forms;
using SimpleInjector;

namespace KSP_To_Boldly_Go
{
    /// <summary>
    /// Class Program.
    /// </summary>
    internal static class Program
    {
        #region Methods

        /// <summary>
        /// Handles the ThreadException event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ThreadExceptionEventArgs" /> instance containing the event data.</param>
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Log.Error(e.Exception);
            MessageBox.Show(Constants.ErrorMessage, Constants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Handles the UnhandledException event of the CurrentDomain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="UnhandledExceptionEventArgs" /> instance containing the event data.</param>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception)
            {
                Log.Error((Exception)e.ExceptionObject);
                MessageBox.Show(Constants.ErrorMessage, Constants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Initializes the di containers.
        /// </summary>
        private static void InitDIContainers()
        {
            var files = new DirectoryInfo(Application.StartupPath).GetFiles().ToList();
            var assemblies = from file in files
                             where file.Extension.ToLowerInvariant() == Constants.DLLExtension
                             select Assembly.Load(AssemblyName.GetAssemblyName(file.FullName));

            var container = new Container();
            container.RegisterPackages(assemblies);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Constants.Culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Constants.Culture);

            InitDIContainers();

            // Do not catch exceptions and log them if debugger is attached
            if (!Debugger.IsAttached)
            {
                Application.ThreadException += Application_ThreadException;
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        #endregion Methods

        #region Classes

        /// <summary>
        /// Class Constants.
        /// </summary>
        private class Constants
        {
            #region Fields

            /// <summary>
            /// The culture
            /// </summary>
            public const string Culture = "en-US";

            /// <summary>
            /// The DLL extension
            /// </summary>
            public const string DLLExtension = ".dll";

            /// <summary>
            /// The error message
            /// </summary>
            public const string ErrorMessage = "Unhandled error occurred";

            /// <summary>
            /// The error title
            /// </summary>
            public const string ErrorTitle = "Error";

            #endregion Fields
        }

        #endregion Classes
    }
}