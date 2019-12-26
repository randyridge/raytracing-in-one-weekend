using System;
using System.Globalization;
using System.IO;
using System.Text;
using RandyRidge.Common;

namespace RayTracing {
    public static class PpmReader {
        // TODO: spanify
        public static Frame Read(Stream stream) {
            Guard.NotNull(stream, nameof(stream));
            using var reader = new StreamReader(stream, Encoding.ASCII, false, -1, true);

            var header = reader.ReadLine();
            if(header != "P3") {
                throw new Exception("Unknown header.");
            }

            var width = 0;
            var height = 0;
            var resolutionLine = reader.ReadLine();
            if(resolutionLine != null && resolutionLine.Contains(" ", StringComparison.OrdinalIgnoreCase)) {
                var split = resolutionLine.Split(" ");
                width = int.Parse(split[0], CultureInfo.InvariantCulture);
                height = int.Parse(split[1], CultureInfo.InvariantCulture);
            }

            var _ = reader.ReadLine();

            var frame = new Frame(width, height);
            string? line;
            while((line = reader.ReadLine()) != null) {
                var split = line.Split(" ");
                frame.AddColor(new Color(byte.Parse(split[0], CultureInfo.InvariantCulture), byte.Parse(split[1], CultureInfo.InvariantCulture), byte.Parse(split[2], CultureInfo.InvariantCulture)));
            }

            return frame;
        }
    }
}
