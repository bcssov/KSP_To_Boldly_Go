// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 02-26-2019
//
// Last Modified By : Mario
// Last Modified On : 02-26-2019
// ***********************************************************************
// <copyright file="YesNoForm.cs" company="Mario">
//     Copyright ©  2017-2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms;

namespace KSP_To_Boldly_Go.Forms
{
    /// <summary>
    /// Class YesNoForm.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class YesNoForm : BaseStaticMaterialForm
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="YesNoForm"/> class.
        /// </summary>
        public YesNoForm()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Sets the content.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="yesSelected">if set to <c>true</c> [yes selected].</param>
        public void SetContent(string title, string message, bool yesSelected = true)
        {
            Text = title;
            labMessage.Text = message;
            if (yesSelected)
            {
                btnYes.Select();
            }
            else
            {
                btnNo.Select();
            }
        }

        #endregion Methods
    }
}