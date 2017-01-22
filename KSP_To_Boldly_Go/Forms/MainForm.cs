// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 01-22-2017
// ***********************************************************************
// <copyright file="MainForm.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms;

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
        /// The form
        /// </summary>
        private DeveloperToolsForm form;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm" /> class.
        /// </summary>
        public MainForm()
        {
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
                form = new DeveloperToolsForm();
                form.FormClosed += DeveloperForm_FormClosed;
                form.Show(this);
            }
        }

        /// <summary>
        /// Handles the FormClosed event of the Form control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosedEventArgs"/> instance containing the event data.</param>
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
            btnDevMode.Visible = Configuration.DevMode;
            KSP_To_Boldly_Go.Common.Startup.Initialize();
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