// ***********************************************************************
// Assembly         : KSP_To_Boldly_Go.Common
// Author           : Mario
// Created          : 01-23-2017
//
// Last Modified By : Mario
// Last Modified On : 01-24-2017
// ***********************************************************************
// <copyright file="RandomExtensions.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary>
// Various external solutions are used I know, this is due to me being very lazy. Can't say that I actually tested\verified\
// reviewed them, sorry for my laziness.
// </summary>
// ***********************************************************************
using KSP_To_Boldly_Go.Common.Types;
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
        /// Nexts the color.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns>Color.</returns>
        public static Color NextColor(this Random random, Color min, Color max)
        {
            Color color = new Color()
            {
                A = random.NextShort(min.A.GetValueOrDefault(), max.A.GetValueOrDefault()),
                B = random.NextShort(min.B.GetValueOrDefault(), max.B.GetValueOrDefault()),
                G = random.NextShort(min.G.GetValueOrDefault(), max.G.GetValueOrDefault()),
                R = random.NextShort(min.R.GetValueOrDefault(), max.R.GetValueOrDefault())
            };
            return color;
        }

        // Random decimal source: http://stackoverflow.com/questions/609501/generating-a-random-decimal-in-c-sharp
        /// <summary>
        /// Nexts the decimal.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <returns>System.Decimal.</returns>
        public static decimal NextDecimal(this Random random)
        {
            return NextDecimal(random, decimal.MaxValue);
        }

        /// <summary>
        /// Nexts the decimal.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>System.Decimal.</returns>
        public static decimal NextDecimal(this Random random, decimal maxValue)
        {
            return NextDecimal(random, decimal.Zero, maxValue);
        }

        /// <summary>
        /// Nexts the decimal.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>System.Decimal.</returns>
        public static decimal NextDecimal(this Random random, decimal minValue, decimal maxValue)
        {
            var sample = DecimalSample(random);
            return maxValue * sample + minValue * (1 - sample);
        }

        // Random double reference: http://stackoverflow.com/questions/1064901/random-number-between-2-double-numbers
        /// <summary>
        /// Nexts the double.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns>System.Double.</returns>
        public static double NextDouble(this Random random, double min, double max)
        {
            return random.NextDouble() * (max - min) + min;
        }

        /// <summary>
        /// Nexts the float.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns>System.Single.</returns>
        public static float NextFloat(this Random random, float min, float max)
        {
            // Use the same approach as for double, should be safe :/
            return Convert.ToSingle(random.NextDouble()) * (max - min) + min;
        }

        // Random long source: http://stackoverflow.com/questions/6651554/random-number-in-long-range-is-this-the-way
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
        /// Nexts the short.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns>System.Int16.</returns>
        public static short NextShort(this Random random, short min, short max)
        {
            return Convert.ToInt16(random.Next(Convert.ToInt32(min), Convert.ToInt32(max)));
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

        /// <summary>
        /// Decimals the sample.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <returns>System.Decimal.</returns>
        private static decimal DecimalSample(this Random random)
        {
            var sample = 1m;
            while (sample >= 1)
            {
                var a = random.Next();
                var b = random.Next();
                var c = random.Next(542101087);
                sample = new decimal(a, b, c, false, 28);
            }
            return sample;
        }

        #endregion Methods
    }
}