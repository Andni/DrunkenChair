using System;

namespace Niklasson.EonIV.Models
{
    public static class RandomNumberGenerator
    {
        private static readonly Random rng = new Random();

        public static int Next()
        {
            return rng.Next();
        }

        public static int Next(int maxValue)
        {
            return rng.Next(maxValue);
        }

        public static int Next(int minValue, int maxValue)
        {
            return rng.Next(minValue, maxValue);
        }

    }
}
