// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 02-25-2019
//
// Last Modified By : Mario
// Last Modified On : 02-26-2019
// ***********************************************************************
// <copyright file="ColorDialog.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace KSP_To_Boldly_Go.Common.UI
{
    // Src: https://stackoverflow.com/questions/762009/how-do-i-change-the-title-of-colordialog
    /// <summary>
    /// Class ColorDialog.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ColorDialog" />
    /// <seealso cref="KSP_To_Boldly_Go.Common.UI.ColorDialog" />
    public class ColorDialog : System.Windows.Forms.ColorDialog
    {
        #region Fields

        /// <summary>
        /// The title
        /// </summary>
        private string title = string.Empty;

        /// <summary>
        /// The title set
        /// </summary>
        private bool titleSet = false;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (value != null && value != title)
                {
                    title = value;
                    titleSet = false;
                }
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Hooks the proc.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="msg">The MSG.</param>
        /// <param name="wparam">The wparam.</param>
        /// <param name="lparam">The lparam.</param>
        /// <returns>IntPtr.</returns>
        protected override IntPtr HookProc(IntPtr hWnd, int msg, IntPtr wparam, IntPtr lparam)
        {
            if (!titleSet)
            {
                NativeMethods.SetWindowText(hWnd, title);
                titleSet = true;
            }

            return base.HookProc(hWnd, msg, wparam, lparam);
        }

        #endregion Methods
    }
}