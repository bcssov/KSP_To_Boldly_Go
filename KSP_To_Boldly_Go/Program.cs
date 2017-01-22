// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-21-2017
// ***********************************************************************
// <copyright file="Program.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using KSP_To_Boldly_Go.Forms;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

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
        /// <param name="e">The <see cref="ThreadExceptionEventArgs"/> instance containing the event data.</param>
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Log.Error(e.Exception);
            MessageBox.Show("Unhandled error occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Handles the UnhandledException event of the CurrentDomain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="UnhandledExceptionEventArgs"/> instance containing the event data.</param>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception)
            {
                Log.Error((Exception)e.ExceptionObject);
                MessageBox.Show("Unhandled error occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
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
    }
}