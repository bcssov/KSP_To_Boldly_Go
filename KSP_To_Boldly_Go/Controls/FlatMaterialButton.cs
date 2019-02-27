// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 02-27-2019
//
// Last Modified By : Mario
// Last Modified On : 02-27-2019
// ***********************************************************************
// <copyright file="MaterialButton.cs" company="Mario">
//     Copyright ©  2017-2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace KSP_To_Boldly_Go.Controls
{
    /// <summary>
    /// Class FlatMaterialButton.
    /// </summary>
    /// <seealso cref="MaterialSkin.Controls.MaterialFlatButton" />
    public class FlatMaterialButton : MaterialSkin.Controls.MaterialFlatButton
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FlatMaterialButton"/> class.
        /// </summary>
        public FlatMaterialButton()
        {
            AutoSize = false;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
        }

        #endregion Constructors
    }
}