// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 02-27-2019
//
// Last Modified By : Mario
// Last Modified On : 02-27-2019
// ***********************************************************************
// <copyright file="RaisedMaterialButton.cs" company="Mario">
//     Copyright ©  2017-2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace KSP_To_Boldly_Go.Controls
{
    /// <summary>
    /// Class RaisedMaterialButton.
    /// </summary>
    /// <seealso cref="MaterialSkin.Controls.MaterialRaisedButton" />
    public class RaisedMaterialButton : MaterialSkin.Controls.MaterialRaisedButton
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RaisedMaterialButton" /> class.
        /// </summary>
        public RaisedMaterialButton()
        {
            AutoSize = false;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
        }

        #endregion Constructors
    }
}