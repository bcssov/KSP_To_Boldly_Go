// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 01-22-2017
//
// Last Modified By : Mario
// Last Modified On : 02-25-2019
// ***********************************************************************
// <copyright file="NewObjectForm.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using KSP_To_Boldly_Go.Common;

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

        /// <summary>
        /// The handler factory
        /// </summary>
        private IHandlerFactory handlerFactory;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NewObjectForm" /> class.
        /// </summary>
        /// <param name="handlerFactory">The handler factory.</param>
        public NewObjectForm(IHandlerFactory handlerFactory)
        {
            InitializeComponent();
            this.handlerFactory = handlerFactory;
            InitDataSource();
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
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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

        /// <summary>
        /// Initializes the data source.
        /// </summary>
        private void InitDataSource()
        {
            dataSource = handlerFactory.CreateModelHandler().GetOrderedRootObjectNames().ToList();
            cbList.DataSource = dataSource;
        }

        #endregion Methods
    }
}