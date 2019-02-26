// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 01-20-2017
//
// Last Modified By : Mario
// Last Modified On : 02-24-2019
// ***********************************************************************
// <copyright file="MainForm.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms;
using KSP_To_Boldly_Go.Common;
using Newtonsoft.Json;

namespace KSP_To_Boldly_Go.Forms
{
    /// <summary>
    /// Class MainForm.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Forms.BaseMaterialForm" />
    public partial class MainForm : BaseMaterialForm
    {
        #region Fields

        /// <summary>
        /// The configuration
        /// </summary>
        private IConfiguration config;

        /// <summary>
        /// The form handler
        /// </summary>
        private IFormHandler formHandler;

        /// <summary>
        /// The json settings
        /// </summary>
        private IJsonSerializerSettings jsonSettings;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm" /> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="formHandler">The form handler.</param>
        /// <param name="jsonSettings">The json settings.</param>
        public MainForm(IConfiguration config, IFormHandler formHandler, IJsonSerializerSettings jsonSettings)
        {
            this.config = config;
            this.formHandler = formHandler;
            this.jsonSettings = jsonSettings;
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
            var form = formHandler.GetFormOrDefault<DeveloperToolsForm>();
            if (!form.Visible || form.Disposing || form.IsDisposed)
            {
                Hide();
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
            var form = formHandler.GetFormOrDefault<DeveloperToolsForm>();
            Show();
            form.FormClosed -= DeveloperForm_FormClosed;
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Initialize()
        {
            btnDevMode.Visible = config.DevMode;
            JsonConvert.DefaultSettings = () => { return jsonSettings.GetSettings(); };
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