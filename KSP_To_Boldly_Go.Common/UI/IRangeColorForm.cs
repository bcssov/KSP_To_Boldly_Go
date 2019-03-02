// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 02-26-2019
//
// Last Modified By : Mario
// Last Modified On : 03-02-2019
// ***********************************************************************
// <copyright file="IRangeColorForm.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

namespace KSP_To_Boldly_Go.Common.UI
{
    /// <summary>
    /// Interface IRangeColorForm
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IRangeColorForm : IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets a value indicating whether this <see cref="IRangeColorForm"/> is disposing.
        /// </summary>
        /// <value><c>true</c> if disposing; otherwise, <c>false</c>.</value>
        bool Disposing { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value><c>true</c> if this instance is disposed; otherwise, <c>false</c>.</value>
        bool IsDisposed { get; }

        /// <summary>
        /// Gets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        Color Max { get; }

        /// <summary>
        /// Gets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        Color Min { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Closes this instance.
        /// </summary>
        void Close();

        /// <summary>
        /// Sets the colors.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        void SetColors(Color min, Color max);

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <returns>DialogResult.</returns>
        DialogResult ShowDialog();

        #endregion Methods
    }
}