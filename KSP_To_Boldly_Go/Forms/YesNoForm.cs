// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 02-26-2019
//
// Last Modified By : Mario
// Last Modified On : 02-28-2019
// ***********************************************************************
// <copyright file="YesNoForm.cs" company="Mario">
//     Copyright ©  2017-2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace KSP_To_Boldly_Go.Forms
{
    /// <summary>
    /// Enum SelectedOption
    /// </summary>
    public enum SelectedOption
    {
        /// <summary>
        /// The none
        /// </summary>
        None,

        /// <summary>
        /// The yes
        /// </summary>
        Yes,

        /// <summary>
        /// The no
        /// </summary>
        No
    }

    /// <summary>
    /// Class YesNoForm.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Forms.BaseStaticMaterialForm" />
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class YesNoForm : BaseStaticMaterialForm
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="YesNoForm" /> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public YesNoForm(IConfiguration config) : base(config)
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
        /// <param name="selectedOption">The selected option.</param>
        public void SetContent(string title, string message, SelectedOption selectedOption)
        {
            Text = title;
            labMessage.Text = message;
            switch (selectedOption)
            {
                case SelectedOption.Yes:
                    btnYes.Select();
                    break;

                case SelectedOption.No:
                    btnNo.Select();
                    break;

                default:
                    Select();
                    break;
            }
        }

        #endregion Methods
    }
}