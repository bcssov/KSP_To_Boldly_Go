// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-23-2017
//
// Last Modified By : Mario
// Last Modified On : 01-23-2017
// ***********************************************************************
// <copyright file="RangeLong.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace KSP_To_Boldly_Go.Common.Types
{
    /// <summary>
    /// Class RangeNumber.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Types.IRangeNumber{T}" />
    public abstract class RangeNumber<T> : IRangeNumber<T> where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {
        #region Fields

        /// <summary>
        /// The maximum
        /// </summary>
        private T? _max;

        /// <summary>
        /// The minimum
        /// </summary>
        private T? _min;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public T? Max
        {
            get
            {
                return _max;
            }
            set
            {
                ValidateMax(value);
                _max = value;
            }
        }

        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        public T? Min
        {
            get
            {
                return _min;
            }
            set
            {
                ValidateMin(value);
                _min = value;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Sets the values.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetValues(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                var values = value.ToLowerInvariant().Split("to".ToCharArray(), 2, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < values.Length; i++)
                {
                    switch (i)
                    {
                        case 1:
                            Max = ParseMin(values[i]);
                            break;

                        default:
                            Min = ParseMax(values[i]);
                            break;
                    }
                }
            }
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
        public virtual string ToString(Random random)
        {
            if (!Min.HasValue && !Max.HasValue)
            {
                return string.Empty;
            }
            else if (Min.HasValue && !Max.HasValue)
            {
                return Min.GetValueOrDefault().ToString();
            }
            else if (Min.GetValueOrDefault().Equals(Max.GetValueOrDefault()))
            {
                return Min.GetValueOrDefault().ToString();
            }
            else
            {
                if (random != null)
                {
                    return GetRandomInRange(random).ToString();
                }
                else
                {
                    return string.Format("{0} To {1}", Min.GetValueOrDefault(), Max.GetValueOrDefault());
                }
            }
        }

        /// <summary>
        /// Gets the random in range.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <returns>T.</returns>
        protected abstract T GetRandomInRange(Random random);

        /// <summary>
        /// Parses the maximum.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Nullable&lt;T&gt;.</returns>
        protected abstract T? ParseMax(string value);

        /// <summary>
        /// Parses the minimum.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Nullable&lt;T&gt;.</returns>
        protected abstract T? ParseMin(string value);

        /// <summary>
        /// Validates the maximum.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        protected abstract void ValidateMax(T? newValue);

        /// <summary>
        /// Validates the minimum.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        protected abstract void ValidateMin(T? newValue);

        #endregion Methods
    }
}