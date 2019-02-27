// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 02-26-2019
//
// Last Modified By : Mario
// Last Modified On : 02-27-2019
// ***********************************************************************
// <copyright file="BaseStaticMaterialForm.cs" company="Mario">
//     Copyright ©  2017-2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace KSP_To_Boldly_Go.Forms
{
    /// <summary>
    /// Class BaseStaticMaterialForm.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Forms.BaseMaterialForm" />
    public class BaseStaticMaterialForm : BaseMaterialForm
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseStaticMaterialForm" /> class.
        /// </summary>
        public BaseStaticMaterialForm()
        {
            Init();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseStaticMaterialForm" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public BaseStaticMaterialForm(IConfiguration configuration) : base(configuration)
        {
            Init();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Initializes the form.
        /// </summary>
        protected new void InitForm()
        {
            base.InitForm();
            MaximizeBox = false;
            MinimizeBox = false;
            ShowIcon = false;
            ShowInTaskbar = false;
            Sizable = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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