// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 02-26-2019
//
// Last Modified By : Mario
// Last Modified On : 02-26-2019
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
    public interface IRangeColorForm
    {
        #region Properties

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