// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 02-26-2019
// ***********************************************************************
// <copyright file="Program.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using KSP_To_Boldly_Go.Common.UI;
using KSP_To_Boldly_Go.DependencyInjection;
using KSP_To_Boldly_Go.Forms;

/// <summary>
/// The KSP_To_Boldly_Go namespace.
/// </summary>
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
            LogError(e.Exception);
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
                LogError((Exception)e.ExceptionObject);
            }
        }

        /// <summary>
        /// Initializes the application configuration.
        /// </summary>
        private static void InitAppConfig()
        {
            // Do not catch exceptions and log them if debugger is attached
            if (!Debugger.IsAttached)
            {
                Application.ThreadException += Application_ThreadException;
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }

        /// <summary>
        /// Initializes the culture.
        /// </summary>
        private static void InitCulture()
        {
            var culture = new CultureInfo(Constants.Culture);

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }

        /// <summary>
        /// Initializes the di.
        /// </summary>
        private static void InitDI()
        {
            Bootstrap.Init(Application.StartupPath);

            RegisterServices();

            Bootstrap.Complete();
        }

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="e">The e.</param>
        private static void LogError(Exception e)
        {
            if (e != null)
            {
                var log = DIResolver.Get<ILogger>();
                log.Error(e);
                MessageBox.Show(Constants.ErrorMessage, Constants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            InitCulture();

            InitAppConfig();

            InitDI();

            var form = DIResolver.Get<IFormHandler>().GetFormOrDefault<MainForm>();
            Application.Run(form);
        }

        /// <summary>
        /// Registers the services.
        /// </summary>
        private static void RegisterServices()
        {
            var container = DIContainer.Container;

            #region Forms

            container.RegisterWithoutTransientWarning<MainForm>();
            container.RegisterWithoutTransientWarning<DeveloperToolsForm>();
            container.RegisterWithoutTransientWarning<GenericOutputForm>();
            container.RegisterWithoutTransientWarning<NewObjectForm>();
            container.RegisterWithoutTransientWarning<IRangeColorForm, ColorSelectorForm>();

            #endregion Forms

            #region Handlers

            container.RegisterSingleton<IFormHandler, FormHandler>();

            #endregion Handlers

            #region Program Management

            container.Register<IConfiguration, Configuration>();
            container.Register<ILogger, Logger>();

            #endregion Program Management
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