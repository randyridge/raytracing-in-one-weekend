using System;
using System.Collections.Generic;
using System.IO;
using BenchmarkDotNet.Attributes;
using SharpSharp.Benchmarks;

namespace RayTracing {
    [Config(typeof(RayTracingConfig))]
    public class PpmWriterBenchmarks : IDisposable {
        private const int Height = 100;
        private const int Width = 200;
        private static readonly List<Color> Colors = BuildColors();
        private readonly MemoryStream memoryStream;

        public PpmWriterBenchmarks() {
            memoryStream = new MemoryStream();
        }

        public void Dispose() {
            memoryStream.Dispose();
        }

        [Benchmark]
        public void Write() => PpmWriter.Write(memoryStream, Colors, Width, Height);

        private static List<Color> BuildColors() {
            var result = new List<Color>(Width * Height);
            Span<byte> bytes = new byte[Width * Height * 3];
            var random = new Random();
            random.NextBytes(bytes);
            var b = 0;
            for(var i = 0; i < Width * Height; i++) {
                result.Add(new Color(bytes[b], bytes[b + 1], bytes[b + 2]));
                b += 3;
            }

            return result;
        }
    }
}
