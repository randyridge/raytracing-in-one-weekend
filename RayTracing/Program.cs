using System;

namespace RayTracing {
    internal static class Program {
        private const int Height = 100;
        private const int Width = 200;

        private static void Main() {
            var buffer = Chapter03.Run(Width, Height);
            using var standardOut = Console.OpenStandardOutput();
            PpmWriter.Write(standardOut, buffer.ToArray(), Width, Height);
        }
    }
}
