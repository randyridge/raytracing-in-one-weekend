using System;
using RayTracing.Chapters;

namespace RayTracing {
    internal static class Program {
        private const int Height = 800;
        private const int Width = 1200;

        private static void Main() {
            var frame = new Frame(Width, Height);
            Chapter13.FillFrame(frame);
            using var standardOut = Console.OpenStandardOutput();
            PpmWriter.Write(standardOut, frame);
        }
    }
}
