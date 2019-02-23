﻿// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 01-22-2017
//
// Last Modified By : Mario
// Last Modified On : 02-23-2019
// ***********************************************************************
// <copyright file="SerializationTestOutput.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms;

namespace KSP_To_Boldly_Go.Forms
{
    /// <summary>
    /// Class GenericOutputForm.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class GenericOutputForm : Form
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericOutputForm" /> class.
        /// </summary>
        public GenericOutputForm()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Sets the content.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="content">The content.</param>
        public void SetContent(string title, string content)
        {
            Text = title;
            txtOutput.Text = content;
        }

        #endregion Methods
    }
}