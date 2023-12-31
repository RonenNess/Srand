﻿
namespace Srand
{
    /// <summary>
    /// Used to generate consistent random numbers across all platforms and .net versions.
    /// Note: this class is not thread-safe.
    /// </summary>
    public class SeededRandom : Random
    {
        private const long Multiplier = 6364136223846793005L;
        private const long Increment = 1442695040888963407L;
        private const long Modulus = long.MaxValue;

        private long _seed;

        /// <summary>
        /// Create the seeded random generator.
        /// </summary>
        /// <param name="seed">Seed to use for random numbers. Random generators with the same seed will always output the same results.</param>
        public SeededRandom(uint seed = 0)
        {
            _seed = seed;
        }

        /// <summary>
        /// Create the seeded random generator.
        /// </summary>
        /// <param name="seed">Seed to use for random numbers. Random generators with the same seed will always output the same results.</param>
        public SeededRandom(int seed = 0)
        {
            _seed = seed;
        }

        /// <summary>
        /// Create the seeded random generator.
        /// </summary>
        /// <param name="seed">Seed to use for random numbers. Random generators with the same seed will always output the same results.</param>
        public SeededRandom(long seed = 0)
        {
            _seed = seed;
        }

        /// <summary>
        /// Pick a random value from a list.
        /// </summary>
        /// <typeparam name="T">List element type.</typeparam>
        /// <param name="list">List to pick from.</param>
        /// <returns>Random value from list.</returns>
        public T Pick<T>(IList<T> list)
        {
            return list[Next(list.Count)];
        }

        /// <summary>
        /// Pick a random value from an array.
        /// </summary>
        /// <typeparam name="T">Array element type.</typeparam>
        /// <param name="arr">Array to pick from.</param>
        /// <returns>Random value from array.</returns>
        public T Pick<T>(T[] arr)
        {
            return arr[Next(arr.Length)];
        }

        /// <summary>
        /// Generate and return a random integer value, ranging from 0 (inclusive) to uint.MaxValue (exclusive).
        /// </summary>
        /// <returns>Random uint value.</returns>
        public uint NextUint()
        {
            return (uint)(Sample() * uint.MaxValue);
        }

        /// <inheritdoc/>
        public override int Next()
        {
            return (int)(Sample() * int.MaxValue);
        }

        /// <inheritdoc/>
        protected override double Sample()
        {
            _seed = (Multiplier * _seed + Increment) % Modulus;
            return (_seed & long.MaxValue) / (double)long.MaxValue;
        }

        /// <summary>
        /// Create and return an array of bytes with random values.
        /// </summary>
        /// <param name="count">Returned buffer size.</param>
        /// <returns>Random bytes array.</returns>
        public byte[] NextBytes(int count)
        {
            var ret = new byte[count];
            NextBytes(ret);
            return ret;
        }
    }
}
