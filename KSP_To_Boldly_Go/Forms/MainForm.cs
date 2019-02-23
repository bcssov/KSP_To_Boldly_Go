// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 02-23-2019
// ***********************************************************************
// <copyright file="MainForm.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms;
using KSP_To_Boldly_Go.DIConfig;

namespace KSP_To_Boldly_Go.Forms
{
    /// <summary>
    /// Class MainForm.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MainForm : Form
    {
        #region Fields

        /// <summary>
        /// The configuration
        /// </summary>
        private Configuration config;

        /// <summary>
        /// The form
        /// </summary>
        private DeveloperToolsForm form;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm" /> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public MainForm(Configuration config)
        {
            this.config = config;
            InitializeComponent();
            Initialize();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Handles the Click event of the btnDevMode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnDevMode_Click(object sender, EventArgs e)
        {
            if (form == null || form.IsDisposed || form.Disposing)
            {
                Hide();
                form = DIResolver.Get<DeveloperToolsForm>();
                form.FormClosed += DeveloperForm_FormClosed;
                form.Show(this);
            }
        }

        /// <summary>
        /// Handles the FormClosed event of the Form control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosedEventArgs" /> instance containing the event data.</param>
        private void DeveloperForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Show();
            form.FormClosed -= DeveloperForm_FormClosed;
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Initialize()
        {
            btnDevMode.Visible = config.DevMode;
            Common.Startup.Initialize();
        }

        /// <summary>
        /// Handles the Load event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        #endregion Methods
    }
}