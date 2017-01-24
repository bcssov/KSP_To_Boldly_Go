// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-24-2017
//
// Last Modified By : Mario
// Last Modified On : 01-24-2017
// ***********************************************************************
// <copyright file="RangeType.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace KSP_To_Boldly_Go.Common.Types
{
    /// <summary>
    /// Class RangeType.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="KSP_To_Boldly_Go.Common.Types.IRangeType{T}" />
    public abstract class RangeType<T> : IRangeType<T> where T : IType
    {
        #region Fields

        /// <summary>
        /// The maximum
        /// </summary>
        private T _max;

        /// <summary>
        /// The minimum
        /// </summary>
        private T _min;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public T Max
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
        public T Min
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
                            Max = ParseValue(values[i]);
                            break;

                        default:
                            Min = ParseValue(values[i]);
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
            if (IsNull(Min) && IsNull(Max))
            {
                return string.Empty;
            }
            else if (!IsNull(Min) && IsNull(Max))
            {
                return Min.ToString(random);
            }
            else if (Min.Equals(Max))
            {
                return Min.ToString(random);
            }
            else
            {
                if (random != null)
                {
                    return GetRandomInRange(random).ToString(random);
                }
                else
                {
                    return string.Format("{0} To {1}", Min.ToString(random), Max.ToString(random));
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
        /// Parses the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>T.</returns>
        protected abstract T ParseValue(string value);

        /// <summary>
        /// Validates the maximum.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        protected abstract void ValidateMax(T newValue);

        /// <summary>
        /// Validates the minimum.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        protected abstract void ValidateMin(T newValue);

        /// <summary>
        /// Determines whether the specified value is null.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if the specified value is null; otherwise, <c>false</c>.</returns>
        private bool IsNull(T value)
        {
            return value == null;
        }

        #endregion Methods
    }
}