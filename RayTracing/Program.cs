using System;

namespace RayTracing {
    internal static class Program {
        private const int Height = 100;
        private const int Width = 200;

        private static void Main() {
            using var standardOut = Console.OpenStandardOutput();
            Chapter03.Run(standardOut, Width, Height);
        }
    }
}
