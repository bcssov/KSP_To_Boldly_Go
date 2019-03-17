// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go
// Author           : Mario
// Created          : 02-26-2019
//
// Last Modified By : Mario
// Last Modified On : 03-17-2019
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
    /// <seealso cref="KSP_To_Boldly_Go.Forms.BaseStaticMaterialForm" />
    /// <seealso cref="KSP_To_Boldly_Go.Common.UI.IRangeColorForm" />
    public partial class ColorSelectorForm : BaseStaticMaterialForm, IRangeColorForm
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorSelectorForm" /> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public ColorSelectorForm(IConfiguration config) : base(config)
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public Color Max { get; set; } = Color.Empty;

        /// <summary>
        /// Gets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        public Color Min { get; set; } = Color.Empty;

        #endregion Properties

        #region Methods

        /// <summary>
        /// Sets the colors.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public void SetColors(Color min, Color max)
        {
            Max = pbMax.BackColor = max;
            Min = pbMin.BackColor = min;
            txtMin.Text = FormatColorString(min);
            txtMax.Text = FormatColorString(max);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Load" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            pbMax.BackColor = Max;
            pbMin.BackColor = Min;
        }

        /// <summary>
        /// Handles the Click event of the btnMax control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnMax_Click(object sender, EventArgs e)
        {
            SetColorSelection(maxColor, pbMax, txtMax, false);
        }

        /// <summary>
        /// Handles the Click event of the btnMin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnMin_Click(object sender, EventArgs e)
        {
            SetColorSelection(minColor, pbMin, txtMin, true);
        }

        /// <summary>
        /// Formats the color string.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>System.String.</returns>
        private string FormatColorString(Color color)
        {
            return $"R:{color.R}, G:{color.G}, B:{color.B}, A:{color.A}";
        }

        /// <summary>
        /// Sets the color selection.
        /// </summary>
        /// <param name="colorDialog">The color dialog.</param>
        /// <param name="pb">The pb.</param>
        /// <param name="txt">The text.</param>
        /// <param name="isMin">if set to <c>true</c> [is minimum].</param>
        private void SetColorSelection(Common.UI.ColorDialog colorDialog, PictureBox pb, MaterialSkin.Controls.MaterialSingleLineTextField txt, bool isMin)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                if (isMin)
                {
                    Min = colorDialog.Color;
                }
                else
                {
                    Max = colorDialog.Color;
                }
                pb.BackColor = colorDialog.Color;
                txt.Text = FormatColorString(pb.BackColor);
            }
        }

        #endregion Methods
    }
}