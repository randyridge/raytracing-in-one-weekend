using System;
using System.IO;
using RayTracing.Chapters;
using SharpSharp;

namespace RayTracing {
    internal static class Program {
        private const int Height = 800;
        private const int Width = 1200;

        private static void Main() {
            var frame = new Frame(Width, Height);

            Chapter13.FillFrame(frame);

            using var standardOut = Console.OpenStandardOutput();
            PpmWriter.Write(standardOut, frame);

            //using var ms = new MemoryStream();
            //PpmWriter.Write(ms, frame);

            //ms.Position = 0;

            //ImagePipeline.FromImage(PpmReader.ImageFromPpm(ms))
            //    .Png()
            //    .ToFile("raytracing-in-one-weekend.png");
        }
    }
}
