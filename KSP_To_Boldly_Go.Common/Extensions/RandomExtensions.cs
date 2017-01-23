// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : stackoverflow.com/questions/6651554/random-number-in-long-range-is-this-the-way
// Created          : 01-23-2017
//
// Last Modified By : Mario
// Last Modified On : 01-23-2017
// ***********************************************************************
// <copyright file="RandomExtensions.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary>stackoverflow.com/questions/6651554/random-number-in-long-range-is-this-the-way</summary>
// ***********************************************************************
using System;

/// <summary>
/// The Extensions namespace.
/// </summary>
namespace KSP_To_Boldly_Go.Common.Extensions
{
    /// <summary>
    /// Class RandomExtensions.
    /// </summary>
    public static class RandomExtensions
    {
        #region Methods

        /// <summary>
        /// Nexts the long.
        /// </summary>
        /// <param name="rng">The RNG.</param>
        /// <returns>System.Int64.</returns>
        public static long NextLong(this Random rng)
        {
            byte[] buf = new byte[8];
            rng.NextBytes(buf);
            return BitConverter.ToInt64(buf, 0);
        }

        /// <summary>
        /// Nexts the long.
        /// </summary>
        /// <param name="rng">The RNG.</param>
        /// <param name="max">The maximum.</param>
        /// <param name="inclusiveUpperBound">if set to <c>true</c> [inclusive upper bound].</param>
        /// <returns>System.Int64.</returns>
        public static long NextLong(this Random rng, long max, bool inclusiveUpperBound = false)
        {
            return rng.NextLong(long.MinValue, max, inclusiveUpperBound);
        }

        /// <summary>
        /// Nexts the long.
        /// </summary>
        /// <param name="rng">The RNG.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <param name="inclusiveUpperBound">if set to <c>true</c> [inclusive upper bound].</param>
        /// <returns>System.Int64.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Max must be greater than min when inclusiveUpperBound is false, and greater than or equal to when true - max</exception>
        public static long NextLong(this Random rng, long min, long max, bool inclusiveUpperBound = false)
        {
            ulong range = (ulong)(max - min);

            if (inclusiveUpperBound)
            {
                if (range == ulong.MaxValue)
                {
                    return rng.NextLong();
                }

                range++;
            }

            if (range <= 0)
            {
                throw new ArgumentOutOfRangeException("Max must be greater than min when inclusiveUpperBound is false, and greater than or equal to when true", "max");
            }

            ulong limit = ulong.MaxValue - ulong.MaxValue % range;
            ulong r;
            do
            {
                r = rng.NextULong();
            } while (r > limit);
            return (long)(r % range + (ulong)min);
        }

        /// <summary>
        /// Nexts the u long.
        /// </summary>
        /// <param name="rng">The RNG.</param>
        /// <returns>System.UInt64.</returns>
        public static ulong NextULong(this Random rng)
        {
            byte[] buf = new byte[8];
            rng.NextBytes(buf);
            return BitConverter.ToUInt64(buf, 0);
        }

        /// <summary>
        /// Nexts the u long.
        /// </summary>
        /// <param name="rng">The RNG.</param>
        /// <param name="max">The maximum.</param>
        /// <param name="inclusiveUpperBound">if set to <c>true</c> [inclusive upper bound].</param>
        /// <returns>System.UInt64.</returns>
        public static ulong NextULong(this Random rng, ulong max, bool inclusiveUpperBound = false)
        {
            return rng.NextULong(ulong.MinValue, max, inclusiveUpperBound);
        }

        /// <summary>
        /// Nexts the u long.
        /// </summary>
        /// <param name="rng">The RNG.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <param name="inclusiveUpperBound">if set to <c>true</c> [inclusive upper bound].</param>
        /// <returns>System.UInt64.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Max must be greater than min when inclusiveUpperBound is false, and greater than or equal to when true - max</exception>
        public static ulong NextULong(this Random rng, ulong min, ulong max, bool inclusiveUpperBound = false)
        {
            ulong range = max - min;

            if (inclusiveUpperBound)
            {
                if (range == ulong.MaxValue)
                {
                    return rng.NextULong();
                }

                range++;
            }

            if (range <= 0)
            {
                throw new ArgumentOutOfRangeException("Max must be greater than min when inclusiveUpperBound is false, and greater than or equal to when true", "max");
            }

            ulong limit = ulong.MaxValue - ulong.MaxValue % range;
            ulong r;
            do
            {
                r = rng.NextULong();
            } while (r > limit);

            return r % range + min;
        }

        #endregion Methods
    }
}