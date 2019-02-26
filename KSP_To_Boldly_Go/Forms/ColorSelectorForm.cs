// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 02-26-2019
//
// Last Modified By : Mario
// Last Modified On : 02-26-2019
// ***********************************************************************
// <copyright file="ColorSelectorForm.cs" company="Mario">
//     Copyright ©  2017-2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;
using KSP_To_Boldly_Go.Common.UI;

namespace KSP_To_Boldly_Go.Forms
{
    /// <summary>
    /// Class ColorSelectorForm.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    /// <seealso cref="KSP_To_Boldly_Go.Common.UI.IRangeColorForm" />
    public partial class ColorSelectorForm : Form, IRangeColorForm
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorSelectorForm" /> class.
        /// </summary>
        public ColorSelectorForm()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public Color Max => pbMax.BackColor;

        /// <summary>
        /// Gets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        public Color Min => pbMin.BackColor;

        #endregion Properties

        #region Methods

        /// <summary>
        /// Sets the colors.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public void SetColors(Color min, Color max)
        {
            pbMax.BackColor = max;
            pbMin.BackColor = min;
            txtMin.Text = min.ToString();
            txtMax.Text = max.ToString();
        }

        /// <summary>
        /// Handles the Click event of the btnMax control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnMax_Click(object sender, EventArgs e)
        {
            SetColorSelection(maxColor, pbMax, txtMax);
        }

        /// <summary>
        /// Handles the Click event of the btnMin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnMin_Click(object sender, EventArgs e)
        {
            SetColorSelection(minColor, pbMin, txtMin);
        }

        /// <summary>
        /// Sets the color selection.
        /// </summary>
        /// <param name="colorDialog">The color dialog.</param>
        /// <param name="pb">The pb.</param>
        /// <param name="txt">The text.</param>
        private void SetColorSelection(Common.UI.ColorDialog colorDialog, PictureBox pb, TextBox txt)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pb.BackColor = colorDialog.Color;
                txt.Text = pb.BackColor.ToString();
            }
        }

        #endregion Methods
    }
}