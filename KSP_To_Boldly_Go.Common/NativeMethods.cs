// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 02-26-2019
//
// Last Modified By : Mario
// Last Modified On : 02-26-2019
// ***********************************************************************
// <copyright file="NativeMethods.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Runtime.InteropServices;

namespace KSP_To_Boldly_Go.Common
{
    /// <summary>
    /// Class NativeMethods.
    /// </summary>
    internal static class NativeMethods
    {
        #region Methods

        /// <summary>
        /// Sets the window text.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="lpString">The lp string.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        internal static extern bool SetWindowText(IntPtr hWnd, string lpString);

        #endregion Methods
    }
}