// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 02-26-2019
//
// Last Modified By : Mario
// Last Modified On : 02-26-2019
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
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseMaterialForm"/> class.
        /// </summary>
        public BaseMaterialForm()
        {
            InitSkin();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Initializes the skin.
        /// </summary>
        private void InitSkin()
        {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        #endregion Methods
    }
}