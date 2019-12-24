using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using RandyRidge.Common;

namespace RayTracing {
    public static class PpmWriter {
        public static void Write(Stream stream, IReadOnlyCollection<Color> colors, int width, int height) {
            stream = Guard.NotNull(stream, nameof(stream));
            colors = Guard.NotNull(colors, nameof(colors));
            Guard.MinimumInclusive(width, 1, nameof(width));
            Guard.MinimumInclusive(height, 1, nameof(height));

            using var writer = new StreamWriter(stream, Encoding.ASCII, -1, true);
            var header = "P3\n".AsSpan();
            var space = " ".AsSpan();
            var maxColor = "\n255\n".AsSpan();
            writer.Write(header);
            writer.Write(space);
            writer.Write(width);
            writer.Write(space);
            writer.Write(height);
            writer.Write(maxColor);
            foreach(var color in colors) {
                writer.Write(color.Red);
                writer.Write(space);
                writer.Write(color.Green);
                writer.Write(space);
                writer.Write(color.Blue);
                writer.Write('\n');
            }
        }

        public static void WriteOld(Stream stream, IEnumerable<Color> colors, int width, int height) {
            Guard.NotNull(stream, nameof(stream));
            colors = Guard.NotNull(colors, nameof(colors));
            Guard.MinimumInclusive(width, 1, nameof(width));
            Guard.MinimumInclusive(height, 1, nameof(height));
            using var streamWriter = new StreamWriter(stream, Encoding.ASCII, -1, true);
            streamWriter.Write($"P3\n {width} {height}\n255\n");
            foreach(var color in colors) {
                streamWriter.Write($"{color.Red} {color.Green} {color.Blue}\n");
            }
        }
    }
}
