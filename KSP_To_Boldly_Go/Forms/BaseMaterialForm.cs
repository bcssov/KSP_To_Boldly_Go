// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 02-26-2019
//
// Last Modified By : Mario
// Last Modified On : 02-27-2019
// ***********************************************************************
// <copyright file="BaseMaterialForm.cs" company="Mario">
//     Copyright ©  2017-2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using MaterialSkin;
using MaterialSkin.Controls;

namespace KSP_To_Boldly_Go.Forms
{
    /// <summary>
    /// Class BaseMaterialForm.
    /// </summary>
    /// <seealso cref="MaterialSkin.Controls.MaterialForm" />
    /// <seealso cref="MaterialForm" />
    public class BaseMaterialForm : MaterialForm
    {
        #region Fields

        /// <summary>
        /// The configuration
        /// </summary>
        protected IConfiguration configuration;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseMaterialForm" /> class.
        /// </summary>
        public BaseMaterialForm()
        {
            Init();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseMaterialForm" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public BaseMaterialForm(IConfiguration configuration)
        {
            this.configuration = configuration;
            Init();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Initializes the form.
        /// </summary>
        protected void InitForm()
        {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            if (configuration != null)
            {
                Icon = configuration.AppIcon;
            }
        }

        /// <summary>
        /// Initializes the skin.
        /// </summary>
        protected void InitSkin()
        {
            if (configuration != null)
            {
                var materialSkinManager = MaterialSkinManager.Instance;
                materialSkinManager.AddFormToManage(this);
                materialSkinManager.Theme = configuration.Theme == Theme.Dark ? MaterialSkinManager.Themes.DARK : MaterialSkinManager.Themes.LIGHT;
                materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Load" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitSkin();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Init()
        {
            InitForm();
        }

        #endregion Methods
    }
}