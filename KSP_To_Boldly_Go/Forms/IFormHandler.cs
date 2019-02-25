// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 02-23-2019
//
// Last Modified By : Mario
// Last Modified On : 02-24-2019
// ***********************************************************************
// <copyright file="IFormOpener.cs" company="Mario">
//     Copyright ©  2017-2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms;

/// <summary>
/// The Forms namespace.
/// </summary>
namespace KSP_To_Boldly_Go.Forms
{
    /// <summary>
    /// Interface IFormHandler
    /// </summary>
    public interface IFormHandler
    {
        #region Methods

        /// <summary>
        /// Creates the form.
        /// </summary>
        /// <typeparam name="TForm">The type of the t form.</typeparam>
        /// <returns>TForm.</returns>
        TForm CreateForm<TForm>() where TForm : Form;

        /// <summary>
        /// Gets the form or default.
        /// </summary>
        /// <typeparam name="TForm">The type of the t form.</typeparam>
        /// <returns>TForm.</returns>
        TForm GetFormOrDefault<TForm>() where TForm : Form;

        /// <summary>
        /// Gets the open form.
        /// </summary>
        /// <typeparam name="TForm">The type of the t form.</typeparam>
        /// <returns>TForm.</returns>
        TForm GetOpenForm<TForm>() where TForm : Form;

        #endregion Methods
    }
}