// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-23-2017
//
// Last Modified By : Mario
// Last Modified On : 01-23-2017
// ***********************************************************************
// <copyright file="Color.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using KSP_To_Boldly_Go.Common.Converters.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace KSP_To_Boldly_Go.Common.Types
{
    /// <summary>
    /// Class Color.
    /// </summary>
    [TypeConverter(typeof(ColorConverter))]
    public class Color
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

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Color" /> class.
        /// </summary>
        public Color() : this(string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Color" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Color(string value)
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
            }
        }

        #endregion Constructors

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
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
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

        /// <summary>
        /// Validates the entry.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        private void ValidateEntry(string property, int? value)
        {
            if (value.GetValueOrDefault() < 0 || value.GetValueOrDefault() > 255)
            {
                throw new ArgumentOutOfRangeException(string.Format("Invalid value {0} for {1}", property, value.GetValueOrDefault()));
            }
        }

        #endregion Methods
    }
}