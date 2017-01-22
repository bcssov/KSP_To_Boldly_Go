// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 01-22-2017
//
// Last Modified By : Mario
// Last Modified On : 01-22-2017
// ***********************************************************************
// <copyright file="SerializationTestOutput.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms;

namespace KSP_To_Boldly_Go.Forms
{
    /// <summary>
    /// Class SerializationTestOutput.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class SerializationTestOutputForm : Form
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SerializationTestOutputForm"/> class.
        /// </summary>
        /// <param name="content">The content.</param>
        public SerializationTestOutputForm(string content)
        {
            InitializeComponent();
            txtOutput.Text = content;
        }

        #endregion Constructors
    }
}