using System;

namespace RayTracing {
    internal static class Program {
        private const int Height = 100;
        private const int Width = 200;

        private static void Main() {
            var frame = new Frame(Width, Height);
            Chapter03.FillFrame(frame);
            using var standardOut = Console.OpenStandardOutput();
            PpmWriter.Write(standardOut, frame);
        }
    }
}
