// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 01-22-2017
//
// Last Modified By : Mario
// Last Modified On : 01-22-2017
// ***********************************************************************
// <copyright file="NewObjectForm.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using KSP_To_Boldly_Go_Common.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KSP_To_Boldly_Go.Forms
{
    /// <summary>
    /// Class NewObjectForm.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class NewObjectForm : Form
    {
        #region Fields

        /// <summary>
        /// The data source
        /// </summary>
        private List<string> dataSource;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NewObjectForm" /> class.
        /// </summary>
        public NewObjectForm()
        {
            InitializeComponent();
            dataSource = ModelManager.GetListOfKopernicusObject();
            cbList.DataSource = dataSource;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the type of the selected.
        /// </summary>
        /// <value>The type of the selected.</value>
        public string SelectedType { get; private set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cbList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbList.SelectedValue != null)
            {
                SelectedType = cbList.SelectedValue.ToString();
            }
            else
            {
                SelectedType = string.Empty;
            }
        }

        #endregion Methods
    }
}