// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-24-2017
//
// Last Modified By : Mario
// Last Modified On : 01-24-2017
// ***********************************************************************
// <copyright file="RangeColor.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using KSP_To_Boldly_Go.Common.Converters.Serializer;
using KSP_To_Boldly_Go.Common.Extensions;

namespace KSP_To_Boldly_Go.Common.Types
{
    /// <summary>
    /// Class RangeColor.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Types.RangeType{KSP_To_Boldly_Go.Common.Types.Color}" />
    [TypeConverter(typeof(Converters.Object.RangeColorConverter))]
    public class RangeColor : RangeType<Color>
    {
        #region Methods

        /// <summary>
        /// Gets the random in range.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <returns>T.</returns>
        protected override Color GetRandomInRange(Random random)
        {
            return random.NextColor(Min, Max);
        }

        /// <summary>
        /// Parses the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>T.</returns>
        protected override Color ParseValue(string value)
        {
            var handler = DependencyInjection.DIContainer.Container.GetInstance<IConverterHandler>();
            var converter = handler.CreateConverter<Color>();
            return converter.ToObject(value);
        }

        /// <summary>
        /// Validates the maximum.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        protected override void ValidateMax(Color newValue)
        {
            List<string> errors = new List<string>();

            if (newValue.A.GetValueOrDefault() < Min.A.GetValueOrDefault())
            {
                errors.Add("Max value A should be greater than Min value A");
            }
            if (newValue.B.GetValueOrDefault() < Min.B.GetValueOrDefault())
            {
                errors.Add("Max value B should be greater than Min value B");
            }
            if (newValue.G.GetValueOrDefault() < Min.G.GetValueOrDefault())
            {
                errors.Add("Max value G should be greater than Min value G");
            }
            if (newValue.R.GetValueOrDefault() < Min.R.GetValueOrDefault())
            {
                errors.Add("Max value R should be greater than Min value R");
            }
            if (errors.Count > 0)
            {
                throw new ArgumentOutOfRangeException(string.Join(Environment.NewLine, errors));
            }
        }

        /// <summary>
        /// Validates the minimum.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        protected override void ValidateMin(Color newValue)
        {
            if (Max != null)
            {
                List<string> errors = new List<string>();
                if (newValue.A.GetValueOrDefault() > Max.A.GetValueOrDefault())
                {
                    errors.Add("Min value A should be lesser than Max value A");
                }
                if (newValue.B.GetValueOrDefault() > Max.B.GetValueOrDefault())
                {
                    errors.Add("Min value B should be lesser than Max value B");
                }
                if (newValue.G.GetValueOrDefault() > Max.G.GetValueOrDefault())
                {
                    errors.Add("Min value G should be lesser than Max value G");
                }
                if (newValue.R.GetValueOrDefault() > Max.R.GetValueOrDefault())
                {
                    errors.Add("Min value R should be lesser than Max value R");
                }
                if (errors.Count > 0)
                {
                    throw new ArgumentOutOfRangeException(string.Join(Environment.NewLine, errors));
                }
            }
        }

        #endregion Methods
    }
}