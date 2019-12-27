using System;
using System.Numerics;
using SystemRandom = System.Random;

namespace RayTracing {
    public static class Random {
        private static readonly SystemRandom R = new SystemRandom();

        public static double NextDouble => R.NextDouble();

        public static Vector3 InUnitSphere() {
            Vector3 result;
            do {
                result = 2.0f * new Vector3((float) NextDouble, (float) NextDouble, (float) NextDouble) - Vector3.One;
            } while(result.LengthSquared() >= 1f);

            return result;
        }

        public static void NextBytes(Span<byte> bytes) => R.NextBytes(bytes);
    }
}
