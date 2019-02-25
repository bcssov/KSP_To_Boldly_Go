﻿// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 02-25-2019
//
// Last Modified By : Mario
// Last Modified On : 02-25-2019
// ***********************************************************************
// <copyright file="RangeColorEditor.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using KSP_To_Boldly_Go.Common.Types;

namespace KSP_To_Boldly_Go.Common.UI
{
    /// <summary>
    /// Class RangeColorEditor.
    /// </summary>
    /// <seealso cref="System.Drawing.Design.UITypeEditor" />
    public class RangeColorEditor : UITypeEditor
    {
        #region Methods

        /// <summary>
        /// Edits the specified object's value using the editor style indicated by the <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle" /> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <param name="provider">An <see cref="T:System.IServiceProvider" /> that this editor can use to obtain services.</param>
        /// <param name="value">The object to edit.</param>
        /// <returns>The new value of the object. If the value of the object has not changed, this should return the same object it was passed.</returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            RangeColor rangeColor;
            if (value != null)
            {
                rangeColor = (RangeColor)value;
            }
            else
            {
                rangeColor = new RangeColor();
            }
            var colorDialogMin = InitColorDialog(rangeColor.Min, "Min Color");
            var colorDialogMax = InitColorDialog(rangeColor.Max, "Max Color");

            var minColor = MapColorDialog(colorDialogMin);
            var maxColor = MapColorDialog(colorDialogMax);
            if (minColor != null)
            {
                rangeColor.Min = minColor;
            }
            if (maxColor != null)
            {
                rangeColor.Max = maxColor;
            }

            return rangeColor;
        }

        /// <summary>
        /// Gets the editor style used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)" /> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <returns>A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle" /> value that indicates the style of editor used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)" /> method. If the <see cref="T:System.Drawing.Design.UITypeEditor" /> does not support this method, then <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle" /> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None" />.</returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        /// <summary>
        /// Initializes the color dialog.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="title">The title.</param>
        /// <returns>ColorDialog.</returns>
        private ColorDialog InitColorDialog(Color color, string title)
        {
            var colorDialog = new ColorDialog
            {
                Color = color != null ? System.Drawing.Color.FromArgb(color.A.GetValueOrDefault(), color.R.GetValueOrDefault(), color.G.GetValueOrDefault(), color.B.GetValueOrDefault()) : System.Drawing.Color.Empty,
                Title = title
            };
            return colorDialog;
        }

        /// <summary>
        /// Maps the color dialog.
        /// </summary>
        /// <param name="dialog">The dialog.</param>
        /// <returns>Color.</returns>
        private Color MapColorDialog(ColorDialog dialog)
        {
            if (dialog.ShowDialog() == DialogResult.OK && dialog.Color != System.Drawing.Color.Empty)
            {
                return new Color()
                {
                    A = dialog.Color.A,
                    B = dialog.Color.B,
                    G = dialog.Color.G,
                    R = dialog.Color.R
                };
            }
            return null;
        }

        #endregion Methods
    }
}