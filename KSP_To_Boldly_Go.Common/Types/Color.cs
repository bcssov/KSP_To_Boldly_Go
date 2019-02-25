// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-23-2017
//
// Last Modified By : Mario
// Last Modified On : 02-25-2019
// ***********************************************************************
// <copyright file="Color.cs" company="Mario">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using KSP_To_Boldly_Go.Common.Converters.Object;

namespace KSP_To_Boldly_Go.Common.Types
{
    /// <summary>
    /// Class Color.
    /// </summary>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Types.IType" />
    [TypeConverter(typeof(ColorConverter))]
    public class Color : IType
    {
        #region Fields

        /// <summary>
        /// The a
        /// </summary>
        private short? _a;

        /// <summary>
        /// The b
        /// </summary>
        private short? _b;

        /// <summary>
        /// The g
        /// </summary>
        private short? _g;

        /// <summary>
        /// The r
        /// </summary>
        private short? _r;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets a.
        /// </summary>
        /// <value>a.</value>
        public short? A
        {
            get
            {
                return _a;
            }
            set
            {
                ValidateEntry("A", value);
                _a = value;
            }
        }

        /// <summary>
        /// Gets or sets the b.
        /// </summary>
        /// <value>The b.</value>
        public short? B
        {
            get
            {
                return _b;
            }
            set
            {
                ValidateEntry("B", value);
                _b = value;
            }
        }

        /// <summary>
        /// Gets or sets the g.
        /// </summary>
        /// <value>The g.</value>
        public short? G
        {
            get
            {
                return _g;
            }
            set
            {
                ValidateEntry("G", value);
                _g = value;
            }
        }

        /// <summary>
        /// Gets or sets the r.
        /// </summary>
        /// <value>The r.</value>
        public short? R
        {
            get
            {
                return _r;
            }
            set
            {
                ValidateEntry("R", value);
                _r = value;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is Color)
            {
                var color = (Color)obj;
                return A.GetValueOrDefault() == color.A.GetValueOrDefault() && R.GetValueOrDefault() == color.R.GetValueOrDefault() && B.GetValueOrDefault() == color.B.GetValueOrDefault() && G.GetValueOrDefault() == color.G.GetValueOrDefault();
            }
            return base.Equals(obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            // A bit of an overhead, however this is not intended to be called too often. Even if it is this app is not something that is intended to be run day and night.
            return new { R, G, B, A }.GetHashCode();
        }

        /// <summary>
        /// Parses the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Parse(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                var values = value.Split(",".ToCharArray(), 4, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < values.Length; i++)
                {
                    switch (i)
                    {
                        case 1:
                            G = Convert.ToInt16(values[i]);
                            break;

                        case 2:
                            B = Convert.ToInt16(values[i]);
                            break;

                        case 3:
                            A = Convert.ToInt16(values[i]);
                            break;

                        default:
                            R = Convert.ToInt16(values[i]);
                            break;
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return ToString(null);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public string ToString(Random random)
        {
            if (random != null)
            {
                return $"{Math.Round(Convert.ToDouble(R.GetValueOrDefault()) / 255D, 2).ToString()}," +
                    $"{Math.Round(Convert.ToDouble(G.GetValueOrDefault()) / 255D, 2).ToString()}," +
                    $"{Math.Round(Convert.ToDouble(B.GetValueOrDefault()) / 255D, 2).ToString()}," +
                    $"{Math.Round(Convert.ToDouble(A.GetValueOrDefault()) / 255D, 2).ToString()}";
            }
            else
            {
                if (!R.HasValue && !G.HasValue && !B.HasValue && !A.HasValue)
                {
                    return string.Empty;
                }

                List<int> vals = new List<int>();
                vals.Add(R.GetValueOrDefault());
                vals.Add(G.GetValueOrDefault());
                vals.Add(B.GetValueOrDefault());
                vals.Add(A.GetValueOrDefault());
                return string.Join(",", vals);
            }
        }

        /// <summary>
        /// Validates the entry.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        private void ValidateEntry(string property, int? value)
        {
            if (value.GetValueOrDefault() < 0 || value.GetValueOrDefault() > 255)
            {
                throw new ArgumentOutOfRangeException($"Invalid value {property} for {value.GetValueOrDefault()}");
            }
        }

        #endregion Methods
    }
}