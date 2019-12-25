using System;
using System.IO;
using System.Text;
using RandyRidge.Common;

namespace RayTracing {
    public static class PpmWriter {
        public static void Write(Stream stream, in Frame frame) {
            stream = Guard.NotNull(stream, nameof(stream));

            using var writer = new StreamWriter(stream, Encoding.ASCII, -1, true);
            var header = "P3\n".AsSpan();
            var space = " ".AsSpan();
            var maxColor = "\n255\n".AsSpan();
            writer.Write(header);
            writer.Write(space);
            writer.Write(frame.Width);
            writer.Write(space);
            writer.Write(frame.Height);
            writer.Write(maxColor);
            for(var i = 0; i < frame.Colors.Count; i++) {
                var color = frame.Colors[i];
                writer.Write(color.Red);
                writer.Write(space);
                writer.Write(color.Green);
                writer.Write(space);
                writer.Write(color.Blue);
                writer.Write('\n');
            }
        }
    }
}
