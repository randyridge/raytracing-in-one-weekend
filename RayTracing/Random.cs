using System;
using SystemRandom = System.Random;

namespace RayTracing {
    public static class Random {
        private static readonly SystemRandom R = new SystemRandom();

        public static double NextDouble => R.NextDouble();

        public static void NextBytes(Span<byte> bytes) => R.NextBytes(bytes);
    }
}
